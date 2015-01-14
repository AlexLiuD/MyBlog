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
    /// 用户信息数据访问类
    /// </summary>
    public class UserInfoRepository : Repository<UserInfo>,IUserInfoRepository
    {
         private readonly MyBlogEntities activeContext;

        /// <summary>
        /// 构造函数
        /// </summary>
        public UserInfoRepository()
        {
            activeContext = new MyBlogEntities();
        }

        /// <summary>
        /// 实体数据库
        /// </summary>
        protected override DbContext ActiveContext
        {
            get
            {
                return activeContext;
            }
        }

        /// <summary>
        /// 用户信息实体集合(操作)
        /// </summary>
        protected override DbSet<UserInfo> DbSet
        {
            get { return activeContext.UserInfos; }
        }

        /// <summary>
        /// 重写实体对象集合(查询)
        /// </summary>
        protected override DbQuery<UserInfo> DbQuery
        {
            get
            {
                return activeContext.UserInfos;
            }
        }

        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IList<UserInfo> QuickQuery(UserInfoQueryParam param)
         {
             int number;
             int.TryParse(param.Value, out number);
             var query =
                 DbQuery.Where(
                     f => (string.IsNullOrEmpty(param.Value) || f.UserCode == number
                           || f.UserName.Contains(param.Value)));
             return query.ToList<UserInfo>();
         }
    }
}
