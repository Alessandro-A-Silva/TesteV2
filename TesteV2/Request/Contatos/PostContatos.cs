using System.ComponentModel.DataAnnotations;

namespace TesteV2.Request.Contatos
{
    public class PostContatos
    {
        public string Nome { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Contato { get; set; }
        [Required(AllowEmptyStrings = false), RegularExpression(@"(Email|Telefone)", ErrorMessage = "Tipo do contato deve ser Email ou Telefone")]
        public string TipoContato { get; set; }
    }
}
