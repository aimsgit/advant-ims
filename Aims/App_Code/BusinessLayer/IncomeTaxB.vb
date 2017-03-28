Imports Microsoft.VisualBasic

Public Class IncomeTaxB
    Dim DAL As New IncomeTaxDA
    Dim prop As New IncomeTaxE
    Public Function grid(ByVal a As Integer) As Data.DataTable
        Return DAL.grid(a)
    End Function
    Public Function recovergrid() As Data.DataTable
        Return DAL.recovergrid()
    End Function
    Public Function delete(ByVal IT_id As Int64) As Integer
        Return DAL.delete(IT_id)
    End Function
    Public Function recover(ByVal IT_id As Int64) As Integer
        Return DAL.recover(IT_id)
    End Function
    Public Function update(ByVal prop As IncomeTaxE) As Int64
        Return DAL.update(prop)
    End Function
End Class

