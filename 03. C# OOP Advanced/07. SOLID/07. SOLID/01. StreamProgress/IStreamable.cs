using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StreamProgress
{
    public interface IStreamable
    {
        int Length { get; }

        int BytesSent { get; }
    }
}
