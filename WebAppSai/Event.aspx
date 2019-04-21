<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Event.aspx.cs" Inherits="WebAppSai.Event" %>

<%@ Register Src="UserControl/Message.ascx" TagName="Message" TagPrefix="uc3" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                                        Member Type
                                        <asp:DropDownList ID="ddlMemberType" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
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
                                        <%--<asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                            Format="dd MMM yyyy" TargetControlID="txtDOB">
                                        </asp:CalendarExtender>--%>
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
                                        <%--<asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-outline btn-success"
                                            OnClick="btnSave_Click" CausesValidation="true" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-outline btn-warning"
                                            OnClick="btnCancel_Click" CausesValidation="false" />--%>
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
                                <%--<center>
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
                                </center>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>
