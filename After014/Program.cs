namespace After014
{
    using System;
    using System.Text;

    internal class Program
    {
        private static void Main(string[] args)
        {

            var strings = new StringBuilder();

            strings.AppendLine("FirstName,LastName,Company,Address,City,County,State,ZIP,Phone,Fax,Email,Web");
            strings.AppendLine("Essie,Vaill,Litronic Industries,14225 Hancock Dr,Anchorage,Anchorage,AK,99515,907-345-0962,907-345-1215,essie@vaill.com,http://www.essievaill.com");
            strings.AppendLine("Cruz,Roudabush,Meridian Products,2202 S Central Ave,Phoenix,Maricopa,AZ,85004,602-252-4827,602-252-4009,cruz@roudabush.com,http://www.cruzroudabush.com");
            strings.AppendLine("Billie,Tinnes,D & M Plywood Inc,28 W 27th St,New York,New York,NY,10001,212-889-5775,212-889-5764,billie@tinnes.com,http://www.billietinnes.com");
            strings.AppendLine("Zackary,Mockus,Metropolitan Elevator Co,286 State St,Perth Amboy,Middlesex,NJ,08861,732-442-0638,732-442-5218,zackary@mockus.com,http://www.zackarymockus.com");
            strings.AppendLine("Rosemarie,Fifield,Technology Services,3131 N Nimitz Hwy  #-105,Honolulu,Honolulu,HI,96819,808-836-8966,808-836-6008,rosemarie@fifield.com,http://www.rosemariefifield.com");

            var csv = strings.ToString();

            // split into lines
            var lines = csv.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // split line into fields
            var fields = lines[0].Split(new[] { ',' }, StringSplitOptions.None);

            // create a pipe "|" delimited string instead
            string newLine = string.Join("|", fields);
        }
    }
}