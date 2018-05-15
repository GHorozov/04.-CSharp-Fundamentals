using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICreature : IBuyer
{
    string Name { get; }
    int Age { get; }
}

