namespace SoalTes_FullStack_NET_V1
{
    public class DebuggingAndErroHandling
    {
        public int AddNumbers(int a, int b)
        {
            try
            {
                int result = a + b;
                return result;
            }
            catch (Exception ex) { System.Console.WriteLine(ex); }
        }
    }
}
