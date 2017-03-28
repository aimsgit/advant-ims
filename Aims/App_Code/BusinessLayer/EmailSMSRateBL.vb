Imports Microsoft.VisualBasic
Imports System.Data

Public Class EmailSMSRateBL
    Shared Function InsertEmailSMSRate(ByVal ESMS As EmailSMSRate) As Integer
        Return EmailSMSRateDL.InsertEmailSMSRate(ESMS)
    End Function
    Shared Function UpdateEmailSMSRate(ByVal ESMS As EmailSMSRate) As Integer
        Return EmailSMSRateDL.UpdateEmailSMSRate(ESMS)
    End Function
    Shared Function DeleteEmailSMSRate(ByVal ESMS As EmailSMSRate) As Integer
        Return EmailSMSRateDL.DeleteEmailSMSRate(ESMS)
    End Function
    Shared Function EmailSMSRateGridview(ByVal ESMS As EmailSMSRate) As Data.DataTable
        Return EmailSMSRateDL.EmailSMSRateGridview(ESMS)
    End Function
    Public Function GetClientCombo() As Data.DataTable
        Return EmailSMSRateDL.GetClientCombo()
    End Function
    Public Function GetBranchCombo(ByVal Mycode As String) As Data.DataTable
        Return EmailSMSRateDL.GetBranchCombo(Mycode)
    End Function
    Shared Function GetSMSRateGridview(ByVal Id As Integer) As Data.DataTable
        Return EmailSMSRateDL.GetSMSRateGridview(Id)
    End Function
End Class
