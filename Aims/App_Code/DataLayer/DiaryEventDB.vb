Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DiaryEventDB
    Shared Function GVDetails(ByVal Id As Integer) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms As SqlParameter
        arParms = New SqlParameter("@DiaryId", SqlDbType.Int)

        arParms.Value = Id
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetDiaryDetails]", arParms)

        Return ds
    End Function
    Public Shared Function Insert(ByVal con As DiaryEvent) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@DiaryId", SqlDbType.Int)
        arParms(0).Value = con.DiaryId

        arParms(1) = New SqlParameter("@EventName", SqlDbType.VarChar, 100)
        arParms(1).Value = con.EventName

        arParms(2) = New SqlParameter("@EventDescription", SqlDbType.VarChar, 100)
        arParms(2).Value = con.EventDescription

        arParms(3) = New SqlParameter("@EventDate", SqlDbType.DateTime)
        arParms(3).Value = con.EventDate

        arParms(4) = New SqlParameter("@EventDuration", SqlDbType.Int)
        arParms(4).Value = con.EventDuration


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_SaveDiaryEvent]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Delete(ByVal Id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms As SqlParameter
        arParms = New SqlParameter("@DiaryId", SqlDbType.Int, 10)
        arParms.Value = Id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteDiaryEvent", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
End Class
