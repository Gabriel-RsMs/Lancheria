using Lancheria.Models;
using Lancheria.Repositories.Interfaces;

namespace Lancheria.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _Context;

    public CategoriaRepository(AppDbContext context)
    {
        _Context = context;
    }

    public IEnumerable<Categoria> Categorias => _Context.Categorias;
}