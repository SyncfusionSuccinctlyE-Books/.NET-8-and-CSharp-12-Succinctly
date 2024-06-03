using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsDemo.Models;

public class RangeExampleModel
{
    [Range(20, 80, MinimumIsExclusive = true, MaximumIsExclusive = true)]
    public int Threshold { get; set; }
}
