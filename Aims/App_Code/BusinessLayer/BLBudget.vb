Imports Microsoft.VisualBasic

Public Class BLBudget
    Dim DLBudget As New DLBudget
    Public Function Insert(ByVal Budget As Budget) As Int16
        Return DLBudget.Insert(Budget)
    End Function
    Public Function CheckDuplicate(ByVal Budget As Budget) As System.Data.DataTable
        Return DLBudget.CheckDuplicate(Budget)
    End Function
    Public Function Update(ByVal Budget As Budget) As Integer
        Return DLBudget.Update(Budget)
    End Function
    Public Function GetBudget(ByVal Budget As Budget) As Data.DataTable
        Return DLBudget.GetBudget(Budget)
    End Function
    Public Function DeleteBudget(ByVal id As Int64) As Integer
        Dim rowsaffected As Integer = DLBudget.DeleteBudget(id)
    End Function
    Public Function GetBudgetSearch(ByVal Budget As Budget) As Data.DataTable
        Return DLBudget.GetBudgetSearch(Budget)
    End Function
End Class
