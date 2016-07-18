using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using BE;

namespace zrchiptuning.administrator
{
    public partial class loadData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
                Response.Redirect("/administrator/login.aspx");

            if (!Page.IsPostBack)
            {
                cmbManufacturers.DataSource = new ManufacturerBL().GetAll();
                cmbManufacturers.DataTextField = "name";
                cmbManufacturers.DataValueField = "id";
                cmbManufacturers.DataBind();
            }
        }

        protected void btnLoadData_Click(object sender, EventArgs e)
        {

        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            if(cmbManufacturers.SelectedIndex > -1)
            {
                new ModelBL().LoadData(int.Parse(cmbManufacturers.SelectedValue));
            }
        }

        protected void btnLoadMcChip_Click(object sender, EventArgs e)
        {
            if(cmbManufacturers.SelectedIndex > -1)
            {
                new ModelBL().LoadDataMcChip(int.Parse(cmbManufacturers.SelectedValue), 1);
            }
        }
    }
}