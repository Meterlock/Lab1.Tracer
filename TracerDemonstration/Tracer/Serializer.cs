using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Tracer
{
    public class SerializerJSON : ISerializer
    {
        public void Serialize(Stream stream, TraceResult traceResult)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(TraceResult));
            using (var jsonWriter = JsonReaderWriterFactory.CreateJsonWriter(stream, Encoding.UTF8, true, true))
            {
                jsonFormatter.WriteObject(jsonWriter, traceResult);
            }
        }
    }


    public class SerializerXML : ISerializer
    {
        public void Serialize(Stream stream, TraceResult traceResult)
        {
            var xmlFormatter = new DataContractSerializer(typeof(TraceResult));
            var set = new XmlWriterSettings();
            set.Indent = true;
            using (var xmlWriter = XmlWriter.Create(stream, set))
            {
                xmlFormatter.WriteObject(xmlWriter, traceResult);
            }

        }
    }
}
