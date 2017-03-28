Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLErrorLog
    Public Function ShowLog(ByVal EL As ElErrorLog) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Date", SqlDbType.DateTime)
        param(0).Value = EL.EDate
        
        param(1) = New SqlParameter("@Status", SqlDbType.VarChar, 20)
        param(1).Value = EL.Estatus

        param(2) = New SqlParameter("@TDate", SqlDbType.DateTime)
        param(2).Value = EL.TDate
       
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetErrorLogDetails", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function
    Public Function ShowError(ByVal LogId As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(0) {}
        param(0) = New SqlParameter("@LodId", SqlDbType.Int)
        param(0).Value = LogId



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetErrorLogMsg", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function
    Shared Function DeleteErrorLog(ByVal El As ElErrorLog) As Integer
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer

        Dim Param() As SqlParameter = New SqlParameter(0) {}
        Param(0) = New SqlClient.SqlParameter("@LodId", SqlDbType.Int)
        Param(0).Value = El.LogId


        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteGetErrorLog", Param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function Close(ByVal El As ElErrorLog) As Integer
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer

        Dim Param() As SqlParameter = New SqlParameter(1) {}
        Param(0) = New SqlClient.SqlParameter("@LodId", SqlDbType.Int)
        Param(0).Value = El.LogId
        Param(1) = New SqlClient.SqlParameter("@Status", SqlDbType.VarChar, 20)
        Param(1).Value = El.Estatus



        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateGetErrorLog", Param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function



End Class
