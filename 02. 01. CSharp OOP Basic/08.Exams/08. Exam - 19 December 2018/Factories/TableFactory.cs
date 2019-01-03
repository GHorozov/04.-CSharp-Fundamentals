using SoftUniRestaurant.Models.Tables;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class TableFactory
    {
        public ITable CreateTables(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if(type == "Inside")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if(type == "Outside")
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            else
            {
                throw new InvalidOperationException("Invalid table type!");
            }

            return table;
        }
    }
}
