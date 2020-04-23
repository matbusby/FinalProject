<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUDPage.aspx.cs" Inherits="FinalProject.Pages.CRUDPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
        <h1>Employee Maintenance Page</h1>

    <%--Employee ID--%>
    
    <div class="row">
        <div class="col-md-4 text-right">
                <asp:Label ID="Label1" runat="server" Text="Employee ID"
                     AssociatedControlID="EmployeeID">
                </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="EmployeeID" runat="server" ReadOnly="true">
                </asp:TextBox>
        </div>
    </div>

    <%--First Name--%>

    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="Label2" runat="server" Text="First Name"
                     AssociatedControlID="FirstName"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
        </div>
    </div>

    <%--Last Name--%>

    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="Label5" runat="server" Text="Last Name"
                     AssociatedControlID="LastName"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
        </div>
    </div>

    <%--Date Hired--%>

    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="Label12" runat="server" Text="Date Hired"
                     AssociatedControlID="DateHired"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="DateHired" runat="server"></asp:TextBox>
        </div>
    </div>

    <%--Date Released--%>

    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="Label13" runat="server" Text="Release Date"
                     AssociatedControlID="ReleaseDate"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="ReleaseDate" runat="server"></asp:TextBox>
        </div>
    </div>

    <%--PositionID--%>

    <div class="row">
        <div class="col-md-4 text-right">
                <asp:Label ID="Label7" runat="server" Text="Position"
                     AssociatedControlID="PositionList">
                </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:DropDownList ID="PositionList" runat="server" Width="300px" >
                </asp:DropDownList> 
        </div>
    </div>

    <%--Program ID--%>

    <div class="row">
        <div class="col-md-4 text-right">
                <asp:Label ID="Label14" runat="server" Text="Program"
                     AssociatedControlID="ProgramList">
                </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:DropDownList ID="ProgramList" runat="server" Width="300px" >
                </asp:DropDownList> 
        </div>
    </div>

    <%--Login ID--%>

    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="Label15" runat="server" Text="Login ID"
                     AssociatedControlID="LoginID"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="LoginID" runat="server"></asp:TextBox>
        </div>
    </div>

<%--    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="Label11" runat="server" Text="Release Employee?"
                     AssociatedControlID="Released">
                  </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:CheckBox ID="Released" runat="server">
                </asp:CheckBox> 
        </div>
    </div>--%>


    <%--End--%>


    <div class="row">
        <div class="col-md-4">
        </div>
        <div class="col-md-6 text-left">
            <asp:Button ID="BackButton" runat="server" Text="Back" CausesValidation="false" OnClick="Back_Click" />&nbsp;&nbsp;
<%--            <asp:Button ID="AddButton" runat="server" OnClick="Add_Click" Text="Add"/>&nbsp;&nbsp;--%>
            <asp:Button ID="UpdateButton" runat="server" OnClick="Update_Click" Text="Update"/>&nbsp;&nbsp;
<%--            <asp:Button ID="DeleteButton" runat="server" OnClick="Delete_Click" Text="Delete"--%>
              OnClientClick="return CallFunction();"/>
        </div>
    </div>

    <br /><br />
    <div class="row">
        <div class="offset-2"> 
            <asp:DataList ID="Message" runat="server">
            <ItemTemplate>
                <%# Container.DataItem %>
            </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="row">
        <div class="offset-2"> 
            <label ID="LabelMessage1" name="LabelMessage1" runat="server" />
        </div>
    </div>
    <script type="text/javascript">
        function CallFunction() {
            return confirm("Are you sure you wish to delete this record?");
       }
   </script>


</asp:Content>
