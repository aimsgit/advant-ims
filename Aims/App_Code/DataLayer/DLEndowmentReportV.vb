Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLEndowmentReportV
    Public Function Rpt_sponsor(ByVal sponsor As String, ByVal IssueFrom As Date, ByVal IssueTo As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@SponsorID", SqlDbType.NVarChar, 50)
        arParms(2).Value = sponsor

        arParms(3) = New SqlParameter("@FromIssueDate", SqlDbType.Date)
        arParms(3).Value = IssueFrom

        arParms(4) = New SqlParameter("@ToIssueDate", SqlDbType.Date)
        arParms(4).Value = IssueTo
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_SponsorEndowment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

End Class
