Imports Microsoft.VisualBasic

Public Class SMSTempleteBL
    Dim Dl As New SMSTempleteDL
    Public Function InsertSMSTemplete(ByVal EL As SMSTempleteEL) As Integer
        Dim rowsaffected As Integer
        rowsaffected = Dl.InsertSMSTemplete(EL)
        Return rowsaffected
    End Function
    Public Function GetSMSTemplete(ByVal EL As SMSTempleteEL) As DataTable
        Return Dl.GetSMSTemplete(EL)
    End Function
    Public Function UpdateSMSTemplete(ByVal EL As SMSTempleteEL) As Integer
        Dim rowsaffected As Integer
        rowsaffected = Dl.UpdateSMSTemplete(EL)
        Return rowsaffected
    End Function
    Public Function GetDuplicateSMSTemplete(ByVal EL As SMSTempleteEL) As DataTable
        Return Dl.GetDuplicateSMSTemplete(EL)
    End Function
    Public Function DeleteSMSTemplete(ByVal id As Integer) As Integer
        Dim rowsaffected As Integer
        rowsaffected = Dl.DeleteSMSTemplete(id)
        Return rowsaffected
    End Function
End Class
