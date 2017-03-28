Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class DLStdReportCard
    Shared Function GetStudentReportCard(ByVal BranchCode As String, ByVal StdId As Integer, ByVal batch As Integer, ByVal sem As Integer, ByVal ass As String, ByVal SortBy As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode
        arParms(1) = New SqlParameter("@STDID", SqlDbType.Int)
        arParms(1).Value = StdId

        arParms(2) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(2).Value = batch

        arParms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(3).Value = sem

        arParms(4) = New SqlParameter("@AssessmentType", SqlDbType.VarChar, 5000)
        arParms(4).Value = ass

        arParms(5) = New SqlParameter("@SortBy", SqlDbType.Int)
        arParms(5).Value = SortBy
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudentReportCard", arParms)
        Return ds.Tables(0)
    End Function
End Class
