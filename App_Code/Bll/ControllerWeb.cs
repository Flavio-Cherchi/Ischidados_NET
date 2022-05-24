using Ischidados.App_Code.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.Net.Mail;
using System.IO;

namespace Ischidados.App_Code.Bll
{
    public class ControllerWeb
    {
        #region base
        public ControllerWeb()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private DalWeb DalWeb;

        protected DalWeb Dal
        {
            get
            {
                if (DalWeb == null)
                {
                    DalWeb = new DalWeb();
                }
                return DalWeb;
            }
        }

        public bool CheckUser(User ut)
        {
            bool res = false;

            try
            {
                User u = S_Convert_User(Dal.S_UserById(ut.i_user_id));

                if (u.t_username.ToUpper() == ut.t_username.ToUpper() && u.t_email == ut.t_email)
                    res = true;

                return res;
            }
            catch { return res; }

        }

        #endregion

        #region characters

        public DataTable S_Characters()
        {
            return Dal.S_Characters();
        }
        public DataRow S_CharacterById(int id)
        {
            return Dal.S_CharacterById(id);
        }

        #endregion

        #region cookies

        public void StoreInCookie(
            string cookieName,
            string value,
            DateTime? expirationDate,
            bool httpOnly = false,
            bool secure = false)
        {
            // NOTE: we have to look first in the response, and then in the request.
            // This is required when we update multiple keys inside the cookie.
            HttpCookie cookie = HttpContext.Current.Response.Cookies.AllKeys.Contains(cookieName)
                ? HttpContext.Current.Response.Cookies[cookieName]
                : HttpContext.Current.Request.Cookies[cookieName];

            if (cookie == null) cookie = new HttpCookie(cookieName);
            //if (!String.IsNullOrEmpty(keyName)) cookie.Values.Set(keyName, value);
            cookie.Value = value;
            //else cookie.Value = value;
            if (expirationDate.HasValue) cookie.Expires = expirationDate.Value;
            cookie.Domain = "ischidados.it";
            if (httpOnly) cookie.HttpOnly = true;
            cookie.Secure = secure;
            //cookie.SameSite = sameSite;
            HttpContext.Current.Response.Cookies.Set(cookie);
        }

        public void RemoveCookie(string cookieName)
        {
            HttpContext.Current.Response.Cookies[cookieName].Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Request.Cookies[cookieName].Expires = DateTime.Now.AddYears(-1);
        }

        #endregion

        #region forum

        public DataTable S_Forum_Sections()
        {
            return Dal.S_Forum_Sections();
        }

        #endregion

        #region dropdown
        public void DD_Users(ref DropDownList res)
        {
            res.DataSource = Dal.DD_Users();
            res.DataTextField = "DataTextField";
            res.DataValueField = "DataValueField";
            res.DataBind();
            res.Items.Insert(0, new ListItem("Primi cento", "0"));
            res.SelectedValue = "0";
        }

        public void DD_Multiple_Users(ref ListBox res)
        {
            res.DataSource = Dal.DD_Users();
            res.DataTextField = "DataTextField";
            res.DataValueField = "DataValueField";
            res.DataBind();
        }
        #endregion

        #region games
        public DataTable S_Games(Game g)
        {
            return Dal.S_Games(g);
        }

        public Game S_GameById(int id)
        {
            return S_Convert_Game(Dal.S_GameById(id));
        }

        public List<Game> S_GamesByUser(int i_user_id, bool isMaster)
        {
            return S_Convert_Games(Dal.S_GamesByUser(i_user_id, isMaster));
        }

        public DataRow S_GameCount()
        {
            return Dal.S_GameCount();
        }

        public int I_Game(Game g)
        {
            return Dal.I_Game(g);
        }

        public void I_GameUser(int i_game_id, int i_user_id, bool isAccepted)
        {
            Dal.I_GameUser(i_game_id, i_user_id, isAccepted);
        }

