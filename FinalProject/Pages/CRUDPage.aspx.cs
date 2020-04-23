using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DBSystem.BLL;
using DBSystem.ENTITIES;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;

namespace FinalProject.Pages
{
    public partial class CRUDPage : System.Web.UI.Page
    {
        static string pagenum = "";
        static string pid = "";
        //static string add = "";
        List<string> errormsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            errormsgs.Clear();
            Message.DataSource = null;
            Message.DataBind();
            if (!Page.IsPostBack)
            {
                //errormsgs.Add("IsPostBack = False");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                pagenum = Request.QueryString["page"];
                pid = Request.QueryString["pid"];
                //add = Request.QueryString["add"];
                BindProgramList();
                BindPositionList();
                if (string.IsNullOrEmpty(pid))
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    EmployeeController sysmgr = new EmployeeController();
                    EmployeeEntity info = null;
                    info = sysmgr.FindByPKID(int.Parse(pid));
                    if (info == null)
                    {
                        errormsgs.Add("Record is not in Database.");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                        Clear(sender, e);
                    }
                    else
                    {
                        EmployeeID.Text = info.EmployeeID.ToString(); //NOT NULL
                        FirstName.Text = info.FirstName; //NOT NULL
                        LastName.Text = info.LastName;
                        PositionList.SelectedValue = info.PositionID.ToString();
                        ProgramList.SelectedValue = info.ProgramID.ToString();
                        DateHired.Text = info.DateHired.ToString();
                        ReleaseDate.Text = info.ReleaseDate.ToString();
                        LoginID.Text = info.LoginID;
                    }
                }
            }
            //else
            //{
            //    errormsgs.Add("IsPostBack = True");

