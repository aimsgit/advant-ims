Imports Microsoft.VisualBasic

Public Class BLGradeMaster
    Public Function Insert(ByVal EL As ELGradeMaster) As Integer
        Return DLGradeMaster.Insert(EL)
    End Function
    Public Function GetData(ByVal EL As ELGradeMaster) As Data.DataTable
        Return DLGradeMaster.GetData(EL)
    End Function
    Public Function Update(ByVal EL As ELGradeMaster) As Integer
        Return DLGradeMaster.Update(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As ELGradeMaster) As Integer
        Return DLGradeMaster.ChangeFlag(EL)
    End Function
    Public Function GetDuplicate(ByVal EL As ELGradeMaster) As DataTable
        Return DLGradeMaster.GetDuplicateType(EL)
    End Function
    Public Function GetMinMax(ByVal EL As ELGradeMaster) As DataTable
        Return DLGradeMaster.GetMinMax(EL)
    End Function
End Class
