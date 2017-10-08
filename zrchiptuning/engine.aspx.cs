using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using BE;

namespace zrchiptuning
{
    public partial class engine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                lblType.Value = Page.RouteData.Values["typeUrl"].ToString();
                lblManufacturerUrl.Value = Page.RouteData.Values["manufacturerUrl"].ToString();
                lblModelUrl.Value = Page.RouteData.Values["modelUrl"].ToString();
                if (Page.RouteData.Values["engineUrl"] != null)
                    showEngine(Page.RouteData.Values["engineUrl"].ToString(), Page.RouteData.Values["modelUrl"].ToString(), Page.RouteData.Values["manufacturerUrl"].ToString());

                showEngines();
                if (lblType.Value == "kamioni")
                    lblStage2.InnerText = "Stage 2 ECO";
            }
        }

        private void showEngine(string url, string modelUrl, string manufacturerUrl)
        {
            Engine engine = new EngineBL().GetEngine(url, modelUrl, manufacturerUrl);
            if(engine == null)
            {
                Response.StatusCode = 404;
                Server.Transfer("~/errors/not-found.html");
            }
            dgvEngine.DataSource = new EngineBL().GetEngineData(engine, 0);
            dgvEngine.DataBind();

            dgvEngineStage2.DataSource = new EngineBL().GetEngineData(engine, 1);
            dgvEngineStage2.DataBind();
            if (((System.Data.DataTable)dgvEngineStage2.DataSource).Rows.Count == 0)
                stage2.Visible = false;

            Model model = new ModelBL().GetByUrl(lblModelUrl.Value, lblManufacturerUrl.Value);
            if(model != null)
                lblModel.Text = model.Name;
            else
            {
                Response.StatusCode = 404;
                Server.Transfer("~/error/not-found.html");
            }

            if (engine != null)
            {
                lblEngine.Text = model.Manufacturer.Name + " " + model.Name + " " + engine.Name;
                Page.Title = model.Manufacturer.Name + " " + model.Name + " " + engine.Name + " Chip tuning";
            }
            else
            {
                Response.StatusCode = 404;
                Server.Transfer("~/error/not-found.html");
            }

            if(model != null)
                imgModel.ImageUrl = "/images/car-logos/" + lblManufacturerUrl.Value + "/" + "models/" + model.ImageUrl;
            else
            {
                Response.StatusCode = 404;
                Server.Transfer("~/errors/not-found.html");
            }
            
            
        }

        protected void rptEngines_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink engine = ((HyperLink)e.Item.FindControl("lnkEngine"));
                engine.NavigateUrl = "/vozila/" + lblType.Value + "/" + lblManufacturerUrl.Value + "/" + lblModelUrl.Value + "/" + engine.NavigateUrl;
            }
        }

        private void showEngines()
        {
            rptEngines.DataSource = new EngineBL().GetByModelUrl(lblModelUrl.Value, lblManufacturerUrl.Value);
            rptEngines.DataBind();
        }
    }
}