using MailApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.DataAccess
{
    public class EmailData : IEmailData
    {
        public static List<EmailModel> emailModels = new List<EmailModel>();

        public bool CreateEmail(EmailModel model)
        {
            emailModels.Add(model);
            return true;
        }

        public List<EmailModel> GetEmails(string LastName = null, bool Ascending = true)
        {
            var emails = emailModels;
            if (!string.IsNullOrWhiteSpace(LastName))
            {
                emails = emails.Where(e => (e.LastName ?? "").ToLower().Contains(LastName.ToLower())).ToList();
            }
            if (Ascending)
            {
                emails = emails.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList();
            }
            else
            {
                emails = emails.OrderByDescending(e => e.LastName).ThenByDescending(e => e.FirstName).ToList();
            }

            return emails;
        }

        // public UpdateEmaail

    }
}
