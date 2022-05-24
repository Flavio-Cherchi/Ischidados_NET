using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;
public partial class imagesList : BasePage
{
    public User u { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        u = SessionMandatory(true, "Immagini");

        if (!IsPostBack)
        {
            LoadTable(Filter());
        }
    }

    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        switch (ea.CommandName)
        {
            case "LoadTable":
                LoadTable(Filter());
                break;
            case "linkImage":
                Response.Redirect("~/default.aspx"); 
                break;
        }
    }

    protected void LoadTable(ImageFilter f)
    {
        repPeople.DataSource = BllControllerWeb.S_Images(f);
        repPeople.DataBind();

        ltlType.Text = (f.filter != "0") ? "Categoria: " + f.filter : "";
        ltlCounter.Text = repPeople.Items.Count + " immagini";
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

    protected ImageFilter Filter()
    {
        ImageFilter res = new ImageFilter();
        res.filter = ddType.SelectedValue;

        res.characters = (res.filter == "Personaggi") ? true : false;
        res.communities = (res.filter == "Comunità") ? true : false;
        res.signs = (res.filter == "Segnali stradali") ? true : false;
        res.zombie = (res.filter == "Zombie") ? true : false;
        res.profiles = (res.filter == "Avatar") ? true : false;
        res.settlements = (res.filter == "Insediamenti") ? true : false;
        res.cover = (res.filter == "Immagini di copertina") ? true : false;
        res.items = (res.filter == "Icone") ? true : false;

        return res;
    }
}