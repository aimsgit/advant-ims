Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLPrincipalDashboard
    Public Function PrincipalDashboard(ByVal academic As Integer, ByVal course As Integer, ByVal stdcategory As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            
            Parms(0) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@coursecode", SqlDbType.VarChar, 50)
            Parms(1).Value = course

            Parms(2) = New SqlParameter("@categoryid", SqlDbType.VarChar, 50)
            Parms(2).Value = stdcategory
            Parms(3) = New SqlParameter("@academic", SqlDbType.VarChar, 50)
            Parms(3).Value = academic
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_PrincipalDashboard", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetCoursebyAcademic(ByVal id As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
        arParms(2).Value = id
        Try

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectcoursefrmAyear", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return ds.Tables(0)
    End Function

    Public Function GetPrincipleDashboardRpt(ByVal academic As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}


            Parms(0) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@academic", SqlDbType.VarChar, 50)
            Parms(1).Value = academic
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_PrincipalDashboard", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function GetTotEmpCount() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(0) {}


            Parms(0) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            'Parms(1) = New SqlParameter("@academic", SqlDbType.VarChar, 50)
            'Parms(1).Value = academic
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_TotEmpcount", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetBranchName(ByVal academic As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(0) {}


            'Parms(0) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
            'Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(0) = New SqlParameter("@academic", SqlDbType.VarChar, 50)
            Parms(0).Value = academic
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GetBranchName", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetStudcategory(ByVal academic As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}


            Parms(0) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@academic", SqlDbType.VarChar, 50)
            Parms(1).Value = academic
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_Getcategorydetails", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
