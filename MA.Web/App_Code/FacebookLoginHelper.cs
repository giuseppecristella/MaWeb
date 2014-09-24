using System.Collections.Generic;
using System.Net;
using System.IO;

/// <summary>
/// Summary description for FacebookLoginHelper
/// </summary>
public class FacebookLoginHelper
{
  public FacebookLoginHelper()
  {
    //
    // TODO: Add constructor logic here
    //
  }

  public Dictionary<string, string> GetAccessToken(string code, string redirectUrl)
  {
    Dictionary<string, string> tokens = new Dictionary<string, string>();
    string clientId = "139351386171412";
    string clientSecret = "fe26fe2227b61e3483ff55236b67afc0";
    string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}",
                    clientId, redirectUrl, clientSecret, code);
    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    {
      StreamReader reader = new StreamReader(response.GetResponseStream());
      string retVal = reader.ReadToEnd();
      foreach (string token in retVal.Split('&'))
      {
        tokens.Add(token.Substring(0, token.IndexOf("=")),
            token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
      }
    }
    return tokens;
  }
}
