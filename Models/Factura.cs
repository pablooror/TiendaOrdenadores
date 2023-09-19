using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComponentesMVC.Models
{
    public class Factura
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Descripcion { get; set; } = "Sin descripción";

        [Required]
        public double? Precio { get; set; } = 0;

        protected bool Equals(Factura other)
        {
            return Id == other.Id && Descripcion == other.Descripcion && Nullable.Equals(Precio, other.Precio);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Descripcion, Precio);
        }
    }
}