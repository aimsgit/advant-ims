Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLStateMaster
    Public Function GetCountry_Name() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DDLCountry")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Function Insert(ByVal i As ELStateMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@CountryId", SqlDbType.Int)
        arParms(0).Value = i.Country
        arParms(1) = New SqlParameter("@StateName", SqlDbType.VarChar, 50)
        arParms(1).Value = i.State
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertState", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected

    End Function
    Public Function GetState(ByVal s As ELStateMaster) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(0) {}
        para(0) = New SqlParameter("@StateId", SqlDbType.Int)
        para(0).Value = s.id
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetState", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function CheckDuplicate(ByVal s As ELStateMaster) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@StateName", SqlDbType.NVarChar, 50)
        para(0).Value = s.State
        para(1) = New SqlParameter("@CountryId", SqlDbType.Int)
        para(1).Value = s.Country
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = s.id
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_DuplicateStateMaster", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Function Update(ByVal i As ELStateMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@StateName", SqlDbType.NVarChar, 50)
        para(0).Value = i.State
        para(1) = New SqlParameter("@CountryId", SqlDbType.Int)
        para(1).Value = i.Country
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = i.id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateState", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

End Class
