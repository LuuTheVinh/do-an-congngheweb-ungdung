using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class ArtistProductEntity
    {
         public ArtistProductEntity()
        {
            this.Products = new HashSet<ProductEntity>();
            this.UserArtists = new HashSet<UserArtistEntity>();
        }
    
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string StageName { get; set; }
        public string RealName { get; set; }
        public System.DateTime BirthDay { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Specialization { get; set; }
        public Nullable<int> GroupId { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
    
        public virtual ArtistEntity Artist { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }
        public virtual ICollection<UserArtistEntity> UserArtists { get; set; }
    }
}
