<%@ Page Title="DASHBOARD" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WebAppSai.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Morris Charts CSS -->
    <link href="bower_components/morrisjs/morris.css" rel="stylesheet" />
    <!-- Timeline CSS -->
    <link href="dist/css/timeline.css" rel="stylesheet" />
    <style type="text/css">
        .over img {
            margin: 0;
            background: yellow;
            position: absolute;
            top: 50%;
            left: 50%;
            margin-right: -50%;
            transform: translate(-50%, -50%);
        }
    </style>
    <script type="text/javascript">
        function showSuccessDivClose() {
            alert('Settings change will take effect from next login. To change user settings goto User Settings page.')
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row" style="text-align:center">
        <img src="images/giphy.gif" style="margin:auto; height:80vh; opacity: 0.2;filter: alpha(opacity=20);" />
    </div>
</asp:Content>
