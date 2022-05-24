using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;

public partial class gameNew : BasePage
{
    public User u { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        u = SessionMandatory(true, "Nuova partita");

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
        }
    }

    protected void NewGame()
    {
        Game g = new Game();
        bool error = CheckError();

        if (!error)
        {
            g.t_name = tName.Text;
            g.t_desc = string.IsNullOrEmpty(tDesc.Text) ? "Nessuna descrizione disponibile per la partita." : tDesc.Text;
            g.i_master_id = u.i_user_id;
            g.i_createdBy_id = u.i_user_id;
            g.i_modifiedBy_id = u.i_user_id;
            g.i_gameType_id = int.Parse(hidTypeOfGame.Value);
            g.i_image_id = int.Parse(hidI_image_id.Value);

            if (int.Parse(hidI_intelligence_id.Value) == 1)
            {
                Random rnd = new Random();
                g.i_intelligence_id = rnd.Next(2, 7);
            } else
            {
                g.i_intelligence_id = int.Parse(hidI_intelligence_id.Value);
            }

            int i_game_id = BllControllerWeb.I_Game(g);

            Response.Redirect("~/Core/Games/game.aspx?id=" + i_game_id);
        }
    }

    protected bool CheckError()
    {
        bool error = false;

        if (int.Parse(hidI_image_id.Value) == 0)
        {
            lblError.Text = "Scegliere un'immagine di copertina!";
            error = true;
        }

        if (string.IsNullOrEmpty(tName.Text))
        {
            lblError.Text = "Titolo obbligatorio!";
            error = true;
        }

        lblError.Visible = (error);

        return error;
    }

    protected void LoadTable()
    {
        ImageFilter f = new ImageFilter();
        f.cover = true;
        repPeople.DataSource = BllControllerWeb.S_Images(f);
        repPeople.DataBind();
    }

    protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (!BllControllerWeb.isRuolo(9, int.Parse(Session["i_rj_id"].ToString())))
        //    {
        //        Button BtnAssumi = (Button)e.Row.FindControl("BtnAssumi");
        //        BtnAssumi.Visible = false;

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
    }

    //protected void VisualizzaMessaggioSuccess(string msg)
    //{
    //    ClientScript.RegisterStartupScript(this.GetType(), " showMsg", " showMsg('success','" + msg + "');", true);
    //}
    //protected void VisualizzaMessaggioErrore(string msg)
    //{
    //    ClientScript.RegisterStartupScript(this.GetType(), " showMsg", " showMsg('error','" + msg + "');", true);
    //}
}