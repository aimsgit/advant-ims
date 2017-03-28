
Partial Class RptStudMedicalDetailsV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLReport
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim StdID As String = Request.QueryString.Get("Std_ID")
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.RptMedicalDetails(StdID)
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 12 Dec 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "SMedicalDetailsR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim SMedicalDetailsR, Disability, ECNo, ECName, alergy, SeriousIllness, ImmuRecord, StdCode, Blood, Identification, StdName, Weight, Height As String

        SMedicalDetailsR = dt2.Rows(0).Item("Default_Text").ToString()
        StdCode = dt2.Rows(1).Item("Default_Text").ToString()
        StdName = dt2.Rows(2).Item("Default_Text").ToString()
        Height = dt2.Rows(3).Item("Default_Text").ToString()
        Weight = dt2.Rows(4).Item("Default_Text").ToString()
        Identification = dt2.Rows(5).Item("Default_Text").ToString()
        Blood = dt2.Rows(6).Item("Default_Text").ToString()
        ImmuRecord = dt2.Rows(7).Item("Default_Text").ToString()
        SeriousIllness = dt2.Rows(8).Item("Default_Text").ToString()
        alergy = dt2.Rows(9).Item("Default_Text").ToString()
        ECName = dt2.Rows(10).Item("Default_Text").ToString()
        ECNo = dt2.Rows(11).Item("Default_Text").ToString()
        Disability = dt2.Rows(12).Item("Default_Text").ToString()
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptStudMedicalDetails.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_GetMedicalDetails", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SMedicalDetailsR", SMedicalDetailsR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Height", Height, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Weight", Weight, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Identification", Identification, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Blood", Blood, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ImmuRecord", ImmuRecord, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SeriousIllness", SeriousIllness, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("alergy", alergy, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ECName", ECName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ECNo", ECNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Disability", Disability, False))
                
                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = ValidationMessage(1023)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1074)
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 12th Dec 2013
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