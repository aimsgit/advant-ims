Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLslssbhierarchytreeview
    Shared Function GetDCO(ByVal HO As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HO

        para(1) = New SqlParameter("@UserName", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("UserName")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDCO", para)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function FillListView(ByVal HO As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HO

        para(1) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Accesslevel")

        para(2) = New SqlParameter("@SessBranchCode", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("ParentBranch")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FillListView", para)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetDCOreverse(ByVal DCODDL1 As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(0) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDCOReverse", para)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetDSD(ByVal DSDDDL As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@UserName", SqlDbType.VarChar, 10)
        para(1).Value = HttpContext.Current.Session("UserName")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDDSDDDL", para)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetDSDreverse(ByVal DSDDDL1 As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(0) {}
        DSDDDL1 = HttpContext.Current.Session("BranchCode")
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDSDReverse", para)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetGSDreverse(ByVal GSDDDL1 As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(0) {}
        GSDDDL1 = HttpContext.Current.Session("BranchCode")
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetGSDReverse", para)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetGSD(ByVal GSDDDL As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@UserName", SqlDbType.VarChar, 10)
        para(1).Value = HttpContext.Current.Session("UserName")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetGSDDDL", para)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCenter(ByVal CenterDDL As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@UserName", SqlDbType.VarChar, 10)
        para(1).Value = HttpContext.Current.Session("UserName")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCenterDDL", para)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetHO() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(0) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("ParentBranch")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetHODDL", para)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Function
End Class
