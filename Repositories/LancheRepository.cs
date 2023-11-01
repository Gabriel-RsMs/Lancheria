using Lancheria.Models;
using Lancheria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Lancheria.Repositories;

public class LancheRepository : ILancheRepository
{
    private readonly AppDbContext _Context;

    public LancheRepository(AppDbContext context)
    {   
        _Context = context;
    }

    public IEnumerable<Lanche> Lanches => _Context.Lanches.Include(i => i.Categoria);

    public IEnumerable<Lanche> LanchesPreferidos => _Context.Lanches.Where(p => p.IsLanchePreferido).Include(c => c.Categoria);

    public Lanche GetLancheById(int LancheId) => _Context.Lanches.FirstOrDefault(I => I.LancheId == LancheId);
}