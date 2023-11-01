using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lancheria.Models;
using Lancheria.Repositories.Interfaces;
using Lancheria.ViewModel;
using System.Reflection;
using Lancheria.Repositories;

namespace Lancheria.Controllers;

public class LanchesController : Controller{
    private readonly ILancheRepository _lancheRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public LanchesController(ILancheRepository lancheRepository, ICategoriaRepository categoriaRepository)
    {
        _lancheRepository = lancheRepository;
        _categoriaRepository = categoriaRepository;
    }

    public IActionResult List(string Categoria)
    {
        var lanchesListViewModel = new LancheListViewModel();
        IEnumerable<Lanche> lanches = _lancheRepository.Lanches;

        if (!string.IsNullOrEmpty(Categoria))
        {
            var categoriaExiste = _categoriaRepository.Categorias
                .Where(c => c.CategoriaNome == Categoria);

            if (categoriaExiste != null)
            {
                lanches = lanches.Where(l => l.Categoria.CategoriaNome == Categoria).ToList();
                lanchesListViewModel.CategoriaAtual = Categoria;
            }
        }
        else
        {
            lanchesListViewModel.CategoriaAtual = "Todos os lanches";
        }

        lanchesListViewModel.Lanches = lanches;
        return View(lanchesListViewModel);
    }

    public IActionResult Details (int lancheId)
    {
        var lanche = _lancheRepository.Lanches.FirstOrDefault(l =>  l.LancheId == lancheId);
        return View(lanche); 
    }

    public ViewResult Search (string searchString)
    {
        IEnumerable<Lanche> lanches;
        string categoriaAtual = string.Empty;
        if (string.IsNullOrEmpty(searchString))
        {
            lanches = _lancheRepository.Lanches.OrderBy(p => p.LancheId);
            categoriaAtual = "Todos os lanches";
        }
        else
        {
            lanches = _lancheRepository.Lanches.Where(p=> p.Nome.ToLower().Contains(searchString.ToLower()));
            if (lanches.Any())
            {
                categoriaAtual = "Lanches";
            }
            else
            {
                categoriaAtual = "Nenhum lanche fora encontrado";
            }
        }

        return View("~/Views/Lanches/List.cshtml", new LancheListViewModel
        {
            Lanches = lanches,
            CategoriaAtual = categoriaAtual
        });
    }
}