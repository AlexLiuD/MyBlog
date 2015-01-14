using MyBlog.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Definition
{
    /// <summary>
    /// 用户信息数据访问接口
    /// </summary>
    public interface IUserInfoRepository : IRepository<UserInfo>
    {
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IList<UserInfo> QuickQuery(UserInfoQueryParam param);
    }
}
