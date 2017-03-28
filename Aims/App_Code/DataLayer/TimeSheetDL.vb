Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient


Public Class TimeSheetDL

    Dim dt As New DataTable
    Dim query As String
    Dim ds As New DataSet
    
    Public Function TopicCombo(ByVal SubjectID As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@SubjectID", SqlDbType.Int)
        param(2).Value = SubjectID
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_TimeSheetCombo", param)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Insert(ByVal TP As TimeSheetEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(12) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(3).Value = TP.EmpID

        arParms(4) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(4).Value = TP.BatchID

        arParms(5) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(5).Value = TP.SemesterID

        arParms(6) = New SqlParameter("@SubjectID", SqlDbType.Int)
        arParms(6).Value = TP.SubjectID

        'SqlDbType.VarChar, LP.Topic.Length

        arParms(7) = New SqlParameter("@TopicID", SqlDbType.Int)
        arParms(7).Value = TP.TopicID

        arParms(8) = New SqlParameter("@Date", SqlDbType.DateTime)
        arParms(8).Value = TP.Date1

        arParms(9) = New SqlParameter("@Time", SqlDbType.DateTime)
        arParms(9).Value = TP.time

        arParms(10) = New SqlParameter("@Period", SqlDbType.VarChar, TP.Period.Length)
        arParms(10).Value = TP.Period

        arParms(11) = New SqlParameter("@Duration", SqlDbType.Float)
        arParms(11).Value = TP.Duration

        arParms(12) = New SqlParameter("@WorkDescription", SqlDbType.VarChar, TP.WorkDescription.Length)
        arParms(12).Value = TP.WorkDescription

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertTimeSheet", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetTimeSheet(ByVal TP As TimeSheetEL) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@TSAUTOID", SqlDbType.Int)
        arParms(2).Value = TP.ID

        arParms(3) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(3).Value = TP.EmpID

        arParms(4) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(4).Value = TP.BatchID

        arParms(5) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(5).Value = TP.SemesterID

        arParms(6) = New SqlParameter("@SubjectID", SqlDbType.Int)
        arParms(6).Value = TP.SubjectID

        arParms(7) = New SqlParameter("@TopicID", SqlDbType.Int)
        arParms(7).Value = TP.TopicID

        arParms(8) = New SqlParameter("@Date", SqlDbType.DateTime)
        arParms(8).Value = TP.Date1



        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[proc_getTimeSheet]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal TP As TimeSheetEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(13) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(3).Value = TP.EmpID

        arParms(4) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(4).Value = TP.BatchID

        arParms(5) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(5).Value = TP.SemesterID

        arParms(6) = New SqlParameter("@SubjectID", SqlDbType.Int)
        arParms(6).Value = TP.SubjectID

        arParms(7) = New SqlParameter("@TopicID", SqlDbType.Int)
        arParms(7).Value = TP.TopicID

        arParms(8) = New SqlParameter("@Date", SqlDbType.DateTime)
        arParms(8).Value = TP.Date1

        arParms(9) = New SqlParameter("@Time", SqlDbType.DateTime)
        arParms(9).Value = TP.time

        arParms(10) = New SqlParameter("@Period", SqlDbType.VarChar)
        arParms(10).Value = TP.Period

        arParms(11) = New SqlParameter("@Duration", SqlDbType.Float)
        arParms(11).Value = TP.Duration

        arParms(12) = New SqlParameter("@WorkDescription", SqlDbType.VarChar, TP.WorkDescription.Length)
        arParms(12).Value = TP.WorkDescription

        arParms(13) = New SqlParameter("@TSAUTOID", SqlDbType.Int)
        arParms(13).Value = TP.ID


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateTimeSheet", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ChangeFlag(ByVal TP As TimeSheetEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(0).Value = TP.ID

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_ChangeFlagTimeSheet", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    '-----Functions for Report
    Shared Function GetRptTimeSheet(ByVal EmpID As Integer, ByVal BatchID As Integer, ByVal SemID As Integer, ByVal SubjectID As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(2).Value = EmpID

        arParms(3) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(3).Value = BatchID

        arParms(4) = New SqlParameter("@SemID", SqlDbType.Int)
        arParms(4).Value = SemID

        arParms(5) = New SqlParameter("@SubjectID", SqlDbType.Int)
        arParms(5).Value = SubjectID


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_RptTimeSheet", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

End Class
