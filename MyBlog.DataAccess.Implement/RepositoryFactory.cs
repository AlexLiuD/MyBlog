using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using MyBlog.DataAccess.Definition;
using MyBlog.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Implement
{ ///<summary>
    /// 数据访问类工厂
    ///</summary>
    public class RepositoryFactory1
    {
        private static readonly IUnityContainer container;
        static RepositoryFactory1()
        {
            container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);
        }

        /// <summary>
        /// 获取数据访问实例
        /// </summary>
        /// <typeparam name="TRepository">业务实体访问接口</typeparam>
        /// <typeparam name="TEntity">业务实体</typeparam>
        /// <returns>数据访问实例</returns>
        public static TRepository GetRepositoryInstance<TRepository, TEntity>()
            where TEntity : IEntityBase
            where TRepository : IRepository<TEntity>
        {
            return container.Resolve<TRepository>();
        }

        /// <summary>
        /// 获取数据访问实例
        /// </summ ary>
        /// <typeparam name="TRepository">数据访问接口</typeparam>
        /// <returns>数据访问实例</returns>
        public static TRepository GetRepositoryInstance<TRepository>()
        {
            return container.Resolve<TRepository>();
        }

        /// <summary>
        /// 获取数据访问实例
        /// </summary>
        /// <typeparam name="TRepository">数据访问接口</typeparam>
        /// <returns>数据访问实例</returns>
        public static TRepository GetRepositoryInstance<TRepository>(string name)
        {
            return container.Resolve<TRepository>(name);
        }
    }
}
