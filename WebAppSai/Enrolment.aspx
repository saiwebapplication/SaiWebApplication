<%@ Page Title="ENROLMENT" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Enrolment.aspx.cs" Inherits="WebAppSai.Enrolment" %>

<%@ Register Src="UserControl/Message.ascx" TagName="Message" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>--%>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            populateStudents();
        });
        function populateStudents() {
            $("[id$=txtStudentName]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Enrolment.aspx/GetStudents") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfStudentId]").val(i.item.val);
                },
                minLength: 1
            });
        }
    </script>
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
            <script type="text/javascript">
                Sys.Application.add_load(populateStudents);
            </script>
            <div class="row">
                <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Add/Edit Enrolment
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group has-error">
                                        Class
                                        <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reqFavoriteColor" Text="Please select class"
                                            InitialValue="0" ControlToValidate="ddlClass" ForeColor="Red"
                                            runat="server" />
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group has-error">
                                        Batch
                                        <asp:DropDownList ID="ddlBatch" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Please select batch"
                                            InitialValue="0" ControlToValidate="ddlBatch" ForeColor="Red"
                                            runat="server" />
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group has-error">
                                        Enrolment No
                                        <asp:TextBox ID="txtEnrolmentNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtEnrolmentNo" runat="server" ErrorMessage="Please enter enrolment no" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group has-error">
                                        Student
                                    <asp:TextBox ID="txtStudentName" runat="server" CssClass="form-control" />
                                        <asp:HiddenField ID="hfStudentId" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtStudentName" runat="server" ErrorMessage="Please select student" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group has-error">
                                        Start Date
                                        <asp:TextBox ID="txtStartDate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                            Format="dd MMM yyyy" TargetControlID="txtStartDate">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtStartDate" runat="server"
                                            ErrorMessage="Please select start date" ForeColor="Red"></asp:RequiredFieldValidator>
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
                <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Enrolment List
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <center>
                                    <asp:GridView ID="dgvEnrolment" runat="server" Width="100%" AutoGenerateColumns="false" class="table table-striped"
                                        GridLines="None" AllowPaging="false" CellPadding="0" CellSpacing="0" DataKeyNames="EnrollmentId" ForeColor="#333333" OnRowCommand="dgvEnrolment_RowCommand">
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
                                            <asp:TemplateField ItemStyle-Width="15px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEdit" runat="server" class="fa fa-pencil-square-o fa-fw" CommandName="Ed" CausesValidation="false"
                                                        CommandArgument='<%# Eval("EnrollmentId") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="15px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" class="fa fa-trash-o fa-fw" CausesValidation="false"
                                                        CommandName="Del" OnClientClick="return confirm('Are You Sure?');" CommandArgument='<%# Eval("EnrollmentId") %>'></asp:LinkButton>
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
