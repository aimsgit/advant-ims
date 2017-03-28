Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class FeeStructD
    Shared Function finalExamRpt(ByVal Aid As Integer, ByVal Bid As Integer, ByVal Sid As Integer, ByVal Cid As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@A_Year", SqlDbType.Int)
        arParms(1).Value = Aid

        arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(2).Value = Bid

        arParms(3) = New SqlParameter("@Semid", SqlDbType.Int)
        arParms(3).Value = Sid

        arParms(4) = New SqlParameter("@Category", SqlDbType.Int)
        arParms(4).Value = Cid

        arParms(5) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_FeeStructureReport", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function Semester() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SemesterComboAll", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function Category() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_StdudentCategoryAll", arParms)
        Return ds.Tables(0)
    End Function


End Class
