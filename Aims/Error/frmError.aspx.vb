Imports System.Data.SqlClient

Partial Class Error_frmError
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'ViewState("ErrorPage") = Request.QueryString.Get("aspxerrorpath")
        Server.ClearError()
    End Sub
    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        ' Response.Redirect(Session("ErrorPageLink").ToString)
        Try
            Mail()
            Response.Redirect("../Default2.aspx", False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
    '    ErrorMessage.Text = Session("ErrorMsg")
    'End Sub
    Sub Mail()
        Try
            'SendMail.MailtoSend("Error on page:" & ViewState("ErrorPage").ToString & Session("UserName").ToString, "Error page link:" & Session("ErrorPageLink") & vbCrLf & "Error Message:" & Session("ErrorMsg"))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

        If Not IsPostBack Then
            UserDetailsDB.InsertError()
            generatemsg()
        End If
    End Sub
    Sub generatemsg()
        Dim vm As String
        Dim parm_msg, parm_phonesp, parm_msgfrm As SqlParameter
        'Session("EmailService") = dt.Rows(0)("EmailService")
        'Session("SMSService")
        'dt = bl.GetCommunication(id)
        Dim dt As DataTable
        'dt = UserDetailsDB.GetErrorLogEmail()
        dt = UserDetailsDB.GetCurrentErrorLog()
        Dim GlobalFunction As New GlobalFunction
        Try
            'If dt.Rows.Count > 0 Then
            'For i As Integer = 0 To dt.Rows.Count
            Dim prefix As String = ""
            Dim ToPhone As String
            Dim Message As String
            Dim Mode As String
            Dim SentDate As DateTime
            ToPhone = dt.Rows(0).Item("ContactNo").ToString
            Message = dt.Rows(0).Item("Message").ToString
            Dim FromEmailID As String = dt.Rows(0).Item("FromEmailId").ToString
            Dim FromPassword As String = dt.Rows(0).Item("EmailPassword").ToString
            Dim SMTPHost As String = dt.Rows(0).Item("SmtpHost").ToString
            'ToPhone = ToPhone.Replace(",,", ",")
            'ToPhone = ToPhone.Replace(",,,", ",")
            'ToPhone = ToPhone.Replace(",,,,", ",")
            'ToPhone = Left(ToPhone, ToPhone.Length - 1)
            prefix = dt.Rows(0).Item("Error").ToString + " " + dt.Rows(0).Item("ErrorDate").ToString + " " + dt.Rows(0).Item("EmpName").ToString + " "
            'If ToPhone.Contains("@") And ToPhone.Contains(".") Then
            '    Message = dt.Rows(i).Item("Message")
            'Else
            '    Message = GlobalFunction.StripHTML(dt.Rows(i).Item("Message")) '.Split(vbCr.ToCharArray())
            'End If
            If ToPhone.Contains("@") And ToPhone.Contains(".") Then
                Mode = "Email"
            Else
                Mode = "SMS"
            End If
            'SentDate = dt.Rows(i).Item("Date")
            SentDate = Format("dd-MMM-yyyy", Today)
            Dim str As String = ""
            Dim connection As New SqlClient.SqlConnection()
            connection.ConnectionString = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
            connection.Open()
            Dim cmd As New SqlCommand()
            vm = "insert into Outbox_tbl (ToPhone,Message,prefix,BranchCode,CommunicationMode,FromEmailID,FromPassword,SMTPHost) values(@ToPhone,@Message,@MsgFrom,@BranchCode,@Mode,@FromEmailID,@FromPassword,@SMTPHost)"

            cmd.Connection = connection
            cmd.CommandText = vm
            parm_phonesp = New SqlParameter
            parm_phonesp.ParameterName = "@ToPhone"
            parm_phonesp.Value = ToPhone
            parm_phonesp.DbType = DbType.String
            cmd.Parameters.Add(parm_phonesp)

            parm_msg = New SqlParameter
            parm_msg.ParameterName = "@Message"
            parm_msg.Value = Message
            parm_msg.DbType = DbType.String
            cmd.Parameters.Add(parm_msg)

            parm_msgfrm = New SqlParameter
            parm_msgfrm.ParameterName = "@MsgFrom"
            parm_msgfrm.Value = prefix
            parm_msgfrm.DbType = DbType.String
            cmd.Parameters.Add(parm_msgfrm)

            parm_msgfrm = New SqlParameter
            parm_msgfrm.ParameterName = "@BranchCode"
            parm_msgfrm.Value = Session("BranchCode")
            parm_msgfrm.DbType = DbType.String
            cmd.Parameters.Add(parm_msgfrm)

            parm_msgfrm = New SqlParameter
            parm_msgfrm.ParameterName = "@Mode"
            parm_msgfrm.Value = Mode
            parm_msgfrm.DbType = DbType.String
            cmd.Parameters.Add(parm_msgfrm)

            parm_msgfrm = New SqlParameter
            parm_msgfrm.ParameterName = "@FromEmailID"
            parm_msgfrm.Value = FromEmailID
            parm_msgfrm.DbType = DbType.String
            cmd.Parameters.Add(parm_msgfrm)

            parm_msgfrm = New SqlParameter
            parm_msgfrm.ParameterName = "@FromPassword"
            parm_msgfrm.Value = FromPassword
            parm_msgfrm.DbType = DbType.String
            cmd.Parameters.Add(parm_msgfrm)

            parm_msgfrm = New SqlParameter
            parm_msgfrm.ParameterName = "@SMTPHost"
            parm_msgfrm.Value = SMTPHost
            parm_msgfrm.DbType = DbType.String
            cmd.Parameters.Add(parm_msgfrm)
            cmd.ExecuteNonQuery()
            'Next
            '  End If

        Catch ex As Exception

        End Try

        'lblGreen1.Text = "Message Sent Successfully."
        'lblRed1.Text = ""
    End Sub
End Class
