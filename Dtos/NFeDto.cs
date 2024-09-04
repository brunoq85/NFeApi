using NFeApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace NFeApi.Dtos
{
    public class NFeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo número é obrigatório")]
        [DataType(DataType.Text)]
        public required string Numero { get; set; }

        [Required(ErrorMessage = "O campo data de emissão é obrigatório")]
        [DataType(DataType.Date)]
        public required DateTime DataEmissao { get; set; }

        // Relacionamento 1:1 com Emitente
        public EmitenteDto Emitente { get; set; }

        // Relacionamento 1:N com ItemNFe
        public ICollection<ItemNFeDto> ItensNFe { get; set; }
    }
}
