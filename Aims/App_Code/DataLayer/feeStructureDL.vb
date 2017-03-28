Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class feeStructureDL
    Public Function getBatch(ByVal aid As Integer) As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@aid", SqlDbType.Int)
        arParms(2).Value = aid
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Getbatch_new", arParms)

            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function getCategory() As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetCategory_new", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Insert(ByVal f As feeStructureE) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@batchID", SqlDbType.Int)
        arParms(0).Value = f.batchID

        arParms(1) = New SqlParameter("@academicYearid", SqlDbType.Int)
        arParms(1).Value = f.AcademicYear_id

        arParms(2) = New SqlParameter("@semesterID", SqlDbType.Int)
        arParms(2).Value = f.Semester_ID

        arParms(3) = New SqlParameter("@categoryID", SqlDbType.Int)
        arParms(3).Value = f.CategoryID

        arParms(4) = New SqlParameter("@feeheadID", SqlDbType.Int)
        arParms(4).Value = f.Feehead_ID

        arParms(5) = New SqlParameter("@feeamt", SqlDbType.Int)
        arParms(5).Value = f.Amount

        arParms(6) = New SqlParameter("@DueDate", SqlDbType.DateTime)
        arParms(6).Value = f.DueDate

        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")

        arParms(8) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("EmpCode")

        arParms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("UserCode")



        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertFeeStructure", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal f As feeStructureE) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = f.id

        arParms(1) = New SqlParameter("@batchID", SqlDbType.Int)
        arParms(1).Value = f.batchID

        arParms(2) = New SqlParameter("@academicYearid", SqlDbType.Int)
        arParms(2).Value = f.AcademicYear_id

        arParms(3) = New SqlParameter("@semesterID", SqlDbType.Int)
        arParms(3).Value = f.Semester_ID

        arParms(4) = New SqlParameter("@categoryID", SqlDbType.Int)
        arParms(4).Value = f.CategoryID

        arParms(5) = New SqlParameter("@feeheadID", SqlDbType.Int)
        arParms(5).Value = f.Feehead_ID

        arParms(6) = New SqlParameter("@feeamt", SqlDbType.Int)
        arParms(6).Value = f.Amount

        arParms(7) = New SqlParameter("@DueDate", SqlDbType.DateTime)
        arParms(7).Value = f.DueDate


        arParms(8) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("EmpCode")

        arParms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("UserCode")

        arParms(10) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("BranchCode")





        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateFeeStructure", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function GetRecord(ByVal feeStructureE As feeStructureE) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(6) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@id", SqlDbType.VarChar, 50)
        para(2).Value = feeStructureE.id

        para(3) = New SqlParameter("@Ayear", SqlDbType.VarChar, 50)
        para(3).Value = feeStructureE.AcademicYear_id

        para(4) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        para(4).Value = feeStructureE.batchID

        para(5) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
        para(5).Value = feeStructureE.Semester_ID

        para(6) = New SqlParameter("@StdCategory", SqlDbType.VarChar, 50)
        para(6).Value = feeStructureE.CategoryID
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetFeeStructure", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function batchList(ByVal feeStructureE As feeStructureE) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@Ayear", SqlDbType.VarChar, 50)
        para(2).Value = feeStructureE.AYearid

        para(3) = New SqlParameter("@CourseType", SqlDbType.VarChar, 50)
        para(3).Value = feeStructureE.CourseTypeid

        para(4) = New SqlParameter("@Course", SqlDbType.VarChar, 50)
        para(4).Value = feeStructureE.Course

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetFeeStructureNewGrid", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetRecordNew(ByVal feeStructureE As feeStructureE) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(5) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@Ayear", SqlDbType.VarChar, 50)
        para(2).Value = feeStructureE.AcademicYear_id

        para(3) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        para(3).Value = feeStructureE.batchID

        para(4) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
        para(4).Value = feeStructureE.Semester_ID

        para(5) = New SqlParameter("@StdCategory", SqlDbType.VarChar, 50)
        para(5).Value = feeStructureE.CategoryID
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetFeeStructureNew", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBatchComboFee(ByVal feeStructureE As feeStructureE) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Ayear", SqlDbType.VarChar, 50)
            Parms(2).Value = feeStructureE.AYearid

            Parms(3) = New SqlParameter("@CourseType", SqlDbType.VarChar, 50)
            Parms(3).Value = feeStructureE.CourseTypeid

            Parms(4) = New SqlParameter("@Course", SqlDbType.VarChar, 50)
            Parms(4).Value = feeStructureE.Course

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DDLOpenBatchesOnStatusFee", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCategoryGrid(ByVal feeStructureE As feeStructureE) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(5) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@Ayear", SqlDbType.VarChar, 50)
        para(2).Value = feeStructureE.AcademicYear_id

        para(3) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        para(3).Value = feeStructureE.batchID

        para(4) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
        para(4).Value = feeStructureE.Semester_ID

        para(5) = New SqlParameter("@StdCategory", SqlDbType.VarChar, 50)
        para(5).Value = feeStructureE.CategoryID
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetCategoryGrid", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function DeleteRecord(ByVal id As Long) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@Fee_Structure_ID", SqlDbType.Int)
        para(0).Value = id
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Proc_DeleteFeestructure", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function DeleteRecordNew(ByVal feeStructureE As feeStructureE) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(3) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@Ayear", SqlDbType.VarChar, 50)
        para(2).Value = feeStructureE.AYearid

        para(3) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        para(3).Value = feeStructureE.batchNo
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Proc_DeleteFeestructureNew", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Public Function GVSemesterComboUser() As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_fee", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetFeeHeads() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@FHID", SqlDbType.Int)
        arParms(2).Value = 0
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetFeeHeads", arParms)

            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function getCourse(ByVal f As feeStructureE) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}

        para(0) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        para(0).Value = f.batchID
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectCourse", para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetFeeHeads1() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@FHID", SqlDbType.Int)
        arParms(2).Value = 0
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetFeeHeads1", arParms)

            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
