
Partial Class rptDetailed
    Inherits System.Web.UI.Page
    Dim bll As New StudentB
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2, dt As New DataTable
    'Protected Sub ReportViewer2_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer2.Init

    '    Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
    '    Dim office As String = Request.QueryString("Office")
    '    Dim BranchCode As String = Request.QueryString("BranchCode")
    '    Dim BatchNo As Integer = Request.QueryString("BatchNo")


    '    dt1 = bll.GetDetailedRpt(BatchNo)
    '    If dt1.Rows.Count > 0 Then
    '        Re.LocalReport.ReportPath = "rptDetailed.rdlc"
    '        dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_New_STDRegisterDetail", dt1)

    '        ReportViewer2.LocalReport.DataSources.Clear()
    '        Me.ReportViewer2.LocalReport.DataSources.Add(dm)
    '        ReportViewer2.LocalReport.Refresh()

    '        dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
    '        AddHandler ReportViewer2.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

    '    Else
    '        lblErrorMsg.Text = "No Records to display"
    '    End If
    'End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub

    Protected Sub RepViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles RepViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim office As String = Request.QueryString("Office")
        Dim BranchCode As String = Request.QueryString("BranchCode")
        Dim BatchNo As Integer = Request.QueryString("BatchNo")
        Dim CourseId As Integer = Request.QueryString("CourseId")
        'Dim Ayear As String = Request.QueryString("Ayear")
        Dim DojDob As Integer = Request.QueryString.Get("DojDob")
        Dim FromDate As Date = Request.QueryString.Get("FromDate")
        Dim ToDate As Date = Request.QueryString.Get("ToDate")
        Dim Sort As Integer = Request.QueryString.Get("Sort")
        Dim Semid As Integer = Request.QueryString.Get("Semid")

        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 03 Dec 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "StudentRegD"
        dt2 = DLReportsR.EnquiryDetailsHeading(FormName, LanguageID)
        Dim StudentRegD, BranchName, BranchType, AcademicY, DOJ, FromDateN, ToDateN, SlNo, StdCode, StdName, StdCategory, DOJN, DOLN, Course, Batch As String
        StudentRegD = dt2.Rows(0).Item("Default_Text").ToString()
        BranchName = dt2.Rows(1).Item("Default_Text").ToString()
        BranchType = dt2.Rows(2).Item("Default_Text").ToString()
        'AcademicY = dt2.Rows(3).Item("Default_Text").ToString()
        DOJ = dt2.Rows(4).Item("Default_Text").ToString()
        FromDateN = dt2.Rows(5).Item("Default_Text").ToString()
        ToDateN = dt2.Rows(6).Item("Default_Text").ToString()
        SlNo = dt2.Rows(7).Item("Default_Text").ToString()
        StdCode = dt2.Rows(8).Item("Default_Text").ToString()
        StdName = dt2.Rows(9).Item("Default_Text").ToString()
        StdCategory = dt2.Rows(10).Item("Default_Text").ToString()
        DOJN = dt2.Rows(11).Item("Default_Text").ToString()
        DOLN = dt2.Rows(12).Item("Default_Text").ToString()
        Course = dt2.Rows(13).Item("Default_Text").ToString()
        Batch = dt2.Rows(14).Item("Default_Text").ToString()


        If Sort = 0 Then
            dt1 = bll.GetDetailedRpt(BranchCode, CourseId, BatchNo, DojDob, FromDate, ToDate, Semid)
            If dt1.Rows.Count > 0 Then
                RepViewer1.LocalReport.ReportPath = "rptDetailed.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_New_STDRegisterDetail", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Ayear", Ayear, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StudentRegD", StudentRegD, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DOJ", DOJ, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDateN", FromDateN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDateN", ToDateN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCategory", StdCategory, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DOJN", DOJN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DOLN", DOLN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Course", Course, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                RepViewer1.LocalReport.SetParameters(paramList)

                RepViewer1.LocalReport.DataSources.Clear()
                Me.RepViewer1.LocalReport.DataSources.Add(dm)
                RepViewer1.LocalReport.Refresh()

                dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler RepViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

            Else
                lblErrorMsg.Text = ValidationMessage(1023)
            End If

        Else
            dt1 = bll.GetDetailedRptSort(BranchCode, CourseId, BatchNo, DojDob, FromDate, ToDate, Semid)
            If dt1.Rows.Count > 0 Then
                RepViewer1.LocalReport.ReportPath = "rptDetailedSort.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_New_STDRegisterDetailSort", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Ayear", Ayear, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StudentRegD", StudentRegD, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DOJ", DOJ, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDateN", FromDateN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDateN", ToDateN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCategory", StdCategory, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DOJN", DOJN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DOLN", DOLN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Course", Course, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                RepViewer1.LocalReport.SetParameters(paramList)

                RepViewer1.LocalReport.DataSources.Clear()
                Me.RepViewer1.LocalReport.DataSources.Add(dm)
                RepViewer1.LocalReport.Refresh()

                dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler RepViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

            Else
                lblErrorMsg.Text = ValidationMessage(1023)
            End If
        End If
    End Sub
    ''Code Written for Multilingual By Niraj on 5th Dec 2013
    ''Retriving the text of controls based on Language
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt5 As DataTable
        dt5 = Session("ValidationTable")
        Dim X As Integer = dt5.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt5.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt5.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function
End Class

