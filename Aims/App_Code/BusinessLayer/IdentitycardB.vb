Imports Microsoft.VisualBasic
Imports GlobalDataSetTableAdapters
Namespace IdentityCardA
    Public Class IdentityCardB
        Private _stdIdentityAdapter As IdentityCardTableAdapter = Nothing
        Public ReadOnly Property Adapter() As IdentityCardTableAdapter
            Get
                If _stdIdentityAdapter Is Nothing Then
                    _stdIdentityAdapter = New IdentityCardTableAdapter
                End If
                Return _stdIdentityAdapter
            End Get
        End Property
        'Public Function Update_Transaction(ByVal SIC As GlobalDataSet.IdentityCardDataTable) As Integer
        '    Return Adapter.UpdateWithTransaction(SIC)
        'End Function
    End Class
End Namespace


