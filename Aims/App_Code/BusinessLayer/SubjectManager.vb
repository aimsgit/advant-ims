Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class SubjectManager
    Dim DAL As New SubjectDB
    Public Function getGVSubjectMaster(ByVal id As Subject) As Data.DataTable
        Return DAL.getGVSubjectMaster(id)
    End Function
    Public Function GetSubjectBySubjectId(ByVal id As Long) As Subject
        'Dim ds As DataSet = BranchDB.GetBranch(id)
        Dim row As DataRow '= ds.Tables(0).Rows(0)
        Dim subject As Subject = New Subject(row("Subject_ID"), row("Subject_Code"), row("Subject_Name"))
        Return subject
    End Function
    'Public Function GetSubject1(ByVal Course_ID As Integer, ByVal Batch_No As Integer) As System.Data.DataTable
    '    Return SubjectDB.GetSubject(Course_ID, Batch_No)
    'End Function
    'Public Function Insert(ByVal Name As String, ByVal Code As String, ByVal Max As Int64, ByVal Min As Int64, ByVal groupcode As String) As Int16
    Public Function Insert(ByVal s As Subject) As Int16
        Return DAL.Insert(s)
    End Function

    Public Function GetBatchWiseSubject(ByVal Batch As Int64) As Data.DataTable
        Return DAL.GetBatchWiseSubject(Batch)
    End Function
    Public Function GetFullSubject() As Data.DataTable
        Return DAL.GetBatchFullSubject
    End Function
    Public Function getGVSubjectMaster() As Data.DataTable
        Dim dt As New DataTable
        Dim s As New Subject
        dt = DAL.getGVSubjectMaster(s)
        Return dt
    End Function
    Public Function DeleteGVSubjectMaster(ByVal s As Subject) As Integer
        Dim rowsaffected As Integer = DAL.DeleteGVSubjectMaster(s)
    End Function
    Public Function delsubjectValidation(ByVal id As Integer) As Boolean
        Dim sdt As New DataTable
        sdt = DAL.delsubjectValidation(id)
        If IsDBNull(sdt.Rows(0)(0)) And IsDBNull(sdt.Rows(0)(1)) And IsDBNull(sdt.Rows(0)(2)) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function CheckDuplicate(ByVal s As Subject) As System.Data.DataTable
        Return DAL.CheckDuplicate(s)
    End Function
    'Public Function Update(ByVal Name As String, ByVal Code As String, ByVal Max As Int64, ByVal Min As Int64, ByVal GroupCode As String, ByVal id As Int32) As Int16
    Public Function Update(ByVal S As Subject) As Integer
        'If GroupCode = "" Then
        '    GroupCode = "0"
        'End If
        'Return DAL.Update(Name, Code, Max, Min, GroupCode, id)
        Return DAL.Update(S)
    End Function
    Public Function GetSubject_TimeTable(ByVal Id As Int64) As Data.DataTable
        Return DAL.GetSubject_TimeTable(Id)
    End Function
    'Public Function GetSubjID() As SubjectCombo
    '    Dim subj As SubjectCombo
    '    Dim ds As DataSet = SubjectDB.GetSubject(0)
    '    Dim row As DataRow = ds.Tables(0).Rows(0)
    '    subj = New SubjectCombo(row("Subject_Name"), row("Subject_ID"))
    '    Return subj
    'End Function
    'Public Function getSubjectMasterRpt(ByVal Office As String, ByVal BranchCode As String) As Data.DataTable
    '    Return DAL.getSubjectMasterRpt(Office, BranchCode)
    'End Function
End Class
