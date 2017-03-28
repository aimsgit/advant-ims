Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLRollOver
    Public Function FromStudentGrid(ByVal BatchId As ELRollOver) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@batchid", SqlDbType.Int)
        Parms(0).Value = BatchId.BatchId
        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FromStudentGrid", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function StudentForumReport(ByVal BatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@batchid", SqlDbType.Int)
        Parms(0).Value = BatchId
        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudentForum", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function getCourseName(ByVal BatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@batchid", SqlDbType.Int)
        Parms(0).Value = BatchId
        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCourseNameFourn", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetForumBatch(ByVal el As ELRollOver) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@batchid", SqlDbType.Int)
        Parms(0).Value = el.BatchId
        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetForumBatch", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function BatchComboD(ByVal Courseid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@CourseCode", SqlDbType.Int)
        Parms(0).Value = Courseid
        Parms(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_BatchCombo", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function BatchAYComboD(ByVal Courseid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@CourseCode", SqlDbType.Int)
        Parms(0).Value = Courseid
        Parms(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_BatchAYCombo", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function StudentComboD(ByVal Batchid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@batchid", SqlDbType.Int)
        Parms(0).Value = Batchid
        Parms(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectStudentAll", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function StudentBatchTransfer(ByVal el As ELRollOver) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer
        Dim Parms() As SqlParameter = New SqlParameter(6) {}
        Parms(0) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
        Parms(0).Value = el.Id
        Parms(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        Parms(1).Value = el.BatchId
        Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
        Parms(2).Value = el.Academicyr
        Parms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("UserCode")
        Parms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(4).Value = HttpContext.Current.Session("EmpCode")
        Parms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(5).Value = HttpContext.Current.Session("BranchCode")
        Parms(6) = New SqlParameter("@CourseCode", SqlDbType.Int)
        Parms(6).Value = el.CourseId
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_StudentBatchTransfer", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function RollOver(ByVal el As ELRollOver) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer
        Dim Parms() As SqlParameter = New SqlParameter(7) {}
        Parms(0) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
        Parms(0).Value = el.Id
        Parms(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        Parms(1).Value = el.BatchId
        Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
        Parms(2).Value = el.Academicyr
        Parms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("UserCode")
        Parms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(4).Value = HttpContext.Current.Session("EmpCode")
        Parms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(5).Value = HttpContext.Current.Session("BranchCode")
        Parms(6) = New SqlParameter("@CourseCode", SqlDbType.Int)
        Parms(6).Value = el.CourseId
        Parms(7) = New SqlParameter("@Date", SqlDbType.DateTime)
        Parms(7).Value = el.Tdate
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_Rollover", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function CourseTransfer(ByVal el As ELRollOver) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer
        Dim Parms() As SqlParameter = New SqlParameter(7) {}
        Parms(0) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
        Parms(0).Value = el.Id
        Parms(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        Parms(1).Value = el.BatchId
        Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
        Parms(2).Value = el.Academicyr
        Parms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("UserCode")
        Parms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(4).Value = HttpContext.Current.Session("EmpCode")
        Parms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(5).Value = HttpContext.Current.Session("BranchCode")
        Parms(6) = New SqlParameter("@CourseCode", SqlDbType.Int)
        Parms(6).Value = el.CourseId
        Parms(7) = New SqlParameter("@Date", SqlDbType.DateTime)
        Parms(7).Value = el.Tdate
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_CourseTransfer", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function Forum(ByVal el As ELRollOver) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer
        Dim Parms() As SqlParameter = New SqlParameter(6) {}
        Parms(0) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
        Parms(0).Value = el.Id
        Parms(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        Parms(1).Value = el.BatchId
        Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
        Parms(2).Value = el.Academicyr
        Parms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("UserCode")
        Parms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(4).Value = HttpContext.Current.Session("EmpCode")
        Parms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(5).Value = HttpContext.Current.Session("BranchCode")
        Parms(6) = New SqlParameter("@CourseCode", SqlDbType.Int)
        Parms(6).Value = el.CourseId
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_ForumTransfer", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function transfer(ByVal el As ELRollOver) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer
        Dim Parms() As SqlParameter = New SqlParameter(9) {}
        Parms(0) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
        Parms(0).Value = el.Id
        Parms(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        Parms(1).Value = el.BatchId
        Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
        Parms(2).Value = el.Academicyr
        Parms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("UserCode")
        Parms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(4).Value = HttpContext.Current.Session("EmpCode")
        Parms(5) = New SqlParameter("@TOBranchCode", SqlDbType.VarChar, 50)
        Parms(5).Value = el.TOBRANCH
        Parms(6) = New SqlParameter("@FromBranchCode", SqlDbType.VarChar, 50)
        Parms(6).Value = el.FRMBRANCH
        Parms(7) = New SqlParameter("@Date", SqlDbType.DateTime)
        Parms(7).Value = el.Tdate
        Parms(8) = New SqlParameter("@CourseCode", SqlDbType.Int)
        Parms(8).Value = el.CourseId
        Parms(9) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(9).Value = HttpContext.Current.Session("BranchCode")
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_transferstudent", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function InsertRecord(ByVal el As ELRollOver) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer
        Dim Parms() As SqlParameter = New SqlParameter(9) {}
        Parms(0) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
        Parms(0).Value = el.Id
        Parms(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        Parms(1).Value = el.BatchId
        Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
        Parms(2).Value = el.Academicyr
        Parms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("UserCode")
        Parms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(4).Value = HttpContext.Current.Session("EmpCode")
        Parms(5) = New SqlParameter("@TOBranchCode", SqlDbType.VarChar, 50)
        Parms(5).Value = el.TOBRANCH
        Parms(6) = New SqlParameter("@FromBranchCode", SqlDbType.VarChar, 50)
        Parms(6).Value = el.FRMBRANCH
        Parms(7) = New SqlParameter("@Date", SqlDbType.DateTime)
        Parms(7).Value = el.Tdate
        Parms(8) = New SqlParameter("@CourseCode", SqlDbType.Int)
        Parms(8).Value = el.CourseId
        Parms(9) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(9).Value = HttpContext.Current.Session("BranchCode")
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateStudentBranchCode", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function ToStudentGrid(ByVal BatchId As ELRollOver) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@batchid", SqlDbType.Int)
        Parms(0).Value = BatchId.BatchId
        Parms(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ToStudentGrid", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function ToStudentGridForum(ByVal BatchId As ELRollOver) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@batchid", SqlDbType.Int)
        Parms(0).Value = BatchId.BatchId
        Parms(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ToStudentGridForum", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function lockunlock(ByVal BatchId As ELRollOver) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As String
        Dim Parms() As SqlParameter = New SqlParameter(1) {}
        Parms(0) = New SqlParameter("@batchid", SqlDbType.Int)
        Parms(0).Value = BatchId.BatchId
        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_LockUnlockRollOver", Parms)
            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function RollBack(ByVal el As ELRollOver) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer
        Dim Parms() As SqlParameter = New SqlParameter(3) {}
        Parms(0) = New SqlParameter("@StdCode", SqlDbType.VarChar, 4000)
        Parms(0).Value = el.Id
        Parms(1) = New SqlParameter("@FromBatchid", SqlDbType.Int)
        Parms(1).Value = el.BatchId
        Parms(2) = New SqlParameter("@ToBatchid", SqlDbType.Int)
        Parms(2).Value = el.ToBatchId
        Parms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("BranchCode")
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_ClearRollover", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function DeleteForum(ByVal el As ELRollOver) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer
        Dim Parms() As SqlParameter = New SqlParameter(3) {}
        Parms(0) = New SqlParameter("@StdCode", SqlDbType.VarChar, 4000)
        Parms(0).Value = el.Id
        Parms(1) = New SqlParameter("@FromBatchid", SqlDbType.Int)
        Parms(1).Value = el.BatchId
        Parms(2) = New SqlParameter("@ToBatchid", SqlDbType.Int)
        Parms(2).Value = el.ToBatchId
        Parms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("BranchCode")
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_ClearForum", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetDuplicateRollOver(ByVal EL As ELRollOver) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}

        para(0) = New SqlParameter("@id", SqlDbType.VarChar, 50)
        para(0).Value = EL.StdCode
        para(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        para(1).Value = EL.BatchId
        para(2) = New SqlParameter("@A_Year", SqlDbType.Int)
        para(2).Value = EL.Academicyr
        para(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_DuplicateRollover", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetDuplicateForum(ByVal EL As ELRollOver) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}

        para(0) = New SqlParameter("@id", SqlDbType.VarChar, 50)
        para(0).Value = EL.Id
        para(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        para(1).Value = EL.BatchId
        para(2) = New SqlParameter("@A_Year", SqlDbType.Int)
        para(2).Value = EL.Academicyr
        para(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_DuplicateRolloverForum", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetDuplicateTransfer(ByVal EL As ELRollOver) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}

        para(0) = New SqlParameter("@id", SqlDbType.VarChar, 50)
        para(0).Value = EL.StdCode
        para(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        para(1).Value = EL.BatchId
        para(2) = New SqlParameter("@A_Year", SqlDbType.Int)
        para(2).Value = EL.Academicyr
        para(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("BranchCode")


        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_DuplicateTransfer", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function LockStatus(ByVal el As ELRollOver) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim lock As String = ""
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(0).Value = el.BatchId

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            lock = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_RollOver_LockStatusCheck", arParms)

        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Return lock
    End Function
    Shared Function LockStatusForum(ByVal el As ELRollOver) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim lock As String = ""
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(0).Value = el.BatchId

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            lock = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_RollOver_LockStatusCheckForum", arParms)

        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Return lock
    End Function

End Class
