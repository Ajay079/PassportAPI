using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PassportAPI.Models;
using PassportAPI.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassportAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PassportController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PassportController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetAllAlbums")]
        public async Task<List<Album>> GetAllAlbums()
        {
            return await ApiRepository.GetAlbumsFromAPI(_configuration);
        }

        [HttpGet("GetAllPhotos")]
        public async Task<List<Photo>> GetAllPhotos()
        {
            return await ApiRepository.GetPhotosFromAPI(_configuration);
        }

        [HttpGet("GetPhotosPerAlbum")]
        public List<PhotoAlbum> GetPhotosPerAlbum()
        {
            return FilterPhotoAlbumByUserId(null);
        }

        [HttpGet("GetPhotosPerUser")]
        public List<PhotoAlbum> GetPhotosPerUser(int userId)
        {
            return FilterPhotoAlbumByUserId(userId);
        }

        private List<PhotoAlbum> FilterPhotoAlbumByUserId(int? userId)
        {
            var photoAlbums = new List<PhotoAlbum>();
            var albums = GetAllAlbums().Result;
            var photos = GetAllPhotos().Result;

            var photoAlbum = (userId is null)
                ?
                (
                    from alb in albums
                    join pho in photos on alb.AlbumId equals pho.AlbumId
                    select new { alb, pho }
                )
                :
                (
                    from alb in albums
                    join pho in photos on alb.AlbumId equals pho.AlbumId
                    where alb.UserId == userId
                    select new { alb, pho }
                );

            foreach (var item in photoAlbum)
            {
                var pa = new PhotoAlbum();
                pa.Photo = item.pho;
                pa.Album = item.alb;

                photoAlbums.Add(pa);
            }

            return photoAlbums;
        }
    }
}
