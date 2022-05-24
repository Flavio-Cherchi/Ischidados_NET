using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;

public partial class forum : BasePage
{
    public User u { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        u = SessionMandatory(false, "Forum");
        LoadTable();
    }

    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        switch (ea.CommandName)
        {
            //case "linkGotoThread":
            //    int i_last_message_id = BllControllerWeb.LoadLastMessageId(int.Parse(Session["i_user_id"].ToString()));
            //    Response.Redirect("~/Core/messages/messages.aspx?id=" + i_last_message_id + "&msg=received");
            //    break;
            //case "goToMessage":
            //    int i_last_message_id = BllControllerWeb.LoadLastMessageId(int.Parse(Session["i_user_id"].ToString()));
            //    Response.Redirect("~/Core/messages/messages.aspx?id=" + i_last_message_id + "&msg=received");
            //    break;
            //default:
            //    break;
        }

    }

    protected void LoadTable()
    {
        rep.DataSource = BllControllerWeb.S_Forum_Sections();
        rep.DataBind();
        if (rep.Items.Count > 0)
        {
            foreach (RepeaterItem rep in rep.Items)
            {
                //do something
            }
        }
    }

    protected void Repeater_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "selectSkillsPerNature")
        {
            //HiddenField hidI_nature_id = (HiddenField)e.Item.FindControl("hidI_nature_id");

            //if (hidI_nature_id != null)
            //    LoadTable(2, int.Parse(hidI_nature_id.Value));

        }
    }



}