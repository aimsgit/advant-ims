Imports Microsoft.VisualBasic

Public Class Entity_PaymentMethod
    Private _PaymentMethodID As Int64
    Public Property PaymentMethodID() As Int64
        Get
            Return _PaymentMethodID
        End Get
        Set(ByVal value As Int64)
            _PaymentMethodID = value
        End Set
    End Property

    Private _Payment_Method As String
    Public Property Payment_Method() As String
        Get
            Return _Payment_Method
        End Get
        Set(ByVal value As String)
            _Payment_Method = value
        End Set
    End Property

    Private _Del_Flag As Boolean
    Public Property Del_Flag() As Boolean
        Get
            Return _Del_Flag
        End Get
        Set(ByVal value As Boolean)
            _Del_Flag = value
        End Set
    End Property

    Public Sub New()

    End Sub
End Class
