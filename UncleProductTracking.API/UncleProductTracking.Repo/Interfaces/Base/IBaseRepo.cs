using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UncleProductTracking.Entities.Models.Base;

namespace UncleProductTracking.Repo.Interfaces.Base
{
    public interface IBaseRepo<T> where T : BaseModel
    {
        List<T> GetAll();

        T Create(T model);

        T GetById(int id);

        void Delete(int id);

        T Update(T model);
    }
}
