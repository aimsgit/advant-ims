Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BRS
    Public Function GetBRSRpt() As DataSet
        Dim dataSet As New DataSet
        dataSet = BRSDB.GetBRSRpt
        Return dataSet
    End Function
    Public Function GetBRS(ByVal el As BRSEntity) As System.Data.DataTable
        Return BRSDB.GetBRS(el)
    End Function
    Public Function Update(ByVal el As BRSEntity) As Integer
        Return BRSDB.Update(el)
    End Function
End Class
