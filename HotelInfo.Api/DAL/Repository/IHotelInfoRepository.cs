using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelInfo.Api.DAL.Entities;

namespace HotelInfo.Api.DAL.Repository
{
    public interface IHotelInfoRepository
    {
        Task<TE> GetFirstAsync<TE>() where TE : HotelDbEntity;

        Task<TE> GetFirstAsync<TE, TP>(Expression<Func<TE, TP>> includedProperty) where TE : HotelDbEntity;

        Task<TE> GetFirstAsync<TE>(Expression<Func<TE, bool>> predicate) where TE : HotelDbEntity;

        Task<TE> GetFirstAsync<TE, TP>(Expression<Func<TE, bool>> predicate, Expression<Func<TE, TP>> includedProperty) where TE : HotelDbEntity;

        Task<IEnumerable<TE>> GetListAsync<TE>() where TE : HotelDbEntity;

        Task<IEnumerable<TE>> GetListAsync<TE, TP>(Expression<Func<TE, TP>> includedProperty) where TE : HotelDbEntity;

        Task<IEnumerable<TE>> GetListAsync<TE>(Expression<Func<TE, bool>> predicate) where TE : HotelDbEntity;

        Task<IEnumerable<TE>> GetListAsync<TE, TP>(Expression<Func<TE, bool>> predicate, Expression<Func<TE, TP>> includedProperty) where TE : HotelDbEntity;

        void Add<TE>(TE addedEntity) where TE : HotelDbEntity;

        void Update<TE>(TE updatedEntity) where TE : HotelDbEntity;

        void Remove<TE>(TE removedEntity) where TE : HotelDbEntity;

        Task<bool> SaveChangesAsync();
    }
}
