namespace Slots
{
    public class Program
    {
        static void Main(string[] args)
        {
            SlotSession session = new(slotRows: 3);

            session.StartReels();
            session.DisplaySlotResults();
        }
    }
}
