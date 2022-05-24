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
using System.Text.RegularExpressions;

public partial class register : BasePage
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
        Session["titlePage"] = "Registrati";
    }

    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        switch (ea.CommandName)
        {
            case "register":
                Register();
                break;
        }

    }

    protected void Register()
    {
        User ut = new User();
        ut.t_username = t_username.Text;
        ut.t_email = t_email.Text;
        ut.t_password = t_password.Text;
        ut.t_password_confirmation = t_conf_password.Text;
        ut.i_image_id = 388;
        ut.i_modified_by = 0;
        ut.b_rememberMe = b_rememberMe.Checked;
        Guid registrationToken = Guid.NewGuid();
        ut.g_identityToken = registrationToken.ToString();

        if (CheckError(ut))
        {
            if (BllControllerWeb.I_User(ut) > 0)
            {
                BllControllerWeb.SendMailRegistration(ut, true);
                Response.Redirect("~/Core/Users/login.aspx?registration=pending");
            } else
            {
                lblErrorAlready.Text = "Errore generico, contattare amministrazione!";
                lblErrorAlready.Visible = true;
            }

        } 
    }

    protected bool CheckError(User ut)
    {
        bool res = true;

        if (string.IsNullOrEmpty(ut.t_username) || ut.t_username.Length < 3)
        {
            lblErrorUsername.Text = "Inserire un nome valido di almeno tre lettere!";
            lblErrorUsername.Visible = true;
            res = false;
        } else
        {
            lblErrorUsername.Visible = false;
        }

        if (string.IsNullOrEmpty(ut.t_email))
        {

            lblErrorEmail.Text = "Inserire un indirizzo e-mail valido!";
            lblErrorEmail.Visible = true;
            res = false;
        }
        else
        {
            try
            {
                var checkMail = new System.Net.Mail.MailAddress(ut.t_email);
                lblErrorEmail.Visible = false;
            }
            catch
            {
                lblErrorEmail.Text = "Inserire un indirizzo e-mail valido!";
                lblErrorEmail.Visible = true;
                res = false;
            }
        }

        if (!string.IsNullOrEmpty(ut.t_password))
        {
            string pattern = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#._?!@$%^&*-]).{8,50}$";
            Regex rg = new Regex(pattern);
            bool isCorrect = rg.IsMatch(ut.t_password);

            if (!isCorrect)
            {
                lblErrorPassword.Text = "Inserire una password valida lunga tra gli 8 e i 50 caratteri, con almeno una maiuscola, almeno una minuscola, un numero e un carattere speciale.";
                lblErrorPassword.Visible = true;
                res = false;
            } else
            {
                lblErrorPassword.Visible = false;
            }
        }
        else
        {
            lblErrorPassword.Text = "Inserire una password valida lunga tra gli 8 e i 50 caratteri, con almeno una maiuscola, almeno una minuscola, un numero e un carattere speciale.";
            lblErrorPassword.Visible = true;
            res = false;
        }

        if (ut.t_password != ut.t_password_confirmation)
        {
            lblErrorPasswordConfirm.Text = "Conferma password non riuscita!";
            lblErrorPasswordConfirm.Visible = true;
            res = false;
        }
        else
        {
            lblErrorPasswordConfirm.Visible = false;
        }

        if (res)
        {
             int checkUser = BllControllerWeb.S_UserUsername(ut.t_username).i_user_id;

            if (checkUser != 0)
            {
                lblErrorAlready.Text = "Attenzione! Username già in uso!";
                lblErrorAlready.Visible = true;
                res = false;
            }
            else
            {
                lblErrorAlready.Visible = false;
            }
        }

        if (res)
        {
            int checkMail = BllControllerWeb.S_UserByMail(ut.t_email).i_user_id;

            if (checkMail != 0)
            {
                lblErrorAlready.Text = "Attenzione! E-mail già in uso!";
                lblErrorAlready.Visible = true;
                res = false;
            }
            else
            {
                lblErrorAlready.Visible = false;
            }
        }

        return res;
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
        Session["isOnline"] = "true";
    }
  

}