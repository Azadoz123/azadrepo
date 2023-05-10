using Business.Abstract;
using DataAccess.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExamService _examService;
        private readonly IExamDal _examDal;
        public HomeController(ILogger<HomeController> logger, IExamService examService, IExamDal examDal)
        {
            _logger = logger;
            _examService = examService;
            _examDal = examDal;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {

            return View(_examDal.Get(p=>p.Id==1));
        }
        [HttpPost]
        public IActionResult Add(ExamAddDto examAddDto)
        {
            return RedirectToAction("Index", "Home");
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