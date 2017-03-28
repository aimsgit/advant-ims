<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AutomationTest.aspx.vb"
    Inherits="AutomationTest" Title="Untitled Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Form Automation</title>
<script>
    function redirect() {
        var testwindow = window.open("frmtestautomation1.aspx", "testwindow", 'width=800,height=600,resizable=yes,toolbar=yes,scrollbars=yes');
//        var fileref = testwindow.document.createElement("script");
        fileref.setAttribute("type", "text/javascript");
//        fileref.setAttribute("src", "traverse.js");
        testwindow.document.body.appendChild(fileref);
//        testwindow.document.body.innerHTML += "<div align='center'><select id='formlist' style='width:150px;' onchange='load()''></select>&nbsp&nbsp&nbsp<button type='button' onclick='reset()'>Test ALL!</button><button onclick='stop()'>Stop</button></div><div align='center'><iframe src='' id='iframe' onload='pgLoaded()' style='width:1200px;height:900px;'></iframe></div>";
    }
    //To add options to "select" aka combobox use the following format <select> <option>Option1</option> </select>
</script>
</head>
<body>
<center>
<h1>Test Automation</h1>
<button onclick="redirect()">Begin</button>
</center>
</body>
</html>
