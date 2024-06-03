using System.Buffers;
using System.Collections.Frozen;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CodeSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region What has changed in .NET 8 - Garbage Collection
            //// What has changed in .NET 8 - Garbage Collection
            //AppContext.SetData("GCHeapHardLimit", (ulong)100 * 1024 * 1024); // 100 MB
            //GC.RefreshMemoryLimit(); 
            #endregion

            #region What has changed in .NET 8 - Core .NET Libraries - Serialization
            //// What has changed in .NET 8 - Core .NET Libraries - Serialization
            //try
            //{
            //    var pers = JsonSerializer.Deserialize<Person>("""{"Name": "John" ,"Age": 44, "YearOfBirth" : 1980 }""");
            //    Console.WriteLine(pers?.Name);                
            //}
            //catch (JsonException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //Console.ReadLine(); 
            #endregion

            #region What has changed in .NET 8 - Core .NET Libraries - Serialization
            //// What has changed in .NET 8 - Core .NET Libraries - Serialization
            //Student student = new()
            //{
            //    Name = "Wile E. Coyote",
            //    Age = 74,
            //    SchoolName = "Acme Code School",
            //    SchoolAddress = "1234 Desert Road, Arizona"
            //};

            //var options = new JsonSerializerOptions
            //{
            //    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            //};

            //string json = JsonSerializer.Serialize(student, options); 
            #endregion

            #region What has changed in .NET 8 - Core .NET Libraries - Serialization
            //// What has changed in .NET 8 - Core .NET Libraries - Serialization
            //StockItem? stockItem = JsonSerializer.Deserialize<StockItem>("""
            //    {"StockCode": "1234", "Pricing":{"MarkupPercentage": 17, "Quantity": 7} }
            //    """);

            //var json = JsonSerializer.Serialize(stockItem); 
            #endregion

            #region What has changed in .NET 8 - Core .NET Libraries - Randomness
            // What has changed in .NET 8 - Core .NET Libraries - Randomness

            var cities = new[]
            {
                "Raleigh", "Tampa", "Los Angeles", "New York", "Chicago"
            };

            Random.Shared.Shuffle(cities);

            foreach (var c in cities)
            {
                Console.WriteLine(c);
            }


            //var generatedCities = Random.Shared.GetItems<string>(cities, 3);

            //foreach (var c in generatedCities)
            //{
            //    Console.WriteLine(c);
            //}


            //var hexStr = RandomNumberGenerator.GetHexString(25);
            //// 9CDCD0C99A7E471DE5F4D2E0F

            //var genString = RandomNumberGenerator.GetString("abcdefgABCDEFG0123456789=><!@#$%^*()-+&", 15);
            //// G#7cg-g9g5g=b16 
            #endregion

            #region What has changed in .NET 8 - Core .NET Libraries -  Performance-focused Types
            //// What has changed in .NET 8 - Core .NET Libraries -  Performance-focused Types

            //// FrozenSet
            //var lst = new List<string> { "John", "Mark", "Jane", "Jeremy", "Daton", "Sally", "Mary" };

            //var frozenSet = lst.ToFrozenSet();
            //var willTheRealJeremyPleaseStandup = frozenSet.Contains("Jeremy");

            ////ISet<string> set = frozenSet;
            ////set.Add("Slim Shady"); // This will throw an error


            //// FrozenDictionary
            //var dictionary = new Dictionary<string, int>
            //{
            //    { "John", 38 },
            //    { "Mark", 42 },
            //    { "Jane", 24 },
            //};

            //var frozenDictionary = dictionary.ToFrozenDictionary();

            //// SearchValues

            //var strSear = @"<>:""/\|?*";
            //SearchValues<char> illegalChars = SearchValues.Create(strSear);

            //var fileName = @"Important_|_File.txt";

            //var illegal = fileName.AsSpan().ContainsAny(illegalChars);
            //// illegal = true

            #endregion

            Console.ReadLine();

        }
    }

    #region What has changed in .NET 8 - Core .NET Libraries - Serialization
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
    public class Person
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }
    #endregion

    #region What has changed in .NET 8 - Core .NET Libraries - Serialization
    public class Student : Person
    {
        public required string SchoolName { get; set; }
        public required string SchoolAddress { get; set; }
    }
    #endregion

    #region What has changed in .NET 8 - Core .NET Libraries - Serialization
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public class StockItem
    {
        public required string StockCode { get; set; }

        public PricingData Pricing { get; } = new()
        {
            MarkupPercentage = 15,
            Quantity = 1
        };
    }

    public class PricingData
    {
        public required int MarkupPercentage { get; set; }
        public required int Quantity { get; set; }
    }
    #endregion




    

}
