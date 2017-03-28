Imports Microsoft.VisualBasic

Public Class Mfg_BLUnit
    Dim dill As New Mfg_DLUnit
    Public Function InsertRecord(ByVal i As Mfg_ELUnit) As Integer
        Return dill.Insert(i)
    End Function
    Public Function UpdateRecord(ByVal i As Mfg_ELUnit) As Integer
        Return dill.Update(i)
    End Function
    Public Function getUnit(ByVal id As Mfg_ELUnit) As Data.DataTable
        Return dill.getUnit(id)
    End Function
    Public Function DeleteUnit(ByVal s As Mfg_ELUnit) As Integer
        Return dill.DeleteUnit(s)
    End Function
    Public Function CheckDuplicate(ByVal s As Mfg_ELUnit) As System.Data.DataTable
        Return dill.CheckDuplicate(s)
    End Function
End Class
