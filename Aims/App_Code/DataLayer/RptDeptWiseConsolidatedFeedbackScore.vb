Imports Microsoft.VisualBasic
Imports System.Data.SqlClient


Public Class RptDeptWiseConsolidatedFeedbackScore
    Public Function insertCourse() As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Branchcode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")




        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_GetFeedbackStatusCourse", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function BatchComboReport(ByVal CourseCode As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Branchcode")


        arParms(1) = New SqlParameter("@CourseCode", SqlDbType.Int)
        arParms(1).Value = CourseCode

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetBatchComboForFeedbackstatus", arParms)
        Return ds.Tables(0)
    End Function
    Public Function SemesterCombo1(ByVal batch As String) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Branchcode")
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetSemesterforFeedbBack", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function FeedBackFacultyDDL() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Parms(0).Value = HttpContext.Current.Session("Office")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@EmpID", SqlDbType.VarChar)
            Parms(2).Value = HttpContext.Current.Session("EmpID")


            Parms(3) = New SqlParameter("@UserRole", SqlDbType.VarChar)
            Parms(3).Value = HttpContext.Current.Session("UserRole")

            Parms(4) = New SqlParameter("@AccessLevel", SqlDbType.Int)
            Parms(4).Value = HttpContext.Current.Session("AccessLevel")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetFacultyDDLforFeedback", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetFeedBackStatus(ByVal CourseId As Integer, ByVal BatchId As String, ByVal SemsterId As Integer, ByVal FacultyId As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@CourseId ", SqlDbType.Int)
        para(2).Value = CourseId
        para(3) = New SqlParameter("@BatchId", SqlDbType.VarChar, 50)
        para(3).Value = BatchId
        para(4) = New SqlParameter("@SemsterId ", SqlDbType.Int)
        para(4).Value = SemsterId
        para(5) = New SqlParameter("@FacultyId", SqlDbType.Int)
        para(5).Value = FacultyId


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_DeptWiseFeedBack", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function BatchComboReport2() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Branchcode")



        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetBatchComboForFeedbackstatus1", arParms)
        Return ds.Tables(0)
    End Function

End Class
