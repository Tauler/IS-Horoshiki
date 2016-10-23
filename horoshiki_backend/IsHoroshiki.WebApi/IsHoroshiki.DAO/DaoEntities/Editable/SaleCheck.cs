using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.DaoEntities.NotEditable;
using System;
using System.Collections.Generic;

namespace IsHoroshiki.DAO.DaoEntities.Editable
{
    /// <summary>
    /// Чек продаж
    /// </summary>
    public class SaleCheck : BaseDaoEntity
    {
        /// <summary>
        /// Способ покупки
        /// </summary>
        public int? BuyProcessId
        {
            get;
            set;
        }

        /// <summary>
        /// Способ покупки
        /// </summary>
        public BuyProcess BuyProcess
        {
            get;
            set;
        }

        /// <summary>
        /// Подотделы
        /// </summary>
        public ICollection<SubDepartment> SubDepartments
        {
            get;
            set;
        }

        /// <summary>
        /// Площадка
        /// </summary>
        public int PlatformId
        {
            get;
            set;
        }

        /// <summary>
        /// Площадка
        /// </summary>
        public Platform Platform
        {
            get;
            set;
        }

        /// <summary>
        /// Дата и время чека (время приема заказа)
        /// </summary>
        public DateTime? DateDoc
        {
            get;
            set;
        }

        /// <summary>
        /// Номер чека
        /// </summary>
        public string IdCheck
        {
            get;
            set;
        }

        /// <summary>
        /// Сумма чека
        /// </summary>
        public decimal Sum
        {
            get;
            set;
        }

        /// <summary>
        /// Время нач приготовления план
        /// </summary>
        public DateTime? PlanCookingStart
        {
            get;
            set;
        }

        /// <summary>
        /// Время нач приготовления факт
        /// </summary>
        public DateTime? FactCookingStart
        {
            get;
            set;
        }

        /// <summary>
        /// Время оконч приготовления план 
        /// </summary>
        public DateTime? PlanCookingEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Время оконч приготовления факт 
        /// </summary>
        public DateTime? FactCookingEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Нач упаковки план
        /// </summary>
        public DateTime? PlanPackingStart
        {
            get;
            set;
        }

        /// <summary>
        /// Нач упаковки факт
        /// </summary>
        public DateTime? FactPackingStart
        {
            get;
            set;
        }

        /// <summary>
        /// Oкончание упаковки план
        /// </summary>
        public DateTime? PlanPackingEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Oкончание упаковки факт
        /// </summary>
        public DateTime? FactPackingEnd
        {
            get;
            set;
        }

        /// <summary>
        /// начало доставки план
        /// </summary>
        public DateTime? PlanDeliveryStart
        {
            get;
            set;
        }

        /// <summary>
        /// начало доставки факт
        /// </summary>
        public DateTime? FactDeliveryStart
        {
            get;
            set;
        }

        /// <summary>
        /// Окончание доставки план
        /// </summary>
        public DateTime? PlanDeliveryEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Окончание доставки факт
        /// </summary>
        public DateTime? FactDeliveryEnd
        {
            get;
            set;
        }
    }
}
