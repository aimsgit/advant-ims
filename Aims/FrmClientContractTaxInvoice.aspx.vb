Imports Microsoft.Reporting.WebForms
Imports System.IO
Imports System.Net.Mail
Imports System.Net
Partial Class FrmClientContractTaxInvoice
    Inherits BasePage
    Dim obj As New SelfDetailsB
    Dim dt2, dt, dt3, dt1, dt4 As New DataTable
    Dim FromEmail As String
    Dim FromPassword As String
    Dim SMSStr1 As String
    Dim SMSStr2 As String
    Dim SMSStr3 As String
    Dim EmailHost As String
    Dim EmailPort As String
    Dim EmailBody As String
    Dim SMSData As String
    Dim ToEmail As String
    Dim ToPhone As String
    Dim TimeforSMS As Integer
    Dim GrowerName As String
    Dim SuccessMsg As String = ""
    Dim Branchname As String
    Dim DLClientContractMaster As New DLClientContractMaster
    Dim ClientId As String
    Dim BranchCode As String
    Dim demail, dtmessage As New DataTable
    Dim Fromdate As String
    Dim ToDate As String
    Dim Yearfrom As String
    Dim YearTo As String
    Dim InvoiceNo As String
    Dim Invdate As Date

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            'txtFromDate.Text = Format(Today, "dd-MMM-yyyy")
            'txtToDate.Text = Format(Today, "dd-MMM-yyyy")
            txtInvdate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub

    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim openclosestatus As Integer = Request.QueryString.Get(("openclosestatus"))
        Dim ID As String = Request.QueryString.Get(("ID"))
        Dim SetUp As String = Request.QueryString.Get(("SetUp"))
        Dim setupcharge As Double = Request.QueryString.Get(("setupcharge"))
       If txtInvdate.Text = "" Then
            Invdate = Format(Today(), "dd-MMM-yyyy")
        Else
            Invdate = txtInvdate.Text
        End If
        ClientId = DdlSelectClient.SelectedValue
        BranchCode = DdlSelectBranch.SelectedValue
        Fromdate = cmbFrom.SelectedValue
        ToDate = CmbTo.SelectedValue
        InvoiceNo = txtInvoiceNo.Text
        Yearfrom = ddlYear.SelectedItem.ToString
        YearTo = ddlYearTo.SelectedItem.ToString
        'If txtInvoiceNo.Text = "" Then
        '    lblmsg.Text = " Enter Invoice Number."
        '    lblmsgG.Text = ""
        'Else
        For Each grid As GridViewRow In GVTaxInvoice.Rows
            Dim InvoiceNo1 As String = CType(grid.FindControl("txtInvNo"), TextBox).Text
            dt2 = DLClientContractMaster.ChkDuplicateData(BranchCode, Fromdate, ToDate, Yearfrom, YearTo, InvoiceNo1)
            If dt2.Rows.Count > 0 Then
                lblmsg.Text = "Data is already generated."
                lblmsgG.Text = ""
                Exit Sub
            End If
        Next
        If Yearfrom > YearTo Then
            lblmsg.Text = "From Year cannot be Greater than To Year."
            lblmsgG.Text = ""
            Exit Sub
        Else
            If Yearfrom = YearTo Then
                If Fromdate > ToDate Then
                    lblmsg.Text = "From Month cannot be Greater than To Month."
                    lblmsgG.Text = ""
                    Exit Sub
                End If
            End If
            lblmsg.Text = ""
            lblmsgG.Text = ""
            dt1 = DLClientContractMaster.GetSaleInvoice(BranchCode, setupcharge, ID, Fromdate, ToDate, Yearfrom, YearTo, InvoiceNo, SetUp, Invdate, ClientId)
            If dt1.Rows.Count = 0 Then
                lblmsg.Text = "Record(s) should be pre audit in Monthly Run."
                lblmsgG.Text = ""
                GVTaxInvoice.Visible = False
                Exit Sub
            End If
            dt = DLClientContractMaster.Clientcontractmonthlyrun(BranchCode, Fromdate, ToDate, Yearfrom, YearTo, ClientId)
            If dt.Rows.Count <> 0 Then
                GVTaxInvoice.DataSource = dt
                GVTaxInvoice.DataBind()
                GVTaxInvoice.Visible = True
                lblmsg.Text = ""
                lblmsgG.Text = ""
            Else
                lblmsg.Text = "No records to display."
                lblmsgG.Text = ""
                GVTaxInvoice.Visible = False
            End If

        End If




    End Sub
   
    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        For Each grid As GridViewRow In GVTaxInvoice.Rows
            ClientId = DdlSelectClient.SelectedValue
            BranchCode = CType(grid.FindControl("lblBranch_Code"), HiddenField).Value
            Fromdate = cmbFrom.SelectedValue
            ToDate = CmbTo.SelectedValue
            Yearfrom = ddlYear.SelectedItem.Text
            YearTo = ddlYearTo.SelectedItem.Text
            Dim InvoiceNo As String
            InvoiceNo = txtInvoiceNo.Text
            'Dim BranchCode As String = Request.QueryString.Get(("BranchCode"))
            'If txtInvoiceNo.Text = "" Then
            '    lblmsg.Text = " Enter Invoice Number."
            '    lblmsgG.Text = ""
            'Else
            If DLClientContractMaster.ClearInvoiceData(InvoiceNo, ClientId, BranchCode, Fromdate, ToDate, Yearfrom, YearTo) = 0 Then
                lblmsg.Text = "Data connot be cleared."
                lblmsgG.Text = ""
            Else
                lblmsgG.Text = "Data is cleared."
                lblmsg.Text = ""
                GVTaxInvoice.Visible = False
            End If
            'End If
        Next
    End Sub

    Protected Sub btnPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If Session("Privilages").ToString.Contains("W") Then

            If (Session("BranchCode") = Session("ParentBranch")) Then
                Dim id As String = ""
                Dim check As String = ""

                Dim count As New Integer
                count = 0
                For Each grid As GridViewRow In GVTaxInvoice.Rows
                    If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                        check = CType(grid.FindControl("lblPKID"), Label).Text
                        id = check + "," + id
                        count = count + 1
                    End If
                Next
                If id = "" Then
                    id = "0"
                    count = 0
                Else
                    id = Left(id, id.Length - 1)
                End If
               If count = 0 Then
                    lblmsg.Text = "Select Atleast One Record to Post."
                    lblmsgG.Text = ""
                Else
                    DLClientContractMaster.PostTaxInvoice(id)
                    Display1()

                    lblmsgG.Text = "Record(s) posted successfully."
                    lblmsg.Text = ""
                End If
                'Else
                '    lblErrorMsg.Text = "Not Authorized to Post."
                '    Lblmsg.Text = ""
                'End If
            Else
                lblmsg.Text = "You do not belong to this branch, Cannot post data."
                lblmsgG.Text = ""
            End If
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Sub Display1()
        ClientID = DdlSelectClient.SelectedValue
        BranchCode = DdlSelectBranch.SelectedValue
        Fromdate = cmbFrom.SelectedValue
        ToDate = CmbTo.SelectedValue
        InvoiceNo = txtInvoiceNo.Text
        Yearfrom = ddlYear.SelectedItem.ToString
        YearTo = ddlYearTo.SelectedItem.ToString
        dt = DLClientContractMaster.Clientcontractmonthlyrun(BranchCode, Fromdate, ToDate, Yearfrom, YearTo, ClientID)
        If dt.Rows.Count <> 0 Then
            GVTaxInvoice.DataSource = dt
            GVTaxInvoice.DataBind()
            GVTaxInvoice.Visible = True
            lblmsg.Text = ""
            lblmsgG.Text = ""
        Else
            lblmsg.Text = "No records to display."
            lblmsgG.Text = ""
            GVTaxInvoice.Visible = False
        End If
    End Sub


    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        If Session("Privilages").ToString.Contains("W") Then
            If (Session("BranchCode") = Session("ParentBranch")) Then
                Dim id As String = ""
                Dim check As String = ""
                Dim count As New Integer
                count = 0
                For Each grid As GridViewRow In GVTaxInvoice.Rows
                    If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                        check = CType(grid.FindControl("lblPKID"), Label).Text
                        id = check + "," + id
                        count = count + 1
                    End If
                Next
                If id = "" Then
                    id = "0"
                    count = 0
                Else
                    id = Left(id, id.Length - 1)
                End If
                If count = 0 Then
                    lblmsg.Text = "Select Atleast One Record to Cancel the Invoice."
                    lblmsgG.Text = ""
                Else
                    DLClientContractMaster.CancelTaxInvoice(id)
                    'If roweffected = 0 Then
                    '    lblmsg.Text = "Record(s) already Posted,cannot cancel the Invoice."
                    '    lblmsgG.Text = ""
                    '    Exit Sub
                    'End If
                    Display1()
                    lblmsg.Text = "Record(s) Canceled successfully."
                    lblmsgG.Text = ""
                End If
            Else
                lblmsg.Text = "You do not belong to this branch, Cannot post data."
                lblmsgG.Text = ""
            End If
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Protected Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click
        EmailSMS()
    End Sub
    Sub EmailSMS()
        Display1()
        For Each grid As GridViewRow In GVTaxInvoice.Rows
            Dim BranchId As String
            Dim InvoiceNo As String
            Dim Month As Integer
            Dim Year As String
            BranchId = CType(grid.FindControl("lblBranch_Code"), HiddenField).Value
            InvoiceNo = CType(grid.FindControl("txtInvNo"), TextBox).Text
            Year = CType(grid.FindControl("lblYear"), Label).Text
            Month = CType(grid.FindControl("lblMonthNo"), Label).Text
            Try
                dt2 = ViewState("data")
                demail = DLSendMsg.GetEmail()
            Catch ex As Exception

            End Try
            dt2 = DLClientContractMaster.EmailInvoice(BranchId)
            SMSData = dt2.Rows(0).Item(0).ToString()
            ToPhone = dt2.Rows(0).Item(1).ToString()
            ToEmail = dt2.Rows(0).Item(2).ToString()
            Branchname = dt2.Rows(0).Item(3).ToString()
            dt2 = DLClientContractMaster.GetConfigEmail()
            If dt2.Rows.Count > 0 Then
                EmailBody = dt2.Rows(0).Item("Config_Value").ToString()
            End If
            Dim X As Integer = dt2.Rows.Count() - 1
            Dim str As String = " "
            Dim myReport As New LocalReport()
            Dim DL As New DLClientContractMaster
            Dim dt1 As New DataTable
            Dim ds As New DataSet()
            Dim dt, dr2 As New Microsoft.Reporting.WebForms.ReportDataSource
            'Try
            '    Dim sURL As String
            '    Dim objReader As StreamReader
            '    sURL = SMSStr1 + ToPhone + SMSStr2 + SMSData + SMSStr3
            '    Dim sResponse As HttpWebRequest
            '    sResponse = HttpWebRequest.Create(sURL)
            '    Dim objStream As Stream
            '    objStream = sResponse.GetResponse.GetResponseStream()
            '    objReader = New StreamReader(objStream)
            '    objReader.Close()
            '    objStream.Close()
            '    objReader.Dispose()
            '    objStream.Dispose()
            '    'msginfo.Text = "SMS Send Sucessfully"
            'Catch ex As Exception
            '    lblmsg.Text = ex.ToString
            'End Try

            Try
                ''Mail 
                dt1 = DL.GetInvoiceData1(BranchId, txtInvoiceNo.Text, DdlSelectClient.SelectedValue, Month, Year)
                myReport.ReportPath = "RptinvoiceView3.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_GetinvoiceData", dt1)
                myReport.DataSources.Clear()
                myReport.DataSources.Add(dt)
                dt2 = obj.RPT_GetSelfDeatilsByBranch(0)
                AddHandler myReport.SubreportProcessing, AddressOf SubreportProcessingEvent
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
                Dim SendTo As MailAddress = New MailAddress(ToEmail)

                Dim MyMessage As MailMessage = New MailMessage(SendFrom, SendTo)

                MyMessage.Subject = "Tax Invoice On " + CDate(txtInvdate.Text).ToLongDateString.ToString
                MyMessage.Body = "Dear Sir/madam ," + Environment.NewLine + Environment.NewLine + EmailBody
                Dim attachFile As New Attachment(s, "TaxInvoice.pdf")
                MyMessage.Attachments.Add(attachFile)

                Dim SmtpServer As New SmtpClient(demail.Rows(0).Item(2).ToString)

                SmtpServer.Port = demail.Rows(0).Item(3).ToString
                SmtpServer.Credentials = New System.Net.NetworkCredential(demail.Rows(0).Item(0).ToString, demail.Rows(0).Item(1).ToString)
                SmtpServer.EnableSsl = True
                Try
                    SmtpServer.Send(MyMessage)
                    lblmsgG.Text = "Email Sent successfully."
                    lblmsg.Text = ""
                Catch ex As Exception
                    lblmsg.Text = ex.ToString
                End Try
            Catch ex As Exception
                lblmsg.Text = ex.ToString
            End Try
        Next
        lblmsgG.Text = "Email Sent Successfully."
        lblmsg.Text = ""
    End Sub

    'Dim DL As New DLClientContractMaster
    'Try
    'dt2 = DLClientContractMaster.EmailInvoice(DdlSelectBranch.SelectedValue, txtInvdate.Text)
    '    SMSData = dt2.Rows(0).Item(0).ToString()
    '    ToPhone = dt2.Rows(0).Item(1).ToString()
    '    ToEmail = dt2.Rows(0).Item(2).ToString()
    '    Branchname = dt2.Rows(0).Item(3).ToString()
    '    FromEmail = "advant@advant-tech.com"
    'Catch ex As Exception
    'End Try

    'Dim myReport As New LocalReport()
    'Dim dt1 As New DataTable
    'Dim ds As New DataSet()
    'Dim dt, dr2 As New Microsoft.Reporting.WebForms.ReportDataSource
    ' ''Mail 
    'Try
    '    dt1 = DL.GetInvoiceData(DdlSelectBranch.SelectedValue, txtInvoiceNo.Text, DdlSelectClient.SelectedValue)
    '    myReport.ReportPath = "RptinvoiceView.rdlc"
    '    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_GetinvoiceData", dt1)
    '    myReport.DataSources.Clear()
    '    myReport.DataSources.Add(dt)
    '    'ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
    '    'dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
    '    AddHandler myReport.SubreportProcessing, AddressOf SubreportProcessingEvent

    '    Dim deviceInfo As String = "<deviceinfo>" + "  <outputformat>PDF</outputformat>" + "  <pagewidth>8.5in</pagewidth>" + "  <pageheight>11in</pageheight>" + "  <margintop>0.5in</margintop>" + "  <marginleft>0.75in</marginleft>" + "  <marginright>0.5in</marginright>" + "  <marginbottom>0.5in</marginbottom>" + "</deviceinfo>"
    '    Dim warnings As Warning()
    '    Dim streamIds As String()
    '    Dim mimeType As String = String.Empty
    '    Dim encoding As String = String.Empty
    '    Dim extension As String = String.Empty
    '    Dim Sample As String = "Sample"
    '    Dim bytes As Byte() = myReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)
    '    Dim s As MemoryStream = New MemoryStream(bytes)
    '    s.Seek(0, SeekOrigin.Begin)


    '    Dim SendFrom As MailAddress = New MailAddress("advant@advant-tech.com")
    '    Dim SendTo As MailAddress = New MailAddress("advant@advant-tech.com")

    '    Dim MyMessage As MailMessage = New MailMessage(SendFrom, SendTo)

    '    MyMessage.Subject = "Tax Invoice On " + CDate(txtInvdate.Text).ToLongDateString.ToString
    '    MyMessage.Body = "Dear Sir/madam ," + Environment.NewLine + Environment.NewLine + EmailBody

    '    Dim attachFile As New Attachment(s, "TaxInvoice.pdf")
    '    MyMessage.Attachments.Add(attachFile)

    '    Dim SmtpServer As New SmtpClient(EmailHost)

    '    SmtpServer.Port = EmailPort
    '    SmtpServer.Credentials = New System.Net.NetworkCredential(FromEmail, FromPassword)
    '    SmtpServer.EnableSsl = True
    '    Try
    '        SmtpServer.Send(MyMessage)
    '    Catch ex As Exception
    '        SuccessMsg = SuccessMsg + ex.ToString + GrowerName + "<br/>"
    '        lblmsgG.Text = SuccessMsg
    '    End Try
    'Catch ex As Exception
    '    SuccessMsg = SuccessMsg + ex.ToString + GrowerName + "<br/>"
    '    lblmsgG.Text = SuccessMsg
    'End Try
    'SuccessMsg = SuccessMsg + "Sent Successfully to " + GrowerName + "<br/>"
    'lblmsgG.Text = SuccessMsg


    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt2)
        e.DataSources.Add(rptDataSource)
        Dim rptDataSource1 As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_UnsoldFlowerReport", dt3)
        e.DataSources.Add(rptDataSource1)
    End Sub

    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        ClientId = DdlSelectClient.SelectedValue
        BranchCode = DdlSelectBranch.SelectedValue
        Fromdate = cmbFrom.SelectedValue
        ToDate = CmbTo.SelectedValue
        InvoiceNo = txtInvoiceNo.Text
        Yearfrom = ddlYear.SelectedItem.ToString
        YearTo = ddlYearTo.SelectedItem.ToString
        If Yearfrom > YearTo Then
            lblmsg.Text = "From Year cannot be Greater than To Year."
            lblmsgG.Text = ""
            Exit Sub
        Else
            If Yearfrom = YearTo Then
                If Fromdate > ToDate Then
                    lblmsg.Text = "From Month cannot be Greater than To Month."
                    lblmsgG.Text = ""
                    GVTaxInvoice.Visible = False
                    Exit Sub
                End If
            End If
        End If
        If txtInvdate.Text = "" Then
            Invdate = Format(Today(), "dd-MMM-yyyy")
        Else
            Invdate = txtInvdate.Text
        End If
        ClientId = DdlSelectClient.SelectedValue
        BranchCode = DdlSelectBranch.SelectedValue
        Fromdate = cmbFrom.SelectedValue
        ToDate = CmbTo.SelectedValue
        InvoiceNo = txtInvoiceNo.Text
        Yearfrom = ddlYear.SelectedItem.ToString
        YearTo = ddlYearTo.SelectedItem.ToString
        dt = DLClientContractMaster.Clientcontractmonthlyrun(BranchCode, Fromdate, ToDate, Yearfrom, YearTo, ClientId)
        If dt.Rows.Count <> 0 Then
            GVTaxInvoice.DataSource = dt
            GVTaxInvoice.DataBind()
            GVTaxInvoice.Visible = True
            lblmsg.Text = ""
            lblmsgG.Text = ""
        Else
            lblmsg.Text = "No records to display."
            lblmsgG.Text = ""
            GVTaxInvoice.Visible = False
        End If
    End Sub
    Sub CheckAll()
        If CType(GVTaxInvoice.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVTaxInvoice.Rows
                CType(grid.FindControl("ChkBx"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GVTaxInvoice.Rows
                CType(grid.FindControl("ChkBx"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub BtnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Dim Chkid As Integer
        If ChkBoxHeader.Checked = True Then
            Chkid = 1
        Else
            Chkid = 0
        End If
        Dim SetUp As String = Request.QueryString.Get(("SetUp"))
        Dim InvoiceNo As String
        Fromdate = cmbFrom.SelectedValue
        ToDate = CmbTo.SelectedValue
        InvoiceNo = txtInvoiceNo.Text
        Yearfrom = ddlYear.SelectedItem.ToString
        YearTo = ddlYearTo.SelectedItem.ToString
        'Dim BranchCode As String = Request.QueryString.Get(("BranchCode"))
        ClientId = DdlSelectClient.SelectedValue
        BranchCode = DdlSelectBranch.SelectedValue
        'If txtInvoiceNo.Text = "" Then
        '    lblmsg.Text = " Enter Invoice Number."
        '    lblmsgG.Text = ""
        'Else

        lblmsg.Text = ""
        lblmsgG.Text = ""
        Dim qrystring As String = "RPT_SaleInvoiceVeiw.aspx?" & QueryStr.Querystring() & "&BranchCode=" & BranchCode & "&InvoiceNo=" & InvoiceNo & "&Chkid=" & Chkid & "&SetUp=" & SetUp & "&ClientID=" & ClientId & "&Fromdate=" & Fromdate & "&ToDate=" & ToDate & "&Yearfrom=" & Yearfrom & "&YearTo=" & YearTo
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)

        'End If
    End Sub
End Class
