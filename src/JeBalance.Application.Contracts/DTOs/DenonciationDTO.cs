using System;
using JeBalance.Enums;

namespace JeBalance.DTOs
{
    public class DenonciationDTO
    {
        public Guid? Id { get; set; }
        public Guid? Informateur { get; set; }

        public SuspectDTO? Suspect { get; set; }

        public eDelit? Delit { get; set; }

        public string? PaysEvasion { get; set; }

        public ReponseDTO? Reponse { get; set; }
    }
}

