<%@ Page Title="ENROLMENT REPORT" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EnrolmentReport.aspx.cs" Inherits="WebAppSai.Report.EnrolmentReport" %>

<%@ Register Src="../UserControl/Message.ascx" TagName="Message" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Filter Criteria
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-4">
                                    <div class="form-group has-error">
                                        Enrolment Id
                                <asp:TextBox ID="txtEnrolmentId" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        Batch Id
                                <asp:TextBox ID="txtBatchId" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        Student Id
                                <asp:TextBox ID="txtStudentId" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        Enrolment No
                                <asp:TextBox ID="txtEnrolmentNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        Start Date
                                <asp:TextBox ID="txtStartDate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                            Format="dd MMM yyyy" TargetControlID="txtStartDate">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        End Date
                                <asp:TextBox ID="txtEndDate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                            Format="dd MMM yyyy" TargetControlID="txtStartDate">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <br />
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-outline btn-success"
                                            OnClick="btnSearch_Click" CausesValidation="true" />
                                        <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-outline btn-warning"
                                            OnClick="btnClear_Click" CausesValidation="false" />
                                        <asp:Button ID="btnExcel" runat="server" Text="Excel" class="btn btn-outline btn-primary"
                                            OnClick="btnExcel_Click" CausesValidation="false" />
                                        <asp:Button ID="btnPdf" runat="server" Text="PDF" class="btn btn-outline btn-primary"
                                            OnClick="btnPdf_Click" CausesValidation="false" />
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <uc3:Message ID="Message" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Enrolment List
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <center>
                                    <asp:GridView ID="dgvEnrolment" runat="server" Width="100%" AutoGenerateColumns="false" class="table table-striped"
                                        GridLines="None" AllowPaging="false" CellPadding="0" CellSpacing="0" ForeColor="#333333">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SL" ItemStyle-Width="15px">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:BoundField DataField="EnrolmentNo" HeaderText="Enrolment No" />
                                            <asp:BoundField DataField="BatchName" HeaderText="Batch Name" />
                                            <asp:BoundField DataField="ClassName" HeaderText="Class Name" />
                                            <asp:BoundField DataField="Year" HeaderText="Year" />
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:TemplateField HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <%# Convert.ToDateTime(Eval("StartDate").ToString()).ToString("dd MMM yyyy") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="End Date">
                                                <ItemTemplate>
                                                    <%# Convert.ToDateTime(Eval("EventEndDate").ToString()).ToString("dd MMM yyyy") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExcel" />
            <asp:PostBackTrigger ControlID="btnPdf" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
