using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    /// <summary>
    /// Interface for AlbumServices
    /// </summary>
   public interface IAlbumServices
    {
        AlbumEntity GetAlbumById(int albumId);
        IEnumerable<AlbumEntity> GetAllAlbums();
        int CreateAlbum(AlbumEntity albumEntity);
        bool UpdateAlbum(AlbumEntity albumEntity);
        bool DeleteAlbum(int albumId);
    }
}
