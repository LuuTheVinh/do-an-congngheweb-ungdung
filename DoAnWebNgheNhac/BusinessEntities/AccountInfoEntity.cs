using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class AccountInfoEntity
    {
        public AccountInfoEntity()
        {
            this.Users = new HashSet<UserEntity>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public System.DateTime Birthday { get; set; }
        public string IdentifyCard { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }
    }
}
