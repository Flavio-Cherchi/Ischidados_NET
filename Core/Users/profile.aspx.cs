using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;
public partial class profile : BasePage
{
    public User u { get; set; }
    public User uToModify { get; set; }
    public bool isOwnPage { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        u = SessionMandatory(true, "Profilo");
        isOwnPage = true;

        if (Request.QueryString["id"] != null)
        {
            uToModify = BllControllerWeb.S_UserById(int.Parse(Request.QueryString["id"].ToString()));
            if(uToModify != null)
            {
                if (u.i_user_id != uToModify.i_user_id && u.i_role_id == 3)
                {
                    isOwnPage = false;
                } else
                {
                    uToModify = u;
                }
            }
        } else
        {
            uToModify = u;
        }

        if (!IsPostBack)
        {
            LoadProfile();
        }
    }

    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        switch (ea.CommandName)
        {
            case "changeImg":
                    UploadImg();
                break;
            case "noImg":
                DefaultImg(1);
                break;
              case "defaultImg":
                DefaultImg(2);
                break;
            case "randomImg":
                DefaultImg(3);
                break;
            case "toMyMessages":
                int i_last_message_id = BllControllerWeb.LoadLastMessageId(uToModify.i_user_id);
                Response.Redirect("~/Core/messages/messages.aspx?id=" + i_last_message_id + "&msg=received");
                break;
            case "sendAMessage":
                Response.Redirect("~/Core/messages/messages.aspx?id=0&msg=new&to=" + uToModify.i_user_id);
                break;
        }
    }

    protected void LoadProfile()
    {
        imgProfile.ImageUrl = uToModify.t_img.Trim();
        ltlUsername.Text = uToModify.t_username;
        ltlEmail.Text = "Mail: <a href='mailto: " + uToModify.t_email + "'>" + uToModify.t_email  + "</a>";
        ltlDate.Text = "Attivo dal: " + uToModify.t_createdOn;
        ltlDateMod.Text = "Ultima visita: " + uToModify.t_modifiedOn;

        if (!isOwnPage)
        {
            divChangePsw.Visible = false;
            btnModifyAvatar.Visible = false;
            btnMyProfile.Visible = false;
        } else
        {
            btnNotMyProfile.Visible = false;
        }
            
    }

    protected void DefaultImg(int type)
    {
        switch (type)
        {
            case 1:
                Session["t_img"] = BllControllerWeb.U_UserImg(388, uToModify.i_user_id);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                break;
            case 2:
                //todo
                //Session["t_img"] = t_url;
                //Page.Response.Redirect(Page.Request.Url.ToString(), true);
                break;
            case 3:
                int randomImg = BllControllerWeb.S_RandomImage("profiles");
                Session["t_img"] = BllControllerWeb.U_UserImg(randomImg, uToModify.i_user_id);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                break;
            default:
                break;
        }
    }
    protected void UploadImg()
    {
        if (FileUpload1.HasFile)
        {
            string t_url = "";
            try
            {
                string filename = FileUpload1.FileName;

                string root = Server.MapPath("~");
                string parent = Path.GetDirectoryName(root);

                FileUpload1.SaveAs(root + "\\public\\img\\profiles\\" + filename);
                t_url = "/public/img/profiles/" + filename;
            }
            catch { }

            try
            {
                BllControllerWeb.I_UserImg(t_url, uToModify.i_user_id, uToModify.t_username);
                Session["t_img"] = t_url;
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.Visible = true;
            }

        }
        else
        {
            lblmsg.Text = "File Non Selezionato!";
            lblmsg.Visible = true;
        }

    }
}