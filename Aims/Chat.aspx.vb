Imports System.Data.SqlClient

Partial Class Chat
    Inherits BasePage

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('AddTech.aspx',null,'toolbar=no,scrollbars=no,location=no,resizable =no,width=330,height=220,left=100,top=100')</script>", False)
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim con As SqlConnection = New SqlConnection( _
            ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        con.Open()
        Dim comm As SqlCommand = New SqlCommand("Proc_DeleteAllUser", con)
        comm.CommandType = CommandType.StoredProcedure
        comm.ExecuteNonQuery()
    End Sub
End Class
