using Sat.Recruitment.Core.Interfaces.Entities;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Core.Generics.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedByAt { get; set; }
    }
}
