using System.ComponentModel.DataAnnotations;

namespace TesteV2.Request.Usuarios
{
    public class PostLogin
    {
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
