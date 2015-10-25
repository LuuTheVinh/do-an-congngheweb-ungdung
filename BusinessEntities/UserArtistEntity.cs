using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class UserArtistEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ArtistProductId { get; set; }

        public virtual ArtistProductEntity ArtistProduct { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
