using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IVideoProductServices
    {
        VideoProductEntity GetVideoProductById(int videoProductId);
        IEnumerable<VideoProductEntity> GetAllVideoroducts();
        int CreateVideoProduct(VideoProductEntity videoProductEntity);
        bool UpdateVideoProduct(int videoProductId, ProductEntity videoProductEntity);
        bool DeleteVideoProduct(int videoProductId);
    }
}
