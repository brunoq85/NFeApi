namespace NFeApi.Entities
{
    public class Emitente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }

        // Relacionamento inverso 1:1 com NFe
        public int NFeId { get; set; }
        public NFe NFe { get; set; }
    }
}
