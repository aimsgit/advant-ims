Imports Microsoft.VisualBasic
Public Class loanmasterB
    Dim DAL As New loanmasterDA
    Dim prop As New loanmasterE
    Public Function GetEmp(ByVal id As loanmasterE) As Data.DataTable
        Return DAL.getRecords(id)
    End Function
   
    Public Function insertRecord(ByVal Prop As loanmasterE) As Integer
        Return DAL.insertRecord(Prop)
    End Function
    Public Function update(ByVal prop As loanmasterE) As Int64
        Return DAL.update(prop)
    End Function
    Public Sub delete(ByVal LoanId As Int64)
        DAL.delete(LoanId)
    End Sub
    Public Function GetDuplicateLoanMaster(ByVal id As loanmasterE) As Data.DataTable
        Return DAL.GetDuplicateLoanMaster(id)
    End Function

End Class

