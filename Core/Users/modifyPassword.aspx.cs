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

public partial class modifyPassword : BasePage
{
    public User u { get; set; }

    public string identityToken { get; set; }

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
        u = SessionMandatory(false, "Password dimenticata");

        if (Request.QueryString["registration"] != null)
        {
            divEmail.Visible = true;
            divPassword.Visible = false;
        }
        else
        {
            if (u.isOnline)
            {
                identityToken = u.g_identityToken;
                divEmail.Visible = false;
                divPassword.Visible = true;
            } 
            else
            {
                try
                {
                    string newIdentityToken = Request.QueryString["passwordRecovery"].ToString();

                    int i_user_id = BllControllerWeb.S_UserByidentityToken(newIdentityToken);

                    User ut = new User();
                    ut = BllControllerWeb.S_UserById(i_user_id);

                    if (ut.i_user_id != 0)
                    {
                        divEmail.Visible = false;
                        divPassword.Visible = true;
                        identityToken = newIdentityToken;
                    }
                }
                catch { }
            }
          
        }
    }

    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        switch (ea.CommandName)
        {
            case "checkMail":
                CheckMail();
                break;
            case "changePassword":
                ChangePassword();
                break;
        }

    }

    protected void CheckMail()
    {
        divEmail.Visible = true;
        divPassword.Visible = false;
        lblSuccess.Visible = false;
        lblError.Visible = false;
        lblErrorEmail.Visible = false;

        User ut = new User();
        ut.t_email = t_email.Text;
        Guid registrationToken = Guid.NewGuid();
        ut.g_identityToken = registrationToken.ToString();

        if (CheckError(ut, true))
        {
            
            ut = BllControllerWeb.S_UserByMail(ut.t_email);
            ut.g_identityToken = registrationToken.ToString();
            BllControllerWeb.U_UserIdentityToken(ut);

            if (ut.i_user_id != 0)
            {
                BllControllerWeb.SendMailRecoveryPassword(ut.t_email, registrationToken.ToString(), ut.t_username);
            }

            lblSuccess.Visible = true;
            lblSuccess.Text = "Una e-mail è stata inviata all'indirizzo segnalato, se presente nei nostri database. Controlla la tua posta!";

        }
    }

    protected void ChangePassword()
    {
        divEmail.Visible = false;
        divPassword.Visible = true;
        lblSuccess.Visible = false;
        lblError.Visible = false;
        lblErrorEmail.Visible = false;

        User ut = new User();
        ut.t_password = t_password.Text;
        ut.t_password_confirmation = t_conf_password.Text;

        if (CheckError(ut, false))
        {
            ut.i_user_id = BllControllerWeb.S_UserByidentityToken(identityToken);
            bool isChanged = BllControllerWeb.U_UserPassword(ut);

            if (isChanged)
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = (!u.isOnline) ? "Password modificata con successo! Torna alla pagina di login per l'autenticazione" : "Password modificata con successo!";
            } else
            {
                lblError.Visible = true;
                lblError.Text = "Si è verificato un problema durante la modifica della password, si prega di contattare l'amministrazione: <a href=\"mailto: tua @email.com\">info@ischidados.it</a>";
            }

        }
    }

    protected bool CheckError(User ut, bool firstStep)
    {
        bool res = true;

        if (firstStep)
        {
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
        } else
        {
            if (!string.IsNullOrEmpty(ut.t_password))
            {
                string pattern = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,50}$";
                Regex rg = new Regex(pattern);
                bool isCorrect = rg.IsMatch(ut.t_password);

                if (!isCorrect)
                {
                    lblErrorPassword.Text = "Inserire una password valida lunga tra gli 8 e i 50 caratteri, con almeno una maiuscola, almeno una minuscola, un numero e un carattere speciale.";
                    lblErrorPassword.Visible = true;
                    res = false;
                }
                else
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