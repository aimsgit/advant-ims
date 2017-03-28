Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class FeedBackFormDL
    Shared Function FeedBackBatchDDL() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Parms(0).Value = HttpContext.Current.Session("Office")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

       
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FeedBackBatch", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function FeedBackSemesterDDL(ByVal BatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Parms(0).Value = HttpContext.Current.Session("Office")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(2).Value = BatchId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FeedBackSemesterDDL", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function InsertFeedBack(ByVal FDBack As FeedBackForm) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(16) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(1).Value = FDBack.BatchId

        arParms(2) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(2).Value = FDBack.SemId

        arParms(3) = New SqlParameter("@SubId", SqlDbType.Int)
        arParms(3).Value = FDBack.SubJectId

        arParms(4) = New SqlParameter("@FacultyId", SqlDbType.Int)
        arParms(4).Value = FDBack.FacultyId

        arParms(5) = New SqlParameter("@Score1", SqlDbType.Int)
        arParms(5).Value = FDBack.Score1

        arParms(6) = New SqlParameter("@Score2", SqlDbType.Int)
        arParms(6).Value = FDBack.Score2

        arParms(7) = New SqlParameter("@Score3", SqlDbType.Int)
        arParms(7).Value = FDBack.Score3

        arParms(8) = New SqlParameter("@Score4", SqlDbType.Int)
        arParms(8).Value = FDBack.Score4

        arParms(9) = New SqlParameter("@Score5", SqlDbType.Int)
        arParms(9).Value = FDBack.Score5

        arParms(10) = New SqlParameter("@Score6", SqlDbType.Int)
        arParms(10).Value = FDBack.Score6

        arParms(11) = New SqlParameter("@Score7", SqlDbType.Int)
        arParms(11).Value = FDBack.Score7

        arParms(12) = New SqlParameter("@Score8", SqlDbType.Int)
        arParms(12).Value = FDBack.Score8

        arParms(13) = New SqlParameter("@Score9", SqlDbType.Int)
        arParms(13).Value = FDBack.Score9

        arParms(14) = New SqlParameter("@Score10", SqlDbType.Int)
        arParms(14).Value = FDBack.Score10

        arParms(15) = New SqlParameter("@StdCode", SqlDbType.VarChar)
        arParms(15).Value = HttpContext.Current.Session("StudentCode")

        arParms(16) = New SqlParameter("@Remarks", SqlDbType.VarChar)
        arParms(16).Value = FDBack.Remarks
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertFeedBack", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function InsertFeedBackNew(ByVal Batch As Integer, ByVal Sem As Integer, ByVal Subj As Integer, ByVal FacultyId As Integer, ByVal Score1 As Integer, ByVal Score2 As Integer, ByVal Score3 As Integer, ByVal Score4 As Integer, ByVal Score5 As Integer, ByVal Score6 As Integer, ByVal Score7 As Integer, ByVal Score8 As Integer, ByVal Score9 As Integer, ByVal Score10 As Integer, ByVal Remarks As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(16) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(1).Value = Batch

        arParms(2) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(2).Value = Sem

        arParms(3) = New SqlParameter("@SubId", SqlDbType.Int)
        arParms(3).Value = Subj

        arParms(4) = New SqlParameter("@FacultyId", SqlDbType.Int)
        arParms(4).Value = FacultyId

        arParms(5) = New SqlParameter("@Score1", SqlDbType.Int)
        arParms(5).Value = Score1

        arParms(6) = New SqlParameter("@Score2", SqlDbType.Int)
        arParms(6).Value = Score2

        arParms(7) = New SqlParameter("@Score3", SqlDbType.Int)
        arParms(7).Value = Score3

        arParms(8) = New SqlParameter("@Score4", SqlDbType.Int)
        arParms(8).Value = Score4

        arParms(9) = New SqlParameter("@Score5", SqlDbType.Int)
        arParms(9).Value = Score5

        arParms(10) = New SqlParameter("@Score6", SqlDbType.Int)
        arParms(10).Value = Score6

        arParms(11) = New SqlParameter("@Score7", SqlDbType.Int)
        arParms(11).Value = Score7

        arParms(12) = New SqlParameter("@Score8", SqlDbType.Int)
        arParms(12).Value = Score8

        arParms(13) = New SqlParameter("@Score9", SqlDbType.Int)
        arParms(13).Value = Score9

        arParms(14) = New SqlParameter("@Score10", SqlDbType.Int)
        arParms(14).Value = Score10

        arParms(15) = New SqlParameter("@StdCode", SqlDbType.VarChar)
        arParms(15).Value = HttpContext.Current.Session("StudentCode")

        arParms(16) = New SqlParameter("@Remarks", SqlDbType.VarChar)
        arParms(16).Value = Remarks
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertFeedBackNew", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetFeedBackGV(ByVal FDBack As FeedBackForm) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Parms(0).Value = HttpContext.Current.Session("Office")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(2).Value = FDBack.BatchId

            Parms(3) = New SqlParameter("@SemId", SqlDbType.Int)
            Parms(3).Value = FDBack.SemId

            

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FeedBackGridviewNew", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function FeedBackParamsGridView(ByVal FDBack As FeedBackForm) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Parms(0).Value = HttpContext.Current.Session("Office")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FeedBackParamGridView", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function FeedbackMaxMin(ByVal FDBack As FeedBackForm) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Parms(0).Value = HttpContext.Current.Session("Office")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FeedbackMaxMin", Parms)
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
            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStdCurrentBatch", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
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
    Shared Function GetFeedBackGVStudent(ByVal BranchCode As String, ByVal BatchId As Integer, ByVal SemId As Integer, ByVal Ltype As String, ByVal SID As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(5) {}

            Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Parms(0).Value = HttpContext.Current.Session("Office")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = BranchCode

            Parms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(2).Value = BatchId

            Parms(3) = New SqlParameter("@SemId", SqlDbType.Int)
            Parms(3).Value = SemId

            Parms(4) = New SqlParameter("@Ltype", SqlDbType.VarChar, 50)
            Parms(4).Value = Ltype

            Parms(5) = New SqlParameter("@SID", SqlDbType.VarChar, 50)
            Parms(5).Value = SID

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FeedBackGridview", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSubjectCombo(ByVal BranchCode As String, ByVal BatchId As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Parms(0).Value = HttpContext.Current.Session("Office")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = BranchCode

            Parms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(2).Value = BatchId

            Parms(3) = New SqlParameter("@SemId", SqlDbType.Int)
            Parms(3).Value = SemId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_SubjectDDL]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetFaculty(ByVal BranchCode As String, ByVal BatchId As Integer, ByVal SemId As Integer, ByVal Subject As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Parms(0).Value = HttpContext.Current.Session("Office")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = BranchCode

            Parms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(2).Value = BatchId

            Parms(3) = New SqlParameter("@SemId", SqlDbType.Int)
            Parms(3).Value = SemId

            Parms(4) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(4).Value = Subject

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_FacultyName]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function FeedBackParamsGridViewStudent(ByVal BranchCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Parms(0).Value = HttpContext.Current.Session("Office")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = BranchCode

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FeedBackParamGridView", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function FeedbackOpenClose(ByVal BatchId As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(1).Value = BatchId

            Parms(2) = New SqlParameter("@SemId", SqlDbType.Int)
            Parms(2).Value = SemId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetFeedbackConfigValue", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CheckStudentFeedbackStatus(ByVal BatchId As Integer, ByVal SemId As Integer, ByVal Subject As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@StdCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("StudentCode")

            Parms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(1).Value = BatchId

            Parms(2) = New SqlParameter("@SemId", SqlDbType.Int)
            Parms(2).Value = SemId

            Parms(3) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(3).Value = Subject

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckStudentFeedbackStatus", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CheckStudentFeedbackStatusNew(ByVal BatchId As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@StdCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("StudentCode")

            Parms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(1).Value = BatchId

            Parms(2) = New SqlParameter("@SemId", SqlDbType.Int)
            Parms(2).Value = SemId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckStudentFeedbackStatusNew", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
