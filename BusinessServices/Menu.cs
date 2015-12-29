using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
   public class Menu
    {

        public IEnumerable<AlbumEntity> GetAlbumLevel1 { get; set; }
        public IEnumerable<AlbumEntity> GetAlbumLevel2 { get; set; }

        public IEnumerable<ArtistEntity> GetArtistLevel1 { get; set; }
        public IEnumerable<ArtistEntity> GetArtistLevel2 { get; set; }     
    }

}
