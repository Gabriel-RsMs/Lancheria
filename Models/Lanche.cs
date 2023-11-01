using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Lancheria.Models;

[Table("Lanches")]
public class Lanche
{
    [Key]
    public int LancheId { get; set; }
    [Required(ErrorMessage = "o nome deve ser informado!")]
    [Display(Name = "Nome")]
    [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no minimo {1} e no maximo {1}")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "A descricao deve ser informado!")]
    [Display(Name = "DescricaoCurta")]
    [StringLength(200, MinimumLength = 10, ErrorMessage = "O {0} deve ter no minimo {1} e no maximo {1}")]
    public string DescricaoCurta { get; set; }
    [Required(ErrorMessage = "A descricao deve ser informado!")]
    [Display(Name = "DescricaoLonga")]
    [StringLength(300, MinimumLength = 10, ErrorMessage = "O {0} deve ter no minimo {1} e no maximo {1}")]
    public string DescricaoLonga { get; set; }
    [Required(ErrorMessage = "Informe o preco do lanche")]
    [Display(Name = "Preco")]
    [Column(TypeName = "decimal(10,2)")]
    [Range(1, 999.99, ErrorMessage = "O prco dever estar entre 1 e 999,99")]
    public decimal Preco { get; set; }
    [Display(Name = "Caminho Imagem normal")]
    [StringLength(200, ErrorMessage = "O {1} deve ter no maximo{1}caracteres")]
    public string ImageUrl { get; set; }
    [Display(Name = "Caminho Imagem miniatura")]
    [StringLength(200, ErrorMessage = "O {1} deve ter no maximo{1}caracteres")]
    public string ImageThumbnailUrl { get; set; }
    [Display(Name = "Preferido?")]
    public bool IsLanchePreferido { get; set; }
    [Display(Name = "Estoque")]
    public bool EmEstoque { get; set; }

    public int CateogoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }
}