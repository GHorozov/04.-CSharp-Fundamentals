namespace FestivalManager.Entities.Instruments
{
	public class Drums : Instrument
	{
        private const int CONST_REPAIR_AMOUNT = 20;

        public Drums()
        {
        }

        protected override int RepairAmount => CONST_REPAIR_AMOUNT;
    }
}
