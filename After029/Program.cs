using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace After029
{
    class Program
    {
        // System.Web.Extensions.dll
        // http://localhost:1234/MyService.svc/json/4
        // http://localhost:1234/MyService.svc/xml/4

        static void Main(string[] args)
        {
            Action action = async () =>
             {
                 var stopwatch = new System.Diagnostics.Stopwatch();

                 Console.WriteLine("JSON (JavaScriptSerializer)");
                 {
                     // fetch data (as JSON string)
                     var url = new Uri("http://localhost:1234/MyService.svc/json/4");
                     var client = new System.Net.WebClient();
                     var json = await client.DownloadStringTaskAsync(url);

                     // deserialize JSON into objects
                     var serializer = new JavaScriptSerializer();
                     var data = serializer.Deserialize<JSONSAMPLE.Data>(json);

                     // use the objects
                     Console.WriteLine(data.Number);
                     foreach (var item in data.Multiples)
                         Console.Write("{0}, ", item);
                 }

                 Console.WriteLine();
                 Console.WriteLine("JSON (DataContractJsonSerializer)");
                 {
                     var url = new Uri("http://localhost:1234/MyService.svc/json/4");
                     var client = new System.Net.WebClient();
                     var json = await client.OpenReadTaskAsync(url);
                     var serializer = new DataContractJsonSerializer(typeof(DATACONTRACT.Data));
                     var data = serializer.ReadObject(json) as DATACONTRACT.Data;
                     Console.WriteLine(data.Number);
                     foreach (var item in data.Multiples)
                         Console.Write("{0}, ", item);
                 }

                 Console.WriteLine();
                 Console.WriteLine("XML");
                 {
                     var url = new Uri("http://localhost:1234/MyService.svc/xml/4");
                     var client = new System.Net.WebClient();
                     var xml = await client.DownloadStringTaskAsync(url);
                     var bytes = Encoding.UTF8.GetBytes(xml);
                     using (MemoryStream stream = new MemoryStream(bytes))
                     {
                         var serializer = new XmlSerializer(typeof(XMLSAMPLE.Data));
                         var data = serializer.Deserialize(stream) as XMLSAMPLE.Data;
                         Console.WriteLine(data.Number);
                         foreach (var item in data.Multiples)
                             Console.Write("{0}, ", item);
                     }
                 }
             };

            action.Invoke();
            Console.Read();
        }
    }

    namespace JSONSAMPLE
    {
        public class Data
        {
            public int Number { get; set; }
            public int[] Multiples { get; set; }
        }
    }

    namespace DATACONTRACT
    {
        [DataContract]
        public class Data
        {
            [DataMember]
            public int Number { get; set; }
            [DataMember]
            public int[] Multiples { get; set; }
        }
    }

    namespace XMLSAMPLE
    {
        [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/SimpleRestService")]
        public class Data
        {
            public int Number { get; set; }
            [XmlArrayItem(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
            public int[] Multiples { get; set; }
        }
    }

}
