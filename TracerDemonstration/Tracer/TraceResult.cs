using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class MethodInfo
    {
        private List<MethodInfo> inMethods;
        private Stopwatch timer;

        public string Name { get; set; }
        public string ClassName { get; set; }
        public string Time { get; set; }
    }

    public class TraceResult
    {
    }
}
