using System.IO;
using System;
using System.Net.Mail;
using System.Net;


/// <summary>
/// Summary description for myHelperUtility
/// </summary>
public class HelperUtility
{
	public HelperUtility()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string getFavoriteLinkByBrowser(string browserName, string pageTitle, string currentUrl)
    {
        string favLink="";
        if (browserName == "firefox")
        {
            favLink = "javascript:window.sidebar.addPanel('" + pageTitle + "','" + currentUrl + "','')";
        }
        else if (browserName == "ie")
        {
            favLink = "javascript:window.external.AddFavorite('" + currentUrl + "','" + pageTitle + "')";
        }
        else if (browserName == "opera" || browserName == "applemac-safari")
        {
            favLink = "javascript:window.external.AddFavorite('" + currentUrl + "','" + pageTitle + "')";
        }
        return favLink;
    }
    public static string getNewWindowLink(string navigateUrl, string pageTitle, string width, string height,
        string menubarOpt, string locationOpt, string resizableOpt, string topPos, string leftPos, string scrollbarsOpt)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("window.open('" + navigateUrl +
            "', '" + pageTitle + "'," + "'" + "width="+width+",height="+height+",menubar="+menubarOpt+",location="+
            locationOpt+",resizable="+resizableOpt+",top="+topPos+",left="+leftPos+",scrollbars="+scrollbarsOpt+"');");

        ////register javascript to open large image in new windows
        ////http://support.microsoft.com/default.aspx?scid=kb;EN-US;827420

        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //sb.Append("<script language='javascript'>");
        //sb.Append("window.open('"+hl2.NavigateUrl+"', '"+lbld.Text+"',");
        //sb.Append("'width=600, height=500, menubar=no, resizable=no');<");
        //sb.Append("/script>");

        ////register with ClientScript
        ////The RegisterStartupScript method is also slightly different
        ////from ASP.NET 1.x
        //Type t = this.GetType();
        //if (!ClientScript.IsClientScriptBlockRegistered(t, "PopupScript"))
        //    ClientScript.RegisterClientScriptBlock(t, "PopupScript", sb.ToString());
        return sb.ToString();
    }
    public static void sendMail(string to, string toname, string from, string fromname, string subject, string body)
    {
        //create objects of smtpclient and mailmessage
        SmtpClient smtpClient = new SmtpClient();
        MailMessage message = new MailMessage();
        //
        try
        {
            MailAddress fromAddress = new MailAddress(from, fromname);
            //now specify the mail settings
            smtpClient.Host = "localhost";
            smtpClient.Port = 25;
            message.From = fromAddress;
            //assign to addresses, you can do multiple
            message.To.Add(new MailAddress(to, toname));
            message.Subject = subject;
            //add cc/bcc optional
            //message.CC.Add("");
            //message.Bcc.Add(new MailAddress("a@b.com","abc"));
            //add attatchment optional
            //message.Attachments.Add("");
            message.IsBodyHtml = true;
            message.Priority = MailPriority.High;
            message.Body = body;
            smtpClient.Send(message);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    //Method added by Ashu For sending mail on date 27-Aug-2016
    public static void SendMailing(string to, string toname, string subject, string body)
    {
        //var fromAddress = "webmail@ntsoft.in";// Gmail Address from where you send the mail
        var fromAddress = System.Configuration.ConfigurationManager.AppSettings["Email"].ToString();
        var pass = System.Configuration.ConfigurationManager.AppSettings["Pass"].ToString();
        var host = System.Configuration.ConfigurationManager.AppSettings["Host"].ToString();
        int Port =Convert.ToInt32( System.Configuration.ConfigurationManager.AppSettings["Port"].ToString());
        var toAddress =to;
        try
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromAddress);
            message.To.Add(to);
            message.Subject = "Enquiry Mail Form FAQ";
            message.Body = "From Name: " + fromAddress + "\r\n To: " + to + "\r\n Subject: " + subject + "\r\n Description: " + body; 
            SmtpClient s = new SmtpClient();
            //s.Host = "smtp.gmail.com";
            s.Host = host;
            //s.Port = 587;
            s.Port = Port;
            s.EnableSsl = true;
            //s.Credentials = new NetworkCredential("webmail@ntsoft.in", "A1b2c3d4e5-");
            s.Credentials = new NetworkCredential(fromAddress,pass);
            s.Send(message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static string SendSMS(string[] ss, string numbers, string msg, string shduleTime)
    {
        string s = "";

        WebClient Client = new WebClient();
        // String s1 = "&to=" + numbers + "&message=" + msg;

        string baseurl;
        if (shduleTime == "")
            baseurl = "http://bulksms.smsintro4u.com/api/sendhttp.php?authkey=" + ss[1] + "&sender=" + ss[2] + "&mobiles=" + numbers + "&message=" + msg + "&route=4";

            //baseurl = "http://sms.smsintro4u.com/sendsms/" + ss[0] + "/" + ss[1] + "/" + ss[2] + "/" + numbers + "/" + msg + "/"+ ss[3];
        else
            baseurl = "http://sms.smsintro4u.com/sendsms/" + ss[0] + "/" + ss[1] + "/" + ss[2] + "/" + numbers + "/" + msg + "/" + shduleTime + "/" + ss[3];

        //string baseurl = "http://login.smsintro.com/http-api/receiverall.asp?username=" + ss[0] + "&password=" + ss[1] + "&sender=" + ss[2] + "&cdmasender=" + ss[3] + "" + s1 + "&Time=" + shduleTime;
        Stream data = Client.OpenRead(baseurl);
        StreamReader reader = new StreamReader(data);
        s = s + reader.ReadToEnd();
        data.Close();
        reader.Close();
        int res;
        //if (int.TryParse(s,out res))
        //    s = "SMS Successfully send! " + s;
        //else
        //    s = "SMS not send! ";

        return s;

    }

    public static string getRandomPassword(int length)
    {
        string pass = "";
        pass = Guid.NewGuid().ToString();
        pass = pass.Replace("-", string.Empty);
        if (length <= 0 || length > pass.Length)
            throw new ArgumentException("password length must be between 1 and " +
                + pass.Length);
        pass = pass.Substring(0, length);
        return pass;
    }
    public static int GetDayOfWeek(string dayname)
    {
        int i = 1;
        switch (dayname.ToLower())
        {
            case "monday":
                i = 2;
                break;
            case "tuesday":
                i = 3;
                break;
            case "wednesday":
                i = 4;
                break;
            case "thursday":
                i = 5;
                break;
            case "friday":
                i = 6;
                break;
            case "saturday":
                i = 7;
                break;
            case "sunday":
                i = 1;
                break;
        }
        return i;
    }
  
}
