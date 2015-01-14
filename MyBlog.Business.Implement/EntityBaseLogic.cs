using MyBlog.Business.Definition;
using MyBlog.DataAccess.Definition;
using MyBlog.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Implement
{
    /// <summary>
    /// 实体业务逻辑基类
    /// </summary>
    /// <typeparam name="T">业务实体类</typeparam>
    public abstract class EntityBaseLogic<T> : IEntityBaseLogic<T>
        where T : class, IEntityBase
    {
        private readonly IRepository<T> repository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository">注入数据访问接口</param>
        protected EntityBaseLogic(IRepository<T> repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository", "Repository cannot be null");
            }
            this.repository = repository;
        }

        #region IEntityBaseLogic<T> Members

        /// <summary>
        /// 创建实体对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="status">操作状态</param>
        public virtual void Create(T entity, out OperateStatus status)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            repository.Insert(entity);
            status = new OperateStatus
            {
                ResultSign = ResultSign.Successful,
                MessageKey = "创建成功",
            };
        }

        /// <summary>
        /// 更新实体对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="status">操作状态</param>
        public virtual void Update(T entity, out OperateStatus status)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (entity.Id == Guid.Empty)
            {
                throw new ArgumentException("实体的Id为空。");
            }
            status = new OperateStatus();
            var original = GetById(entity.Id);
            if (original == null)
            {
                status.ResultSign = ResultSign.Error;
                status.MessageKey = "源实体对象不存在";
            }
            else
            {

                repository.Update(original, entity);
                status.ResultSign = ResultSign.Successful;
                status.MessageKey = "跟新成功";
            }
        }

        /// <summary>
        /// 删除实体对象
        /// </summary>
        /// <param name="id">实体对象Id</param>
        /// <param name="status">操作状态</param>
        public virtual void Delete(Guid id, out OperateStatus status)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("id为空。");
            }
            status = new OperateStatus();
            T entity = GetById(id);
            if (entity == null)
            {
                status.ResultSign = ResultSign.Error;

                status.MessageKey = "实体对象不存在";
            }
            else
            {
                repository.Delete(entity);
                status.ResultSign = ResultSign.Successful;

                status.MessageKey = "100015";
            }
        }

        /// <summary>
        /// 通过ID获取实体对象
        /// </summary>
        /// <param name="id">实体对象Id</param>
        /// <returns>实体对象</returns>
        public virtual T GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("id为空");
            }
            return repository.GetById(id);
        }

        /// <summary>
        /// 通过指定Id清单获取实体对象清单
        /// </summary>
        /// <param name="values">实体Id清单</param>
        /// <returns>实体对象清单</returns>
        public virtual IList<T> GetByValues(IList<Guid> values)
        {
            return repository.GetByValues(values);
        }

        #endregion
    }
}
