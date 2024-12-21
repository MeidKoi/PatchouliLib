
using System.Net.Http.Json;
using Microsoft.JSInterop;
namespace Models
{
    public class JwtToken
    {
        public string id {get; set;}
        public long nbf {get; set;}
        public long exp {get; set;}
        public long iat {get; set;}

        public async Task<string?> RefreshTokenIfNeed(string accessToken)
        {
            var currentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var remainingTime = exp - currentTime;
            if (remainingTime <= 60 * 14) // 60 is const for because seconds
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("https://mnogolibapi-f7vitvir.b4a.run/")
                };
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage response = await client.PostAsync("Accounts/refresh-token", null);
                if (response.IsSuccessStatusCode)
                {
                    return (await response.Content.ReadFromJsonAsync<AuthenticateResponse>()).JwtToken;
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }

            }
            return accessToken;
        } 

    }
}