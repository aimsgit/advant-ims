Imports Microsoft.VisualBasic

Public Class Mfg_BLPaymentReceived
    Public Function getDetails(ByVal EL As Mfg_ElPaymentMade) As Data.DataTable
        Return Mfg_DLPaymentReceived.GridviewDetails(EL)
    End Function
    Public Function InsertRecord(ByVal EL As Mfg_ElPaymentMade, ByVal PR As String) As Integer
        Return Mfg_DLPaymentReceived.Insert(EL, PR)
    End Function
  
    Public Function UpdateRecord(ByVal EL As Mfg_ElPaymentMade) As Integer
        Return Mfg_DLPaymentReceived.Update(EL)
    End Function
    Public Function DeleteRecord(ByVal id As Long) As Integer
        Return Mfg_DLPaymentReceived.Delete(id)
    End Function
    Public Function Getbuyerdetails(ByVal EL As Mfg_ElPaymentMade) As Data.DataTable
        Return Mfg_DLPaymentReceived.Getbuyerdetails(EL)
    End Function
    Public Function amtpaid(ByVal EL As Mfg_ElPaymentMade) As Data.DataTable
        Return Mfg_DLPaymentReceived.amtpaid(EL)
    End Function
End Class
