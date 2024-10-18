using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.IServices
{
    public interface IMailingServices 
    {
        Task<int> SendEmailAsync(string mailto, string subject, string body, IList<IFormFile> attachments = null);
    }
}
