using System.ComponentModel.DataAnnotations;

namespace TesteV2.Request.Usuarios
{
    public class PostUsuarios
    {
        [Required(AllowEmptyStrings = false), MaxLength(50)]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false), RegularExpression(@"\+\d{2} \d{2} \d{5}-\d{4}", ErrorMessage = "O Telefone deve estar no formato: +99 99 99999-9999.")]
        public string Telefone { get; set; }
        [Required(AllowEmptyStrings = false),Length(8,48,ErrorMessage ="A senha deve ter entre 8 e 48 caracteres.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage = "E necessário anexar uma imagem.")]
        public IFormFile Imagem { get; set; }
    }
}
