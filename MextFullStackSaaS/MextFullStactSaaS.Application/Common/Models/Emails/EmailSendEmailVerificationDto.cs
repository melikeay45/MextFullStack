using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStactSaaS.Application.Common.Models.Emails
{
    public class EmailSendEmailVerificationDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Token { get; set; }

        public EmailSendEmailVerificationDto(string email, string firstName, string token)
        {
            Email = email;
            FirstName = firstName;
            Token = token;
        }

        public EmailSendEmailVerificationDto()
        {

        }
    }
}
