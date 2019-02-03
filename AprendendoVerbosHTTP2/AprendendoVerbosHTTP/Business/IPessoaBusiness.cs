using AprendendoVerbosHTTP.Model;
using System.Collections.Generic;

namespace AprendendoVerbosHTTP.Repository
{
    public interface IPessoaBusiness
    {

        Pessoa Create(Pessoa pessoa);
        Pessoa FindById(int ID);
        List<Pessoa> FindAll();
        Pessoa Update(Pessoa pessoa);
        void Delete(int ID);

    }
}
