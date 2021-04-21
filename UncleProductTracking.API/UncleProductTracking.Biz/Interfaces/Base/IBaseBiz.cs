using System;
using System.Collections.Generic;
using System.Text;
using UncleProductTracking.Entities.Models.Base;

namespace UncleProductTracking.Biz.Interfaces.Base
{
    public interface IBaseBiz<T> where T : BaseModel
    {
        T Create(T model);

        List<T> GetAll();

        T GetById(int id);

        void Delete(int id);

        T Update(T model);
    }
}
