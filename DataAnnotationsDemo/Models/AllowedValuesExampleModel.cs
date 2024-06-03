using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsDemo.Models;

public class AllowedValuesExampleModel
{
    [AllowedValues("USA", "GBR", "ZAF")]
    public string CountryISO { get; set; } = string.Empty;
}