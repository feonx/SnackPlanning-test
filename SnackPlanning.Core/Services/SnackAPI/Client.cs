using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SnackPlanning.Core.Services.SnackAPI
{
    public class Client
    {
        private const string WEB_API_URL = "https://snackplanning-snackplan.azurewebsites.net/api/";

        public async Task<bool> RegisterUser(string username, string password)
        {
            var userCredentials = new UserCredentials
            {
                username = username,
                password = password
            };

            var registrationResponse = await PostAsync<StatusResponse>($"{WEB_API_URL}register", userCredentials);

            if(registrationResponse.Status == StatusEnum.RecordCreated)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UserExists(string username)
        {
            var userCredentials = new UserCredentials
            {
                username = username
            };

            var registrationResponse = await PostAsync<StatusResponse>($"{WEB_API_URL}register/userexists", userCredentials);

            if (registrationResponse.Status == StatusEnum.RecordCreated)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Login(string username, string password)
        {
            var userCredentials = new UserCredentials
            {
                username = username,
                password = password
            };

            var loginResponse = await PostAsync<StatusResponse>($"{WEB_API_URL}login", userCredentials);

            if(loginResponse.Status == StatusEnum.RecordExists)
            {
                return true;
            }

            return false;
        }

        public async Task<UserLogin> GetUser(string username, string password)
        {
            var userCredentials = new UserCredentials
            {
                username = username,
                password = password
            };

            return await PostAsync<UserLogin>($"{WEB_API_URL}login/getuser", userCredentials);
        }

        private async Task<T> PostAsync<T>(string uri, UserCredentials userCredentials) where T : class
        {
            var jsonUserCredentials = JsonConvert.SerializeObject(userCredentials);

            var httpContent = new StringContent(jsonUserCredentials, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.PostAsync(uri, httpContent);

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            var registrationResponse = JsonConvert.DeserializeObject<T>(jsonResponse);

            return registrationResponse;
        }

    }
}
