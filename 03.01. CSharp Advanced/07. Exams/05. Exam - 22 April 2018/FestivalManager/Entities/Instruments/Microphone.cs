namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
        private const int CONST_REPAIR_AMOUNT = 80;

        public Microphone()
        {
        }

        protected override int RepairAmount => CONST_REPAIR_AMOUNT;
    }
}
