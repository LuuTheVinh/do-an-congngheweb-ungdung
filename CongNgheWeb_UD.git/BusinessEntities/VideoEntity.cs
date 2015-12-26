using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
  public class VideoEntity
    {
        public VideoEntity()
        {
            this.VideoProducts = new HashSet<VideoProductEntity>();
        }
    
        public int Id { get; set; }
        public string Tittle { get; set; }
        public int ParentId { get; set; }
        public int Level { get; set; }

        public ICollection<VideoEntity> VideoLevel { get; set; }
        public virtual ICollection<VideoProductEntity> VideoProducts { get; set; }
    }
}
