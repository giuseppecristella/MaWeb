using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;
using Facebook;

public partial class oauth_oauth_redirect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["code"] == null)
        {
            var api = new FacebookAPI("AAABZBvUXfKBQBACUfoZBu47w681FZBSo9e9zJmA6y4ZCt3YFKfmxytkDUqNHosZB3DSrqP3ePq0si1Is4flCT9wRZAZBEtpvYgxUQuinvvqrgZDZD");
            api.Get("/me/feed");
            api.Get("/me/events");
        }
    }

    private string GetAccessToken()
    {
        if (HttpRuntime.Cache["access_token"] == null)
        {
            var args = GetOauthTokens(Request.Params["code"]);
            HttpRuntime.Cache.Insert("access_token", args["access_token"], null, DateTime.Now.AddMinutes(Convert.ToDouble(args["expires"])), TimeSpan.Zero);

        }
        return HttpRuntime.Cache["access_token"].ToString();
    }

    private Dictionary<string, string> GetOauthTokens(string code)
    {
        var tokens = new Dictionary<string, string>();
        const string clientId = "139351386171412";
        const string redirectUrl = "http://localhost:31049/materarredamenti.it/oauth/oauth-redirect.aspx";
        const string clientSecret = "fe26fe2227b61e3483ff55236b67afc0";
        const string scope = "read_friendlists,user_status";

        var url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}&scope={4}",
                        clientId, redirectUrl, clientSecret, code, scope);

        var request = WebRequest.Create(url) as HttpWebRequest;

        using (var response = request.GetResponse() as HttpWebResponse)
        {
            var reader = new StreamReader(response.GetResponseStream());
            var retVal = reader.ReadToEnd();

            foreach (var token in retVal.Split('&'))
            {
                tokens.Add(token.Substring(0, token.IndexOf("=", StringComparison.Ordinal)),
                    token.Substring(token.IndexOf("=", System.StringComparison.Ordinal) + 1, token.Length - token.IndexOf("=", StringComparison.Ordinal) - 1));
            }
        }
        return tokens;
    }

}
