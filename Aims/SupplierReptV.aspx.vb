
Partial Class BranchrptV
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        ' Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Bll As New SupplierManager
        Dim dt1, dt2 As New DataTable
        'QueryStr.GetValue(Page.Request, Prop)

        'Dim brnID As Integer = CInt(Request.QueryString(0))
        'Dim insID As Integer = CInt(Request.QueryString(1))
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 17 Sep 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "SupplierDetailsR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim SupplierDetailsR, BranchType, BranchName, SlNo, SupplierName, ContactPerson, ContactNo, Address, Code, CreditPeriod, CreditLimit, OBCR, OBDR, OBDate As String
        SupplierDetailsR = dt2.Rows(0).Item("Default_Text").ToString()
        BranchName = dt2.Rows(1).Item("Default_Text").ToString()
        BranchType = dt2.Rows(2).Item("Default_Text").ToString()
        SlNo = dt2.Rows(3).Item("Default_Text").ToString()
        SupplierName = dt2.Rows(4).Item("Default_Text").ToString()
        ContactPerson = dt2.Rows(5).Item("Default_Text").ToString()
        ContactNo = dt2.Rows(6).Item("Default_Text").ToString()
        Address = dt2.Rows(7).Item("Default_Text").ToString()
        Code = dt2.Rows(8).Item("Default_Text").ToString()
        CreditPeriod = dt2.Rows(9).Item("Default_Text").ToString()
        CreditLimit = dt2.Rows(10).Item("Default_Text").ToString()
        OBCR = dt2.Rows(11).Item("Default_Text").ToString()
        OBDR = dt2.Rows(12).Item("Default_Text").ToString()
        OBDate = dt2.Rows(13).Item("Default_Text").ToString()
        dt1 = Bll.GetSupplierDetailsRpt()
        Try
            If dt1.Rows.Count > 0 Then
                ReportViewer1.LocalReport.ReportPath = "SupplierDetailsRept.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_SupplierDetails", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SupplierDetailsR", SupplierDetailsR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SupplierName", SupplierName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ContactPerson", ContactPerson, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ContactNo", ContactNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Address", Address, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Code", Code, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CreditPeriod", CreditPeriod, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CreditLimit", CreditLimit, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("OBCR", OBCR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("OBDR", OBDR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("OBDate", OBDate, False))
                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                LblError.Text = ValidationMessage(1023)
            End If
        Catch ex As Exception
            LblError.Text = ValidationMessage(1074)
        End Try

        'Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        'Me.ReportViewer1.LocalReport.ReportPath = "SupplierDetailsRept.rdlc"
        ''dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_SupplierMaster", Bll.GetReport(insID, brnID))
        'dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_SupplierDetails", Bll.GetSupplierDetailsRpt())
        'ReportViewer1.LocalReport.DataSources.Clear()
        'Me.ReportViewer1.LocalReport.DataSources.Add(dt)
        'ReportViewer1.LocalReport.Refresh()

        'ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
        'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 17th sep 2013
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
