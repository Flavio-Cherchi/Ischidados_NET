using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;

public partial class about : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User u = SessionMandatory(false, "Cos'è Ischidados GdR?");
    }

}