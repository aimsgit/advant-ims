Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLSelectElective
    Shared Function StudentCurrentSem(ByVal BatchId As Integer, ByVal BranchCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(0).Value = BatchId

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = BranchCode

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStudentCurrentSem", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function StudentCurrentBatch(ByVal StdCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@StdCode", SqlDbType.VarChar)
            Parms(0).Value = StdCode

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetNewStdCurrent", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function ddlelective() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(5) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = HttpContext.Current.Session("BatchID")
        param(3) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("StudentCode")
        param(4) = New SqlParameter("@CourseID", SqlDbType.Int)
        param(4).Value = HttpContext.Current.Session("CourseID")
        param(5) = New SqlParameter("@SemesterID", SqlDbType.Int)
        param(5).Value = HttpContext.Current.Session("SemesterID")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getSubjectddlforElective", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function ddloption() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(5) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = HttpContext.Current.Session("BatchID")
        param(3) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("StudentCode")
        param(4) = New SqlParameter("@CourseID", SqlDbType.Int)
        param(4).Value = HttpContext.Current.Session("CourseID")
        param(5) = New SqlParameter("@SemesterID", SqlDbType.Int)
        param(5).Value = HttpContext.Current.Session("SemesterID")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getSubjectddlforOption", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function countsub(ByVal Batch As Integer,ByVal i As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(6) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = HttpContext.Current.Session("BatchID")
        param(3) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("StudentCode")
        param(4) = New SqlParameter("@CourseID", SqlDbType.Int)
        param(4).Value = HttpContext.Current.Session("CourseID")
        param(5) = New SqlParameter("@SemesterID", SqlDbType.Int)
        param(5).Value = HttpContext.Current.Session("SemesterID")
        param(6) = New SqlParameter("@i", SqlDbType.Int)
        param(6).Value = i
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getcountelective", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function creditpoint(ByVal subjectid As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(6) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = HttpContext.Current.Session("BatchID")
        param(3) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("StudentCode")
        param(4) = New SqlParameter("@CourseID", SqlDbType.Int)
        param(4).Value = HttpContext.Current.Session("CourseID")
        param(5) = New SqlParameter("@SemesterID", SqlDbType.Int)
        param(5).Value = HttpContext.Current.Session("SemesterID")
        param(6) = New SqlParameter("@SubjectID", SqlDbType.Int)
        param(6).Value = subjectid
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getSubjectCredit", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function UpdateElective(ByVal Elective As Integer, ByVal Options As Integer) As Integer
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(7) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = HttpContext.Current.Session("BatchID")
        param(3) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("StudentCode")
        param(4) = New SqlParameter("@CourseID", SqlDbType.Int)
        param(4).Value = HttpContext.Current.Session("CourseID")
        param(5) = New SqlParameter("@SemesterID", SqlDbType.Int)
        param(5).Value = HttpContext.Current.Session("SemesterID")
        param(6) = New SqlParameter("@ElectiveID", SqlDbType.Int)
        param(6).Value = Elective
        param(7) = New SqlParameter("@SubjectID", SqlDbType.Int)
        param(7).Value = Options
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_updateElective", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Public Function getoptions() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(5) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = HttpContext.Current.Session("BatchID")
        param(3) = New SqlParameter("@CourseID", SqlDbType.Int)
        param(3).Value = HttpContext.Current.Session("CourseID")
        param(4) = New SqlParameter("@SemesterID", SqlDbType.Int)
        param(4).Value = HttpContext.Current.Session("SemesterID")
        param(5) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
        param(5).Value = HttpContext.Current.Session("StudentCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getsubjectoption", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function insertoption(ByVal subjectid As String) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(7) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = HttpContext.Current.Session("BatchID")
        param(3) = New SqlParameter("@CourseID", SqlDbType.Int)
        param(3).Value = HttpContext.Current.Session("CourseID")
        param(4) = New SqlParameter("@SemesterID", SqlDbType.Int)
        param(4).Value = HttpContext.Current.Session("SemesterID")
        param(5) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
        param(5).Value = HttpContext.Current.Session("StudentCode")
        param(6) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        param(6).Value = HttpContext.Current.Session("UserName")
        param(7) = New SqlParameter("@subjectid", SqlDbType.VarChar, subjectid.Length)
        param(7).Value = subjectid
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Addsubjectoption", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return Nothing
    End Function
End Class
