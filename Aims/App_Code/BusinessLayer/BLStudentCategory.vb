Imports Microsoft.VisualBasic

Public Class BLStudentCategory
    Public Function InsertStudentCategory(ByVal El As Category) As Integer
        Return DLStudentCategory.InsertStudentCategory(El)
    End Function
    Public Function GetDuplicateStudentCategory(ByVal El As Category) As Data.DataTable
        Return DLStudentCategory.GetDuplicateStudentCategory(El)
    End Function
    Public Function UpdateStudentCategory(ByVal El As Category) As Integer
        Return DLStudentCategory.UpdateStudentCategory(El)
    End Function
    Public Function DeleteStudentCategory(ByVal El As Category) As Integer
        Return DLStudentCategory.DeleteStudentCategory(El)
    End Function
    Public Function GetStudentcategory(ByVal id As Integer) As Data.DataTable
        Return DLStudentCategory.GetStudentcategory(id)
    End Function
End Class
