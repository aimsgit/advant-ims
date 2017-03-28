Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLAssesmentResult
    Shared Function GetGridData1(ByVal batchId As Integer, ByVal sem As Integer, ByVal Subject As Integer, ByVal Asses As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(2).Value = batchId

        arParms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(3).Value = sem

        arParms(4) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(4).Value = Subject

        arParms(5) = New SqlParameter("@AssesmentTypeID", SqlDbType.VarChar, 80)
        arParms(5).Value = Asses


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBatchAssesmentResult", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CountAssessment(ByVal batchId As Integer, ByVal sem As Integer, ByVal Asses As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(2).Value = batchId

        arParms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(3).Value = sem

        arParms(4) = New SqlParameter("@AssesmentTypeID", SqlDbType.VarChar, 80)
        arParms(4).Value = Asses


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_TotalAssessmentcount", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetAss(ByVal id As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@AssesmentTypeID", SqlDbType.VarChar, 80)
        arParms(2).Value = id

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_TotAsses", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetGridData(ByVal batchId As Integer, ByVal sem As Integer, ByVal Subject As Integer, ByVal Asses As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(2).Value = batchId

        arParms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(3).Value = sem

        arParms(4) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(4).Value = Subject

        arParms(5) = New SqlParameter("@AssesmentTypeID", SqlDbType.NVarChar, 80)
        arParms(5).Value = Asses


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBatchAssesmentResult1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function BEstOF(ByVal p1 As Double, ByVal p2 As Double, ByVal p3 As Double, ByVal p4 As Double, ByVal p5 As Double, ByVal p6 As Double, ByVal p7 As Double, ByVal p8 As Double, ByVal p9 As Double, ByVal BestOfM As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(11) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@P1", SqlDbType.Float)
        arParms(2).Value = p1

        arParms(3) = New SqlParameter("@P2", SqlDbType.Float)
        arParms(3).Value = p2

        arParms(4) = New SqlParameter("@P3", SqlDbType.Float)
        arParms(4).Value = p3


        arParms(5) = New SqlParameter("@P4", SqlDbType.Float)
        arParms(5).Value = p4

        arParms(6) = New SqlParameter("@P5", SqlDbType.Float)
        arParms(6).Value = p5

        arParms(7) = New SqlParameter("@P6", SqlDbType.Float)
        arParms(7).Value = p6

        arParms(8) = New SqlParameter("@P7", SqlDbType.Float)
        arParms(8).Value = p7

        arParms(9) = New SqlParameter("@P8", SqlDbType.Float)
        arParms(9).Value = p8

        arParms(10) = New SqlParameter("@P9", SqlDbType.Float)
        arParms(10).Value = p9

        arParms(11) = New SqlParameter("@BestOf", SqlDbType.Int)
        arParms(11).Value = BestOfM

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetTotal", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal EL As ELAssesmentResult) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(14) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@A_Year", SqlDbType.Int)
        Parms(1).Value = EL.Academicyr

        Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        Parms(2).Value = EL.batchId

        Parms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        Parms(3).Value = EL.sem1

        Parms(4) = New SqlParameter("@Subject", SqlDbType.Int)
        Parms(4).Value = EL.Subject

        Parms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(5).Value = HttpContext.Current.Session("EmpCode")

        Parms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(6).Value = HttpContext.Current.Session("UserCode")

        Parms(7) = New SqlParameter("@Assesment", SqlDbType.Int)
        Parms(7).Value = EL.Asses
        If EL.TotalMarks = 0 Then
            Parms(8) = New SqlParameter("@TotalMarks", SqlDbType.Float)
            Parms(8).Value = DBNull.Value
        Else
            Parms(8) = New SqlParameter("@TotalMarks", SqlDbType.Float)
            Parms(8).Value = EL.TotalMarks
        End If
        Parms(9) = New SqlParameter("@StdId", SqlDbType.NVarChar, 50)
        Parms(9).Value = EL.Stdid

        Parms(10) = New SqlParameter("@Grade", SqlDbType.NVarChar, 50)
        Parms(10).Value = EL.Grade

        If EL.TotalMarksPer = 0 Then
            Parms(11) = New SqlParameter("@Percentage", SqlDbType.Float)
            Parms(11).Value = DBNull.Value
        Else
            Parms(11) = New SqlParameter("@Percentage", SqlDbType.Float)
            Parms(11).Value = EL.TotalMarksPer
        End If
        Parms(12) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(12).Value = HttpContext.Current.Session("Office")
        Parms(13) = New SqlParameter("@MaxMarks", SqlDbType.Float)
        Parms(13).Value = EL.MaxMarks

        Parms(14) = New SqlParameter("@MinMarks", SqlDbType.Float)
        Parms(14).Value = EL.MinMarks

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_BatchAssesmentResult", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UpdateGrade(ByVal El As ELAssesmentResult) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Percent", SqlDbType.Float)
        Parms(1).Value = El.TotalMarksPer

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_UpdateGrade", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Duplicate(ByVal El As ELAssesmentResult) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(5) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@A_Year", SqlDbType.Int)
        Parms(1).Value = El.Academicyr

        Parms(2) = New SqlParameter("@Batch", SqlDbType.NVarChar, 50)
        Parms(2).Value = El.batchId

        Parms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        Parms(3).Value = El.sem1

        Parms(4) = New SqlParameter("@Subject", SqlDbType.Int)
        Parms(4).Value = El.Subject

        Parms(5) = New SqlParameter("@Assesment", SqlDbType.Int)
        Parms(5).Value = El.Asses

    
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DulpicateAssesmentResult", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetMarks(ByVal El As ELAssesmentResult) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(5) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Assessment", SqlDbType.Int)
        Parms(1).Value = El.AssesmentId

        Parms(2) = New SqlParameter("@StdId", SqlDbType.NVarChar, 50)
        Parms(2).Value = El.id

        Parms(3) = New SqlParameter("@BatchId", SqlDbType.Int)
        Parms(3).Value = El.batchId

        Parms(4) = New SqlParameter("@Subject", SqlDbType.Int)
        Parms(4).Value = El.Subject

        Parms(5) = New SqlParameter("@Semester", SqlDbType.Int)
        Parms(5).Value = El.sem


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMarksfill", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function AcademicYear(ByVal El As ELAssesmentResult) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(3) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        Parms(1).Value = El.batchId

        Parms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("Office")

        Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
        Parms(3).Value = El.sem

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_AcademicYearId", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function UpdateMarks(ByVal EL As ELAssesmentResult) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(11) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@A_Marks", SqlDbType.Float)
        Parms(1).Value = EL.TotalMarks

        Parms(2) = New SqlParameter("@Grade", SqlDbType.NVarChar, 50)
        Parms(2).Value = EL.Grade

        Parms(4) = New SqlParameter("@batch", SqlDbType.Int)
        Parms(4).Value = EL.batchId

        Parms(5) = New SqlParameter("@Semester", SqlDbType.Int)
        Parms(5).Value = EL.sem

        Parms(6) = New SqlParameter("@Assessment", SqlDbType.Int)
        Parms(6).Value = EL.Asses

        Parms(7) = New SqlParameter("@StdId", SqlDbType.Int)
        Parms(7).Value = EL.Stdid

        Parms(8) = New SqlParameter("@Subject", SqlDbType.Int)
        Parms(8).Value = EL.Subject

        Parms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(9).Value = HttpContext.Current.Session("UserCode")

        Parms(10) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(10).Value = HttpContext.Current.Session("EmpCode")

        Parms(11) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(11).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdateMarks", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function SemesterComboD1(ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemesterComboAll", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
