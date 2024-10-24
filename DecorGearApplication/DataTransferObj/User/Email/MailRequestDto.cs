using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.User.Email
{
    public class MailRequestDto
    {
        [Required]
        public string MailTo { get; set; }
        [Required]
        public string Subject { get; set; }

        public string? Body { get; set; }
        public IList<IFormFile>? Attachment { get; set; }
    }
}
