Imports Microsoft.VisualBasic

Public Class BLAccountGroupMapping
    Public Function GetAccounSubGroup(ByVal EL As ELAccountGroupMapping) As DataTable
        Return DLAccountGroupMapping.GetAccounSubGroup(EL)
    End Function
    Public Function GetClientAccounSubGroup(ByVal EL As ELAccountGroupMapping) As DataTable
        Return DLAccountGroupMapping.GetClientAccounSubGroup(EL)
    End Function
    Public Function Update(ByVal EL As ELAccountGroupMapping) As Integer
        Return DLAccountGroupMapping.Update(EL)
    End Function
    Public Function GetAccounSubGroup2(ByVal EL As ELAccountGroupMapping) As DataTable
        Return DLAccountGroupMapping.GetAccounSubGroup2(EL)
    End Function
End Class
