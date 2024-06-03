using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsDemo.Models;

public class Base64ExampleModel
{
    [Base64String]
    public string SystemInput { get; set; } = string.Empty;
}