Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class DesignationManager
    Public Function GetDesiganation(ByVal DesignationP As DesignationP) As System.Data.DataTable
        'Dim dataSet As DataSet = 
        Return DesignationDB.GetDesignation(DesignationP)
        'Return dataSet
    End Function
    Public Function UpdateRecord(ByVal c As DesignationP) As Integer
        Return DesignationDB.UpdateRecord(c)
    End Function
    Public Function InsertRecord(ByVal i As DesignationP) As Integer
        Return DesignationDB.Insert(i)
    End Function
    Public Function ChangeFlag(ByVal id As Long) As Integer
        'Dim Status As Boolean
        'Status = globalcnn.Del_Validation(c.Id, "CourseMaster")
        'If (Status) = True Then
        '    Exit Function
        'End If
        Return DesignationDB.ChangeFlag(id)
    End Function
    'Public Function RptDesignation(ByVal Inst As Int64, ByVal Brch As Int64) As Data.DataTable
    '    Return DesignationDB.RptDesignation(Inst, Brch)
    'End Function
    Public Function GetDuplicateNameType(ByVal DesignationP As DesignationP) As DataTable
        Dim DDB As New DesignationDB
        Return DDB.GetDuplicateName(DesignationP)
    End Function
End Class
