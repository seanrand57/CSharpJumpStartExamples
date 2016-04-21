using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace After029
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteXml();
            ReadXml();
            Console.Read();
        }

        private static void WriteXml()
        {
            XElement xml;
            XNamespace ns = "http://jerrynixon.com";

            xml = new XElement(ns + "Galaxy", "Space");

            // create xml with default namespace
            Debugger.Break();

            xml = new XElement(ns + "Galaxy", "Space",
                new XAttribute(XNamespace.Xmlns + "j", ns));

            // create xml with qualified namespace
            Debugger.Break();

            xml = new XElement("Galaxy", "Space", new XAttribute("Name", "Milky Way"));

            // create xml with text and attributes
            Debugger.Break();

            xml = new XElement("Galaxy", "Space", new XAttribute("Name", "Milky Way"),
                    new XElement("SolarSystem",
                        new XAttribute("Name", "Sol"),
                        new XElement("Planet", "Mercury", new XAttribute("Position", "1")),
                        new XElement("Planet", "Venus", new XAttribute("Position", "2")),
                        new XElement("Planet", "Earth", new XAttribute("Position", "3")),
                        new XElement("Planet", "Mars", new XAttribute("Position", "4"))
                        )
                    );

            // create xml with child elements
            Debugger.Break();
        }

        private static void ReadXml()
        {
            var text = "<Galaxy Name=\"Milky Way\">Space<SolarSystem Name=\"Sol\"><Planet Position=\"1\">Mercury</Planet><Planet Position=\"2\">Venus</Planet><Planet Position=\"3\">Earth</Planet><Planet Position=\"4\">Mars</Planet></SolarSystem></Galaxy>";
            var xml = XElement.Parse(text);
            string value;

            value = xml.Value;

            // read deep values
            Debugger.Break();

            var texts = xml
                .Nodes().OfType<XText>()
                .Select(x => x.Value);
            value = texts.Any() ? string.Join(string.Empty, texts) : "EMPTY";

            // read shallow values
            Debugger.Break();

            value = xml
                .Attribute("Name").Value;

            // read attributes
            Debugger.Break();

            value = xml
                .Descendants("SolarSystem").First()
                .Attribute("Name").Value;

            // navigate descendents
            Debugger.Break();

            var planet = xml
                .Descendants("SolarSystem").First()
                .DescendantNodes().First();
            while (planet != null)
            {
                Console.WriteLine("Planet: {0}", (planet as XElement).Value);
                planet = planet.NextNode;
            }

            // use nextnode to sibling
            Debugger.Break();

            value = xml
                .Descendants("SolarSystem").First()
                .Elements().ToArray()[2].Value;

            // leverage LINQ, find third planet
            Debugger.Break();
        }
    }
}
