using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Maticsoft.Web
{
    public partial class Greybox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //在后台代码控制弹出效果
            HyperLink1.Attributes.Add("onclick", "return GB_showCenter('Google', this.href)");//GB_show
            //HyperLink1.Attributes.Add("onclick", "return GB_showFullScreen('Google', this.href)");//GB_show

            HyperLink2.Attributes.Add("onclick", "return GB_showImage('图片', this.href)");//GB_show
                        

        }
    }
}
