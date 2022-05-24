using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;
using System.Threading.Tasks;
using System.Collections.Generic;

public partial class game : BasePage
{
    public User u { get; set; }
    public Game g { get; set; }
    public List<Settlement> sList { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        //BllControllerWeb.LogError();

        u = SessionMandatory(false, "Pannello partita");

        LoadRowData();
        LoadCalendar();

        if (!IsPostBack)
        {
        }
    }

    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        switch (ea.CommandName)
        {
            case "newTurn":
                NewTurn();
                break;
            case "deleteGamePending":
                divConfirmDelete.Visible = true;
                break;
            case "deleteGameForgive":
                Response.Redirect(Request.Url.ToString(), true);
                break;
            case "deleteGameConfirm":
                DeleteGame();
                List<User>recipientList = BllControllerWeb.S_UsersByGame(int.Parse(Request.QueryString["id"].ToString()), true);

                foreach (User recipient in recipientList)
                {
                    BllControllerWeb.SendMailGameDeletedNotification(g.t_name, recipient.t_username, recipient.t_email);
                }

                Response.Redirect("~/Default.aspx");
                break;
            case "newSettlement":
                newSettlement(false);
                break;
            case "newSettlementRandom":
                newSettlement(true);
                break;
        }
    }

    protected void NewTurn()
    {
        try
        {
            g.i_turn_id = BllControllerWeb.I_Game_Turn(g.i_game_id);

            UpdateSettlements();
        }
        catch (Exception e) { throw e; }

        LoadRowData();
        LoadCalendar();
    }

    protected void UpdateSettlements()
    {
        foreach (Settlement s in sList)
        {
            s.settlementSpecsList[0].i_turn_id = g.i_turn_id;
            BllControllerWeb.U_settlement(s.settlementSpecsList[0], s.settlementDiplomacyList);
        }
    }

    protected void LoadRowData()
    {
        try
        {
            if(Request.QueryString["id"] != null)
            {
                g = BllControllerWeb.S_GameById(int.Parse(Request.QueryString["id"].ToString()));

                if (g.i_game_id == 0)
                    Response.Redirect("~/Default.aspx");

                if ((g.i_master_id != u.i_user_id) && u.i_role_id == 3)
                    divMaster.Visible = false;

                Session["titlePage"] = g.t_name;
                tName.Text = g.t_name;
                coverImg.ImageUrl = g.t_img;

                ImageFilter f = new ImageFilter();
                f.communities = true;
                repLogo.DataSource = BllControllerWeb.S_Images(f);
                repLogo.DataBind();

            } else
            {
                Response.Redirect("~/Default.aspx");
            }

        }
        catch { Response.Redirect("~/Default.aspx"); }

        LoadTables();
    }

    protected void LoadTables()
    {
        repPlayers.DataSource = BllControllerWeb.S_UsersByGame(int.Parse(Request.QueryString["id"].ToString()), true);
        repPlayers.DataBind();

        sList = BllControllerWeb.S_SettlementsByGame(g);

        repSettlements.DataSource = sList;
        repSettlements.DataBind();
    }

    protected void LoadCalendar()
    {
        int i_turn = g.i_turn;
        string month = "";
        int year = DateTime.Now.Year + 1;

        for (int i = 1; i <= g.i_turn; i++)
        {
            if(i_turn > 12)
            {
                i_turn = i_turn - 12;
                year++;
            } else
            {
                var CalendarGame = (CalendarGame)i_turn;
                month = CalendarGame.ToString();
                break;
            }
        }

        tCalendar.Text = "Turno " + g.i_turn + " - " + month + " " + year;
        tNature.Text = "Le comunità neutrali hanno un'indole " + g.t_intelligence;
    }

    protected void newSettlement(bool random)
    {
        bool error = CheckError();

        if (random)
            error = !random;

        if (!error)
        {
            Settlement s = new Settlement();
            s.settlementSpecsList = new SettlementSpecs[] {
                new SettlementSpecs {}
            };
            s.i_game_id = g.i_game_id;
            s.i_user_id = BllControllerWeb.S_Neutral_User();
            s.settlementSpecsList[0].i_turn_id = g.i_turn_id;

            if (random)
            {
                s.i_image_id = BllControllerWeb.S_RandomImage("communities");
                s.t_name = JustForFun(s.i_user_id);
                s.t_desc = "Questa è una comunità neutrale generata automaticamente";

            } else
            {
                s.i_image_id = int.Parse(hidI_image_id.Value);
                s.t_name = txtSettlementName.Text;
                s.t_desc = txtSettlementDesc.Text;
            }

        


            BllControllerWeb.I_settlement(s);
            Response.Redirect(Request.Url.ToString(), true);
        }
    }

    protected bool CheckError()
    {
        bool error = false;

        if (int.Parse(hidI_image_id.Value) == 0)
        {
            lblError.Text = "Scegliere un logo per la comunità!";
            error = true;
        }

        if (string.IsNullOrEmpty(txtSettlementName.Text))
        {
            lblError.Text = "Nome obbligatorio per la comunità!";
            error = true;
        }

        lblError.Visible = (error);

        return error;
    }

    protected void RepPlayers_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "toProfile")
        {
            HiddenField hidI_user_id = (HiddenField)e.Item.FindControl("hidI_user_id");
            Response.Redirect("~/core/users/profile.aspx?id=" + hidI_user_id.Value);
        }
    }

    protected string JustForFun(int i_user_id)
    {
        List<string> first = new List<string>();
        List<string> second = new List<string>();

        first.Add("I poeti ");
        first.Add("I morti ");
        first.Add("Gli allegri ");
        first.Add("Gli imbattuti ");
        first.Add("Gli stanchi ");
        first.Add("I traghettatori ");
        first.Add("I maledetti ");
        first.Add("I santi ");
        first.Add("Gli indimenticabili ");
        first.Add("I feroci ");

        second.Add("neri ");
        second.Add("camionisti ");
        second.Add("ridanciani ");
        second.Add("navigatori ");
        second.Add("esploratori ");
        second.Add("cannibali ");
        second.Add("veterani ");
        second.Add("errabondi ");
        second.Add("pompieri ");
        second.Add("poliziotti ");

        Random firstRes = new Random();
        int index = firstRes.Next(first.Count);
        string res = first[index];

        Random secondRes = new Random();
        index = secondRes.Next(second.Count);
        res += second[index];
        res += "di " + BllControllerWeb.S_UserById(i_user_id).t_username.Replace("_neutrale", "");

        return res;
    }

    protected void DeleteGame()
    {
        BllControllerWeb.D_Game(g.i_game_id);
    }
    protected void RepSettlements_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {

    }

}