using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiDemo.Entities;

namespace WebApiDemo.DataAccess
{


    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;

        public EfEntityRepositoryBase(DbContext context)
        {
            _context = context;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            //IQueryable<TEntity> query = _context.Set<TEntity>();
            //if (predicate != null)
            //{
            //    query = query.Where(predicate);
            //}

            //if (includeProperties.Any())
            //{
            //    foreach (var includeProperty in includeProperties)
            //    {
            //        query = query.Include(includeProperty);
            //    }
            //}

            //return await query.SingleOrDefaultAsync();

            return await _context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            //public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
            //{
            //IQueryable<TEntity> query = _context.Set<TEntity>();
            //if (predicate != null)
            //{
            //    query = query.Where(predicate);
            //}

            //if (includeProperties.Any())
            //{
            //    foreach (var includeProperty in includeProperties)
            //    {
            //        query = query.Include(includeProperty);
            //    }
            //}

            //return await query.ToListAsync();

            //return predicate == null
            //? await _context.Set<TEntity>().ToListAsync()
            //: await _context.Set<TEntity>().Where(predicate).ToListAsync();

            return predicate == null
               ? _context.Set<TEntity>().ToList()
               : _context.Set<TEntity>().Where(predicate).ToList();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        //public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return await _context.Set<TEntity>().AnyAsync(predicate);
        //}

        //public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return await _context.Set<TEntity>().CountAsync(predicate);
        //}
        public void Delete(TEntity entity)
        {
            var deleteEntity = _context.Entry(entity);
            deleteEntity.State= EntityState.Deleted;
            _context.SaveChanges();
        } 
        //public void Delete(TEntity entity)
        //{
        //    _context.Set<TEntity>().Remove(entity);
        //    _context.SaveChanges();
        //}
        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Remove(entity); });
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Update(entity); });
            await _context.SaveChangesAsync();
        }
    }
}
