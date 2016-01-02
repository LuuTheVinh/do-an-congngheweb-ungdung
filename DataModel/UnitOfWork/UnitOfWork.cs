#region Using Namespace...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.GenericRepository;
using System.Data.Entity.Validation;
using System.Diagnostics;
#endregion

namespace DataModel.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
  public class UnitOfWork : IDisposable
    {
        #region Private members...
        private WebNgheNhacDb1Entities _context = null;
        private GenericRepository<Album> _albumRepository;
        private GenericRepository<AlbumProduct> _albumProductRepository;       
        private GenericRepository<Video> _videoRepository;   
        private GenericRepository<VideoProduct> _videoProductRepository;
        private GenericRepository<Artist> _artistRepository;      
        private GenericRepository<ArtistProduct> _artistProductRepository;      
        private GenericRepository<Product> _productRepository;

        private GenericRepository<AccountInfo> _AccountInfoRepository;
        private GenericRepository<User> _UserRepository;

        #endregion

        #region Public Repository Create propoty...
        /// <summary>
        /// Init DB
        /// </summary>
        public UnitOfWork()
        {
            _context = new WebNgheNhacDb1Entities();
        }

        /// <summary>
        /// Get method for Album
        /// </summary>
        public GenericRepository<Album> AlbumRepository
        {
            get
            {
                if (this._albumRepository == null)
                    this._albumRepository = new GenericRepository<Album>(_context);
                return _albumRepository;
            }

        }
          /// <summary>
          /// Get method for AlbumProduct
          /// </summary>
        public GenericRepository<AlbumProduct> AlbumProductRepository
        {
            get
            {
                if (this._albumProductRepository == null)
                    this._albumProductRepository = new GenericRepository<AlbumProduct>(_context);
                return _albumProductRepository;
            }
        }
         /// <summary>
         /// Get method for Video
         /// </summary>
        public GenericRepository<Video> VideoRepository
        {
            get
            {
                if (this._videoRepository == null)
                    this._videoRepository = new GenericRepository<Video>(_context);
                return _videoRepository;
            }
        }
        /// <summary>
        /// Get method for VideoProduct
        /// </summary>
        public GenericRepository<VideoProduct> VideoProductRepository
        {
            get
            {
                if (this._videoProductRepository == null)
                    this._videoProductRepository = new GenericRepository<VideoProduct>(_context);
                return _videoProductRepository;
            }
        }
        /// <summary>
        /// Get method for Artist
        /// </summary>
        public GenericRepository<Artist> ArtistRepository
        {
            get
            {
                if (this._artistRepository == null)
                    this._artistRepository = new GenericRepository<Artist>(_context);
                return _artistRepository;
            }
        }
        /// <summary>
        /// Get method for ArtistProduct
        /// </summary>
        public GenericRepository<ArtistProduct> ArtistProductRepository
        {
            get
            {
                if (this._artistProductRepository == null)
                    this._artistProductRepository = new GenericRepository<ArtistProduct>(_context);
                return _artistProductRepository;
            }
        }
        /// <summary>
        /// Get method for  Product
        /// </summary>
        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                    this._productRepository = new GenericRepository<Product>(_context);
                return _productRepository;
            }
        }

        public GenericRepository<AccountInfo> AccountInfoRepository
        {
            get
            {
                if (this._AccountInfoRepository == null)
                    this._AccountInfoRepository = new GenericRepository<AccountInfo>(_context);
                return _AccountInfoRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._UserRepository == null)
                    this._UserRepository = new GenericRepository<User>(_context);
                return _UserRepository;
            }
        }
        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }
        }
        #endregion

        #region Implementing IDisposable...
        #region private disposable variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected virtual dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("Unit Of Work being disposed");
                    _context.Dispose();
                }

            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
