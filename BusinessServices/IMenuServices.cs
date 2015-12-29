using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface IMenuServices
    {
        IEnumerable<AlbumEntity> GetListAlbums();
        IEnumerable<AlbumEntity> GetListAlbumsLevel2();
        IEnumerable<VideoEntity> GetListVideos();
        IEnumerable<VideoEntity> GetListVideosLevel2();

        IEnumerable<ArtistEntity> GetListArtists();
        IEnumerable<ArtistEntity> GetListArtistsLevel2();
    }
}
