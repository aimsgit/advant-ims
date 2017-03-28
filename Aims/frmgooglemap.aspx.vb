Imports System.Data.SqlClient

Partial Class frmgooglemap
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("LoginType").Equals("Others")) Then
            ddlRouteName.Enabled = False
        Else
            ddlRouteName.Enabled = True
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        Dim dt As New DataTable()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("select lat=Latitude,lng=Longitude from Gps_data where Route='" + ddlRouteName.SelectedValue + "' and Date=CONVERT(VARCHAR(10),GETDATE(),111) ", con)
                con.Open()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count() = 0 Then
                    lblmsg.Text = "No Records to Display."
                Else
                    lblmsg.Text = ""
                    Dim Route As String
                    Route = ddlRouteName.SelectedValue
                    'Dim SDate As String=txtDate.text
                    Dim qrystring As String = "googlemap.aspx?" & QueryStr.Querystring() & "&Route=" & Route
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                    msginfo.Text = ""
                End If

            End Using
        End Using
    End Sub
End Class
