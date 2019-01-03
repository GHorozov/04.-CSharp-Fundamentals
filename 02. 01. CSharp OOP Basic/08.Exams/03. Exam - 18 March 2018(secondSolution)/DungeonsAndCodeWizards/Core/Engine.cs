namespace DungeonsAndCodeWizards.Core
{
    using DungeonsAndCodeWizards.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        private DungeonMaster dungeonMaster;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string input = this.reader.ReadLine();
                try
                {
                    ReadCommand(input);
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine("Parameter Error: " + ex.Message);
                }
                catch (InvalidOperationException e)
                {
                    this.writer.WriteLine("Invalid Operation: " + e.Message);
                }

                if (this.dungeonMaster.IsGameOver() || this.isRunning == false)
                {
                    this.writer.WriteLine("Final stats:");
                    this.writer.WriteLine(dungeonMaster.GetStats());
                    this.isRunning = false;
                }
            }
        }

        private void ReadCommand(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                this.isRunning = false;
                return;
            }

            var inputArgs = input
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            var command = inputArgs[0];
            var args = inputArgs.Skip(1).ToArray();

            switch (command)
            {
                case "JoinParty":
                    this.writer.WriteLine(dungeonMaster.JoinParty(args));
                    break;
                case "AddItemToPool":
                    this.writer.WriteLine(dungeonMaster.AddItemToPool(args));
                    break;
                case "PickUpItem":
                    this.writer.WriteLine(dungeonMaster.PickUpItem(args));
                    break;
                case "UseItem":
                    this.writer.WriteLine(dungeonMaster.UseItem(args));
                    break;
                case "UseItemOn":
                    this.writer.WriteLine(dungeonMaster.UseItemOn(args));
                    break;
                case "GiveCharacterItem":
                    this.writer.WriteLine(dungeonMaster.GiveCharacterItem(args));
                    break;
                case "GetStats":
                    this.writer.WriteLine(dungeonMaster.GetStats());
                    break;
                case "Attack":
                    this.writer.WriteLine(dungeonMaster.Attack(args));
                    break;
                case "Heal":
                    this.writer.WriteLine(dungeonMaster.Heal(args));
                    break;
                case "EndTurn":
                    this.writer.WriteLine(dungeonMaster.EndTurn(args));
                    break;
            }
        }
    }
}
