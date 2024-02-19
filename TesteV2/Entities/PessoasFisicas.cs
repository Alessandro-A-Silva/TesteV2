using System.ComponentModel.DataAnnotations;

namespace TesteV2.Entities
{
    public class PessoasFisicas
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
        public List<Enderecos> Enderecos { get; set; } = new();
        public List<Contatos> Contatos { get; set; } = new();
    }
}
