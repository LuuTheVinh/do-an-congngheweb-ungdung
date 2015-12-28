using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessServices;

namespace BusinessServices
{
   public class HomeServices
    {
       public IEnumerable<AlbumProductEntity> NhacVietHot {get; set;}
       public IEnumerable<AlbumProductEntity> NhacVietMoi {get; set;}
       public IEnumerable<AlbumEntity> GetAlbum { get; set; }
       public IEnumerable<VideoProductEntity> GetVideo { get; set; }
    }
}
