Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLStudentMarksForFailed
    Shared Function getBatchPlanner() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("EmpID")

            Parms(3) = New SqlParameter("@UserRole", SqlDbType.VarChar, 50)
            Parms(3).Value = HttpContext.Current.Session("UserRole")

            Parms(4) = New SqlParameter("@DeptId", SqlDbType.Int)
            Parms(4).Value = HttpContext.Current.Session("DeptId")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getBatchPlanner", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function SemesterCombo(ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        If HttpContext.Current.Session("LoginType") = "Others" Then
            param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            param(2).Value = HttpContext.Current.Session("BatchID")
        Else
            param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            param(2).Value = batch
        End If
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester1", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetAssesmentCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectAssesmentDet", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function ViewStdMarks(ByVal m As ELStudentMarksForFailed) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(7) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
        Parms(1).Value = m.Batch

        Parms(2) = New SqlParameter("@Semester", SqlDbType.Int)
        Parms(2).Value = m.Semester

        Parms(3) = New SqlParameter("@Subject", SqlDbType.Int)
        Parms(3).Value = m.Subject

        Parms(4) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        Parms(4).Value = m.Assesment

        Parms(5) = New SqlParameter("@AssessmentDate", SqlDbType.DateTime)
        Parms(5).Value = m.AssesmentDate

        Parms(6) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Parms(6).Value = HttpContext.Current.Session("Office")

        Parms(7) = New SqlParameter("@Min", SqlDbType.Int)
        Parms(7).Value = m.Min
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_ViewStudentMarksForFailed", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetSubjectComboBatchPlanner(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(6) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            Parms(2).Value = Batchid

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = SemId

            Parms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(4).Value = HttpContext.Current.Session("EmpID")

            Parms(5) = New SqlParameter("@UserRole", SqlDbType.VarChar, 50)
            Parms(5).Value = HttpContext.Current.Session("UserRole")

            Parms(6) = New SqlParameter("@DeptId", SqlDbType.Int)
            Parms(6).Value = HttpContext.Current.Session("DeptId")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubjectPlan", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function UpdateStdMarks(ByVal m As ELStudentMarksForFailed) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(14) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@A_Year", SqlDbType.Int)
        Parms(1).Value = m.A_Year

        Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        Parms(2).Value = m.Batch

        Parms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        Parms(3).Value = m.Semester

        Parms(4) = New SqlParameter("@Subject", SqlDbType.Int)
        Parms(4).Value = m.Subject

        Parms(5) = New SqlParameter("@Assesment", SqlDbType.Int)
        Parms(5).Value = m.Assesment

        Parms(6) = New SqlParameter("@AssesmentDate", SqlDbType.DateTime)
        Parms(6).Value = m.AssesmentDate

        Parms(7) = New SqlParameter("@Max", SqlDbType.Float)
        Parms(7).Value = m.Max1

        Parms(8) = New SqlParameter("@Min", SqlDbType.Float)
        Parms(8).Value = m.Min1

        Parms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(9).Value = HttpContext.Current.Session("UserCode")

        Parms(10) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(10).Value = HttpContext.Current.Session("EmpCode")

        Parms(11) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(11).Value = HttpContext.Current.Session("Office")

        Parms(12) = New SqlParameter("@A_Marks", SqlDbType.Float)
        Parms(12).Value = m.A_Marks

        'Parms(13) = New SqlParameter("@Elective", SqlDbType.Int)
        'Parms(13).Value = m.Elective

        Parms(13) = New SqlParameter("@StdId", SqlDbType.Int)
        Parms(13).Value = m.StdId

        Parms(14) = New SqlParameter("@ExamAttend", SqlDbType.Int)
        Parms(14).Value = m.ExamAttend
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Update_InsertStudentMarks", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function


    Shared Function CheckDuplicateaData(ByVal m As ELStudentMarksForFailed) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(8) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@A_Year", SqlDbType.Int)
        Parms(1).Value = m.A_Year

        Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        Parms(2).Value = m.Batch

        Parms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        Parms(3).Value = m.Semester

        Parms(4) = New SqlParameter("@Subject", SqlDbType.Int)
        Parms(4).Value = m.Subject

        Parms(5) = New SqlParameter("@Assesment", SqlDbType.Int)
        Parms(5).Value = m.Assesment

        Parms(6) = New SqlParameter("@AssesmentDate", SqlDbType.DateTime)
        Parms(6).Value = m.AssesmentDate

        Parms(7) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(7).Value = HttpContext.Current.Session("Office")

        Parms(8) = New SqlParameter("@StdId", SqlDbType.Int)
        Parms(8).Value = m.StdId
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CheckDuplicate_StudentMarks", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function


    Shared Function GetStudentDtls(ByVal EL As ELStudentMarksForFailed) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = EL.id
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStudDetails", arParms)
        Return ds.Tables(0)
    End Function
End Class
