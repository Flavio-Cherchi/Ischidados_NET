using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;

public partial class adminPanel : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User u = SessionMandatory(true, "Admin panel");

        AdminOnly(u);

        if (!IsPostBack)
        {
        }
    }


    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        switch (ea.CommandName)
        {
            case "natures":
                Response.Redirect("~/Core/Admin/Natures.aspx");
                break;
            case "test":
                Response.Redirect("~/Core/Test/elenco_test.aspx");
                break;
            case "games":
                //toDo
                Response.Redirect("~/Core/Admin/Natures.aspx");
                break;
            case "community":
                //testing!
                Response.Redirect("~/Core/communities/community.aspx");
                break;
            case "characters":
                Response.Redirect("~/Core/characters/charactersList.aspx");
                break;
            case "testCharacters":
                Response.Redirect("~/Core/characters/characters.aspx");
                break;
            case "images":
                Response.Redirect("~/Core/images/imagesList.aspx");
                break;
            case "usersLog":
                Response.Redirect("~/Core/Admin/usersLog.aspx");
                break;
        }
    }
}