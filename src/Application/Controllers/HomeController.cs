using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Data;
using Microsoft.Extensions.Logging;
using Services;

namespace Application.Controllers;

public class HomeController : Controller
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IDoctorService _doctorService;

    public HomeController(
        IDoctorRepository doctorRepository,
        IDoctorService doctorService)
    {
        _doctorRepository = doctorRepository;
        _doctorService = doctorService;
    }

    [HttpGet("/")]
    public IActionResult Index([FromQuery]string lastName)
    {
        var doctorsFromRepository = _doctorRepository.FetchDoctors();
        var doctorsFromServices = _doctorService.FetchDoctorsByLastName(null);

        var notes = new List<string>();
        notes.AddRange(doctorsFromRepository.Select(x => x.Note));
        notes.AddRange(doctorsFromServices.Select(x => x.Note));
        
        return Ok(notes);
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