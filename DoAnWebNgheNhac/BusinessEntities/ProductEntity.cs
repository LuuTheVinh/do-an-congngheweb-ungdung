using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
  public class ProductEntity
    {
      public ProductEntity()
        {
            this.AlbumProducts = new HashSet<AlbumProductEntity>();
            this.UserComments = new HashSet<UserCommentEntity>();
            this.UserLikes = new HashSet<UserLikeEntity>();
            this.VideoProducts = new HashSet<VideoProductEntity>();
        }
    
        public int Id { get; set; }
        public int ArtistProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string Thumbnail { get; set; }
        public int Views { get; set; }
    
        public virtual ICollection<AlbumProductEntity> AlbumProducts { get; set; }
        public virtual ArtistProductEntity ArtistProduct { get; set; }
        public virtual ICollection<UserCommentEntity> UserComments { get; set; }
        public virtual ICollection<UserLikeEntity> UserLikes { get; set; }
        public virtual ICollection<VideoProductEntity> VideoProducts { get; set; }
    }
}
