using AprendendoVerbosHTTP.Model.Base;
using AprendendoVerbosHTTP.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AprendendoVerbosHTTP.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MySQLContext _dbContext;
        protected DbSet<T> _dbSet;

        public GenericRepository(MySQLContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public T Create(T data)
        {
            try
            {
                _dbSet.Add(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return data;
        }

        public T Update(T data)
        {
            if (!Exists(data.ID)) return null;

            var dataUpdate = _dbSet.SingleOrDefault(search => search.ID.Equals(data.ID));

            if (dataUpdate != null)
            {
                try
                {
                    _dbContext.Entry(dataUpdate).CurrentValues.SetValues(data);
                    _dbContext.SaveChanges();
                    return data;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return null;
        }

        public bool Delete(int ID)
        {
            var dataDelete = _dbSet.SingleOrDefault(data => data.ID.Equals(ID));

            try
            {
                if (dataDelete != null)
                {
                    _dbSet.Remove(dataDelete);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        public T FindById(int ID)
        {
            return _dbSet.FirstOrDefault(data => data.ID.Equals(ID));
        }

        public List<T> FindAll()
        {
            return _dbSet.ToList();
        }

        public List<T> FindWithPagedSearch(string query)
        {
            return _dbSet.FromSql<T>(query).ToList();
        }

        public int GetCount(string query)
        {
            var result = "";

            using (var conexao = _dbContext.Database.GetDbConnection())
            {
                conexao.Open();

                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandText = query;
                    result = comando.ExecuteScalar().ToString();
                }
            }

            return Int32.Parse(result);
        }

        public bool Exists(int ID)
        {
            return _dbSet.Any(data => data.ID.Equals(ID));
        }     
    }
}
