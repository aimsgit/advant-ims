Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BatchB
    Implements IDisposable
    Public Function BatchComboDT(ByVal Brnid As Long, ByVal Insid As Long, ByVal Crsid As Long) As DataTable
        Dim ds As DataSet = BatchDB.BatchCoursePlannerCombo(Brnid, Insid, Crsid)
        Return ds.Tables(0)
    End Function
    'Public Function GetBatch(ByVal id As Long) As List(Of Batch)
    '    Dim batch As New List(Of Batch)
    '    Dim ds As DataSet = BatchDB.GetBatch(id)

    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        batch.Add(New Batch(row("Batch_ID"), row("Batch_Name")))
    '    Next
    '    Return batch
    'End Function

    'Public Function GetBatch() As List(Of Batch)
    '    Dim batch As New List(Of Batch)
    '    Dim ds As DataSet = BatchDB.GetBatch(0)

    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        batch.Add(New Batch(row("Batch_ID"), row("Batch_Name")))
    '    Next
    '    Return batch
    'End Function

    'Public Function GetBatchByBatchID(ByVal Bid As Long) As Batch
    '    Dim ds As DataSet = BatchDB.GetBatch(Bid)
    '    Dim row As DataRow = ds.Tables(0).Rows(0)
    '    Dim batch As Batch = New Batch(row("Batch_ID"), row("Batch_Name"))
    '    Return batch
    'End Function

    'Public Function Insert(ByVal B As Batch) As Integer
    '    If B.BatchName = "" Then
    '        B.BatchName = ""
    '    End If
    '    Return BatchDB.Insert(B)
    'End Function
    'Public Function Update(ByVal B As Batch) As Integer
    '    If B.BatchName = Nothing Then
    '        B.BatchName = ""
    '    End If
    '    Return BatchDB.Update(B)
    'End Function
    'Public Function ChangeFlag(ByVal b As Batch) As Integer
    '    'Dim status As Boolean
    '    Return BatchDB.ChangeFlag(b.BatchID)
    'End Function

    Public Function BatchCombo(ByVal Brnid As Long, ByVal Insid As Long, ByVal Crsid As Long) As List(Of Batch)
        Dim batch As New List(Of Batch)
        Dim ds As DataSet = BatchDB.BatchCoursePlannerCombo(Brnid, Insid, Crsid)

        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            batch.Add(New Batch(row("ID"), row("Batch_No")))
        Next
        Return batch
    End Function
    Public Function BatchComboCourseplanner(ByVal id As Long) As BatchCombo
        Dim ds As DataSet = BatchDB.BatchCorsePlnnerCombobyCorse(id)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        Dim batch As BatchCombo = New BatchCombo(row("Batch_No"))
        Return batch
    End Function
    Public Function GetBatchForTimeTable(ByVal Branch_ID As Int64, ByVal Institute_ID As Int64, ByVal Course_ID As Int64) As List(Of Batch)
        Dim batch As New List(Of Batch)
        Dim ds As DataSet = BatchDB.GetBatchForTimeTable(Branch_ID, Institute_ID, Course_ID)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            batch.Add(New Batch(row("ID"), row("Batch_No")))
        Next
        Return batch
    End Function
    Private disposedValue As Boolean = False        ' To detect redundant calls
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub
#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class



