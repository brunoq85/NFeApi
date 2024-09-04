using System.ComponentModel.DataAnnotations;

namespace NFeApi.Dtos
{
    public class EmitenteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [DataType(DataType.Text)]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O campo cnpj é obrigatório")]
        [DataType(DataType.Text)]
        public required string CNPJ { get; set; }

        public int? NFeId { get; set; }
    }
}
