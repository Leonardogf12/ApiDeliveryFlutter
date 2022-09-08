using System.ComponentModel.DataAnnotations;

namespace ApiDeliveryFlutter.models
{
    public class Categoria
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string imagem { get; set; }
        public string nome_url { get; set; }
        public int produtos { get; set; }
    }
}
