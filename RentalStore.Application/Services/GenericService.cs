using RentalStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.Application.Services
{
    public class GenericService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public GenericService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public int Count()
        {
            return _repository.Count();
        }

        public TEntity Get(int id)
        {
            return _repository.Get(id);
        }

        public IList<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.Find(expression);
        }

        public void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }
        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }
    }
}
