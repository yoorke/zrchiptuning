using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace zrchiptuning
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Utility.ExceptionHandling.ExceptionLog.CheckFiles();
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = HttpContext.Current.Server.GetLastError() as HttpException;
            Utility.ExceptionHandling.ExceptionLog.LogError(ex);

            if (ex.GetHttpCode() == 404)
                Server.Transfer("/not-found.aspx");
        
            Server.Transfer("~/error.html");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("manufacturers", "vozila/{typeUrl}", "~/manufacturers.aspx");
            routes.MapPageRoute("models", "vozila/{typeUrl}/{manufacturerUrl}", "~/models.aspx");
            routes.MapPageRoute("engines", "vozila/{typeUrl}/{manufacturerUrl}/{modelUrl}", "~/engines.aspx");
            routes.MapPageRoute("engine", "vozila/{typeUrl}/{manufacturerUrl}/{modelUrl}/{engineUrl}", "~/engine.aspx");
            routes.MapPageRoute("project", "projekti", "~/customPage.aspx", false, new RouteValueDictionary { { "url", "projekti" } });
            routes.MapPageRoute("contact", "kontakt", "~/customPage.aspx", false, new RouteValueDictionary { { "url", "kontakt" } });
            routes.MapPageRoute("whereAreWe", "gde-se-nalazimo", "~/customPage.aspx", false, new RouteValueDictionary { { "url", "gde-se-nalazimo" } });
            routes.MapPageRoute("addBlueIskljucivanje", "iskljucivanje-adblue-sistema", "~/customPage.aspx", false, new RouteValueDictionary { { "url", "iskljucivanje-adblue-sistema" } });
            routes.MapPageRoute("lambdaO2UklanjanjeGresaka", "gasenje-lambda-o2-senzora", "~/customPage.aspx", false, new RouteValueDictionary { { "url", "gasenje-lambda-o2-senzora" } });
            routes.MapPageRoute("dpfIskljucivanje", "uklanjanje-dpf", "~/customPage.aspx", false, new RouteValueDictionary { { "url", "uklanjanje-dpf" } });
            routes.MapPageRoute("egrVentilBlokiranje", "blokiranje-egr-ventila", "~/customPage.aspx", false, new RouteValueDictionary { { "url", "blokiranje-egr-ventila" } });
            routes.MapPageRoute("dtcTrajnoUklanjanjeGresaka", "dtc-off-trajno-uklanjanje-gresaka", "~/customPage.aspx", false, new RouteValueDictionary { { "url", "dtc-off-trajno-uklanjanje-gresaka" } });
            routes.MapPageRoute("flapsGasenjeKlapni", "flaps-gasenje-klapni", "~/customPage.aspx", false, new RouteValueDictionary { { "url", "flaps-gasenje-klapni" } });
            routes.MapPageRoute("iskljucivanjeStartStopSistema", "iskljucivanje-start-stop-sistema", "~/customPage.aspx", false, new RouteValueDictionary { { "url", "iskljucivanje-start-stop-sistema" } });
            routes.MapPageRoute("mafSenzorDeaktivacija", "deaktivacija-maf-senzora", "~/customPage.aspx", false, new RouteValueDictionary { { "url", "deaktivacija-maf-senzora" } });
            routes.MapPageRoute("iskljucivanjeOgranicenaBrzine", "iskljucivanje-ogranicenja-brzine", "~/customPage.aspx", false, new RouteValueDictionary { { "url", "iskljucivanje-ogranicenja-brzine" } });

            routes.MapPageRoute("povecanjeSnage", "chip-tuning/{url}", "~/customPage.aspx");
            routes.MapPageRoute("dynoPowerTest", "dyno-test", "~/customPage.aspx", false, new RouteValueDictionary { { "url", "dyno-test" } });
        }
    }
}