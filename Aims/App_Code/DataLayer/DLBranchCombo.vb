Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLBranchCombo
    Shared Function insertBatch(ByVal Aid As Integer, ByVal CourseID As Integer, ByVal BranchCode As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode

        arParms(1) = New SqlParameter("@AYear", SqlDbType.Int)
        arParms(1).Value = Aid

        arParms(2) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(2).Value = CourseID

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetNewBatchSelect", arParms)
        Return ds.Tables(0)
    End Function
End Class
