Imports System.Data.SqlClient

Partial Class Chatmain
    Inherits BasePage
    Dim user As String = ""
    Dim ID As String


    Protected Sub Btnok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnok.Click
        If (Session("user") <> "" And TextBox1.Text <> "") Then
            Dim con As SqlConnection = New SqlConnection(
                ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
            con.Open()
            Dim comm As SqlCommand = New SqlCommand("proc_InsertUserMsg", con)
            comm.CommandType = CommandType.StoredProcedure
            comm.Parameters.AddWithValue("@Msg", TextBox1.Text)
            comm.Parameters.AddWithValue("@Sender", HttpContext.Current.Session("ID"))
            comm.Parameters.AddWithValue("@Uid", HttpContext.Current.Session("user"))
            'Dim paramSender As SqlParameter = New SqlParameter( _
            '    "@Msg", SqlDbType.VarChar, 200)
            'paramSender.Value = TextBox1.Text
            'comm.Parameters.Add(paramSender)

            'Dim paramSender1 As SqlParameter = New SqlParameter( _
            '    "@Sender", SqlDbType.VarChar, 10)
            'paramSender.Value = "1"
            'comm.Parameters.Add(paramSender1)

            'Dim paramSender2 As SqlParameter = New SqlParameter( _
            '    "@Uid", SqlDbType.VarChar, 10)
            'paramSender.Value = HttpContext.Current.Session("ID")
            'comm.Parameters.Add(paramSender2)
            comm.ExecuteNonQuery()
            TextBox1.Text = ""
            'ScriptManager1.SetFocus(TextBox1.ClientID)
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            TextBox1.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + Btnok.ClientID + "').click();return false;}} else {return true}; ")
        End If
        'Page.Form.DefaultFocus = TextBox1.ClientID
    End Sub
    <System.Web.Services.WebMethod()> _
   Public Shared Sub Logout()
        Dim con As SqlConnection = New SqlConnection( _
             ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        con.Open()
        Dim comm As SqlCommand = New SqlCommand("stp_Message", con)
        comm.CommandType = CommandType.StoredProcedure
        Dim paramSender As SqlParameter = New SqlParameter( _
            "@Sender", SqlDbType.Int)
        paramSender.Value = HttpContext.Current.Session("ID")
        comm.Parameters.Add(paramSender)
        comm.ExecuteNonQuery()


        con = New SqlConnection( _
           ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        con.Open()
        comm = New SqlCommand("Proc_DeleteUser", con)
        comm.CommandType = CommandType.StoredProcedure
        paramSender = New SqlParameter( _
            "@ID", SqlDbType.Int)
        paramSender.Value = HttpContext.Current.Session("ID")
        comm.Parameters.Add(paramSender)
        comm.ExecuteNonQuery()


    End Sub
End Class
