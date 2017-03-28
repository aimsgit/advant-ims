Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLRptFeedbackComments
    Public Function GetCourseDDL() As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Branchcode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_FeedbackStatusCourse", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetBatchDDL(ByVal CourseCode As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Branchcode")


        arParms(1) = New SqlParameter("@CourseCode", SqlDbType.Int)
        arParms(1).Value = CourseCode

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_BatchComboForFeedbackstatus", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function FeedBackFacultyDDL(ByVal Batch As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(5) {}

            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@EmpID", SqlDbType.VarChar)
            arParms(2).Value = HttpContext.Current.Session("EmpID")


            arParms(3) = New SqlParameter("@UserRole", SqlDbType.VarChar)
            arParms(3).Value = HttpContext.Current.Session("UserRole")

            arParms(4) = New SqlParameter("@AccessLevel", SqlDbType.Int)
            arParms(4).Value = HttpContext.Current.Session("AccessLevel")

            arParms(5) = New SqlParameter("@Batch", SqlDbType.Int)
            arParms(5).Value = Batch

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetLoginFacultyDDL", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetFeedBackComments(ByVal CourseId As Integer, ByVal BatchId As Integer, ByVal FacultyId As Integer, ByVal SemId As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@CourseId ", SqlDbType.Int)
        arParms(2).Value = CourseId

        arParms(3) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(3).Value = BatchId

        arParms(4) = New SqlParameter("@FacultyId", SqlDbType.Int)
        arParms(4).Value = FacultyId
        arParms(5) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(5).Value = SemId


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_FeedBackComments", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class


