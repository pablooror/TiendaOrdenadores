using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComponentesMVC.Models
{
    public class Ordenador
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Descripcion { get; set; } = "Sin descripción";

        [Required] 
        public double? Precio { get; set; } = 0;

        [ForeignKey("Pedido")]
        [Display(Name = "Pedido")]
        public int? PedidoId { get; set; } = 0;

        protected bool Equals(Ordenador other)
        {
            return Id == other.Id && Descripcion == other.Descripcion && Nullable.Equals(Precio, other.Precio) && PedidoId == other.PedidoId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Descripcion, Precio, PedidoId);
        }
    }
}