<%@ Page Title="ADD/EDIT MEMBERS" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="WebAppSai.Members" %>

<%@ Register Src="UserControl/Message.ascx" TagName="Message" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .radioButtonList input[type="radio"] {
            width: auto;
            float: left;
            margin: 5px;
        }

        .radioButtonList label {
            width: auto;
            display: inline;
            float: left;
            margin: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <br />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
        <ProgressTemplate>
            <div class="divWaiting">
                <div class="loading">
                    <div class="loading-bar"></div>
                    <div class="loading-bar"></div>
                    <div class="loading-bar"></div>
                    <div class="loading-bar"></div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Add/Edit Members
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-3">
                                    <div class="form-group has-error">
                                        &nbsp;
                                        <asp:DropDownList ID="ddlSalutation" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Mr" Value="Mr"></asp:ListItem>
                                            <asp:ListItem Text="Miss" Value="Miss"></asp:ListItem>
                                            <asp:ListItem Text="Mrs" Value="Mrs"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-9">
                                    <div class="form-group has-error">
                                        First Name
                                        <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtFirstName" runat="server" ErrorMessage="Please enter first name" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group has-error">
                                        Last Name
                                        <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtLastName" runat="server" ErrorMessage="Please enter last name" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group has-error">
                                        Gender
                                        <asp:RadioButtonList ID="rbtnGender" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Male" Value="Male" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group has-error">
                                        Mobile No
                                        <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtMobileNo" runat="server" ErrorMessage="Please enter mobile no" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        Email Id
                                        <asp:TextBox ID="txtEmailId" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        Barcode Number
                                        <asp:TextBox ID="txtBarcodeNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        Date of birth
                                        <asp:TextBox ID="txtDOB" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                            Format="dd MMM yyyy" TargetControlID="txtDOB">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        Card Id
                                        <asp:TextBox ID="txtCardId" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        Occupation
                                        <asp:DropDownList ID="ddlOccupation" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <br />
                                        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-outline btn-success"
                                            OnClick="btnSave_Click" CausesValidation="true" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-outline btn-warning"
                                            OnClick="btnCancel_Click" CausesValidation="false" />
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <uc3:Message ID="Message" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6" style="min-height: 1000px">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Member List
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <center>
                                    <asp:GridView ID="dgvMember" runat="server" Width="100%" AutoGenerateColumns="false" class="table table-striped"
                                        GridLines="None" AllowPaging="false" CellPadding="0" CellSpacing="0" DataKeyNames="MemberId" ForeColor="#333333" OnRowCommand="dgvMember_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SL" ItemStyle-Width="15px">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:BoundField DataField="BarCodeNo" HeaderText="Barcode" />
                                            <asp:BoundField DataField="CardId" HeaderText="Card Id" />
                                            <asp:BoundField DataField="PersonalMobile" HeaderText="Mobile" />
                                            <asp:TemplateField ItemStyle-Width="15px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnSettings" runat="server" class="fa fa-cogs fa-fw" CommandName="Settings" CausesValidation="false"
                                                        CommandArgument='<%# Eval("MemberId") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="15px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEdit" runat="server" class="fa fa-pencil-square-o fa-fw" CommandName="Ed" CausesValidation="false"
                                                        CommandArgument='<%# Eval("MemberId") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="15px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" class="fa fa-trash-o fa-fw" CausesValidation="false"
                                                        CommandName="Del" OnClientClick="return confirm('Are You Sure?');" CommandArgument='<%# Eval("MemberId") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#5bb0de" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#379ed6" Font-Bold="True" ForeColor="White" />
                                        <RowStyle CssClass="RowStyle" BackColor="#F7F6F3" ForeColor="#333333" />
                                        <EditRowStyle BackColor="#999999" />
                                        <EmptyDataRowStyle CssClass="EditRowStyle" />
                                        <AlternatingRowStyle CssClass="AltRowStyle" BackColor="White" ForeColor="#284775" />
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="12" FirstPageText="First"
                                            LastPageText="Last" />
                                        <PagerStyle CssClass="PagerStyle" BackColor="#379ed6" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <EmptyDataTemplate>
                                            No Record Found...
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <a id="lnk1" runat="server"></a>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="myModalPopupbackGrnd"
                runat="server" TargetControlID="lnk1" PopupControlID="Panel2" CancelControlID="imgbtn1">
                <Animations>
                 <OnShown><Fadein Duration="0.50" /></OnShown>
                </Animations>
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel2" runat="server" CssClass="myModalPopup-16" Style="display: none;">
                <asp:Panel ID="Panel4" runat="server" class="popup-working-section-extra-height" ScrollBars="Auto">
                    <h6 id="popupHeader2" runat="server" class="popup-header-companyname"></h6>
                    <asp:TabContainer ID="TabContainer2" runat="server" Width="100%" CssClass="MyTabStyle"
                        ActiveTabIndex="0" OnActiveTabChanged="TabContainer2_ActiveTabChanged" AutoPostBack="true">
                        <asp:TabPanel ID="TabPanel1" runat="server">
                            <HeaderTemplate>
                                Member Address
                            </HeaderTemplate>
                            <ContentTemplate>
                                <br />
                                <div class="accountInfo" style="width: 97%; float: left">
                                    <fieldset>
                                        <legend>Enter member address details</legend>
                                        <table class="popup-table">
                                            <tr>
                                                <td>Residential Address
                                                    <asp:TextBox ID="txtResidentialAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Locality
                                                    <asp:DropDownList ID="ddlLocality" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Emirates
                                                    <asp:TextBox ID="txtEmirates" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnAddressSave" runat="server" Text="Save" class="btn btn-outline btn-success"
                                                        OnClick="btnAddressSave_Click" CausesValidation="false" />
                                                    <asp:Button ID="btnAddressCancel" runat="server" Text="Cancel" class="btn btn-outline btn-warning"
                                                        OnClick="btnAddressCancel_Click" CausesValidation="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <uc3:Message ID="MessageAddress" runat="server"></uc3:Message>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <fieldset>
                                        <legend>Member's address list</legend>
                                        <center>
                                            <asp:GridView ID="gvAddress" runat="server" Width="100%" AutoGenerateColumns="false" class="table table-striped"
                                                GridLines="None" AllowPaging="false" CellPadding="0" CellSpacing="0" DataKeyNames="MemberAddressDetailsId" ForeColor="#333333" OnRowCommand="gvAddress_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SL" ItemStyle-Width="15px">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Residential Address
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span title='<%# Eval("ResidentialAddress") %>'>
                                                                <%# (Eval("ResidentialAddress").ToString().Length>50)?Eval("ResidentialAddress").ToString().Substring(0,50)+"...":Eval("ResidentialAddress").ToString() %>
                                                            </span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="LocalityName" HeaderText="Locality" />
                                                    <asp:BoundField DataField="Emirates" HeaderText="Emirates" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEdit" runat="server" class="fa fa-pencil-square-o fa-fw" CommandName="Ed" CausesValidation="false"
                                                                CommandArgument='<%# Eval("MemberAddressDetailsId") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDelete" runat="server" class="fa fa-trash-o fa-fw" CausesValidation="false"
                                                                CommandName="Del" OnClientClick="return confirm('Are You Sure?');" CommandArgument='<%# Eval("MemberAddressDetailsId") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#5bb0de" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#379ed6" Font-Bold="True" ForeColor="White" />
                                                <RowStyle CssClass="RowStyle" BackColor="#F7F6F3" ForeColor="#333333" />
                                                <EditRowStyle BackColor="#999999" />
                                                <AlternatingRowStyle CssClass="AltRowStyle" BackColor="White" ForeColor="#284775" />
                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="12" FirstPageText="First"
                                                    LastPageText="Last" />
                                                <PagerStyle CssClass="PagerStyle" BackColor="#379ed6" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <EmptyDataTemplate>
                                                    No Record Found...
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </center>
                                    </fieldset>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel ID="TabPanel2" runat="server">
                            <HeaderTemplate>
                                Member Job
                            </HeaderTemplate>
                            <ContentTemplate>
                                <br />
                                <div class="accountInfo" style="width: 97%; float: left">
                                    <fieldset>
                                        <legend>Enter member job details</legend>
                                        <table class="popup-table">
                                            <tr>
                                                <td>Company Name
                                                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Company Address
                                                    <asp:TextBox ID="txtCompanyAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Emirates
                                                    <asp:TextBox ID="txtCompanyEmirates" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnJobSave" runat="server" Text="Save" class="btn btn-outline btn-success"
                                                        OnClick="btnJobSave_Click" CausesValidation="false" />
                                                    <asp:Button ID="btnJobCancel" runat="server" Text="Cancel" class="btn btn-outline btn-warning"
                                                        OnClick="btnJobCancel_Click" CausesValidation="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <uc3:Message ID="MessageJob" runat="server"></uc3:Message>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <fieldset>
                                        <legend>Member's job list</legend>
                                        <center>
                                            <asp:GridView ID="gvJob" runat="server" Width="100%" AutoGenerateColumns="false" class="table table-striped"
                                                GridLines="None" AllowPaging="false" CellPadding="0" CellSpacing="0" DataKeyNames="MemberJobDetailsId"
                                                ForeColor="#333333" OnRowCommand="gvCompany_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SL" ItemStyle-Width="15px">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Company Address
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span title='<%# Eval("CompanyAddress") %>'>
                                                                <%# (Eval("CompanyAddress").ToString().Length>50)?Eval("CompanyAddress").ToString().Substring(0,50)+"...":Eval("CompanyAddress").ToString() %>
                                                            </span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Emirates" HeaderText="Emirates" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEdit" runat="server" class="fa fa-pencil-square-o fa-fw" CommandName="Ed" CausesValidation="false"
                                                                CommandArgument='<%# Eval("MemberJobDetailsId") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDelete" runat="server" class="fa fa-trash-o fa-fw" CausesValidation="false"
                                                                CommandName="Del" OnClientClick="return confirm('Are You Sure?');" CommandArgument='<%# Eval("MemberJobDetailsId") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#5bb0de" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#379ed6" Font-Bold="True" ForeColor="White" />
                                                <RowStyle CssClass="RowStyle" BackColor="#F7F6F3" ForeColor="#333333" />
                                                <EditRowStyle BackColor="#999999" />
                                                <AlternatingRowStyle CssClass="AltRowStyle" BackColor="White" ForeColor="#284775" />
                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="12" FirstPageText="First"
                                                    LastPageText="Last" />
                                                <PagerStyle CssClass="PagerStyle" BackColor="#379ed6" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <EmptyDataTemplate>
                                                    No Record Found...
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </center>
                                    </fieldset>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel ID="TabPanel3" runat="server">
                            <HeaderTemplate>
                                Member Activity
                            </HeaderTemplate>
                            <ContentTemplate>
                                <br />
                                <div class="accountInfo" style="width: 97%; float: left">
                                    <fieldset>
                                        <legend>Enter member activity details</legend>
                                        <table class="popup-table">
                                            <tr>
                                                <td>Activity
                                                    <asp:DropDownList ID="ddlActivity" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Location
                                                    <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>From Date
                                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                                        Format="dd MMM yyyy" TargetControlID="txtFromDate">
                                                    </asp:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>To Date
                                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True"
                                                        Format="dd MMM yyyy" TargetControlID="txtToDate">
                                                    </asp:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Like Activity
                                                    <asp:RadioButtonList ID="rbtnLikeActivity" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="True" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="False"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnActivitySave" runat="server" Text="Save" class="btn btn-outline btn-success"
                                                        OnClick="btnActivitySave_Click" CausesValidation="false" />
                                                    <asp:Button ID="btnActivityCancel" runat="server" Text="Cancel" class="btn btn-outline btn-warning"
                                                        OnClick="btnActivityCancel_Click" CausesValidation="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <uc3:Message ID="MessageActivity" runat="server"></uc3:Message>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <fieldset>
                                        <legend>Member's activity list</legend>
                                        <center>
                                            <asp:GridView ID="gvActivity" runat="server" Width="100%" AutoGenerateColumns="false" class="table table-striped"
                                                GridLines="None" AllowPaging="false" CellPadding="0" CellSpacing="0" DataKeyNames="MemberActivityId"
                                                ForeColor="#333333" OnRowCommand="gvActivity_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SL" ItemStyle-Width="15px">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ActivityName" HeaderText="Activity Name" />
                                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                                    <asp:TemplateField HeaderText="From Date">
                                                        <ItemTemplate>
                                                            <%# Convert.ToDateTime(Eval("FromDate").ToString()).ToString("dd MMM yyyy") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="To Date">
                                                        <ItemTemplate>
                                                            <%# Convert.ToDateTime(Eval("ToDate").ToString()).ToString("dd MMM yyyy") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="LikeActivity" HeaderText="Like Activity" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEdit" runat="server" class="fa fa-pencil-square-o fa-fw" CommandName="Ed" CausesValidation="false"
                                                                CommandArgument='<%# Eval("MemberActivityId") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDelete" runat="server" class="fa fa-trash-o fa-fw" CausesValidation="false"
                                                                CommandName="Del" OnClientClick="return confirm('Are You Sure?');" CommandArgument='<%# Eval("MemberActivityId") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#5bb0de" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#379ed6" Font-Bold="True" ForeColor="White" />
                                                <RowStyle CssClass="RowStyle" BackColor="#F7F6F3" ForeColor="#333333" />
                                                <EditRowStyle BackColor="#999999" />
                                                <AlternatingRowStyle CssClass="AltRowStyle" BackColor="White" ForeColor="#284775" />
                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="12" FirstPageText="First"
                                                    LastPageText="Last" />
                                                <PagerStyle CssClass="PagerStyle" BackColor="#379ed6" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <EmptyDataTemplate>
                                                    No Record Found...
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </center>
                                    </fieldset>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel ID="TabPanel4" runat="server">
                            <HeaderTemplate>
                                Member Relations
                            </HeaderTemplate>
                            <ContentTemplate>
                                <br />
                                <div class="accountInfo" style="width: 97%; float: left">
                                    <fieldset>
                                        <legend>Enter member relation details</legend>
                                        <table class="popup-table">
                                            <tr>
                                                <td>Person
                                                    <asp:DropDownList ID="ddlPerson" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Relation
                                                     <asp:DropDownList ID="ddlRelation" CssClass="form-control" runat="server">
                                                     </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnRelationSave" runat="server" Text="Save" class="btn btn-outline btn-success"
                                                        OnClick="btnRelationSave_Click" CausesValidation="false" />
                                                    <asp:Button ID="btnRelationCancel" runat="server" Text="Cancel" class="btn btn-outline btn-warning"
                                                        OnClick="btnRelationCancel_Click" CausesValidation="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <uc3:Message ID="MessageRelation" runat="server"></uc3:Message>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <fieldset>
                                        <legend>Member's relation list</legend>
                                        <center>
                                            <asp:GridView ID="gvRelation" runat="server" Width="100%" AutoGenerateColumns="false" class="table table-striped"
                                                GridLines="None" AllowPaging="false" CellPadding="0" CellSpacing="0" DataKeyNames="MemberRelationMappingId"
                                                ForeColor="#333333" OnRowCommand="gvRelation_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SL" ItemStyle-Width="15px">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <%# Eval("FirstMemberName").ToString() %> <%# string.Concat(Eval("RelationName").ToString()," of") %> <%# Eval("SecondMemberName").ToString() %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEdit" runat="server" class="fa fa-pencil-square-o fa-fw" CommandName="Ed" CausesValidation="false"
                                                                CommandArgument='<%# Eval("MemberRelationMappingId") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDelete" runat="server" class="fa fa-trash-o fa-fw" CausesValidation="false"
                                                                CommandName="Del" OnClientClick="return confirm('Are You Sure?');" CommandArgument='<%# Eval("MemberRelationMappingId") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#5bb0de" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#379ed6" Font-Bold="True" ForeColor="White" />
                                                <RowStyle CssClass="RowStyle" BackColor="#F7F6F3" ForeColor="#333333" />
                                                <EditRowStyle BackColor="#999999" />
                                                <AlternatingRowStyle CssClass="AltRowStyle" BackColor="White" ForeColor="#284775" />
                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="12" FirstPageText="First"
                                                    LastPageText="Last" />
                                                <PagerStyle CssClass="PagerStyle" BackColor="#379ed6" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <EmptyDataTemplate>
                                                    No Record Found...
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </center>
                                    </fieldset>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel ID="TabPanel5" runat="server">
                            <HeaderTemplate>
                                Member Settings
                            </HeaderTemplate>
                            <ContentTemplate>
                                <br />
                                <div class="accountInfo" style="width: 97%; float: left">
                                    <fieldset>
                                        <legend>Enter member setting details</legend>
                                        <table class="popup-table">
                                            <tr>
                                                <td>Member Active
                                                    <asp:RadioButtonList ID="rbtnIsActive" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="True" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="False"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Can Login into Application
                                                    <asp:RadioButtonList ID="rbtnIsAppLoginEnabled" CssClass="radioButtonList" runat="server"
                                                        RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtnIsAppLoginEnabled_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Text="Yes" Value="True" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="False"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Username
                                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Password
                                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="Regex5" runat="server" ControlToValidate="txtPassword"
                                                        ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,10}"
                                                        ErrorMessage="Password must contain: Minimum 8 and Maximum 10 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character"
                                                        ForeColor="Red" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Roles
                                                    <asp:CheckBoxList ID="chkRoles" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnSettingsSave" runat="server" Text="Save" class="btn btn-outline btn-success"
                                                        OnClick="btnSettingsSave_Click" CausesValidation="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <uc3:Message ID="MessageSettings" runat="server"></uc3:Message>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
                </asp:Panel>
                <img id="imgbtn1" runat="server" src="../images/close-button.png" title="Close popup" style="float: right; margin-right: 1px; cursor: pointer"
                    alt="Close" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