        public void D_GameUser(int i_game_id, int i_user_id)
        {
            Dal.D_GameUser(i_game_id, i_user_id);
        }

        public int I_Game_Turn(int i_game_id)
        {
            return Dal.I_Game_Turn(i_game_id);
        }

        public void D_Game(int i_game_id)
        {
            Dal.D_Game(i_game_id);
        }

        public UserInGame S_IsInGame(int i_game_id, int i_user_id)
        {
            return S_Convert_UserInGame(Dal.S_IsInGame(i_game_id, i_user_id));
        }

        public UserInGame S_Convert_UserInGame(DataRow r)
        {
            UserInGame res = new UserInGame();

            try
            {
                res.isAdmin = (int.Parse(r["isAdmin"].ToString()) > 0) ? true : false;
                res.isPlayer = (int.Parse(r["isPlayer"].ToString()) > 0) ? true : false;
                res.isPlayerPending = (int.Parse(r["isPlayerPending"].ToString()) > 0) ? true : false;

            }
            catch { }

            return res;
        }

        public Game S_Convert_Game(DataRow r)
        {
            Game res = new Game();

            //From all tables and views
            try
            {
                res.i_game_id = int.Parse(r["i_game_id"].ToString());
                res.i_master_id = int.Parse(r["i_master_id"].ToString());
                res.t_name = r["t_name"].ToString();
                res.t_desc = r["t_desc"].ToString();
                res.d_modifiedOn = DateTime.Parse(r["d_modifiedOn"].ToString());
            }
            catch { };

            //From v_gamesList
            try
            {
                res.t_img = r["t_img"].ToString();
                res.t_gameType_desc = r["tipo"].ToString();
                res.t_master_email = r["email"].ToString();
                res.t_master = r["master"].ToString();
                res.i_turn_id = int.Parse(r["i_turn_id"].ToString());
                res.i_turn = int.Parse(r["turno attuale"].ToString());
                res.i_intelligence_id = int.Parse(r["i_intelligence_id"].ToString());
                res.t_intelligence = r["t_intelligence"].ToString();
            }
            catch { };

            //From dbo.games and v_gamesbyuser
            try
            {
                res.d_createdOn = DateTime.Parse(r["d_createdOn"].ToString());
                res.i_createdBy_id = int.Parse(r["i_createdBy_id"].ToString());
                res.i_modifiedBy_id = int.Parse(r["i_modifiedBy_id"].ToString());
                res.isActive = bool.Parse(r["b_isActive"].ToString());
                res.i_gameType_id = int.Parse(r["i_gameType_id"].ToString());
                res.t_gameType_desc = Dal.S_GameType(res.i_gameType_id);
                res.i_game_id = int.Parse(r["i_gameType_id"].ToString());
                res.i_intelligence_id = int.Parse(r["i_intelligence_id"].ToString());
                res.t_intelligence = r["t_intelligence"].ToString();
            }
            catch { };

            //From for v_gamesbyuser
            try
            {
                res.i_user_id = int.Parse(r["i_gameType_id"].ToString());
                res.i_gameUser_id = int.Parse(r["i_gameType_id"].ToString());
            }
            catch { };

            return res;
        }

        public List<Game> S_Convert_Games(DataTable dt)
        {
            List<Game> res = new List<Game>();

            foreach (DataRow dr in dt.Rows)
            {
                res.Add(S_Convert_Game(dr));
            }

            return res;
        }

        #endregion

        #region grounds
        public DataTable S_Grounds(string parameters)
        {
            return Dal.S_Grounds(parameters);
        }
        #endregion

        #region images

        public List<Image> S_Images(ImageFilter f)
        {
            return S_Convert_Images(Dal.S_Images(f));
        }

        public List<Image> S_Convert_Images(DataTable dt)
        {
            List<Image> res = new List<Image>();

            foreach (DataRow dr in dt.Rows)
            {
                res.Add(S_Convert_Image(dr));
            }

            return res;
        }

