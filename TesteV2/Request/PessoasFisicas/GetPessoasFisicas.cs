using System.ComponentModel.DataAnnotations;

namespace TesteV2.Request.PessoasFisicas
{
    public class GetPessoasFisicas
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
    }
}
