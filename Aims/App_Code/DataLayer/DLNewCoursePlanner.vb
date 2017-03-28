Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLNewCoursePlanner
    Shared Function InsertCoursePlanner(ByVal m As NewCoursePlanner) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(8) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@CourseCode", SqlDbType.Int)
        Parms(1).Value = m.Course

        Parms(2) = New SqlParameter("@PrincipalSubject", SqlDbType.Int)
        Parms(2).Value = m.PrincipalSubject

        Parms(3) = New SqlParameter("@SubjectCategory", SqlDbType.Int)
        Parms(3).Value = m.SubjectCategory

        Parms(4) = New SqlParameter("@SemCode", SqlDbType.Int)
        Parms(4).Value = m.Semester

        Parms(5) = New SqlParameter("@SubjectCode", SqlDbType.Int)
        Parms(5).Value = m.subject

        Parms(6) = New SqlParameter("@TheoryHours", SqlDbType.Float)
        Parms(6).Value = m.theory

        Parms(7) = New SqlParameter("@Credit", SqlDbType.Float)
        Parms(7).Value = m.Credit

        Parms(8) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(8).Value = HttpContext.Current.Session("EmpCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_InsertCoursePlanner", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UpdateCoursePlanner(ByVal m As NewCoursePlanner) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(9) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@CourseCode", SqlDbType.Int)
        Parms(1).Value = m.Course

        Parms(2) = New SqlParameter("@PrincipalSubject", SqlDbType.Int)
        Parms(2).Value = m.PrincipalSubject

        Parms(3) = New SqlParameter("@SubjectCategory", SqlDbType.Int)
        Parms(3).Value = m.SubjectCategory

        Parms(4) = New SqlParameter("@Semester", SqlDbType.Int)
        Parms(4).Value = m.Semester

        Parms(5) = New SqlParameter("@subject", SqlDbType.Int)
        Parms(5).Value = m.subject

        Parms(6) = New SqlParameter("@theory", SqlDbType.NVarChar, 50)
        Parms(6).Value = m.theory

        Parms(7) = New SqlParameter("@id", SqlDbType.Int)
        Parms(7).Value = m.id

        Parms(8) = New SqlParameter("@Credit", SqlDbType.Float)
        Parms(8).Value = m.Credit

        Parms(9) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(9).Value = HttpContext.Current.Session("EmpCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdateCoursePlanner", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function DeleteCoursePlanner(ByVal m As NewCoursePlanner) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}
        Parms(0) = New SqlParameter("@id", SqlDbType.Int)
        Parms(0).Value = m.id
        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_DeleteCoursePlanner", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function
    Shared Function GetCoursePlanner(ByVal p As Integer, ByVal c As Integer, ByVal s As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@ID", SqlDbType.Int)
            Parms(0).Value = p

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(2).Value = HttpContext.Current.Session("Office")

            Parms(3) = New SqlParameter("@Course", SqlDbType.Int)
            Parms(3).Value = c

            Parms(4) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(4).Value = s
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectCoursePlanner", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function DuplicateCoursePlanner(ByVal id As Integer, ByVal c As Integer, ByVal sem As Integer, ByVal subj As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(5) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Course", SqlDbType.Int)
            Parms(2).Value = c

            Parms(3) = New SqlParameter("@Sem", SqlDbType.Int)
            Parms(3).Value = sem

            Parms(4) = New SqlParameter("@sub", SqlDbType.Int)
            Parms(4).Value = subj

            Parms(5) = New SqlParameter("@ID", SqlDbType.Int)
            Parms(5).Value = id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_DuplicateCoursePlanner", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCourseCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_CourseCombo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCourseCombo1() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_CourseComboforLessionPlan", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCourseComboAdmission(ByVal Branchcode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            If Branchcode = "0" Then
                Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
                Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Else
                Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
                Parms(0).Value = Branchcode
            End If

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_CourseComboAdmissionRpt", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCourseComboAdmission() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_CourseComboAdmission", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SubjectCombo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectComboByPrinci(ByVal PrincipalSubject As Integer, ByVal SubjectCategory As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@PrincipalSubject", SqlDbType.Int)
            Parms(2).Value = PrincipalSubject

            Parms(3) = New SqlParameter("@SubjectCategory", SqlDbType.Int)
            Parms(3).Value = SubjectCategory

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SubjectComboByPrinci", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectComboExam() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SubjectComboExam", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSemesterCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SemesterCombo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function SemComboBasedonBatch(ByVal BatchID As Int32) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = BatchID
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemesterddl", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetPrincipalSubject() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            arParms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPrincipalSubjectCombo", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            'MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetSubjectCategory() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            arParms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSubjectCategoryCombo", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            'MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCourseComboGvsSub(ByVal Branchcode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_CourseComboGvsSub", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
