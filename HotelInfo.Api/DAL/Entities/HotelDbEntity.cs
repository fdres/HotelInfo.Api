using System;

namespace HotelInfo.Api.DAL.Entities
{
    public abstract class HotelDbEntity
    {
        public abstract Guid Id { get; set; }
    }
}
