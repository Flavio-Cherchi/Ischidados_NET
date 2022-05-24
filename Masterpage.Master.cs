using Ischidados.App_Code.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ischidados
{
    public partial class Masterpage : System.Web.UI.MasterPage
    {
        public int i_user_id { get; set; }
        public int i_role_id { get; set; }

        ControllerWeb _BllControllerWeb;
        ControllerWeb BllControllerWeb
        {
            get
            {
                if (_BllControllerWeb == null)
                {
                    _BllControllerWeb = new ControllerWeb();
                }
                return _BllControllerWeb;
            }
            set
            {
                _BllControllerWeb = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lbltitle.Text = (Session["titlePage"] != null) ? Session["titlePage"].ToString() : "Ischidados";

            switch (Session["titlePage"].ToString())
            {
                case "Ischidados GdR - I Risvegliati":
                    linkHome.Attributes["class"] += " active";
                    break;
                case "Admin panel":
                    linkAdmin.Attributes["class"] += " active";
                    break;
                case "Forum":
                    linkForum.Attributes["class"] += " active";
                    break;
                case "Le mie partite":
                    linkMyGames.Attributes["class"] += " active";
                    break;
                case "Regolamento":
                    linkRegulation.Attributes["class"] += " active";
                    break;
                case "Cos'è Ischidados GdR?":
                    linkAbout.Attributes["class"] += " active";
                    break;
                case "Contatti":
                    linkContacts.Attributes["class"] += " active";
                    break;
                default:
                    break;
            }


            i_user_id = (Session["i_user_id"] != null) ? int.Parse(Session["i_user_id"].ToString()) : 0;

            if (i_user_id != 0)
            {
                i_role_id = int.Parse(Session["i_role_id"].ToString());
            } else 
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["identityToken"];
                if (cookie != null)
                {
                    if(cookie.Value != "noIdentity")
                    {
                        i_user_id = BllControllerWeb.S_UserByidentityToken(cookie.Value);
                        SessionRegister(BllControllerWeb.S_UserById(i_user_id));
                    }
                }
            }
            NavbarVisibility(i_user_id);
            //String NomePagina = System.IO.Path.GetFileName(HttpContext.Current.Request.FilePath);
        }

        protected void ProcessCommand(object sender, CommandEventArgs ea)
        {
            switch (ea.CommandName)
            {
                case "toLogin":
                    Response.Redirect("~/Core/Users/login.aspx");
                    break;
                case "toRegister":
                    Response.Redirect("~/Core/Users/register.aspx");
                    break;
                case "toProfile":
                    Response.Redirect("~/Core/Users/profile.aspx"); 
                    break;
                case "message":
                    int i_last_message_id = BllControllerWeb.LoadLastMessageId(int.Parse(Session["i_user_id"].ToString()));
                    Response.Redirect("~/Core/messages/messages.aspx?id=" + i_last_message_id + "&msg=received");
                    break;
                case "logOut":
                    Session.Clear();
                    BllControllerWeb.StoreInCookie("identityToken", "noIdentity", DateTime.Now.AddDays(30), false, false);
                    Response.Redirect("~/Default.aspx");
                    break;
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
        }

        protected void NavbarVisibility(int i_user_id)
        {
            if (i_user_id == 0)
            {
                //linkUser.Visible = false;
                linkAdmin.Visible = false;

                btnLogin.Visible = true;
                btnRegister.Visible = true;
                btnLogout.Visible = false;
                //divisor1.Visible = true;
                divProfile.Visible = false;
                divMessageResponsive.Visible = false;
            }
            else
            {
                //linkUser.Visible = true;
                if (i_role_id == 3)
                    linkAdmin.Visible = false;

                btnRegister.Visible = false;
                btnLogin.Visible = false;
                btnLogout.Visible = true;
                //divisor1.Visible = false;
                divProfile.Visible = true;

                divMessageResponsive.Visible = true;

                if (BllControllerWeb.S_Messages_Check_Unread(int.Parse(Session["i_user_id"].ToString())) > 0)
                {
                    Attributes.Add("class", "animate__flash");

                    imgMessage.Attributes.Add("class", "fa fa-envelope-o animate__animated animate__flash newMessage");
                    imgMessageResponsive.Attributes.Add("class", "fa fa-envelope-o animate__animated animate__flash newMessage");
                } else
                {
                    imgMessage.Attributes.Add("class", "fa fa-envelope-o");
                    imgMessageResponsive.Attributes.Add("class", "fa fa-envelope-o");
                }

                nameUser.Text = Session["t_username"].ToString();
                imgUser.ImageUrl = Session["t_img"].ToString().Trim();
                imgUserResponsive.ImageUrl = Session["t_img"].ToString().Trim();
            }

            linkMyGames.Visible = (BllControllerWeb.S_GamesByUser(i_user_id, true).Count > 0 || BllControllerWeb.S_GamesByUser(i_user_id, false).Count > 0) ? true : false;

        }
    }
}