namespace After012
{
    using System;
    using System.Text;

    internal class Program
    {
        private static void Main(string[] args)
        {
            // create a stringbuilder instance
            var sb = new StringBuilder();

            // append lines
            sb.AppendLine("This is the original first line");
            sb.AppendLine("This is another line");
            
            // append formatted values
            for (int i = 0; i < 10; i++)
            {
                sb.AppendFormat(
                    "Inserting line with loop index {0,5} on {1,9:d} {2}", i, DateTime.Now, Environment.NewLine);
            }

            // replace values
            sb.Replace("index", "counter");

            // insert 
            var newLine = string.Format("This is a new first line {0}", Environment.NewLine);
            sb.Insert(0, newLine);

            // remove
            sb.Remove(0, newLine.Length);

            // convert to a string
            var s1 = sb.ToString();

            // convert a subset to a string
            var s2 = sb.ToString(10, 10);
        }
    }
}