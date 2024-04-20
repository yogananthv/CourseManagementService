using CMS_Model.DTO;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;

namespace CMS_Repository
{
    public class UserAPIRepository : IUserAPIRepository
    {
        private readonly IConfiguration configuration;
        private readonly IHttpClientFactory clientFactory;
        private readonly JsonSerializerOptions _options;
        public UserAPIRepository(IConfiguration _configuration, IHttpClientFactory _clientFactory) 
        { 
            configuration = _configuration;
            clientFactory = _clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        
        async Task<List<UserDto>> IUserAPIRepository.GetAllUserAsync(string companyName)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"status", "active"}
            };
            // Query parameters
            var queryString = string.Join("&", queryParameters
                .Select(x => $"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value)}"));

            // Get the api url based on company from app settings file
            var apiURL = configuration.GetValue<string>(companyName);
            
            var httpClient = clientFactory.CreateClient();
            List<UserDto>? users = new List<UserDto>();
            using (var response = await httpClient.GetAsync($"{apiURL}?{queryString}", HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                users = await JsonSerializer.DeserializeAsync<List<UserDto>>(stream, _options);
            }
            return users;
        }
    }
}
