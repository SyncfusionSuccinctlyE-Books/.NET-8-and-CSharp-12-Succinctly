using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsDemo.Models;

public class LengthExampleModel
{
    [Length(1, 3)]
    public ICollection<int> TestResults { get; set; } = Array.Empty<int>();
}