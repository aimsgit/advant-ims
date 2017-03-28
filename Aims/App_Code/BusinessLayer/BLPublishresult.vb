Imports Microsoft.VisualBasic

Public Class BLPublishresult
    Dim DL As New DLPublishResult
    Public Function UpdateRecord(ByVal EL As ELPublishResult) As Integer
        Return DLPublishResult.Update(EL)
    End Function
    Public Function GetGridData(ByVal EL As ELPublishResult) As DataTable
        Return DLPublishResult.GetGridData(EL)
    End Function
End Class
