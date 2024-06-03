using System.Diagnostics.CodeAnalysis;

var person = new Person { Name = "John" };

var age = person.GetAge(1980);
var guid = Guid.NewGuid();
//var age2 = person.GetAge(guid);

Console.WriteLine(age);

public class Person
{
    public string Name { get; set; }
    

    public int GetAge(int yearBorn)
    {
        // Do some standard calculation
        // Just return default for now

        return default;
    }

    [Experimental("fef6b55e36f753c893f5afe8435bcca1"
        , UrlFormat = "https://gist.github.com/dirkstrauss/{0}")]
    public int GetAge(Guid guid)
    {
        // Do advanced experimental calculation
        // Just return default for now

        return default;
    }
}