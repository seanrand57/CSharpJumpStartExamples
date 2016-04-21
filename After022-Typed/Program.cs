namespace After022_Typed
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Process();
            }
            catch (DivideByZeroException ex)
            {
                // specific exception
            }
            catch (Exception ex)
            {
                // generic exception
            }
            finally
            {
                // this will always occur
            }
        }

        private static void Process()
        {
            throw new NotImplementedException();
        }
    }
}