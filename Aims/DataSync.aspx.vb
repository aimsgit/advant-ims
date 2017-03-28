Imports System.IO

Partial Class DataSync
    Inherits BasePage

    Protected Sub btnexport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnexport.Click
        Dim StrBuild As New StringBuilder
        Dim MobileDir As IO.DirectoryInfo
        Dim fstrm_write As IO.FileStream
        Dim swrite As IO.StreamWriter
        Dim pfile As String = ""
        Dim Dt As New DataTable
        Dim Dt1 As New DataTable
        Dim Dt2 As New DataTable
        Dim Dt3 As New DataTable
        Dim Dt4 As New DataTable

        ' Dim connection As New SqlClient.SqlConnection()
        'connection.ConnectionString = ConfigurationManager.ConnectionStrings("FMIS").ConnectionString
        'connection.Open()
        Try
            lblmsg.Text = ""

            'Dim sqlCmd As New SqlClient.SqlCommand("SELECT dbo.Mobilefarmer.f_code, dbo.Mobilefarmer.f_name, dbo.Mobilefarmer.f_village, dbo.EmployeeMaster.ContactNo FROM dbo.EmployeeMaster LEFT OUTER JOIN dbo.Farmer_Crop_Map ON dbo.EmployeeMaster.Emp_Code = dbo.Farmer_Crop_Map.PP_Code RIGHT OUTER JOIN   dbo.Mobilefarmer ON dbo.Farmer_Crop_Map.Farmer_Code = dbo.Mobilefarmer.f_code GROUP BY dbo.Mobilefarmer.f_code, dbo.Mobilefarmer.f_name, dbo.Mobilefarmer.f_village, dbo.EmployeeMaster.ContactNo", connection)
            'Dim sqlDa As New SqlClient.SqlDataAdapter(sqlCmd)
            Dt = DLExport.GetStudent()

            'lblmsg.Text = "sqlDa.Fill(Dt)"

            StrBuild.AppendLine(">>S")
            For q As Int32 = 0 To Dt.Rows.Count - 1
                StrBuild.AppendLine("""" + Dt.Rows(q).Item("Std_Id").ToString + """" + "," + """" + Dt.Rows(q).Item("Batch_No").ToString + """" + "," + """" + Dt.Rows(q).Item("StdCode").ToString + """" + "," + """" + Dt.Rows(q).Item("StdName").ToString + """" + "," + """" + Dt.Rows(q).Item("CourseName").ToString + """" + "," + """" + Dt.Rows(q).Item("Courseid").ToString + """")
            Next


            Dt = DLExport.GetStudentData()
            StrBuild.AppendLine(">>R")
            For q As Int32 = 0 To Dt.Rows.Count - 1
                StrBuild.AppendLine("""" + Dt.Rows(q).Item("StdCode").ToString + """" + "," + """" + Dt.Rows(q).Item("StdName").ToString + """" + "," + """" + Dt.Rows(q).Item("RouteName").ToString + """" + "," + """" + Dt.Rows(q).Item("Std_Id").ToString + """" + "," + """" + Dt.Rows(q).Item("RouteNo").ToString + """" + "," + """" + Dt.Rows(q).Item("BranchCode").ToString + """" + "," + """" + "S" + """")
            Next
            'lblmsg.Text = "bizDa.Fill(Dt4)"
            Dt = DLExport.GetEmployeeData()
            'StrBuild.AppendLine(">>R")
            For q As Int32 = 0 To Dt.Rows.Count - 1
                StrBuild.AppendLine("""" + Dt.Rows(q).Item("Emp_Code").ToString + """" + "," + """" + Trim(Dt.Rows(q).Item("Emp_Name")).ToString + """" + "," + """" + Dt.Rows(q).Item("RouteName").ToString + """" + "," + """" + Dt.Rows(q).Item("EmpID").ToString + """" + "," + """" + Dt.Rows(q).Item("RouteNo").ToString + """" + "," + """" + Dt.Rows(q).Item("BranchCode").ToString + """" + "," + """" + "E" + """")
            Next
            StrBuild.AppendLine(">>>>")
            'lblmsg.Text = "bizDa.Fill(Dt4)"
            pfile = "Mobile.txt"
            'lblmsg.Text = "\Mobile.txt"
            pfile = Server.MapPath("~\MobileData\") + Session("BranchCode") & pfile
            'lblmsg.Text = pfile
            'MobileDir = New IO.DirectoryInfo(Session("BranchCode"))
            If File.Exists(pfile) Then
                File.Delete(pfile)
            End If
            'lblmsg.Text = MobileDir.ToString
            'If Not MobileDir.Exists Then
            'MobileDir.Create()
            'lblmsg.Text = "MobileDir.Exists"
            'End If
            'lblmsg.Text = "MobileDir.Exists.no"
            'Bizcon.Close()
            'If File.Exists(pfile) Then
            '    File.Delete(pfile)
            'End If
            'lblmsg.Text = "File.Delete(pfile): " + pfile
            fstrm_write = New FileStream(pfile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite)
            'lblmsg.Text = "fstrm_write.ToString" + fstrm_write.ToString
            swrite = New StreamWriter(fstrm_write)
            'lblmsg.Text = "swrite.ToString" + swrite.ToString
            swrite.Write(StrBuild.ToString.TrimEnd)
            'lblmsg.Text = "StrBuild.ToString.TrimEnd" + StrBuild.ToString.TrimEnd
            swrite.Flush()
            'lblmsg.Text = "Flush"
            swrite.Close()
            lbl.Text = "Data Exported successfully"
            lbl.Visible = True
            'connection.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            'connection.Close()
            lblmsg.Text = "Cannot find the file"
        End Try
    End Sub
End Class
