﻿namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
    {
        private static TimeSpan maxTime = new TimeSpan(0, 40, 0);

        public Medium(string name)
			: base(name, maxTime)
		{
		}
	}
}