using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ischidados.App_Code.Bll
{
    public class User
    {
        public int i_user_id { get; set; }
        public int i_role_id { get; set; }
        public string t_username { get; set; }
        public string t_password { get; set; }
        public string t_password_confirmation { get; set; }
        public string t_email { get; set; }
        public string t_img { get; set; }
        public string t_message_id { get; set; }
        public bool b_rememberMe { get; set; }
        public bool isOnline { get; set; }
        public int i_modified_by { get; set; }

    }

    public class Game
    {
        public int i_game_id { get; set; }
        public int i_master_id { get; set; }
        public string t_name { get; set; }
        public string t_desc { get; set; }
        public int i_createdBy_id { get; set; }
        public DateTime d_createdOn { get; set; }
        public DateTime d_modifiedOn { get { return DateTime.Now; } }
        public int i_modifiedBy_id { get; set; }
        public bool isActive { get; set; }
        public bool isOpen { get; set; }
    }

    public class UserInGame
    {
        public bool isPlayer { get; set; }
        public bool isAdmin { get; set; }
    }

    public class Image
    {
        public int i_image_id { get; set; }
        public string t_url { get; set; }
        public string t_uploadedBy { get; set; }
        public string t_tag { get; set; }
        public string t_sex { get; set; }
    }

    public class ImageFilter
    {
        public string filter { get; set; }
        public bool characters { get; set; }
        public bool communities { get; set; }
        public bool signs { get; set; }
        public bool zombie { get; set; }
    }

    public class NatureSkill
    {
        public int i_nature_skill_id { get; set; }
        public int i_nature_id { get; set; }
        public int i_skill_id { get; set; }
        public string t_nature { get; set; }
        public string t_url { get; set; }
        public string t_skill { get; set; }
        public int i_value_start { get; set; }
        public int i_value_min { get; set; }
        public int i_value_max { get; set; }
        public int i_multiplier { get; set; }
    }

    public class Trait
    {
        public int i_trait_id { get; set; }
        public string t_trait { get; set; }
    }
}
