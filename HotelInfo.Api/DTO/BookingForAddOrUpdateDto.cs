using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace HotelInfo.Api.DTO
{
    [DataContract]
    public class BookingForAddOrUpdateDto
    {
        [DataMember(Name = "customerSurname")]
        [StringLength(50)]
        [Required]
        public string CustomerSurname { get; set; }

        [DataMember(Name = "customerName")]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [DataMember(Name = "paxNumber")]
        public short PaxNumber { get; set; }
    }
}
