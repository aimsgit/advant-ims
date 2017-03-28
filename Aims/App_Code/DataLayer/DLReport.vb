Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLReport
    Shared Function GetStudentLeaveData(ByVal Bat As Integer, ByVal Sem As Integer, ByVal StdId As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(2).Value = Bat

        arParms(3) = New SqlParameter("@Sem", SqlDbType.Int)
        arParms(3).Value = Sem

        arParms(4) = New SqlParameter("@StdId", SqlDbType.Int)
        arParms(4).Value = StdId

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GetLeaveApplication", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetReportData(ByVal Id As Integer, ByVal SearchKey As String, ByVal ModuleName As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@UserRole", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserRole")

        arParms(3) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(3).Value = Id

        arParms(4) = New SqlParameter("@SearchKey", SqlDbType.VarChar, 50)
        arParms(4).Value = SearchKey

        arParms(5) = New SqlParameter("@ModuleName", SqlDbType.Int)
        arParms(5).Value = ModuleName

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetReportDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Code written by Niraj on 12 July 2013
    Public Function RptMedicalDetails(ByVal StdID As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(3) {}

        Parms(0) = New SqlParameter("@Std_ID", SqlDbType.Int)
        Parms(0).Value = StdID

        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")

        Parms(2) = New SqlParameter("@LoginType", SqlDbType.VarChar, 500)
        Parms(2).Value = HttpContext.Current.Session("LoginType")

        Parms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("Office")
        Try
            dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GetMedicalDetails", Parms)
            Return dt.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'Code written by Niraj on 16 July 2013
    Public Function RptStudentReport() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Try
            dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudReportWithTwoUSN", Parms)
            Return dt.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
