'This form is to take the Database Backup.
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Net.Mail
Partial Class frmDBBackUp
    Inherits BasePage
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dt1 As New DataTable
    Dim GlobalFnt As New GlobalFunction
    Protected Sub btnBackupDatabase_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBackupDatabase.Click
        Try
            lblErrorMsg.Text = ""
            lblgreen.Text = ""
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            con = New SqlConnection(connectionString)
            Dim dt As New DateTime
            dt = System.DateTime.Now
            Dim dbName, dbpath As String

            dbName = Mid(connectionString, InStr(connectionString, "Catalog=") + 8)
            dt1 = DLReportsP.GetConfigValue()
            dbpath = dt1.Rows(0).Item("Config_Value").ToString()

            Dim backupname As String = "'" & dbpath & "AIMSBackup_" & dt.Day & "-" & dt.Month & "-" & dt.Year & "_" & dt.Hour & "-" & dt.Minute & "-" & dt.Second & ".bak" & "'"
            cmd = New SqlCommand("BACKUP DATABASE " & dbName & " TO DISK =" & backupname, con)
            con.Open()
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            con.Close()
            lblgreen.Text = "Database Backup created successfully in " + dbpath + " "
            lblErrorMsg.Text = ""
        Catch ex As Exception
            lblErrorMsg.Text = "Check the Path."
            lblgreen.Text = ""
        End Try
    End Sub
    Protected Sub BtnVersionNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVersionNo.Click
        Dim VBVersion As Double = GlobalFnt.VersionNo
        dt1 = DLReportsP.GetDBVersionNo()
        lblErrorMsg.Text = ""
        lblgreen.Text = ""
        Dim DBVersion As Double = dt1.Rows(0).Item("Config_Value").ToString()
        If VBVersion = DBVersion Then
            lblgreen.Text = "Both Versions are matching. Current Version No : " + Format(VBVersion, "F2")
            lblErrorMsg.Text = ""
        ElseIf VBVersion <> DBVersion Then
            lblErrorMsg.Text = " Version Nos are not matching. DataBase version No : " + Format(DBVersion, "F2") + " , " + " Build Version No : " + Format(VBVersion, "F2") + "  "
            lblgreen.Text = ""
        End If
    End Sub

    Protected Sub BtnDeleteCount_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDeleteCount.Click
        'Dim qry_str As String = "&FinStartDate=" & txtStartDate.Text & "&FinEndDate=" & txtEndDate.Text
        lblErrorMsg.Text = ""
        lblgreen.Text = ""
        Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "rptDBDeleteCount.aspx?" & QueryStr.Querystring()
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    End Sub

    Protected Sub BtnBiometric_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBiometric.Click
        Dim i As Integer = DLBiometric.SyncBiometricData()
        lblErrorMsg.Text = ""
        lblgreen.Text = ""
        If i > 0 Then
            lblgreen.Text = i.ToString + " Records synchronized Successfully. "
            lblErrorMsg.Text = ""
        Else
            lblErrorMsg.Text = " No Records to be synchronized. "
            lblgreen.Text = ""
        End If
    End Sub

    Protected Sub BtnBiometricStd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBiometricStd.Click
        Dim i As Integer = DLBiometric.SyncStdBiometricData()
        lblErrorMsg.Text = ""
        lblgreen.Text = ""
        If i > 0 Then
            lblgreen.Text = i.ToString + " Records synchronized Successfully. "
            lblErrorMsg.Text = ""
        Else
            lblErrorMsg.Text = " No Records to be synchronized. "
            lblgreen.Text = ""
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("BranchCode") <> "000000000000" Then
            Response.Redirect("AccessDenied.aspx")
        Else
        End If
    End Sub
End Class
