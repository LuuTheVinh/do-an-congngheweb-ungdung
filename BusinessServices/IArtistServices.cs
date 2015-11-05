using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    public interface IArtistServices
    {
        ArtistEntity GetArtistById(int artistId);
        IEnumerable<ArtistEntity> GetAllArtists();
        int CreateArtist(ArtistEntity artistEntity);
        bool UpdateArtist(int artistId, ArtistEntity artistEntity);
        bool DeleteArtist(int artistId);
    }
}
