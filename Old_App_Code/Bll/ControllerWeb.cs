using Ischidados.App_Code.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

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

            User u = S_Convert_User(Dal.S_UserById(ut.i_user_id));

            if (u.t_username.ToUpper() == ut.t_username.ToUpper() && u.t_email == ut.t_email)
                res = true;

            return res;
        }
        public void ControlloUtente(User utente)
        {
            Dal.ControlloUtente(utente, false);
        }

        public Boolean isRuolo(int id, string t_ruolo)
        {
            return Dal.isRuolo(id, t_ruolo);
        }


        #endregion

        #region test

        public DataTable S_Tests()
        {
            return Dal.S_Tests();
        }
        public DataRow S_TestById(int chiave)
        {
            return Dal.S_TestById(chiave);
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

        #region games

        public DataTable S_Games()
        {
            return Dal.S_Games();
        }

        public Game S_GameById(int id)
        {
            return S_Convert_Game(Dal.S_GameById(id));
        }

        public DataRow I_Game(Game g)
        {
            return Dal.I_Game(g);
        }

        public void I_GameUser(int i_game_id, int i_user_id)
        {
            Dal.I_GameUser(i_game_id, i_user_id);
        }

        public void D_GameUser(int i_game_id, int i_user_id)
        {
            Dal.D_GameUser(i_game_id, i_user_id);
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

            }
            catch { }

            return res;
        }

        public Game S_Convert_Game(DataRow r)
        {
            Game res = new Game();

            try
            {
                res.i_game_id = int.Parse(r["i_game_id"].ToString());
                res.i_master_id = int.Parse(r["i_master_id"].ToString());
                res.t_name = r["t_name"].ToString();
                res.t_desc = r["t_desc"].ToString();
                res.d_createdOn = DateTime.Parse(r["d_createdOn"].ToString());
                res.i_createdBy_id = int.Parse(r["i_createdBy_id"].ToString());
                res.i_modifiedBy_id = int.Parse(r["i_modifiedBy_id"].ToString());
                res.isActive = bool.Parse(r["isActive"].ToString());
                res.isOpen = bool.Parse(r["isOpen"].ToString());
            }
            catch { }

            return res;
        }

        #endregion

        #region natures

        public List<NatureSkill> S_NaturesSkills(int type)
        {
            return S_Convert_Natures(Dal.S_NaturesSkills(type));
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
                res.i_nature_skill_id = int.Parse(r["i_nature_skill_id"].ToString());
                res.i_nature_id = int.Parse(r["i_nature_id"].ToString());
                res.i_skill_id = int.Parse(r["i_skill_id"].ToString());
                res.t_nature = r["t_nature"].ToString();
                res.t_url = r["t_url"].ToString();
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

        #region users

        public DataTable S_Users(int i_role_id)
        {
            return Dal.S_Users(i_role_id);
        }

        public User S_UserById(int id)
        {
            return S_Convert_User(Dal.S_UserById(id));
        }

        public User S_User_One(User user)
        {
            return S_Convert_User(Dal.S_UserByObject(user));
        }

        public bool I_User(User user)
        {
            return Dal.I_User(user);
        }

        public User S_Convert_User(DataRow r)
        {
            User res = new User();

            try
            {
                res.i_user_id = int.Parse(r["i_user_id"].ToString());
                res.i_role_id = int.Parse(r["i_role_id"].ToString());
                res.t_username = r["t_username"].ToString();
                res.t_email = r["t_email"].ToString();
                res.t_img = r["t_img"].ToString();
                res.b_rememberMe = bool.Parse(r["b_rememberMe"].ToString());
            }
            catch { }

            return res;
        }

        #endregion
    }
}