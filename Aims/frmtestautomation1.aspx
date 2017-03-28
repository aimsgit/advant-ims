<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmtestautomation1.aspx.vb"
    Inherits="frmtestautomation1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<link rel="stylesheet" type="text/css" href="lib/sweet-alert.css"/>
</head>

<script type="text/javascript">
    changeColor();
</script>
<script src="lib/sweet-alert.min.js" type="text/javascript"></script> 


<script type="text/javascript">
    //    var pop = 0;
    var pagecount =1;
    //    var nIntervId;

    //    function sleep(milliseconds) {
    //        var start = new Date().getTime();
    //        for (var i = 0; i < 1e7; i++) {
    //            if ((new Date().getTime() - start) > milliseconds) {
    //                break;
    //            }
    //        }
    //    }
//        function sleepFor(sleepDuration) {
//            var now = new Date().getTime();
//           while (new Date().getTime() < now + sleepDuration) { /* do nothing */ }
//       }
    //     setInterval(function() { pgLoaded() }, 2000);


    function changeColor() {

        // Call function with 1000 milliseconds gap
        
        setInterval(pgLoaded, 9000);
        //        alert("Loading");
    }

    //    function loadPage() {
    //        var ddl_id = document.getElementById("ddlLinkName");
    //        document.getElementById("iframe").src = "http://localhost:1742/AIMS_20150207/" + ddl_id.options[ddl_id.selectedIndex].text;
    //        alert("http://localhost:1742/AIMS_20150207/" + ddl_id.options[ddl_id.selectedIndex].text);
    //    }


    function pgLoaded() {

        //        alert({ title: "Auto close alert!", text: pagecount, timer: 5000 });
        var ddl_id = document.getElementById("ddlLinkName");
        //        alert({ title: "Auto close alert!", text: "http://localhost:1742/AIMS_20150207/" + ddl_id.options[pagecount + 1].text), timer: 5000 });
        //            alert("http://localhost:1742/AIMS_20150207/" + ddl_id.options[pagecount + 1].text);

        try {

            do {
//                swal({ title: "Auto close alert!", text: pagecount, timer: 500 });
                swal({ title: "Auto close alert!", text: ddl_id.options[pagecount].text, timer: 500 });
                document.getElementById("iframe").src = "http://localhost:1241/AIMS_20150207/" + ddl_id.options[pagecount].text;
               
//                pagecount = pagecount+1;
            } 
            while (pagecount>500);
           
        }

        catch (err) {
              alert(err);
//            alter(pagecount);
        }
        finally {
            pagecount = pagecount+1;


        }
        //            pagecount++;
    }

    //    }
    
 

   

</script>

<body>
<script type="text/javascript">
    //call after page loaded
    window.onload = changeColor; 
</script>

    <form id="form1" runat="server">
    <center>
        <asp:Label ID="lblTitle" runat="server" Text="Form Link* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
        <asp:DropDownList ID="ddlLinkName" TabIndex="3" runat="server" SkinID="ddl" DataSourceID="ObjLinkName"
            DataValueField="Code" DataTextField="LinkName" AppendDataBoundItems="true" AutoPostBack="true">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjLinkName" runat="server" SelectMethod="GetLinkName"
            TypeName="TestAutomationDL"></asp:ObjectDataSource>
        <div align='center'>
            <button type='button' onclick='changeColor()'>
                Test ALL!</button>
            <button onclick='loadPage()'>
                Load</button></div>
        <div align='center'>
            <iframe src='' id='iframe' style='width: 1200px; height: 900px;'>
            </iframe>
        </div>
    </center>
    </form>
</body>
</html>
