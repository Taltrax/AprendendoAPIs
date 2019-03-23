using AprendendoVerbosHTTP.Model.Base;
using System.Collections.Generic;

namespace AprendendoVerbosHTTP.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T data);
        T Update(T data);
        bool Delete(int ID);
        T FindById(int ID);
        List<T> FindAll();
        bool Exists(int ID);
    }
}
