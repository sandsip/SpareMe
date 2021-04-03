using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;



/// <summary>
/// Summary description for SMSControls
/// </summary>
public class SMSControls
{
    public SMSControls()
    {
        //
        // TODO: Add constructor logic here
        //SMSControls.SMSSendFuction(txtFBMobileVerifcatiion.Text, Session["FBMobileVerfifyOTPVerificationCode"].ToString() + " is your OTP for the Account Verification");
        //My API http://sms.zerozilla.com/pushsms.php?username=VENUST&password=Password@123&sender=VENUST&numbers=9743117980,8792181196&message=YOUR_MESSAGE_TestMSG
    }

    public static string SMSSendFuction(string MobileNo, string SMSTEXT)
    {
        WebClient client = new WebClient();     
        string baseurl = "http://sms.zerozilla.com/pushsms.php?username=SPARESME&password=Password@123&sender=SPARES&numbers=" + System.Uri.EscapeUriString(MobileNo) + "&message=" + System.Uri.EscapeUriString(SMSTEXT);
        Console.Write(baseurl);
        Stream data = client.OpenRead(baseurl);
        StreamReader reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        data.Close();
        reader.Close();
        return s;
    }
}