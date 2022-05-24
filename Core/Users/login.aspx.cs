using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using Ischidados;
using Ischidados.App_Code.Bll;

public partial class login : BasePage
{
    ControllerWeb _ControllerWeb;
    ControllerWeb ControllerWeb
    {
        get
        {
            if (_ControllerWeb == null)
            {
                _ControllerWeb = new ControllerWeb();
            }
            return _ControllerWeb;
        }
        set
        {
            _ControllerWeb = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["titlePage"] = "Login";
        FirstTime();
    }

    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        switch (ea.CommandName)
        {
            case "temporary":
                switch (ea.CommandArgument)
                {
                    case "1":
                        t_username.Text = "admin";
                        t_password.Text = "admin";
                        break;
                    case "2":
                        t_username.Text = "asd";
                        t_password.Text = "asd";
                        break;
                    case "3":
                        t_username.Text = "thanatos";
                        t_password.Text = "asd";
                        break;
                    case "4":
                        t_username.Text = "Terenzio";
                        t_password.Text = "asd";
                        break;
                    default:
                        break;
                }
                Login();
                break;
            case "login":
                Login();
                break;
        }

    }

    protected void Login()
    {
        lblSuccess.Visible = false;
        lblNotFound.Visible = false;
        lblNotActive.Visible = false;

        User ut = new User();
        ut.t_username = t_username.Text;
        ut.t_password = t_password.Text;
        
        if(!string.IsNullOrEmpty(ut.t_username) && !string.IsNullOrEmpty(ut.t_password))
        {
            ut = BllControllerWeb.S_User_One(ut);

            if (b_rememberMe.Checked != ut.b_rememberMe)
            {
                BllControllerWeb.U_UserRememberBe(ut.i_user_id, b_rememberMe.Checked);
                ut.b_rememberMe = b_rememberMe.Checked;
            }

            if (b_rememberMe.Checked)
            {
                //BllControllerWeb.StoreInCookie("identityToken", ut.g_identityToken);
                BllControllerWeb.StoreInCookie("identityToken", ut.g_identityToken, DateTime.Now.AddDays(30), false, false);
            }
            else
            {
                BllControllerWeb.StoreInCookie("identityToken", "noIdentity", DateTime.Now.AddDays(30), false, false);
            }
        }

        if (ut.i_user_id != 0)
        {
            if (ut.isActive)
            {
                ut.t_modifiedOn = BllControllerWeb.U_UserLastLogin(ut.i_user_id);
                SessionRegister(ut);

                if(Session["toRedirect"] != null)
                {
                    Response.Redirect(Session["toRedirect"].ToString());
                } else
                {
                    Response.Redirect("~/Default.aspx");
                }
                
            } else
            {
                lblNotActive.Visible = true;
                lblNotActive.Text = "Attenzione! L'utenza non è ancora stata attivata. Controlla la tua posta e rispondi al link di registrazione, oppure contatta l'amministrazione: <a href=\"mailto: tua @email.com\">info@ischidados.it</a>";
            }

        } else
        {
            lblNotFound.Visible = true;
        }
    }

    public void FirstTime()
    {
        if (Request.QueryString["registration"] != null)
        {
            if (Request.QueryString["registration"].ToString() == "pending")
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Account creato con successo! Riceverai una mail all'indirizzo usato per ultimare registrazione!";
            } else
            {
                try
                {
                    string registrationToken = Request.QueryString["registration"].ToString();
                    BllControllerWeb.U_UserIsActive(registrationToken);
                    int i_user_id = BllControllerWeb.S_UserByidentityToken(registrationToken);
                    
                    User ut = new User();
                    ut = BllControllerWeb.S_UserById(i_user_id);

                    if (ut.i_user_id != 0)
                    {
                        BllControllerWeb.SendMailRegistration(ut, false);
                        ut.t_modifiedOn = BllControllerWeb.U_UserLastLogin(ut.i_user_id);
                        SessionRegister(ut);
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        lblNotActive.Visible = true;
                        lblNotActive.Text = "Si è verificato un problema durante la registrazione dell'account, si prega di contattare l'amministrazione: <a href=\"mailto: tua @email.com\">info@ischidados.it</a>";
                    }
                }
                catch (Exception e ){ throw e; }
            } 
        }
    }

    protected void SessionRegister(User registeredUser)
    {
        string username = char.ToUpper(registeredUser.t_username[0]) + registeredUser.t_username.Substring(1);
        Session["i_user_id"] = registeredUser.i_user_id;
        Session["i_role_id"] = registeredUser.i_role_id;
        Session["t_username"] = username;
        Session["t_email"] = registeredUser.t_email;
        Session["i_image_id"] = registeredUser.i_image_id;
        Session["t_img"] = registeredUser.t_img;
        Session["b_rememberMe"] = registeredUser.b_rememberMe;
        Session["g_registrationToken"] = registeredUser.g_identityToken;
        Session["isOnline"] = "true";
        Session["t_createdOn"] = registeredUser.t_createdOn;
        Session["t_modifiedOn"] = registeredUser.t_modifiedOn;
    }
  

}