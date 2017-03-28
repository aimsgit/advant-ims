Imports System.Data.SqlClient
Imports System.Data

Partial Class Result
    Inherits System.Web.UI.Page

    Protected Sub btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn.Click
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'html cariable which will be used to create the required html format for the function
        Dim html As String = ""


        Dim conn As SqlConnection = New SqlConnection(connectionString)
        'Opening a connection
        conn.Open()
        'Creating SQL Command
        Dim cmd As SqlCommand = New SqlCommand("SELECT  dbo.StudentMaster.NicNo, dbo.StudentMaster.StdName, dbo.NewStudentMarks.Grade, dbo.NewStudentMarks.Remarks,dbo.StudentMaster.Perm_Address, dbo.StudentMaster.City, dbo.StudentMaster.Title FROM dbo.StudentMaster LEFT OUTER JOIN dbo.NewStudentMarks ON dbo.StudentMaster.Std_Id = dbo.NewStudentMarks.STDID WHERE (dbo.StudentMaster.NicNo IS NOT NULL) AND (dbo.StudentMaster.BranchCode = '007205000000') AND (dbo.StudentMaster.Del_Flag = 'N') AND (dbo.StudentMaster.NicNo = '" + search.Text + "')", conn)

        'Create SqlDataReader which reads the data retrieved
        Dim r As SqlDataReader = cmd.ExecuteReader()
        'Declaring a DataTable to hold the data retrieved
        Dim dt As DataTable = New DataTable()
        'Load data from SqlDataReader to DataTable
        dt.Load(r)
        'Traverse through each row in the data table to fetch values

        Dim X As Integer = dt.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            Dim nic As String = dt.Rows(i).Item("NicNo").ToString()
            Dim q As String = dt.Rows(i).Item("Grade").ToString()
            Dim title As String = dt.Rows(i).Item("Title").ToString()
            Dim name As String = dt.Rows(i).Item("StdName").ToString()
            Dim adr As String = dt.Rows(i).Item("Perm_Address").ToString() + "," + dt.Rows(i).Item("City").ToString()
            Dim Center As String = dt.Rows(i).Item("Remarks").ToString()
            If nic = search.Text Then
                html = "<center><strong>" + title + name + " with Nic Number : " + search.Text + " has " + q + "<strong><br/><br/>"
                html += "<font size='2'><table  align = 'center'><tr><td bgcolor='blue'><b><font color='white'>TITLE</font></b></td><td bgcolor='blue'><b><font color='white'>NAME</font></b></td><td bgcolor='blue'> <b><font color='white'>NIC NUMBER</font></b></td><td bgcolor='blue'><b><font color='white'>RESULT</font></b></td><td bgcolor='blue'><b><font color='white'>ADDRESS</font></b></td><td bgcolor='blue'><b><font color='white'>CENTER NAME</font></b></td></tr>" + "<tr><td>" + title + "</td>" + "<td>" + name + "</td>" + "<td>" + nic + "</td><td>" + q + "</td><td>" + adr + "</td>" + "<td>" + Center + "</td>" + "</tr></table></font><br /> <div align='left' style='width: 75%;'>&nbsp;<br /><br /><strong>According to the results of GCE (A/L) 2013 Examination all students who may get selected to the University are required to get trained the Leadership and Positive Attitude Development Programme Conducted by Ministry of Higher Education. You have been selected to the first phase of this programme and your training centre is listed below.</strong></div><br /><img src='Images/centers.png'/></center>"
            
            End If
        Next

        If search.Text.Length = 0 Then
            html = "<font size='3' color='red'><b><center>Please enter Nic Number. EG : 000000000V</center></b></font>"

        End If
        If X = -1 And search.Text.Length <> 0 Then
            html = "<font size='3' color='red'><b><center>No such Nic Number found in the database. Please try again. EG : 000000000V</center></b></font>"
        End If

        '    foreach (DataRow row in dt.Rows) // Loop over the rows.
        ' {
        '     foreach (var item in row.ItemArray) // Loop over the items.
        '     {
        '      String nic = row["NicNo"].ToString();
        '            String q = row["Grade"].ToString();
        '            String title = row["Title"].ToString();
        '            String name = row["StdName"].ToString();
        '            String adr = row["Perm_Address"].ToString();
        '            String city = row["City"].ToString();
        '            if(nic == search)
        '            {
        '                    html = "<center><strong>"+title + name + " with Nic Number : " + search + " has Qualified<strong><br/><br/>";
        '                    html += "<font color='white'><table border='2' align = 'center' bgcolor='blue'><tr><td>Title</td><td>Name</td><td>NIC Number</td><td>Grade</td><td>Address</td><td>City</td></tr>"+"<tr><td>"+title+"</td>"+"<td>"+name+"</td>"+"<td>"+nic+"</td><td>"+q+"</td><td>"+adr+"</td>"+"<td>"+city+"</td>"+"</tr></table></font></center>";
        '            }
        'Else
        '            {
        '                html = "No such Nic Number found in the database. Please try again. EG : 000000000V";
        '            }
        '     }
        ' }

        '    'Return the final formatted data
        'return html;
        Label1.Text = html
    End Sub
End Class
