Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLNew_StudentMarks
    Shared Function GetAcademicCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectAcademicYear", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetAcademicComboAll() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectAcademicYearAll", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'By Jina
    Shared Function GetAcademicComboBySub() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectAcademicYearBySub", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetAcademicCombo1() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectAcademicYear1", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetAssesmentTypeWitDateCombo(ByVal Batch As Integer, ByVal Semester As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = Batch

            Parms(3) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(3).Value = Semester

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_SelectAssesmentType]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectComboBatchPlanner5(ByVal Batchid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            Parms(2).Value = Batchid

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubjectForBest", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetAssesmentComboAll() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectAssesmentAll", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBatch(ByVal a As NewStdMarks) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(4) {}
        param(0) = New SqlParameter("@A_Year", SqlDbType.Int)
        param(0).Value = a.A_Year
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = a.Batch
        param(3) = New SqlParameter("@Semester", SqlDbType.Int)
        param(3).Value = a.Semester
        param(4) = New SqlParameter("@Subject", SqlDbType.Int)
        param(4).Value = a.Subject
        'param(5) = New SqlParameter("@ClassType", SqlDbType.Int)
        'param(5).Value = a.ClassType
        'param(5) = New SqlParameter("@ElecSub", SqlDbType.Int)
        'param(5).Value = a.ElecSub
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetBatchStatus", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Code By Jina
    Shared Function GetBatchBySub(ByVal a As ELNewStdMarksBySub) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(4) {}
        param(0) = New SqlParameter("@A_Year", SqlDbType.Int)
        param(0).Value = a.A_Year
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = a.Batch
        param(3) = New SqlParameter("@Semester", SqlDbType.Int)
        param(3).Value = a.Semester
        param(4) = New SqlParameter("@Subject", SqlDbType.Int)
        param(4).Value = a.Subject
        'param(5) = New SqlParameter("@ClassType", SqlDbType.Int)
        'param(5).Value = a.ClassType
        'param(5) = New SqlParameter("@ElecSub", SqlDbType.Int)
        'param(5).Value = a.ElecSub
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetBatchStatus1", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetAcademicCombo(ByVal Branchcode As String) As DataTable
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

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectAcademicYear", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetCurrentAcademicCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAcademicCurrentYear", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBatchCombo(ByVal A_Year As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
            Parms(2).Value = A_Year
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DDLOpenBatchesOnStatus", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBatchComboFee(ByVal A_Year As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
            Parms(2).Value = A_Year
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DDLOpenBatchesOnStatusFee", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBatchCombo1(ByVal A_Year As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
            Parms(2).Value = A_Year
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DDLOpenBatchesOnStatusnew", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetOpenBatchCombo(ByVal A_Year As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
            Parms(2).Value = A_Year
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectopenBatch", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetOpenBatchCombo1() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            'Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
            'Parms(2).Value = A_Year
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectopenBatch1", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetBatchCombo(ByVal A_Year As Integer, ByVal Course As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
            Parms(2).Value = A_Year

            Parms(3) = New SqlParameter("@Course", SqlDbType.Int)
            Parms(3).Value = Course
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectBatchReg", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBatchCombo2() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectBatchComboCompletion", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBatch() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectBatchForSTD", Parms)
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

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSemester", Parms)
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

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubjectFromBatchBlanner", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectComboBatchPlannerNoSub(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
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

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubjectFromBatchBlannerNoSub", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    'Code By Jina
    'Shared Function GetSubComboBatchPlanner(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
    Shared Function GetSubComboBatchPlanner() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            'Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            'Parms(2).Value = Batchid

            'Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            'Parms(3).Value = SemId

            Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("EmpID")

            Parms(3) = New SqlParameter("@UserRole", SqlDbType.VarChar, 50)
            Parms(3).Value = HttpContext.Current.Session("UserRole")

            Parms(4) = New SqlParameter("@DeptId", SqlDbType.Int)
            Parms(4).Value = HttpContext.Current.Session("DeptId")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubjFromBatchBlanner", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    'Code By Jina
    'To Retreive Subjects from Subject Master Without Batch Planner
    Shared Function GetSubCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_GetSubCombo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    'Code By Jina
    'Shared Function GetSubComboBatchPlanner1(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable

    Shared Function GetSubComboBatchPlanner1() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            'Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            'Parms(2).Value = Batchid

            'Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            'Parms(3).Value = SemId

            Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("EmpID")

            Parms(3) = New SqlParameter("@UserRole", SqlDbType.VarChar, 50)
            Parms(3).Value = HttpContext.Current.Session("UserRole")

            Parms(4) = New SqlParameter("@DeptId", SqlDbType.Int)
            Parms(4).Value = HttpContext.Current.Session("DeptId")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubjFromBatchBlanner1", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetSubjectAllComboBatchPlanner(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
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

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_AllSubjectFromBatchBlanner", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectGridFinalResult(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

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

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubjectForFinalResult", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectComboBatchPlanner2(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            Parms(2).Value = Batchid

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = SemId


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubject2", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectComboBatchPlanner1(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubjectFromBatchBlanner1", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectCombo(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            Parms(2).Value = Batchid

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = SemId
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubject", Parms)
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

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectAssesment", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetAssesmentComboSelect(ByVal Asse As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Assessment", SqlDbType.VarChar, 100)
            Parms(2).Value = Asse

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectAssesmentFromGrid", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'Code By Jina
    Shared Function GetAssesmentComboBySub() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectAssesmentBySub", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetClassCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectClassType", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function InsertStdMarks(ByVal m As NewStdMarks) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(12) {}
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

        Parms(6) = New SqlParameter("@ClassType", SqlDbType.Int)
        Parms(6).Value = m.ClassType

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
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_InsertStudentMarks", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ViewStdMarks(ByVal m As NewStdMarks) As Data.DataTable
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

        Parms(5) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        Parms(5).Value = m.Assesment

        Parms(6) = New SqlParameter("@ClassType", SqlDbType.Int)
        Parms(6).Value = m.ClassType

        Parms(7) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        Parms(7).Value = HttpContext.Current.Session("Office")

        Parms(8) = New SqlParameter("@SubGrp", SqlDbType.Int)
        Parms(8).Value = m.SubGrp

        'Parms(8) = New SqlParameter("@Max", SqlDbType.Int)
        'Parms(8).Value = m.Max

        'Parms(9) = New SqlParameter("@Min", SqlDbType.Int)
        'Parms(9).Value = m.Min
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_ViewStudentMarks", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function LockStdMarks(ByVal m As NewStdMarks) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(7) {}
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

        Parms(6) = New SqlParameter("@ClassType", SqlDbType.Int)
        Parms(6).Value = m.ClassType

        Parms(7) = New SqlParameter("@SubGrp", SqlDbType.Int)
        Parms(7).Value = m.SubGrp

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_LockMarks", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UNLockStdMarks(ByVal m As NewStdMarks) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(7) {}
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

        Parms(6) = New SqlParameter("@ClassType", SqlDbType.Int)
        Parms(6).Value = m.ClassType
        Parms(7) = New SqlParameter("@SubGrp", SqlDbType.Int)
        Parms(7).Value = m.SubGrp

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UNLockMarks", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ClearMarks(ByVal m As NewStdMarks) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(7) {}
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

        Parms(6) = New SqlParameter("@SubGrp", SqlDbType.Int)
        Parms(6).Value = m.SubGrp

        Parms(7) = New SqlParameter("@ClassType", SqlDbType.Int)
        Parms(7).Value = m.ClassType

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_ClearMarks", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UpdateMarks(ByVal m As NewStdMarks) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(9) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@A_Marks", SqlDbType.Float)
        Parms(1).Value = m.A_Marks

        Parms(2) = New SqlParameter("@Grade", SqlDbType.VarChar, 50)
        Parms(2).Value = m.Grade

        Parms(3) = New SqlParameter("@Percent", SqlDbType.Float)
        Parms(3).Value = m.Percent

        Parms(4) = New SqlParameter("@id", SqlDbType.Int)
        Parms(4).Value = m.id

        Parms(5) = New SqlParameter("@MaxMarks", SqlDbType.Float)
        Parms(5).Value = m.Max

        Parms(6) = New SqlParameter("@MinMarks", SqlDbType.Float)
        Parms(6).Value = m.Min

        Parms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 255)
        Parms(7).Value = m.Remarks

        Parms(8) = New SqlParameter("@batch", SqlDbType.Int)
        Parms(8).Value = m.Batch
        If m.Pass_Fail = Nothing Then
            Parms(9) = New SqlParameter("@Pass_Fail", SqlDbType.VarChar, 20)
            Parms(9).Value = System.DBNull.Value
        Else
            Parms(9) = New SqlParameter("@Pass_Fail", SqlDbType.VarChar, 20)
            Parms(9).Value = m.Pass_Fail
        End If



        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdateMarks", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UpdateMarksFromGrade(ByVal m As NewStdMarks) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(9) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@A_Marks", SqlDbType.Float)
        Parms(1).Value = m.A_Marks

        Parms(2) = New SqlParameter("@Grade", SqlDbType.VarChar, 50)
        Parms(2).Value = m.Grade

        Parms(3) = New SqlParameter("@Percent", SqlDbType.Float)
        Parms(3).Value = m.Percent

        Parms(4) = New SqlParameter("@id", SqlDbType.Int)
        Parms(4).Value = m.id

        Parms(5) = New SqlParameter("@MaxMarks", SqlDbType.Float)
        Parms(5).Value = m.Max

        Parms(6) = New SqlParameter("@MinMarks", SqlDbType.Float)
        Parms(6).Value = m.Min

        Parms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 255)
        Parms(7).Value = m.Remarks

        Parms(8) = New SqlParameter("@batch", SqlDbType.Int)
        Parms(8).Value = m.Batch
        If m.Pass_Fail = Nothing Then
            Parms(9) = New SqlParameter("@Pass_Fail", SqlDbType.VarChar, 20)
            Parms(9).Value = System.DBNull.Value
        Else
            Parms(9) = New SqlParameter("@Pass_Fail", SqlDbType.VarChar, 20)
            Parms(9).Value = m.Pass_Fail
        End If



        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdateMarksFromGradeMaster1", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function CheckLockMarks(ByVal m As NewStdMarks) As DataSet
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

        Parms(5) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        Parms(5).Value = m.Assesment

        Parms(6) = New SqlParameter("@ClassType", SqlDbType.Int)
        Parms(6).Value = m.ClassType

        Parms(7) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(7).Value = HttpContext.Current.Session("Office")

        Parms(8) = New SqlParameter("@SubGrp", SqlDbType.Int)
        Parms(8).Value = m.SubGrp
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_CheckLockMarks", Parms)
            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBatchComboB(ByVal A_Year As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
            Parms(2).Value = A_Year
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ElectBatchSemesterMap", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function PostCheck(ByVal role As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(0).Value = role
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetUnlockStdMarks", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetOpenBatchCombo1(ByVal BranchCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            'Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
            'Parms(2).Value = A_Year
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectopenBatch", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'Code By Jina 
    Shared Function PostCheckBySub(ByVal role As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(0).Value = role
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetUnlockStdMarksBySub", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    'By Jina
    Shared Function GetAcademicComboBySub1() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectAcademicYearBySub1", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'Code By Jina
    Shared Function GetClassComboBySub() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectClassTypeBySub", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetAcademicComboGvsSub(ByVal Branchcode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectAcademicYearGvsSub", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetAssesmentComboAllGvsSub() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectAssesmentGvsSub", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
