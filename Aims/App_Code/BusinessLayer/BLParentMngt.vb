Imports Microsoft.VisualBasic

Public Class BLParentMngt
    Dim dll As New DLParentMngt
    Public Function SearchParent(ByVal U As ELParentMngt) As Data.DataTable
        Return dll.SearchParent(U)
    End Function
    Public Function GetParentDetails(ByVal U As ELParentMngt) As Data.DataTable
        Return DLParentMngt.GetParentDetails(U)
    End Function
    Public Function InsertRecord(ByVal g As ELParentMngt) As Integer
        Return DLParentMngt.InsertParentManagement(g)
    End Function
    Public Function DeleteRecord(ByVal g As ELParentMngt) As Integer
        Return DLParentMngt.DeleteParentDetails(g)
    End Function
    Public Function UpdateRecord(ByVal g As ELParentMngt) As Integer
        Return DLParentMngt.UpdateParentDetails(g)
    End Function
    Public Function GetDuplicateUser(ByVal EL As ELParentMngt) As DataTable
        Return dll.GetDuplicateUser(EL)
    End Function
End Class

