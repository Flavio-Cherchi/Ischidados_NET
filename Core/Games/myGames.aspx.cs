using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;
public partial class myGames : BasePage
{
    public User u { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        u = SessionMandatory(true, "Le mie partite");
        divNewGame.Visible = u.isOnline ? true : false;

        if (!IsPostBack)
        {
            LoadTable();
        }
    }

    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        switch (ea.CommandName)
        {
            case "newGame":
                NewGame();
                break;
            case "removePlayer":
                //btnNewGame.Text = ea.CommandArgument.ToString();
                RemovePlayer(int.Parse(hidGameUnsub.Value));
                BllControllerWeb.SendMailUnsubscribe(u.t_username, int.Parse(hidGameUnsub.Value));
                LoadTable();
                break;

        }
    }

    protected void LoadTable()
    {
        Game g = new Game();
        int gameAsAdmin = 0;
        int gameAsPlayer = 0;
        g.i_master_id = u.i_user_id;

        //ADMIN
        GvAdmin.DataSource = BllControllerWeb.S_Games(g);
        GvAdmin.DataBind();
        if (GvAdmin.Rows.Count > 0)
        {
            UserInGame userInGame = new UserInGame();
            foreach (GridViewRow row in GvAdmin.Rows)
            {

                Button btnManageGame = (Button)row.FindControl("btnManageGame");

                int i_game_id = int.Parse(btnManageGame.CommandArgument.ToString());

               userInGame = BllControllerWeb.S_IsInGame(i_game_id, u.i_user_id);

                btnManageGame.Visible = userInGame.isAdmin;

                if (userInGame.isAdmin)
                    gameAsAdmin++;
            }

            GvAdmin.UseAccessibleHeader = true;
            GvAdmin.HeaderRow.TableSection = TableRowSection.TableHeader;
        } 

        //Player
        g.i_not_master_id = u.i_user_id;
        g.i_master_id = 0;
        
        GvPlayer.DataSource = BllControllerWeb.S_Games(g);
        GvPlayer.DataBind();
        if (GvPlayer.Rows.Count > 0)
        {
            UserInGame userInGame = new UserInGame();
            foreach (GridViewRow row in GvPlayer.Rows)
            {

                Button btnObserve = (Button)row.FindControl("btnObserve");
                Control btnRemovePlayer = row.FindControl("btnRemovePlayer");

                int i_game_id = int.Parse(btnObserve.CommandArgument.ToString());

                userInGame = BllControllerWeb.S_IsInGame(i_game_id, u.i_user_id);
                btnRemovePlayer.Visible = userInGame.isPlayer;

                if (userInGame.isPlayer)
                    gameAsPlayer++;
            }

            GvPlayer.UseAccessibleHeader = true;
            GvPlayer.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        divAsAdmin.Visible = (gameAsAdmin != 0) ? true : false;
        divAsPlayer.Visible = (gameAsPlayer != 0) ? true : false;

        if(gameAsAdmin == 0 && gameAsPlayer == 0)
            Response.Redirect("~/Default.aspx");

    }

    protected void GVAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
           case "manageGame":
                Response.Redirect("~/Core/Games/game.aspx?id=" + int.Parse(e.CommandArgument.ToString()));
                break;
            default:
                break;
        }
    }

    protected void GVPlayer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "observe":
                Response.Redirect("~/Core/Games/game.aspx?id=" + int.Parse(e.CommandArgument.ToString()));
                break;
            default:
                break;
        }
    }

    protected void NewGame()
    {
        Response.Redirect("~/Core/Games/gameNew.aspx");
    }

    protected void ManageGame(int i_image_id)
    {
        
    }

    protected void RemovePlayer(int i_game_id)
    {
        BllControllerWeb.D_GameUser(i_game_id, u.i_user_id);
    }

}