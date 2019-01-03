namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
        private const int CONST_REPAIR_AMOUNT = 60;

        public Guitar()
        {
        }

        protected override int RepairAmount => CONST_REPAIR_AMOUNT;
    }
}
