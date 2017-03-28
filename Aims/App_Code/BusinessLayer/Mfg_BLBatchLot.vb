Imports Microsoft.VisualBasic

Public Class Mfg_BLBatchLot
    Dim DL As New Mfg_DLBatchLot
    Public Function InsertRecord(ByVal EL As Mfg_ELBatchLot) As Integer
        Return Mfg_DLBatchLot.Insert(EL)
    End Function

    Public Function UpdateRecord(ByVal EL As Mfg_ELBatchLot) As Integer
        Return Mfg_DLBatchLot.Update(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As Mfg_ELBatchLot) As Integer
        Return Mfg_DLBatchLot.ChangeFlag(EL)
    End Function

    Public Function GetGridData(ByVal Id As Integer) As DataTable
        Return Mfg_DLBatchLot.GetGridData(Id)
    End Function

    Public Function GetDuplicateShift(ByVal EL As Mfg_ELBatchLot) As DataTable
        Return DL.GetDuplicateShift(EL)
    End Function

End Class
