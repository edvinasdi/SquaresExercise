using Microsoft.EntityFrameworkCore;

namespace SquaresAPI.Data.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
