Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class DLAimsUsageAnalytics
    Shared Function GetTableNames(ByVal m As TableMaster) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetTableNames")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetTableDetails(ByVal EL As ELAimsUsageAnalytics) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@InstId", SqlDbType.VarChar, 50)
        arParms(2).Value = EL.InstId

        arParms(3) = New SqlParameter("@BranchId", SqlDbType.VarChar, 50)
        arParms(3).Value = EL.BranchId

        arParms(4) = New SqlParameter("@TableId", SqlDbType.Int)
        arParms(4).Value = EL.TableId

        arParms(5) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(5).Value = EL.FromDate

        arParms(6) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(6).Value = EL.ToDate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetTableDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetTableDetailsReport(ByVal InstId As String, ByVal BranchId As String, ByVal TableId As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@InstId", SqlDbType.VarChar, 50)
        arParms(2).Value = InstId

        arParms(3) = New SqlParameter("@BranchId", SqlDbType.VarChar, 50)
        arParms(3).Value = BranchId

        arParms(4) = New SqlParameter("@TableId", SqlDbType.Int)
        arParms(4).Value = TableId

        arParms(5) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(5).Value = FromDate

        arParms(6) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(6).Value = ToDate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetTableDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetBranchDDl(ByVal BranchCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(0) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = BranchCode

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetBranchAnalyiticsDDL", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetInstitute() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataSet

        Try
            dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetInstituteDDLforAnalytics")
        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
        End Try
        Return dt.Tables(0)
    End Function
End Class
