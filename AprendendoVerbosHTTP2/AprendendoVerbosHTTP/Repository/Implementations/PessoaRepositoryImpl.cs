using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AprendendoVerbosHTTP.Model;
using AprendendoVerbosHTTP.Model.Context;

namespace AprendendoVerbosHTTP.Repository.Implementations
{
    public class PessoaRepositoryImpl : IPessoaRepository
    {

        private MySQLContext _dbContext;

        public PessoaRepositoryImpl(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Pessoa Create(Pessoa pessoa)
        {

            try
            {

                _dbContext.Add(pessoa);
                _dbContext.SaveChanges();

            }catch(Exception ex)
            {
                throw ex;
            }

            return pessoa;
        }

        public void Delete(int ID)
        {

            var result = _dbContext.Pessoas.SingleOrDefault(p => p.ID.Equals(ID));

            try
            {

                if (result != null) _dbContext.Pessoas.Remove(result);
                _dbContext.SaveChanges();

            }catch(Exception ex)
            {
                throw ex;
            }


        }

        public List<Pessoa> FindAll()
        {
            return _dbContext.Pessoas.ToList();
        }

        public Pessoa FindById(int ID)
        {
            return _dbContext.Pessoas.SingleOrDefault(p => p.ID.Equals(ID));
        }

        public Pessoa Update(Pessoa pessoa)
        {

            if (!Exists(pessoa.ID)) return new Pessoa();

            var result = _dbContext.Pessoas.SingleOrDefault(p => p.ID.Equals(pessoa.ID));

            try
            {
                _dbContext.Entry(result).CurrentValues.SetValues(pessoa);
                _dbContext.SaveChanges();

            }catch(Exception ex)
            {
                throw ex;
            }

            return pessoa;

        }

        public bool Exists(int ID)
        {
            return _dbContext.Pessoas.Any(p => p.ID.Equals(ID));
        }
    }
}
