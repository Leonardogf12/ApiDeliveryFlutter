using System.ComponentModel.DataAnnotations;

namespace ApiDeliveryFlutter.models
{
    public class Produto
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string descricao_longa { get; set; }
        public decimal valor { get; set; }
        public int idCategoria { get; set; }
        public string imagem { get; set; }
        public string nome_url { get; set; }
        public string? combo { get; set; }
        public int vendas { get; set; }
    }
}
