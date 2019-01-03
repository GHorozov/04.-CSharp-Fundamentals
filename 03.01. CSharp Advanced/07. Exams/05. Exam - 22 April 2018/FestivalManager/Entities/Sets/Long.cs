namespace FestivalManager.Entities.Sets
{
    using System;

    public class Long : Set
    {
        private static TimeSpan maxTime = new TimeSpan(1, 0, 0);

        public Long(string name)
            : base(name, maxTime)
        {
        }
    }
}
