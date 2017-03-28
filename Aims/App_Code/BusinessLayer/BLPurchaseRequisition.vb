Imports Microsoft.VisualBasic

Public Class BLPurchaseRequisition
    Dim DLPurchaseRequisition As New DLPurchaseRequisition
    Public Function InsertRecord(ByVal b As ELPurchaseRequisition) As Integer
        Return DLPurchaseRequisition.Insert(b)
    End Function
    Public Function UpdateRecord(ByVal b As ELPurchaseRequisition) As Integer
        Return DLPurchaseRequisition.UpdateRecord(b)
    End Function
    Public Function InsertRecord1(ByVal b As ELPurchaseRequisition) As Integer
        Return DLPurchaseRequisition.Insert1(b)
    End Function
    Public Function getProductforPurchaseReq(ByVal el As ELPurchaseRequisition) As DataTable
        Return DLPurchaseRequisition.getProductforPurchaseReq(el)
    End Function
    Public Function UpdateRecord1(ByVal b As ELPurchaseRequisition) As Integer
        Return DLPurchaseRequisition.UpdateRecord1(b)
    End Function
    Public Function checkSubmit(ByVal b As ELPurchaseRequisition) As DataTable
        Return DLPurchaseRequisition.checkSubmit(b)
    End Function
    Public Function GetRecord(ByVal b As ELPurchaseRequisition) As DataTable
        Return DLPurchaseRequisition.GetRecord(b)
    End Function
    Public Function GetRecord1(ByVal b As ELPurchaseRequisition) As DataTable
        Return DLPurchaseRequisition.GetRecord1(b)
    End Function
    Public Function DeleteRecord(ByVal id As Long) As Integer
        Return DLPurchaseRequisition.DeleteRecord(id)
    End Function
    Public Function DeleteRecord1(ByVal id As Long) As Integer
        Return DLPurchaseRequisition.DeleteRecord1(id)
    End Function
    Public Function PostRequest(ByVal id As String) As Integer
        Return DLPurchaseRequisition.PostRequest(id)
    End Function
    Public Function GetUnit(ByVal EL As ELPurchaseRequisition) As DataTable
        Return DLPurchaseRequisition.GetUnit(EL)
    End Function
    Public Function GetPONo() As DataTable
        Return DLPurchaseRequisition.GetPONo()
    End Function
End Class
