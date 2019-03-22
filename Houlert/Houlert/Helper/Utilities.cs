using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

  

namespace Houlert.Helper
{
    public class Utilities
    {
        public bool IsEmailValid (string email)
        {
            try
            {
                var emailAddress = new MailAddress(email);
                return emailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
