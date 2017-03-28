Imports Microsoft.VisualBasic

Public Class BLOverTime
    Dim DL As New DLOverTime
    Public Function AutoGenerateNo(ByVal EL As ELOverTime) As Data.DataTable
        Return DLOverTime.AutoGenerateNo(EL)
    End Function
    Public Function InsertRecordOT(ByVal EL As ELOverTime) As Integer
        Return DLOverTime.InsertRecordOT(EL)
    End Function
    Public Function GetGridDataOT(ByVal EL As ELOverTime) As DataTable
        Return DLOverTime.GetGridDataOT(EL)
    End Function
    Public Function UpdateOT(ByVal EN As ELOverTime) As Integer
        Return DLOverTime.UpdateOT(EN)
    End Function
    Public Function ChangeFlagOT(ByVal EN As ELOverTime) As Integer
        Return DLOverTime.ChangeFlagOT(EN)
    End Function
    Public Function AutoGenerateNo1(ByVal EL As LoanSettlementEL) As Data.DataTable
        Return DLOverTime.AutoGenerateNo1(EL)
    End Function
    Public Function AutoGenerateLoanDetails(ByVal EL As LoanSettlementEL) As Data.DataTable
        Return DLOverTime.AutoGenerateLoanDetails(EL)
    End Function
    Public Function UpdateLoanSettlement(ByVal EN As LoanSettlementEL) As Integer
        Return DLOverTime.UpdateLoanSettlement(EN)
    End Function
    Public Function InsertLoanSettlement(ByVal EN As LoanSettlementEL) As Integer
        Return DLOverTime.InsertLoanSettlement(EN)
    End Function
    Public Function GetEmp(ByVal id As LoanSettlementEL) As Data.DataTable
        Return DL.getRecords(id)
    End Function

    Public Function AutoGenerateSType(ByVal EL As LoanSettlementEL) As Data.DataTable
        Return DLOverTime.AutoGenerateSType(EL)
    End Function
End Class
