Imports Microsoft.Reporting.WebForms
Imports System.IO
Imports System.Net.Mail
Imports System.Net
Imports System.Data.SqlClient


Partial Class frmNewCommunication
    Inherits BasePage
    Dim bl As New BLCommunication
    Dim el As New ELCommunication
    Dim CommunicationMode, ID As String
    'Dim GroupType As Integer
    Dim dt, dt2, demail, dtmessage As New DataTable
    Dim DLMD As New DLReportsR
    Dim obj As New SelfDetailsB
    Dim N As Integer = 30
    Dim flag As Integer = 0
    Protected Sub btnPublish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPublish.Click
        Try
            If Trim(txtmessage.Text).Length = 0 Then
                lblcorrect.Text = ""
                lblError.Text = "Enter Message."
            Else
                lblcorrect.Text = ""
                lblError.Text = ""
                Dim vm As String
                Dim parm_msg, parm_phonesp, parm_msgfrm, parm_branch, parm_host, parm_mode, parm_frmemail, parm_frmpass As SqlParameter
                Dim Email As String
                Dim Message As String
                Dim SentDate As Date
                Dim str As String = ""
                Dim connection As New SqlClient.SqlConnection()
                Dim cmd As New SqlCommand()
                If (rblist1.SelectedIndex.Equals(0)) Then
                    bulk()
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
                    connection.Open()
                    If (GVMsg.Rows.Count > 0) Then
                        vm = "insert into Outbox_tbl (ToPhone,Message,prefix,BranchCode,CommunicationMode,FromEmailID,FromPassword,SMTPHost) values(@ToPhone,@Message,@MsgFrom,@BranchCode,@Mode,@FromEmailID,@FromPassword,@SMTPHost)"
                        cmd.Connection = connection
                        cmd.CommandText = vm

                        parm_phonesp = New SqlParameter
                        parm_phonesp.ParameterName = "@ToPhone"
                        parm_phonesp.DbType = DbType.String
                        cmd.Parameters.Add(parm_phonesp)

                        parm_msg = New SqlParameter
                        parm_msg.ParameterName = "@Message"
                        parm_msg.DbType = DbType.String
                        cmd.Parameters.Add(parm_msg)

                        parm_msgfrm = New SqlParameter
                        parm_msgfrm.ParameterName = "@MsgFrom"
                        parm_msgfrm.DbType = DbType.String
                        cmd.Parameters.Add(parm_msgfrm)

                        parm_branch = New SqlParameter
                        parm_branch.ParameterName = "@BranchCode"
                        parm_branch.DbType = DbType.String
                        cmd.Parameters.Add(parm_branch)

                        parm_mode = New SqlParameter
                        parm_mode.ParameterName = "@Mode"
                        parm_mode.DbType = DbType.String
                        cmd.Parameters.Add(parm_mode)

                        parm_frmemail = New SqlParameter
                        parm_frmemail.ParameterName = "@FromEmailID"
                        parm_frmemail.DbType = DbType.String
                        cmd.Parameters.Add(parm_frmemail)

                        parm_frmpass = New SqlParameter
                        parm_frmpass.ParameterName = "@FromPassword"
                        parm_frmpass.DbType = DbType.String
                        cmd.Parameters.Add(parm_frmpass)

                        parm_host = New SqlParameter
                        parm_host.ParameterName = "@SMTPHost"
                        parm_host.DbType = DbType.String
                        cmd.Parameters.Add(parm_host)

                        For Each grid As GridViewRow In GVMsg.Rows
                            Try
                                Email = CType(grid.FindControl("lblto"), Label).Text

                                Message = txtmessage.Text
                                SentDate = Date.Today
                                parm_phonesp.Value = Email
                                parm_msg.Value = Message
                                parm_msgfrm.Value = "Advant"
                                parm_branch.Value = Session("BranchCode")
                                parm_mode.Value = "Email"
                                parm_frmemail.Value = Session("FromEmailID")
                                parm_frmpass.Value = Session("FromPassword")
                                parm_host.Value = Session("SMTPHost")
                                cmd.ExecuteNonQuery()

                            Catch ex As Exception
                            End Try
                        Next
                        lblcorrect.Text = "Email(s) Scheduled for Sending."
                        lblError.Text = ""
                    End If
                End If
                If (rblist1.SelectedIndex.Equals(1)) Then
                    If (ddlreport.SelectedItem.Value.Equals("0") = False) Then
                        dt = ViewState("data")
                        If (dt.Rows.Count > 0) Then
                            For Each grid As GridViewRow In GVName.Rows
                                If CType(grid.FindControl("ChkIndividual"), CheckBox).Checked = True Then
                                    Dim GlobalFunction As New GlobalFunction
                                    Try
                                        Email = CType(grid.FindControl("lblEmail"), Label).Text
                                        If Email.Length > 0 Then
                                            Message = "Please go through the Attached PDF file with this mail from advantims.com"
                                            SentDate = Date.Today
                                            EmailSMS(Email)
                                        End If
                                    Catch ex As Exception
                                    End Try
                                End If
                            Next
                        End If
                    Else
                        lblError.Text = "Select Report to be send."
                        lblcorrect.Text = ""
                    End If
                End If
                If rblist1.SelectedItem Is Nothing Then
                    lblError.Text = "Select Either Bulk/Report Message Radio Button."
                    lblcorrect.Text = ""
                End If
            End If
        Catch ex As Exception
            lblError.Text = "Enter correct date."
            lblcorrect.Text = ""
        End Try

    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt2)
        e.DataSources.Add(rptDataSource)
    End Sub

    Sub EmailSMS(ByVal Emailid As String)
        Try
            dt2 = ViewState("data")
            demail = DLSendMsg.GetEmail()
        Catch ex As Exception
        End Try
        Dim myReport As New LocalReport()
        Dim DL As New DLBuyerDetails
        Dim dt1 As New DataTable
        Dim ds As New DataSet()
        Dim dt, dr2 As New Microsoft.Reporting.WebForms.ReportDataSource
        Try
            ''Mail 
            If (ddlreport.SelectedValue = 1) Then
                dt1 = DLMD.Rpt_ManagementDashboard(txtBranchName.SelectedItem.Value, Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy"), (System.DateTime.Now).ToString("dd-MMM-yyyy"))
                myReport.ReportPath = "Rpt_ManagementDashboard.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_Rpt_ManagementDashBoard", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy"), False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", (System.DateTime.Now).ToString("dd-MMM-yyyy"), False))
                myReport.SetParameters(paramList)
                myReport.DataSources.Clear()
                myReport.DataSources.Add(dt)
                dt2 = obj.RPT_GetSelfDeatilsByBranch(0)
                AddHandler myReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            End If
            If (ddlreport.SelectedValue = 2) Then
                dt1 = DLMD.Rpt_ManagementDashboard(txtBranchName.SelectedItem.Value, Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy"), (System.DateTime.Now).ToString("dd-MMM-yyyy"))
                myReport.ReportPath = "Rpt_ManagementDashboardGraph.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_Rpt_ManagementDashBoard", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy"), False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", (System.DateTime.Now).ToString("dd-MMM-yyyy"), False))
                myReport.SetParameters(paramList)
                myReport.DataSources.Clear()
                myReport.DataSources.Add(dt)
                dt2 = obj.RPT_GetSelfDeatilsByBranch(0)
                AddHandler myReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            End If
            Dim deviceInfo As String = "<deviceinfo>" + "  <outputformat>PDF</outputformat>" + "  <pagewidth>8.5in</pagewidth>" + "  <pageheight>11in</pageheight>" + "  <margintop>0.5in</margintop>" + "  <marginleft>0.75in</marginleft>" + "  <marginright>0.5in</marginright>" + "  <marginbottom>0.5in</marginbottom>" + "</deviceinfo>"
            Dim warnings As Warning()
            Dim streamIds As String()
            Dim mimeType As String = String.Empty
            Dim encoding As String = String.Empty
            Dim extension As String = String.Empty
            Dim Sample As String = "Sample"
            Dim bytes As Byte() = myReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)
            Dim s As MemoryStream = New MemoryStream(bytes)
            s.Seek(0, SeekOrigin.Begin)
            Dim SendFrom As MailAddress = New MailAddress(demail.Rows(0).Item(0).ToString)
            Dim SendTo As MailAddress = New MailAddress(Emailid)

            Dim MyMessage As MailMessage = New MailMessage(SendFrom, SendTo)

            MyMessage.Subject = ddlreport.SelectedItem.ToString
            MyMessage.Body = txtmessage.Text
            Dim attachFile As New Attachment(s, ddlreport.SelectedItem.ToString + ".pdf")
            MyMessage.Attachments.Add(attachFile)

            Dim SmtpServer As New SmtpClient(demail.Rows(0).Item(2).ToString)

            SmtpServer.Port = demail.Rows(0).Item(3).ToString
            SmtpServer.Credentials = New System.Net.NetworkCredential(demail.Rows(0).Item(0).ToString, demail.Rows(0).Item(1).ToString)
            SmtpServer.EnableSsl = True
            Try
                SmtpServer.Send(MyMessage)
                lblcorrect.Text = "Email Send Sucessfully."
                lblError.Text = ""
            Catch ex As Exception
                lblError.Text = ex.ToString
            End Try
        Catch ex As Exception
            lblError.Text = ex.ToString
        End Try
    End Sub
    Sub CheckAll()
        If CType(GVName.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVName.Rows
                CType(grid.FindControl("ChkIndividual"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GVName.Rows
                CType(grid.FindControl("ChkIndividual"), CheckBox).Checked = False
            Next
        End If
    End Sub
    Sub clear()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If IsPostBack = False Then
            ViewState("data") = ""
            rblist1.Items.Add("Bulk Text Message")
            rblist1.Items.Add("Report Message")
            GVPanel.Visible = False
            MsgPanel.Visible = True
        End If
    End Sub

    Protected Sub ddlGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGroup.SelectedIndexChanged
        Try
            If (ddlGroup.SelectedValue <> 0) Then
                lblError.Text = ""
                lblcorrect.Text = ""
                display()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GVName_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVName.PageIndexChanging
        GVName.PageIndex = e.NewPageIndex
        GVName.DataBind()
        display()
    End Sub
    Sub display()
        dt = DLCommunicationModule.GetBranchwiseNameCombo(ddlGroup.SelectedValue, txtBranchName.SelectedValue)
        GVName.DataSource = dt
        GVName.DataBind()
        dt.Dispose()
        GVName.Visible = True
        ViewState("data") = dt
        If (dt.Rows.Count = 0) Then
            GVPanel.Visible = False
        Else
            GVPanel.Visible = True
        End If
        MsgPanel.Visible = True
        GVMsg.Visible = True
    End Sub

    Protected Sub ddlGroup_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGroup.TextChanged
        ddlGroup.Focus()
    End Sub
    Protected Sub txtBranchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBranchName.SelectedIndexChanged
        Try
            If (ddlGroup.SelectedValue <> 0) Then
                lblError.Text = ""
                lblcorrect.Text = ""
                display()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub bulk()
        If (rblist1.SelectedValue = "") Then
            lblError.Text = "Please select the Bulk/Report Message radio button."
            lblcorrect.Text = ""
            Exit Sub
        End If
        Dim k As Integer
        Dim count As Integer = 0
        Dim GroupEmail As String = ""
        Dim Toarray(Math.Ceiling(CDbl((dt.Rows.Count - 1)) / N)) As String
        For Each grid As GridViewRow In GVName.Rows
            If CType(grid.FindControl("ChkIndividual"), CheckBox).Checked = True Then
                count = count + 1
                flag = 1
            End If
        Next
        If (rblist1.SelectedIndex.Equals(0)) Then
            k = Math.Floor(CDbl(count) / N)
            Dim Togroup(k) As String
            k = 0
            count = 0
            For Each grid As GridViewRow In GVName.Rows
                If CType(grid.FindControl("ChkIndividual"), CheckBox).Checked = True Then
                    If Trim(CType(grid.FindControl("lblEmail"), Label).Text).Length > 0 Then
                        If GroupEmail = "" Then
                            GroupEmail = Trim(CType(grid.FindControl("lblEmail"), Label).Text)
                        Else
                            GroupEmail = GroupEmail + ", " + Trim(CType(grid.FindControl("lblEmail"), Label).Text)
                        End If
                        count = count + 1
                    End If
                End If
                If (count = N) Then
                    Togroup(k) = GroupEmail
                    GroupEmail = ""
                    k = k + 1
                    count = 0
                End If
            Next
            dtmessage.Columns.Add(New DataColumn("To"))
            dtmessage.Columns.Add(New DataColumn("Message"))
            Togroup(k) = GroupEmail
            For Each ToGrp As String In Togroup
                If (ToGrp <> "") Then
                    Dim RowValues As Object() = {ToGrp, txtmessage.Text}
                    Dim dRow As DataRow
                    dRow = dtmessage.Rows.Add(RowValues)
                    dtmessage.AcceptChanges()
                End If
            Next
        End If
        If (rblist1.SelectedIndex.Equals(1)) Then
            Dim Togroup(count) As String
            k = 0
            count = 0
            For Each grid As GridViewRow In GVName.Rows
                If CType(grid.FindControl("ChkIndividual"), CheckBox).Checked = True Then
                    If Trim(CType(grid.FindControl("lblEmail"), Label).Text).Length > 0 Then
                        Togroup(count) = (CType(grid.FindControl("lblEmail"), Label).Text)
                        count = count + 1
                    End If
                End If
            Next
            dtmessage.Columns.Add(New DataColumn("To"))
            dtmessage.Columns.Add(New DataColumn("Message"))
            For Each ToGrp As String In Togroup
                If (ToGrp <> "") Then
                    Dim RowValues As Object() = {ToGrp, txtmessage.Text}
                    Dim dRow As DataRow
                    dRow = dtmessage.Rows.Add(RowValues)
                    dtmessage.AcceptChanges()
                End If
            Next
        End If
        GVMsg.DataSource = dtmessage
        GVMsg.DataBind()
        If (flag = 0) Then
            lblError.Text = "Please select record."
            lblcorrect.Text = ""
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        lblcorrect.Text = ""
        lblError.Text = ""
        bulk()
        GVMsg.Visible = True
        MsgPanel.Visible = True
    End Sub
End Class
