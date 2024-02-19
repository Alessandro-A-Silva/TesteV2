using System.ComponentModel.DataAnnotations;

namespace TesteV2.Entities
{
    public class Contatos
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Contato { get; set; }
        public string? TipoContato { get; set; }

        public int PessoasFisicasId { get; set; }
        public PessoasFisicas PessoaFisica { get; set; } = new();
    }
}
