Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BLProjectMaster
    Public Function InsertRecord(ByVal PM As ELProjectMaster) As Integer
        Return DLProjectMaster.Insert(PM)
    End Function
    Public Function UpdateRecord(ByVal PM As ELProjectMaster) As Integer
        Return DLProjectMaster.Update(PM)
    End Function
    Public Function Display(ByVal PM As ELProjectMaster) As Data.DataTable
        Return DLProjectMaster.DisplayGridValue(PM)
    End Function
    Public Function duplicate(ByVal PM As ELProjectMaster) As Data.DataTable
        Return DLProjectMaster.Getduplicate(PM)
    End Function
    Public Function ChangeFlag(ByVal PM As ELProjectMaster) As Integer
        Return DLProjectMaster.ChangeFlag(PM)
    End Function
End Class
