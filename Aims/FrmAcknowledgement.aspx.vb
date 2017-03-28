Imports System.Data.SqlClient

Partial Class FrmAcknowledgement
    Inherits BasePage

    Protected Sub LKReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LKReport.Click
        Dim qrystring As String = "Acknowledgement"
        Dim EnqNo As String = Request.QueryString.Get("EnqNo")
        Dim BranchName As String = Request.QueryString.Get("BranchName")
        Dim Name As String = Request.QueryString.Get("Name")
        Dim Phone As String = Request.QueryString.Get("Phone")
        Dim Email As String = Request.QueryString.Get("Email")
        Dim caste As String = Request.QueryString.Get("caste")
        Dim EnqFor As String = Request.QueryString.Get("EnqFor")
        qrystring = "FrmPrintacknowledgementEnquiryV.aspx?" & "&EnqNo=" & EnqNo & "&BranchName=" & BranchName & "&Name=" & Name & "&Phone=" & Phone & "&Email=" & Email & "&caste=" & caste & "&EnqFor=" & EnqFor ' & QueryStr.Querystring()
        'Response.Redirect("FrmAcknowledgement.aspx?QS=" & qrystring & "&heading=" & heading & "&EnqNo=" & EnqNo & "&BranchName=" & BranchName & "&Name=" & Name & "&Phone=" & Phone & "&Email=" & Email & "&caste=" & caste)
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=450,height=400,left=200,top=100')</script>", False)
        'ClientScript.RegisterStartupScript(Me.GetType(), "OpenWin", "<script>openNewWin('" & qrystring & "')</script>")
        'Response.Redirect("FrmPrintacknowledgementEnquiryV.aspx")
    End Sub

    Protected Sub LKMail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LKMail.Click
        'Dim qrystring As String
        'qrystring = "FrmAcknowledgement.aspx?=" & "&EnqNo=" & EnqNo & "&BranchName=" & BranchName & "&Name=" & Name & "&Phone=" & Phone & "&Email=" & Email & "&caste=" & caste
        If Session("EmailService") = "N" Then
            lblmsgg.Text = ""
            lblmsg.Text = "Email service is blocked."
        Else
            Dim EnqNo As String = Request.QueryString.Get("EnqNo")
            Dim BranchName As String = Request.QueryString.Get("BranchName")
            Dim Name As String = Request.QueryString.Get("Name")
            Dim Phone As String = Request.QueryString.Get("Phone")
            Dim Email As String = Request.QueryString.Get("Email")
            Dim caste As String = Request.QueryString.Get("caste")

            Dim vm As String
            Dim parm_msg, parm_phonesp, parm_msgfrm As SqlParameter
            'ID = CType(GVSendMsg.Rows(e.NewEditIndex).FindControl("hidCMID"), HiddenField).Value

            Dim GlobalFunction As New GlobalFunction
            Try
                Dim prefix As String
                Dim ToPhone As String
                Dim Message As String
                Dim SentDate As Date
                ToPhone = Email
                Dim Mode As String = "Email"
                SentDate = Now.Date
                prefix = BranchName + " - Enquiry Acknowledgement"
                If ToPhone <> "" Then
                    Message = "Dear Sir/Madam,<BR><BR>&nbsp;&nbsp;&nbsp;Thank you for your enquiry on " + Format(SentDate, "dd-MMM-yyyy") + " for applicant: " + Name + ". Your Enquiry No is " + EnqNo + ". We appreciate your interest in our Institute.&nbsp;<BR><BR>&nbsp;&nbsp;&nbsp;We are looking forward to hear from you shortly.<BR><BR>Regards,<BR>" + BranchName
                    Dim connection As New SqlClient.SqlConnection()
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
                    connection.Open()
                    Dim cmd As New SqlCommand()
                    vm = "insert into Outbox_tbl (ToPhone,Message,prefix,BranchCode,CommunicationMode) values(@ToPhone,@Message,@MsgFrom,@BranchCode,@Mode)"

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
                    cmd.ExecuteNonQuery()
                    lblmsgg.Text = " Acknowledgement sent successfully. "
                    lblmsg.Text = ""
                Else
                    lblmsgg.Text = ""
                    lblmsg.Text = " Email not entered to send acknowledgement. "
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub LKSMS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LKSMS.Click
        If Session("SMSService") = "N" Then
            lblmsgg.Text = ""
            lblmsg.Text = "SMS service is blocked."
        Else
            Dim EnqNo As String = Request.QueryString.Get("EnqNo")
            Dim BranchName As String = Request.QueryString.Get("BranchName")
            Dim Name As String = Request.QueryString.Get("Name")
            Dim Phone As String = Request.QueryString.Get("Phone")
            Dim Email As String = Request.QueryString.Get("Email")
            Dim caste As String = Request.QueryString.Get("caste")

            Dim vm As String
            Dim parm_msg, parm_phonesp, parm_msgfrm As SqlParameter
            'ID = CType(GVSendMsg.Rows(e.NewEditIndex).FindControl("hidCMID"), HiddenField).Value

            Dim GlobalFunction As New GlobalFunction
            Try
                Dim prefix As String
                Dim ToPhone As String
                Dim Message As String
                Dim SentDate As Date
                Dim Mode As String = "SMS"
                ToPhone = Phone
                SentDate = Now.Date
                prefix = BranchName + " - Enquiry Acknowledgement"
                If ToPhone <> "" Then
                    Message = "Dear Sir/Madam, Thank you for your enquiry on " + Format(SentDate, "dd-MMM-yyyy") + " for applicant: " + Name + ". Your Enquiry No is " + EnqNo + ". We appreciate your interest in our Institute. We are looking forward to hear from you shortly. Regards, " + BranchName
                    Dim connection As New SqlClient.SqlConnection()
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
                    connection.Open()
                    Dim cmd As New SqlCommand()
                    vm = "insert into Outbox_tbl (ToPhone,Message,prefix,BranchCode,CommunicationMode) values(@ToPhone,@Message,@MsgFrom,@BranchCode,@Mode)"

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
                    cmd.ExecuteNonQuery()
                    lblmsgg.Text = " Acknowledgement sent successfully. "
                    lblmsg.Text = ""
                Else
                    lblmsgg.Text = ""
                    lblmsg.Text = " Email not entered to send acknowledgement. "
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Response.Write("<script language='javascript'> { self.close() }</script>")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            LKMail.Focus()
            BtnClose.Attributes.Add("onclick", "self.close();")
        End If
    End Sub
End Class
