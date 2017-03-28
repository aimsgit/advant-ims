Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_DLProcessDetails
    'Author Anchala 29-10-2012
    'code for insert 
    Public Function InsertProcessMaster(ByVal i As Mfg_ELProcessDetails) As Integer
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@productID", SqlDbType.Int)
        arParms(0).Value = i.ItemDesc
        arParms(1) = New SqlParameter("@IO", SqlDbType.VarChar, 1)
        arParms(1).Value = i.IO
        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")
        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")
        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")
        arParms(5) = New SqlParameter("@processID", SqlDbType.Int)
        arParms(5).Value = i.ProcessID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertProcessIO", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    'Author Anchala 29-10-2012
    'code for update 
    Public Function UpdateProcessDetails(ByVal i As Mfg_ELProcessDetails) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@ProcessDesc", SqlDbType.VarChar, 50)
        arParms(0).Value = i.ProcessDesc
        arParms(1) = New SqlParameter("@Sequence", SqlDbType.Int)
        arParms(1).Value = i.Sequence
        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")
        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")
        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")
        arParms(5) = New SqlParameter("@id", SqlDbType.Int)
        arParms(5).Value = i.id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateProcessMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    'Author Anchala 29-10-2012
    'code for display 
    Public Function GetProcessDetails(ByVal s As Mfg_ELProcessDetails) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = s.id

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetProcessMaster", arParms)
        Return ds.Tables(0)
    End Function
    'Author Anchala 29-10-2012
    'code for delete 
    Public Function DeteteProcessMaster(ByVal s As Mfg_ELProcessDetails) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = s.PID
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteProcessIO", arParms)
        Return rowsaffected
    End Function
    'Author Anchala 29-10-2012
    'code for delete 
    Public Function DeteteProcessDetails(ByVal s As Mfg_ELProcessDetails) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = s.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteProcessMaster", arParms)
        Return rowsaffected
    End Function
    'Author Anchala 29-10-2012
    'code for display 
    Public Function GetProcessMaster(ByVal s As Mfg_ELProcessDetails) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = s.PID



        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetProcessIO", arParms)
        Return ds.Tables(0)
    End Function
    'Author Anchala 29-10-2012
    'code for insert 
    Public Function InsertProcessDetails(ByVal i As Mfg_ELProcessDetails) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@processdesc", SqlDbType.VarChar, 50)
        arParms(0).Value = i.ProcessDesc
        arParms(1) = New SqlParameter("@sequence", SqlDbType.Int)
        arParms(1).Value = i.Sequence
        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")
        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")
        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertProcessMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    'Author Anchala 29-10-2012
    'code for update 
    Public Function UpdateProcessMaster(ByVal i As Mfg_ELProcessDetails) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@ItemID", SqlDbType.Int)
        arParms(0).Value = i.ItemDesc
        arParms(1) = New SqlParameter("@IO", SqlDbType.VarChar, 1)
        arParms(1).Value = i.IO
        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")
        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")
        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")
        arParms(5) = New SqlParameter("@id", SqlDbType.Int)
        arParms(5).Value = i.PID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateProcessIO", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    'Author Anchala 29-10-2012
    'code for get process ID 
    Public Function GetProcessID() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectProcessID", arParms)
        Return ds.Tables(0)
    End Function
End Class
