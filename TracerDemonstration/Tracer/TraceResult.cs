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
        private Stopwatch timer;
        private List<MethodInfo> insideMethods;        

        public MethodInfo()
        {
            timer = new Stopwatch();
            insideMethods = new List<MethodInfo>();           
        }

        public string Name { get; set; }
        public string ClassName { get; set; }

        public long Time
        {
            get
            {
                return timer.ElapsedMilliseconds;
            }
        }

        public string TimeStr { get { return Time.ToString() + "ms"; } set { } }

        public List<MethodInfo> InsideMethods
        {
            get
            {
                return new List<MethodInfo>(insideMethods);
            }
            set { }
        }        

        internal void StartTrace()
        {
            timer.Start();
        }

        internal void StopTrace()
        {
            timer.Stop();
        }

        internal void InsideMethodAdd(MethodInfo method)
        {
            insideMethods.Add(method);
        }
    }


    public class TraceResult
    {
    }
}
