Imports Microsoft.VisualBasic

Public Class BLReceiveAssetReport
    Dim RA As New DLReceiveAssetReport
    Public Function ReceiveAssetReoprt(ByVal AT As String) As Data.DataTable
        Return RA.ReceiveAssetReport(AT)
    End Function
End Class
