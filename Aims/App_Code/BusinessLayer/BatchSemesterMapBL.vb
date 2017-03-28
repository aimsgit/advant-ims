Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BatchSemesterMapBL

    Public Function GetBatchCombo() As Data.DataTable
        Dim department As New List(Of BatchSemesterMap)
        Dim ds As DataSet = BatchSemesterMapDB.getBatch()
        Return ds.Tables(0)
    End Function

    Public Function UpdateRecord(ByVal BSM As BatchSemesterMap) As Integer
        Return BatchSemesterMapDB.Update(BSM)
    End Function

    Public Function GetCategory(ByVal BSM As BatchSemesterMap) As Data.DataTable
        Dim ds As DataSet = BatchSemesterMapDB.getBatchSemMap(BSM)
        Return ds.Tables(0)
    End Function

    Public Function ChangeFlag(ByVal BSM As BatchSemesterMap) As Integer
        Return BatchSemesterMapDB.ChangeFlag(BSM)
    End Function
    'Code for get Batch Semester Map Report By Nitin 09/05/2012
    'Public Function RptBatchSemesterMap(ByVal BSM As BatchSemesterMap) As Data.DataTable
    '    Return BatchSemesterMapDB.RptBatchSemesterMap(BSM)
    'End Function

End Class
