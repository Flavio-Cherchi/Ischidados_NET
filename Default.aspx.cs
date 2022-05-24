using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;

public partial class _default : BasePage
{
    public User u { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        u = SessionMandatory(false, "Ischidados GdR - I Risvegliati");
        Visibility();
    }

    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        switch (ea.CommandName)
        {
            case "message":
                int i_last_message_id = BllControllerWeb.LoadLastMessageId(int.Parse(Session["i_user_id"].ToString()));
                Response.Redirect("~/Core/messages/messages.aspx?id=" + i_last_message_id + "&msg=received");
                break;
            default:
                break;
        }

    }


    protected void Visibility()
    {
        divWelcomeH1.InnerText = (u.isOnline) ? "Ciao, " + u.t_username + "!" : "Benvenuto su Ischidados GdR!";
        divWelcomeResponsive.InnerText = divWelcomeH1.InnerText;
        //imgDefault.ImageUrl = (u.isOnline) ? u.t_img : "Assets/img/Base/logo.jpg";

        if (u.isOnline)
        {
            divImgDefault.Attributes.Add("class", "customJumbotron d-none d-md-block");

            if (BllControllerWeb.S_Messages_Check_Unread(u.i_user_id) > 0)
                btnNewMessage.Visible = true;

        } else
        {
            divImgDefault.Attributes.Remove("d-none d-md-block");
        }

        imgDefault.ImageUrl = "Assets/img/Base/logo.jpg";
        divWelcomeH2.Visible = (u.isOnline) ? false : true;
        divMarketingH3.Visible = (u.isOnline) ? false : true;
        divIsOnlineRight.Visible = (u.isOnline) ? true : false;
        divWelcomeResponsive.Visible = (u.isOnline) ? true : false;

        linkMyGamesRight.Visible = (BllControllerWeb.S_GamesByUser(u.i_user_id, true).Count > 0 || BllControllerWeb.S_GamesByUser(u.i_user_id, false).Count > 0) ? true : false;

        //divIsOnlineLeft.Visible = divIsOnlineRight.Visible;
        //linkMyGamesLeft.Visible = linkMyGamesRight.Visible;

        DataRow r = BllControllerWeb.S_GameCount();
        divGameList.Visible = (int.Parse(r["GameNum"].ToString()) > 0) ? true : false;
    }

}