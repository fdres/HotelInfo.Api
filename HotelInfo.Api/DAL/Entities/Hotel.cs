using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelInfo.Api.DAL.Entities
{
    [Table("Hotel")]
    public class Hotel : HotelDbEntity
    {
        public override Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        public double? StarRating { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
