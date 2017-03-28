Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLStudentDetAICTE
    Shared Function StdDetail() As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_StdDetailsAicte")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function GetCourse() As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        'arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        'arParms(0).Value = Branchcode

        arParms(0) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_BranchCourseCombo2", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function insertBatchOpenN(ByVal CourseID As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        'arParms(1) = New SqlParameter("@AYear", SqlDbType.Int)
        'arParms(1).Value = Aid

        arParms(1) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(1).Value = CourseID

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_BatchComboWithCourse&AYNew1", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function StudentDynamicReport(ByVal Course As Integer, ByVal Batch As Integer, ByVal id As String, ByVal str1 As String, ByVal semid As Integer, ByVal semid1 As Integer, ByVal semid2 As Integer, ByVal semid3 As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@Course", SqlDbType.Int)
        arParms(0).Value = Course '0

        arParms(1) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(1).Value = Batch '0

        arParms(2) = New SqlParameter("@ColumnNames", SqlDbType.VarChar)
        arParms(2).Value = id
        arParms(3) = New SqlParameter("BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")
        arParms(4) = New SqlParameter("@str", SqlDbType.VarChar)
        arParms(4).Value = str1

        arParms(5) = New SqlParameter("@semid", SqlDbType.Int)
        arParms(5).Value = semid

        arParms(6) = New SqlParameter("@semid1", SqlDbType.Int)
        arParms(6).Value = semid1
        arParms(7) = New SqlParameter("@semid2", SqlDbType.Int)
        arParms(7).Value = semid2
        arParms(8) = New SqlParameter("@semid3", SqlDbType.Int)
        arParms(8).Value = semid3


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[Rpt_StudentDetailsDynamicReport]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function sem1() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}



        arParms(0) = New SqlParameter("BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[sem1]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function sem2() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}



        arParms(0) = New SqlParameter("BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[sem2]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function sem3() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}



        arParms(0) = New SqlParameter("BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[sem3]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function sem4() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}



        arParms(0) = New SqlParameter("BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[sem4]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function batch(ByVal Course As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("Course", SqlDbType.Int)
        arParms(0).Value = Course

        arParms(1) = New SqlParameter("BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[batch]", arParms)
        Return ds.Tables(0)
    End Function
End Class
