using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MainController : ControllerBase
    {
        [HttpGet]
        [ActionName("GetTrackByName")]
        public async Task<TracksObject> GetTrackByNameAsync(string track, string artist)
        {
            using (HttpClient client = new())
            {
                HttpRequestMessage request = new()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(Links.Uri + $"search?q=track:{track}%20artist:{artist}&type=track"),
                    Headers =
                    {
                        Authorization = new AuthenticationHeaderValue("Bearer", SpotifyTokenService.CachedSpotifyToken.AccessToken)
                    }
                };

                HttpResponseMessage response = await client.SendAsync(request);
                string content = await response.Content.ReadAsStringAsync();
                var trackObj = JsonConvert.DeserializeObject<TracksObject>(content);
                return trackObj;
            }
        }
        [HttpGet]
        [ActionName("GetAlbumByName")]
        public async Task<AlbumObject> GetAlbumByNameAsync(string album, string artist)
        {
            using (HttpClient client = new())
            {
                HttpRequestMessage request = new()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(Links.Uri + $"search?q=album:{album}%20artist:{artist}&type=album"),
                    Headers =
                    {
                        Authorization = new AuthenticationHeaderValue("Bearer", SpotifyTokenService.CachedSpotifyToken.AccessToken)
                    }
                };

                HttpResponseMessage response = await client.SendAsync(request);
                string content = await response.Content.ReadAsStringAsync();
                var albumObj = JsonConvert.DeserializeObject<AlbumObject>(content);
                return albumObj;
            }
        }
        [HttpGet]
        [ActionName("GetArtistByName")]
        public async Task<ArtistObject> GetArtistByNameAsync(string name)
        {
            using (HttpClient client = new())
            {
                HttpRequestMessage request = new()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(Links.Uri + $"search?q={name}&type=artist"),
                    Headers =
                    {
                        Authorization = new AuthenticationHeaderValue("Bearer", SpotifyTokenService.CachedSpotifyToken.AccessToken)
                    }
                };

                HttpResponseMessage response = await client.SendAsync(request);
                string content = await response.Content.ReadAsStringAsync();
                var artistObj = JsonConvert.DeserializeObject<ArtistObject>(content);
                return artistObj;
            }
        }
        [HttpGet]
        [ActionName("GetTrackById")]
        public async Task<Track> GetTrackByIdAsync(string id)
        {
            using (HttpClient client = new())
            {
                HttpRequestMessage request = new()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(Links.Uri + $"tracks/{id}"),
                    Headers =
                    {
                        Authorization = new AuthenticationHeaderValue("Bearer", SpotifyTokenService.CachedSpotifyToken.AccessToken)
                    }
                };

                HttpResponseMessage response = await client.SendAsync(request);
                string content = await response.Content.ReadAsStringAsync();
                var track = JsonConvert.DeserializeObject<Track>(content);
                return track;
            }
        }
        [HttpGet]
        [ActionName("GetAlbumById")]
        public async Task<Album> GetAlbumByIdAsync(string id)
        {
            using (HttpClient client = new())
            {
                HttpRequestMessage request = new()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(Links.Uri + $"albums/{id}"),
                    Headers =
                    {
                        Authorization = new AuthenticationHeaderValue("Bearer", SpotifyTokenService.CachedSpotifyToken.AccessToken)
                    }
                };

                HttpResponseMessage response = await client.SendAsync(request);
                string content = await response.Content.ReadAsStringAsync();
                var album = JsonConvert.DeserializeObject<Album>(content);
                return album;
            }
        }
        [HttpGet]
        [ActionName("GetArtistById")]
        public async Task<Artist> GetArtistByIdAsync(string id)
        {
            using (HttpClient client = new())
            {
                HttpRequestMessage request = new()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(Links.Uri + $"artists/{id}"),
                    Headers =
                    {
                    Authorization = new AuthenticationHeaderValue("Bearer", SpotifyTokenService.CachedSpotifyToken.AccessToken)
                    }
                };

                HttpResponseMessage response = await client.SendAsync(request);
                string content = await response.Content.ReadAsStringAsync();
                var artist = JsonConvert.DeserializeObject<Artist>(content);
                return artist;
            }
        }
    }
}