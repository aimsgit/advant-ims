'Imports System.Data.OleDb
'Imports System.Data

'Partial Class DepreciationRateV
'Inherits System.Web.UI.Page
'Dim dt, dt2 As New DataTable
'Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
'    Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
'    Dim obj As New SelfDetailsB
'    Dim Bll As New Depreciation_Rates
'    Dim ds As New DataTable
'    Dim LanguageID As Integer
'    Dim FormName As String
'    ''Multilingual Conversion  By: Niraj on 14 Sep 2013
'    If Session("LanguageID") = "" Then
'        LanguageID = 1
'    Else
'        LanguageID = Session("LanguageID")
'    End If
'    FormName = "DepreciationRatesR"
'    dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
'    Dim DepreciationRatesR, BranchType, BranchName, SlNo, AssetType, GDRate, CDRate As String
'    DepreciationRatesR = dt2.Rows(0).Item("Default_Text").ToString()
'    BranchType = dt2.Rows(1).Item("Default_Text").ToString()
'    BranchName = dt2.Rows(2).Item("Default_Text").ToString()
'    SlNo = dt2.Rows(3).Item("Default_Text").ToString()
'    AssetType = dt2.Rows(4).Item("Default_Text").ToString()
'    GDRate = dt2.Rows(5).Item("Default_Text").ToString()
'    CDRate = dt2.Rows(6).Item("Default_Text").ToString()


'    ds = Bll.RptDepreciationCompRpt(Request.QueryString(1), Request.QueryString(0))
'    ReportViewer1.LocalReport.ReportPath = "rptDepreciationRate.rdlc"
'    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Depreciation_Rates", ds)
'    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
'    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DepreciationRatesR", DepreciationRatesR, False))
'    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
'    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
'    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
'    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AssetType", AssetType, False))
'    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("GDRate", GDRate, False))
'    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CDRate", CDRate, False))


'    ReportViewer1.LocalReport.SetParameters(paramList)
'    ReportViewer1.LocalReport.DataSources.Clear()
'    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
'    ReportViewer1.LocalReport.Refresh()

'    'dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
'    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
'End Sub
'Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
'    Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
'    e.DataSources.Add(rptDataSource)
'End Sub
Partial Class DepreciationRateV
    Inherits System.Web.UI.Page
    Dim ds1 As Data.DataTable
    Dim dt2 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim DAL As New CompanyDB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 14 Sep 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "DepreciationRatesR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim DepreciationRatesR, BranchType, BranchName, SlNo, AssetType, GDRate, CDRate As String
        DepreciationRatesR = dt2.Rows(0).Item("Default_Text").ToString()
        BranchType = dt2.Rows(1).Item("Default_Text").ToString()
        BranchName = dt2.Rows(2).Item("Default_Text").ToString()
        SlNo = dt2.Rows(3).Item("Default_Text").ToString()
        AssetType = dt2.Rows(4).Item("Default_Text").ToString()
        GDRate = dt2.Rows(5).Item("Default_Text").ToString()
        CDRate = dt2.Rows(6).Item("Default_Text").ToString()

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = CompanyDB.RptCompanyMaster(Prop.insID, Prop.brnID)
        Try

            If dt1.Rows.Count > 0 Then

                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "rptDepreciationRate.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RptCompanyMaster", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DepreciationRatesR", DepreciationRatesR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AssetType", AssetType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("GDRate", GDRate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CDRate", CDRate, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()

                dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = ValidationMessage(1023)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1074)
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt2)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 14th sep 2013
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
