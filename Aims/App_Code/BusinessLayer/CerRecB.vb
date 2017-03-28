Imports Microsoft.VisualBasic
Imports GlobalDataSetTableAdapters
Public Class CerRecB
    Private _CerrecAdapter As CertificateReceivedTableAdapter = Nothing
    Public ReadOnly Property Adapter() As CertificateReceivedTableAdapter
        Get
            If _CerrecAdapter Is Nothing Then
                _CerrecAdapter = New CertificateReceivedTableAdapter
            End If
            Return _CerrecAdapter
        End Get
    End Property
    'Public Function UpdateWithTransaction(ByVal Cerrec As GlobalDataSet.CertificateReceivedDataTable) As Integer
    '    Return Adapter.UpdateWithTransaction(Cerrec)
    'End Function
End Class
