using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slots
{
    public enum Symbols
    {
        Sym1,
        Sym2,
        Sym3,
        Sym4,
        Sym5,
        Sym6,
        Sym7,
        Sym8
    }

    public struct PayoutTableRecord
    {
        public Symbols Symbol;
        public int RequiredMatchCount;
        public int Score;

        public PayoutTableRecord(int score, Symbols symbol, int matchCount)
        {
            Symbol = symbol;
            Score = score;
            RequiredMatchCount = matchCount;
        }
    }

    public class PayoutTable
    {
        public List<PayoutTableRecord> Records = new List<PayoutTableRecord>()
        {
            new(50, Symbols.Sym8, 5),
            new(20, Symbols.Sym8, 4),
            new(10, Symbols.Sym8, 3),

            new(20, Symbols.Sym7, 5),
            new(10, Symbols.Sym7, 4),
            new(5, Symbols.Sym7,  3),

            new(15, Symbols.Sym6, 5),
            new(10, Symbols.Sym6, 4),
            new(5, Symbols.Sym6,  3),

            new(15, Symbols.Sym5, 5),
            new(10, Symbols.Sym5, 4),
            new(5, Symbols.Sym5,  3),

            new(10, Symbols.Sym4, 5),
            new(5, Symbols.Sym4,  4),
            new(2, Symbols.Sym4,  3),

            new(5, Symbols.Sym3, 5),
            new(2, Symbols.Sym3, 4),
            new(1, Symbols.Sym3, 3),

            new(3, Symbols.Sym2, 5),
            new(2, Symbols.Sym2, 4),
            new(1, Symbols.Sym2, 3),

            new(3, Symbols.Sym1, 5),
            new(2, Symbols.Sym1, 4),
            new(1, Symbols.Sym1, 3)
        };

        public PayoutTable()
        {
            Records = Records.OrderByDescending(x=> x.Score).ToList();
        }
    }

    public class ReelSet
    {
        public List<List<Symbols>> Bands = new List<List<Symbols>>()
        {
            new List<Symbols>()
            {
                Symbols.Sym2, Symbols.Sym7, Symbols.Sym7, Symbols.Sym1, Symbols.Sym1, Symbols.Sym5,
                Symbols.Sym1, Symbols.Sym4, Symbols.Sym5, Symbols.Sym3, Symbols.Sym2, Symbols.Sym3,
                Symbols.Sym8, Symbols.Sym4, Symbols.Sym5, Symbols.Sym2, Symbols.Sym8, Symbols.Sym5,
                Symbols.Sym7, Symbols.Sym2
            },


            new List<Symbols>()
            {
                Symbols.Sym1, Symbols.Sym6, Symbols.Sym7, Symbols.Sym6, Symbols.Sym5, Symbols.Sym5,
                Symbols.Sym8, Symbols.Sym5, Symbols.Sym5, Symbols.Sym4, Symbols.Sym7, Symbols.Sym2,
                Symbols.Sym5, Symbols.Sym7, Symbols.Sym1, Symbols.Sym5, Symbols.Sym6, Symbols.Sym8,
                Symbols.Sym7, Symbols.Sym6, Symbols.Sym3, Symbols.Sym3, Symbols.Sym6, Symbols.Sym7, Symbols.Sym3
            },

            new List<Symbols>()
            {
                Symbols.Sym5, Symbols.Sym2, Symbols.Sym7, Symbols.Sym8, Symbols.Sym3, Symbols.Sym2,
                Symbols.Sym6, Symbols.Sym2, Symbols.Sym2, Symbols.Sym5, Symbols.Sym3, Symbols.Sym5,
                Symbols.Sym1, Symbols.Sym6, Symbols.Sym3, Symbols.Sym2, Symbols.Sym4, Symbols.Sym1,
                Symbols.Sym6, Symbols.Sym8, Symbols.Sym6, Symbols.Sym3, Symbols.Sym4, Symbols.Sym4,
                Symbols.Sym8, Symbols.Sym1, Symbols.Sym7, Symbols.Sym6, Symbols.Sym1, Symbols.Sym6
            },

            new List<Symbols>()
            {
                Symbols.Sym2, Symbols.Sym6, Symbols.Sym3, Symbols.Sym6, Symbols.Sym8, Symbols.Sym8, 
                Symbols.Sym3, Symbols.Sym6, Symbols.Sym8, Symbols.Sym1, Symbols.Sym5, Symbols.Sym1, 
                Symbols.Sym6, Symbols.Sym3, Symbols.Sym6, Symbols.Sym7, Symbols.Sym2, Symbols.Sym5, 
                Symbols.Sym3, Symbols.Sym6, Symbols.Sym8, Symbols.Sym4, Symbols.Sym1, Symbols.Sym5, Symbols.Sym7 },

            new List<Symbols>()
            {
                Symbols.Sym7, Symbols.Sym8, Symbols.Sym2, Symbols.Sym3, Symbols.Sym4, Symbols.Sym1,
                Symbols.Sym3, Symbols.Sym2, Symbols.Sym2, Symbols.Sym4, Symbols.Sym4, Symbols.Sym2,
                Symbols.Sym6, Symbols.Sym4, Symbols.Sym1, Symbols.Sym6, Symbols.Sym1, Symbols.Sym6, Symbols.Sym4, Symbols.Sym8
            }
        };
    }
}
