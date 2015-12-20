using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IServices
    {
        IEnumerable<AlbumEntity> GetListAlbums();
        IEnumerable<ProductEntity> GetListProducts();

        IEnumerable<AlbumEntity> GetListAlbumByParentId(int parentId);

        IEnumerable<AlbumProductEntity> GetNhacVietHot();
        IEnumerable<AlbumProductEntity> GetNhacVietMoi();

    }
}
