Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class CourseTypeB
    Public Function GetcourseTypescombo() As Data.DataTable
        Return CourseTypeDB.GetcourseTypescombo()
    End Function
    Public Function InsertMethod(ByVal C As CourseType) As Integer
        Return CourseTypeDB.Insert(C)
    End Function
    Public Function UpdateMethod(ByVal C As CourseType) As Integer
        Return CourseTypeDB.Update(C)
    End Function
    Public Function ChangeFlag(ByVal id As Integer) As Integer
        Return CourseTypeDB.ChangeFlag(id)
    End Function
    Public Function GetcourseTypes(ByVal id As CourseType) As Data.DataTable
        Return CourseTypeDB.CourseType(id)
    End Function
    Public Function Coursetypeduplicate(ByVal c As CourseType) As Data.DataTable
        Return CourseTypeDB.Coursetypeduplicate(c)
    End Function
End Class
