using MyBlog.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Definition
{
    public interface IUserInfoRepository
    {
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IList<UserInfo> QuickQuery(UserInfoQueryParam param);
    }
}
