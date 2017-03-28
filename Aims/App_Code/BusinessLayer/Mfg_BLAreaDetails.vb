Imports Microsoft.VisualBasic

Public Class Mfg_BLAreaDetails
    Dim DL As New Mfg_DLAreaDetails
    Public Function InsertRecord(ByVal EL As Mfg_ELAreaDetails) As Integer
        Return Mfg_DLAreaDetails.Insert(EL)
    End Function

    Public Function UpdateRecord(ByVal EL As Mfg_ELAreaDetails) As Integer
        Return Mfg_DLAreaDetails.Update(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As Mfg_ELAreaDetails) As Integer
        Return Mfg_DLAreaDetails.ChangeFlag(EL)
    End Function

    Public Function GetGridData(ByVal Id As Integer) As DataTable
        Return Mfg_DLAreaDetails.GetGridData(Id)
    End Function

    Public Function GetDuplicateYear(ByVal EL As String, ByVal id As Integer) As DataTable
        Return DL.GetDuplicateAreaDetails(EL, id)
    End Function
End Class
