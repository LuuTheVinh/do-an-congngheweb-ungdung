using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
  public class ArtistEntity
    {
         public ArtistEntity()
        {
            this.ArtistProducts = new HashSet<ArtistProductEntity>();
        }
    
        public int Id { get; set; }
        public string Tittle { get; set; }
        public int ParentId { get; set; }
        public int Level { get; set; }
    
        public virtual ICollection<ArtistProductEntity> ArtistProducts { get; set; }
    }
}
