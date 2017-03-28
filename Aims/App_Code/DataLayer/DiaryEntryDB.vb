Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DiaryEntryDB
    Shared Function GVDetails(ByVal Id As Integer) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms As SqlParameter
        arParms = New SqlParameter("@DiaryEntryId", SqlDbType.Int)

        arParms.Value = Id
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetDiaryEntry]", arParms)

        Return ds
    End Function
    Public Shared Function Insert(ByVal con As DiaryEntry) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@DiaryEntryId", SqlDbType.Int)
        arParms(0).Value = con.DiaryEntryId

        arParms(1) = New SqlParameter("@EntryText", SqlDbType.VarChar, 250)
        arParms(1).Value = con.EntryText

        arParms(2) = New SqlParameter("@EntryTitle", SqlDbType.VarChar, 250)
        arParms(2).Value = con.EntryTitle


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_SaveDiaryEntry]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Delete(ByVal Id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms As SqlParameter
        arParms = New SqlParameter("@DiaryEntryId", SqlDbType.Int, 10)
        arParms.Value = Id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_DeleteDiaryEntry]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
End Class
