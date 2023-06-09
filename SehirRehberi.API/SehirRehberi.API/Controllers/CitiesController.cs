﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IAppRepository<City> _appRepository;
        private IMapper _mapper;

        public CitiesController(IAppRepository<City> appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            //var cities = _appRepository.GetCities().Select(c => new CityForListDto
            //{
            //    Description= c.Description,
            //    Name= c.Name,
            //    Id= c.Id,
            //    PhotoUrl = c.Photos.FirstOrDefault(p=>p.IsMain==true).Url
            //}).ToList();
            var cities = _appRepository.GetCities(); 
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);

            
            return Ok(citiesToReturn);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] City city)
        {
            _appRepository.Add(city);
            _appRepository.SaveAll();
            return Ok(city);
        }
        [HttpGet]
        [Route("detail")]
        public IActionResult GetCityById(int id)
        {
          
            var city = _appRepository.GetCityById(id);
            //var photo = _appRepository.GetPhoto(id);
            var cityToReturn = _mapper.Map<CityForDetailDto>(city);

            return Ok(cityToReturn);
        }

        [HttpGet("Photos")]
        public IActionResult GetPhotosByCity(int cityId)
        {
            var photos = _appRepository.GetPhotosByCity(cityId);
            return Ok(photos);

        }
    }
}
