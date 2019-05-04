using System;
using System.Runtime.Serialization;

namespace HotelInfo.Api.DTO
{
    [DataContract]
    public class BookingDto
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "customerSurname")]
        public string CustomerSurname { get; set; }

        [DataMember(Name = "customerName")]
        public string CustomerName { get; set; }

        [DataMember(Name = "paxNumber")]
        public short PaxNumber { get; set; }

        [DataMember(Name = "hotelId")]
        public Guid HotelId { get; set; }

        [DataMember(Name = "hotelInfo")]
        public string HotelInfo { get; set; }
    }
}
