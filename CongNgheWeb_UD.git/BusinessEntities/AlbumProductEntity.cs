using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class AlbumProductEntity
    {
        public AlbumProductEntity()
        {
            this.Playlists = new HashSet<PlaylistEntity>();
        }
    
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AlbumId { get; set; }
        public Nullable<int> Year { get; set; }
    
        public virtual AlbumEntity Album { get; set; }
        public virtual ProductEntity Product { get; set; }
        public virtual ICollection<PlaylistEntity> Playlists { get; set; }
    }
}
