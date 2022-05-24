using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ischidados.App_Code.Bll
{
    public class BasePage : System.Web.UI.Page
    {
        public ControllerWeb _BllControllerWeb;
        public ControllerWeb BllControllerWeb
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

        public User SessionMandatory(bool isMandatory, string titlePage)
        {
            User u = new User();
            bool isReal = false;
            Session["titlePage"] = titlePage;

            if (Session["i_user_id"] != null)
            {
                LogUser logUser = new LogUser();
                logUser.i_user_id = int.Parse(Session["i_user_id"].ToString());
                logUser.t_page = titlePage.Replace("'", "’");
                BllControllerWeb.I_LogUser(logUser);

                u.i_user_id = int.Parse(Session["i_user_id"].ToString());
                u.i_role_id = int.Parse(Session["i_role_id"].ToString());
                u.t_username = Session["t_username"].ToString();
                u.t_email = Session["t_email"].ToString();
                u.i_image_id = int.Parse(Session["i_image_id"].ToString());
                u.t_img = Session["t_img"].ToString();
                u.isOnline = bool.Parse(Session["isOnline"].ToString());
                u.g_identityToken = Session["g_registrationToken"].ToString();
                u.t_createdOn = Session["t_createdOn"].ToString();
                string partialDate = Session["t_modifiedOn"].ToString();
                u.t_modifiedOn = partialDate.Substring(0, 10); 

                isReal = BllControllerWeb.CheckUser(u);
            }

            if (isMandatory)
            {
                if (!isReal)
                {
                    if (Session["toRedirect"] == null)
                            Session["toRedirect"] = Page.Request.Url.ToString();
                    Response.Redirect("~/Core/Users/login.aspx");
                }
            }
            return u;
        }

        public void AdminOnly(User u)
        {
            if(u.i_role_id != 2 && u.i_role_id != 1)
                Response.Redirect("~/error.aspx?id=magicWord");
        }

    }
}