Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class ConfigProcManager
    Public Function GetTableName() As DataTable
        Dim dataSet As DataSet = GetConfigProcDB.GetTableName
        Return dataSet.Tables(0)
    End Function
    Public Function GetConfigProc() As DataSet
        Dim dataSet As DataSet = GetConfigProcDB.GetConfigProc
        Return dataSet
    End Function
    Public Function UpdateRecord(ByVal i As ConfigProcessP) As Integer
        Return GetConfigProcDB.Update(i)
    End Function
    Public Function UpdateTable(ByVal i As ConfigProcessP) As Integer
        Return GetConfigProcDB.UpdateTables(i)
    End Function
    Public Function InsertRecord(ByVal i As ConfigProcessP) As Integer
        Return GetConfigProcDB.Insert(i)
    End Function
    Public Function ChangeFlag(ByVal id As Long) As Integer
        'Dim Status As Boolean
        'Status = globalcnn.Del_Validation(c.Id, "CourseMaster")
        'If (Status) = True Then
        '    Exit Function
        'End If
        Return GetConfigProcDB.ChangeFlag(id)
    End Function
End Class
