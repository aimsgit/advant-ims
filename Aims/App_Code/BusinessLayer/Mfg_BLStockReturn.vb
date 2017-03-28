Imports Microsoft.VisualBasic

Public Class Mfg_BLStockReturn
    Dim DLL As New Mfg_DLStockReturn
    Public Function insert(ByVal EL As Mfg_ELStockReturn) As Integer
        Return DLL.Insert(EL)
    End Function
    Public Function Insertrecord(ByVal EL As Mfg_ELStockReturn) As Integer
        Return DLL.Insertrecord(EL)
    End Function
    Public Function UpdateRecord(ByVal EL As Mfg_ELStockReturn) As Integer
        Return DLL.UpdateRecord(EL)
    End Function
    Public Function update(ByVal EL As Mfg_ELStockReturn) As Integer
        Return DLL.Update(EL)
    End Function
    Public Function GetStockReturnM(ByVal EL As Mfg_ELStockReturn) As DataTable
        Return DLL.GetStockReturnM(EL)
    End Function
    Public Function GetStockReturnNo(ByVal EL As Mfg_ELStockReturn) As DataTable
        Return DLL.GetStockReturnNo(EL)
    End Function
    'Public Function SelectProductName(ByVal Supplier As Integer, ByVal id As Integer) As DataTable
    '    Return DLL.SelectProductName(Supplier, id)
    'End Function
    Public Function DeleteStockReturn(ByVal EL As Mfg_ELStockReturn) As Integer
        Return DLL.DeleteStockReturn(EL)
    End Function

    Public Function DeleteStockReturnD(ByVal EL As Mfg_ELStockReturn) As Integer
        Return DLL.DeleteStockReturnD(EL)
    End Function
    Public Function GetStockReturnDetails(ByVal EL As Mfg_ELStockReturn) As DataTable
        Return DLL.GetStockReturnDetails(EL)
    End Function
    Public Function PostToStockReturn(ByVal i As Mfg_ELStockReturn) As Integer
        Return DLL.PostToStockReturn(i)
    End Function
  
End Class
