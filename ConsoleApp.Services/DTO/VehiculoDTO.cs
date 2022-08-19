namespace ConsoleApp.Services.Services
{
    public class VehiculoDTO
    {
        public int Id { get; set; }
        public decimal Precio { get; set; }
        public string Anio { get; set; }



        //////////////////////////////////////////////////////////////////
        // Foreing Keys 
        public int ModeloId { get; set; }
        public ModeloDTO Modelo { get; set; }

        public int PaisId { get; set; }
        public PaisDTO Pais { get; set; }

        public int ColorId { get; set; }
        public ColorDTO Color { get; set; }

        public int CombustibleId { get; set; }
        public CombustibleDTO Combustible { get; set; }

        public int SeguroId { get; set; }
        public SeguroDTO Seguro { get; set; }

        public int TipoId { get; set; }
        public TipoDTO Tipo { get; set; }

        public int MarcaId { get; set; }
        public MarcaDTO Marca { get; set; }

        public int TransmisionId { get; set; }
        public TransmisionDTO Transmision { get; set; }
    }
}
