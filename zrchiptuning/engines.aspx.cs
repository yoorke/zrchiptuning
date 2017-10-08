using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BL;

namespace zrchiptuning
{
    public partial class engines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                lblType.Value = Page.RouteData.Values["typeUrl"].ToString();
                lblManufacturerUrl.Value = Page.RouteData.Values["manufacturerUrl"].ToString();
                if (Page.RouteData.Values["modelUrl"] != null)
                    showEngines(Page.RouteData.Values["modelUrl"].ToString(), Page.RouteData.Values["manufacturerUrl"].ToString());
            }
        }

        private void showEngines(string modelUrl, string manufacturerUrl)
        {
            //rptEngines.DataSource = new EngineBL().GetByModelUrl(modelUrl);
            //rptEngines.DataBind();

            Model model = new ModelBL().GetByUrl(modelUrl, manufacturerUrl);
            if(model != null)
            { 
                lblModel.Text = model.Manufacturer.Name + " " + model.Name;
                showModels(model.Manufacturer);
                Page.Title = model.Manufacturer.Name + " " + model.Name + " | Chip tuning poslednje generacije";

            //rptEngines.DataSource = model.Engines;
            //rptEngines.DataBind();

                dgvEngines.DataSource = model.Engines;
                dgvEngines.DataBind();

                imgModel.ImageUrl = "/images/car-logos/" + lblManufacturerUrl.Value + "/models/" + model.ImageUrl;
            }
            else
            {
                Response.StatusCode = 404;
                Server.Transfer("~/errors/not-found.html");
            }
        }

        private void showModels(Manufacturer manufacturer)
        {
            lblManufacturer.Text = manufacturer.Name;
            rptModels.DataSource = new ModelBL().GetByManufacturerID(manufacturer.ID, false);
            rptModels.DataBind();
        }

        protected void rptModels_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink lnkModel = ((HyperLink)e.Item.FindControl("lnkModel"));
                lnkModel.NavigateUrl = "/vozila/" + lblType.Value + "/" + lblManufacturerUrl.Value + "/" + lnkModel.NavigateUrl;
            }
        }
    }
}