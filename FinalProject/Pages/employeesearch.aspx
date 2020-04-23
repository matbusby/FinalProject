<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="employeesearch.aspx.cs" Inherits="FinalProject.Pages.employeesearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Employee Search</h1>
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
            OnClick="SearchEmployeesPartial_Click" /><br />

        <%--Search by ID--%>

        <asp:Label ID="PositionSearchLabel" runat="server" Text="Position" AssociatedControlID="PositionList"></asp:Label>&nbsp;&nbsp
        <asp:DropDownList ID="PositionList" runat="server" Width="300px"></asp:DropDownList> 
        <asp:Button ID="PositionListButton" runat="server" Text="Search Positions" OnClick="SearchPositions_Click" />
        
<%--        <asp:Label ID="Label2" runat="server" Text="Select"></asp:Label>&nbsp;&nbsp
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>


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

                <asp:TemplateField HeaderText="Full Name">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="FullName" runat="server" 
                            Text='<%# Eval("FullName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

<%--                <asp:TemplateField HeaderText="First Name">
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
                </asp:TemplateField>--%>

                <asp:TemplateField HeaderText="Date Hired">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="DateHired" runat="server" 
                            Text='<%# Eval("DateHired") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Date Released">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="ReleaseDate" runat="server" 
                            Text='<%# Eval("ReleaseDate") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Position ID">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="PositionID" runat="server" 
                            Text='<%# Eval("PositionID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Program ID">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="ProgramID" runat="server" 
                            Text='<%# Eval("ProgramID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Login ID">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="LoginID" runat="server" 
                            Text='<%# Eval("LoginID") %>'>
                        </asp:Label>
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
