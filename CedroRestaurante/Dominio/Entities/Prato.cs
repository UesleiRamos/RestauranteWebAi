namespace CedroRestaurante.Dominio.Entities
{
    public class Prato
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }
    }
}
