using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;
using System.Web.UI.HtmlControls;

public partial class usersList : BasePage
{
    public User u { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        u = SessionMandatory(false, "Giocatori");

        if (!IsPostBack)
        {
            LoadTable();
        }
    }

    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
    }

    protected void LoadTable()
    {
        Gv.DataSource = BllControllerWeb.S_Users(u.i_role_id);
        Gv.DataBind();
        if (Gv.Rows.Count > 0)
        {
            foreach (GridViewRow row in Gv.Rows)
            {
                Button btnManageUser = (Button)row.FindControl("btnManageUser");
                Button btnDeactivatePlayer = (Button)row.FindControl("btnDeactivatePlayer");
 
                btnManageUser.Visible = (u.i_role_id == 1 || u.i_role_id == 2) ? true : false;
                btnDeactivatePlayer.Visible = (u.i_role_id == 1 || u.i_role_id == 2) ? true : false;
            }

            Gv.UseAccessibleHeader = true;
            Gv.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "message":
                //todo
                if (u.isOnline)
                {
                    Response.Redirect("~/Core/messages/messages.aspx?id=0&msg=new&to=" + e.CommandArgument.ToString());
                }
                else
                {
                    Response.Redirect("~/Core/Users/login.aspx");
                }

                break;
            case "manageUser":
                //todo
                Response.Redirect("~/default.aspx");
                break;
            case "profile":
                if (u.isOnline)
                {
                    Response.Redirect("~/core/users/profile.aspx?id=" + e.CommandArgument.ToString());
                }
                else
                {
                    Response.Redirect("~/Core/Users/login.aspx");
                }
                break;
            case "deactivateUser":
                DeactivateUser(int.Parse(e.CommandArgument.ToString()));
                LoadTable();
                break;
            default:
                break;
        }
    }

    //protected void NewUser()
    //{
    //    //todo
    //    Response.Redirect("~/Core/Games/gameNew.aspx");
    //}

    protected void DeactivateUser(int i_user_id)
    {
        //todo
        //BllControllerWeb.U_DeactivateUser(i_user_id);
    }

    protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    HtmlImage lastHope = (HtmlImage)e.Row.FindControl("lastHope");
        //    lastHope.Src = "https://www.ischidados.it/" + lastHope.Src;
        //}


        //Gv.Columns[4].Visible = u.isOnline;
        #region Comment
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Button btnAddPlayer = (Button)e.Row.FindControl("btnAddPlayer");
        //    btnAddPlayer.CommandArgument

        //    }

        //    if (!BllControllerWeb.isRuolo(9,int.Parse(Session["i_rj_id"].ToString())))
        //    {                
        //        Button BtnCessazione = (Button)e.Row.FindControl("BtnCessazione");
        //        BtnCessazione.Visible = false;

        //    }

        //    if (!BllControllerWeb.isRuolo(9, int.Parse(Session["i_rj_id"].ToString())) && !BllControllerWeb.isRuolo(40, int.Parse(Session["i_rj_id"].ToString())))
        //    {
        //        Button BtnDotazioni = (Button)e.Row.FindControl("BtnDotazioni");
        //        BtnDotazioni.Visible = false;


        //    }

        //    if (BllControllerWeb.isRuolo(89, int.Parse(Session["i_rj_id"].ToString())))
        //    {
        //        Button BtnAbilRichieste = (Button)e.Row.FindControl("btnAbilRichieste");
        //        BtnAbilRichieste.Visible = true;

        //    }

        //}
        #endregion
    }

}