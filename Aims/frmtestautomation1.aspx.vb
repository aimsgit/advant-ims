
Partial Class frmtestautomation1
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then


            ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "changeColor();", True)
        End If
    End Sub
End Class
