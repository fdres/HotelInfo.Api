using System.Runtime.Serialization;

namespace HotelInfo.Api.DTO
{
    [DataContract]
    public class HotelDto
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "starRating")]
        public double? StarRating { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}
