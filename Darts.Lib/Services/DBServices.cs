using Darts.Lib.DBTemp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Darts.Lib.Services
{
    public class DBServices
    {
        public interface IDBAction
        {

            IQueryable<TEntity> ReadData<TEntity>() where TEntity : class, new();
            int InsertData<TEntity>(TEntity _entity) where TEntity : class, new();
            int DeleteData<TEntity>(TEntity _entity) where TEntity : class, new();
            int UpdateData<TEntity>(TEntity _entity) where TEntity : class, new();

            List<TEntity> ReadRangeData<TEntity>() where TEntity : class, new();
            int InsertRangeData<TEntity>(List<TEntity> _entity) where TEntity : class, new();
            int DeleteRangeData<TEntity>(List<TEntity> _entity) where TEntity : class, new();
            int UpdateRangeData<TEntity>(List<TEntity> _entity) where TEntity : class, new();
        }

        public class DBService : IDBAction
        {
            //PlayGroundContextContext
            private DartTempContext db;
            public DBService(DartTempContext _db)
            {
                this.db = _db;
            }
            public List<TEntity> ReadRangeData<TEntity>() where TEntity : class, new()
            {
                var query = this.db.Set<TEntity>().AsNoTracking().ToList();
                return query;
            }
            public IQueryable<TEntity> ReadData<TEntity>() where TEntity : class, new()
            {
                var query = this.db.Set<TEntity>().AsNoTracking();
                return query;
            }

            public int InsertData<TEntity>(TEntity _entity) where TEntity : class, new()
            {
                this.db.Set<TEntity>().Add(_entity);
                return SaveDB();
            }

            public int DeleteData<TEntity>(TEntity _entity) where TEntity : class, new()
            {
                this.db.Set<TEntity>().Remove(_entity);
                return SaveDB();
            }

            public int UpdateData<TEntity>(TEntity _entity) where TEntity : class, new()
            {
                this.db.Set<TEntity>().Update(_entity);
                return SaveDB();
            }

            public int InsertRangeData<TEntity>(List<TEntity> _entity) where TEntity : class, new()
            {
                this.db.Set<TEntity>().AddRange(_entity);
                return SaveDB();
            }

            public int DeleteRangeData<TEntity>(List<TEntity> _entity) where TEntity : class, new()
            {
                this.db.Set<TEntity>().RemoveRange(_entity);
                return SaveDB();
            }

            public int UpdateRangeData<TEntity>(List<TEntity> _entity) where TEntity : class, new()
            {
                this.db.Set<TEntity>().UpdateRange(_entity);
                return SaveDB();
            }

            /****************************************************************************************************/
            private int SaveDB()
            {
                int state = -1;
                try
                {
                    state = this.db.SaveChanges();
                }
                catch (Exception ex)
                {
                    //to do log
                }
                return state;
            }
        }
    }
}
