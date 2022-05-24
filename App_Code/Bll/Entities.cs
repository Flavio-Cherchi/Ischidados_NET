using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ischidados.App_Code.Bll
{
    public enum CalendarGame
    {
            Gennaio = 1,
            Febbraio = 2,
            Marzo = 3,
            Aprile = 4,
            Maggior = 5,
            Giugno = 6,
            Luglio = 7,
            Agosto = 8,
            Settembre = 9,
            Ottobre = 10,
            Novembre = 11,
            Dicembre = 12
    }

    public class User
    {
        public int i_user_id { get; set; }
        public int i_role_id { get; set; }
        public int i_image_id { get; set; }
        public string t_username { get; set; }
        public string t_password { get; set; }
        public string t_password_confirmation { get; set; }
        public string t_email { get; set; }
        public string t_img { get; set; }
        public string t_message_id { get; set; }
        public bool b_rememberMe { get; set; }
        public bool isActive { get; set; }
        public bool isOnline { get; set; }
        public int i_modified_by { get; set; }
        public string g_identityToken { get; set; }
        public string t_createdOn { get; set; }
        public string t_modifiedOn { get; set; }
        public bool b_isNeutral { get; set; }

    }

    public class LogUser
    {
        public int i_user_id { get; set; }
        public string t_user { get; set; }
        public string t_page { get; set; }
        public DateTime d_date { get; set; }
    }

    public class LogError
    {
        public int i_logError_id { get; set; }
        public string t_desc { get; set; }
        public string t_function { get; set; }
        public string t_page { get; set; }
        public DateTime d_date { get; set; }
    }

    public class Game
    {
        public int i_game_id { get; set; }
        public int i_not_master_id { get; set; }
        public int i_master_id { get; set; }
        public int i_user_id { get; set; }
        public int i_gameUser_id { get; set; }
        public int i_image_id { get; set; }
        public int i_gameType_id { get; set; }
        public int i_intelligence_id { get; set; }
        public string t_intelligence { get; set; }
        public int i_turn_id { get; set; }
        public int i_turn { get; set; }
        public string t_name { get; set; }
        public string t_desc { get; set; }
        public string t_master { get; set; }
        public string t_master_email { get; set; }
        public int i_createdBy_id { get; set; }
        public DateTime d_createdOn { get; set; }
        public DateTime d_modifiedOn { get; set; }
        public int i_modifiedBy_id { get; set; }
        public bool isActive { get; set; }
        public string t_gameType_desc { get; set; } 
        public string t_img { get; set; }
        public string t_test { get; set; }
    }

    public class UserInGame
    {
        public bool isPlayer { get; set; }
        public bool isPlayerPending { get; set; }
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
        public bool items { get; set; }
        public bool zombie { get; set; }
        public bool profiles { get; set; }
        public bool cover { get; set; }
        public bool settlements { get; set; }
    }

    public class Message
    {
        public int i_message_id { get; set; }
        public int i_sender_id { get; set; }
        public string t_sender { get; set; }
        public string t_subject { get; set; }
        public string t_content { get; set; }
        public DateTime d_sendOn { get; set; }
        public List<Recipient> recipientList { get; set; }
    }

    public class Recipient
    {
        public int i_recipient_id { get; set; }
        public string t_username { get; set; }
        public bool b_isRead { get; set; }

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

    public class Settlement
    {
        public int i_settlement_id { get; set; }
        public int i_game_id { get; set; }
        public int i_user_id { get; set; }
        public int i_image_id { get; set; }
        public string t_img { get; set; }
        public string t_player { get; set; }
        public string t_name { get; set; }
        public string t_desc { get; set; }
        public SettlementSpecs[] settlementSpecsList { get; set; }
        public SettlementDiplomacy[] settlementDiplomacyList { get; set; }
        public string t_createdOn { get; set; }
    }

    public class SettlementSpecs
    {
        public int i_settlemenSpec_id { get; set; }
        public int i_settlement_id { get; set; }
        public int i_turn_id { get; set; }
        public int i_population { get; set; }
        public int i_food { get; set; }
        public int i_drug { get; set; }
        public int i_tool { get; set; }
        public int i_weapon { get; set; }
        public int i_hygiene { get; set; }
        public bool b_isNeutral { get; set; }
        public bool b_isDestroyed { get; set; }
    }

    public class SettlementDiplomacy
    {
        public int i_settlementDiplomacy_id { get; set; }
        public int i_first_settlement_id { get; set; }
        public int i_second_settlement_id { get; set; }
        public Diplomacy diplomacy { get; set; }
        public int i_turn_id { get; set; }
    }

    public class Diplomacy
    {
        public int i_diplomacy_id { get; set; }
        public int i_diplomacy { get; set; }
        public string t_desc { get; set; }
    }
}
