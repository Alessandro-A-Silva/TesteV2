using System.ComponentModel.DataAnnotations;
using TesteV2.Entities;
using TesteV2.Request.Contatos;
using TesteV2.Request.Enderecos;

namespace TesteV2.Request.PessoasFisicas
{
    public class PostPessoasFisicas
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string Sobrenome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false), RegularExpression(@"\d{3}\.\d{3}\.\d{3}-\d{2}", ErrorMessage = "O Cpf deve estar no formato: 999.999.999-99")]
        public string Cpf { get; set; }
        [Required(AllowEmptyStrings = false), RegularExpression(@"\d{3}\.\d{3}\.\d{2}-\d{1}", ErrorMessage = "O Cpf deve estar no formato: 999.999.99-9")]
        public string Rg { get; set; }
        [Required]
        public List<PostEnderecos> Enderecos { get; set; } = new();
        [Required]
        public List<PostContatos> Contatos { get; set; } = new();
    }
}
