Imports Microsoft.VisualBasic
Imports GlobalDataSetTableAdapters
Imports System.Collections.Generic
Imports System.Data
Public Class ManufacturerManager
    Dim m As New ManufacturerDB
    'Public Shared Function GetManufacturerNameById(ByVal id As Long) As List(Of ManufacturerE)
    '    Dim manufacturername As New List(Of ManufacturerE)
    '    Dim ds As DataSet = ManufacturerDB.GetManufacturer(id)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        manufacturername.Add(New ManufacturerE(row("ManuFacturer_Id"), row("Manufacturer")))
    '    Next
    '    Return manufacturername
    'End Function
    'Public Function GetManufacturerRpt() As DataTable
    '    Dim ds As DataSet = ManufacturerDB.GetManufacturer(0)
    '    Return ds.Tables(0)
    'End Function
    Public Function GetManufacturer(ByVal e As ManufacturerE) As DataTable
        Return m.GetManufacturer(e)
    End Function
    'Public Function GetManufacturer() As List(Of ManufacturerE)
    '    Dim manufacturername As New List(Of ManufacturerE)
    '    Dim ds As DataSet = ManufacturerDB.GetManufacturer(0)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        manufacturername.Add(New ManufacturerE(row("ManuFacturer_Id"), row("Manufacturer")))
    '    Next
    '    Return manufacturername
    'End Function
    Public Function InsertRecord(ByVal mf As ManufacturerE) As Integer
        Return ManufacturerDB.Insert(mf)
    End Function
    Public Function UpdateRecord(ByVal mf As ManufacturerE) As Integer
        'If mf.Name = Nothing Then
        '    mf.Name = ""
        'End If
        Return ManufacturerDB.Update(mf)
    End Function
    'Public Function ChangeFlag(ByVal mf As ManufacturerE) As Integer
    '    Return ManufacturerDB.ChangeFlag(mf)
    'End Function
    Public Function GetDuplicateManfMaster(ByVal EL As ManufacturerE) As DataTable
        Return m.GetDuplicateManfMaster(EL)
    End Function
    Public Function Delete(ByVal id As Integer) As Integer
        Dim rowsaffected As Integer
        rowsaffected = m.Delete(id)
        Return rowsaffected
    End Function
End Class
