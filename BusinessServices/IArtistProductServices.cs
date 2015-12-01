using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
   public interface IArtistProductServices
    {
        ArtistProductEntity GetArtistProductById(int artistProductId);
        IEnumerable<ArtistProductEntity> GetAllArtistProducts();
       // IQueryable<ArtistProductEntity> GetAllArtistProductsWithInclude();
        int CreateArtistProduct(ArtistProductEntity artistProductEntity);
        bool UpdateArtistProduct(int artistProductId, ArtistProductEntity artistProductEntity);
        bool DeleteArtistProduct(int artistProductId);

        //IEnumerable<ArtistEntity> GetAllArtists();
    }
}
