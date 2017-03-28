Imports Microsoft.VisualBasic

Public Class BLInvestmentMaster
    Dim DL As New DLInvestmentMaster
    Public Function InsertRecord(ByVal EM As ELInvestmentMaster) As Integer
        Return DLInvestmentMaster.Insert(EM)
    End Function
    Public Function UpdateRecord(ByVal EM As ELInvestmentMaster) As Integer
        Return DLInvestmentMaster.Update(EM)
    End Function
    Public Function Display(ByVal EM As ELInvestmentMaster) As Data.DataTable
        Return DLInvestmentMaster.DisplayGridValue(EM)
    End Function
    'Public Function CheckDuplicate(ByVal EM As ELInvestmentMaster) As Data.DataTable
    '    Return DL.Duplicate(EM)
    'End Function
End Class
