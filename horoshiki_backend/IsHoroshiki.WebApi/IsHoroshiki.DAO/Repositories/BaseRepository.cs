using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using IsHoroshiki.DAO.Helpers;
using System.Data.SqlClient;
using System.Data;

namespace IsHoroshiki.DAO.Repositories
{
    /// <summary>  
    /// Базовый репозиторий
    /// </summary>  
    /// <typeparam name="TDaoEntity">Тип сущности Dao</typeparam> 
    public abstract class BaseRepository<TDaoEntity> : IBaseRepository<TDaoEntity>
        where TDaoEntity : class, IBaseDaoEntity
    {
        #region поля и свойства

        /// <summary>
        /// Контекст выполнения БД
        /// </summary>
        protected ApplicationDbContext Context;

        /// <summary>
        /// Сущность БД
        /// </summary>
        protected DbSet<TDaoEntity> DbSet;

        #endregion

        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        protected BaseRepository(ApplicationDbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TDaoEntity>();
        }

        #endregion

        #region методы

        /// <summary>  
        /// Найти по Id 
        /// </summary>  
        /// <param name="id">Id</param>  
        /// <returns></returns>  
        public virtual async Task<TDaoEntity> GetByIdAsync(int id)
        {
            var daoEntity = DbSet.Find(id);
            if (daoEntity != null)
            {
                LoadChildEntities(daoEntity);
            }
            return daoEntity;
        }

        /// <summary>  
        /// Добавить
        /// </summary>  
        /// <param name="entity">Сущность DAO</param>  
        public virtual void Insert(TDaoEntity entity)
        {
            BeforeInsert(entity);
            DbSet.Add(entity);
        }

        /// <summary>  
        /// Обновить  
        /// </summary>  
        /// <param name="entity">Сущность DAO</param>  
        public virtual void Update(TDaoEntity entity)
        {
            BeforeUpdate(entity);
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>  
        /// Удалить по Id 
        /// </summary>  
        /// <param name="id">Id</param>  
        public virtual void Delete(int id)
        {
            TDaoEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>  
        /// Удалить
        /// </summary>  
        /// <param name="entity">Сущность DAO</param>  
        public virtual void Delete(TDaoEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        /// <summary>  
        /// Получить записи по условию  
        /// </summary>  
        /// <param name="where">Условие в запросе</param>  
        /// <returns></returns>  
        public virtual async Task<IEnumerable<TDaoEntity>> GetManyAsync(Func<TDaoEntity, bool> where)
        {
            var list = DbSet.Where(where).ToList();
            foreach (var daoEntity in list)
            {
                LoadChildEntities(daoEntity);
            }
            return list;
        }

        /// <summary>  
        /// Получить запись по условию    
        /// </summary>  
        /// <param name="where">Условие в запросе</param>  
        /// <returns></returns>  
        public virtual async Task<TDaoEntity> GetAsync(Func<TDaoEntity, Boolean> where)
        {
            var daoEntity = DbSet.Where(where).FirstOrDefault<TDaoEntity>();
            if (daoEntity != null)
            {
                LoadChildEntities(daoEntity);
            }
            return daoEntity;
        }

        /// <summary>  
        /// Удалить записи по условию 
        /// </summary>  
        /// <param name="where">Условие в запросе</param>  
        /// <returns></returns>  
        public virtual void Delete(Func<TDaoEntity, Boolean> where)
        {
            IQueryable<TDaoEntity> objects = DbSet.Where<TDaoEntity>(where).AsQueryable();
            foreach (TDaoEntity obj in objects)
            {
                DbSet.Remove(obj);
            }
        }

        /// <summary>  
        /// Получить все записи
        /// </summary>  
        /// <param name="pageNo">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <param name="isLoadChild">true - если нужно загрузить дочерние объекты</param>
        public virtual async Task<IEnumerable<TDaoEntity>> GetAllAsync(int pageNo = 1, int pageSize = Int32.MaxValue, string sortField = "", bool isAscending = true, bool isLoadChild = true)
        {
            int skip = (pageNo - 1) * pageSize;

            var list = DbSet.OrderByPropertyName(sortField, isAscending)
                            .Skip(skip)
                            .Take(pageSize)
                            .ToList()
                            .AsEnumerable();

            if (isLoadChild)
            {
                foreach (var daoEntity in list)
                {
                    LoadChildEntities(daoEntity);
                }
            }

            return list;
        }

        /// <summary>  
        /// Получить количество записей
        /// </summary>  
        /// <returns></returns>  
        public virtual Task<int> CountAsync()
        {
            return DbSet.CountAsync();
        }

        /// <summary>  
        /// Проверка на существование записи
        /// </summary>  
        /// <param name="id">id</param>  
        /// <returns></returns>  
        public virtual async Task<bool> IsExistsAsync(int id)
        {
            return DbSet.Find(id) != null;
        }

        #endregion

        #region protected virtual

        /// <summary>
        /// Действие с сущностью перед добавлением в БД
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void BeforeInsert(TDaoEntity entity)
        {

        }

        /// <summary>
        /// Действие с сущностью перед обновлением в БД
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void BeforeUpdate(TDaoEntity entity)
        {

        }

        /// <summary>
        /// Действие с сущностью перед добавлением в БД
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void LoadChildEntities(TDaoEntity entity)
        {

        }

        /// <summary>
        /// Создать параметр БД
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="value">Значение</param>
        /// <returns></returns>
        protected virtual IDataParameter GetParameter(string name, object value)
        {
            return new SqlParameter(name, value); 
        }

        #endregion
    }
}
