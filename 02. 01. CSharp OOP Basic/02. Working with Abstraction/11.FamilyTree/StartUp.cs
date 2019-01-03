namespace _11.FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            string personInput = Console.ReadLine();
            FamilyTreeBuilder familyTreeBuilder = new FamilyTreeBuilder(personInput);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                familyTreeBuilder.ParseInput( command);
            }

            familyTreeBuilder.PrintPersonTree();
        }       
    }
}
