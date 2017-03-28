Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLCreateExamCalendar
    Shared Function GetExamBatch() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_ddlExamBatch", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal b As ELCreateExamCalendar) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@Batch_No", SqlDbType.Int)
        arParms(0).Value = b.BatchId

        arParms(1) = New SqlParameter("@SubjectId", SqlDbType.Int)
        arParms(1).Value = b.SubjectId

        arParms(2) = New SqlParameter("@TOE", SqlDbType.VarChar, 50)
        arParms(2).Value = b.TOE

        arParms(3) = New SqlParameter("@DOE", SqlDbType.DateTime)
        arParms(3).Value = b.DOE

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@id", SqlDbType.Int)
        arParms(7).Value = b.Id

        arParms(8) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("Office")


        Try
            rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_InsertCreateExamCalendar", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetAddCreateExamCalender(ByVal ID As String) As Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
        arParms(2).Value = ID

        Dim ds As DataSet
        'If id = 0 Then
        '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Select * From View_GetEnquiryDetails")
        'Else
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAddCreateExamCalendar", arParms)
            'End If
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCreateExamCalender(ByVal el As ELCreateExamCalendar) As Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = el.Id

        arParms(3) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(3).Value = el.BatchId

        Dim ds As DataSet
        'If id = 0 Then
        '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Select * From View_GetEnquiryDetails")
        'Else
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCreateExamCalendar", arParms)
            'End If
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetPublishCreateExamCalender(ByVal el As ELCreateExamCalendar) As Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = el.Id

        arParms(3) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(3).Value = el.BatchId

        arParms(4) = New SqlParameter("@SubjectId", SqlDbType.Int)
        arParms(4).Value = el.SubjectId

        arParms(5) = New SqlParameter("@DOE", SqlDbType.DateTime)
        arParms(5).Value = el.DOE

        arParms(6) = New SqlParameter("@TOE", SqlDbType.NVarChar, 50)
        arParms(6).Value = el.TOE

        Dim ds As DataSet
        'If id = 0 Then
        '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Select * From View_GetEnquiryDetails")
        'Else
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPublishCreateExamCalendar1", arParms)
            'End If
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'Code By Jinapriya --> Set the publish Flag
    Shared Function UpdatePublish(ByVal el As ELCreateExamCalendar) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = el.Id

        arParms(3) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(3).Value = el.BatchId

        arParms(4) = New SqlParameter("@SubjectId", SqlDbType.Int)
        arParms(4).Value = el.SubjectId

        arParms(5) = New SqlParameter("@DOE", SqlDbType.DateTime)
        arParms(5).Value = el.DOE

        arParms(6) = New SqlParameter("@TOE", SqlDbType.NVarChar, 50)
        arParms(6).Value = el.TOE

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdatePublish", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function publish(ByVal msg As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@msg", SqlDbType.VarChar, 8000)
        arParms(1).Value = msg

        arParms(2) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        Try
            rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "[Proc_PublishExamRes1]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function CntData(ByVal ExamBatchId As Integer) As Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        arParms(2).Value = ExamBatchId

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CntCreateExamCalender]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Shared Function delete(ByVal EL As ELCreateExamCalendar) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_DeleteCreateExamCalendar]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function LockData(ByVal Exambatchid As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        Parms(1).Value = Exambatchid

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_LockCreateExamCalendar]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetunlockData(ByVal id As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
        arParms(1).Value = id

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetUnlockCreateExam]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function UnLockData(ByVal Exambatchid As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        Parms(1).Value = Exambatchid

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UnLockCreateExamCalendar]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function CountData(ByVal ExamBatchId As Integer) As Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        arParms(2).Value = ExamBatchId

        Dim ds As New DataSet
        Try

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CountCreateExamCalender]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
End Class
