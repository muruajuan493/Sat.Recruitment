using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Core.Interfaces.Entities
{
    public interface IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedByAt { get; set; }
    }
}
