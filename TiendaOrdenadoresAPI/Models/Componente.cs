using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaOrdenadoresAPI.Models
{
    public class Componente
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Descripción")] 
        public string? Descripcion { get; set; } = "Sin descripción";

        [Display(Name = "Nº de serie")] 
        public string? NumSerie { get; set; } = "Desconocido";

        [Required(ErrorMessage = "Campo obligatorio")]
        public EnumComponente Tipo { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El valor no puede ser negativo")]
        public int? Cores { get; set; } = 0;

        [Range(0, double.MaxValue, ErrorMessage = "El valor no puede ser negativo")]
        public double? Gigas { get; set; } = 0;

        [Required(ErrorMessage = "Campo obligatorio")]
        public double Calor { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public double Precio { get; set; }

        [ForeignKey("Ordenador")]
        [Display(Name = "Ordenador")]
        public int? OrdenadorId { get; set; } = 1;

        protected bool Equals(Componente other)
        {
            return Id == other.Id && Descripcion == other.Descripcion && NumSerie == other.NumSerie && Tipo == other.Tipo && Cores == other.Cores && Nullable.Equals(Gigas, other.Gigas) && Calor.Equals(other.Calor) && Precio.Equals(other.Precio) && OrdenadorId == other.OrdenadorId;
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Descripcion);
            hashCode.Add(NumSerie);
            hashCode.Add((int)Tipo);
            hashCode.Add(Cores);
            hashCode.Add(Gigas);
            hashCode.Add(Calor);
            hashCode.Add(Precio);
            hashCode.Add(OrdenadorId);
            return hashCode.ToHashCode();
        }
    }
}