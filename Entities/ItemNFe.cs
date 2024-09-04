namespace NFeApi.Entities
{
    public class ItemNFe
    {
        public int Id { get; set; }
        public required string Descricao { get; set; }
        public decimal Valor { get; set; }

        // Relacionamento com NFe (muitos para um)
        public int? NFeId { get; set; }
        public NFe NFe { get; set; }
    }
}
