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
                <div class="col-lg-6" style="min-height:1000px">
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
                                             <asp:TemplateField ItemStyle-Width="15px">
                                                <ItemTemplate>
                                                    <ul class="nav navbar-grid-links navbar-left">
                                                        <li class="dropdown">
                                                            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                                                <i class="fa fa-wrench fa-fw"></i><i class="fa fa-caret-down"></i>
                                                            </a>
                                                            <ul class="dropdown-menu dropdown-messages">
                                                                <li>
                                                                    <a href="#">
                                                                        <input type="submit" />
                                                                    </a>
                                                                </li>
                                                                <li class="divider"></li>
                                                            </ul>
                                                            <!-- /.dropdown-messages -->
                                                        </li>
                                                    </ul>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:BoundField DataField="BarCodeNo" HeaderText="Barcode" />
                                            <asp:BoundField DataField="CardId" HeaderText="Card Id" />
                                            <asp:BoundField DataField="PersonalMobile" HeaderText="Mobile" />
                                            <asp:TemplateField ItemStyle-Width="15px">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/edit_button.png" CommandName="Ed" CausesValidation="false"
                                                        Width="15px" Height="15px" CommandArgument='<%# Eval("MemberId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="15px">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/Images/delete_button.png" CausesValidation="false"
                                                        CommandName="Del" Width="15px" Height="15px" OnClientClick="return confirm('Are You Sure?');" CommandArgument='<%# Eval("MemberId") %>' />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
