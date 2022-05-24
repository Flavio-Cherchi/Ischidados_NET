using Ischidados.App_Code.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = Ischidados.App_Code.Bll.Image;

namespace Ischidados.App_Code.Dal
{
    public class DalWeb
    {

        public string strSQL = "";
        public String NomeTabella = "";
        public String top = "";
        public String temp = "";
        public String valore = "";
        public String messaggio = "";
        public int numero = 0;

        public string StringaConnessione = System.Configuration.ConfigurationManager.ConnectionStrings["ISCHIDADOS"].ConnectionString;

        protected void GenericSelecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = 6000;
        }

        public DataTable RicercaTable(string SQL)
        {
            return RicercaTable(SQL, StringaConnessione);
        }

        public DataRow RicercaTableSingola(string SQL)
        {
            return RicercaTableSingola(SQL, StringaConnessione);
        }

        public void EseguiSQL(string SQL)
        {
            EseguiSQL(SQL, StringaConnessione);
        }

        #region ControlloUtente

        public void ControlloUtente(User ut, bool nuova)
        {
            DataTable dt = new DataTable();
            ut.t_img = "/Assets/img/uomo.png";

            // Ricerca negli utenti del sito Standard
            strSQL = "select * from dbo.users where 1 = 1 ";

            if (!String.IsNullOrEmpty(ut.t_username))
            {
                strSQL += " and t_username ='" + ut.t_username + "' and t_password='" + ut.t_password + "'";
            }
            else strSQL += " and i_user_id ='" + ut.i_user_id + "'";
            dt = RicercaTable(strSQL);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                ut.i_user_id = Convert.ToInt32(dr["i_user_id"].ToString());
                ut.t_username = dr["t_username"].ToString();
                ut.t_email = dr["t_email"].ToString();
                ut.t_img = dr["t_img"].ToString();
                //RegistrazioneLog(Convert.ToInt32(dr["i_rj_id"].ToString()), 1);
            }
        }

        public Boolean isRuolo(int id, string t_ruolo)
        {

            strSQL = "select count(1) as numero from dpv_ore.dbo.v_ruolo_risorse where userid=" + id + " and lower(t_descrizione_ruolo)='" + t_ruolo.Replace("'", "''").ToLower() + "'";
            DataRow dr = RicercaTableSingola(strSQL);
            if (dr["numero"].ToString() == "0")
            {
                return false;
            }
            else return true;


        }

        #endregion
        public DataTable RicercaTable(string SQL, string Connessione)
        {
            using (SqlDataSource SqlDS = new SqlDataSource())
            {

                DataTable dt = null;
                SqlDS.ConnectionString = Connessione;// @"Data Source=192.168.1.9\TEKKAMAKI;Initial Catalog=DPV;User Id=saold;Password=dpvall;Connect Timeout=900";// Connessione;
                SqlDS.Selecting += GenericSelecting;
                SqlDS.SelectCommand = SQL;
                SqlDS.DataBind();
                DataView view = (DataView)SqlDS.Select(DataSourceSelectArguments.Empty);
                dt = view.ToTable();
                return dt;

            }

        }

        public DataRow RicercaTableSingola(string SQL, string Connessione)
        {
            using (SqlDataSource SqlDS = new SqlDataSource())
            {

                DataTable dt = null;
                SqlDS.ConnectionString = Connessione;
                SqlDS.Selecting += GenericSelecting;
                SqlDS.SelectCommand = SQL;
                SqlDS.DataBind();
                DataView view = (DataView)SqlDS.Select(DataSourceSelectArguments.Empty);
                dt = view.ToTable();
                DataRow dr = null;
                if (dt.Rows.Count > 0) dr = dt.Rows[0];
                return dr;

            }

        }

        public void EseguiSQL(string SQL, string Connessione)
        {
            using (SqlConnection con = new SqlConnection(Connessione))
            {
                SqlCommand com = new SqlCommand(SQL, con);
                con.Open();
                com.CommandTimeout = 9000;
                com.ExecuteNonQuery();
                con.Close();
            }

        }

        #region test
        public DataTable S_Tests()
        {
            strSQL = "select * from dbo.secondoTest";
            //DataRow dr = RicercaTableSingola(strSQL);
            //t_nome_file = dr["t_nome_file"].ToString();
            //strSQL = dr["t_sql"].ToString();
            return RicercaTable(strSQL);
        }


        public DataRow S_TestById(int i_sql_id)
        {
            strSQL = "select * from dpv_evo.query.t_a_sql where i_sql_id=" + i_sql_id;
            return RicercaTableSingola(strSQL);
        }

        public void E_Test(int i_candidato_id, string email_dest)
        {
            strSQL = "select * from dpv_evo.candidato.SchedaCandidato where i_candidato_id =" + i_candidato_id;
            DataRow dr = RicercaTableSingola(strSQL);

            if (dr["b_inviata_mail_completamento_dati"].ToString() != "True")
            {
                strSQL = " UPDATE dpv_evo.candidato.SchedaCandidato SET ";
                strSQL += " b_inviata_mail_completamento_dati = 1";
                strSQL += " where i_candidato_id =" + i_candidato_id;

                EseguiSQL(strSQL);
            }
        }
        #endregion

        #region characters
        public DataTable S_Characters()
        {
            strSQL = "select *, t_name + ' ' + t_lastname as fullName, CASE WHEN b_sex = 1 THEN 'Uomo' ELSE 'Donna' END as t_sex from dbo.characters";
            //DataRow dr = RicercaTableSingola(strSQL);
            //t_nome_file = dr["t_nome_file"].ToString();
            //strSQL = dr["t_sql"].ToString();
            return RicercaTable(strSQL);
        }

        public DataRow S_CharacterById(int id)
        {
            strSQL = "select * from dbo.characters where i_character_id = " + id;
            return RicercaTableSingola(strSQL);
        }
        #endregion

        #region games
        public DataTable S_Games()
        {
            strSQL = "Select * from dbo.v_gamesList";
            //strSQL = "select *, convert(varchar(10), d_createdOn, 103) as t_createdOn from dbo.games";
            //DataRow dr = RicercaTableSingola(strSQL);
            //t_nome_file = dr["t_nome_file"].ToString();
            //strSQL = dr["t_sql"].ToString();
            return RicercaTable(strSQL);
        }

        public DataRow S_GameById(int id)
        {
            strSQL = "select * from dbo.games where i_game_id = " + id;
            return RicercaTableSingola(strSQL);
        }

        public DataRow I_Game(Game g)
        {
            int isOpen = (g.isOpen) ? 1 : 0;

            strSQL = @"INSERT INTO [dbo].[games] (
                        [i_master_id], 
                        [t_name], 
                        [t_desc], 
                        [i_createdBy_id], 
                        [i_modifiedBy_id],
                        [b_isActive],
                        [b_isOpen]
                        ) VALUES (" +
                        g.i_master_id +
                        @", '" + g.t_name.Replace("'", "’") +
                        @"', '" + g.t_desc.Replace("'", "’") +
                        @"'," + g.i_createdBy_id +
                        @"," + g.i_modifiedBy_id +
                        @",0," + isOpen + ") SELECT SCOPE_IDENTITY() as i_game_id";

            DataRow partialRes = RicercaTableSingola(strSQL);
            int i_game_id = int.Parse(partialRes["i_game_id"].ToString());

            strSQL = @"INSERT INTO [dbo].[turns] (
                        [i_game_id], 
                        [i_turn]
                        ) VALUES (" + i_game_id + ",1)";

            EseguiSQL(strSQL);



            strSQL = "select * from dbo.games where i_game_id = " + i_game_id;
            return RicercaTableSingola(strSQL);
        }

        public void I_GameUser(int i_game_id, int i_user_id)
        {
            strSQL = @"INSERT INTO [dbo].[gamesUsers] (
                        [i_game_id], 
                        [i_user_id] 
                        ) VALUES (" + i_game_id + "," + i_user_id + ")";

            EseguiSQL(strSQL);
        }

        public void D_GameUser(int i_game_id, int i_user_id)
        {
            strSQL = @"Delete [dbo].[gamesUsers] 
                            where [i_game_id] = " + i_game_id + 
                            "and [i_user_id] = " + i_user_id;

            EseguiSQL(strSQL);
        }

        public DataRow S_IsInGame(int i_game_id, int i_user_id)
        {
            strSQL = "exec dbo.sp_isInGame @i_user_id = " + i_user_id + ", @i_game_id = " + i_game_id; ;
            return RicercaTableSingola(strSQL);
        }
        #endregion


        #region natures

        public DataTable S_NaturesSkills(int type)
        {
            strSQL = "";

            switch (type)
            {
                case 1:
                    strSQL = @"select distinct i_nature_id, t_nature, t_url from                 
                                dbo.v_natureSkillList";
                    break;
                case 2:
                    strSQL = "select * from dbo.v_natureSkillList where i_nature_skill_id is not null";
                    break;
                default:
                    break;
            }
            
            return RicercaTable(strSQL);
        }

        public DataTable S_Traits()
        {
            strSQL = "select * from dbo.traits";

            return RicercaTable(strSQL);
        }

        #endregion

        #region images
        public DataTable S_Images(ImageFilter f)
        {
            strSQL = "select * from dbo.images where t_tag != 'items' ";

            if (f.characters)
                strSQL += " and t_tag = 'characters'";
            if (f.communities)
                strSQL += " and t_tag = 'communities'";
            if (f.signs)
                strSQL += " and t_tag = 'signs'";
            if (f.zombie)
                strSQL += " and t_tag = 'zombie'";

            return RicercaTable(strSQL);
        }
        public DataRow S_ImageById(int id)
        {
            strSQL = "select * from dbo.images where i_image_id = " + id;
            return RicercaTableSingola(strSQL);
        }

        public void I_Image(Image g)
        {
            strSQL = @"INSERT INTO [dbo].[images] (
                                        [t_url], 
                                        [t_uploadedBy], 
                                        [t_tag], 
                                        [t_sex]
                                        ) VALUES ('" + 
                                        g.t_url + "', '" + 
                                        g.t_uploadedBy + "', '" + 
                                        g.t_tag + "', '" + 
                                        g.t_sex+ "')";
            EseguiSQL(strSQL);
        }

        public void U_Image(Image g)
        {
            //todo;
        }

        public void D_Image(int id)
        {
            strSQL = "Delete dbo.images where i_image_id = " + id;
            EseguiSQL(strSQL);
        }

        #endregion

        #region users
        public DataTable S_Users(int i_role_id)
        {
            strSQL = "select * from dbo.v_users";
            if(i_role_id == 3)
                strSQL += " where b_isActive = 1";

            return RicercaTable(strSQL);
        }

        public DataRow S_UserById(int id)
        {
            strSQL = "select * from dbo.users where i_user_id = " + id;
            return RicercaTableSingola(strSQL);
        }

        public DataRow S_UserByObject(User user)
        {
            strSQL = "select * from dbo.users " +
                     "where t_username = '" + user.t_username + "' and t_password = '" + user.t_password + "'";
            return RicercaTableSingola(strSQL);
        }

        public bool I_User(User user)
        {
            bool res = true;
            int rememberMe = (user.b_rememberMe) ? 1 : 0;
            strSQL = @"INSERT INTO [dbo].[users] (
                                        [i_role_id], 
                                        [t_username], 
                                        [t_password], 
                                        [t_email], 
                                        [t_img], 
                                        [i_modifiedBy_id], 
                                        [b_rememberMe]
                                        ) VALUES (
                                        3, "
                                         + "'" + user.t_username.Replace("'", "’") + "'," +
                                           "'" + user.t_password + "'," +
                                           "'" + user.t_email + "'," +
                                           "'" + user.t_img + "'," +
                                           0 + "," +
                                           rememberMe + ")";

            try { EseguiSQL(strSQL); }
            catch { res = false; }

            return res;
        }
        #endregion
    }
}