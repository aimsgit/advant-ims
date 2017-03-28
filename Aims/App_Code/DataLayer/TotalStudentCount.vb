Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO

Public Class TotalStudentCount
    Shared Function insertBranchCombo() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "getBranchNameddl", arParms)
        Return ds.Tables(0)
    End Function
    Public Function TotalStudentCount(ByVal BranchCode As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@StartDate", SqlDbType.DateTime)
            Parms(2).Value = FromDate

            Parms(3) = New SqlParameter("@EndDate", SqlDbType.DateTime)
            Parms(3).Value = ToDate

            'Parms(4) = New SqlParameter("@BranchCode1", SqlDbType.VarChar)
            'Parms(4).Value = BranchCode1

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_TotalStudentcount", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function SUBranchCombo() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[SUBranchNameddl]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function SUStreamCombo() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_SUStreamNameDDL")
        Return ds.Tables(0)
    End Function
    Public Function UniStudentStudCountStreamWise(ByVal BranchCode As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime, ByVal Stream As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@StartDate", SqlDbType.DateTime)
            Parms(2).Value = FromDate

            Parms(3) = New SqlParameter("@EndDate", SqlDbType.DateTime)
            Parms(3).Value = ToDate

            Parms(4) = New SqlParameter("@Stream", SqlDbType.Int)
            Parms(4).Value = Stream

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_UniStudentcountStreamWise", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function CompositionOfEthnicWise(ByVal BranchCode As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime, ByVal Stream As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@StartDate", SqlDbType.DateTime)
            Parms(2).Value = FromDate

            Parms(3) = New SqlParameter("@EndDate", SqlDbType.DateTime)
            Parms(3).Value = ToDate

            'Parms(4) = New SqlParameter("@Stream", SqlDbType.Int)
            'Parms(4).Value = Stream

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_CompositionOfEhtnicWiseStudent", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function CompositionOfGenderWise(ByVal BranchCode As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime, ByVal Stream As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
            Parms(2).Value = FromDate

            Parms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            Parms(3).Value = ToDate

            'Parms(4) = New SqlParameter("@Stream", SqlDbType.Int)
            'Parms(4).Value = Stream

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_EthnicWiseDashboard", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function SUBranchComboEG() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[SUBranchNameddlEG]", arParms)
        Return ds.Tables(0)
    End Function
End Class

