using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace Tracer
{
    public class SerializerJSON : ISerializer
    {
        public void Serialize(Stream stream, TraceResult traceResult)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(TraceResult));
            using (stream)
            {
                jsonFormatter.WriteObject(stream, traceResult);
            }
        }
    }

    public class SerializerXML : ISerializer
    {
        public void Serialize(Stream stream, TraceResult traceResult)
        {

        }
    }
}
