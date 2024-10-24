using Microsoft.AspNetCore.Http;

namespace DecorGearApplication.IServices
{
    public interface IMailingServices
    {
        Task<int> SendEmailAsync(string mailto, string subject, string body, IList<IFormFile> attachments = null);
    }
}
