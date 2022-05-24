using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;

public partial class error : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            switch (Request.QueryString["id"].ToString())
            {
                case "working":
                    imgDefault.Src = "https://i.pinimg.com/236x/c3/c5/53/c3c5539dfd1a0a2d1fb7561699f942b8--funny-things-funny-stuff.jpg";
                    break;
                case "magicWord":
                    imgDefault.Src = "https://www.waywardsparkles.com/wp-content/uploads/2021/05/the-magic-word.gif";
                    break;
                default:
                    break;
            }
        }
    }

}