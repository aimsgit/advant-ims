Imports Microsoft.VisualBasic

Public Class BLLoanTypeMaster
    Public Function InsertRecord(ByVal EL As ELLoanTypeMaster) As Integer
        Return DLLoanTypeMaster.Insert(EL)
    End Function
    Public Function GetGridData(ByVal Id As Integer) As DataTable
        Return DLLoanTypeMaster.GetGridData(Id)
    End Function
    Public Function ChangeFlag(ByVal EN As ELLoanTypeMaster) As Integer
        Return DLLoanTypeMaster.ChangeFlag(EN)
    End Function
    Public Function UpdateRecord(ByVal EL As ELLoanTypeMaster) As Integer
        Return DLLoanTypeMaster.Update(EL)
    End Function

End Class
