using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Ischidados;
using Ischidados.App_Code.Bll;
public partial class elenco_test : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User u = SessionMandatory(false, "Pagina test");

        if (!IsPostBack)
        {
            ddTest1.Visible = false;
        }
    }

    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        switch (ea.CommandName)
        {
            case "LoadTable":                         
                LoadTable();
                break;
            //case "nuovaScheda":
            //    {
            //        string link = "hr_evo_schede_risorse_dettaglio2.aspx?u=" + Session["GutenteID"].ToString();
            //        Response.Redirect(link);
            //    }
            //    break;
            //case "dettaglio2":
            //    {

            //        Button l = (Button)sender;
            //        FiltroRichieste f = new FiltroRichieste();

            //        string tipologiarichDPI = "009";
            //        string tipologiarichBV = "011";
            //        string tipologiapers = "000";
            //        Boolean b_dettaglio = true;

            //        int i_utente_richiesta_id = int.Parse(Session["i_rj_id"].ToString());

            //        int i_richiesta_id_DPI = BllControllerWeb.RichiestaNuova(int.Parse(tipologiarichDPI), int.Parse(tipologiapers), b_dettaglio, i_utente_richiesta_id, false);
            //        if (int.Parse(tipologiapers) == 101 || int.Parse(tipologiapers) == 102)
            //            BllControllerWeb.RichiestaInserisciRisorsa(i_richiesta_id_DPI);
            //        f.i_richiesta_id = i_richiesta_id_DPI;
            //        f.b_non_confermate = true;
            //        DataTable dtRichiesteDPI = BllControllerWeb.RicercaRichieste(f);
            //        DataRow drDPI = dtRichiesteDPI.Rows[0];


            //        int i_richiesta_id_BV = BllControllerWeb.RichiestaNuova(int.Parse(tipologiarichBV), int.Parse(tipologiapers), b_dettaglio, i_utente_richiesta_id, false);
            //        if (int.Parse(tipologiapers) == 101 || int.Parse(tipologiapers) == 102)
            //            BllControllerWeb.RichiestaInserisciRisorsa(i_richiesta_id_BV);
            //        f.i_richiesta_id = i_richiesta_id_BV;
            //        f.b_non_confermate = true;
            //        DataTable dtRichiesteBV = BllControllerWeb.RicercaRichieste(f);
            //        DataRow drBV = dtRichiesteBV.Rows[0];

            //        string i_scheda_id = l.CommandArgument.ToString();
            //        string link = "hr_evo_schede_risorse_dettaglio2.aspx?u=" + Session["GutenteID"].ToString() + "&id=" + i_scheda_id + "&idRichiestaDPI=" + i_richiesta_id_DPI + "&idtiporichiestaDPI=" + int.Parse(tipologiarichDPI).ToString() + "&idRichiestaBV=" + i_richiesta_id_BV + "&idtiporichiestaBV=" + int.Parse(tipologiarichBV).ToString();
            //        Response.Redirect(link);
            //    }
            //    break;
        }
    }

    //protected void Elimina(int i_scheda_id)
    //{
    //    int i_persona_id_cancellazione = int.Parse(Session["i_rj_id"].ToString());
    //    //bool deleted = BllControllerWeb.EliminaSchedaRisorsa(i_scheda_id, i_persona_id_cancellazione);

    //    if (deleted)
    //    {
    //        LoadTable();
    //        VisualizzaMessaggioSuccess("Scheda eliminata correttamente!");
    //    } else
    //    {
    //        VisualizzaMessaggioErrore("Errore durante 'eliminazione della scheda!");
    //    }
    //    btnDivElimina.Visible = false;
    //    divNuovaScheda.Visible = true;
    //}
    protected void SvuotaFiltri()
    {
        //txtRisorsa.Text = "";
        //ddValidazioni.SelectedValue = "tutte";
        //ddCommessa.SelectedValue = "0";
        //ddAzienda.SelectedValue = "0";
        //ddAreaManager.SelectedValue = "";
        //ddTeamLeader.SelectedValue = "";
        //ddPlanner.SelectedValue = "";
        //ddPrimoResp.SelectedValue = "";
        //ddSecondoResp.SelectedValue = "";
        
    }
   
    protected void LoadTable()
    {
        //Gv.DataSource = BllControllerWeb.S_Test_All();
        //Gv.DataBind();
        //if (Gv.Rows.Count > 0)
        //{
        //    Gv.UseAccessibleHeader = true;
        //    Gv.HeaderRow.TableSection = TableRowSection.TableHeader;
        //}

        //btnDivElimina.Visible = false;
        //divNuovaScheda.Visible = true;
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

    protected void VisualizzaMessaggioSuccess(string msg)
    {
        ClientScript.RegisterStartupScript(this.GetType(), " showMsg", " showMsg('success','" + msg + "');", true);
    }
    protected void VisualizzaMessaggioErrore(string msg)
    {
        ClientScript.RegisterStartupScript(this.GetType(), " showMsg", " showMsg('error','" + msg + "');", true);
    }
}