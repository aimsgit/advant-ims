Imports System.Data.SqlClient
Imports Microsoft.Reporting.WebForms
Imports System.IO
Imports System.Net.Mail
Imports System.Net
Partial Class FrmRemainder
    Inherits BasePage
    Dim dt, dt3 As DataTable
    Dim DL As New DLRemainder
    Dim obj As New SelfDetailsB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub

    Protected Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        lblGreen1.Text = ""
        lblRed1.Text = ""
        dt = DLRemainder.GVDetails()
        If dt.Rows.Count > 0 Then
            GVName.DataSource = dt
            GVName.DataBind()
            lblGreen1.Text = ""
            lblRed1.Text = ""
            dt.Dispose()
            GVName.Visible = True
        Else
            lblRed1.Text = "No Records Display."
            GVName.Visible = False
        End If

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

    Protected Sub BtnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSend.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                lblGreen1.Text = ""
                lblRed1.Text = ""
                Dim dt1 As DataTable
                Dim tablecount As Integer
                Dim password As String = ""
                Dim decryptpassword As String = ""
                Dim Mode As String = ""
                Dim id As String = ""
                Dim id2 As String = ""
                Dim check As String = ""
                Dim ab As Integer
                Dim Emp_Code As String = ""
                Dim GroupName As String = ""
                Dim ContactNo As String = ""
                Dim EmailID As String = ""
                Dim ChkID As String
                Dim count As New Integer
                Dim InvoiceNo As String = ""
                Dim InvoiceDate As Date
                Dim Amount As String = ""
                Dim dt As New DataTable
                count = 0
                If CheckSMS.Checked = False And CheckEmail.Checked = False Then
                    lblRed1.Text = "Please Select SMS or Email."
                    lblGreen1.Text = ""
                    Exit Sub
                End If

                For Each grid As GridViewRow In GVName.Rows
                    If CType(grid.FindControl("ChkIndividual"), CheckBox).Checked = True Then
                        If CheckSMS.Checked And CheckEmail.Checked Then
                            id2 = CType(grid.FindControl("lblCellPhone"), Label).Text
                            InvoiceNo = CType(grid.FindControl("lblInvoiceNo"), Label).Text
                            InvoiceDate = CType(grid.FindControl("lblInvoiceDate"), Label).Text
                            Amount = CType(grid.FindControl("lblAmount"), Label).Text
                            If id2 <> "" Then
                                Mode = "SMS"
                                DLRemainder.InsertReminder(id2, Mode, InvoiceNo, InvoiceDate, Amount)
                            End If
                            id2 = CType(grid.FindControl("lblEmailId"), Label).Text
                            InvoiceNo = CType(grid.FindControl("lblInvoiceNo"), Label).Text
                            InvoiceDate = CType(grid.FindControl("lblInvoiceDate"), Label).Text
                            Amount = CType(grid.FindControl("lblAmount"), Label).Text
                            If id2 <> "" Then
                                Mode = "Email"
                                DLRemainder.InsertReminder(id2, Mode, InvoiceNo, InvoiceDate, Amount)
                            End If
                        ElseIf CheckSMS.Checked Then
                            id2 = CType(grid.FindControl("lblCellPhone"), Label).Text
                            InvoiceNo = CType(grid.FindControl("lblInvoiceNo"), Label).Text
                            InvoiceDate = CType(grid.FindControl("lblInvoiceDate"), Label).Text
                            Amount = CType(grid.FindControl("lblAmount"), Label).Text
                            If id2 <> "" Then
                                Mode = "SMS"
                                DLRemainder.InsertReminder(id2, Mode, InvoiceNo, InvoiceDate, Amount)
                            End If
                        ElseIf CheckEmail.Checked Then
                            id2 = CType(grid.FindControl("lblEmailId"), Label).Text
                            InvoiceNo = CType(grid.FindControl("lblInvoiceNo"), Label).Text
                            InvoiceDate = CType(grid.FindControl("lblInvoiceDate"), Label).Text
                            Amount = CType(grid.FindControl("lblAmount"), Label).Text
                            If id2 <> "" Then
                                Mode = "Email"
                                DLRemainder.InsertReminder(id2, Mode, InvoiceNo, InvoiceDate, Amount)
                            End If
                        End If
                    End If
                    lblGreen1.Text = "Reminder(s) Sent Successfully."
                Next
            Catch ex As ArgumentException
            End Try
        Else
            lblRed1.Text = "You do not belong to this branch, Cannot Send Message."
            lblGreen1.Text = ""
        End If
    End Sub

    'Sub EmailSMS()

    '    For Each grid As GridViewRow In GVName.Rows
    '        Dim BranchId, Branchname As String
    '        Dim InvoiceNo As String
    '        BranchId = CType(grid.FindControl("lblBranch_Code"), HiddenField).Value
    '        InvoiceNo = CType(grid.FindControl("txtInvNo"), TextBox).Text
    '        Dim demail, dtmessage, dt2 As New DataTable
    '        Dim SMSData As String
    '        Dim ToEmail As String
    '        Dim ToPhone As String
    '        Dim EmailBody As String
    '        Try
    '            dt2 = ViewState("data")
    '            demail = DLSendMsg.GetEmail()
    '        Catch ex As Exception

    '        End Try
    '        dt2 = DLClientContractMaster.EmailInvoice(BranchId)
    '        SMSData = dt2.Rows(0).Item(0).ToString()
    '        ToPhone = dt2.Rows(0).Item(1).ToString()
    '        ToEmail = dt2.Rows(0).Item(2).ToString()
    '        Branchname = dt2.Rows(0).Item(3).ToString()
    '        Dim myReport As New LocalReport()
    '        Dim DL As New DLRemainder
    '        Dim dt1 As New DataTable
    '        Dim ds As New DataSet()
    '        Dim dt, dr2 As New Microsoft.Reporting.WebForms.ReportDataSource
    '        Try
    '            ''Mail 
    '            dt1 = DL.GetInvoiceData1(BranchId, InvoiceNo)
    '            myReport.ReportPath = "RptinvoiceView3.rdlc"
    '            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_GetinvoiceData", dt1)
    '            myReport.DataSources.Clear()
    '            myReport.DataSources.Add(dt)
    '            dt2 = obj.RPT_GetSelfDeatilsByBranch(0)
    '            AddHandler myReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    '            Dim deviceInfo As String = "<deviceinfo>" + "  <outputformat>PDF</outputformat>" + "  <pagewidth>8.5in</pagewidth>" + "  <pageheight>11in</pageheight>" + "  <margintop>0.5in</margintop>" + "  <marginleft>0.75in</marginleft>" + "  <marginright>0.5in</marginright>" + "  <marginbottom>0.5in</marginbottom>" + "</deviceinfo>"
    '            Dim warnings As Warning()
    '            Dim streamIds As String()
    '            Dim mimeType As String = String.Empty
    '            Dim encoding As String = String.Empty
    '            Dim extension As String = String.Empty
    '            Dim Sample As String = "Sample"
    '            Dim bytes As Byte() = myReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)
    '            Dim s As MemoryStream = New MemoryStream(bytes)
    '            s.Seek(0, SeekOrigin.Begin)
    '            Dim SendFrom As MailAddress = New MailAddress(demail.Rows(0).Item(0).ToString)
    '            Dim SendTo As MailAddress = New MailAddress(ToEmail)

    '            Dim MyMessage As MailMessage = New MailMessage(SendFrom, SendTo)

    '            MyMessage.Subject = "Tax Invoice On " + CDate(InvoiceNo).ToLongDateString.ToString
    '            MyMessage.Body = "Dear Sir/madam ," + Environment.NewLine + Environment.NewLine + EmailBody
    '            Dim attachFile As New Attachment(s, "TaxInvoice.pdf")
    '            MyMessage.Attachments.Add(attachFile)

    '            Dim SmtpServer As New SmtpClient(demail.Rows(0).Item(2).ToString)

    '            SmtpServer.Port = demail.Rows(0).Item(3).ToString
    '            SmtpServer.Credentials = New System.Net.NetworkCredential(demail.Rows(0).Item(0).ToString, demail.Rows(0).Item(1).ToString)
    '            SmtpServer.EnableSsl = True
    '            Try
    '                SmtpServer.Send(MyMessage)
    '                lblGreen1.Text = "Email Send successfully."
    '                lblRed1.Text = ""
    '            Catch ex As Exception
    '                lblRed1.Text = ex.ToString
    '            End Try
    '        Catch ex As Exception
    '            lblRed1.Text = ex.ToString
    '        End Try
    '    Next
    '    lblGreen1.Text = "Email Send Sucessfully."
    '    lblRed1.Text = ""
    '    GVName.Visible = False
    'End Sub
    'Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
    '    Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt3)
    '    e.DataSources.Add(rptDataSource)

    'End Sub
End Class
