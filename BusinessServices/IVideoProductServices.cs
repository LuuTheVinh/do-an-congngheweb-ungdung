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
        IEnumerable<VideoProductEntity> GetAllVideoProducts();
        int CreateVideoProduct(VideoProductEntity videoProductEntity);
        bool UpdateVideoProduct(int videoProductId, VideoProductEntity videoProductEntity);
        bool DeleteVideoProduct(int videoProductId);
    }
}
