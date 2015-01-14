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
    /// 用户信息业务逻辑层
    /// </summary>
    public class UserInfoLogic : EntityBaseLogic<UserInfo>, IUserInfoLogic
    {
        private readonly IUserInfoRepository repository;

         /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        public UserInfoLogic(IUserInfoRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IList<UserInfo> QuickQuery(UserInfoQueryParam param)
        {
            return repository.QuickQuery(param);
        }
    }
}
