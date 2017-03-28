Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class RecoverDB
    Public Function RecoverTimeTable(ByVal Id As Int64) As Int16
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Int16 = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_RecoverTimeTable", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function TimeTableGridFill() As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, "SELECT * FROM View_TimeTableDelGridFill")
        Return ds.Tables(0)
    End Function
End Class
