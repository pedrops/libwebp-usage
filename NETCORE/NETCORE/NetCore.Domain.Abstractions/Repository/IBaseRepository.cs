using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Domain.Abstractions.Repository
{
    public interface IBaseRepository<IEntity> where IEntity : class
    {
        IEntity Get(string id);
        IEnumerable<IEntity> GetAll();
        void Add(IEntity entity);
        void Remove(IEntity entity);
        void Update(IEntity entity);
    }
}
