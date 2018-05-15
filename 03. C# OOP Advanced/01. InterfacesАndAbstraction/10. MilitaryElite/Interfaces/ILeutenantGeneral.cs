using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ILeutenantGeneral : IPrivate
{
    IReadOnlyList<IPrivate> PrivateSoldiers { get; }
}

