using Deneme2.Models;
using Microsoft.AspNetCore.SignalR;

namespace Deneme2
{
    public class Repo<T>
    {
        //private CarData _carData;
        private BusData<T> _busData;
        public Repo()
        {
             //_carData = new CarData();
             _busData = new BusData<T> ();
        }
        
      //public List<Car> GetData(T Entity)
      //public List<T> GetData()
      //{
      //      if (typeof(T) ==  typeof(Car))
      //      {
      //          List<T> newcars = _carData.cars.ConvertAll<T>;
      //             return newcars.ToList();
               
      //      }
      //      if (typeof(T) == typeof(Bus))
      //      {
      //          List<T> newcars = _busData.Buss.ToList();
      //             return newcars.ToList();

      //      }
            //return _carData.T.ToList();

            //      }
            //      if (typeof(Entity) == typeof(Bus))
            //      {
            //          return _busData.Buss.ToList();
            //      }
        //}

        //public List<Car> setCar()
        //{
        //    return _carData.cars.ToList();
        //}

        //public List<Car> setCar()
        //{
        //    return _carData.cars.ToList();
        //}
    }
}