        public Image S_Convert_Image(DataRow r)
        {
            Image res = new Image();

            try
            {
                res.i_image_id = int.Parse(r["i_image_id"].ToString());
                res.t_url = r["t_url"].ToString();
                res.t_uploadedBy = r["t_uploadedBy"].ToString();
                res.t_tag = r["t_tag"].ToString();
                res.t_sex = r["t_sex"].ToString();
            }
            catch { }

            return res;
        }

        public Image S_ImageById(int id)
        {
            return S_Convert_Image(Dal.S_ImageById(id));
        }

        public void I_Image(Image g)
        {
            Dal.I_Image(g);
        }

        public void U_Image(Image g)
        {
            Dal.U_Image(g);
        }

        public void D_Image(int id)
        {
            Dal.D_Image(id);
        }
        #endregion

        #region logs
        public void I_LogError(LogError logError)
        {
            Dal.I_LogError(logError);
        }

        public List<LogError> S_LogErrors()
        {
            List<LogError> resList = new List<LogError>();
            LogError res = new LogError();
            DataTable partialRes =  Dal.S_LogErrors();

            foreach (DataRow dr in partialRes.Rows)
            {
                res.i_logError_id = int.Parse(dr["i_logError_id"].ToString());
                res.t_desc = dr["t_desc"].ToString();
                res.t_page = dr["t_page"].ToString();
                res.t_function = dr["t_function"].ToString();
                res.d_date = DateTime.Parse(dr["d_date"].ToString());

                resList.Add(res);
            }

            return resList;
        }

        public void I_LogUser(LogUser logUser)
        {
            Dal.I_LogUser(logUser);
        }

        public List<LogUser> S_LogUsers(int i_user_id)
        {
            List<LogUser> resList = new List<LogUser>();
            
            DataTable partialRes = Dal.S_LogUsers(i_user_id);

            foreach (DataRow dr in partialRes.Rows)
            {
                LogUser res = new LogUser();
                res.t_user = dr["t_user"].ToString();
                res.i_user_id = int.Parse(dr["i_user_id"].ToString());
                res.t_page = dr["t_page"].ToString();
                res.d_date = DateTime.Parse(dr["d_date"].ToString());

                resList.Add(res);
            }

            return resList;
        }
        #endregion

        #region messages

        public int LoadLastMessageId(int i_user_id)
        {
            DataTable dt = new DataTable();
            dt = S_Messages_Received(i_user_id, false);

            return (dt.Rows.Count > 0) ? int.Parse(dt.Rows[0][5].ToString()) : 0;
        }

        public Message S_Message(int i_message_id)
        {
            Message res = new Message();

            DataRow partialRes = Dal.S_Message(i_message_id);

            res.i_message_id = int.Parse(partialRes["i_message_id"].ToString());
            res.i_sender_id = int.Parse(partialRes["i_sender_id"].ToString());
            res.t_sender = partialRes["t_sender"].ToString();
            res.t_subject = partialRes["t_subject"].ToString();
            res.t_content = partialRes["t_content"].ToString();
            res.d_sendOn = DateTime.Parse(partialRes["d_sendOn"].ToString());

            DataTable partialSubRes = Dal.S_MessageRecipient(i_message_id);
            List<Recipient> tempRecipientList = new List<Recipient>();

            foreach (DataRow dr in partialSubRes.Rows)
            {
                Recipient r = new Recipient();
                r.i_recipient_id = int.Parse(dr["i_recipient_id"].ToString());
                r.t_username = dr["t_username"].ToString();
                r.b_isRead = (int.Parse(dr["b_isRead"].ToString()) == 1) ? true : false;

                tempRecipientList.Add(r);
            }

            res.recipientList = tempRecipientList;
            return res;
        }

        public DataTable S_Messages_Received(int i_user_id, bool checkIfRead)
        {
            return Dal.S_Messages_Received(i_user_id, checkIfRead);
        }

        public int S_Messages_Check_Unread(int i_user_id)
        {
            return Dal.S_Messages_Check_Unread(i_user_id);
        }

