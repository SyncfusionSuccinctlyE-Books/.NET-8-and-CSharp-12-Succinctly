//var greeting = (string personToGreet) => $"Hello, {personToGreet}!";

//Console.WriteLine(greeting("John")); // Hello, John!

var greeting = (string personToGreet = "World") => $"Hello, {personToGreet}!";

Console.WriteLine(greeting()); // Hello, World!