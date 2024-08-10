namespace Slots
{
    public class Program
    {
        static void Main(string[] args)
        {
            int rows = 3;

            if (args != null && args.Length != 0)
            {
                int.TryParse(args[0], out rows);
            }

            SlotSession session = new(slotRows: rows);

            session.StartReels();
            session.DisplaySlotResults();
        }
    }
}
