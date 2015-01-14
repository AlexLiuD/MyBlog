using MyBlog.DataAccess.Definition;
using MyBlog.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Implement
{
    public class UserInfoRepository : IUserInfoRepository
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
        /// 快速查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IList<UserInfo> QuickQuery(UserInfoQueryParam param)
         {
             int number;
             int.TryParse(param.Value, out number);
             var query =
                 activeContext.UserInfos.Where(
                     f => (string.IsNullOrEmpty(param.Value) || f.UserCode == number
                           || f.UserName.Contains(param.Value)));
             return query.ToList<UserInfo>();
         }

        public void Create(UserInfo entity)
        {
            //加入实体
            activeContext.UserInfos.Add(entity);
            //提交数据库
            activeContext.SaveChanges();
        }

    }
}
