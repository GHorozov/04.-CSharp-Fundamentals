using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StartUp
{
    static void Main(string[] args)
    {
        Scale<int> scale = new Scale<int>(5, 3);
        Console.WriteLine(scale.GetHavier());
    }
}

