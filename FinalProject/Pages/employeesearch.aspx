<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="employeesearch.aspx.cs" Inherits="FinalProject.Pages.employeesearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Partial String Search to Custom GridView to Single Record via Page Navigation</h1>
    <div class="offset-2">
        <asp:DataList ID="Message" runat="server" Enabled="False">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
        </asp:DataList>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Enter a Partial Employee Name "></asp:Label>&nbsp;&nbsp
        <asp:TextBox ID="PartialEmployeeNameV2" runat="server"></asp:TextBox>
        <asp:Button ID="SearchEmployeesPartial" runat="server" Text="Search Employees"
            OnClick="SearchEmployeesPartial_Click" />
        <br />
        <br />
        <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
        <br />
        <asp:GridView ID="EmployeeGridViewV2" runat="server"

            AutoGenerateColumns="False"
            CssClass="table table-striped" GridLines="Horizontal"
            BorderStyle="None" AllowPaging="True"
            OnPageIndexChanging="List02_PageIndexChanging" PageSize="5"
            OnSelectedIndexChanged="List02_SelectedIndexChanged">

            <Columns>
                <asp:CommandField SelectText="View" ShowSelectButton="True" 
                    ButtonType="Button" CausesValidation="false">
                </asp:CommandField>

                <asp:TemplateField HeaderText="ID" Visible="True">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="EmployeeID" runat="server" 
                            Text='<%# Eval("EmployeeID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="First Name">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="FirstName" runat="server" 
                            Text='<%# Eval("FirstName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Last Name">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="LastName" runat="server" 
                            Text='<%# Eval("LastName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Date Hired">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="DateHired" runat="server" 
                            Text='<%# Eval("DateHired") == null ? "each" : Eval("QuantityPerUnit") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Price ($)">
                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="UnitPrice" runat="server" 
                            Text='<%# string.Format("{0:0.00}",Eval("UnitPrice"))%>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Disc">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                         <asp:CheckBox ID="Discontinued" runat="server" 
                              Checked='<%# Eval("Discontinued") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                no data to display
            </EmptyDataTemplate>
            <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" PageButtonCount="3" />
        </asp:GridView>
    </div>
</asp:Content>
