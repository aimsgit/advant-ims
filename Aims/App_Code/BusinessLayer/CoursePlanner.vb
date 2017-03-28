Imports Microsoft.VisualBasic
Imports GlobalDataSetTableAdapters
Imports System.Collections.Generic
Public Class CoursePlanner
    Dim DAL As New CoursePlannerDB
    'Public Function GetSubject1(ByVal ID As Int64) As List(Of CourcePlanner.CoursePlannerP)
    '    Dim Cp As New List(Of CourcePlanner.CoursePlannerP)
    '    Dim DAL As New CoursePlannerDB
    '    Dim ds As Data.DataTable = DAL.GetSubject(ID)
    '    Dim row As DataRow
    '    For Each row In ds.Rows
    '        Cp.Add(New CourcePlanner.CoursePlannerP(row("Subject_ID"), row("SubjectName")))
    '    Next
    '    Return Cp
    'End Function
    Public Function GetCoursePlannerRpt(ByVal Courseid As Long, ByVal InsId As Long, ByVal BranchId As Long) As DataTable
        Dim dt As New DataTable
        dt = DAL.GetCoursePlannerRpt(Courseid, InsId, BranchId)
        Return dt
    End Function
    Public Function getSelectCourse(ByVal BranId As Int64, ByVal InsId As Int64) As Data.DataTable
        Dim DAL As New GlobalDataSetTableAdapters.CoursePlannerDB
        Return DAL.GetSelectCourse(BranId, InsId)
    End Function

    Public Function GetData(ByVal ID As Int64) As Data.DataTable
        Return DAL.GetData(ID)
    End Function
    Public Function GetCheckBatch(ByVal branchID As Int64, ByVal InsID As Int64, ByVal CourseID As Int64, ByVal Batchno As String) As Boolean
        Return DAL.GetBatchAvail(branchID, InsID, CourseID, Batchno)
    End Function
    Public Function GetBatch(ByVal branchID As Int64, ByVal InsID As Int64, ByVal CourseID As Int64) As DataTable
        Return DAL.GetBatch(branchID, InsID, CourseID)
    End Function
    Public Function GetDataforGV(ByVal branchID As Int64, ByVal InsID As Int64, ByVal CourseID As Int64) As DataTable
        Return DAL.GetDataForGV(branchID, InsID, CourseID)
    End Function
    Public Function Update(ByVal Prop As CourcePlanner.CoursePlannerP) As Int16
        Return DAL.UpdateCp(Prop)
    End Function
    Public Function DeleteSub(ByVal Id As Int64) As Int16
        Return DAL.Delete(Id)
    End Function
    Public Function DELUpdate(ByVal ID As Int64) As Int64
        Return DAL.DELUpdate(ID)
    End Function
    'Private _courseplannersubjectAdapter As CoursePlannerSubjectTableAdapter = Nothing
    'Public ReadOnly Property Adapter() As CoursePlannerSubjectTableAdapter
    '    Get
    '        If _courseplannersubjectAdapter Is Nothing Then
    '            _courseplannersubjectAdapter = New CoursePlannerSubjectTableAdapter
    '        End If
    '        Return _courseplannersubjectAdapter
    '    End Get
    'End Property
    'Public Function UpdateWithTransaction(ByVal Subject As GlobalDataSet.CoursePlannerSubjectDataTable) As Integer
    '    Return Adapter.UpdateWithTransaction(Subject)
    'End Function
End Class
