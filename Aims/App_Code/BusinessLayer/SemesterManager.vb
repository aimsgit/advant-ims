Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class SemesterManager
    Dim DAL As New SemesterDB
    Public Function GetFullSemester() As List(Of Semester)
        Dim SemesterP As New List(Of Semester)
        Dim dt As Data.DataTable = DAL.GetSemester
        Dim dr As Data.DataRow
        For Each dr In dt.Rows
            SemesterP.Add(New Semester(dr("ID"), dr("AssessmentType")))
        Next
        Return SemesterP
    End Function
    Public Function DeleteAss(ByVal id As Integer) As Integer
        Dim rowsaffected As Integer
        rowsaffected = DAL.DeleteAss(id)
        Return rowsaffected
    End Function
    Public Function InsertAssessment(ByVal type As String) As Integer
        Dim rowsaffected As Integer
        rowsaffected = DAL.InsertAssessment(type)
        Return rowsaffected
    End Function
    Public Function InsertSemester(ByVal type As Semester) As Integer
        Dim rowsaffected As Integer
        rowsaffected = DAL.InsertSemester(type)
        Return rowsaffected
    End Function

    Public Function getData1() As DataTable
        Return DAL.getData1()
    End Function
    Public Function getData2(ByVal e As Semester) As DataTable
        Return DAL.getData2(e)
    End Function

    Public Function GetSemesterCombo() As List(Of Semester)
        Dim ds As DataSet = DAL.GVSemesterComboUser()
        Dim semestertype As New List(Of Semester)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            semestertype.Add(New Semester(row("ID"), row("AssessmentType")))
        Next
        Return semestertype
    End Function
    Public Function GetAssessmentCombo() As List(Of Semester)
        Dim ds As DataSet = DAL.GVSemesterComboUser()
        Dim semestertype As New List(Of Semester)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            semestertype.Add(New Semester(row("ID"), row("AssessmentType")))
        Next
        Return semestertype
    End Function
    Public Function RptAssessment(ByVal Office As String, ByVal BranchCode As String) As Data.DataTable
        Return SemesterDB.RptAssessment(Office, BranchCode)
    End Function
    Public Function Rptsemester(ByVal Office As String, ByVal BranchCode As String) As Data.DataTable
        Return SemesterDB.Rptsemester(Office, BranchCode)
    End Function
    Public Function UpdateAsse(ByVal sem As Semester) As Integer
        Dim rowsaffected As Integer
        rowsaffected = DAL.UpdateAsse(sem)
        Return rowsaffected
    End Function
    Public Function GetDuplicateSemesterMaster(ByVal EL As Semester) As DataTable
        Return DAL.GetDuplicateSemesterMaster(EL)
    End Function
    
End Class