        public DataTable S_Messages_Sent(int i_user_id)
        {
            return Dal.S_Messages_Sent(i_user_id);
        }

        public DataRow I_Message(Message m)
        {
            return Dal.I_Message(m);
        }

        public void U_MessageIsRead(int i_message_id, int i_recipient_id)
        {
            Dal.U_MessageIsRead(i_message_id, i_recipient_id);
        }

        public void D_MessageForSender(int i_message_id)
        {
            Dal.D_MessageForSender(i_message_id);
        }

        public void D_MessageForRecipient(int i_message_id, int i_recipient_id)
        {
            Dal.D_MessageForRecipient(i_message_id, i_recipient_id);
        }

        #endregion

        #region natures

        public List<NatureSkill> S_NaturesSkills(int type, int i_nature_id)
        {
            return S_Convert_Natures(Dal.S_NaturesSkills(type, i_nature_id));
        }

        public DataTable S_Traits()
        {
            return Dal.S_Traits();
        }

        public List<NatureSkill> S_Convert_Natures(DataTable dt)
        {
            List<NatureSkill> res = new List<NatureSkill>();

            foreach (DataRow dr in dt.Rows)
            {
                res.Add(S_Convert_Nature(dr));
            }

            return res;
        }

        public NatureSkill S_Convert_Nature(DataRow r)
        {
            NatureSkill res = new NatureSkill();

            try
            {
                res.i_nature_id = int.Parse(r["i_nature_id"].ToString());
                res.t_nature = r["t_nature"].ToString();
                res.t_url = r["t_url"].ToString();
            }
            catch { }

            try
            {
                res.i_nature_skill_id = int.Parse(r["i_nature_skill_id"].ToString());
                res.i_skill_id = int.Parse(r["i_skill_id"].ToString());
                res.t_skill = r["t_skill"].ToString();
                res.i_value_start = int.Parse(r["i_value_start"].ToString());
                res.i_value_min = int.Parse(r["i_value_min"].ToString());
                res.i_value_max = int.Parse(r["i_value_max"].ToString());
                res.i_multiplier = int.Parse(r["i_multiplier"].ToString());
            }
            catch { }

            return res;
        }

        #endregion

        #region sendMail

        public bool SendMail(string recipient, string subject, string body)
        {
            bool res = false;
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("info@ischidados.it", "Ischidados GdR");
            //La proprietà .To è una collezione di destinatari,
            //quindi possiamo addizionare quanti destinatari vogliamo.
            msg.To.Add(recipient);
            msg.Subject = subject;
            //Imposto contenuto
            string firm = "<br/><br/>Grazie, <br/> Ischidados GdR <br/><br/><br/><hr><center>Questa è una e-mail automatica, non rispondere. <br/>";
            body += firm;
            string corpoMail = BodyMail();
            corpoMail = BodyMail().Replace("BODY", body);
            msg.Body = corpoMail;
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.ischidados.it");
            //Possiamo impostare differenti metodi di spedizione.
            //Imposta consegna diretta.
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                smtp.Send(msg);
                res = true;
            } catch { }

            return res;
        }

        public string BodyMail()
        {
            string res = @"

<table>
<thead>
<tr>
<th><img style='display: block; margin - left: auto; margin - right: auto; margin: black 1px solid; border-radius:5px;' src='https://www.ischidados.it/Assets/img/Base/logo.jpg' alt='Ischi' height='350' /></th>
</tr>
</thead>
<tbody>
<tr>
<td style = 'text-align: justify;'> BODY </td>
 </tr>
 <tr>
 <td style='text-align: center;'> &copy; 2021 - Ischidados </td>
      </tr>
      </tbody>
      </table>

      ";

            return res;
        }

