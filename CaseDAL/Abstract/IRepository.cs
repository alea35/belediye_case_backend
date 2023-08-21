using CaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDAL.Abstract
{
    public interface IRepository<T> where T : Entity
    {
        List<T> GetAll();

        T GetById(Guid id);

        bool Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
