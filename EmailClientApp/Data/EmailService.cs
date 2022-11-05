using System.Collections.Generic;
using System.Net;

namespace EmailClientApp.Data
{
    public class EmailService
    {
        HttpClient _httpClient = new HttpClient();
        IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            var baseAdressAPI = _configuration.GetValue<string>("baseUrlApi");
            _httpClient.BaseAddress = new Uri(baseAdressAPI);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            _configuration=configuration;
        }
        public async Task<int> CreateEmailAsync(EmailModel email)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Email", email);
            return (int)response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteEmail(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Email/{id}");
            return response.StatusCode;
        }

        public async Task<HttpStatusCode> UpdateEmail(int id, EmailModel email)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/Email/{id}", email);
            return response.StatusCode;
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
