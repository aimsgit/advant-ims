Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLElectivesMapReport
    Public Function Rpt_Electives(ByVal CourseId As Integer, ByVal BatchId As Integer, ByVal SemesterID As Integer, ByVal ElectiveID As Integer, ByVal Sort As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(2).Value = CourseId

        arParms(3) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(3).Value = BatchId

        arParms(4) = New SqlParameter("@SemesterID", SqlDbType.Int)
        arParms(4).Value = SemesterID

        arParms(5) = New SqlParameter("@ElectiveID", SqlDbType.Int)
        arParms(5).Value = ElectiveID

        arParms(6) = New SqlParameter("@Sort", SqlDbType.Int)
        arParms(6).Value = Sort

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_ElectivesMap", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


End Class
