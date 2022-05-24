using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;
public partial class usersLog : BasePage
{
    public User u { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        u = SessionMandatory(true, "Log Utenti");
        AdminOnly(u);

        if (!IsPostBack)
        {
            BllControllerWeb.DD_Users(ref ddUsers);
            LoadTable(0);
        }
    }

    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        switch (ea.CommandName)
        {
            case "LoadTable":
                LoadTable(int.Parse(ddUsers.SelectedValue));
                break;
        }
    }

    protected void LoadTable(int i_user_id) 
    {
        Gv.DataSource = BllControllerWeb.S_LogUsers(i_user_id);

        Gv.DataBind();
        if (Gv.Rows.Count > 0)
        {
            Gv.UseAccessibleHeader = true;
            Gv.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        #region comment
        //if (ListView1.Items.Count > 0)
        //{
        //UserInGame userInGame = new UserInGame();
        //foreach (ListViewDataItem row in ListView1.Items)
        //{

        //    Button btnAddPlayer = (Button)row.FindControl("btnAddPlayer");
        //    Button btnManagePlayer = (Button)row.FindControl("btnManagePlayer");
        //    Button btnRemovePlayer = (Button)row.FindControl("btnRemovePlayer");

        //    int i_game_id = int.Parse(btnManagePlayer.CommandArgument.ToString());

        //    userInGame = BllControllerWeb.S_IsInGame(i_game_id, u.i_user_id);

        //    btnAddPlayer.Visible = (!userInGame.isAdmin && !userInGame.isPlayer) ? true : false;
        //    btnManagePlayer.Visible = userInGame.isAdmin;
        //    btnRemovePlayer.Visible = userInGame.isPlayer;

        //}
        //}
        #endregion
    }

    protected void Gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gv.PageIndex = e.NewPageIndex;
        Gv.DataBind();

        //bindGrid(); 
        //SubmitAppraisalGrid.PageIndex = e.NewPageIndex;
        //SubmitAppraisalGrid.DataBind();
    }

}