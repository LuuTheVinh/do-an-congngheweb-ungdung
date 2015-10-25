//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnWebNgheNhac.Diagrams
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.UserComments = new HashSet<UserComment>();
            this.Artists = new HashSet<Artist>();
            this.Users = new HashSet<User>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string Thumbnail { get; set; }
        public int Views { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual Music Music { get; set; }
        public virtual ICollection<UserComment> UserComments { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual VideoCategory VideoCategory { get; set; }
    }
}
