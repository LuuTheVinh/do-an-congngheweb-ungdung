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
  public class ArtistServices : IArtistServices
    {
      private readonly UnitOfWork _unitOfWork;

      public ArtistServices()
      {
          _unitOfWork = new UnitOfWork();
      }

      public BusinessEntities.ArtistEntity GetArtistById(int artistId)
        {
            var artist = _unitOfWork.ArtistRepository.GetById(artistId);
            if(artist!=null)
            {
                var artistModel = Mapper.Map<Artist, ArtistEntity>(artist);
                return artistModel;
            }
            return null;
        }

        public IEnumerable<BusinessEntities.ArtistEntity> GetAllArtists()
        {
            var artists = _unitOfWork.ArtistRepository.GetAll();
            if (artists.Any())
            {
                var artistsModel = Mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistEntity>>(artists);
                return artistsModel;
            }
            return null;
        }

        public int CreateArtist(BusinessEntities.ArtistEntity artistEntity)
        {
            using (var scope = new TransactionScope())
            {
                var artistModel = Mapper.Map<ArtistEntity, Artist>(artistEntity);
                _unitOfWork.ArtistRepository.Insert(artistModel);
                _unitOfWork.Save();
                scope.Complete();
                return artistModel.Id;
            }
        }

        public bool UpdateArtist(BusinessEntities.ArtistEntity artistEntity)
        {
            var success = false;
            if (artistEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                        var artists = Mapper.Map<ArtistEntity, Artist>(artistEntity);
                        _unitOfWork.ArtistRepository.Update(artists);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                }
            }
            return success;
        }

        public bool DeleteArtist(int artistId)
        {
            var success = false;
            if (artistId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var artist = _unitOfWork.ArtistRepository.GetById(artistId);
                    if (artist != null)
                    {
                        _unitOfWork.ArtistRepository.Delete(artist);
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
