var score = 30;
var c = new Counter();
c.Increment(ref score);

Console.WriteLine($"The score is {score}");

c.Increment(25);

public class Counter
{    
    
     
    public void Increment(ref readonly int score)
    {
        //score++; // This will give a compilation error
    }
}




