using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Maticsoft.Web
{
    /// <summary>
    /// 用户行为日志类
    /// </summary>
    public sealed class UserLog
    {
        /// <summary>
        /// 增加日志内容
        /// </summary>        
        public static void AddLog(string UserName,string UserType,string UserIP,string URL,string Info)
        {
            Maticsoft.Model.UserLog model = new Maticsoft.Model.UserLog();
            model.OPInfo = Info;
            model.Url = URL;
            model.UserIP = UserIP;
            model.UserName = UserName;
            model.UserType = UserType;
            Maticsoft.BLL.UserLog log = new Maticsoft.BLL.UserLog();
            log.LogUserAdd(model);

        }
    }
}
