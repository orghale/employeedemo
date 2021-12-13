using System;
using System.ComponentModel.DataAnnotations;

namespace empapp.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        public int CreatedBy { get; set; }
    }
}
