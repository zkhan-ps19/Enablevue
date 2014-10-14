using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using BLL;
using System.Xml;

namespace RESTfulAPI
{
    public class Global : System.Web.HttpApplication
    {

        private static string strAccessToken = "evue_sec_token";
        private static string strSecretToken = System.Web.Configuration.WebConfigurationManager.AppSettings[strAccessToken].ToString();
        private static string strUserToken = "evue_token";

        protected void Application_Start(object sender, EventArgs e)
        {
            //SharedClass.LoadConfig();

            RouteTable.Routes.Add(new ServiceRoute(SharedClass.uri_workrequests, new WebServiceHostFactory(), typeof(APIWorkRequests)));
            RouteTable.Routes.Add(new ServiceRoute(SharedClass.uri_content, new WebServiceHostFactory(), typeof(APIContent)));
            RouteTable.Routes.Add(new ServiceRoute(SharedClass.uri_windowsServerapi, new WebServiceHostFactory(), typeof(APIWindowsService)));

            //custom made routes
            //  RegisterRoutes(RouteTable.Routes);

            //RouteTable.Routes.Add(new ServiceRoute("home/contentrequests", new WebServiceHostFactory(), typeof(HomeContentRequests)));
            //RouteTable.Routes.Add(new ServiceRoute("home/content", new WebServiceHostFactory(), typeof(HomeContent)));
            //RouteTable.Routes.Add(new ServiceRoute("apihome", new WebServiceHostFactory(), typeof(Home.htm)));
            //RouteTable.Routes.Add(new ServiceRoute("RestService", new WebServiceHostFactory(), typeof(RESTSerivce)));

            SharedClass.setConnString(System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ToString());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.MapPageRoute("","home","~home.aspx");
            //routes.MapPageRoute("Main Default" , "", "~/home.aspx");
            //routes.MapPageRoute("apiHome", "apihome", "~/apihome.aspx");

            routes.MapPageRoute("DefaultPage", "", "~/WebPages/Home.aspx");
            routes.MapPageRoute("DefaultPage2", "home/", "~/WebPages/Home.aspx");
            routes.MapPageRoute("ApiHomePage", "apihome", "~/API/apihome.aspx");

            // Content Requests
            routes.MapPageRoute("ContReqList", "home/contentrequests/list", "~/WebPages/ContentRequest.aspx");
            routes.MapPageRoute("ContReqView", "home/contentrequests/{id}/view", "~/WebPages/ContentRequest.aspx");
            routes.MapPageRoute("ContReqEdit", "home/contentrequests/{id}/edit", "~/WebPages/ContentRequest.aspx");

            //Content
            routes.MapPageRoute("ContentList", "home/content/list", "~/WebPages/GetAllContent.aspx");
            routes.MapPageRoute("ContentView", "home/content/{id}/view", "~/WebPages/Content.aspx");
            routes.MapPageRoute("ContentEdit", "home/content/{id}/edit", "~/WebPages/Content.aspx");
        }

        protected void Application_BeginRequest(object source, EventArgs e)
        {

            Server.ClearError();

            HttpRequest objRequest = ((HttpApplication)source).Context.Request;
            string strUrl = objRequest.Url.ToString();

            if (strUrl == "http://ec2-54-83-12-225.compute-1.amazonaws.com/evue/" || strUrl == "http://ec2-54-83-12-225.compute-1.amazonaws.com/evue")
                Response.Redirect("http://ec2-54-83-12-225.compute-1.amazonaws.com/evue/WebPages/Login.aspx");
            else if (strUrl == "http://localhost/evue/" || strUrl == "http://localhost/evue")
                Response.Redirect("http://localhost/evue/WebPages/Login.aspx");
            else if ((strUrl.Contains("/apihome/workrequests") && objRequest.HttpMethod == "POST")
                || (strUrl.Contains("/apihome/content") && (objRequest.HttpMethod == "GET"
                || objRequest.HttpMethod == "PUT")))
            {
                string strToken = objRequest.Headers.Get(strAccessToken);

                if (strToken == null || strToken.Length == 0)
                {
                    Response.StatusCode = 401;
                    Response.Write("OAuth Failure : Could not resolve the app key with variable request.header." + strAccessToken);
                    Response.StatusDescription = "OAuth Failure : Could not resolve the app key with variable request.header." + strAccessToken;
                }
                else if (strToken == strSecretToken)
                {
                    byte[] buffer = new byte[objRequest.InputStream.Length];
                    objRequest.InputStream.Read(buffer, 0, buffer.Length);
                    objRequest.InputStream.Position = 0;

                    if (objRequest.HttpMethod == "GET")
                        return;

                    try
                    {
                        string str = System.Text.Encoding.UTF8.GetString(buffer);

                        XmlDocument xmlRequest = new XmlDocument();
                        xmlRequest.LoadXml(str);

                        return;
                    }
                    catch (Exception)
                    {
                        Response.StatusCode = 422;
                        Response.Write("XML malformed.");
                        Response.StatusDescription = "XML malformed.";
                    }
                }
                else
                {
                    Response.StatusCode = 401;
                    Response.Write("OAuth Failure : Could not resolve the app key with variable request.header." + strAccessToken);
                    Response.StatusDescription = "OAuth Failure : Could not resolve the app key with variable request.header." + strAccessToken;
                }

                Response.Flush();
                Response.End();
            }
            else if ((strUrl.Contains("/apihome/content") && objRequest.HttpMethod == "POST")
                || (strUrl.Contains("/apihome/sendemail") && objRequest.HttpMethod == "POST"))
            {
                string strTokenValue = Request.Headers.Get(strUserToken);

                if (Admin.UserToken.CountAllWhere("Token='" + strTokenValue + "'") == 0)
                {
                    Response.StatusCode = 401;
                    Response.Write("OAuth Failure : Could not resolve the app key with variable request.header." + strUserToken);
                    Response.StatusDescription = "OAuth Failure : Could not resolve the app key with variable request.header." + strUserToken;
                    Response.Flush();
                    Response.End();
                }
            }
        }
    }
}