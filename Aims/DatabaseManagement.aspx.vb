Imports System.Data.SqlClient
Imports System.Windows.Forms
Partial Class DatabaseManagement

    Inherits BasePage

    Dim con As SqlConnection

    Dim cmd As SqlCommand


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBackupDatabase.Click
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        con = New SqlConnection(connectionString)
        Dim dt As New DateTime
        dt = System.DateTime.Now
        Dim dbName As String
        dbName = Mid(connectionString, InStr(connectionString, "Catalog=") + 8)
        Dim backupname As String = "'" & "C:\db\advant\" & "Backup_" & dt.Day & "-" & dt.Month & "-" & dt.Year & "-" & dt.Hour & "-" & dt.Minute & ".bak" & "'"
        cmd = New SqlCommand("BACKUP DATABASE " & dbName & " TO DISK =" & backupname, con)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Database Backup created successfuly.")
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRestoreDatabase.Click
        MsgBox("Not available.")

        'Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant1").ConnectionString
        'con = New SqlConnection(connectionString)
        ''cmd = New SqlCommand("RESTORE DATABASE EDU FROM DISK = 'C:\PROSQL.bak'WITH  FILE = 1,  MOVE N'EDU' TO N'C:\IMS.mdf',  MOVE N'EDU_log' TO N'C:\IMS.ldf',  NOUNLOAD,  REPLACE,  STATS = 10", con)
        'cmd = New SqlCommand("RESTORE DATABASE AdvantIMSStandBy_94930 FROM DISK = 'c:\db\advant\PROSQL.bak'WITH  FILE = 1,  MOVE N'AdvantIMSStandBy_94930' TO N'C:\AdvantIMSStandBy_94930.mdf',  MOVE N'AdvantIMSStandBy_94930_log' TO N'C:\AdvantIMSStandBy_94930.ldf',  NOUNLOAD,  REPLACE,  STATS = 10", con)

        'con.Open()

        'cmd.ExecuteNonQuery()

        'con.Close()
        'MsgBox("Database Restore is successfuly.")
    End Sub

    <System.Web.Services.WebMethod()> _
        Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
