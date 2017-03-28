Imports Microsoft.VisualBasic
Imports System.Data.SqlClient


Public Class DLAssetTransferNew
    Public Function GetAssetname(ByVal Assettype As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@AssetType", SqlDbType.Int)
        Parms(0).Value = Assettype
        Parms(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ddlAssetNameAndCode", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetAssetNameAll(ByVal Assettype As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@AssetType", SqlDbType.Int)
        Parms(0).Value = Assettype
        Parms(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ddlAssetNameAll", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal EL As ELAssetTansferNew) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@AssetType", SqlDbType.Int)
        arParms(0).Value = EL.AssetType

        arParms(1) = New SqlParameter("@AssetName", SqlDbType.Int)
        arParms(1).Value = EL.AssetName

        arParms(2) = New SqlParameter("@FromBranch", SqlDbType.VarChar, 250)
        arParms(2).Value = EL.FromBranch

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")

        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@DateOfTransfer", SqlDbType.DateTime)
        arParms(6).Value = EL.AssetDate

        arParms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(7).Value = EL.Remarks

        arParms(8) = New SqlParameter("@ToBranch", SqlDbType.VarChar, 50)
        arParms(8).Value = EL.ToBranch
        Try
            rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_InsertAssetTransferNew", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function Update(ByVal EL As ELAssetTansferNew) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@AssetType", SqlDbType.Int)
        arParms(0).Value = EL.AssetType

        arParms(1) = New SqlParameter("@AssetName", SqlDbType.Int)
        arParms(1).Value = EL.AssetName

        arParms(2) = New SqlParameter("@FromBranch", SqlDbType.VarChar, 50)
        arParms(2).Value = EL.FromBranch

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")

        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@DateOfTransfer", SqlDbType.DateTime)
        arParms(6).Value = EL.AssetDate

        arParms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(7).Value = EL.Remarks

        arParms(8) = New SqlParameter("@ToBranch", SqlDbType.VarChar, 50)
        arParms(8).Value = EL.ToBranch

        arParms(9) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(9).Value = EL.id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateAssetTransfer", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function GetAssetTransfer(ByVal el As ELAssetTansferNew) As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = el.id
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetAssetTransfer", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetAssetTransfer1(ByVal el As ELAssetTansferNew) As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = el.id
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetAssetTransfer1", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetAddAssetTransfer(ByVal ID As String) As Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
        arParms(2).Value = ID

        Dim ds As DataSet

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAddAssetTransferNew", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function delete(ByVal EL As ELAssetTansferNew) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteAssetTransferNew", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
End Class
