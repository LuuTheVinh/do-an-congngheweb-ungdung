using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class UserCommentEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string CommentText { get; set; }

        public virtual ProductEntity Product { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
