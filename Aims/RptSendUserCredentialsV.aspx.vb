Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Security.Cryptography
Imports System
Imports System.Data.SqlClient
Partial Class RptSendUserCredentialsV

    Inherits BasePage
    Dim ds1 As Data.DataTable
    Dim dt2 As New DataTable
    Dim DLRpt As New DayBookDB
    Dim obj As New SelfDetailsB
    Public dt1 As DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim tablecount As Integer
        Dim tablecount1 As Integer
        Dim decrtptpassword As String
        Dim Prop As New QureyStringP
        Dim password As String
        Dim ChkID As String = Request.QueryString.Get("ChkID")
        Dim ID As String = Request.QueryString.Get("Group")
        Dim GroupName As String = Request.QueryString.Get("GroupName")
        Dim Emp_Code As String = Request.QueryString.Get("Emp_Code")
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        QueryStr.GetValue(Page.Request, Prop)
        'If ID = 1 Then
        dt1 = DLSendUserCredentials.GetParentLoginDetails(ChkID, GroupName, Emp_Code)
        'Else
        '    dt1 = DLSendUserCredentials.GetEmployeeDetails(ChkID)
        'End If
        tablecount = dt1.Rows.Count
        tablecount1 = 0
        While tablecount > 0
            password = dt1.Rows(tablecount - 1).Item("password")
            decrtptpassword = RijndaelSimple.Decrypt(password, _
                                           RijndaelSimple.passPhrase, _
                                           RijndaelSimple.saltValue, _
                                           RijndaelSimple.hashAlgorithm, _
                                           RijndaelSimple.passwordIterations, _
                                           RijndaelSimple.initVector, _
                                           RijndaelSimple.keySize)

            dt1.Rows(tablecount - 1).Item("Password") = decrtptpassword
           
            tablecount = tablecount - 1
        End While


        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptSendUserCredentials.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RptSendParentCredentials", dt1)
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()

                dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblMsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt2)
        e.DataSources.Add(rptDataSource)
    End Sub
   
End Class
