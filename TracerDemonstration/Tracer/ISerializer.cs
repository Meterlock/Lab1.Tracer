using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public interface ISerializer
    {
        void Serialize(Stream stream, TraceResult traceResult);
    }
}
