using DataAccess.DataAccess;
using MailApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MailApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailData _emailData;

        public EmailController(IEmailData emailData)
        {
            _emailData = emailData;
        }


        // GET: api/<EmailController>
        [HttpGet(Name = nameof(Get))]
        public List<EmailModel> Get()
        {
            return _emailData.GetEmails();
        }

        // GET api/<EmailController>/5
        [HttpGet("{LastName}/{Ascending}")]
        public List<EmailModel> Get(string LastName = "", string Ascending = "ascending")
        {
            Ascending = (Ascending ?? "").ToLower();
            bool asc = Ascending == "ascending" || Ascending == "asc";
            return _emailData.GetEmails(LastName, asc);
        }

        // POST api/<EmailController>
        [HttpPost]
        public void Post([FromBody] EmailModel emailModel)
        {
            var newEmail = _emailData.CreateEmail(emailModel);
            Ok(newEmail);
        }

        // PUT api/<EmailController>/5
        [HttpPut("{id}")]
        public EmailModel Put(int id, [FromBody] EmailModel email)
        {
            return _emailData.UpdateEmail(id, email);
        }

        // DELETE api/<EmailController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool res = _emailData.DeleteEmail(id);
            if (res)
            {
                return Ok();
            }
            return NotFound(id);
        }
    }
}
