using System.Collections.Generic;

namespace EmailClientApp.Data
{
    public class EmailService
    {
        HttpClient _httpClient = new HttpClient();
        public EmailService()
        {
            _httpClient.BaseAddress = new Uri("https://emailapicoderslink.azurewebsites.net/");
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }
        public async Task<int> CreateEmailAsync(EmailModel email)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Email", email);
            return (int)response.StatusCode;
        }

        public async Task<List<EmailModel>> GetEmails(string LastName = "", string orderBy = "Ascending")
        {
            List<EmailModel> emails = new List<EmailModel>();
            HttpResponseMessage response = await _httpClient.GetAsync("api/Email");
            var results = response.Content.ReadFromJsonAsync<List<EmailModel>>();
            return results.Result;
        }

    }
}
