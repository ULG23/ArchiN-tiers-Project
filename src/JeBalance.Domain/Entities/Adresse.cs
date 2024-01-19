namespace JeBalance.Entities
{
    public class Adresse
    {
        public required int Numero { get; set; }

         public required string NomdeVoie { get; set; }

        public required int CodePostal { get; set; }

        public required string NomdeCommune { get; set; }
    }
}