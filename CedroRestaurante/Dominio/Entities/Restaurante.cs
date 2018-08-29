using System.Collections.Generic;

namespace CedroRestaurante.Dominio.Entities
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Prato> Pratos { get; set; }
    }
}