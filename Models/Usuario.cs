using System.ComponentModel.DataAnnotations;

namespace ApiDeliveryFlutter.models
{
    public class Usuario
    {    
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public string nivel { get; set; }
    }
}
