﻿namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Factories;
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private FoodFactory foodFactory;
        private DrinkFactory drinkFactory;
        private TableFactory tableFactory;
        private decimal totalIncome;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
        }

        public string AddFood(string type, string name, decimal price)
        {
            var food = this.foodFactory.CreateFood(type, name, price);
            this.menu.Add(food);

            return $"Added {food.Name} ({food.GetType().Name}) with price {food.Price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            var drink = this.drinkFactory.CreateDrink(type, name, servingSize, brand);
            this.drinks.Add(drink);

            return $"Added {drink.Name} ({drink.Brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            var table = this.tableFactory.CreateTables(type, tableNumber, capacity);
            this.tables.Add(table);

            return $"Added table number {table.TableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = this.tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);
            if(table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);

                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people"; 
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if(table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var food = this.menu.FirstOrDefault(x => x.Name == foodName);
            if(food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {table.TableNumber} ordered {food.Name}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var drink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
            if(drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {table.TableNumber} ordered {drink.Name} {drink.Brand}";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var bill = table.GetBill();
            table.Clear();
            this.totalIncome += bill;

            var sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            var notReserveTables = this.tables.Where(x => x.IsReserved == false).ToArray();

            var sb = new StringBuilder();
            foreach (var table in notReserveTables)
            {
                 sb.AppendLine($"{table.GetFreeTableInfo()}");
            }

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            var notReserveTables = this.tables.Where(x => x.IsReserved == true).ToArray();

            var sb = new StringBuilder();
            foreach (var table in notReserveTables)
            {
                sb.AppendLine($"{table.GetOccupiedTableInfo()}");
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {this.totalIncome:f2}lv";
        }
    }
}
