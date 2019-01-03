namespace StorageMaster.Core
{
    using System;
    using System.Linq;

    public class Engine
    {
        private StorageMaster storageMaster;

        public Engine()
        {
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var command = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var args = command.Skip(1).ToArray();
                try
                {
                    switch (command[0])
                    {
                        case "AddProduct":
                            Console.WriteLine(storageMaster.AddProduct(args[0], double.Parse(args[1])));
                            break;
                        case "RegisterStorage":
                            Console.WriteLine(storageMaster.RegisterStorage(args[0], args[1]));
                            break;
                        case "SelectVehicle":
                            Console.WriteLine(storageMaster.SelectVehicle(args[0], int.Parse(args[1])));
                            break;
                        case "LoadVehicle":
                            Console.WriteLine(storageMaster.LoadVehicle(args));
                            break;
                        case "SendVehicleTo":
                            Console.WriteLine(storageMaster.SendVehicleTo(args[0], int.Parse(args[1]), args[2]));
                            break;
                        case "UnloadVehicle":
                            Console.WriteLine(storageMaster.UnloadVehicle(args[0], int.Parse(args[1])));
                            break;
                        case "GetStorageStatus":
                            Console.WriteLine(storageMaster.GetStorageStatus(args[0]));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            Console.WriteLine(storageMaster.GetSummary());
        }
    }
}

