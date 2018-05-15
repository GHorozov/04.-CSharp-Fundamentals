using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ICar
{
    string Name { get; }
    string Model { get; }
    string Break();

    string Gas();
}

