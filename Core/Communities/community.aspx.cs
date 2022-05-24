using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Ischidados;
using Ischidados.App_Code.Bll;
using System.Data;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

public partial class community : BasePage
{
    enum Grounds
    {
        Empty = 00,
        OneSide = 01,
        TwoSide = 02,
        ThreeSide = 03,
        Full = 04
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        User u = SessionMandatory(false, "Pagina test");

        if (!IsPostBack)
        {
            //ddTest1.Visible = false;
        }
    }

    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        switch (ea.CommandName)
        {
            case "create":
                Create();
                break;
        }
    } 

    protected void SvuotaFiltri()
    {
        
    }

    public byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
        MemoryStream ms = new MemoryStream();
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        return ms.ToArray();
    }

    protected void Create()
    {
        int numColumn = int.Parse(ddX.SelectedValue); 
        int numRow = int.Parse(ddY.SelectedValue);
        DataTable dt = new DataTable();

        try  
        {
            string parameters = "@param13 = 104, @param14 = 103";
            
            gv.DataSource = BllControllerWeb.S_Grounds(parameters);
            gv.DataBind();

         

            //divNuovaScheda.Visible = true;
        }
        catch (Exception e)
        {
            VisualizzaMessaggioErrore(e.Message);
        }
    }

    protected int Random()
    {
        Array values = Enum.GetValues(typeof(Grounds));
        Random random = new Random();
        Grounds randomGround = (Grounds)values.GetValue(random.Next(values.Length));
        int res = (int)randomGround;
        return res;
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
        //}
    }

    protected void VisualizzaMessaggioSuccess(string msg)
    {
        ClientScript.RegisterStartupScript(this.GetType(), " showMsg", " showMsg('success','" + msg + "');", true);
    }

    protected void VisualizzaMessaggioErrore(string msg)
    {
        lblError.Text = "Errore! " + msg;
        lblError.Visible = true;
    }
}