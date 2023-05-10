using Deneme2.Concrede;
using Deneme2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Deneme2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

       
    

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
         
        }

        public IActionResult Index()
        {
            //CarList<Car> cars = new CarList<Car>();

          //  List<Vehicle> list = new List<Car>(); 
         // List<IVehicle> list = new List<Bus>();   

            CarData carData = new CarData();
          
            Car car = new Car { Id=3, Name="cc"};
            carData.cars[0].Id = 20;
            carData.cars.Remove(carData.cars[1]);
            //var sayi2 = carData.sayi;

            carData.cars.FirstOrDefault(x=>x.Name== "aa");

            Vehicle vehicle= new Car();

            
            //carData.cars.ToList
            //carData.cars.Add(car);
            //CarData _carData = new CarData();
            //var isim = _carData.cars[0].Name;
            //var repo = new Repo<Car>();
            //Car car = new Car();

            //AllData<CarData> data = new AllData<CarData>();

            //repo.GetData();
            //CarList<Car> carList = new CarList<Car>();
            //carList.Set
            //foreach (var item in carList.Set)
            //{
            //    Console.WriteLine(item);
            //}

            return View(carData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}