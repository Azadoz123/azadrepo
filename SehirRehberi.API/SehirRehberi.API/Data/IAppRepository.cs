using SehirRehberi.API.Models;

namespace SehirRehberi.API.Data
{
    public interface IAppRepository<T> where T : class
    {
        void Add<T> (T entity);
        void Delete<T> (T entity);
        bool SaveAll();

        List<City> GetCities();
        List<Photo> GetPhotosByCity(int cityId);
        City GetCityById (int cityId);
        Photo GetPhoto(int id);
    }
}
