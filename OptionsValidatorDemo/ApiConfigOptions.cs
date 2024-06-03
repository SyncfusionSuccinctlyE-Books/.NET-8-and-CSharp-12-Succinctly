using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace OptionsValidatorDemo
{
    enum NotificationType
    {
        Email,
        Sms,
        Push
    }    

    public class ApiConfigOptions
    {
        public const string SectionName = "ApiOptions";

        [EnumDataType(typeof(NotificationType)
            , ErrorMessage = "Invalid notification type defined.")]
        public required string NotificationType { get; init; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
            , ErrorMessage = "Invalid notification email address defined")]        
        public required string NotificationEmailAddress { get; init; }


        [Required]
        [Range(1, 3
            , ErrorMessage = "The value for Attempts is outside the valid range.")]
        public required int Attempts { get; init; }
    }

    [OptionsValidator]
    public partial class  ApiConfigOptionsValidator : IValidateOptions<ApiConfigOptions>
    {
        
    }
}