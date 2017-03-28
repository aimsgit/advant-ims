Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class CategoryManager
    Public Function GetCategoryRpt() As Data.DataTable
        Dim dt As DataTable = CategoryDB.GetCategoryRpt()
        Return dt
    End Function
    Public Function GetDepartment() As Data.DataTable
        Dim department As New List(Of Department)
        Dim ds As DataSet = CategoryDB.getDepartment()
        Return ds.Tables(0)
    End Function
    Public Function CheckDuplicate(ByVal i As Category) As System.Data.DataTable
        Return CategoryDB.CheckDuplicate(i)
    End Function

    Public Function GetCategory(ByVal Dept_ID As Category) As Data.DataTable
        'Dim category As New List(Of Category)
        Dim ds As DataSet = CategoryDB.getCategory(Dept_ID)
        'Dim row As DataRow
        'For Each row In ds.Tables(0).Rows
        '    category.Add(New Category(row("Category_Id"), row("CategoryName")))
        'Next
        Return ds.Tables(0)
        'Dim category As New List(Of Category)
        'Dim ds As DataSet = CategoryDB.getCategory()
        'Dim row As DataRow
        'For Each row In ds.Tables(0).Rows
        '    category.Add(New Category(row("Category_Id"), row("CategoryName")))
        'Next
        'Return category
    End Function
    Public Function GetCategoryByCategoryId(ByVal id As Long) As Category
        Dim category As New Category
        Dim ds As DataSet = CategoryDB.getCategory(id)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            category = New Category(row("Category_Id"), row("CategoryName"))
        End If
        Return category
    End Function
    Public Function GetCategories(ByVal Dept_ID As Integer) As DataSet
        Dim dataSet As New DataSet
        dataSet = CategoryDB.getCategory(Dept_ID)
        Return dataSet
        'Dim dataSet As New DataSet
        'dataSet = CategoryDB.GetCategory()
        'Return dataSet
    End Function
    Public Function UpdateRecord(ByVal i As Category) As Integer
        Return CategoryDB.Update(i)
    End Function
    Public Function InsertRecord(ByVal i As Category) As Integer
        Return CategoryDB.Insert(i)
    End Function
    Public Function ChangeFlag(ByVal id As Long) As Integer
        'Dim Status As Boolean
        'Status = globalcnn.Del_Validation(c.Id, "CourseMaster")
        'If (Status) = True Then
        '    Exit Function
        'End If
        Return CategoryDB.ChangeFlag(id)
    End Function
End Class
