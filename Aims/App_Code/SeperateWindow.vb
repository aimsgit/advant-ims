Imports Microsoft.VisualBasic

Public Class SeperateWindow
    Public Shared Function SepWindow() As String
        Dim str As String = "BrnCode=" & HttpContext.Current.Session("BranchCode") & "&UsrCode=" & HttpContext.Current.Session("UserCode") & "&EmCode=" & HttpContext.Current.Session("EmpCode")
        Return str
    End Function
End Class
