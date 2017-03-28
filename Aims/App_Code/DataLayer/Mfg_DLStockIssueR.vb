Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_DLStockIssueR
    Shared Function BatchCombo(ByVal ProductId As Integer) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        param(1) = New SqlParameter("@ProductId", SqlDbType.Int)
        param(1).Value = ProductId
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ProductBatches", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function ProductUnit(ByVal ProductId As Integer) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        param(1) = New SqlParameter("@ProductId", SqlDbType.Int)
        param(1).Value = ProductId
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ProductUnit", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function ProductBatchAvailability(ByVal ProductId As Integer, ByVal BatchId As Integer) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        param(1) = New SqlParameter("@ProductId", SqlDbType.Int)
        param(1).Value = ProductId

        param(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        param(2).Value = BatchId
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ProductBatchAvailability", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function getProductExpiry(ByVal ProductId As Integer, ByVal BatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@ProductId", SqlDbType.Int)
        arParms(2).Value = ProductId

        arParms(3) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(3).Value = BatchId

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetProductBatchExipry", arParms)
        Return ds.Tables(0)
    End Function
    Public Function InsertStockIssueDetails(ByVal EL As Mfg_StockIssue) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@StockIssueNo", SqlDbType.VarChar)
        arParms(0).Value = EL.IssueNo
        'arParms(0).Value = EL.StockIssueId
        arParms(1) = New SqlParameter("@ProductId", SqlDbType.Int)
        arParms(1).Value = EL.ProductId
        arParms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(2).Value = EL.BatchId
        arParms(3) = New SqlParameter("@QtyIssued", SqlDbType.Int)
        arParms(3).Value = EL.QtyIssued
        arParms(4) = New SqlParameter("@Remarks", SqlDbType.VarChar)
        arParms(4).Value = EL.Remarks
        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")
        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")
        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertStkIssueDetailsR", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function UpdateStockIssueDetails(ByVal EL As Mfg_StockIssue) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.id
        'arParms(0).Value = EL.StockIssueId
        arParms(1) = New SqlParameter("@ProductId", SqlDbType.Int)
        arParms(1).Value = EL.ProductId
        arParms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(2).Value = EL.BatchId
        arParms(3) = New SqlParameter("@QtyIssued", SqlDbType.Int)
        arParms(3).Value = EL.QtyIssued
        arParms(4) = New SqlParameter("@Remarks", SqlDbType.VarChar)
        arParms(4).Value = EL.Remarks
        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")
        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")
        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateStkIssueDetailsR", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function GridviewStockIssueDetails(ByVal EL As Mfg_StockIssue) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@Id", SqlDbType.Int)
        param(1).Value = EL.id
        param(2) = New SqlParameter("@StockIssueNo", SqlDbType.VarChar)
        param(2).Value = EL.IssueNo
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GridviewStockIssueDetails", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Delete row of Stock Issue Details
    Public Function DeteteStockIssueDetails(ByVal EL As Mfg_StockIssue) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteStockIssueDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Public Function GetStockIssueNo() As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(0) {}
        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockIssueNo", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function GetDelivaryChallanNo() As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(0) {}
        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockIssueDCNo", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function InsertStockIssue(ByVal EL As Mfg_StockIssue) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(11) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@StockIssueNo", SqlDbType.VarChar)
        arParms(0).Value = EL.IssueNo
        arParms(1) = New SqlParameter("@DCNo", SqlDbType.VarChar)
        arParms(1).Value = EL.DCNo
        arParms(2) = New SqlParameter("@IssueDate", SqlDbType.DateTime)
        arParms(2).Value = EL.EntryDate
        arParms(3) = New SqlParameter("@SO_Id", SqlDbType.Int)
        arParms(3).Value = EL.WorkOrder
        arParms(4) = New SqlParameter("@IndentNo", SqlDbType.VarChar)
        arParms(4).Value = EL.IndentNo
        arParms(5) = New SqlParameter("@DONo", SqlDbType.VarChar)
        arParms(5).Value = EL.DONo
        arParms(6) = New SqlParameter("@PartyType", SqlDbType.Int)
        arParms(6).Value = EL.PartyType
        arParms(7) = New SqlParameter("@PartyId", SqlDbType.Int)
        arParms(7).Value = EL.PartyName
        arParms(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("UserCode")
        arParms(9) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("EmpCode")
        arParms(10) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("BranchCode")
        arParms(11) = New SqlParameter("@IssuedBy", SqlDbType.Int)
        arParms(11).Value = HttpContext.Current.Session("EmpID")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertStkIssueR", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function UpdateStockIssue(ByVal EL As Mfg_StockIssue) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(12) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.id
        'arParms(0).Value = EL.StockIssueId
        arParms(1) = New SqlParameter("@StockIssueNo", SqlDbType.VarChar)
        arParms(1).Value = EL.IssueNo
        arParms(2) = New SqlParameter("@DCNo", SqlDbType.VarChar)
        arParms(2).Value = EL.DCNo
        arParms(3) = New SqlParameter("@IssueDate", SqlDbType.DateTime)
        arParms(3).Value = EL.EntryDate
        arParms(4) = New SqlParameter("@SO_Id", SqlDbType.Int)
        arParms(4).Value = EL.WorkOrder
        arParms(5) = New SqlParameter("@IndentNo", SqlDbType.VarChar)
        arParms(5).Value = EL.IndentNo
        arParms(6) = New SqlParameter("@DONo", SqlDbType.VarChar)
        arParms(6).Value = EL.DONo
        arParms(7) = New SqlParameter("@PartyType", SqlDbType.Int)
        arParms(7).Value = EL.PartyType
        arParms(8) = New SqlParameter("@PartyId", SqlDbType.Int)
        arParms(8).Value = EL.PartyName
        arParms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("UserCode")
        arParms(10) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("EmpCode")
        arParms(11) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("BranchCode")
        arParms(12) = New SqlParameter("@IssuedBy", SqlDbType.Int)
        arParms(12).Value = HttpContext.Current.Session("EmpID")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateStkIssueR", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function GridviewStockIssueMain(ByVal EL As Mfg_StockIssue) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@Id", SqlDbType.Int)
        param(2).Value = EL.id
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GridviewStockIssue", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Delete row of Stock Issue Main
    Public Function DeteteStockIssue(ByVal EL As Mfg_StockIssue) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@StockIssueId", SqlDbType.Int)
        arParms(0).Value = EL.StockIssueId
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteStockIssueMainR", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function GetWorkOrderDDL() As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(0) {}
        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_WorkOrderDDLR", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Post stock from Stock Issue
    Public Function PostToStockIssue(ByVal EL As Mfg_StockIssue) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")
        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")
        arParms(3) = New SqlParameter("@StockIssueId", SqlDbType.Int)
        arParms(3).Value = EL.StockIssueId
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_PostStockIssue", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    'Check Post Status of Stock Issue
    Public Function CheckStockIssuePostStatus(ByVal EL As Mfg_StockIssue) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@Id", SqlDbType.Int)
        param(2).Value = EL.id
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_CheckStockIssuePostStatus", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function CheckStockIssuePostStatusMain(ByVal EL As Mfg_StockIssue) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@StockIssueId", SqlDbType.Int)
        param(2).Value = EL.id
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_CheckStockIssuePostStatusMain", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function PrintStockIssueNote(ByVal IssueNo As String) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@IssueNo", SqlDbType.VarChar)
        param(2).Value = IssueNo
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_RptStockIssueNote", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
