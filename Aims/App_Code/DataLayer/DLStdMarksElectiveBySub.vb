Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLStdMarksElectiveBySub
    Shared Function InsertStdMarks(ByVal m As ELNewStdMarksBySub) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(13) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@A_Year", SqlDbType.Int)
        Parms(1).Value = m.A_Year

        Parms(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        Parms(2).Value = m.Batch

        Parms(3) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
        Parms(3).Value = m.Semester

        Parms(4) = New SqlParameter("@Subject", SqlDbType.Int)
        Parms(4).Value = m.Subject

        Parms(5) = New SqlParameter("@Assesment", SqlDbType.Int)
        Parms(5).Value = m.Assesment

        Parms(6) = New SqlParameter("@AssesmentDate", SqlDbType.Date)
        Parms(6).Value = m.AssesmentDate

        Parms(7) = New SqlParameter("@Max", SqlDbType.Float)
        Parms(7).Value = m.Max

        Parms(8) = New SqlParameter("@Min", SqlDbType.Float)
        Parms(8).Value = m.Min

        Parms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(9).Value = HttpContext.Current.Session("UserCode")

        Parms(10) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(10).Value = HttpContext.Current.Session("EmpCode")

        Parms(11) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(11).Value = HttpContext.Current.Session("Office")

        Parms(12) = New SqlParameter("@SubGrp", SqlDbType.Int)
        Parms(12).Value = m.SubGrp

        'Parms(13) = New SqlParameter("@Elective", SqlDbType.Int)
        'Parms(13).Value = m.Elective

        Parms(13) = New SqlParameter("@StdId", SqlDbType.Int)
        Parms(13).Value = m.StdId
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_InsertStudentMarksElectiveBySub", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    'Code By JINA --> Accessing Batch & SemId through SubjectId
    Public Function BatchAccess(ByVal El As ELNewStdMarksBySub) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@SubjectId", SqlDbType.Int)
        param(0).Value = El.Subject

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Branchcode")

        param(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_BatchAccessBySub1", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Function SemAccess(ByVal El As ELNewStdMarksBySub) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(3) {}
        param(0) = New SqlParameter("@BatchId", SqlDbType.VarChar, 50)
        param(0).Value = El.Batch

        param(1) = New SqlParameter("@SubjectId", SqlDbType.Int)
        param(1).Value = El.Subject

        param(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Branchcode")

        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SemAccessBySub", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Shared Function ViewStdMarks(ByVal m As ELNewStdMarksBySub) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(9) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@A_Year", SqlDbType.Int)
        Parms(1).Value = m.A_Year

        Parms(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        Parms(2).Value = m.Batch

        Parms(3) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
        Parms(3).Value = m.Semester

        Parms(4) = New SqlParameter("@Subject", SqlDbType.Int)
        Parms(4).Value = m.Subject

        Parms(5) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        Parms(5).Value = m.Assesment

        Parms(6) = New SqlParameter("@AssessmentDate", SqlDbType.Date)
        Parms(6).Value = m.AssesmentDate

        Parms(7) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        Parms(7).Value = HttpContext.Current.Session("Office")

        Parms(8) = New SqlParameter("@SubGrp", SqlDbType.Int)
        Parms(8).Value = m.SubGrp

        'Parms(9) = New SqlParameter("@Elective", SqlDbType.Int)
        'Parms(9).Value = m.Elective

        Parms(9) = New SqlParameter("@StdId", SqlDbType.Int)
        Parms(9).Value = m.StdId

        'Parms(8) = New SqlParameter("@Max", SqlDbType.Int)
        'Parms(8).Value = m.Max

        'Parms(9) = New SqlParameter("@Min", SqlDbType.Int)
        'Parms(9).Value = m.Min
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_ViewStudentMarksElectiveBySub", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function ViewStdMarksRpt(ByVal Ayaer As Integer, ByVal Batch As String, ByVal Semester As String, ByVal Subject As Integer, ByVal Assesment As Integer, ByVal AssesmentDate As Date, ByVal SubGrp As Integer, ByVal Stdid As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(9) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@A_Year", SqlDbType.Int)
        Parms(1).Value = Ayaer

        Parms(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        Parms(2).Value = Batch

        Parms(3) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
        Parms(3).Value = Semester

        Parms(4) = New SqlParameter("@Subject", SqlDbType.Int)
        Parms(4).Value = Subject

        Parms(5) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        Parms(5).Value = Assesment

        Parms(6) = New SqlParameter("@AssessmentDate", SqlDbType.Date)
        Parms(6).Value = AssesmentDate

        Parms(7) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        Parms(7).Value = HttpContext.Current.Session("Office")

        Parms(8) = New SqlParameter("@SubGrp", SqlDbType.Int)
        Parms(8).Value = SubGrp

        'Parms(9) = New SqlParameter("@Elective", SqlDbType.Int)
        'Parms(9).Value = m.Elective

        Parms(9) = New SqlParameter("@StdId", SqlDbType.Int)
        Parms(9).Value = Stdid

        'Parms(8) = New SqlParameter("@Max", SqlDbType.Int)
        'Parms(8).Value = m.Max

        'Parms(9) = New SqlParameter("@Min", SqlDbType.Int)
        'Parms(9).Value = m.Min
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_ViewStudentMarksElectiveBySub", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Duplicate(ByVal m As ELNewStdMarksBySub) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(9) {}
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

        Parms(5) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        Parms(5).Value = m.Assesment

        Parms(6) = New SqlParameter("@AssessmentDate", SqlDbType.Date)
        Parms(6).Value = m.AssesmentDate

        Parms(7) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        Parms(7).Value = HttpContext.Current.Session("Office")

        Parms(8) = New SqlParameter("@SubGrp", SqlDbType.Int)
        Parms(8).Value = m.SubGrp

        'Parms(9) = New SqlParameter("@Elective", SqlDbType.Int)
        'Parms(9).Value = m.Elective

        Parms(9) = New SqlParameter("@StdId", SqlDbType.Int)
        Parms(9).Value = m.StdId

        'Parms(8) = New SqlParameter("@Max", SqlDbType.Int)
        'Parms(8).Value = m.Max

        'Parms(9) = New SqlParameter("@Min", SqlDbType.Int)
        'Parms(9).Value = m.Min
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_ViewStudentMarksElectiveBySub", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function LockStdMarks(ByVal m As ELNewStdMarksBySub) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
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

        Parms(6) = New SqlParameter("@AssesmentDate", SqlDbType.Date)
        Parms(6).Value = m.AssesmentDate

        Parms(7) = New SqlParameter("@SubGrp", SqlDbType.Int)
        Parms(7).Value = m.SubGrp

        'Parms(8) = New SqlParameter("@Elective", SqlDbType.Int)
        'Parms(8).Value = m.Elective

        Parms(8) = New SqlParameter("@StdId", SqlDbType.Int)
        Parms(8).Value = m.StdId

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_LockMarksElectiveBySub", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal El As ELNewStdMarksBySub) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = El.id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_StdMarksBySub", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function UNLockStdMarks(ByVal m As ELNewStdMarksBySub) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
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

        Parms(6) = New SqlParameter("@AssesmentDate", SqlDbType.Date)
        Parms(6).Value = m.AssesmentDate

        Parms(7) = New SqlParameter("@SubGrp", SqlDbType.Int)
        Parms(7).Value = m.SubGrp

        'Parms(8) = New SqlParameter("@Elective", SqlDbType.Int)
        'Parms(8).Value = m.Elective

        Parms(8) = New SqlParameter("@StdId", SqlDbType.Int)
        Parms(8).Value = m.StdId

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UNLockMarksElectivesBySub", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ClearMarks(ByVal m As ELNewStdMarksBySub) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(8) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@A_Year", SqlDbType.Int)
        Parms(1).Value = m.A_Year

        Parms(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        Parms(2).Value = m.Batch

        Parms(3) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
        Parms(3).Value = m.Semester

        Parms(4) = New SqlParameter("@Subject", SqlDbType.Int)
        Parms(4).Value = m.Subject

        Parms(5) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        Parms(5).Value = m.Assesment

        Parms(6) = New SqlParameter("@AssesmentDate", SqlDbType.Date)
        Parms(6).Value = m.AssesmentDate

        Parms(7) = New SqlParameter("@SubGrp", SqlDbType.Int)
        Parms(7).Value = m.SubGrp

        'Parms(8) = New SqlParameter("@Elective", SqlDbType.Int)
        'Parms(8).Value = m.Elective

        Parms(8) = New SqlParameter("@StdId", SqlDbType.Int)
        Parms(8).Value = m.StdId

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_ClearMarksElectivesBySub", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UpdateMarks(ByVal m As ELNewStdMarksBySub) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(11) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@A_Marks", SqlDbType.Float)
        Parms(1).Value = m.A_Marks

        Parms(2) = New SqlParameter("@Grade", SqlDbType.NVarChar, 50)
        Parms(2).Value = m.Grade

        Parms(3) = New SqlParameter("@Percent", SqlDbType.Float)
        Parms(3).Value = m.Percent

        Parms(4) = New SqlParameter("@id", SqlDbType.Int)
        Parms(4).Value = m.id

        Parms(5) = New SqlParameter("@MaxMarks", SqlDbType.Float)
        Parms(5).Value = m.Max

        Parms(6) = New SqlParameter("@MinMarks", SqlDbType.Float)
        Parms(6).Value = m.Min

        Parms(7) = New SqlParameter("@Remarks", SqlDbType.NVarChar, 255)
        Parms(7).Value = m.Remarks

        Parms(8) = New SqlParameter("@batch", SqlDbType.VarChar, 50)
        Parms(8).Value = m.Batch

        If m.Pass_Fail = Nothing Then
            Parms(9) = New SqlParameter("@Pass_Fail", SqlDbType.NVarChar, 20)
            Parms(9).Value = System.DBNull.Value
        Else
            Parms(9) = New SqlParameter("@Pass_Fail", SqlDbType.NVarChar, 20)
            Parms(9).Value = m.Pass_Fail
        End If
        Parms(10) = New SqlParameter("@ExamAttendance", SqlDbType.Int)
        Parms(10).Value = m.ExamAttendance

        Parms(11) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(11).Value = HttpContext.Current.Session("EmpCode")



        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdateMarksBySub", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UpdateMarksFromGrade(ByVal m As ELNewStdMarksBySub) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(11) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@A_Marks", SqlDbType.Float)
        Parms(1).Value = m.A_Marks

        Parms(2) = New SqlParameter("@Grade", SqlDbType.NVarChar, 50)
        Parms(2).Value = m.Grade

        Parms(3) = New SqlParameter("@Percent", SqlDbType.Float)
        Parms(3).Value = m.Percent

        Parms(4) = New SqlParameter("@id", SqlDbType.Int)
        Parms(4).Value = m.id

        Parms(5) = New SqlParameter("@MaxMarks", SqlDbType.Float)
        Parms(5).Value = m.Max

        Parms(6) = New SqlParameter("@MinMarks", SqlDbType.Float)
        Parms(6).Value = m.Min

        Parms(7) = New SqlParameter("@Remarks", SqlDbType.NVarChar, 255)
        Parms(7).Value = m.Remarks

        Parms(8) = New SqlParameter("@batch", SqlDbType.Int)
        Parms(8).Value = m.Batch
        If m.Pass_Fail = Nothing Then
            Parms(9) = New SqlParameter("@Pass_Fail", SqlDbType.NVarChar, 20)
            Parms(9).Value = System.DBNull.Value
        Else
            Parms(9) = New SqlParameter("@Pass_Fail", SqlDbType.NVarChar, 20)
            Parms(9).Value = m.Pass_Fail
        End If

        Parms(10) = New SqlParameter("@ExamAttendance", SqlDbType.Int)
        Parms(10).Value = m.ExamAttendance

        Parms(11) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(11).Value = HttpContext.Current.Session("EmpCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdateMarksFromGradeMasterBySub", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function CheckLockMarks(ByVal m As ELNewStdMarksBySub) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(9) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@A_Year", SqlDbType.Int)
        Parms(1).Value = m.A_Year

        Parms(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        Parms(2).Value = m.Batch

        Parms(3) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
        Parms(3).Value = m.Semester

        Parms(4) = New SqlParameter("@Subject", SqlDbType.Int)
        Parms(4).Value = m.Subject

        Parms(5) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        Parms(5).Value = m.Assesment


        Parms(6) = New SqlParameter("@AssesmentDate", SqlDbType.Date)
        Parms(6).Value = m.AssesmentDate

        Parms(7) = New SqlParameter("@SubGrp", SqlDbType.Int)
        Parms(7).Value = m.SubGrp

        'Parms(8) = New SqlParameter("@Elective", SqlDbType.Int)
        'Parms(8).Value = m.Elective

        Parms(8) = New SqlParameter("@StdId", SqlDbType.Int)
        Parms(8).Value = m.StdId

        Parms(9) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(9).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_CheckLockMarksElectivesBySub", Parms)
            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function ExamAttendance() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter() {}

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_ddlExamAttendBySub", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function ViewDataStatus(ByVal Batch As Integer, ByVal Semester As Integer, ByVal Subject As Integer) As Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(1).Value = Batch

            Parms(2) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(2).Value = Semester

            Parms(3) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(3).Value = Subject



            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_ViewMarksDataEntryStatus]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
