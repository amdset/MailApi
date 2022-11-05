using MailApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class EmailData : IEmailData
    {
        public static List<EmailModel> lstEmails = new List<EmailModel>();

        public EmailModel CreateEmail(EmailModel model)
        {
            model.Id = CreateId();
            lstEmails.Add(model);
            return model;
        }

        private int CreateId()
        {
            if (lstEmails.Count == 0)
            {
                return 1;
            }
            return lstEmails.Max(x => x.Id) + 1;
        }

        public List<EmailModel> GetEmails(string LastName = null, bool Ascending = true)
        {
            var emails = lstEmails;
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

        public EmailModel UpdateEmail(int id, EmailModel email)
        {
            email.Id = 0;
            if (lstEmails.Count >0)
            {
                var emailToUpdate = lstEmails.FirstOrDefault(e => e.Id == id);
                if (emailToUpdate!=null)
                {
                    if (!string.IsNullOrWhiteSpace(email.FirstName) && 
                        !string.Equals(email.FirstName,"string"))
                    {
                        emailToUpdate.FirstName = email.FirstName;
                    }

                    if (!string.IsNullOrWhiteSpace(email.LastName) &&
                        !string.Equals(email.LastName, "string"))
                    {
                        emailToUpdate.LastName = email.LastName;
                    }

                    if (!string.IsNullOrWhiteSpace(email.Email) &&
                        !string.Equals(email.Email, "string"))
                    {
                        emailToUpdate.Email = email.Email;
                    }
                    return emailToUpdate;
                }
            }
            return email;
        }

        public bool DeleteEmail(int id)
        {
            if (lstEmails.Count >0)
            {
                var emailToDelete = lstEmails.FirstOrDefault(e => e.Id == id);
                if (emailToDelete!=null)
                {
                    return lstEmails.Remove(emailToDelete);
                }
            }
            return false;
        }

    }
}
