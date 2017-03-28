Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class ResourceDl
    Shared Function Insert(ByVal EL As ElResourceMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        arParms(0) = New SqlParameter("@ResourceType", SqlDbType.NVarChar, 50)
        arParms(0).Value = EL.ResourceType

        arParms(1) = New SqlParameter("@ResourceName", SqlDbType.NVarChar, 200)
        arParms(1).Value = EL.ResourceName

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        arParms(4) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        If EL.Capacity = 0 Then
            arParms(5) = New SqlParameter("@Capacity", SqlDbType.Int)
            arParms(5).Value = DBNull.Value
        Else
            arParms(5) = New SqlParameter("@Capacity", SqlDbType.Int)
            arParms(5).Value = EL.Capacity
        End If
        arParms(6) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("office")

     
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[proc_InsertResourceMaster]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    
    Shared Function GetGridData(ByVal EL As ElResourceMaster) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.id


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetResourceMaster]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal EL As ElResourceMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(7) {}


        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.id

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")
     

        arParms(4) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        arParms(5) = New SqlParameter("@ResourceType", SqlDbType.NVarChar, 50)
        arParms(5).Value = EL.ResourceType

        arParms(6) = New SqlParameter("@ResourceName", SqlDbType.NVarChar, 200)
        arParms(6).Value = EL.ResourceName

        If EL.Capacity = 0 Then
            arParms(7) = New SqlParameter("@Capacity", SqlDbType.Int)
            arParms(7).Value = DBNull.Value
        Else
            arParms(7) = New SqlParameter("@Capacity", SqlDbType.Int)
            arParms(7).Value = EL.Capacity
        End If




        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateResourceMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ChangeFlag(ByVal EL As ElResourceMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteResourceMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Public Function GetDuplicateResource(ByVal EL As ElResourceMaster) As Data.DataTable

        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}

        para(0) = New SqlParameter("@ResourceType", SqlDbType.NVarChar, 100)
        para(0).Value = EL.ResourceType

        para(1) = New SqlParameter("@ResourceName ", SqlDbType.NVarChar, 200)
        para(1).Value = EL.ResourceName

        para(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("BranchCode")
       
        para(3) = New SqlParameter("@id", SqlDbType.Int)
        para(3).Value = EL.id
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_SelectDuplicateResourceMaster", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    
End Class
