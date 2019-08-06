using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        //atributo
        private readonly DataContext context;

        //contrutor para injeção de dependência
        protected BaseRepository(DataContext context)
        {
            this.context = context;
        }

        public virtual void Insert(T obj)
        {
            context.Entry(obj).State = EntityState.Added;
            context.SaveChanges();
        }

        public virtual void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual void Delete(int id)
        {

            var obj = context.Set<T>().Find(id);

            context.Entry(obj).State = EntityState.Deleted;
            context.SaveChanges();

        }

        public virtual List<T> SelectAll()
        {
            return context.Set<T>().ToList();
        }

        public virtual T SelectById(int id)
        {
            return context.Set<T>().Find(id);
        }
    }
}
