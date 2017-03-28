
Partial Class RptStudAttendListV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim DL As New stdAttndance
        Dim Bat, Sem, id, RptType, Subject, SubSubgrp, StdId As Integer
        Dim FrmDate, ToDate As Date
        Dim BranchCode As String
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 06 Jan 2014
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "SemAttenListR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim SemAttenListR, Batch, Semester, Reg, TotalClass, Count, DateN As String

        SemAttenListR = dt2.Rows(0).Item("Default_Text").ToString()
        Batch = dt2.Rows(1).Item("Default_Text").ToString()
        Semester = dt2.Rows(2).Item("Default_Text").ToString()
        Reg = dt2.Rows(3).Item("Default_Text").ToString()
        TotalClass = dt2.Rows(4).Item("Default_Text").ToString()
        Count = dt2.Rows(5).Item("Default_Text").ToString()
        DateN = dt2.Rows(6).Item("Default_Text").ToString()
        If Session("LoginType") = "Others" Then
            ds1 = DLReportsR.stddetails()

            StdId = ds1.Rows(0).Item("STD_ID").ToString
            BranchCode = ds1.Rows(0).Item("BranchCode").ToString
            Bat = ds1.Rows(0).Item("Batch_No").ToString
            Sem = ds1.Rows(0).Item("SemesterID").ToString
            Subject = 0
            SubSubgrp = 0
            RptType = 1
            Dim Dt As New DataTable
            Dt = stdAttndance.StudentStartEndDate(Bat, Sem)
            FrmDate = Dt.Rows(0).Item("StartDate")
            ToDate = Dt.Rows(0).Item("EndDate")
            id = 0
            Dim dt1 As New Data.DataTable
            QueryStr.GetValue(Page.Request, Prop)
            dt1 = DL.GetNewSemAttendListParentReport(Bat, Sem, id, FrmDate, ToDate, Subject, SubSubgrp, StdId)
            Try
                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "RptStudAttendList.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_SemAttenMap", dt1)

                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("RptType", RptType, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemAttenListR", SemAttenListR, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Reg", Reg, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TotalClass", TotalClass, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Count", Count, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DateN", DateN, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()

                    dt1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblmsg.Text = ValidationMessage(1023)
                End If
            Catch ex As Exception
                lblmsg.Text = ValidationMessage(1074)
            End Try

        Else
            If Session("Form") = "frmStudentEnquiryForm.aspx" Then
                StdId = Request.QueryString.Get("Student")
                BranchCode = Request.QueryString.Get("BranchCode")
                Bat = Request.QueryString.Get("Batch")
                Sem = Request.QueryString.Get("Semester")
                Subject = 0
                SubSubgrp = 0
                RptType = 1
                Dim Dt2 As New DataTable
                Dt2 = stdAttndance.StudentStartEndDate(Bat, Sem)
                FrmDate = Dt2.Rows(0).Item("StartDate")
                ToDate = Dt2.Rows(0).Item("EndDate")
                id = 0
                Dim dt1 As New Data.DataTable
                QueryStr.GetValue(Page.Request, Prop)
                dt1 = DL.GetNewSemAttendListParentReport(Bat, Sem, id, FrmDate, ToDate, Subject, SubSubgrp, StdId)
                Try
                    If dt1.Rows.Count > 0 Then
                        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                        Me.ReportViewer1.LocalReport.ReportPath = "RptStudAttendList.rdlc"
                        dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_SemAttenMap", dt1)

                        Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("RptType", RptType, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemAttenListR", SemAttenListR, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Reg", Reg, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TotalClass", TotalClass, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Count", Count, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DateN", DateN, False))
                        ReportViewer1.LocalReport.SetParameters(paramList)

                        ReportViewer1.LocalReport.DataSources.Clear()
                        Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                        ReportViewer1.LocalReport.Refresh()

                        dt1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    Else
                        lblmsg.Text = ValidationMessage(1023)
                    End If
                Catch ex As Exception
                    lblmsg.Text = ValidationMessage(1074)
                End Try
                Exit Sub
            End If

            Bat = Request.QueryString.Get("BatchID")
            Sem = Request.QueryString.Get("Semester")
            id = Request.QueryString.Get("id")
            FrmDate = Request.QueryString.Get("FrmDate")
            ToDate = Request.QueryString.Get("ToDate")
            RptType = Request.QueryString.Get("RptType")
            Subject = Request.QueryString.Get("Subject")
            SubSubgrp = Request.QueryString.Get("SubSubgrp")
            Dim dt As New Data.DataTable
            QueryStr.GetValue(Page.Request, Prop)
            dt1 = DL.GetNewSemAttendListReport(Bat, Sem, id, FrmDate, ToDate, Subject, SubSubgrp)
            Try
                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "RptStudAttendList.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_SemAttenMap", dt1)

                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("RptType", RptType, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemAttenListR", SemAttenListR, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Reg", Reg, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TotalClass", TotalClass, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Count", Count, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DateN", DateN, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()

                    dt1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblmsg.Text = ValidationMessage(1023)
                End If
            Catch ex As Exception
                lblmsg.Text = ValidationMessage(1074)
            End Try
            'Dim BAL As New GlobalDataSetTableAdapters.Test_BankReconciliationTableAdapter
          
        End If

       
    
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt1)
        e.DataSources.Add(rptDataSource)
    End Sub
   
    ''Retriving the text of controls based on Language
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        dt2 = Session("ValidationTable")
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function
End Class



