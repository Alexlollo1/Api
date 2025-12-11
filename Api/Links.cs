using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Api
{
    public class Links
    {
        public static string Uri = "https://api.spotify.com/v1/";
    }
    public class SpotifyTokenService
    {
        public static SpotifyToken CachedSpotifyToken { get; private set; } = new();
        private static Timer _timer;

        private readonly string _clientId = "ca0e4e1b2a744302bb8e0cb365dd089f";
        private readonly string _clientSecret = "64d9901495524803af3fe481f6a4f0c0";

        public SpotifyTokenService()
        {
            var token = RefreshAccessTokenAsync().GetAwaiter().GetResult();
            Console.WriteLine($"[DEBUG] Полученный токен: {token}"); // ← Вот это добавь

            CachedSpotifyToken.AccessToken = token;
            CachedSpotifyToken.ExpiryTime = DateTime.UtcNow.AddSeconds(2400);
            StartTokenRefreshTimer();
        }

        public void StartTokenRefreshTimer()
        {
            _timer = new Timer(async _ =>
            {
                try
                {
                    string newToken = await RefreshAccessTokenAsync();
                    CachedSpotifyToken.AccessToken = newToken;
                    CachedSpotifyToken.ExpiryTime = DateTime.UtcNow.AddSeconds(2400);
                    Console.WriteLine($"[INFO] Access token обновлён: {DateTime.UtcNow} {CachedSpotifyToken}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] Ошибка обновления токена: {ex.Message}");
                }

            }, null, TimeSpan.Zero, TimeSpan.FromMinutes(40));
        }

        public async Task<string> RefreshAccessTokenAsync()
        {
            using var client = new HttpClient();

            var authHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"));

            var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authHeader);
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "grant_type", "client_credentials" }
        });

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<JsonElement>(content);

            return json.GetProperty("access_token").GetString();
        }
    }

    public class SpotifyToken
    {
        public string AccessToken { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}