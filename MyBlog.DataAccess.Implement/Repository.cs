using MyBlog.DataAccess.Definition;
using MyBlog.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Implement
{
    /// <summary>
    /// 数据访问层操作实现基类
    /// </summary>
    /// <typeparam name="T">实体类</typeparam>
    public abstract class Repository<T> : IRepository<T>//, INoteRepoistory<T>
        where T : class, IEntityBase
    {
        #region 实体框架操作

        /// <summary>
        /// 实体数据库
        /// </summary>
        protected abstract DbContext ActiveContext { get; }

        /// <summary>
        /// 实体对象集合(查询)
        /// </summary>
        protected virtual DbQuery<T> DbQuery
        {
            get { return DbSet; }
        }

        /// <summary>
        /// 实体对象集合(操作)
        /// </summary>
        protected abstract DbSet<T> DbSet { get; }

        /// <summary>
        /// 实体接受所有变更,重置到UnChanged状态,用于缓存更新前
        /// </summary>
        /// <param name="item">业务实体</param>
        protected virtual void AcceptChanges(T item)
        {
            if (item == null) { return; }
        }


        #endregion

        #region IRepository<T> Members


        /// <summary>
        /// 插入对象
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(T entity)
        {
            //加入实体
            DbSet.Add(entity);
            //提交数据库
            ActiveContext.SaveChanges();
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            //执行删除
            DbSet.Attach(entity);
            DbSet.Remove(entity);
            //提交数据库
            ActiveContext.SaveChanges();
        }

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="original">原始数据</param>
        /// <param name="current">当前数据</param>
        public virtual void Update(T original, T current)
        {
            //执行更改
            DbSet.Attach(original);
            ActiveContext.Entry(original).CurrentValues.SetValues(current);
            //提交数据库
            ActiveContext.SaveChanges();
            //实体接受所有变更,重置到UnChanged状态
            AcceptChanges(original);
        }

        /// <summary>
        /// 将已经附加的当前实体对象的变更更新到数据库
        /// </summary>
        /// <remarks>实体对象在变更前已经附加在数据库上下文中</remarks>
        /// <param name="current">实体对象当前值</param>
        public virtual void Update(T current)
        {
            DbSet.Attach(current);
            //执行更改
            ActiveContext.Entry(current).State = EntityState.Modified;
            //提交数据库
            ActiveContext.SaveChanges();
            //实体接受所有变更,重置到UnChanged状态
            AcceptChanges(current);
        }

        /// <summary>
        /// 根据Id获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(Guid id)
        {
            return DbQuery.SingleOrDefault(o => o.Id == id);
        }

        /// <summary>
        /// 通过指定Id清单获取实体对象清单
        /// </summary>
        /// <param name="values">实体Id清单</param>
        /// <returns>实体对象清单</returns>
        public virtual IList<T> GetByValues(IList<Guid> values)
        {
            return DbQuery.Where(e => values.Contains(e.Id)).ToList();
        }

        /// <summary>
        /// 获取所有对象
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>实体对象清单</returns>
        public virtual IList<T> GetAll()
        {
            IList<T> result = DbQuery.ToList();
            return result;
        }

        #endregion
    }
}
