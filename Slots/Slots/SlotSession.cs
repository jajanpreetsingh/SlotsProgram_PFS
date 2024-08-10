using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slots
{
    public class SlotSession
    {
        private PayoutTable _payoutTable;
        private ReelSet _reelSet;
        private List<List<int>> _slotResults;
        private List<List<Symbols>> _screenOutput;
        private int _slotRows;
        private int _maxRows = 0;

        public SlotSession(int slotRows)
        {
            _payoutTable = new();
            _reelSet = new ReelSet();
            _slotRows = slotRows;
            _screenOutput = new();
            _slotResults = new List<List<int>>();

            _maxRows = _reelSet.Bands.Min(band => band.Count);
        }

        public void StartReels()
        {
            if (BadRowInput())
            {
                return;
            }

            for (int bandIndex = 0; bandIndex < _reelSet.Bands.Count; bandIndex++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());

                int bandCount = _reelSet.Bands[bandIndex].Count;

                int topRowIndex = rand.Next(0, bandCount);

                List<int> bandResult = new List<int>();

                bandResult.Add(topRowIndex);

                int rowsToDecide = _slotRows - 1;
                int distanceFromTop = 0;


                while (rowsToDecide > 0)
                {
                    ++distanceFromTop;

                    int nextRowIndex = GetNextRowSymbolIndex(topRowIndex, distanceFromTop, bandCount);

                    bandResult.Add(nextRowIndex);

                    --rowsToDecide;
                }

                _slotResults.Add(bandResult);
            }

            DetermineScreenOutput();
        }

        public void DisplaySlotResults()
        {
            if (_screenOutput == null || _screenOutput.Count < 1)
            {
                return;
            }

            StringBuilder stopPositions = new StringBuilder("Stop Positions : \n");

            if (_slotResults == null)
            {
                return;
            }

            foreach (List<int> bandResult in _slotResults)
            {
                stopPositions.Append(bandResult[0] + ", ");
            }

            Console.WriteLine(stopPositions.ToString());

            StringBuilder symbols = new StringBuilder("Screen : \n");

            for (int rowIndex = 0; rowIndex < _slotRows; rowIndex++)
            {
                for (int bandIndex = 0; bandIndex < _slotResults.Count; bandIndex++)
                {
                    List<int> bandResult = _slotResults[bandIndex];

                    symbols.Append((_reelSet.Bands[bandIndex][bandResult[rowIndex]]).ToString() + "  ");
                }

                symbols.Append("\n");
            }

            Console.WriteLine(symbols.ToString());

            Console.WriteLine("Total Wins : " + CalculateWins(_screenOutput));
        }

        public int CalculateWins(List<List<Symbols>> _screenOutput)
        {
            int result = 0;

            foreach (List<Symbols> rowOutput in _screenOutput)
            {
                _payoutTable.Records.ForEach(record =>
                {
                    if (SequenceExists(record, rowOutput))
                    {
                        result += record.Score;
                    }
                });
            }

            return result;
        }

        private bool SequenceExists(PayoutTableRecord record, List<Symbols> rowOutput)
        {
            int counter = 0;

            for (int i = 0; i < rowOutput.Count; i++)
            {
                if (rowOutput[i] == record.Symbol)
                {
                    ++counter;
                }
                else if(counter < 3)
                {
                    counter = 0;
                }
            }

            return counter == record.RequiredMatchCount;
        }

        private void DetermineScreenOutput()
        {
            _screenOutput = new();

            for (int rowIndex = 0; rowIndex < _slotRows; rowIndex++)
            {
                List<Symbols> rowOutput = new();

                for (int bandIndex = 0; bandIndex < _slotResults.Count; bandIndex++)
                {
                    List<int> bandResult = _slotResults[bandIndex];

                    Symbols symbol = _reelSet.Bands[bandIndex][bandResult[rowIndex]];

                    rowOutput.Add(symbol);
                }

                _screenOutput.Add(rowOutput);
            }
        }

        private int GetNextRowSymbolIndex(int topRowIndex, int count, int bandCount)
        {
            int resultIndex = topRowIndex;

            while (count > 0)
            {
                ++resultIndex;

                if (resultIndex > bandCount - 1)
                {
                    resultIndex = 0;
                }

                --count;
            }

            return resultIndex;
        }

        private bool BadRowInput()
        {
            if (_slotRows < 1 || _slotRows > _maxRows)
            {
                Console.WriteLine("(Min,Max) rows supported by current reel set : ( 1, " + _maxRows + ")"
                    + "\nQuitting session ... ");

                return true;
            }

            return false;
        }
    }
}
