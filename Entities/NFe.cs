﻿namespace NFeApi.Entities
{
    public class NFe
    {
        public int Id { get; set; }
        public required string Numero { get; set; }
        public DateTime DataEmissao { get; set; }

        // Relacionamento 1:1 com Emitente
        public Emitente Emitente { get; set; }

        // Relacionamento 1:N com ItemNFe
        public ICollection<ItemNFe> ItensNFe { get; set; }
    }
}
