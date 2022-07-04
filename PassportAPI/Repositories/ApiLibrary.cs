using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PassportAPI.Models;

namespace PassportAPI.Repositories
{
    public static class ApiRepository
    {
        public static async Task<List<Photo>> GetPhotosFromAPI(IConfiguration configuration)
        {
            using (var httpClient = new HttpClient())
            {
                var jsonData = await httpClient.GetStringAsync(configuration[Constants.PhotoStorage]);
                return JsonConvert.DeserializeObject<List<Photo>>(jsonData);
            }
        }

        public static async Task<List<Album>> GetAlbumsFromAPI(IConfiguration configuration)
        {
            using (var httpClient = new HttpClient())
            {
                var jsonData = await httpClient.GetStringAsync(configuration[Constants.AlbumStorage]);
                return JsonConvert.DeserializeObject<List<Album>>(jsonData);
            }
        }
    }
}