        public bool SendMailRegistration(User ut, bool firstMail)
        {
            //mailTemplate -> mailregistrationTemplate.html. Reverse with "URLHERE"

            #region betterClosed

            //string mailRegistrationTemplate = "";
            #endregion

            //string mailRegistrationTemplate = File.ReadAllText("~/Assets/mailTemplate/mailRegistrationTemplate.html");

            string subject = firstMail ? "Ischidados GdR - Conferma registrazione!" : "Ischidados GdR - Registrazione confermata!";
            string body = firstMail ? "<br /> Ciao " + ut.t_username + ", <br /> ricevi questo messaggio a seguito della tua richiesta di iscrizione ad Ischidados GdR. Se non hai fatto tu la richiesta, cancella pure la mail, altrimenti clicca <a href='www.ischidados.it/core/users/login.aspx?registration=" + ut.g_identityToken + "'>qui</a>" : "Ciao! Il tuo account su Ischidados Gdr è stato confermato, benvenuto!";

            //string body = firstMail ? mailRegistrationTemplate : "Account confermato, benvenuto!";

            return SendMail(ut.t_email, subject, body);
        }

        public bool SendMailRecoveryPassword(string recipient, string b_registrationToken, string username)
        {
            string subject = "Ischidados GdR - Modifica password";
            string body = "< br /> Ciao " + username + ", < br /> ricevi questo messaggio a seguito di una richiesta di modifica della tua password. Se non hai fatto tu la richiesta, cancella pure la mail, altrimenti clicca <a href='www.ischidados.it/core/users/modifyPassword.aspx?passwordRecovery=" + b_registrationToken + "'>qui</a> per completare la modifica della password.";

            return SendMail(recipient, subject, body);
        }

        public bool SendMailNotificationMessage(List<Recipient> recipientList, int i_message_id, string t_subject, string t_sender)
        {
            bool res = true;

            try
            {
                foreach (Recipient rec in recipientList)
                {
                    User u = S_UserById(rec.i_recipient_id);
                    string subject = "Ischidados GdR - Notifica nuovo messaggio";
                    string body = "<br />Ciao " + u.t_username + ", <br /> hai ricevuto un nuovo messaggio su Ischidados GdR: '<b>" + t_subject + "</b>', da parte di <b>" + t_sender + "</b>.<br/> Clicca <a href='www.ischidados.it/core/messages/messages.aspx?id=" + i_message_id + "&msg=received'>qui</a> per leggerlo!";
                    SendMail(u.t_email, subject, body);
                }
            }
            catch { res = false; }

            return res;
        }

        public bool SendMailSubscribe(string t_username, int i_game_id, bool isAccepted)
        {
            Game g = S_GameById(i_game_id);
            User master = S_UserById(g.i_master_id);

            string subject = "Ischidados GdR - Notifica iscrizione giocatore";
            string body = "Ciao " + master.t_username + ", <br/>";

            if (isAccepted)
            {
                body += t_username + " si è iscritto alla partita pubblica <b>" + g.t_name + "</b>";
            } else
            {
                body += t_username + " ha fatto richiesta di partecipazione per la partita privata <b>" + g.t_name + "</b>";
            }

            body += ", di cui tu sei master. Puoi gestire la sua iscrizione nella <a href='www.ischidados.it/Core/Games/game.aspx?id=" + i_game_id + ">pagina della partita</a>, una volta effettuato il login.";

            return SendMail(master.t_email, subject, body);
        }

        public bool SendMailUnsubscribe(string t_username, int i_game_id)
        {
            Game g = S_GameById(i_game_id);
            User master = S_UserById(g.i_master_id);

            string subject = "Ischidados GdR - Notifica giocatore disiscritto";
            string body = "Ciao " + master.t_username + ", <br/>";

            body += t_username + " ha ritirato la sua iscrizione per la partita <b>" + g.t_name + "</b>";


            body += ", di cui tu sei master. Puoi visualizzare l'elenco degli iscritti nella <a href='www.ischidados.it/Core/Games/game.aspx?id=" + i_game_id + ">pagina della partita</a>, una volta effettuato il login.";

            return SendMail(master.t_email, subject, body);
        }

