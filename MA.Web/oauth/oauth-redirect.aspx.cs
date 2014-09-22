using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Facebook;

public partial class oauth_oauth_redirect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Params["code"] == null)
        {

            //Facebook.FacebookAPI api = new Facebook.FacebookAPI(GetAccessToken());


            Facebook.FacebookAPI api = new Facebook.FacebookAPI("AAABZBvUXfKBQBACUfoZBu47w681FZBSo9e9zJmA6y4ZCt3YFKfmxytkDUqNHosZB3DSrqP3ePq0si1Is4flCT9wRZAZBEtpvYgxUQuinvvqrgZDZD");
            JSONObject feeds = api.Get("/me/feed");

            string provaL = feeds.Dictionary["data"].Array[0].Dictionary["link"].String;

            JSONObject events = api.Get("/me/events");

        }

   

    }



    private string GetAccessToken()
    {

        if (HttpRuntime.Cache["access_token"] == null)
        {

            Dictionary<string, string> args = GetOauthTokens(Request.Params["code"]);

            HttpRuntime.Cache.Insert("access_token", args["access_token"], null, DateTime.Now.AddMinutes(Convert.ToDouble(args["expires"])), TimeSpan.Zero);

        }



        return HttpRuntime.Cache["access_token"].ToString();

    }



    private Dictionary<string, string> GetOauthTokens(string code)
    {

        Dictionary<string, string> tokens = new Dictionary<string, string>();



        string clientId = "139351386171412";

        string redirectUrl = "http://localhost:31049/materarredamenti.it/oauth/oauth-redirect.aspx";

        string clientSecret = "fe26fe2227b61e3483ff55236b67afc0";

        string scope = "read_friendlists,user_status";



        string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}&scope={4}",

                        clientId, redirectUrl, clientSecret, code, scope);



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
