﻿<%@ Page Title="ADD/EDIT CLASS" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ClassMaster.aspx.cs" Inherits="WebAppSai.ControlPanel.ClassMaster" %>
<%@ Register Src="../UserControl/Message.ascx" TagName="Message" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <br />
    <div class="row">
        <div class="col-lg-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Add/Edit Class
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group has-error">
                                Class Name
                                <asp:TextBox ID="txtClassName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group has-error">
                                Description
                                <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <br />
                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-outline btn-success"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-outline btn-warning"
                                    OnClick="btnCancel_Click" />
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <uc3:Message ID="Message" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Class List
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <center>
                            <asp:GridView ID="dgvClass" runat="server" Width="100%" AutoGenerateColumns="false" class="table table-striped"
                                GridLines="None" AllowPaging="false" CellPadding="0" CellSpacing="0" DataKeyNames="ClassId" ForeColor="#333333" OnRowCommand="">
                                <Columns>
                                    <asp:TemplateField HeaderText="SL" ItemStyle-Width="15px">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ClassName" HeaderText="Name" />
                                    <asp:TemplateField ItemStyle-Width="15px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/edit_button.png" CommandName="Ed"
                                                Width="15px" Height="15px" CommandArgument='<%# Eval("ClassId") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="15px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/Images/delete_button.png"
                                                CommandName="Del" Width="15px" Height="15px" OnClientClick="return confirm('Are You Sure?');" CommandArgument='<%# Eval("ClassId") %>' />
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
</asp:Content>