            //}
        }


        protected Exception GetInnerException(Exception ex)
        {
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
            LabelMessage1.InnerHtml = "";
            for (int i = 0; i <= errormsglist.Count - 1; i++)
            {
                LabelMessage1.InnerHtml += "<br />"
                                        + errormsglist[i];
            }

        }
        protected void BindPositionList()
        {
            try
            {
                PositionController sysmgr = new PositionController();
                List<PositionEntity> info = null;
                info = sysmgr.List();
                info.Sort((x, y) => x.Description.CompareTo(y.Description));
                PositionList.DataSource = info;
                PositionList.DataTextField = nameof(PositionEntity.Description);
                PositionList.DataValueField = nameof(PositionEntity.PositionID);
                PositionList.DataBind();
                PositionList.Items.Insert(0, "select...");

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        protected void BindProgramList()
        {
            try
            {
                ProgramController sysmgr = new ProgramController();
                List<ProgramEntity> info = null;
                info = sysmgr.List();
                info.Sort((x, y) => x.ProgramName.CompareTo(y.ProgramName));
                ProgramList.DataSource = info;
                ProgramList.DataTextField = nameof(ProgramEntity.ProgramName);
                ProgramList.DataValueField = nameof(ProgramEntity.ProgramID);
                ProgramList.DataBind();
                ProgramList.Items.Insert(0, "select...");

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        protected void Validation(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FirstName.Text))
            {
                errormsgs.Add("First Name is required");
            }

            if (string.IsNullOrEmpty(LastName.Text))
            {
                errormsgs.Add("First Name is required");
            }

            if (string.IsNullOrEmpty(DateHired.Text))
            {
                errormsgs.Add("Date hired is required");
            }

            if (PositionList.SelectedIndex == 0)
            {
                errormsgs.Add("Position is required");
            }

            if (ProgramList.SelectedIndex == 0)
            {
                errormsgs.Add("Program is required");
            }

        }
        protected void Back_Click(object sender, EventArgs e)
        {
                Response.Redirect("~/Pages/employeesearch.aspx");
            //if (pagenum == "4")
            //{
            //}
            //else
            //{
            //    Response.Redirect("~/Default.aspx");
            //}
        }
        protected void Clear(object sender, EventArgs e)
        {
            EmployeeID.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            DateHired.Text = "";
            ReleaseDate.Text = "";
            PositionList.ClearSelection();
            ProgramList.ClearSelection();
            LoginID.Text = "";
        }

        //protected void Add_Click(object sender, EventArgs e)
        //{
        //    Validation(sender, e);
        //    if (errormsgs.Count > 1)
        //    {
        //        LoadMessageDisplay(errormsgs, "alert alert-info");
        //    }
        //    else
        //    {
        //        try
        //        {
        //            EmployeeController sysmgr = new EmployeeController();
        //            EmployeeEntity item = new EmployeeEntity();
        //            //No ProductID here as the database will give a new one back when we add
        //            item.ProductName = Name.Text.Trim(); //NOT NULL
        //            if (SupplierList.SelectedIndex == 0) //NULL
        //            {
        //                item.SupplierID = null;
        //            }
        //            else
        //            {
        //                item.SupplierID = int.Parse(SupplierList.SelectedValue);
        //            }
        //            //PositionID can be NULL in database but NOT NULL when record is added in this CRUD page
        //            item.PositionID = int.Parse(PositionList.SelectedValue);
        //            item.QuantityPerUnit =
        //                string.IsNullOrEmpty(QuantityPerUnit.Text) ? null : QuantityPerUnit.Text; //NULL
        //            //UnitPrice can be NULL in database but NOT NULL when record is added in this CRUD page
        //            item.UnitPrice = decimal.Parse(UnitPrice.Text);
        //            if (string.IsNullOrEmpty(UnitsInStock.Text)) //NULL
        //            {
        //                item.UnitsInStock = null;
        //            }
        //            else
        //            {
        //                item.UnitsInStock = Int16.Parse(UnitsInStock.Text);
        //            }
        //            if (string.IsNullOrEmpty(UnitsOnOrder.Text)) //NULL
        //            {
        //                item.UnitsOnOrder = null;
        //            }
        //            else
        //            {
        //                item.UnitsOnOrder = Int16.Parse(UnitsOnOrder.Text);
        //            }
        //            if (string.IsNullOrEmpty(ReorderLevel.Text)) //NULL
        //            {
        //                item.ReorderLevel = null;
        //            }
        //            else
        //            {
        //                item.ReorderLevel = Int16.Parse(ReorderLevel.Text);
        //            }
        //            item.Discontinued = false; //NOT NULL
        //            int newID = sysmgr.Add(item);
        //            ID.Text = newID.ToString();
        //            errormsgs.Add("Record has been added");
        //            LoadMessageDisplay(errormsgs, "alert alert-success");
        //            UpdateButton.Enabled = true;
        //            DeleteButton.Enabled = true;
        //            Discontinued.Enabled = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            errormsgs.Add(GetInnerException(ex).ToString());
        //            LoadMessageDisplay(errormsgs, "alert alert-danger");
        //        }
        //    }
        //}
        protected void Update_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(EmployeeID.Text))
            {
                errormsgs.Add("Search for a record to update");
            }
            else if (!int.TryParse(EmployeeID.Text, out id))
            {
                errormsgs.Add("Id is invalid");
            }
            Validation(sender, e);
            if (errormsgs.Count > 1)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    EmployeeController sysmgr = new EmployeeController();
                    EmployeeEntity item = new EmployeeEntity();
                    item.EmployeeID = int.Parse(EmployeeID.Text);
                    item.FirstName = FirstName.Text.Trim();
                    item.LastName = LastName.Text.Trim();
                    item.DateHired = DateTime.Parse(DateHired.Text);
                    if (string.IsNullOrEmpty(ReleaseDate.Text))
                    {
                        item.ReleaseDate = null;
                    }
                    else
                    {
                        item.ReleaseDate = DateTime.Parse(ReleaseDate.Text);
                    }

                    item.PositionID = int.Parse(PositionList.SelectedValue);
                    item.ProgramID = int.Parse(ProgramList.SelectedValue);
                    if (string.IsNullOrEmpty(LoginID.Text))
                    {
                        item.LoginID = null;
                    }
                    else
                    {
                        item.LoginID = LoginID.Text.Trim();
                    }

                    int rowsaffected = sysmgr.Update(item);
                    if (rowsaffected > 0)
                    {
                        errormsgs.Add("Record has been updated");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                    }
                    else
                    {
                        errormsgs.Add("Record was not found");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
        //protected void Delete_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(ID.Text))
        //    {
        //        errormsgs.Add("Search for a record to delete");
        //    }
        //    if (errormsgs.Count > 1)
        //    {
        //        LoadMessageDisplay(errormsgs, "alert alert-info");
        //    }
        //    else
        //    {
        //        try
        //        {
        //            EmployeeController sysmgr = new EmployeeController();
        //            int rowsaffected = sysmgr.Delete(int.Parse(ID.Text));
        //            if (rowsaffected > 0)
        //            {
        //                errormsgs.Add("Record has been deleted");
        //                LoadMessageDisplay(errormsgs, "alert alert-success");
        //                Clear(sender, e);
        //            }
        //            else
        //            {
        //                errormsgs.Add("Record was not found");
        //                LoadMessageDisplay(errormsgs, "alert alert-warning");
        //            }
        //            UpdateButton.Enabled = false;
        //            DeleteButton.Enabled = false;
        //            Discontinued.Enabled = false;
        //            AddButton.Enabled = true;

        //        }
        //        catch (Exception ex)
        //        {
        //            errormsgs.Add(GetInnerException(ex).ToString());
        //            LoadMessageDisplay(errormsgs, "alert alert-danger");
        //        }
        //    }
        //}
    }
}