using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsDemo.Models;

public class DeniedValuesExampleModel
{
    [DeniedValues("US", "ZAR")]
    public string CountryISO { get; set; } = string.Empty;
}