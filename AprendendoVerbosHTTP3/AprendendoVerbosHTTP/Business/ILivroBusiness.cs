using AprendendoVerbosHTTP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AprendendoVerbosHTTP.Business
{
    public interface ILivroBusiness
    {
        Livro Create(Livro livro);
        Livro Update(Livro livro);
        bool Delete(int ID);
        Livro FindById(int ID);
        List<Livro> FindAll();
    }
}
