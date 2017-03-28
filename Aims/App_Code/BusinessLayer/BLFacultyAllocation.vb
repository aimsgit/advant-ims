Imports Microsoft.VisualBasic

Public Class BLFacultyAllocation
    Shared Function getduplicate(ByVal EL As ELFacultyAllocation) As DataTable
        Return DLFacultyAllocation.getduplicate(EL)
    End Function
    Shared Function generate(ByVal EL As ELFacultyAllocation) As Integer
        Return DLFacultyAllocation.generate(EL)
    End Function
    Shared Function GetData(ByVal EL As ELFacultyAllocation) As DataTable
        Return DLFacultyAllocation.GetData(EL)
    End Function
    Shared Function CheckLock(ByVal EL As ELFacultyAllocation) As DataTable
        Return BLFacultyAllocation.CheckLock(EL)
    End Function
    Shared Function clear(ByVal EL As ELFacultyAllocation) As Integer
        Return DLFacultyAllocation.clear(EL)
    End Function
    Shared Function Lock(ByVal EL As ELFacultyAllocation) As Integer

        Return DLFacultyAllocation.Lock(EL)
    End Function
    Shared Function UnLock(ByVal EL As ELFacultyAllocation) As Integer

        Return DLFacultyAllocation.UnLock(EL)
    End Function
    Shared Function Update(ByVal EL As ELFacultyAllocation) As Integer

        Return DLFacultyAllocation.Update(EL)
    End Function
End Class
