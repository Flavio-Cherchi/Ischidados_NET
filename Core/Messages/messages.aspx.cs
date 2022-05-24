using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ischidados;
using System.Data;
using System.IO;
using Ischidados.App_Code.Bll;
using System.Collections.Generic;
using System.Web;

public partial class messages : BasePage
{
    public User u { get; set; }
    public Message singleMessage { get; set; } = new Message();
    public int i_last_message_received { get; set; }
    public int i_last_message_sent { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        u = SessionMandatory(true, "Messaggi");
        int i_message_id = 0;

        i_last_message_received = LoadGridViewReceived(false);
        i_last_message_sent = LoadGridViewSent();

        if (!IsPostBack)
        {
            BllControllerWeb.DD_Multiple_Users(ref ddRecipients);
            foreach (ListItem item in ddRecipients.Items)
            {
                item.Attributes.Add("class", "form-control");
            }
        }

        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Request.QueryString["msg"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Request.QueryString["resp"] == null)
        {
            GvSent.CssClass = ("table table-bordered table-striped table-dark animate__animated  animate__fadeInDown");
            GvReceived.CssClass = ("table table-bordered table-striped table-dark animate__animated  animate__fadeInDown");
        } else
        {
            GvSent.CssClass = ("table table-bordered table-striped table-dark showOnlyInCell animate__animated  fadeOutUp");
            GvReceived.CssClass = ("table table-bordered table-striped table-dark showOnlyInCell animate__animated  fadeOutUp");
        }

        string typeOfMessage = Request.QueryString["msg"].ToString();

        if (Request.QueryString["id"] == "0")
        {
            Visibility(2);
            try
            {
                i_message_id = int.Parse(Request.QueryString["id"].ToString());
                if (i_message_id != 0)
                    VisibilityCentralMessage(int.Parse(Request.QueryString["id"].ToString()), true);

                if (Request.QueryString["to"] != null)
                {
                    try
                    {
                        string i_recipient_id = Request.QueryString["to"].ToString();

                        foreach (ListItem item in ddRecipients.Items)
                        {
                            if (item.Value == i_recipient_id)
                            {
                                item.Selected = true;
                                break;
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { Response.Redirect("~/Default.aspx"); }
        } else
        {
            switch (typeOfMessage)
            {
                case "received":
                    if(Request.QueryString["read"] != null)
                    {
                        if(Request.QueryString["read"] != "1")
                        {
                            int i_message_received = int.Parse(Request.QueryString["id"].ToString());
                            int i_recipient_id = u.i_user_id;
                            BllControllerWeb.U_MessageIsRead(i_message_received, i_recipient_id);
                            Response.Redirect("~/Core/messages/messages.aspx?id=" + Request.QueryString["id"] + "&msg=received&resp=1&read=1");
                        }
                    }
                    Visibility(0);
                    if (BllControllerWeb.S_Messages_Check_Unread(int.Parse(Session["i_user_id"].ToString())) > 0)
                    {
                        i_message_id = LoadGridViewReceived(true) > 0 ? LoadGridViewReceived(true) : LoadGridViewReceived(false);

                        VisibilityCentralMessage(i_message_id, false);
                        LoadGridViewReceived(false);
                    } else
                    {
                        VisibilityCentralMessage(int.Parse(Request.QueryString["id"].ToString()), false);
                    }
                    break;
                case "sent":
                    Visibility(1);
                    VisibilityCentralMessage(int.Parse(Request.QueryString["id"].ToString()), false);
                    break;
                case "new":
                    Visibility(2);
                    try
                    {
                        i_message_id = int.Parse(Request.QueryString["id"].ToString());
                        if (i_message_id != 0)
                            VisibilityCentralMessage(int.Parse(Request.QueryString["id"].ToString()), true);
                    }
                    catch { Response.Redirect("~/Default.aspx"); }
                    break;
                default:
                    break;
            }
        }
       




    }

    protected void CheckQueryString()
    {
        if (Request.QueryString["id"] != null)
        {
            string type = Request.QueryString["id"].ToString();

        }
    }

    protected void ProcessCommand(object sender, CommandEventArgs ea)
    {
        int i_message_id = 0;
        switch (ea.CommandName)
        {
            case "receivedMessages":
                Response.Redirect("~/Core/messages/messages.aspx?id=" + i_last_message_received + "&msg=received");
                break;
            case "sentMessages":
                Response.Redirect("~/Core/messages/messages.aspx?id=" + i_last_message_sent + "&msg=sent");
                break;
            case "newMessage":
                Response.Redirect("~/Core/messages/messages.aspx?id=0&msg=new");
                break;
            case "sendMessage":
                if (!CheckError())
                {
                    SendMessage();
                    i_last_message_sent = LoadGridViewSent();
                    Response.Redirect("~/Core/messages/messages.aspx?id=" + i_last_message_sent + "&msg=sent");
                }
                break;
            case "reply":
                i_message_id = int.Parse(hidI_Message_id.Value);
                Response.Redirect("~/Core/messages/messages.aspx?id=" + i_message_id  + "&msg=new");
                break;
            case "delete":
                i_message_id = int.Parse(hidI_Message_id.Value);

                if(btnReply.Text != "Rispondi")
                {
                    BllControllerWeb.D_MessageForSender(i_message_id);
                    i_last_message_sent = LoadGridViewSent();
                    Response.Redirect("~/Core/messages/messages.aspx?id=" + i_last_message_sent + "&msg=sent");
                } else
                {
                    BllControllerWeb.D_MessageForRecipient(i_message_id, u.i_user_id);
                    i_last_message_received = LoadGridViewReceived(false);
                    Response.Redirect("~/Core/messages/messages.aspx?id=" + i_last_message_received + "&msg=received");
                }

                break;
        }
    }

    protected void SendMessage()
    {
        bool toSend = false;
        Message m = new Message();
        m.i_sender_id = u.i_user_id;
        m.t_sender = u.t_username;
        m.t_subject = t_subject.Text;
        m.t_content = t_content.Text;
        m.d_sendOn = DateTime.Now;

        List<Recipient> intTest = new List<Recipient>();
        foreach (ListItem li in ddRecipients.Items)
        {
            Recipient singleRec = new Recipient();

            if (li.Selected)
            {
                singleRec.i_recipient_id = int.Parse(li.Value);
                intTest.Add(singleRec);
                toSend = true;
            }
        }

        m.recipientList = intTest;
        if (toSend)
        {
            BllControllerWeb.I_Message(m);
            BllControllerWeb.SendMailNotificationMessage(intTest, i_last_message_sent, m.t_subject, m.t_sender);
        }

    }

    protected int LoadGridViewReceived(bool checkIfRead)
    {
        DataTable dt = new DataTable();
        newMessage.Visible = false;
        btnNewMessage.CssClass.Replace("showOnlyInCell", "");

        dt = BllControllerWeb.S_Messages_Received(u.i_user_id, checkIfRead);
        GvReceived.DataSource = dt;
        GvReceived.DataBind();

        
        foreach (GridViewRow row in GvReceived.Rows)
        {
            HyperLink hplink = ((HyperLink)row.Cells[0].Controls[0]);
            string textval = hplink.NavigateUrl;
            if(hplink.NavigateUrl != "1")
            {
                row.Cells[0].Attributes.Add("class", "colorwarningNotRead");
            } else
            {
                row.Cells[0].Attributes.Add("class", "colorwarningRead");
            }
        }

        if (GvReceived.Rows.Count > 0)
        {
            GvReceived.UseAccessibleHeader = true;
            GvReceived.HeaderRow.TableSection = TableRowSection.TableHeader;

            return int.Parse(dt.Rows[0][5].ToString());
        }

        btnReceivedMessages.Visible = false;
        return 0;
    }

    protected void GvReceived_OnRowDataBound(Object Sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            //HiddenField hidIsRead = (HiddenField)e.Row.FindControl("hidIsRead");
            //var heff = hidIsRead.Value;

            //if (hidIsRead.Value != "0")
            //{
            //    e.Row.Attributes.Add("class", "colorwarningNotRead");
            //} else
            //{
            //}
        }
    }

    protected int LoadGridViewSent()
    {
        DataTable dt = new DataTable();
        newMessage.Visible = false;
        btnNewMessage.CssClass.Replace("showOnlyInCell", "");

        dt = BllControllerWeb.S_Messages_Sent(u.i_user_id);
        GvSent.DataSource = dt;
        GvSent.DataBind();
        if (GvSent.Rows.Count > 0)
        {
            GvSent.UseAccessibleHeader = true;
            GvSent.HeaderRow.TableSection = TableRowSection.TableHeader;

            return int.Parse(dt.Rows[0][4].ToString());
        }

        btnSentMessages.Visible = false;
        return 0;
    }

    protected void VisibilityCentralMessage(int i_message_id, bool newMessage)
    {
        if (!newMessage)
        {
            singleMessage = (i_message_id != 0) ? BllControllerWeb.S_Message(i_message_id) : BllControllerWeb.S_Message(singleMessage.i_message_id);
            hidI_Message_id.Value = singleMessage.i_message_id.ToString();
            lblSender.Text = "Da: <a class=\"borderedAccount\" href=\"/core/users/profile.aspx?id=" + singleMessage.i_sender_id + "\">" + singleMessage.t_sender + "</a>";
            string recipients = "Destinatari: ";
            foreach (Recipient rec in singleMessage.recipientList)
            {
                recipients += "<a class=\"borderedAccount\" href=\"/core/users/profile.aspx?id=" + rec.i_recipient_id + "\">" + rec.t_username + "</a> ";
            }
            lblRecipient.Text = recipients;
            lblSubject.Text = "Oggetto: " + singleMessage.t_subject;
            lblContent.Text = singleMessage.t_content;
        } else
        {
            Message reply = BllControllerWeb.S_Message(i_message_id);
            t_subject.Text = "Re: " + reply.t_subject;

            if(btnReply.Text != "Inoltra")
                ddRecipients.SelectedValue = reply.i_sender_id.ToString();
        }
    }

    protected void Visibility(int type)
    {
        btnReceivedMessages.Attributes.Remove("CssClass");
        btnSentMessages.Attributes.Remove("CssClass");
        btnNewMessage.Attributes.Remove("CssClass");

        switch (type)
        {
            //Received messages
            case 0:
                btnReply.Text = "Rispondi";
                GvReceived.Visible = true;
                GvSent.Visible = false;
                btnReceivedMessages.CssClass = ("btn btn-warning btn-block");
                btnSentMessages.CssClass = ("btn btn-dark btn-block");
                btnNewMessage.CssClass = ("btn btn-dark btn-block");
                break;
            //Sent messages
            case 1:
                btnReply.Text = "Inoltra";
                GvReceived.Visible = false;
                GvSent.Visible = true;
                firstPage.Attributes.Remove("class");
                btnReceivedMessages.CssClass = ("btn btn-dark btn-block");
                btnSentMessages.CssClass = ("btn btn-warning btn-block");
                btnNewMessage.CssClass = ("btn btn-dark btn-block");
                break;
            //New message
            case 2:
                GvReceived.Visible = true;
                GvSent.Visible = false;
                divMessage.Visible = false;
                newMessage.Visible = true;
                btnReceivedMessages.CssClass = ("btn btn-dark btn-block");
                btnSentMessages.CssClass = ("btn btn-dark btn-block");
                btnNewMessage.CssClass = ("btn btn-warning btn-block showOnlyInCell");
                firstPage.Attributes.Add("class", "showOnlyInCell");
                break;
            default:
                break;
        }
    }

    protected bool CheckError()
    {
        bool error = false;
        if (ddRecipients.SelectedIndex == -1)
        {
            ddRecipients.CssClass = "form-control redBorder animate__animated animate__heartBeat";
            error = true;
        } else
        {
            ddRecipients.CssClass = "form-control";
        }

        if (string.IsNullOrEmpty(t_subject.Text))
        {
            t_subject.CssClass = "form-control redBorder animate__animated animate__heartBeat";
            error = true;
        } else
        {
            t_subject.CssClass = "form-control";
        }

        if (string.IsNullOrEmpty(t_content.Text))
        {
            t_content.CssClass = "form-control redBorder animate__animated animate__heartBeat";
            error = true;
        } else
        {
            t_content.CssClass = "form-control";
        }

        return error;
    }
}