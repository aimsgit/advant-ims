Imports Microsoft.VisualBasic

Public Class QueryStr
    Public Shared Sub GetValue(ByVal rq As System.Web.HttpRequest, ByVal prop As QureyStringP)
        'prop.brnCode = rq.QueryString(0)
        'prop.usercode = rq.QueryString(1)
        'HttpContext.Current.Session("BranchCode") = prop.brnCode
    End Sub
    Public Shared Function Querystring() As String
        Dim str As String = "BrnCode=" & HttpContext.Current.Session("BranchCode") & "&UserCode=" & HttpContext.Current.Session("UserCode")
        Return str
    End Function
End Class
