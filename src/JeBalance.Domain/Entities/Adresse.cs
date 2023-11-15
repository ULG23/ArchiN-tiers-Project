namespace JeBalance.Entities
{
    public class Adresse
    {
        public int Numero { get; set; }

         public required string NomdeVoie { get; set; }

        public int CodePostal { get; set; }

        public required string NomdeCommune { get; set; }
    }
}