namespace StorageMaster
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
                var args = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = args[0];
                args = args.Skip(1).ToArray();

                try
                {
                    switch (command)
                    {
                        case "AddProduct":
                            Console.WriteLine(this.storageMaster.AddProduct(args[0], double.Parse(args[1])));
                            break;
                        case "RegisterStorage":
                            Console.WriteLine(this.storageMaster.RegisterStorage(args[0], args[1]));
                            break;
                        case "SelectVehicle":
                            Console.WriteLine(this.storageMaster.SelectVehicle(args[0], int.Parse(args[1])));
                            break;
                        case "LoadVehicle":
                            Console.WriteLine(this.storageMaster.LoadVehicle(args));
                            break;
                        case "SendVehicleTo":
                            Console.WriteLine(this.storageMaster.SendVehicleTo(args[0], int.Parse(args[1]), args[2]));
                            break;
                        case "UnloadVehicle":
                            Console.WriteLine(this.storageMaster.UnloadVehicle(args[0], int.Parse(args[1])));
                            break;
                        case "GetStorageStatus":
                            Console.WriteLine(this.storageMaster.GetStorageStatus(args[0]));
                            break;
                        default:
                            throw new InvalidOperationException("Wrong  command!");
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(this.storageMaster.GetSummary());
        }
    }
}
