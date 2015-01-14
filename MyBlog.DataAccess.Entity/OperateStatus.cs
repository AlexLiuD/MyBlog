using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Entity
{
    /// <summary>
    /// 调用服务或业务逻辑的返回标记
    /// </summary>
    [DataContract]
    public enum ResultSign
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        [EnumMember]
        Successful = 0,

        /// <summary>
        /// 警告
        /// </summary>
        [EnumMember]
        Warning = 1,

        /// <summary>
        /// 出现错误
        /// </summary>
        [EnumMember]
        Error = 2
    }

    /// <summary>
    /// 调用服务或业务逻辑的操作状态
    /// </summary>
    [DataContract]
    public class OperateStatus
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public OperateStatus()
        {
            ResultSign = ResultSign.Successful;
            MessageKey = String.Empty;
        }
        /// <summary>
        /// 从操作状态构造
        /// </summary>
        public OperateStatus(OperateStatus status)
        {
            ResultSign = status.ResultSign;
            MessageKey = status.MessageKey;
            FormatParams = status.FormatParams;
        }

        /// <summary>
        /// 从操作状态复制
        /// </summary>
        /// <param name="status">其他操作状态</param>
        public void CopyFromStatus(OperateStatus status)
        {
            ResultSign = status.ResultSign;
            MessageKey = status.MessageKey;
            FormatParams = status.FormatParams;
        }
        /// <summary>
        /// 返回标记
        /// </summary>
        [DataMember]
        public ResultSign ResultSign
        { get; set; }

        /// <summary>
        /// 消息字符串key
        /// </summary>
        [DataMember]
        public string MessageKey
        { get; set; }

        /// <summary>
        /// 消息的参数
        /// </summary>
        [DataMember]
        public string[] FormatParams
        { get; set; }
    }
}
