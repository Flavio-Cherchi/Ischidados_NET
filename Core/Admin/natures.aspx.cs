using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;
using System.Collections.Generic;

public partial class natures : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User u = SessionMandatory(true, "Indoli");
        AdminOnly(u);

        if (!IsPostBack)
        {
            LoadTable(1,0);
        }
    }


    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        switch (ea.CommandName)
        {
            case "natures":
                LoadTable(2,0);
                break;
            case "traits":
                LoadTable(3,0);
                break;
        }
    }

    protected void LoadTable(int type, int i_nature_id)
    {
        switch (type)
        {
            case 1:
                RepNatures.Visible = true;
                GvSkills.Visible = true;
                GvTraits.Visible = false;
                RepNatures.DataSource = BllControllerWeb.S_NaturesSkills(1, i_nature_id);
                RepNatures.DataBind();

                break;
            case 2:
                RepNatures.Visible = true;
                GvSkills.Visible = true;
                GvTraits.Visible = false;
                GvSkills.DataSource = BllControllerWeb.S_NaturesSkills(2, i_nature_id);
                GvSkills.DataBind();
                if (GvSkills.Rows.Count > 0)
                {
                    GvSkills.UseAccessibleHeader = true;
                    GvSkills.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                break;
            case 3:
                RepNatures.Visible = false;
                GvSkills.Visible = false;
                GvTraits.Visible = true;
                GvTraits.DataSource = BllControllerWeb.S_Traits();
                GvTraits.DataBind();
                if (GvTraits.Rows.Count > 0)
                {
                    GvTraits.UseAccessibleHeader = true;
                    GvTraits.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                break;
            default:
                break;
        }

    }

    protected void Repeater_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "selectSkillsPerNature")
        {
            HiddenField hidI_nature_id = (HiddenField)e.Item.FindControl("hidI_nature_id");

            if (hidI_nature_id != null)
                LoadTable(2, int.Parse(hidI_nature_id.Value));

        }
    }

}