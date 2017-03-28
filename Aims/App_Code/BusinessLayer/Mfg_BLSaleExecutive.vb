Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Public Class Mfg_BLSaleExecutive
    Dim dill As New Mfg_DLSaleExecutive
    Public Function InsertRecord(ByVal i As Mfg_ELSaleExecutive) As Integer
        Return dill.Insert(i)
    End Function
    Public Function UpdateRecord(ByVal i As Mfg_ELSaleExecutive) As Integer
        Return dill.Update(i)
    End Function
    Public Function getSale(ByVal id As Mfg_ELSaleExecutive) As Data.DataTable
        Return dill.getSales(id)
    End Function
    Public Function DeleteSale(ByVal s As Mfg_ELSaleExecutive) As Integer
        Return dill.DeleteSales(s)
    End Function
    Public Function CheckDuplicate(ByVal s As Mfg_ELSaleExecutive) As System.Data.DataTable
        Return dill.CheckDuplicate(s)
    End Function
End Class
