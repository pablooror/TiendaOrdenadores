using Microsoft.EntityFrameworkCore;

namespace ComponentesMVC.Models
{
    public class TiendaOrdenadoresContext : DbContext
    {
        public TiendaOrdenadoresContext(DbContextOptions<TiendaOrdenadoresContext> options)
            : base(options)
        {
            
        }

        public DbSet<Componente> Componentes => Set<Componente>();
        public DbSet<Ordenador> Ordenadores => Set<Ordenador>();
        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<Factura> Facturas => Set<Factura>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CompInitializer(modelBuilder).Seed();
            new OrdenadorInitializer(modelBuilder).Seed();
            new PedidoInitalizer(modelBuilder).Seed();
            new FacturaInitalizer(modelBuilder).Seed();
        }
    }

    public class CompInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public CompInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Componente>().HasData(
                (object)new Componente()
                {
                    Id = 1,
                    NumSerie = "789_XCS",
                    Descripcion = "Procesador Intel i7",
                    Calor = 10,
                    Gigas = 0,
                    Cores = 9,
                    Precio = 134.0,
                    Tipo = EnumComponente.Procesador,
                    OrdenadorId = 2
                },
                new Componente()
                {
                    Id = 2,
                    NumSerie = "789_XCD",
                    Descripcion = "Procesador Intel i7",
                    Calor = 12,
                    Gigas = 0,
                    Cores = 10,
                    Precio = 138.0,
                    Tipo = EnumComponente.Procesador,
                    OrdenadorId = 1
                },
                new Componente()
                {
                    Id = 3,
                    NumSerie = "789_XCT",
                    Descripcion = "Procesador Intel i7",
                    Calor = 22,
                    Gigas = 0,
                    Cores = 11,
                    Precio = 138.0,
                    Tipo = EnumComponente.Procesador,
                    OrdenadorId = 1
                },
                new Componente()
                {
                    Id = 4,
                    NumSerie = "879FH",
                    Descripcion = "Banco de memoria SDRAM",
                    Calor = 10,
                    Gigas = 512,
                    Cores = 0,
                    Precio = 100.0,
                    Tipo = EnumComponente.Memoria,
                    OrdenadorId = 2
                },
                new Componente()
                {
                    Id = 5,
                    NumSerie = "879FH_L",
                    Descripcion = "Banco de memoria SDRAM",
                    Calor = 15,
                    Gigas = 1024,
                    Cores = 0,
                    Precio = 125,
                    Tipo = EnumComponente.Memoria,
                    OrdenadorId = 1
                },
                new Componente()
                {
                    Id = 6,
                    NumSerie = "879FH_T",
                    Descripcion = "Banco de memoria SDRAM",
                    Calor = 24,
                    Gigas = 2028,
                    Cores = 0,
                    Precio = 150,
                    Tipo = EnumComponente.Memoria,
                    OrdenadorId = 1
                },

                new Componente()
                {
                    Id = 7,
                    NumSerie = "789_XX",
                    Descripcion = "Disco Duro Scan Disk",
                    Calor = 10,
                    Gigas = 500000,
                    Cores = 0,
                    Precio = 50,
                    Tipo = EnumComponente.Disco,
                    OrdenadorId = 2
                },
                new Componente()
                {
                    Id = 8,
                    NumSerie = "789_XX_2",
                    Descripcion = "Disco Duro Scan Disk",
                    Calor = 29,
                    Gigas = 1000000,
                    Cores = 0,
                    Precio = 90,
                    Tipo = EnumComponente.Disco,
                    OrdenadorId = 1
                },
                new Componente()
                {
                    Id = 9,
                    NumSerie = "789_XX_3",
                    Descripcion = "Disco Duro Scan Disk",
                    Calor = 39,
                    Gigas = 2000000,
                    Cores = 0,
                    Precio = 128,
                    Tipo = EnumComponente.Disco,
                    OrdenadorId = 1
                },
                new Componente()
                {
                    Id = 10,
                    NumSerie = "797-X",
                    Descripcion = "Procesador Ryzen AMD",
                    Calor = 30,
                    Gigas = 0,
                    Cores = 10,
                    Precio = 78,
                    Tipo = EnumComponente.Procesador,
                    OrdenadorId = 1
                },
                new Componente()
                {
                    Id = 11,
                    NumSerie = "797-X-2",
                    Descripcion = "Procesador Ryzen AMD",
                    Calor = 30,
                    Gigas = 0,
                    Cores = 29,
                    Precio = 178,
                    Tipo = EnumComponente.Procesador,
                    OrdenadorId = 1
                },
                new Componente()
                {
                    Id = 12,
                    NumSerie = "797-X-3",
                    Descripcion = "Procesador Ryzen AMD",
                    Calor = 60,
                    Gigas = 0,
                    Cores = 34,
                    Precio = 278,
                    Tipo = EnumComponente.Procesador,
                    OrdenadorId = 1
                },
                new Componente()
                {
                    Id = 13,
                    NumSerie = "788-fg",
                    Descripcion = "Disco Mecanico Patatin",
                    Calor = 35,
                    Gigas = 250,
                    Cores = 0,
                    Precio = 37,
                    Tipo = EnumComponente.Disco,
                    OrdenadorId = 1
                },
                new Componente()
                {
                    Id = 14,
                    NumSerie = "788-fg-2",
                    Descripcion = "Disco Mecanico Patatin",
                    Calor = 35,
                    Gigas = 250,
                    Cores = 0,
                    Precio = 67,
                    Tipo = EnumComponente.Disco,
                    OrdenadorId = 1
                },
                new Componente()
                {
                    Id = 15,
                    NumSerie = "788-fg-3",
                    Descripcion = "Disco Mecanico Patatin",
                    Calor = 35,
                    Gigas = 250,
                    Cores = 0,
                    Precio = 97,
                    Tipo = EnumComponente.Disco,
                    OrdenadorId = 1
                }
            );
        }
    }

    public class OrdenadorInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public OrdenadorInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Ordenador>().HasData(
                new Ordenador()
                {
                    Id = 1,
                    Descripcion = "Almacén de componentes",
                },
                new Ordenador()
                {
                    Id = 2,
                    Descripcion = "Ordenador de María",
                    PedidoId = 1
                }
            );
        }
    }

    public class PedidoInitalizer
    {
        private readonly ModelBuilder modelBuilder;

        public PedidoInitalizer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Pedido>().HasData(
                new Pedido()
                {
                    Id = 1,
                    Descripcion = "Pedido 1",
                    FacturaId = 1
                },
                new Pedido()
                {
                    Id = 2,
                    Descripcion = "Pedido 2",
                    FacturaId = 1
                }
            );
        }
    }

    public class FacturaInitalizer
    {
        private readonly ModelBuilder modelBuilder;

        public FacturaInitalizer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Factura>().HasData(
                new Factura()
                {
                    Id = 1,
                    Descripcion = "Factura 1"
                }
            );
        }
    }
}