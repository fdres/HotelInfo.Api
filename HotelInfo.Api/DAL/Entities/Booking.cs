using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelInfo.Api.DAL.Entities
{
    [Table("Booking")]
    public class Booking : HotelDbEntity
    {
        public override Guid Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string CustomerSurname { get; set; }

        [MaxLength(50)]
        public string CustomerName { get; set; }

        public short PaxNumber { get; set; }

        [Required]
        public Guid HotelId { get; set; }

        public Hotel Hotel { get; set; }
    }
}
