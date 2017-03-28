Imports Microsoft.VisualBasic
Imports System.Data.DataTable
Public Class BookSearchB
    Dim Dt As Data.DataTable
    Dim DAL As New BookSearchD
    Public Function BookSearch(ByVal prop As BookSearch) As Data.DataTable
        Return DAL.BookSearch(prop)
    End Function
End Class
