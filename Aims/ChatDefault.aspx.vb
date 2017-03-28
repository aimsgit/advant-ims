

Partial Public Class ChatDefault
    Inherits BasePage
    'Dim user As String = ""
    'Dim ID As String

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    '    lblUser.Text = "Hi " & Session("Name") & " Welcome to AIMS Support Application."
    '    Dim ID As Integer = Integer.Parse(Session("ID"))


    '    'msgPanel.Style.Add("overflow-y", "scroll")
    '    'Repeater1.DataSource = ds
    '    'Repeater1.DataBind()


    '    hidCurrentUser.Value = Session("ID")
    '    'HttpContext.Current.User.Identity.Name
    '    'dsrcWebChat.SelectCommand = "select * from OnlineUsers where Del_Flag = 'N' and UserID = " + ID + ""
    '    'dsrcWebChat.ConnectionString = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    'End Sub

    'Private Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    '    Dim con As SqlConnection = New SqlConnection( _
    '        ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
    '    con.Open()
    '    Dim comm As SqlCommand = New SqlCommand("stp_Message", con)
    '    comm.CommandType = CommandType.StoredProcedure
    '    Dim paramSender As SqlParameter = New SqlParameter( _
    '        "@Sender", SqlDbType.Int)
    '    paramSender.Value = Session("ID")
    '    comm.Parameters.Add(paramSender)
    '    comm.ExecuteNonQuery()


    '    con = New SqlConnection( _
    '       ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
    '    con.Open()
    '    comm = New SqlCommand("Proc_DeleteUser", con)
    '    comm.CommandType = CommandType.StoredProcedure
    '    paramSender = New SqlParameter( _
    '        "@ID", SqlDbType.Int)
    '    paramSender.Value = HttpContext.Current.Session("ID")
    '    comm.Parameters.Add(paramSender)
    '    comm.ExecuteNonQuery()
    '    Session("user") = ""
    '    Response.Redirect("frmsupportlogin.aspx")
    'End Sub
    '<System.Web.Services.WebMethod()> _
    'Public Shared Sub Logout()
    '    Dim con As SqlConnection = New SqlConnection( _
    '         ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
    '    con.Open()
    '    Dim comm As SqlCommand = New SqlCommand("stp_Message", con)
    '    comm.CommandType = CommandType.StoredProcedure
    '    Dim paramSender As SqlParameter = New SqlParameter( _
    '        "@Sender", SqlDbType.Int)
    '    paramSender.Value = HttpContext.Current.Session("ID")
    '    comm.Parameters.Add(paramSender)
    '    comm.ExecuteNonQuery()


    '    con = New SqlConnection( _
    '       ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
    '    con.Open()
    '    comm = New SqlCommand("Proc_DeleteUser", con)
    '    comm.CommandType = CommandType.StoredProcedure
    '    paramSender = New SqlParameter( _
    '        "@ID", SqlDbType.Int)
    '    paramSender.Value = HttpContext.Current.Session("ID")
    '    comm.Parameters.Add(paramSender)
    '    comm.ExecuteNonQuery()


    'End Sub

    'Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    '    Repeater1.DataSource = Nothing
    '    Repeater1.DataBind()
    '    Repeater1.DataSourceID = "dsrcWebChat"
    '    Repeater1.DataBind()

    '    Dim ds As DataSet = New DataSet()
    '    Dim con As SqlConnection = New SqlConnection( _
    '        ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
    '    con.Open()
    '    Dim comm As SqlCommand = New SqlCommand("proc_getUserMsg", con)
    '    comm.CommandType = CommandType.StoredProcedure
    '    Dim paramSender As SqlParameter = New SqlParameter( _
    '        "@ID", SqlDbType.VarChar, 50)
    '    paramSender.Value = Session("ID")
    '    'Session("ID")
    '    comm.Parameters.Add(paramSender)
    '    con.Close()
    '    Dim da As SqlDataAdapter = New SqlDataAdapter(comm)
    '    da.Fill(ds)

    '    'objPanelText.Text = "Welcome to my VB.NET-page!"
    '    Dim dt As DataTable = ds.Tables(0)
    '    If (dt.Rows.Count > 0) Then
    '        If (Session("user") = "") Then



    '            msgPanel.Text = ""
    '            For Each row As DataRow In dt.Rows
    '                Dim usr As String
    '                comm = New SqlCommand("proc_getUserID", con)
    '                con.Open()
    '                comm.CommandType = CommandType.StoredProcedure
    '                paramSender = New SqlParameter( _
    '                    "@ID", SqlDbType.VarChar, 50)
    '                paramSender.Value = row.Item("Uid")
    '                comm.Parameters.Add(paramSender)
    '                usr = comm.ExecuteScalar
    '                con.Close()
    '                If (row.Item("Sender").Equals(Session("ID").ToString)) Then

    '                    msgPanel.Text += "Me" & "(" & usr & ")" & ":" & row.Item("Msg") & "<br/>"
    '                Else
    '                    msgPanel.Text += usr & " : " & row.Item("Msg") & "<br/>"
    '                End If

    '            Next row
    '        End If
    '    End If

    '    If (Session("user") <> "") Then

    '        comm = New SqlCommand("proc_getUserID", con)
    '        con.Open()
    '        comm.CommandType = CommandType.StoredProcedure
    '        paramSender = New SqlParameter( _
    '            "@ID", SqlDbType.VarChar, 50)
    '        paramSender.Value = Session("user")
    '        comm.Parameters.Add(paramSender)
    '        user = comm.ExecuteScalar
    '        con.Close()
    '        If (dt.Rows.Count > 0) Then
    '            msgPanel.Text = ""
    '            For Each row As DataRow In dt.Rows
    '                If (row.Item("Sender").Equals(Session("ID").ToString)) Then

    '                    msgPanel.Text += "Me" & "(" & user & ")" & ":" & row.Item("Msg") & "<br/>"
    '                Else
    '                    msgPanel.Text += user & " : " & row.Item("Msg") & "<br/>"
    '                End If

    '            Next row
    '        End If
    '    End If


    'End Sub

    'Protected Sub Btnok_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If (Session("user") <> "" And TextBox1.Text <> "") Then
    '        Dim con As SqlConnection = New SqlConnection( _
    '            ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
    '        con.Open()
    '        Dim comm As SqlCommand = New SqlCommand("proc_InsertUserMsg", con)
    '        comm.CommandType = CommandType.StoredProcedure
    '        comm.Parameters.AddWithValue("@Msg", TextBox1.Text)
    '        comm.Parameters.AddWithValue("@Sender", HttpContext.Current.Session("ID"))
    '        comm.Parameters.AddWithValue("@Uid", HttpContext.Current.Session("user"))
    '        'Dim paramSender As SqlParameter = New SqlParameter( _
    '        '    "@Msg", SqlDbType.VarChar, 200)
    '        'paramSender.Value = TextBox1.Text
    '        'comm.Parameters.Add(paramSender)

    '        'Dim paramSender1 As SqlParameter = New SqlParameter( _
    '        '    "@Sender", SqlDbType.VarChar, 10)
    '        'paramSender.Value = "1"
    '        'comm.Parameters.Add(paramSender1)

    '        'Dim paramSender2 As SqlParameter = New SqlParameter( _
    '        '    "@Uid", SqlDbType.VarChar, 10)
    '        'paramSender.Value = HttpContext.Current.Session("ID")
    '        'comm.Parameters.Add(paramSender2)
    '        comm.ExecuteNonQuery()
    '        TextBox1.Text = ""
    '        'ScriptManager1.SetFocus(TextBox1.ClientID)
    '    End If
    'End Sub

    ''<System.Web.Services.WebMethod()> _
    ''Public Shared Sub current_user(ByVal ID As String)
    ''    ID = ID
    ''End Sub




    'Sub current_user(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim btn As LinkButton = DirectCast(sender, LinkButton)
    '    Session("user") = btn.CommandArgument
    '    btn.BackColor = Drawing.Color.Red
    'End Sub

    ''Sub current_user(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
    ''    Dim str As String = Repeater1.Items.Item("UserID").ToString
    ''End Sub
End Class