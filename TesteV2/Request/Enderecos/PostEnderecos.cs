using System.ComponentModel.DataAnnotations;

namespace TesteV2.Request.Enderecos
{
    public class PostEnderecos
    {
        public string? Logradouro { get; set; }
        public int Numero { get; set; }
        [Required, RegularExpression(@"\d{5}-\d{3}", ErrorMessage = "Cep deve está no formato: 99999-999")]
        public string Cep { get; set; }
        public string? Complemento { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string Cidade { get; set; }
        [Required(AllowEmptyStrings = false), RegularExpression(@"(AC|AL|AP|AM|BA|CE|DF|ES|GO|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RO|RR|SC|SP|SE|TO)", ErrorMessage = "O estado deve ser um dos seguintes: AC,AL,AP,AM,BA,CE,DF,ES,GO,MA,MT,MS,MG,PA,PB,PR,PE,PI,RJ,RN,RS,RO,RR,SC,SP,SE,TO.")]
        [StringLength(2)]
        public string Estado { get; set; }
    }
}
