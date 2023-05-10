using Deneme2.Abstract;
using Deneme2.Models;

namespace Deneme2.Concrede
{
    public class Generic : IGeneric<Vehicle>
    {
        //AllData<Vehicle> data = new AllData<Vehicle>();

        //List<Vehicle> _vehicles = new List<Car>();
        CarData carDatas= new CarData();

        public List<Vehicle> getById()
        {
            throw new NotImplementedException();
        }

        //public List<Vehicle> getById()
        //{
        //    //return  carDatas.cars.ToList();
        //    return _vehicles;
        //}

        public List<T> Set<T>()
        {
            throw new NotImplementedException();
        }
    }
}
