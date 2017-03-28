Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System

Public Class CourseManager
    'Implements IDisposable
    Public Function GetCourse(ByVal id As Course) As Data.DataTable
        'Dim ds As DataSet = CourseDB.GetCourse(id)
        Return CourseDB.GetCourse(id)
    End Function
    'Public Function GetCourseALLBatchRpt(ByVal courseid As Long, ByVal BrnId As Long, ByVal insId As Long) As DataTable
    '    Dim dt As DataTable = CourseDB.GetCourseALLBatchRpt(courseid, BrnId, insId)
    '    Return dt
    'End Function
    Public Function GetCourseBatchGDSRpt(ByVal courseid As Long, ByVal BrnId As Long, ByVal insId As Long, ByVal CPID As Long) As DataTable
        Dim dt As DataTable = CourseDB.GetCourseBatchGDSRpt(courseid, BrnId, insId, CPID)
        Return dt
    End Function

    Public Function InsertRecord(ByVal c As Course) As Integer
        Return CourseDB.Insert(c)
    End Function
    Public Function UpdateRecord(ByVal c As Course) As Integer
        Return CourseDB.Update(c)
    End Function
    Public Function ChangeFlag(ByVal c As Course) As Integer
        'Dim Status As Boolean
        'Status = globalcnn.Del_Validation(c.Course_ID, "CourseMaster")
        'If (Status) = True Then
        '    Exit Function
        'End If
        Return CourseDB.ChangeFlag(c.Course_ID)
    End Function
    Public Function CourseCoursePlannerCombo(ByVal Brnid As Int64, ByVal Insid As Int64) As List(Of CourseFCPCombo)
        Dim CCP As New List(Of CourseFCPCombo)
        Dim ds As DataSet = CourseDB.CourseCoursePlannerCombo(Brnid, Insid)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            CCP.Add(New CourseFCPCombo(row("Course_ID"), row("Course")))
        Next
        Return CCP
    End Function
    Public Function GetcourseTypescombo() As Data.DataTable
        Return CourseDB.GetcourseTypescombo()
    End Function
    Public Function GetStreamTypescombo() As Data.DataTable
        Return CourseDB.GetStreamTypescombo()
    End Function
    Public Function CheckDuplicate(ByVal c As Course) As Data.DataTable
        Return CourseDB.CheckDuplicate(c)
    End Function
    'Public Function CourseFrmDispCourse() As Data.DataTable
    '    'Return CourseDB.CourseFrmDispCourse()
    'End Function
    Public Function CourseByType(ByVal id As Int64) As Data.DataTable
        Return CourseDB.CourseByType(id)
    End Function
    'Public Function GetCourseRpt(ByVal Insid As Int64, ByVal Brnid As Int64) As Data.DataTable
    '    Return CourseDB.GetCourseRpt(Insid, Brnid)
    'End Function
    'Private disposedValue As Boolean = False        ' To detect redundant calls
    ' IDisposable
    'Protected Overridable Sub Dispose(ByVal disposing As Boolean)
    '    If Not Me.disposedValue Then
    '        If disposing Then
    '            ' TODO: free unmanaged resources when explicitly called
    '        End If

    '        ' TODO: free shared unmanaged resources
    '    End If
    '    Me.disposedValue = True
    'End Sub

    '#Region " IDisposable Support "
    '    ' This code added by Visual Basic to correctly implement the disposable pattern.
    '    Public Sub Dispose() Implements IDisposable.Dispose
    '        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '        Dispose(True)
    '        GC.SuppressFinalize(Me)
    '    End Sub
    '#End Region
End Class
