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

        public User SessionMandatory(bool isMandatory)
        {
            User u = new User();
            bool isReal = false;

            if (Session["i_user_id"] != null)
            {
                u.i_user_id = int.Parse(Session["i_user_id"].ToString());
                u.i_role_id = int.Parse(Session["i_role_id"].ToString());
                u.t_username = Session["t_username"].ToString();
                u.t_email = Session["t_email"].ToString();
                u.t_img = Session["t_img"].ToString();
                u.isOnline = bool.Parse(Session["isOnline"].ToString());
                isReal = BllControllerWeb.CheckUser(u);
            }

            if (isMandatory)
            {
                if (!isReal)
                    Response.Redirect("~/Default.aspx");
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