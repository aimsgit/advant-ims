Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class GetConfigProcDB
    Shared Function GetTableName() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetTableName")
        Return ds
    End Function
    Shared Function GetConfigProc() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetConfigProc")
        Return ds
    End Function

    Shared Function Insert(ByVal c As ConfigProcessP) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Table_ID", SqlDbType.Int)
        arParms(0).Value = c.TableID
        arParms(1) = New SqlParameter("@AppReq", c.AppReq.Length)
        arParms(1).Value = c.AppReq

        arParms(2) = New SqlParameter("@AppBy", c.AppBy.Length)
        arParms(2).Value = c.AppBy

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertConfgProc", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function Update(ByVal c As ConfigProcessP) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(0).Value = c.ID

        arParms(1) = New SqlParameter("@Table_ID", SqlDbType.Int)
        arParms(1).Value = c.TableID
        arParms(2) = New SqlParameter("@AppReq", c.AppReq.Length)
        arParms(2).Value = c.AppReq

        arParms(3) = New SqlParameter("@AppBy", c.AppBy.Length)
        arParms(3).Value = c.AppBy
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateConfigProc", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function UpdateTables(ByVal c As ConfigProcessP) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim AppReqBit As Boolean

        If c.AppReq = "Y" Then
            AppReqBit = 1
        Else
            AppReqBit = 0
        End If

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@TableName", c.TableName.Length)
        arParms(0).Value = c.TableName

        arParms(1) = New SqlParameter("@AppReq", SqlDbType.Bit)
        arParms(1).Value = AppReqBit

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateTables", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms As SqlParameter = New SqlParameter

        arParms = New SqlParameter("@ID", SqlDbType.BigInt)
        arParms.Value = Id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteConfigProc", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
End Class
