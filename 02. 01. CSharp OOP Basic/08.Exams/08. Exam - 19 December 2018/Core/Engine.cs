using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Core
{
    public class Engine
    {
        private RestaurantController restaurantController;

        public Engine()
        {
            this.restaurantController = new RestaurantController();
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = args[0];
                args = args.Skip(1).ToArray();

                try
                {
                    switch (command)
                    {
                        case "AddFood":
                            Console.WriteLine(this.restaurantController.AddFood(args[0], args[1], decimal.Parse(args[2])));
                            break;
                        case "AddDrink":
                            Console.WriteLine(this.restaurantController.AddDrink(args[0], args[1], int.Parse(args[2]), args[3]));
                            break;
                        case "AddTable":
                            Console.WriteLine(this.restaurantController.AddTable(args[0], int.Parse(args[1]), int.Parse(args[2])));
                            break;
                        case "ReserveTable":
                            Console.WriteLine(this.restaurantController.ReserveTable(int.Parse(args[0])));
                            break;
                        case "OrderFood":
                            Console.WriteLine(this.restaurantController.OrderFood(int.Parse(args[0]), args[1]));
                            break;
                        case "OrderDrink":
                            Console.WriteLine(this.restaurantController.OrderDrink(int.Parse(args[0]), args[1], args[2]));
                            break;
                        case "LeaveTable":
                            Console.WriteLine(this.restaurantController.LeaveTable(int.Parse(args[0])));
                            break;
                        case "GetFreeTablesInfo":
                            Console.WriteLine(this.restaurantController.GetFreeTablesInfo());
                            break;
                        case "GetOccupiedTablesInfo":
                            Console.WriteLine(this.restaurantController.GetOccupiedTablesInfo());
                            break;
                        default:
                            throw new InvalidOperationException("Wrong command!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(this.restaurantController.GetSummary());
        }
    }
}
