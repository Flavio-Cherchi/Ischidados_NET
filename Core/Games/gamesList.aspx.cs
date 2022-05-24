using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;
public partial class gamesList : BasePage
{
    public User u { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        u = SessionMandatory(false, "Partite in corso");
        divNewGame.Visible = u.isOnline ? true : false;

        if (u.isOnline) 
        {
            linkMyGames2.Visible = (BllControllerWeb.S_GamesByUser(u.i_user_id, true).Count > 0 || BllControllerWeb.S_GamesByUser(u.i_user_id, false).Count > 0) ? true : false;
        } else
        {
            linkMyGames2.Visible = false;
        }

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
            case "addPlayer":
                AddPlayer(int.Parse(hidGameAdd.Value), true);
                BllControllerWeb.SendMailSubscribe(u.t_username, int.Parse(hidGameAdd.Value), true);
                Response.Redirect("~/Core/Games/game.aspx?id=" + int.Parse(hidGameAdd.Value));
                break;
            case "addPlayerRequest":
                AddPlayer(int.Parse(hidGameAdd.Value), false);
                BllControllerWeb.SendMailSubscribe(u.t_username, int.Parse(hidGameAdd.Value), false);
                LoadTable();
                //mandare mail a master
                //avvertire giocatore in forum e tramite mail
                break;
            case "removePlayer":
                //btnNewGame.Text = ea.CommandArgument.ToString();
                RemovePlayer(int.Parse(hidGameUnsub.Value));
                BllControllerWeb.SendMailUnsubscribe(u.t_username, int.Parse(hidGameAdd.Value));
                LoadTable();
                break;
            case "deleteGame":
                //btnNewGame.Text = ea.CommandArgument.ToString();
                DeleteGame(int.Parse(hidGameDelete.Value));
                LoadTable();
                break;
        }
    }

    protected void LoadTable()
    {
        Game g = new Game();
        rep.DataSource = BllControllerWeb.S_Games(g);
        rep.DataBind();
        if (rep.Items.Count > 0)
        {
            UserInGame userInGame = new UserInGame();
            foreach (RepeaterItem rep in rep.Items)
            {
                Control btnAddPlayer = rep.FindControl("btnAddPlayer");
                Control btnAddPlayerRequest = rep.FindControl("btnAddPlayerRequest");
                Button btnManageGame = (Button)rep.FindControl("btnManageGame");
                Button btnRequest = (Button)rep.FindControl("btnRequest");
                Control btnRemovePlayer = rep.FindControl("btnRemovePlayer");
                Control btnDeleteGame = rep.FindControl("btnDeleteGame");
                Button btnType = (Button)rep.FindControl("btnType");

                int i_game_id = int.Parse(btnManageGame.CommandArgument.ToString());
                string type = btnType.CommandArgument;

                userInGame = BllControllerWeb.S_IsInGame(i_game_id, u.i_user_id);
                btnManageGame.Visible = userInGame.isAdmin;
                btnRemovePlayer.Visible = userInGame.isPlayer;
                btnDeleteGame.Visible = (u.i_role_id == 2 || u.i_role_id == 1) ? true : false;

                switch (type)
                {
                    case "Privata":
                        btnAddPlayer.Visible = false;
                        btnAddPlayerRequest.Visible = (!userInGame.isAdmin && !userInGame.isPlayer && !userInGame.isPlayerPending) ? true : false;
                        lblAddPlayerRequest.Text = "Verrà inviata una notifica al master e sarai avvisato se accetterà la tua partecipazione.";
                        btnAddPlayerRequest2.Text = "Fai richiesta";
                        break;
                    case "Solitaria":
                        btnAddPlayer.Visible = false;
                        break;
                    case "Pubblica":
                        btnAddPlayer.Visible = (!userInGame.isAdmin && !userInGame.isPlayer && !userInGame.isPlayerPending) ? true : false;
                        btnAddPlayerRequest.Visible = false;
                        lblAddPlayer.Text = "Entrerai subito come giocatore.";
                        btnAddPlayer2.Text = "Partecipa";
                        break;
                    default:
                        break;
                }

                if (!u.isOnline)
                    btnAddPlayer.Visible = false;

                if (userInGame.isPlayerPending)
                    btnRequest.Visible = true;
            }

        } else
        {
            Response.Redirect("~/Default.aspx");
        }


    }

    protected void Rep_RowCommand(object sender, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "manageGame":
                ManageGame(int.Parse(e.CommandArgument.ToString()));
                break;
            case "Observe":
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

    protected void ManageGame(int i_game_id)
    {
        Response.Redirect("~/Core/Games/game.aspx?id=" + i_game_id);
    }

    protected void AddPlayer(int i_game_id, bool isAccepted)
    {
        BllControllerWeb.I_GameUser(i_game_id, u.i_user_id, isAccepted);
    }

    protected void RemovePlayer(int i_game_id)
    {
        BllControllerWeb.D_GameUser(i_game_id, u.i_user_id);
    }

    protected void DeleteGame(int i_game_id)
    {
        BllControllerWeb.D_Game(i_game_id);
    }

}