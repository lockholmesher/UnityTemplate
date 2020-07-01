using UnityEngine;
using System;
public class Utils
{
    public static string ConvertMoneyToString(long money)
    {
        if (money>=1000000000)
        {
            return (money / 1000000000).ToString() + "B";
        }
        if (money >= 1000000)
        {
            return (money / 1000000).ToString() + "M";
        }
        if (money >= 1000)
        {
            return (money / 1000).ToString() + "K";
        }
        return money.ToString();
    }

    public static int GetSecondElalsed(DateTime prevDate)
    {
        DateTime now = DateTime.Now;
        TimeSpan timeDiffernce = now.Subtract(prevDate);
        return timeDiffernce.Seconds;
    }

    public static string CutString(string text,int MaxLength)
    {
        if (text == null) return "";
        string[] SplitText = text.Split(' ');
        if (SplitText == null) return "";
        string newText = "";
        foreach (string c_text in SplitText)
        {
            if (newText.Length + c_text.Length > MaxLength) return newText;
            newText = newText + " " + c_text;
        }

        return newText;
    }

    public static string ConvertIntToTimeHH_MM_SS(int duration)
    {
        string time = "";
        for (int i = 2; i >= 0; i--)
        {
            if (i < 2) time += ":";
            int detailTime = (int)Mathf.Pow(60, i);
            int t = duration / detailTime;
            duration = duration % detailTime;
            if (t > 9)
            {
                time += t.ToString();
                continue;
            }
            if (t > 0)
            {
                time += "0" + t.ToString();
                continue;
            }
            time += "00";
        }
        return time;
    }

    public static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

}
