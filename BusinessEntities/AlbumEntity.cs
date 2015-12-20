using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities
{
   public class AlbumEntity
    {
          public AlbumEntity()
        {
            this.AlbumProducts = new HashSet<AlbumProductEntity>();
        }
    
        public int Id { get; set; }
        public string Tittle { get; set; }
        public int ParentId { get; set; }
        public int Level { get; set; }

        public ICollection<AlbumEntity> AlbumLevel2 { get; set; }
    
        public virtual ICollection<AlbumProductEntity> AlbumProducts { get; set; }

       //
    }
}
