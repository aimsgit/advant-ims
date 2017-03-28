Imports Microsoft.VisualBasic

Public Class Mfg_BLStockIssue
    Dim DL As New Mfg_DLStockIssue
    Public Function InsertProductReceipe(ByVal EL As Mfg_ElStockIssue) As Integer
        Return DL.InsertProductReceipe(EL)
    End Function
    Public Function UpdateProductReceipe(ByVal EL As Mfg_ElStockIssue) As Integer
        Return DL.UpdateProductReceipe(EL)
    End Function
    Public Function getProductExpiry(ByVal EL As Mfg_ElStockIssue) As DataTable
        Return DL.getProductExpiry(EL)
    End Function
    Public Function getProductReceipe(ByVal EL As Mfg_ElStockIssue) As DataTable
        Return DL.getProductReceipe(EL)
    End Function
    Public Function DeteteProductReceipe(ByVal EL As Mfg_ElStockIssue) As Integer
        Return DL.DeteteProductReceipe(EL)
    End Function
    Public Function getProductDetailsReceipe(ByVal EL As Mfg_ElStockIssue) As DataTable
        Return DL.getProducyDetailsReceipe(EL)
    End Function
End Class
