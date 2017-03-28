Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLbookissuerpt
    Public Function Rpt_BookIssue(ByVal BranchCode As String, ByVal Dept As String, ByVal bookissueto As String, ByVal IssueFrom As Date, ByVal IssueTo As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BookIssueTo", SqlDbType.VarChar, 20)
        arParms(2).Value = bookissueto

        arParms(3) = New SqlParameter("@FromIssueDate", SqlDbType.Date)
        arParms(3).Value = IssueFrom

        arParms(4) = New SqlParameter("@ToIssueDate", SqlDbType.Date)
        arParms(4).Value = IssueTo

        arParms(5) = New SqlParameter("@DeptId", SqlDbType.VarChar, 50)
        arParms(5).Value = Dept

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_BookIssueReport", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
