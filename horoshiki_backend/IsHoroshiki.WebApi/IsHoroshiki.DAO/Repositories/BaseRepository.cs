using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IsHoroshiki.DAO.Repositories
{
    /// <summary>  
    /// Базовый репозиторий
    /// </summary>  
    /// <typeparam name="TDaoEntity">Тип сущности Dao</typeparam> 
    /// <typeparam name="TPrimaryKey">Тип primary key в БД</typeparam> 
    public abstract class BaseRepository<TDaoEntity, TPrimaryKey> : IBaseRepository<TDaoEntity, TPrimaryKey>
        where TDaoEntity : BaseDaoEntity
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
        public virtual TDaoEntity GetById(TPrimaryKey id)
        {
            return DbSet.Find(id);
        }

        /// <summary>  
        /// Добавить
        /// </summary>  
        /// <param name="entity">Сущность DAO</param>  
        public virtual void Insert(TDaoEntity entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>  
        /// Удалить по Id 
        /// </summary>  
        /// <param name="id">Id</param>  
        public virtual void Delete(TPrimaryKey id)
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
        /// Обновить  
        /// </summary>  
        /// <param name="entity">Сущность DAO</param>  
        public virtual void Update(TDaoEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>  
        /// Получить записи по условию  
        /// </summary>  
        /// <param name="where">Условие в запросе</param>  
        /// <returns></returns>  
        public virtual IEnumerable<TDaoEntity> GetMany(Func<TDaoEntity, bool> where)
        {
            return DbSet.Where(where).ToList();
        }

        /// <summary>  
        /// Получить запись по условию    
        /// </summary>  
        /// <param name="where">Условие в запросе</param>  
        /// <returns></returns>  
        public TDaoEntity Get(Func<TDaoEntity, Boolean> where)
        {
            return DbSet.Where(where).FirstOrDefault<TDaoEntity>();
        }

        /// <summary>  
        /// Удалить записи по условию 
        /// </summary>  
        /// <param name="where">Условие в запросе</param>  
        /// <returns></returns>  
        public void Delete(Func<TDaoEntity, Boolean> where)
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
        /// <returns></returns>  
        public virtual IEnumerable<TDaoEntity> GetAll()
        {
            return DbSet.ToList();
        }

        /// <summary>  
        /// Проверка на существование записи
        /// </summary>  
        /// <param name="id">id</param>  
        /// <returns></returns>  
        public bool Exists(TPrimaryKey id)
        {
            return DbSet.Find(id) != null;
        }

        #endregion
    }
}
