using System.Linq.Expressions;
using HotelInfo.Api.DAL.Contexts;
using HotelInfo.Api.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelInfo.Api.DAL.Repository
{
    public class HotelInfoRepository : IHotelInfoRepository
    {
        private readonly HotelInfoContext _hotelInfoContext;

        public HotelInfoRepository(HotelInfoContext hotelInfoContext)
        {
            _hotelInfoContext = hotelInfoContext 
                                ?? throw new ArgumentNullException(nameof(hotelInfoContext));
        }

        public async Task<TE> GetFirstAsync<TE>() where TE : HotelDbEntity
        {
            return await _hotelInfoContext.Set<TE>().FirstOrDefaultAsync();
        }

        public async Task<TE> GetFirstAsync<TE, TP>(Expression<Func<TE, TP>> includedProperty) where TE : HotelDbEntity
        {
            return await _hotelInfoContext.Set<TE>()
                .Include(includedProperty)
                .FirstOrDefaultAsync();
        }

        public async Task<TE> GetFirstAsync<TE>(Expression<Func<TE, bool>> predicate) where TE : HotelDbEntity
        {
            return await _hotelInfoContext.Set<TE>()
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<TE> GetFirstAsync<TE, TP>(Expression<Func<TE, bool>> predicate, Expression<Func<TE, TP>> includedProperty) where TE : HotelDbEntity
        {
            return await _hotelInfoContext.Set<TE>()
                .Where(predicate)
                .Include(includedProperty)
                .FirstOrDefaultAsync();
        }
        
        public async Task<IEnumerable<TE>> GetListAsync<TE>() where TE : HotelDbEntity
        {
            return await _hotelInfoContext.Set<TE>()
                .ToListAsync();
        }

        public async Task<IEnumerable<TE>> GetListAsync<TE, TP>(Expression<Func<TE, TP>> includedProperty) where TE : HotelDbEntity
        {
            return await _hotelInfoContext.Set<TE>()
                .Include(includedProperty)
                .ToListAsync();
        }

        public async Task<IEnumerable<TE>> GetListAsync<TE>(Expression<Func<TE, bool>> predicate) where TE : HotelDbEntity
        {
            return await _hotelInfoContext.Set<TE>()
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TE>> GetListAsync<TE, TP>(Expression<Func<TE, bool>> predicate, Expression<Func<TE, TP>> includedProperty) where TE : HotelDbEntity
        {
            return await _hotelInfoContext.Set<TE>()
                .Where(predicate)
                .Include(includedProperty)
                .ToListAsync();
        }

        public void Add<TE>(TE addedEntity) where TE : HotelDbEntity
        {
            if (addedEntity == null)
                throw new ArgumentNullException(nameof(addedEntity));

            _hotelInfoContext.Add(addedEntity);
        }

        public void Update<TE>(TE updatedEntity) where TE : HotelDbEntity
        {
            if (updatedEntity == null)
                throw new ArgumentNullException(nameof(updatedEntity));

            _hotelInfoContext.Update(updatedEntity);
        }

        public void Remove<TE>(TE removedEntity) where TE : HotelDbEntity
        {
            if (removedEntity == null)
                throw new ArgumentNullException(nameof(removedEntity));

            _hotelInfoContext.Remove(removedEntity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _hotelInfoContext.SaveChangesAsync() > 0);
        }
    }
}
