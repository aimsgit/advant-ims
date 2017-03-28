Imports Microsoft.VisualBasic
Imports System.Data.SqlClient


Public Class DLCreateBatch

    Shared Function GetRecord(ByVal b As CreateBatch) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(4) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = b.id
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        para(3) = New SqlParameter("@Ayear", SqlDbType.VarChar, 50)
        para(3).Value = b.AcademicYear
        para(4) = New SqlParameter("@CourseCode", SqlDbType.VarChar, 50)
        para(4).Value = b.CourseCode
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetCreateBatchCoursegrid", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)


    End Function
    Shared Function Insert(ByVal b As CreateBatch) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@Batch_No", SqlDbType.NVarChar, 50)
        arParms(0).Value = b.Batch_No

        arParms(1) = New SqlParameter("@CourseCode", SqlDbType.Int)
        arParms(1).Value = b.CourseCode

        arParms(2) = New SqlParameter("@AcademicYear", SqlDbType.NVarChar, 50)
        arParms(2).Value = b.AcademicYear

        arParms(3) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(3).Value = b.StartDate

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@NoOfSeats", SqlDbType.Int)
        arParms(7).Value = b.Seat

        arParms(8) = New SqlParameter("@ClassTeacher", SqlDbType.NVarChar, 50)
        arParms(8).Value = b.ClassTeacher

        arParms(9) = New SqlParameter("@AssociateTeacher", SqlDbType.NVarChar, 50)
        arParms(9).Value = b.AssociatedTeacher

        arParms(10) = New SqlParameter("@Forum", SqlDbType.VarChar, 2)
        arParms(10).Value = b.Forum
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertCreateBatch", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function UpdateRecord(ByVal b As CreateBatch) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(11) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = b.id

        arParms(1) = New SqlParameter("@Batch_No", SqlDbType.NVarChar, 50)
        arParms(1).Value = b.Batch_No

        arParms(2) = New SqlParameter("@CourseCode", SqlDbType.Int)
        arParms(2).Value = b.CourseCode

        arParms(3) = New SqlParameter("@AcademicYear", SqlDbType.NVarChar, 50)
        arParms(3).Value = b.AcademicYear

        arParms(4) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(4).Value = b.StartDate

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@NoOfSeats", SqlDbType.Int)
        arParms(7).Value = b.Seat

        arParms(8) = New SqlParameter("@ClassTeacher", SqlDbType.Int)
        arParms(8).Value = b.ClassTeacher

        arParms(9) = New SqlParameter("@AssociateTeacher", SqlDbType.Int)
        arParms(9).Value = b.AssociatedTeacher

        arParms(10) = New SqlParameter("@Forum", SqlDbType.VarChar, 2)
        arParms(10).Value = b.Forum

        arParms(11) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateCreateBatch1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Long) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = Id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteCreateBatch", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DeleteRecord(ByVal id As Long) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = id
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Proc_DeleteCreateBatch", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function getCreateBatchCourse() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getCreateBatchCourse", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetAcademicyear(ByVal Batch As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = Batch


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetAcademicYear", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


    Shared Function GetCreateBatchAcademicYearCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetCreateBatchAcademicYearCombo", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function CheckDuplicate(ByVal b As CreateBatch) As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = b.id
        arParms(1) = New SqlParameter("@Batch_No", SqlDbType.NVarChar, 50)
        arParms(1).Value = b.Batch_No
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CreateBatchDuplicate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
