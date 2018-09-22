using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class Tracer : ITracer
    {
        public void StartTrace() { }
        public void StopTrace() { }
        public TraceResult GetTraceResult()
        {
            return new TraceResult();
        }
    }
}
