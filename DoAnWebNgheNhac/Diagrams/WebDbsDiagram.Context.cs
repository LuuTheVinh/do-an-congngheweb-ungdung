﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WebDBsEntities : DbContext
    {
        public WebDBsEntities()
            : base("name=WebDBsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AccountInfo> AccountInfoes { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumCategory> AlbumCategories { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistCategory> ArtistCategories { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoCategory> VideoCategories { get; set; }
        public DbSet<AlbumView> AlbumViews { get; set; }
        public DbSet<MusicView> MusicViews { get; set; }
        public DbSet<VideoView> VideoViews { get; set; }
    }
}