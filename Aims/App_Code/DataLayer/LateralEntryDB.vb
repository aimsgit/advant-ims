Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class LateralEntryDB
    Shared Function Insert(ByVal l As LateralEntry) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = l.Id

        arParms(1) = New SqlParameter("@stdcode", SqlDbType.Char, l.StdCode.Length)
        arParms(1).Value = l.StdCode

        arParms(2) = New SqlParameter("@admissionyear", SqlDbType.Char, l.AdmissionYear.Length)
        arParms(2).Value = l.AdmissionYear

        arParms(3) = New SqlParameter("@feepaid", SqlDbType.Money)
        arParms(3).Value = l.FeePaid

        arParms(4) = New SqlParameter("@attendedexam", SqlDbType.Char, l.AttendedExam.Length)
        arParms(4).Value = l.AttendedExam

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveLateralEntryDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function
    Shared Function GetLateralDetails(ByVal stdcode As String) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms As SqlParameter

        arParms = New SqlParameter("@stdcode", SqlDbType.VarChar)
        arParms.Value = stdcode
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLateralEntryDetails", arParms)

        Return ds
    End Function
    Shared Function ChangeFlag(ByVal Id As Long) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteLateralEntryDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
End Class
