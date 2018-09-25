﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    class ConsoleWriter : IWriter
    {
        public void Write(ISerializer serializer, TraceResult traceResult)
        {
            using (Stream console = Console.OpenStandardOutput())
            {
                serializer.Serialize(console, traceResult);
            }
        }
    }
}