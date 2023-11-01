using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lancheria.Models;
using Lancheria.Repositories.Interfaces;
using Lancheria.ViewModel;

namespace Lancheria.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ILancheRepository _lancheRepository;

    public HomeController(ILogger<HomeController> logger, ILancheRepository lancheRepository)
    {
        _logger = logger;
        _lancheRepository = lancheRepository;
    }

    public IActionResult Index()
    {
        var HomeViewModel = new HomeViewModel
        {
            LanchePreferidos = _lancheRepository.LanchesPreferidos
        };
        return View(HomeViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