        public bool SendMailGameDeletedNotification(string t_game_name, string t_player_name, string recipient)
        {
            string subject = "Ischidados GdR - Notifica partita eliminata";
            string body = "Ciao " + t_player_name + ", <br/>";

            body += "La partita " + t_game_name + " è stata eliminata. Tutti i dati sono stati cancellati, compresi la tua comunità e i tuoi personaggi. Per giocare a una nuova partita, puoi crearne una o visualizzare l'elenco delle <a href='www.ischidados.it/Core/Games/gamesList.aspx'>partite in corso</a>, una volta effettuato il login.";

            return SendMail(recipient, subject, body);
        }


        #endregion

        #region settlements
        public List<Settlement> S_SettlementsByGame(Game g)
        {
            return S_Convert_Settlements(Dal.S_SettlementsByGame(g));
        }

        public Settlement S_SettlementById(int i_settlement_id)
        {
            return S_Convert_Settlement(Dal.S_SettlementById(i_settlement_id));
        }

        public List<Settlement> S_SettlementHystoryById(int i_settlement_id)
        {
            return S_Convert_Settlements(Dal.S_SettlementHystoryById(i_settlement_id));
        }

        public void I_settlement(Settlement s)
        {
            Dal.I_settlement(s);
        }

        public void U_settlement(SettlementSpecs ss, SettlementDiplomacy[] sdList)
        {
            Dal.U_settlement(ss, sdList);
        }

        public List<Settlement> S_Convert_Settlements(DataTable dt)
        {
            List<Settlement> res = new List<Settlement>();

            foreach (DataRow dr in dt.Rows)
            {
                res.Add(S_Convert_Settlement(dr));
            }

            return res;
        }

        public Settlement S_Convert_Settlement(DataRow r)
        {
            Settlement res = new Settlement();
            res.settlementSpecsList = new SettlementSpecs[] {
            new SettlementSpecs {}
            };

            if (r != null)
            {
                try
                {
                    res.i_settlement_id = int.Parse(r["i_settlement_id"].ToString());
                    res.settlementSpecsList[0].i_settlement_id = int.Parse(r["i_settlement_id"].ToString());
                    res.settlementSpecsList[0].i_turn_id = int.Parse(r["i_turn_id"].ToString());
                    res.i_game_id = int.Parse(r["i_game_id"].ToString());
                    res.i_user_id = int.Parse(r["i_user_id"].ToString());
                    res.i_image_id = int.Parse(r["i_image_id"].ToString());
                    res.t_img = r["t_img"].ToString();
                    res.t_player = r["t_player"].ToString();
                    res.t_name = r["t_name"].ToString();
                    res.t_desc = r["t_desc"].ToString();
                    res.t_createdOn = DateTime.Parse(r["d_createdOn"].ToString()).Date.ToString().Substring(0, 10); ;
                    res.settlementSpecsList[0].i_settlemenSpec_id = int.Parse(r["i_image_id"].ToString());
                    res.settlementSpecsList[0].i_population = int.Parse(r["i_population"].ToString());
                    res.settlementSpecsList[0].i_food = int.Parse(r["i_food"].ToString());
                    res.settlementSpecsList[0].i_drug = int.Parse(r["i_drug"].ToString());
                    res.settlementSpecsList[0].i_tool = int.Parse(r["i_tool"].ToString());
                    res.settlementSpecsList[0].i_weapon = int.Parse(r["i_weapon"].ToString());
                    res.settlementSpecsList[0].i_hygiene = int.Parse(r["i_hygiene"].ToString());

                    res.settlementSpecsList[0].b_isNeutral = r["b_isNeutral"].ToString() == "1" ? true : false;
                    res.settlementSpecsList[0].b_isDestroyed = r["b_isDestroyed"].ToString() == "1" ? true : false;

                }
                catch { }
            }


            return res;
        }

        #endregion

        #region test

