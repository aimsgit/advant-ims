Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLSemesterResultAnalysis
    Public Function GetReportData(ByVal A_Year As Integer, ByVal Batch As Integer, ByVal Semester As Integer, ByVal assesmentType As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@A_Year", SqlDbType.Int)
        arParms(0).Value = A_Year

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(2).Value = Batch

        arParms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(3).Value = Semester

        arParms(4) = New SqlParameter("@assesmentType", SqlDbType.Int)
        arParms(4).Value = assesmentType

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SemesterResultAnalysis", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
End Class
