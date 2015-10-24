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
    
    public partial class AlbumProduct
    {
        public AlbumProduct()
        {
            this.Playlists = new HashSet<Playlist>();
        }
    
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AlbumId { get; set; }
        public Nullable<int> Year { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}