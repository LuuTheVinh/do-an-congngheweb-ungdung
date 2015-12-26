using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class VideoProductEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int VideoId { get; set; }

        public virtual ProductEntity Product { get; set; }
        public virtual VideoEntity Video { get; set; }
    }
}
