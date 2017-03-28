Imports Microsoft.VisualBasic

Public Class B_PaymentMethos
    Dim PD As New Data_PaymentMethod
    Dim PE As New Entity_PaymentMethod
    Public Function grid(ByVal PE As Entity_PaymentMethod) As Data.DataTable
        Return PD.GetPaymentType(PE)
    End Function
    Public Function GetPaymentType(ByVal PE As Entity_PaymentMethod) As Data.DataTable
        Return PD.GetPaymentType(PE)
    End Function

    Public Function Insert(ByVal PE As Entity_PaymentMethod) As Integer
        Return PD.Insert(PE)
    End Function

    Public Function changeFlag(ByVal id As Integer) As Integer
        Return PD.ChangeFlag(id)
    End Function
    Public Function Update(ByVal PE As Entity_PaymentMethod) As Integer
        Return PD.Update(PE)
    End Function

    Public Function GetPayDuplicate(ByVal PE As Entity_PaymentMethod) As DataTable
        Return Data_PaymentMethod.GetPayDuplicate(PE)
    End Function
End Class
