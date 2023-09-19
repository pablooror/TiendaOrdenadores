using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Services
{
    public class FakeRepositoryFactura : IRepositorio<Factura>
    {
        readonly List<Factura> listaFacturas = new();
        public FakeRepositoryFactura()
        {
            listaFacturas.Add(new Factura()
            {
                Id = 1,
                Descripcion = "Factura 1",
                Precio = 284.0,
            });
        }

        public List<Factura> ObtenerTodos()
        {
            return listaFacturas;
        }

        public Factura? Obtener(int Id)
        {
            if (Id < 0 || Id > listaFacturas.Count)
            {
                return null;
            }
            return listaFacturas.First(x => x.Id == Id);
        }

        public void Añadir(Factura item)
        {
            listaFacturas.Add(item);
        }

        public void Borrar(int id)
        {
            var facturaABorrar = listaFacturas.First(factura => factura.Id == id);
            if (facturaABorrar != null)
            {
                listaFacturas.Remove(facturaABorrar);
            }
        }

        public void Actualizar(Factura factura)
        {
            var facturaAEditar = Obtener(factura.Id);
            if (facturaAEditar != null)
            {
                facturaAEditar.Descripcion = factura.Descripcion;
                facturaAEditar.Precio = factura.Precio;
            }
        }

        public int ObtenerUltimoId()
        {
            return 0;
        }
    }
}