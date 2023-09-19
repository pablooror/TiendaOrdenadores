using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComponentesMVC.Models
{
    public class Pedido
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Descripcion { get; set; } = "Sin descripción";

        [Required] 
        public double? Precio { get; set; } = 0;

        [ForeignKey("Factura")]
        [Display(Name = "Factura")]
        public int? FacturaId { get; set; } = 0;

        protected bool Equals(Pedido other)
        {
            return Id == other.Id && Descripcion == other.Descripcion && Nullable.Equals(Precio, other.Precio) && FacturaId == other.FacturaId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Descripcion, Precio, FacturaId);
        }
    }
}