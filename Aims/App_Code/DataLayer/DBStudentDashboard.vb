Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DBStudentDashboard
    Shared Function Generate(ByVal id As Integer, ByVal StdCode As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim dt As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@Stdid", SqlDbType.Int)
        arParms(2).Value = id

        arParms(3) = New SqlParameter("@Studentcode", SqlDbType.VarChar, 50)
        arParms(3).Value = StdCode
        '  dt = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_StudentDashboard", arParms)
        dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_StudentDashboard", arParms)


        Return dt.Tables(0)
    End Function
    Shared Function stddetails() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim dt As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Studentcode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("StudentCode")

        '  dt = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_StudentDashboard", arParms)
        dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_StudentDetailsDB", arParms)

        Return dt.Tables(0)
    End Function
End Class
