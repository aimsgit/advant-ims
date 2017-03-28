Imports Microsoft.VisualBasic

Public Class Mfg_BLRStockIssue
    Dim DL As New Mfg_DLStockIssueR
    Public Function InsertStockIssueDetails(ByVal EL As Mfg_StockIssue) As Integer
        Return DL.InsertStockIssueDetails(EL)
    End Function
    Public Function UpdateStockIssueDetails(ByVal EL As Mfg_StockIssue) As Integer
        Return DL.UpdateStockIssueDetails(EL)
    End Function
    Public Function GridviewStockIssueDetails(ByVal EL As Mfg_StockIssue) As DataTable
        Return DL.GridviewStockIssueDetails(EL)
    End Function
    Public Function GetStockIssueNo() As DataTable
        Return DL.GetStockIssueNo()
    End Function
    Public Function GetDelivaryChallanNo() As DataTable
        Return DL.GetDelivaryChallanNo()
    End Function
    Public Function DeteteStockIssueDetails(ByVal EL As Mfg_StockIssue) As Integer
        Return DL.DeteteStockIssueDetails(EL)
    End Function
    'Public Function getProductDetailsReceipe(ByVal EL As Mfg_StockIssue) As DataTable
    '    Return DL.getProducyDetailsReceipe(EL)
    'End Function
    Public Function InsertStockIssue(ByVal EL As Mfg_StockIssue) As Integer
        Return DL.InsertStockIssue(EL)
    End Function
    Public Function UpdateStockIssue(ByVal EL As Mfg_StockIssue) As Integer
        Return DL.UpdateStockIssue(EL)
    End Function
    'Public Function GridviewStockIssue(ByVal EL As Mfg_StockIssue) As DataTable
    '    Return DL.GridviewStockIssue(EL)
    'End Function
    'Public Function DeteteStockIssue(ByVal EL As Mfg_StockIssue) As Integer
    '    Return DL.DeteteStockIssue(EL)
    'End Function
    Public Function GridviewStockIssueMain(ByVal EL As Mfg_StockIssue) As DataTable
        Return DL.GridviewStockIssueMain(EL)
    End Function
    Public Function DeteteStockIssue(ByVal EL As Mfg_StockIssue) As Integer
        Return DL.DeteteStockIssue(EL)
    End Function
    Public Function PostToStockIssue(ByVal EL As Mfg_StockIssue) As Integer
        Return DL.PostToStockIssue(EL)
    End Function
    Public Function CheckStockIssuePostStatus(ByVal EL As Mfg_StockIssue) As DataTable
        Return DL.CheckStockIssuePostStatus(EL)
    End Function
    Public Function CheckStockIssuePostStatusMain(ByVal EL As Mfg_StockIssue) As DataTable
        Return DL.CheckStockIssuePostStatusMain(EL)
    End Function
End Class
