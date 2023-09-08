using Sat.Recruitment.Core.Interfaces.Generics.DTOs.Entities;

namespace Sat.Recruitment.Core.Generics.DTOs.Entities
{
    public abstract class BaseDtoEntity : IIBaseDtoEntity
    {
        public int Id { get; set; }
    }
}
