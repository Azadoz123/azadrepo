using Microsoft.EntityFrameworkCore;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Data
{
    public class AppRepository<T> : IAppRepository<T> where T : class
    {
        private DataContext _context;

        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity)
        {
            _context.Add(entity);
            _context.ChangeTracker.Entries();
        }

        public void Delete<T>(T entity)
        {
            _context.Remove(entity);
           
        }

        public List<City> GetCities()
        {
            var cities = _context.Cities.Include(c => c.Photos).ToList();
            _context.ChangeTracker.Entries();
            return cities;
        }

        public City GetCityById(int cityId)
        {
            _context.ChangeTracker.Entries();
           return _context.Cities.Include(c=>c.Photos).SingleOrDefault(c => c.Id == cityId);
            //_context.SaveChanges();
        }

        public Photo GetPhoto(int id)
        {
        
          var photo = _context.Photos.SingleOrDefault(p => p.Id == id);
            //_context.Cities.Add(new City { Name = "bb", Description = "aa" });
            //_context.ChangeTracker.Entries();
            return photo;
        }

        public List<Photo> GetPhotosByCity(int cityId)
        {
            var photos = _context.Photos.Where(c => c.CityId == cityId).ToList();
            return photos;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
