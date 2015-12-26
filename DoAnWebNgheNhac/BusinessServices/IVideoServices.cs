using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface IVideoServices
    {
        VideoEntity GetVideoById(int videoId);
        IEnumerable<VideoEntity> GetAllVideos();
        int CreateVideo(VideoEntity videoEntity);
        bool UpdateVideo(VideoEntity videoEntity);
        bool DeleteVideo(int videoId);
    }
}
