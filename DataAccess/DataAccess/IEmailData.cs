using MailApi.Models;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public interface IEmailData
    {
        bool CreateEmail(EmailModel model);
        List<EmailModel> GetEmails(string LastName = null, bool Ascending = true);
    }
}