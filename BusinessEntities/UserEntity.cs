using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class UserEntity
    {
        public UserEntity()
        {
            this.Playlists = new HashSet<PlaylistEntity>();
            this.UserArtists = new HashSet<UserArtistEntity>();
            this.UserComments = new HashSet<UserCommentEntity>();
            this.UserLikes = new HashSet<UserLikeEntity>();
        }
    
        public int Id { get; set; }
        public int AccountInfoId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SecQuest1 { get; set; }
        public string SecAnswer1 { get; set; }
        public string SecQuest2 { get; set; }
        public string SecAnswer2 { get; set; }

        public virtual AccountInfoEntity AccountInfo { get; set; }
        public virtual ICollection<PlaylistEntity> Playlists { get; set; }
        public virtual ICollection<UserArtistEntity> UserArtists { get; set; }
        public virtual ICollection<UserCommentEntity> UserComments { get; set; }
        public virtual ICollection<UserLikeEntity> UserLikes { get; set; }
    }
}
