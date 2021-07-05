using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
namespace AdminDash.BL.Helper
{
    public class MailHelper
    {
        public static String SendMail(string To,string Title , string Message)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);

                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("as8338873@gmail.com", "A@123321A@");
                smtp.Send("as8338873@gmail.com", To,Title,Message);
                

                return "Mail sent";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
