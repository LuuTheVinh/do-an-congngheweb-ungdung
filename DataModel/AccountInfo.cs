//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccountInfo
    {
        public AccountInfo()
        {
            this.Users = new HashSet<User>();
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
    
        public virtual ICollection<User> Users { get; set; }
    }
}
