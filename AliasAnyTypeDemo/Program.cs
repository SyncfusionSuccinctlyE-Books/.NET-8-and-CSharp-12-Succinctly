

//using Employee = System.Collections.Generic.Dictionary<string, string>;
//using Foo = System.Console;

//Employee employee = new()
//{
//    { "Name", "John Doe" }
//};

//Foo.WriteLine(employee["Name"]);
//Foo.ReadLine();


using TuplePoints = (int x, int y);
using Foo = System.Console;

TuplePoints p = (3, 4);
Foo.WriteLine(p.x);
Foo.WriteLine(p.y);
Foo.ReadLine();