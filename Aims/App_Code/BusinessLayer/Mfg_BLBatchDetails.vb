Imports Microsoft.VisualBasic

Public Class Mfg_BLBatchDetails
    Dim DL As Mfg_DLBatchDetails
    Public Function getDetails(ByVal EL As Mfg_ELBatchDetails) As Data.DataTable
        Return Mfg_DLBatchDetails.getDetails(EL)
    End Function
    Public Function InsertRecord(ByVal EL As Mfg_ELBatchDetails) As Integer
        Return Mfg_DLBatchDetails.Insert(EL)
    End Function
    Public Function UpdateRecord(ByVal EL As Mfg_ELBatchDetails) As Integer
        Return Mfg_DLBatchDetails.Update(EL)
    End Function
    Public Function DeleteRecord(ByVal id As Long) As Integer
        Return Mfg_DLBatchDetails.Delete(id)
    End Function
    Public Function GetBatchDetails(ByVal EL As Mfg_ELBatchDetails) As System.Data.DataTable
        Return Mfg_DLBatchDetails.GridviewDetails(EL)
    End Function
    Public Function GetDuplicate(ByVal EL As Mfg_ELBatchDetails) As DataTable
        Return Mfg_DLBatchDetails.GetDuplicateType(EL)
    End Function
End Class
