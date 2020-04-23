using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DBSystem.BLL;
using DBSystem.ENTITIES;

namespace FinalProject.Pages
{
    public partial class employeesearch : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
            if (!Page.IsPostBack)
            {
                //BindList();
            }
        }


        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }


        protected void SearchEmployeesPartial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PartialEmployeeNameV2.Text))
            {
                errormsgs.Add("Please enter a partial employee name for the search");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                EmployeeGridViewV2.DataSource = null;
                EmployeeGridViewV2.DataBind();
            }
            else
            {
                try
                {
                    EmployeeController sysmgr = new EmployeeController();
                    List<EmployeeEntity> info = sysmgr.FindByPartialName(PartialEmployeeNameV2.Text);
                    if (info.Count == 0)
                    {
                        errormsgs.Add("No data found for the partial employee name search");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                    }
                    else
                    {
                        info.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                        //load the multiple record control

                        //GridView
                        EmployeeGridViewV2.DataSource = info;
                        EmployeeGridViewV2.DataBind();

                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
        protected void List02_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EmployeeGridViewV2.PageIndex = e.NewPageIndex;
            SearchEmployeesPartial_Click(sender, new EventArgs());
        }
        protected void List02_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow agvrow = EmployeeGridViewV2.Rows[EmployeeGridViewV2.SelectedIndex];
            string employeeid = (agvrow.FindControl("EmployeeID") as Label).Text;
            Response.Redirect("CRUDPage.aspx?pid=" + employeeid);
        }
    }
}