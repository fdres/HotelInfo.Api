using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace HotelInfo.Api.DTO
{
    [DataContract]
    public class HotelForAddOrUpdateDto
    {
        [DataMember(Name = "name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DataMember(Name = "address")]
        [StringLength(100)]
        public string Address { get; set; }

        [DataMember(Name = "starRating")]
        public double? StarRating { get; set; }

        [DataMember(Name = "description")]
        [StringLength(500)]
        public string Description { get; set; }
    }
}
