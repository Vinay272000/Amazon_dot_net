using AmazonClone.Models;
using AmazonClone.Services;
using AmazonClone.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AmazonClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        public ICountriesService _CountriesService;
        public CountriesController(ICountriesService countriesService)
        {
            _CountriesService = countriesService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Countrys> countrys = await _CountriesService.GetCountries();
            return countrys.Any() ? Ok(countrys) : BadRequest();
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            Countrys country = await _CountriesService.GetCountryById(id);
            return country != null ? Ok(country) : BadRequest();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Post(Countrys country)
        {
            bool isCreated = await _CountriesService.Create(country);
            return isCreated ? Ok() : BadRequest();
        }

        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> Delete(Countrys country)
        {
            bool isDeleted = await _CountriesService.DeleteCountry(country);
            return isDeleted ? Ok() : BadRequest();
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(Countrys country)
        {
            bool isUpdated = await _CountriesService.UpdateCountry(country);
            return isUpdated ? Ok() : BadRequest();
        }
    }
}
