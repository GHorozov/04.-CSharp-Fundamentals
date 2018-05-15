using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IPhone
{
    string Model { get; }

    string Call(string phoneNumber);
}

