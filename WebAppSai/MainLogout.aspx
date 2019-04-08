<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainLogout.aspx.cs" Inherits="WebAppSai.MainLogout" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/images/omm.png" type="image/x-icon" rel="shortcut icon" />
    <link href="/images/omm.png" type="image/x-icon" rel="icon" />
    <script type="text/javascript">
        window.history.forward(1); 
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <asp:Timer ID="Timer1" runat="server" Interval="2000" ontick="Timer1_Tick">  
        </asp:Timer>
        
        
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <center>
            <div style="background-color:#CEE5FF; width:45%; border:solid 1px #1399EB; padding:50px 70px 50px 70px; font-family:Book Antiqua; font-size:18px;">
                Loging out, Please Wait...
            </div>    
        </center>
    </form>
</body>
</html>
