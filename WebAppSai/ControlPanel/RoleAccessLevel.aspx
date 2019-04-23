<%@ Page Title="ROLE ACCESS CONTROL" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RoleAccessLevel.aspx.cs" Inherits="WebAppSai.ControlPanel.RoleAccessLevel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .header {
            background-color: #356BA0;
            font-family: Calibri;
            font-size: 13px;
            text-transform: uppercase;
            color: #fff;
            font-weight: bold;
            padding: 8px 0 8px 0;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                            Manage Role Access
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group has-error">
                                        Role Name
                                        <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="true" Width="290px" CssClass="form-control"
                                            DataValueField="RoleId" DataTextField="RoleName" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Control Panel
                        </div>
                        <div class="panel-body">
                            <asp:CheckBoxList ID="ChkControlPanel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckListBox_SelectedIndexChanged">
                                <asp:ListItem Value="1000" Text="&nbsp;&nbsp;&nbsp;CONTROL PANEL"></asp:ListItem>
                                <asp:ListItem Value="1001" Text="&nbsp;&nbsp;&nbsp;ROLE"></asp:ListItem>
                                <asp:ListItem Value="1002" Text="&nbsp;&nbsp;&nbsp;ROLE ACCESS CONTROL"></asp:ListItem>
                                <asp:ListItem Value="1003" Text="&nbsp;&nbsp;&nbsp;ACTIVITY MASTER"></asp:ListItem>
                                <asp:ListItem Value="1004" Text="&nbsp;&nbsp;&nbsp;CLASS MASTER"></asp:ListItem>
                                <asp:ListItem Value="1005" Text="&nbsp;&nbsp;&nbsp;EVENT TYPE"></asp:ListItem>
                                <asp:ListItem Value="1006" Text="&nbsp;&nbsp;&nbsp;LOCALITY MASTER"></asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Main Menu
                        </div>
                        <div class="panel-body">
                            <asp:CheckBoxList ID="chkMainMenu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckListBox_SelectedIndexChanged">
                                <asp:ListItem Value="1008" Text="&nbsp;&nbsp;&nbsp;ADD/EDIT HOST"></asp:ListItem>
                                <asp:ListItem Value="1009" Text="&nbsp;&nbsp;&nbsp;ADD/EDIT BATCH"></asp:ListItem>
                                <asp:ListItem Value="1007" Text="&nbsp;&nbsp;&nbsp;ADD/EDIT MEMBERS"></asp:ListItem>
                                <asp:ListItem Value="1015" Text="&nbsp;&nbsp;&nbsp;ADD/EDIT EVENT"></asp:ListItem>
                                <asp:ListItem Value="1017" Text="&nbsp;&nbsp;&nbsp;ATTENDANCE"></asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Lists & Reports
                        </div>
                        <div class="panel-body">
                            <asp:CheckBoxList ID="ChkListReport" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckListBox_SelectedIndexChanged">
                                <asp:ListItem Value="1014" Text="&nbsp;&nbsp;&nbsp;REPORT"></asp:ListItem>
                                <asp:ListItem Value="1010" Text="&nbsp;&nbsp;&nbsp;BATCH"></asp:ListItem>
                                <asp:ListItem Value="1011" Text="&nbsp;&nbsp;&nbsp;EVENT"></asp:ListItem>
                                <asp:ListItem Value="1012" Text="&nbsp;&nbsp;&nbsp;HOST"></asp:ListItem>
                                <asp:ListItem Value="1013" Text="&nbsp;&nbsp;&nbsp;MEMBER"></asp:ListItem>
                                <asp:ListItem Value="1016" Text="&nbsp;&nbsp;&nbsp;ENROLMENT"></asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

