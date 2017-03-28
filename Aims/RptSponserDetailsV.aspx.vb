
Partial Class RptSponserDetailsV
    Inherits System.Web.UI.Page
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt As New DataTable


    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt2 As New Data.DataTable
        Dim DL As New SponsorDB
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim LanguageID As Integer
        Dim FormName As String
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "Sponsor Details"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim SponsorDetails, BranchType, BranchName, SlNo, Name, ContactNo, Address, Email, Remarks As String
        SponsorDetails = dt2.Rows(0).Item("Default_Text").ToString()
        BranchType = dt2.Rows(1).Item("Default_Text").ToString()
        BranchName = dt2.Rows(2).Item("Default_Text").ToString()
        SlNo = dt2.Rows(3).Item("Default_Text").ToString()
        Name = dt2.Rows(4).Item("Default_Text").ToString()
        ContactNo = dt2.Rows(5).Item("Default_Text").ToString()
        Address = dt2.Rows(6).Item("Default_Text").ToString()
        Email = dt2.Rows(7).Item("Default_Text").ToString()
        Remarks = dt2.Rows(8).Item("Default_Text").ToString()
        dt1 = DL.RptGetSponsor()
        Try
            If dt1.Rows.Count > 0 Then
                ReportViewer1.LocalReport.ReportPath = "RptSponserDetails.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_GetSponsorDetails", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SponsorDetails", SponsorDetails, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Name", Name, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ContactNo", ContactNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Address", Address, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Email", Email, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Remarks", Remarks, False))
                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else

                lblmsg.Text = ValidationMessage(1023)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1074)
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 03th sep 2013
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
