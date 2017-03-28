Imports Microsoft.VisualBasic

Public Class Mfg_BLDescription
    Dim dill As New Mfg_DLDescription
    Public Function InsertRecord(ByVal i As Mfg_ELDescription) As Integer
        Return dill.Insert(i)
    End Function
    Public Function UpdateRecord(ByVal i As Mfg_ELDescription) As Integer
        Return dill.Update(i)
    End Function
    Public Function getDescription(ByVal id As Mfg_ELDescription) As Data.DataTable
        Return dill.getDescription(id)
    End Function
    Public Function DeleteDescription(ByVal s As Mfg_ELDescription) As Integer
        Return dill.DeleteDescription(s)
    End Function
    Public Function CheckDuplicate(ByVal s As Mfg_ELDescription) As System.Data.DataTable
        Return dill.CheckDuplicate(s)
    End Function
End Class
