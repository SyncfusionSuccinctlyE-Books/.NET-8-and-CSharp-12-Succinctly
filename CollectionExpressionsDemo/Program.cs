namespace CollectionExpressionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] scores = new int[] { 97, 92, 81, 60 };
            int[] scores = [97, 92, 81, 60];
                        
            //Span<int> foo = new int[] { 'a', 'b', 'c' };
            Span<int> foo = ['a', 'b', 'c'];
        }
    }
}
