Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class DLTableMaster
    Shared Function GetTableNames(ByVal m As TableMaster) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[SP_GetTableNames]")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetTableNamesApprove(ByVal m As TableMaster) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[SP_GetTableNamesApprove]")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function InsertTableMaster(ByVal m As TableMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(2) {}

        Parms(0) = New SqlParameter("@TableName", SqlDbType.NVarChar, 100)
        Parms(0).Value = m.TableName
        Parms(1) = New SqlParameter("@TAL", SqlDbType.NVarChar, 50)
        Parms(1).Value = m.TableAL
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = m.BranchCode

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[SP_InsertTableMaster]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetAllTableMaster(ByVal p As TableMaster) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}
            If p.TableID = "0" Then
                Parms(0) = New SqlParameter("@Table_ID", SqlDbType.NVarChar, 100)
                Parms(0).Value = ""
            Else
                Parms(0) = New SqlParameter("@Table_ID", SqlDbType.Int)
                Parms(0).Value = p.TableID
            End If

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = p.BranchCode
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[SP_GetAllTableMaster]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function DeleteTableMaster(ByVal m As TableMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(0) {}
        Parms(0) = New SqlParameter("@Table_ID", SqlDbType.Int)
        Parms(0).Value = m.TableID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[SP_DeleteTableMaster]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function
    Shared Function UpdateTableMaster(ByVal m As TableMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(3) {}
        Parms(0) = New SqlParameter("@Table_ID", SqlDbType.Int)
        Parms(0).Value = HttpContext.Current.Session("Table_ID")
        Parms(1) = New SqlParameter("@TableName", SqlDbType.NVarChar, 100)
        Parms(1).Value = m.TableName
        Parms(2) = New SqlParameter("@TableAccessLvl", SqlDbType.NVarChar, 50)
        Parms(2).Value = m.TableAL
        Parms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(3).Value = m.BranchCode
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[SP_UpdateTableMaster]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function
End Class
