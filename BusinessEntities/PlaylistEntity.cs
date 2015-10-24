using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class PlaylistEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AlbumProductId { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public int Views { get; set; }

        public virtual AlbumProductEntity AlbumProduct { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
