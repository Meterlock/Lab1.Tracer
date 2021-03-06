﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tracer
{
    public class Tracer : ITracer
    {
        private TraceResult res;

        public Tracer()
        {
            res = new TraceResult();
        }

        public void StartTrace()
        {
            MethodBase mb = new StackTrace().GetFrame(1).GetMethod();
            var method = new MethodInfo();
            method.ClassName = mb.ReflectedType.Name;
            method.Name = mb.Name;
            ThreadInfo currentThread = res.GetThread(Thread.CurrentThread.ManagedThreadId);
            currentThread.StartMethodTracing(method);
        }

        public void StopTrace()
        {
            res.GetThread(Thread.CurrentThread.ManagedThreadId).StopMethodTracing();            
        }

        public TraceResult GetTraceResult()
        {
            return res;
        }
    }
}
