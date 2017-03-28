Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLDashBoard
    Public Function DashBoardEmployeeDrillDown(ByVal BranchCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms As SqlParameter
        arParms = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms.Value = BranchCode

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "DashBoardEmployeeDrillDown", arParms)

        Return ds.Tables(0)
    End Function
    Public Function DashBoardEmployeeDrillDownCount(ByVal BranchCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms As SqlParameter
        arParms = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms.Value = BranchCode

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ManagementDashboardStaffCount", arParms)

        Return ds.Tables(0)
    End Function
    Public Function DashBoardEmployeeDrillDown1(ByVal BranchCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms As SqlParameter
        arParms = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms.Value = BranchCode

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "DashBoardEmployeeDrillDown1", arParms)

        Return ds.Tables(0)
    End Function

    Public Function DashBoardFeeCollectionDrillDown(ByVal BranchCode As String, ByVal CourseId As Integer, ByVal fromdate As Date, ByVal todate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode

        arParms(1) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(1).Value = CourseId

        'arParms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        'arParms(2).Value = BatchId

        arParms(2) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(2).Value = fromdate

        arParms(3) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(3).Value = todate

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_DashBoardFeeCollectionDrillDown", arParms)

        Return ds.Tables(0)
    End Function
    Public Function DashBoardAdmittedDrillDown(ByVal BranchCode As String, ByVal CourseId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode

        arParms(1) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(1).Value = CourseId

        'arParms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        'arParms(2).Value = BatchId

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_DashBoardAdmittedDrillDown", arParms)

        Return ds.Tables(0)
    End Function
End Class
