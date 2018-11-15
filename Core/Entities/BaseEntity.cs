using System.ComponentModel.DataAnnotations.Schema;

namespace api.Core.Entities
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}