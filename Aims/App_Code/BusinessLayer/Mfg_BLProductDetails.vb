Imports Microsoft.VisualBasic

Public Class Mfg_BLProductDetails
    Dim dill As New Mfg_DLProductDetails
    Public Function InsertRecord(ByVal i As Mfg_ELProductDetails) As Integer
        Return dill.Insert(i)
    End Function
    Public Function UpdateRecord(ByVal i As Mfg_ELProductDetails) As Integer
        Return dill.Update(i)
    End Function
    Public Function getProduct(ByVal id As Mfg_ELProductDetails) As Data.DataTable
        Return dill.getProduct(id)
    End Function
    Public Function DeleteProduct(ByVal s As Mfg_ELProductDetails) As Integer
        Return dill.DeleteProduct(s)
    End Function
    Public Function CheckDuplicate(ByVal s As Mfg_ELProductDetails) As System.Data.DataTable
        Return dill.CheckDuplicate(s)
    End Function
End Class
