﻿using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;

        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.IsReserved = false;
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson  { get; private set; }
        public bool IsReserved { get; private set; }
        public decimal Price => this.PricePerPerson * this.NumberOfPeople;

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            var allFoodPrice = this.foodOrders.Sum(x => x.Price);
            var allDrinkPrice = this.drinkOrders.Sum(x => x.Price);

            var result = allFoodPrice + allDrinkPrice + this.Price;

            return result; 
        }

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");

            if (!this.foodOrders.Any())
            {
                sb.AppendLine($"Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {this.foodOrders.Count}");
            }

            foreach (var food in this.foodOrders)
            {
                sb.AppendLine($"{food.ToString()}");
            }

            if (!this.drinkOrders.Any())
            {
                sb.AppendLine($"Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {this.drinkOrders.Count}");
            }

            foreach (var drink in this.drinkOrders)
            {
                sb.AppendLine($"{drink.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.numberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
