using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessServices
{
   public class VideoServices: IVideoServices
    {
       private readonly UnitOfWork _unitOfWork;

       public VideoServices()
       {
           _unitOfWork = new UnitOfWork();
       }

        public BusinessEntities.VideoEntity GetVideoById(int videoId)
        {
            var video = _unitOfWork.VideoRepository.GetById(videoId);
            if (video != null)
            {
                Mapper.CreateMap<Video, VideoEntity>();
                var videoModel = Mapper.Map<Video, VideoEntity>(video);
                return videoModel;
            }
            return null;
        }

        public IEnumerable<BusinessEntities.VideoEntity> GetAllVideos()
        {
            var videos = _unitOfWork.VideoRepository.GetAll();
            if (videos.Any())
            {
                Mapper.CreateMap<Video, VideoEntity>();
                var videosModel = Mapper.Map<IEnumerable<Video>, IEnumerable<VideoEntity>>(videos);
                return videosModel;
            }
            return null;
        }

        public int CreateVideo(BusinessEntities.VideoEntity videoEntity)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<VideoEntity, Video>();
                var video = Mapper.Map<VideoEntity, Video>(videoEntity);
                _unitOfWork.VideoRepository.Insert(video);
                _unitOfWork.Save();
                scope.Complete();
                return video.Id;
            }
        }

        public bool UpdateVideo(int videoId, BusinessEntities.VideoEntity videoEntity)
        {
            var success = false;
            if (videoEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var video = _unitOfWork.VideoRepository.GetById(videoId);
                    if (video != null)
                    {
                        video.Tittle = videoEntity.Tittle;
                        video.ParentId = videoEntity.ParentId;
                        video.Level = videoEntity.Level;
                        _unitOfWork.VideoRepository.Update(video);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteVideo(int videoId)
        {
            var success = false;
            if (videoId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var video = _unitOfWork.VideoRepository.GetById(videoId);
                    if (video != null)
                    {
                        _unitOfWork.VideoRepository.Delete(video);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
