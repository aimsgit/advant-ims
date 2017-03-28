Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class AssetDB
    'Shared Function GetAsset(ByVal id As Long) As System.Data.DataSet

    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

    '    Dim ds As DataSet
    '    Try
    '        If id = 0 Then
    '            Dim arParms() As SqlParameter = New SqlParameter(1) {}
    '            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
    '            arParms(0).Value = HttpContext.Current.Session("Office")
    '            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '            arParms(1).Value = HttpContext.Current.Session("BranchCode")

    '            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAssetMasterDetails", arParms)

    '        Else
    '            Dim arParms() As SqlParameter = New SqlParameter(0) {}
    '            arParms(0) = New SqlParameter("@id", SqlDbType.Int)
    '            arParms(0).Value = id

    '            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAssetMasterDetailsByAssetID", arParms)
    '        End If
    '    Catch e As Exception
    '        ds = New DataSet
    '    End Try
    '    Return ds

    'End Function
    Shared Function GetAssetByid(ByVal ID As Long) As Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(0).Value = ID

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAssetByid")
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal Ast As Asset) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@name", SqlDbType.VarChar, Ast.Name.Length)
        arParms(0).Value = Ast.Name

        arParms(1) = New SqlParameter("@code", SqlDbType.VarChar, Ast.Code.Length)
        arParms(1).Value = Ast.Code

        arParms(2) = New SqlParameter("@remarks", SqlDbType.VarChar, Ast.Remarks.Length)
        arParms(2).Value = Ast.Remarks

        'arParms(3) = New SqlParameter("@assettype", SqlDbType.Int)
        'arParms(3).Value = Ast.AssetType

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@empCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("empCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@IssuedTo", SqlDbType.VarChar, Ast.IssuedTo.Length)
        arParms(6).Value = Ast.IssuedTo

        arParms(7) = New SqlParameter("@issueDate", SqlDbType.Date)
        arParms(7).Value = Ast.IssueDate

        arParms(8) = New SqlParameter("@returnDate", SqlDbType.Date)
        arParms(8).Value = Ast.ReturnDate

        arParms(9) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(9).Value = Ast.depid

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveAssetMasterDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal Ast As Asset) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@name", SqlDbType.VarChar, Ast.Name.Length)
        arParms(0).Value = Ast.Name

        arParms(1) = New SqlParameter("@code", SqlDbType.VarChar, Ast.Code.Length)
        arParms(1).Value = Ast.Code

        arParms(2) = New SqlParameter("@remarks", SqlDbType.VarChar, Ast.Remarks.Length)
        arParms(2).Value = Ast.Remarks

        'arParms(3) = New SqlParameter("@assettype", SqlDbType.Int)
        'arParms(3).Value = Ast.AssetType

        arParms(3) = New SqlParameter("@Asset_ID", SqlDbType.Int)
        arParms(3).Value = Ast.Asset_ID

        arParms(4) = New SqlParameter("@IssuedTo", SqlDbType.VarChar, Ast.IssuedTo.Length)
        arParms(4).Value = Ast.IssuedTo

        arParms(5) = New SqlParameter("@empCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("empCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@issuedate", SqlDbType.Date)
        arParms(7).Value = Ast.IssueDate

        arParms(8) = New SqlParameter("@returndate", SqlDbType.Date)
        arParms(8).Value = Ast.ReturnDate

        arParms(9) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(9).Value = Ast.depid

        arParms(10) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateAssetMasterDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Long) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteAssetMasterDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GVAssetComboUser(ByVal ID As Int64) As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(0).Value = ID
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAssetByid", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetCommName(ByVal Ast As Asset) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        Dim ds As New DataSet
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Asset_ID", SqlDbType.Int)
        arParms(2).Value = Ast.Asset_ID
        arParms(3) = New SqlParameter("@AssetName", SqlDbType.VarChar, 50)
        arParms(3).Value = Ast.Name
        arParms(4) = New SqlParameter("@IssuedTo", SqlDbType.VarChar, 50)
        arParms(4).Value = Ast.IssuedTo
        arParms(5) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(5).Value = Ast.depid

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ViewAsset", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetDuplicate(ByVal id As Integer, ByVal Ast As Asset) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@AssetCode", SqlDbType.VarChar, 100)
        para(1).Value = Ast.Code
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = id
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDuplicateAsset", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetDatEmpCode(ByVal prefixText As String) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
        arParms(0) = New SqlParameter("@EmpName", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetEmpExt", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function getAssetName(ByVal prefixText As String) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
        arParms(0) = New SqlParameter("@AssetName", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAssetName", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'report generate method'
    Public Function Rpt_AssetAllc(ByVal issuedto As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@IssuedTo", SqlDbType.VarChar, 20)
        arParms(2).Value = issuedto

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_AssetAllocation", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
