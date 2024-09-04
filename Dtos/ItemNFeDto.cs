using System.ComponentModel.DataAnnotations;

namespace NFeApi.Dtos
{
    public class ItemNFeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        [DataType(DataType.Text)]
        public required string Descricao { get; set; }

        [Required(ErrorMessage = "O campo valor é obrigatório")]
        [DataType(DataType.Currency)]
        public required decimal Valor { get; set; }

        public int? NFeId { get; set; }
    }
}
