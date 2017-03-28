Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class DLSystemConfiguration
    Shared Function Insert(ByVal C As SystemConfiguration) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        Dim s As String = HttpContext.Current.Session("BranchCode")
        Dim s1 As String = HttpContext.Current.Session("UserCode")
        Dim s2 As String = HttpContext.Current.Session("EmpCode")

        arParms(0) = New SqlParameter("@branch", SqlDbType.VarChar, C.BranchCode.Length)
        arParms(0).Value = C.BranchCode

        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("UserCode")

        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@Name", SqlDbType.VarChar, C.Name.Length)
        arParms(3).Value = C.Name

        arParms(4) = New SqlParameter("@Value", SqlDbType.VarChar, C.Value.Length)
        arParms(4).Value = C.Value

        arParms(5) = New SqlParameter("@Date", SqlDbType.DateTime)
        arParms(5).Value = C.ConfigDate

        arParms(6) = New SqlParameter("@Description", SqlDbType.Char, C.Description.Length)
        arParms(6).Value = C.Description

        arParms(7) = New SqlParameter("@ReadOnly", SqlDbType.Char, C.ReadOnlys.Length)
        arParms(7).Value = C.ReadOnlys

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveSystemConfiguration", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function Update(ByVal C As SystemConfiguration) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@branch", SqlDbType.VarChar, C.BranchCode.Length)
        arParms(0).Value = C.BranchCode

        arParms(1) = New SqlParameter("@ConfigID", SqlDbType.Int)
        arParms(1).Value = C.configID

        arParms(2) = New SqlParameter("@Name", SqlDbType.VarChar, C.Name.Length)
        arParms(2).Value = C.Name

        arParms(3) = New SqlParameter("@Value", SqlDbType.VarChar, C.Value.Length)
        arParms(3).Value = C.Value

        arParms(4) = New SqlParameter("@Date", SqlDbType.DateTime)
        arParms(4).Value = C.ConfigDate

        arParms(5) = New SqlParameter("@Description", SqlDbType.Char, C.Description.Length)
        arParms(5).Value = C.Description

        arParms(6) = New SqlParameter("@ReadOnly", SqlDbType.Char, C.ReadOnlys.Length)
        arParms(6).Value = C.ReadOnlys
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateSystemConfiguration", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function UpdateBranch(ByVal C As SystemConfiguration) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@ConfigID", SqlDbType.Int)
        arParms(0).Value = C.configID
        arParms(1) = New SqlParameter("@Value", SqlDbType.VarChar, C.Value.Length)
        arParms(1).Value = C.Value
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateBranchSystemConfiguration", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Display(ByVal C As SystemConfiguration) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@branch", SqlDbType.VarChar)
        arParms(0).Value = C.BranchCode

        arParms(1) = New SqlParameter("@ConfigID", SqlDbType.Int)
        arParms(1).Value = C.configID

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSystemConfiguration", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function DisplayBranch(ByVal C As SystemConfiguration) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@branch", SqlDbType.VarChar)
        arParms(0).Value = C.BranchCode

        arParms(1) = New SqlParameter("@ConfigID", SqlDbType.Int)
        arParms(1).Value = C.configID

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBranchSystemConfiguration", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function ChangeFlag(ByVal C As SystemConfiguration) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@ConfigID", SqlDbType.Int)
        arParms(0).Value = C.configID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteSystemConfiguration", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function GetDefault(ByVal C As SystemConfiguration) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@branch", SqlDbType.VarChar, 50)
        arParms(0).Value = C.BranchCode
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_GetDefaultSystemConfiguration", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function GetsystemConfigurationReport(ByVal branchcode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@branch", SqlDbType.VarChar)
        arParms(0).Value = branchcode


        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSystemConfigurationReport", arParms)
        Return ds.Tables(0)
    End Function
End Class
