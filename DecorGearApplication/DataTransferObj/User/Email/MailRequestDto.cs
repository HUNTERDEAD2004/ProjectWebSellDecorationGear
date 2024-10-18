﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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