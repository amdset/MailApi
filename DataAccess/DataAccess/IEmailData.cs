using MailApi.Models;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public interface IEmailData
    {
        EmailModel CreateEmail(EmailModel model);
        bool DeleteEmail(int id);
        List<EmailModel> GetEmails(string LastName = null, bool Ascending = true);
        EmailModel UpdateEmail(int id, EmailModel email);
    }
}