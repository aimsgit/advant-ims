Imports Microsoft.VisualBasic

Public Class FeeStructB
    Public Function finalExamRpt(ByVal Aid As Integer, ByVal Bid As Integer, ByVal Sid As Integer, ByVal Cid As Integer) As DataTable
        Return FeeStructD.finalExamRpt(Aid, Bid, Sid, Cid)
    End Function

    Public Function Sem() As DataTable
        Return FeeStructD.Semester()
    End Function

    Public Function Category() As DataTable
        Return FeeStructD.Category()
    End Function
End Class
