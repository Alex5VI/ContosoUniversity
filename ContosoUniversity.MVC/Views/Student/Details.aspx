<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContosoUniversity.BE.Estudiante>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Estudiante</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.StudentID) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.StudentID) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.LastName) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.LastName) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.FirstName) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.FirstName) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.EnrollmentDate) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.EnrollmentDate) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
