Imports System.IO
Imports System.Collections.Generic

Partial Class PopFileSelection
    Inherits BasePage
    Dim dt As DataTable
    Dim configvalue As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dt = DLDocUpload.Getupload()
        If dt.Rows.Count > 0 Then
            configvalue = dt.Rows(0).Item(0)
            If Not IsPostBack Then
                Dim filePaths() As String = Directory.GetFiles(configvalue)
                Dim files As List(Of ListItem) = New List(Of ListItem)
                For Each filePath As String In filePaths
                    files.Add(New ListItem(Path.GetFileName(filePath), filePath))
                Next
                Listfile.DataSource = files
                Listfile.DataBind()
            End If
        End If
    End Sub

    'Protected Sub btnok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnok.Click
    '    Dim File As String = ""
    '    Dim Str As String = ""
    '    Dim i As Integer = 0
    '    For Each Item In Listfile.Items
    '        If (Listfile.Items(i).Selected = True) Then
    '            Str = configvalue + Listfile.Items(i).Value
    '            File = Str + "," + File
    '        End If
    '        i = i + 1
    '    Next
    '    ViewState("FileUpload") = File.Substring(0, File.Length - 1)
    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "callFunctionsStartupScript", "javascript:changeparent( '" + File.Substring(0, File.Length - 1) + "');", True)
    '    'Response.Write("<script language=javascript>window.opener.document.getElementById('txtemailids').value = '" + s + "';window.close();</script>");
    '    'Response.Write("<script language=javascript>alert(window.opener.document.getElementById('txtFrom').value)</script>")
    '    'Response.Write("<script language='javascript'> { self.close() }</script>")
    'End Sub

    Protected Sub btnclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Response.Write("<script language='javascript'> { self.close() }</script>")
    End Sub
End Class
