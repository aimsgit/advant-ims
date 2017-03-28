Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLSendExamMarks
    Shared Function getBatchsendmarksddl() As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getBatchddlsendmarks", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetSemesterSendMarks(ByVal batch As Integer) As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemesterddlSendMarks", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetassessmentAllDDl() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetAssesmentAllSendMarks", arParms)
        Return ds.Tables(0)
    End Function
    Public Function ViewSendMessage(ByVal Batchid As Integer, ByVal Semesterid As Integer, ByVal Assessmentid As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(2).Value = Batchid

        arParms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(3).Value = Semesterid



        arParms(4) = New SqlParameter("@AssessmentType", SqlDbType.Int)
        arParms(4).Value = Assessmentid



        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_SendStudentMarks", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function ViewSendMessage1(ByVal Batchid As Integer, ByVal Semesterid As Integer, ByVal Assessmentid As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")


        arParms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(1).Value = Batchid

        arParms(2) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(2).Value = Semesterid



        arParms(3) = New SqlParameter("@AssessmentType", SqlDbType.Int)
        arParms(3).Value = Assessmentid



        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_SendStudentMarksAttendance", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function ViewSendMessage2(ByVal Batchid As Integer, ByVal Semesterid As Integer, ByVal Assessmentid As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")


        arParms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(1).Value = Batchid

        arParms(2) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(2).Value = Semesterid



        arParms(3) = New SqlParameter("@AssessmentType", SqlDbType.Int)
        arParms(3).Value = Assessmentid



        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_SendStudentAttendance", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function InsertSendMessage(ByVal prefix As String, ByVal contact As String, ByVal message As String, ByVal mode As String, ByVal batch As Integer, ByVal sem As Integer, ByVal assess As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@Prefix", SqlDbType.VarChar, 50)
        arParms(0).Value = prefix

        arParms(1) = New SqlParameter("@ToPhone", SqlDbType.VarChar, 50)
        arParms(1).Value = contact

        arParms(2) = New SqlParameter("@Message", SqlDbType.VarChar)
        arParms(2).Value = message

        arParms(3) = New SqlParameter("@Mode", SqlDbType.VarChar, 50)
        arParms(3).Value = mode



        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@SMTPHost", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("SMTPHost")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(8).Value = batch

        arParms(9) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(9).Value = sem

        arParms(10) = New SqlParameter("@Assessment", SqlDbType.Int)
        arParms(10).Value = assess



        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertSendMessage", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function GenerateMsgHistoryReport(ByVal Batchid As Integer, ByVal Semesterid As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")


        arParms(1) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(1).Value = Batchid

        arParms(2) = New SqlParameter("@Sem", SqlDbType.Int)
        arParms(2).Value = Semesterid

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMsgHistory", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

End Class
