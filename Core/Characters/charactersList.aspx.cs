using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;

public partial class charactersList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User u = SessionMandatory(true, "Elenco personaggi");

        if (!IsPostBack)
        {
            LoadTable();
        }
    }


    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        switch (ea.CommandName)
        {
            case "research":
                //LoadTable();
                Response.Redirect("~/error.aspx?id=working");
                break;
            case "newChar":
                Response.Redirect("~/error.aspx");
                break;
        }
    }

    protected void LoadTable()
    {
        Rep.DataSource = BllControllerWeb.S_Characters();
        Rep.DataBind();
    }
}