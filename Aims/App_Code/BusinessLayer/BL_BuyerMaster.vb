Imports Microsoft.VisualBasic

Public Class BL_BuyerMaster
    Public Function InsertRecord(ByVal NS As EL_BuyerMaster) As Integer
        Return DL_BuyerMaster.Insert(NS)
    End Function
    Public Function UpdateRecord(ByVal NS As EL_BuyerMaster) As Integer
        Return DL_BuyerMaster.Update(NS)
    End Function
    Public Function DeleteRecord(ByVal id As Long) As Integer
        Return DL_BuyerMaster.Delete(id)
    End Function
  
    Public Function GridviewDetails(ByVal NS As EL_BuyerMaster) As System.Data.DataTable
        Return DL_BuyerMaster.GridviewDetails(NS)
    End Function
    Public Function GetDuplicateBuyerMaster(ByVal NS As EL_BuyerMaster) As DataTable
        Return DL_BuyerMaster.GetDuplicateType(NS)
    End Function
End Class

