Imports Microsoft.VisualBasic

Public Class BLAssetTransferNew
    Public Function Insert(ByVal EL As ELAssetTansferNew) As Integer
        Return DLAssetTransferNew.Insert(EL)
    End Function
    Public Function Update(ByVal EL As ELAssetTansferNew) As Integer
        Return DLAssetTransferNew.Update(EL)
    End Function
    Public Function Delete(ByVal EL As ELAssetTansferNew) As Integer
        Return DLAssetTransferNew.delete(EL)
    End Function

    Public Function GetAssetTransfer(ByVal e As ELAssetTansferNew) As Data.DataTable
        Return DLAssetTransferNew.GetAssetTransfer(e)
    End Function
    Public Function GetAssetTransfer1(ByVal e As ELAssetTansferNew) As Data.DataTable
        Return DLAssetTransferNew.GetAssetTransfer1(e)
    End Function


    Public Function GetAddAssetTransfer(ByVal e As String) As Data.DataTable
        Return DLAssetTransferNew.GetAddAssetTransfer(e)
    End Function
End Class
