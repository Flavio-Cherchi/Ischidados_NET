using Ischidados.App_Code.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
        public string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Ischidados"].ConnectionString;

        #region Base

        protected void GenericSelecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = 6000;
        }

        public DataTable SearchDataTable(string SQL)
        {
            return SearchDataTable(SQL, ConnectionString);
        }

        public DataRow SearchDataRow(string SQL)
        {
            return SearchDataRow(SQL, ConnectionString);
        }

        public void ExecSQL(string SQL)
        {
            ExecSQL(SQL, ConnectionString);
        }

        public DataTable SearchDataTable(string SQL, string Connessione)
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
                return dt;

            }

        }

        public DataRow SearchDataRow(string SQL, string Connessione)
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

        public void ExecSQL(string SQL, string Connessione)
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
        #endregion

        #region characters
        public DataTable S_Characters()
        {
            strSQL = @"select *, t_name + ' ' + t_lastname as fullName, CASE WHEN b_sex = 1 THEN 'Uomo' ELSE 'Donna' END as t_sex from dbo.characters as a join dbo.images as b on a.i_image_id = b.i_image_id";
            return SearchDataTable(strSQL);
        }

        public DataRow S_CharacterById(int id)
        {
            strSQL = "select * from dbo.characters where i_character_id = " + id;
            return SearchDataRow(strSQL);
        }
        #endregion

        #region dropdown

        public DataTable DD_Users()
        {
            strSQL = @"Select i_user_id as DataValueField, t_username as DataTextField
                       from dbo.users
                       where b_isActive = 1";
            return SearchDataTable(strSQL);
        }

        #endregion

        #region forum

        public DataTable S_Forum_Sections()
        {
            strSQL = "select a.*, substring(b.t_body, 0, 20) + '...' as t_body from dbo.v_forum_sections as a join dbo.forum_messages as b on a.i_last_message_id = b.i_message_id order by i_order";
            return SearchDataTable(strSQL);
        }

        #endregion

        #region games
        public DataTable S_Games(Game g)
        {
            strSQL = "Select distinct * from dbo.v_gamesList ";

            if (g.i_master_id != 0)
                strSQL += " where i_master_id = " + g.i_master_id;

            if (g.i_not_master_id != 0)
                strSQL += "  as a join dbo.gamesusers as b on a.i_game_id = b.i_game_id and i_user_id = " + g.i_not_master_id;

            if (g.i_game_id != 0)
                strSQL += " where i_game_id = " + g.i_game_id;

            //if (g.i_not_master_id != 0)
            //    strSQL += " and i_master_id != " + g.i_not_master_id;

            strSQL += " order by [d_modifiedOn] desc";
            return SearchDataTable(strSQL);
        }

        public DataRow S_GameById(int id)
        {
            strSQL = "select * from dbo.v_gamesList where i_game_id = " + id;

            return SearchDataRow(strSQL);
        }

        public string S_GameType(int i_gameType_id)
        {
            strSQL = "Select t_desc from dbo.gamesTypes where i_gameType_id = " + i_gameType_id;
            DataRow res = SearchDataRow(strSQL);

            return res["t_desc"].ToString();
        }

        public DataTable S_GamesByUser(int i_user_id, bool isMaster)
        {
            if (isMaster)
            {
                strSQL = "select * from dbo.games where i_master_id = " + i_user_id;
            }
            else
            {
                strSQL = "select * from dbo.v_gamesByUser where i_user_id = " + i_user_id;
            }
            return SearchDataTable(strSQL);
        }

        public DataRow S_GameCount()
        {
            strSQL = "select count(*) as GameNum from dbo.games";
            return SearchDataRow(strSQL);
        }

        public int I_Game(Game g)
        {

            strSQL = @"INSERT INTO [dbo].[games] (
                        [i_master_id], 
                        [t_name], 
                        [t_desc], 
                        [i_createdBy_id], 
                        [i_modifiedBy_id],
                        [b_isActive],
                        [i_gameType_id],
                        [i_image_id],
                        [i_intelligence_id]
                        ) VALUES (" +
                        g.i_master_id +
                        @", '" + g.t_name.Replace("'", "’") +
                        @"', '" + g.t_desc.Replace("'", "’") +
                        @"'," + g.i_createdBy_id +
                        @"," + g.i_modifiedBy_id +
                        @",1," + g.i_gameType_id +
                        @"," + g.i_image_id +
                        @"," + g.i_intelligence_id + ") SELECT SCOPE_IDENTITY() as i_game_id";

            DataRow partialRes = SearchDataRow(strSQL);
            int i_game_id = int.Parse(partialRes["i_game_id"].ToString());

            strSQL = @"INSERT INTO [dbo].[turns] (
                        [i_game_id], 
                        [i_turn]
                        ) VALUES (" + i_game_id + ",1)";

            ExecSQL(strSQL);



            strSQL = "select * from dbo.games where i_game_id = " + i_game_id;

            DataRow res = SearchDataRow(strSQL);

            return int.Parse(res["i_game_id"].ToString());
        }

        public void I_GameUser(int i_game_id, int i_user_id, bool isAccepted)
        {
            if (isAccepted)
            {
                strSQL = @"INSERT INTO [dbo].[gamesUsers] (
                        [i_game_id], 
                        [i_user_id] 
                        ) VALUES (" + i_game_id + "," + i_user_id + ")";
            }
            else
            {
                strSQL = @"INSERT INTO [dbo].[gamesUsers] (
                        [i_game_id], 
                        [i_user_id],
                        [b_isAccepted]
                        ) VALUES (" + i_game_id + "," + i_user_id + ",0)";
            }


            ExecSQL(strSQL);
        }

        public int I_Game_Turn(int i_game_id)
        {
            strSQL = @"select top 1 i_turn from turns where i_game_id = " + i_game_id + " order by i_turn desc ";
            DataRow i_turnRow = SearchDataRow(strSQL);
            int i_turn = int.Parse(i_turnRow["i_turn"].ToString()) + 1;

            strSQL = @"INSERT INTO [dbo].[turns] (
                        [i_game_id], 
                        [i_turn] 
                        ) VALUES (" + i_game_id + "," + i_turn + ")";

            strSQL += " SELECT SCOPE_IDENTITY() as i_turn_id";

            DataRow partialRes = SearchDataRow(strSQL);

            return int.Parse(partialRes["i_turn_id"].ToString());
        }

        public void D_GameUser(int i_game_id, int i_user_id)
        {
            strSQL = @"Delete [dbo].[gamesUsers] 
                            where [i_game_id] = " + i_game_id +
                            "and [i_user_id] = " + i_user_id;

            ExecSQL(strSQL);
        }

        public void D_Game(int i_game_id)
        {
            strSQL = @"Delete [dbo].[gamesUsers] 
                            where [i_game_id] = " + i_game_id;

            strSQL += @"Delete [dbo].[games] 
                            where [i_game_id] = " + i_game_id;

            strSQL += @"Delete [dbo].[turns] 
                            where [i_game_id] = " + i_game_id;
            ExecSQL(strSQL);

            //todo: add mail to master to explain cancellation!
        }


        public DataRow S_IsInGame(int i_game_id, int i_user_id)
        {
            strSQL = "exec dbo.sp_isInGame @i_user_id = " + i_user_id + ", @i_game_id = " + i_game_id; ;
            return SearchDataRow(strSQL);
        }
        #endregion

        #region Grounds
        #endregion
        public DataTable S_Grounds(string parameters)
        {
            strSQL = @"exec dbo.sp_grounds_set " + parameters;

            return SearchDataTable(strSQL);
        }
        #region images
        public DataTable S_Images(ImageFilter f)
        {
            strSQL = "select * from dbo.images where 1=1 ";

            if (f.characters)
                strSQL += " and t_tag = 'characters'";
            if (f.communities)
                strSQL += " and t_tag = 'communities'";
            if (f.signs)
                strSQL += " and t_tag = 'signs'";
            if (f.zombie)
                strSQL += " and t_tag = 'zombie'";
            if (f.profiles)
                strSQL += " and t_tag = 'profiles'";
            if (f.items)
                strSQL += " and t_tag = 'items'";
            if (f.cover)
                strSQL += " and t_tag = 'cover'";
            if (f.settlements)
                strSQL += " and t_tag = 'settlements'";

            strSQL += " order by t_tag";

            return SearchDataTable(strSQL);
        }
        public DataRow S_ImageById(int id)
        {
            strSQL = "select * from dbo.images where i_image_id = " + id;
            return SearchDataRow(strSQL);
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
                                        g.t_sex + "')";
            ExecSQL(strSQL);
        }

        public void U_Image(Image g)
        {
            //todo;
        }

        public void D_Image(int id)
        {
            strSQL = "Delete dbo.images where i_image_id = " + id;
            ExecSQL(strSQL);
        }

        #endregion

        #region logs
        public void I_LogError(LogError logError)
        {
            strSQL = "INSERT INTO DBO.LOGERRORS (";
            strSQL += "t_desc, t_function, t_page";
            strSQL += ")VALUES(";
            strSQL += "'" + logError.t_desc + "',";
            strSQL += "'" + logError.t_function + "',";
            strSQL += "'" + logError.t_page + "'";
            strSQL += ")";

            ExecSQL(strSQL);
        }

        public DataTable S_LogErrors()
        {
            strSQL = "Select * from dbo.logErrors order by d_date desc";
            return SearchDataTable(strSQL);
        }

        public void I_LogUser(LogUser logUser)
        {
            strSQL = "INSERT INTO DBO.LOGUSERS (";
            strSQL += "i_user_id, t_page";
            strSQL += ")VALUES(";
            strSQL += logUser.i_user_id + ",";
            strSQL += "'" + logUser.t_page + "'";
            strSQL += ")";

            ExecSQL(strSQL);
        }

        public DataTable S_LogUsers(int i_user_id)
        {
            string top100 = i_user_id != 0 ? "" : "top 100 ";
            string where = i_user_id != 0 ? " where i_user_id = " + i_user_id : "";

            strSQL = "Select " + top100 + " * from dbo.v_logUsers " + where;
            strSQL += " order by d_date desc";

            return SearchDataTable(strSQL);
        }
        #endregion

        #region messages

        public DataRow S_Message(int i_message_id)
        {
            strSQL = "Select * from dbo.v_message where i_message_id = " + i_message_id;
            return SearchDataRow(strSQL);
        }

        public DataTable S_MessageRecipient(int i_message_id)
        {
            strSQL = "Select * from dbo.v_recipients where i_message_id = " + i_message_id;
            return SearchDataTable(strSQL);
        }

        public DataTable S_Messages_Received(int i_user_id, bool checkIfRead)
        {
            strSQL = "Select * from dbo.v_messages where i_recipient_id = " + i_user_id + "  and b_isDeletedForRecipient = 0 ";

            if (checkIfRead)
                strSQL += " and b_isRead = 1";

            strSQL += " order by d_sendOn desc";
            return SearchDataTable(strSQL);
        }

        public int S_Messages_Check_Unread(int i_user_id)
        {
            strSQL = "Select count(b_isRead) as numIsRead from messagesRecipients where i_recipient_id = " + i_user_id + " and b_isRead = 0 and b_isDeletedForRecipient = 0";
            return int.Parse(SearchDataRow(strSQL)["numIsRead"].ToString());
        }

        public DataTable S_Messages_Sent(int i_user_id)
        {
            strSQL = "Select * from dbo.v_messages_without_recipients where i_sender_id = " + i_user_id + " and b_isDeletedForSender = 0 order by d_sendOn desc";
            return SearchDataTable(strSQL);
        }

        public DataRow I_Message(Message g)
        {
            strSQL = @"INSERT INTO [dbo].[messages] (
                        [i_sender_id], 
                        [t_subject], 
                        [t_content]) VALUES (" +
                        g.i_sender_id +
                        @", '" + g.t_subject.Replace("'", "’") +
                        @"', '" + g.t_content.Replace("'", "’") +
                        @"') SELECT SCOPE_IDENTITY() as i_message_id";

            DataRow partialRes = SearchDataRow(strSQL);
            int i_message_id = int.Parse(partialRes["i_message_id"].ToString());

            foreach (Recipient rec in g.recipientList)
            {
                strSQL = @"INSERT INTO [dbo].[messagesRecipients] (
                            [i_message_id], 
                            [i_recipient_id],
                            [b_isRead]
                            ) VALUES (" + i_message_id + "," + rec.i_recipient_id + ", 0)";
                ExecSQL(strSQL);
            }


            strSQL = "select * from dbo.v_messages where i_message_id = " + i_message_id + " and b_isDeletedForSender = 0 order by d_sendOn desc";
            return SearchDataRow(strSQL);
        }

        public void U_MessageIsRead(int i_message_id, int i_recipient_id)
        {
            strSQL = @"update dbo.messagesRecipients 
                        set b_isRead = 1
                        where i_message_id = " + i_message_id +
                        "and i_recipient_id = " + i_recipient_id;
            ExecSQL(strSQL);
        }

        public void D_MessageForSender(int i_message_id)
        {
            strSQL = "Update dbo.messages set b_isDeletedForSender = 1 where i_message_id = " + i_message_id;
            ExecSQL(strSQL);
        }

        public void D_MessageForRecipient(int i_message_id, int i_recipient_id)
        {
            strSQL = "Update dbo.messagesRecipients set b_isDeletedForRecipient = 1 where i_message_id = " + i_message_id + " and i_recipient_id = " + i_recipient_id;
            ExecSQL(strSQL);
        }



        #endregion

        #region natures

        public DataTable S_NaturesSkills(int type, int i_nature_id)
        {
            strSQL = "";

            switch (type)
            {
                case 1:
                    strSQL = "select distinct i_nature_id, t_nature, t_url from dbo.v_natureSkillList";
                    break;
                case 2:
                    strSQL = "select * from dbo.v_natureSkillList where i_nature_skill_id is not null";

                    if (i_nature_id != 0)
                        strSQL += " and i_nature_id = " + i_nature_id;
                    break;
                default:
                    break;
            }

            return SearchDataTable(strSQL);
        }

        public DataTable S_Traits()
        {
            strSQL = "select * from dbo.traits";

            return SearchDataTable(strSQL);
        }

        #endregion

        #region settlements
        public DataTable S_SettlementsByGame(Game g)
        {
            strSQL = @"select * from v_settlements 
                                where i_game_id = " + g.i_game_id + 
                                " and i_turn_id = " + g.i_turn_id + 
                                " order by t_name ";
            return SearchDataTable(strSQL);
        }

        public DataRow S_SettlementById(int i_settlement_id)
        {
            strSQL = "select top 1 * from v_settlements where i_settlement_id = 4 " + i_settlement_id;
            strSQL += " order by i_turn_id desc";
            return SearchDataRow(strSQL);
        }

        public DataTable S_SettlementHystoryById(int i_settlement_id)
        {
            strSQL = "select * from v_settlements where i_settlement_id = 4 " + i_settlement_id;
            strSQL += " order by i_turn_id desc";
            return SearchDataTable(strSQL);
        }

        public void I_settlement(Settlement s)
        {
            //First, insert settlement generic data
            strSQL = @"INSERT INTO [dbo].[settlements]
                                       ([i_game_id]
                                       ,[i_user_id]
                                       ,[i_image_id]
                                       ,[t_name]
                                       ,[t_desc]
                                       ,[d_createdOn])
                                 VALUES
                                       (";
            strSQL += s.i_game_id + ",";
            strSQL += s.i_user_id + ",";
            strSQL += s.i_image_id + ",";
            strSQL += "'" + s.t_name + "',";
            strSQL += "'" + s.t_desc + "',";
            strSQL += "convert(datetime, '" + DateTime.Now + "', 103)";
            strSQL += ")";

            strSQL += " SELECT SCOPE_IDENTITY() as i_settlement_id";

            DataRow partialRes = SearchDataRow(strSQL);
            s.i_settlement_id = int.Parse(partialRes["i_settlement_id"].ToString());

            //Then, insert settlement specs

            strSQL = @"INSERT INTO [dbo].[settlementsSpecs]
                                       ([i_settlement_id],
                                        [i_turn_id])
                                        VALUES
                                       (";
            strSQL += s.i_settlement_id + ",";
            strSQL += s.settlementSpecsList[0].i_turn_id;
            strSQL += ")";

            ExecSQL(strSQL);
        }

        public void U_settlement(SettlementSpecs ss, SettlementDiplomacy[] sdList)
        {
            //settlement generic data never update!
            //First, update settlement specs
            strSQL = @"INSERT INTO [dbo].[settlementsSpecs]
                                       ([i_settlement_id]
                                       ,[i_turn_id]
                                       ,[i_population]
                                       ,[i_food]
                                       ,[i_drug]
                                       ,[i_tool]
                                       ,[i_weapon]
                                       ,[i_hygiene]
                                       ,[b_isNeutral]
                                       ,[b_isDestroyed])
                                 VALUES
                                       (";
            strSQL += ss.i_settlement_id + ",";
            strSQL += ss.i_turn_id + ",";
            strSQL += ss.i_population + ",";
            strSQL += ss.i_food + ",";
            strSQL += ss.i_drug + ",";
            strSQL += ss.i_tool + ",";
            strSQL += ss.i_weapon + ",";
            strSQL += ss.i_hygiene + ",";
            strSQL += (ss.b_isNeutral == true ? 1 : 0) + ",";
            strSQL += (ss.b_isDestroyed == true ? 1 : 0);
            strSQL += ")";

            ExecSQL(strSQL);

            //Then, insert new settlement diplomacies, if exist
            if(sdList != null)
            {
                if (sdList.Length > 0)
                {
                    foreach (SettlementDiplomacy sd in sdList)
                    {
                        strSQL = @"INSERT INTO [dbo].[settlementsDiplomacy]
                                           ([i_first_settlement_id]
                                           ,[i_second_settlement_id]
                                           ,[i_diplomacy_id]
                                           ,[i_turn_id])
                                     VALUES
                                           (";
                        strSQL += sd.i_first_settlement_id + ",";
                        strSQL += sd.i_second_settlement_id + ",";
                        strSQL += sd.diplomacy.i_diplomacy_id + ",";
                        strSQL += sd.i_turn_id + ",";
                        strSQL += ")";

                        ExecSQL(strSQL);
                    }
                }
            }

        }
        #endregion

        #region test
        public DataTable S_Tests()
        {
            strSQL = "select * from dbo.secondoTest";
            return SearchDataTable(strSQL);
        }
        #endregion

        #region users
        public DataTable S_Users(int i_role_id)
        {
            strSQL = "select * from dbo.v_users";
            if (i_role_id == 3)
                strSQL += " where b_isActive = 1";
            strSQL += " order by username";
            return SearchDataTable(strSQL);
        }

        public DataRow S_UserById(int id)
        {
            try
            {
                strSQL = "select * from dbo.users where i_user_id = " + id;
                return SearchDataRow(strSQL);
            }
            catch (Exception e)
            {
                LogError logError = new LogError();
                logError.t_desc = e.Message;
                logError.t_function = "S_UserById";
                logError.t_page = "DalWeb";
                I_LogError(logError);
                throw e;
            }

        }

        public DataTable S_UsersByGame(int i_game_id, bool isAccepted)
        {
            int accepted = (isAccepted) ? 1 : 0;

            strSQL = "select a.* from dbo.users as a " +
                " join dbo.gamesusers as b" +
                " on b.i_user_id = a.i_user_id " +
                " join dbo.games as c" +
                " on b.i_game_id = c.i_game_id";

            strSQL += " where c.i_game_id = " + i_game_id;
            strSQL += " and b.b_isAccepted = " + accepted;
            strSQL += " order by t_username";
            return SearchDataTable(strSQL);
        }

        public string S_UserImg(int i_image_id)
        {
            strSQL = "Select t_url from dbo.images where i_image_id = " + i_image_id;
            DataRow res = SearchDataRow(strSQL);

            return res["t_url"].ToString().Trim();
        }
        public DataRow S_UserByObject(User user)
        {
            strSQL = "select * from dbo.users " +
                     "where t_username = '" + user.t_username + "' and t_password = '" + user.t_password + "'";
            return SearchDataRow(strSQL);
        }

        public DataRow S_UserUsername(string username)
        {
            strSQL = "select * from dbo.users " +
                     "where t_username = '" + username + "'";
            return SearchDataRow(strSQL);
        }

        public DataRow S_UserByMail(string email)
        {
            strSQL = "select * from dbo.users " +
                     "where t_email = '" + email + "'";
            return SearchDataRow(strSQL);
        }

        public int I_User(User user)
        {
            int res = 0;
            int rememberMe = (user.b_rememberMe) ? 1 : 0;
            int neutral = 0;
            neutral = (user.b_isNeutral) ? 1 : 0;
            strSQL = @"INSERT INTO [dbo].[users] (
                                        [i_role_id], 
                                        [t_username], 
                                        [t_password], 
                                        [t_email], 
                                        [i_image_id], 
                                        [i_modifiedBy_id], 
                                        [b_rememberMe],
                                        [g_registrationToken],
                                        [b_isNeutral]
                                        ) VALUES (
                                        3, "
                                         + "'" + user.t_username.Replace("'", "’") + "'," +
                                           "'" + user.t_password + "'," +
                                           "'" + user.t_email + "'," +
                                            +user.i_image_id + "," +
                                           0 + "," +
                                           rememberMe + ", '" + user.g_identityToken + "'," + neutral + ")";
            strSQL += "SELECT SCOPE_IDENTITY() as i_user_id";
            try
            {
                DataRow partialRes = SearchDataRow(strSQL);
                res = int.Parse(partialRes["i_user_id"].ToString());
            }
            catch { }

            return res;
        }

        public bool I_UserImg(string t_url, int i_user_id, string t_username)
        {
            int i_image_id = 0;
            try
            {
                strSQL = @"INSERT INTO [dbo].[images] (
                                [t_url], 
                                [t_uploadedBy], 
                                [t_tag], 
                                [t_sex]
                                ) VALUES ('
                                " + t_url + "', '" + t_username + "', " +
                                    "'profiles', " +
                                    "'n') " +
                                    "SELECT SCOPE_IDENTITY() as i_image_id";
                DataRow partialRes = SearchDataRow(strSQL);
                i_image_id = int.Parse(partialRes["i_image_id"].ToString());
            }
            catch { return false; }

            try
            {
                U_UserImg(i_image_id, i_user_id);
            }
            catch { return false; }

            return true;
        }

        public int S_RandomImage(string t_tag)
        {
            strSQL = "SELECT top 1 i_image_id FROM dbo.images where t_tag = '" + t_tag + "' ORDER BY NEWID()";
            DataRow res = SearchDataRow(strSQL);
            return int.Parse(res["i_image_id"].ToString());
        }

        public string U_UserImg(int i_image_id, int i_user_id)
        {
            if (i_image_id != 0)
            {
                strSQL = "Update dbo.users " +
                    " set i_image_id = " + i_image_id +
                    " where i_user_id = " + i_user_id; ;
                ExecSQL(strSQL);
            }

            strSQL = "select t_url from dbo.images where i_image_id = " + i_image_id;

            DataRow res = SearchDataRow(strSQL);

            return res["t_url"].ToString();

        }

        public string U_UserLastLogin(int i_user_id)
        {
            strSQL = @"Update dbo.users set d_modifiedOn = convert(datetime, '" + DateTime.Now + "', 103) where i_user_id = " + i_user_id;

            ExecSQL(strSQL);

            strSQL = "Select d_modifiedOn from dbo.users where i_user_id = " + i_user_id;
            DataRow res = SearchDataRow(strSQL);

            return res["d_modifiedOn"].ToString();
        }

        public bool U_UserPassword(User u)
        {
            bool res = true;

            try
            {
                if (u.i_user_id != 0)
                {
                    strSQL = "Update dbo.users " +
                        " set t_password = '" + u.t_password + "'" +
                        " where i_user_id = " + u.i_user_id; ;
                    ExecSQL(strSQL);
                }
            }
            catch { res = false; }

            return res;
        }

        public void U_UserIsActive(string identityToken)
        {
            if (!string.IsNullOrEmpty(identityToken))
            {
                strSQL = "Update dbo.users " +
                    " set b_isActive = 1" +
                    " where g_registrationToken = '" + identityToken + "'";
                ExecSQL(strSQL);
            }
        }

        public void U_UserIdentityToken(User u)
        {
            if (u.i_user_id != 0)
            {
                strSQL = "Update dbo.users " +
                    " set g_registrationToken = '" + u.g_identityToken + "'" +
                    " where i_user_id = " + u.i_user_id;
                ExecSQL(strSQL);
            }
        }

        public void U_UserRememberBe(int i_user_id, bool rememberMe)
        {
            if (i_user_id != 0)
            {
                int intRememberMe = (rememberMe) ? 1 : 0;

                strSQL = "Update dbo.users " +
                    " set b_rememberMe = " + intRememberMe +
                    " where i_user_id = " + i_user_id;
                ExecSQL(strSQL);
            }
        }

        public int S_UserByidentityToken(string identityToken)
        {
            strSQL = "select i_user_id from dbo.users where g_registrationToken = '" + identityToken + "'";
            DataRow res = SearchDataRow(strSQL);
            return int.Parse(res["i_user_id"].ToString());
        }

        public string S_RandomName()
        {
            strSQL = "SELECT TOP 1 t_name FROM dbo.zMockDate ORDER BY NEWID()";
            DataRow res = SearchDataRow(strSQL);
            return res["t_name"].ToString();

        }
        #endregion
    }
}