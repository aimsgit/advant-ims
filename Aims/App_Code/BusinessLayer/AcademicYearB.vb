Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class AcademicYearB
    Dim acy As New AcademicYearDB
    Public Function InsertRecord(ByVal EL As AcademicYear) As Integer
        Return AcademicYearDB.Insert(EL)
    End Function

    Public Function UpdateRecord(ByVal EL As AcademicYear) As Integer
        Return AcademicYearDB.Update(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As AcademicYear) As Integer
        Return AcademicYearDB.ChangeFlag(EL)
    End Function
    Public Function GetReportData() As DataTable
        Return AcademicYearDB.GetReportData()
    End Function
    Public Function GetGridData(ByVal Id As Integer) As DataTable
        Return AcademicYearDB.GetGridData(ID)
    End Function

    Public Function GetDuplicateYear(ByVal EL As String, ByVal id As Integer) As DataTable
        Return acy.GetDuplicateAcademicYear(EL, id)
    End Function
    Public Function GetDuplicateCurrentYear(ByVal id As Integer) As DataTable
        Return acy.GetDuplicateCurrentYear(id)
    End Function


End Class
