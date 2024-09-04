namespace NFeApi.Entities
{
    public class Emitente
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string CNPJ { get; set; }

        // Relacionamento inverso 1:1 com NFe
        public int? NFeId { get; set; }
        public required NFe NFe { get; set; }
    }
}
