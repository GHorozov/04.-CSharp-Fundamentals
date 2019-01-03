namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
		public Medium(string name)
			: base(name, new TimeSpan(00,40,00))
		{
		}
	}
}