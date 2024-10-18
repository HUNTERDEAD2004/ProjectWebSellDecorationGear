using DecorGearApplication.DataTransferObj.User.Email;
using DecorGearApplication.IServices;
using DecorGearDomain.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;


namespace DecorGearApi.Controllers.User
{
    [ApiController]
    [Route("api/user/[controller]")]
  
    public class MalingController : ControllerBase
    {
        private readonly IMailingServices _mailingServices;
        private readonly IWebHostEnvironment _web;
        private readonly MailSettings _mailSettings;

        public MalingController(IMailingServices mailingServices, IWebHostEnvironment web, IOptions<MailSettings> mailSettings)
        {
            _mailingServices = mailingServices;
            _web = web;
            _mailSettings = mailSettings.Value;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Index([FromForm] MailRequestDto dto)
        {
            if (string.IsNullOrEmpty(dto.MailTo) || string.IsNullOrEmpty(dto.Subject))
            {
                return BadRequest("All fields are required.");
            }

            try
            {
                await _mailingServices.SendEmailAsync(dto.MailTo, dto.Subject, dto.Body, dto.Attachment);
                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while sending the email.");
            }
        }
        [HttpPost("welcome")]
        public async Task<IActionResult> SendWelcomeEmail([FromBody] WelcomeRequestDto dto)
        {
            var builder = new BodyBuilder();
            var pathinfoFile = _web.WebRootPath
                 + Path.DirectorySeparatorChar.ToString()
                 + "Templates"
                 + Path.DirectorySeparatorChar.ToString()
                 + "index.html";
            using (StreamReader streamReader = System.IO.File.OpenText(pathinfoFile))
            {
                builder.HtmlBody = streamReader.ReadToEnd();
            }
            builder.HtmlBody = builder.HtmlBody.Replace("[username]", _mailSettings.Email);
            builder.HtmlBody = builder.HtmlBody.Replace("[email]", _mailSettings.DisplayName);
            await _mailingServices.SendEmailAsync(dto.Email, "Welcome to our channel", builder.HtmlBody);
            return Ok();
        }


    }
}
