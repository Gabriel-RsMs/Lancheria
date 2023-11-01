using Lancheria.Models;

namespace Lancheria.Repositories.Interfaces;

    public interface ICategoriaRepository{
        IEnumerable<Categoria> Categorias { get; }
    }