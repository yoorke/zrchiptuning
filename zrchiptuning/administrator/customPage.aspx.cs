using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using BL;
using BE;
using Utility;

namespace zrchiptuning.administrator
{
    public partial class customPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                if (!Page.IsPostBack)
                {
                    populateControls();
                    if (Page.Request.QueryString.ToString().Contains("customPageID"))
                    {
                        int customPageID = 0;
                        int.TryParse(Page.Request.QueryString["customPageID"], out customPageID);
                        if (customPageID > 0)
                            loadCustomPage(customPageID);
                    }
                }
                Page.Title = (ViewState["pageTitle"] != null) ? ViewState["pageTitle"].ToString() : "Unos nove stranice";
            }
            else
                Response.Redirect("/administrator/login.aspx?returnUrl=" + Page.Request.RawUrl);
        }

        private void loadCustomPage(int customPageID)
        {
            CustomPageBL customPageBL = new CustomPageBL();
            CustomPage customPage = customPageBL.GetCustomPage(customPageID);
            txtTitle.Text = customPage.Title;
            txtDescription.Text = customPage.Description;
            txtUrl.Text = customPage.Url;
            txtHeading.Text = customPage.Heading;
            txtHead.Text = customPage.Head;
            txtInsertDate.Text = customPage._insertDate.ToString();
            txtUpdateDate.Text = customPage._updateDate.ToString();
            txtContent.Text = customPage.Content;
            ViewState.Add("customPageID", customPage.ID);
            lblTitleHeading.Text = customPage.Heading;
            ViewState.Add("pageTitle", customPage.Title);
            chkIsActive.Checked = customPage._isActive;
            cmbCustomPageCategory.SelectedValue = customPage.CustomPageCategory.ID.ToString();
            txtFooter.Text = customPage.Footer;
        }

        private void save()
        {
            try
            {
                CustomPage customPage = new CustomPage();
                customPage.ID = (ViewState["customPageID"] != null) ? int.Parse(ViewState["customPageID"].ToString()) : 0;
                int customPageID = customPage.ID;
                customPage.Title = txtTitle.Text;
                customPage.Description = txtDescription.Text;
                customPage.Url = txtUrl.Text;
                customPage.Heading = txtHeading.Text;
                customPage.Head = txtHead.Text;
                customPage._insertDate = DateTime.Now.ToUniversalTime();
                customPage._updateDate = DateTime.Now.ToUniversalTime();
                customPage.Content = txtContent.Text;
                customPage.SortIndex = 1;
                customPage.ImageUrl = string.Empty;
                customPage._isActive = chkIsActive.Checked;
                customPage.CustomPageCategory = new CustomPageCategory(string.Empty, int.Parse(cmbCustomPageCategory.SelectedValue));
                customPage.Footer = txtFooter.Text;

                CustomPageBL customPageBL = new CustomPageBL();
                customPage.ID = customPageBL.Save(customPage);

                if (customPageID == 0)
                    Common.AddUrlRewrite(customPage.Url, "customPage.aspx");

                lblTitleHeading.Text = customPage.Heading;
                ViewState.Add("customPageID", customPage.ID);
                ViewState.Add("pageTitle", customPage.Title);

                divAlert.Visible = true;
                divAlert.Attributes["class"] = "alert alert-success text-center";
                lblAlert.Text = "Custom page saved";
            }
            catch (Exception ex)
            {
                divAlert.Visible = true;
                divAlert.Attributes["class"] = "alert alert-danger text-center";
                lblAlert.Text = ex.Message;
            }
        }

        protected void btnSave_Close(object sender, EventArgs e)
        {
            save();
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            save();
            Response.Redirect("/administrator/customPages.aspx");
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("/administrator/customPages.aspx");
        }

        private void populateControls()
        {
            CustomPageCategoryBL customPageCategoryBL = new CustomPageCategoryBL();
            cmbCustomPageCategory.DataSource = customPageCategoryBL.GetAll();
            cmbCustomPageCategory.DataTextField = "name";
            cmbCustomPageCategory.DataValueField = "ID";
            cmbCustomPageCategory.DataBind();
        }
    }
}