        public DataTable S_Tests()
        {
            return Dal.S_Tests();
        }
        #endregion

        #region users

        public DataTable S_Users(int i_role_id)
        {
            return Dal.S_Users(i_role_id);
        }

        public User S_UserById(int id)
        {
            return S_Convert_User(Dal.S_UserById(id));
        }

        public List<User> S_UsersByGame(int i_game_id, bool isAccepted)
        {
            return S_Convert_Users(Dal.S_UsersByGame(i_game_id, isAccepted));
        }


        public string S_UserImg(int i_image_id)
        {
            return Dal.S_UserImg(i_image_id);
        }

        public User S_User_One(User user)
        {
            return S_Convert_User(Dal.S_UserByObject(user));
        }

        public User S_UserUsername(string username)
        {
            return S_Convert_User(Dal.S_UserUsername(username));
        }

        public User S_UserByMail(string email)
        {
            return S_Convert_User(Dal.S_UserByMail(email));
        }

        public int I_User(User user)
        {
            return Dal.I_User(user);
        }

        public bool I_UserImg(string t_url, int i_user_id, string t_username)
        {
            return Dal.I_UserImg(t_url, i_user_id, t_username);
        }

        public int S_RandomImage(string t_tag)
        {
            return Dal.S_RandomImage(t_tag);
        }

        public string U_UserImg(int i_image_id, int i_user_id)
        {
            return Dal.U_UserImg(i_image_id, i_user_id);
        }

        public string U_UserLastLogin(int i_user_id)
        {
            return Dal.U_UserLastLogin(i_user_id);
        }

        public bool U_UserPassword(User u)
        {
            return Dal.U_UserPassword(u);
        }

        public void U_UserIsActive(string identityToken)
        {
            Dal.U_UserIsActive(identityToken);
        }

        public void U_UserIdentityToken(User u)
        {
            Dal.U_UserIdentityToken(u);
        }

        public void U_UserRememberBe(int i_user_id, bool rememberMe)
        {
            Dal.U_UserRememberBe(i_user_id, rememberMe);
        }

        public int S_UserByidentityToken(string identityToken)
        {
            return Dal.S_UserByidentityToken(identityToken);
        }

        public List<User> S_Convert_Users(DataTable dt)
        {
            List<User> res = new List<User>();

            foreach (DataRow dr in dt.Rows)
            {
                res.Add(S_Convert_User(dr));
            }

            return res;
        }

        public User S_Convert_User(DataRow r)
        {
            User res = new User();

            if (r != null)
            {
                try
                {
                    res.i_user_id = int.Parse(r["i_user_id"].ToString());
                    res.i_role_id = int.Parse(r["i_role_id"].ToString());
                    res.t_username = r["t_username"].ToString();
                    res.t_email = r["t_email"].ToString();
                    res.i_image_id = int.Parse(r["i_image_id"].ToString());
                    res.t_img = Dal.S_UserImg(int.Parse(r["i_image_id"].ToString()));
                    res.b_rememberMe = r["b_rememberMe"].ToString() == "1" ? true : false;
                    res.isActive = r["b_isActive"].ToString() == "1" ? true : false;
                    res.g_identityToken = r["g_registrationToken"].ToString();
                    res.t_createdOn = DateTime.Parse(r["d_createdOn"].ToString()).Date.ToString().Substring(0, 10); ;
                    res.t_modifiedOn = DateTime.Parse(r["d_modifiedOn"].ToString()).Date.ToString().Substring(0, 10); ;
                }
                catch { }
            }


            return res;
        }

        public int S_Neutral_User()
        {
            User u = new User();
            u.t_username = Dal.S_RandomName() + "_neutrale";
            u.t_password = Guid.NewGuid().ToString();
            u.t_email = "neutral@ischidados.it";
            u.i_image_id = 388;
            u.g_identityToken = u.t_password;
            u.b_isNeutral = true;
            return Dal.I_User(u);
        }

        #endregion
    }
}