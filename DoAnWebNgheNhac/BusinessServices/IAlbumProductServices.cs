using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IAlbumProductServices
    {
        AlbumProductEntity GetAlbumProductById(int albumProductId);
        IEnumerable<AlbumProductEntity> GetAllAlbumProducts();
        int CreateAlbumProduct(AlbumProductEntity albumProductEntity);
        bool UpdateAlbumProduct(int albumProductId, AlbumProductEntity albumProductEntity);
        bool DeleteAlbumProduct(int albumProductId);
    }
}
