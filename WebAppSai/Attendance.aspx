<%@ Page Title="ATTENDANCE" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="WebAppSai.Attendance" %>

<%@ Register Src="UserControl/Message.ascx" TagName="Message" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <%--DateTime picker related--%>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/css/bootstrap-datetimepicker.min.css" />
    <%--DateTime picker related End--%>
    <%--DateTime picker related--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.6/moment.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
    <%--DateTime picker related End--%>

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
     <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                prepareDateTimeControls();
            });
        });
        function prepareDateTimeControls() {
            $('.calendar').datetimepicker({ format: 'DD MMM YYYY hh:mm A' });
            $('.calendar').val($('#hfCurrentDateTime').val());
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
                Sys.Application.add_load(prepareDateTimeControls);
            </script>
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Attendance Criteria
                        </div>
                        <div class="panel-body">
                            <asp:TabContainer ID="TabContainer2" runat="server" Width="100%" CssClass="TabStyle"
                                ActiveTabIndex="0" OnActiveTabChanged="TabContainer2_ActiveTabChanged" AutoPostBack="true">
                                <asp:TabPanel ID="TabPanel1" runat="server" Style="background-color: #bebebe;" TabIndex="0">
                                    <HeaderTemplate>
                                        Student Attendance
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <div class="col-lg-4">
                                            <div class="form-group has-error">
                                                Class
                                        <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                        </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="reqFavoriteColor" Text="Please select class"
                                                    InitialValue="0" ControlToValidate="ddlClass" ForeColor="Red"
                                                    runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group has-error">
                                                Batch
                                        <asp:DropDownList ID="ddlBatch" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Please select batch"
                                                    InitialValue="0" ControlToValidate="ddlBatch" ForeColor="Red"
                                                    runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group has-error">
                                                Attendance Date
                                                <asp:TextBox ID="txtAttendanceDate" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtAttendanceDate" runat="server" ErrorMessage="Please enter attendance date" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                                Student
                                                <asp:TextBox ID="txtStudentName" runat="server" CssClass="form-control" />
                                                <asp:HiddenField ID="hfStudentId" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <br />
                                                <asp:Button ID="btnSearch" runat="server" Text="Show" class="btn btn-outline btn-success"
                                                    OnClick="btnSearch_Click" />
                                                <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-outline btn-warning"
                                                    OnClick="btnClear_Click" CausesValidation="False" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <uc3:Message ID="Message" runat="server" />
                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" Style="background-color: #bebebe;" TabIndex="0">
                                    <HeaderTemplate>
                                        Event Attendance
                                    </HeaderTemplate>
                                      <ContentTemplate>
                                        <div class="col-lg-4">
                                            <div class="form-group has-error">
                                                Class
                                        <asp:DropDownList ID="ddlClassEvent" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                        </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Please select class"
                                                    InitialValue="0" ControlToValidate="ddlClassEvent" ForeColor="Red"
                                                    runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group has-error">
                                                Batch
                                        <asp:DropDownList ID="ddlBatchEvent" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Please select batch"
                                                    InitialValue="0" ControlToValidate="ddlBatchEvent" ForeColor="Red"
                                                    runat="server" />
                                            </div>
                                        </div>
                                          <div class="col-lg-4">
                                            <div class="form-group has-error">
                                                Event
                                        <asp:DropDownList ID="ddlEvent" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="Please select event"
                                                    InitialValue="0" ControlToValidate="ddlEvent" ForeColor="Red"
                                                    runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group has-error">
                                                Attendance Date
                                                <asp:TextBox ID="txtAttendanceDateEvent" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtAttendanceDateEvent" runat="server" ErrorMessage="Please enter attendance date" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                Enrolment No
                                                <asp:TextBox ID="txtEnrolmentNoEvent" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                Student
                                                <asp:TextBox ID="txtStudentEvent" runat="server" CssClass="form-control" />
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <br />
                                                <asp:Button ID="btnSearchEvent" runat="server" Text="Show" class="btn btn-outline btn-success"
                                                    OnClick="btnSearchEvent_Click" />
                                                <asp:Button ID="btnClearEvent" runat="server" Text="Clear" class="btn btn-outline btn-warning"
                                                    OnClick="btnClearEvent_Click" CausesValidation="False" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <uc3:Message ID="Message1" runat="server" />
                                        </div>
                                    </ContentTemplate>

                                </asp:TabPanel>
                            </asp:TabContainer>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Attendance Criteria
                        </div>
                        <div class="panel-body">
                            <center>
                                <asp:HiddenField ID="hfCurrentDateTime" runat="server" ClientIDMode="Static" />
                                <asp:GridView ID="dgvStudentAttendance" runat="server" Width="100%" AutoGenerateColumns="false" class="table table-striped"
                                    GridLines="None" AllowPaging="false" CellPadding="0" CellSpacing="0" 
                                    DataKeyNames="MemberId,AttendanceId" ForeColor="#333333" OnRowDataBound="dgvStudentAttendance_RowDataBound" OnRowCommand="dgvStudentAttendance_RowCommand">
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
                                        <asp:TemplateField ItemStyle-Width="150px" HeaderText="In Datetime">
                                            <ItemTemplate>
                                                <input type="text" id="txtStartDateTime" name="txtStartDateTime" runat="server" class="form-control calendar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="15px" HeaderText="In" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAttendance" runat="server" AutoPostBack="true" OnCheckedChanged="chkAttendance_CheckedChanged" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="150px" HeaderText="Out Datetime">
                                            <ItemTemplate>
                                                <input type="text" id="txtEndDateTime" name="txtEndDateTime" runat="server" class="form-control calendar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="15px" HeaderText="Out" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAttendanceOut" runat="server" AutoPostBack="true" OnCheckedChanged="chkAttendanceOut_CheckedChanged" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="15px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" style="margin:5px" class="fa fa-trash-o fa-fw" CausesValidation="false"
                                                        CommandName="Del" OnClientClick="return confirm('Are You Sure?');" CommandArgument='<%# Eval("AttendanceId") %>'></asp:LinkButton>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
