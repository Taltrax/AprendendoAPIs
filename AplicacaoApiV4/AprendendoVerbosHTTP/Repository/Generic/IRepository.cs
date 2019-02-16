using AprendendoVerbosHTTP.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AprendendoVerbosHTTP.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T data);
        T FindById(int ID);
        List<T> FindAll();
        T Update(T data);
        bool Delete(int ID);
        bool Exists(int ID);
    }
}
