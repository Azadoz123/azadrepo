namespace Deneme2.Models
{
    public class AllData<T>
    {
        List<string> strings= new List<string> { "","" };
        //public CarData carData = new CarData();
        //public BusData busData = new BusData();
       // public T Data = new T();
        public T _allData;
       
        List<T> vehicles = new List<T>();

  
        public AllData( T allData)
        {
            _allData = allData;
        }
        //public List<T> GetAllData(T entity ) 
        //{
        //    return;
        //}

        //public List<Car> getAllCars()
        //{
        //    return carData.cars;
        // }
    //    public List<Bus> getAllBus()
    //    {
    //        return busData.Buss;
    //    }
    }
}
