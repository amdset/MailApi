using MailApi.Models;
using System.Net.Http.Json;

namespace ApiTest
{
    public class Tests
    {

        HttpClient _httpClient = new HttpClient();


        [Test]
        public async Task CreateEmail()
        {
          
            _httpClient.BaseAddress = new Uri("https://emailapicoderslink.azurewebsites.net/");
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            EmailModel e = new EmailModel()
            {
                Id = 100,
                FirstName ="First Name test",
                LastName = "Last Name test",
                Email = "EmailTest@gmail.com"
            };

            var result = await CreateEmailAsync(e);
            int ok = 200;
            if(result == ok)
            {
                Assert.Pass();
            }
            
        }


      
        public async Task<int> CreateEmailAsync(EmailModel email)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Email", email);
            return (int)response.StatusCode;
        }

        //public async Task<List<EmailModel>> GetEmails(string LastName = "", string orderBy = "Ascending")
        //{
        //    List<EmailModel> emails = new List<EmailModel>();
        //    HttpResponseMessage response = await _httpClient.GetAsync("api/Email");
        //    var results = response.Content.ReadFromJsonAsync<List<EmailModel>>();
        //    return results.Result;
        //}


    }
}