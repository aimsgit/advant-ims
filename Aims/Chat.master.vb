Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing

Partial Class Chat
    Inherits System.Web.UI.MasterPage
    Dim user As String = ""
    Dim ID As String
    Dim x, y As Integer
    Dim NotifyIcon1 As NotifyIcon = New NotifyIcon
    Dim ShowInTaskbar As String
    Dim WindowState As FormWindowState
    'Dim taskbarNotifier1 As TaskBarNotifier
    Dim Sound As New System.Media.SoundPlayer()
    Dim SaveScrollLocation As New StringBuilder

    Dim SetScrollLocation As New StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblUser.Text = "Hi " & Session("Name") & " Welcome to AIMS Support Application."
        Dim ID As Integer = Integer.Parse(Session("ID"))
        If (Not IsPostBack) Then
            Session(user) = ""
            If (Session("chat") = "Support") Then
                Label1.Text = "Online User :"
                LinkButton2.visible = "True"
            End If
            If (Session("chat") = "User") Then
                Label1.Text = "Online Support :"
            End If
            'Session("Path")
        End If
        'ScriptManager.RegisterStartupScript(divUsers, divUsers.GetType(), "Scroll", ";javascript:ScrollToBottom();", True)
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim con As SqlConnection = New SqlConnection( _
           ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        con.Open()
        Dim comm As SqlCommand = New SqlCommand("stp_Message", con)
        comm.CommandType = CommandType.StoredProcedure
        Dim paramSender As SqlParameter = New SqlParameter( _
            "@Sender", SqlDbType.Int)
        paramSender.Value = Session("ID")
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
        Session("user") = ""
        If (Session("chat") = "Support") Then
            Session("chat") = ""
            Response.Redirect("frmsupportlogin.aspx")
        End If
        If (Session("chat") = "User") Then
            Session("chat") = ""
            Response.Redirect("ChatLogin.aspx")
        End If

    End Sub
    

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Dim pt As Point = New Point(msgPanel.AutoScrollPosition.X, Math.Abs(Panel.AutoScrollPosition.Y))
        'x = 0
        Repeater1.DataSource = Nothing
        Repeater1.DataBind()
        Repeater1.DataSourceID = "dsrcWebChat"
        Repeater1.DataBind()

        Dim ds As DataSet = New DataSet()
        Dim con As SqlConnection = New SqlConnection( _
            ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        con.Open()
        Dim comm As SqlCommand = New SqlCommand("proc_getUserMsg", con)
        comm.CommandType = CommandType.StoredProcedure
        Dim paramSender As SqlParameter = New SqlParameter( _
            "@ID", SqlDbType.VarChar, 50)
        paramSender.Value = Session("ID")
        'Session("ID")
        comm.Parameters.Add(paramSender)
        con.Close()
        Dim da As SqlDataAdapter = New SqlDataAdapter(comm)
        da.Fill(ds)
        Dim dt As DataTable = ds.Tables(0)
        If (dt.Rows.Count > 0) Then
            If (Session("user") = "") Then
                msgPanel.Text = ""
                For Each row As DataRow In dt.Rows
                    Dim usr As String
                    comm = New SqlCommand("proc_getUserID", con)
                    con.Open()
                    comm.CommandType = CommandType.StoredProcedure
                    paramSender = New SqlParameter( _
                        "@ID", SqlDbType.VarChar, 50)
                    paramSender.Value = row.Item("Uid")
                    comm.Parameters.Add(paramSender)
                    usr = comm.ExecuteScalar
                    con.Close()
                    If (row.Item("Sender").Equals(Session("ID").ToString)) Then
                        msgPanel.Text += "<b>Me" & "(" & usr & ")" & "</b>:" & row.Item("Msg") & "<br/>"

                    Else
                        'If (usr.Equals(Session("Name").ToString)) Then
                        comm = New SqlCommand("proc_getUserID", con)
                        con.Open()
                        comm.CommandType = CommandType.StoredProcedure
                        paramSender = New SqlParameter( _
                            "@ID", SqlDbType.VarChar, 50)
                        paramSender.Value = row.Item("Sender")
                        comm.Parameters.Add(paramSender)
                        usr = comm.ExecuteScalar
                        con.Close()
                        msgPanel.Text += "<b>" & usr & "</b> : " & row.Item("Msg") & "<br/>"

                        'Else
                        '    msgPanel.Text += "<b>" & usr & "</b> : " & row.Item("Msg") & "<br/>"

                        'End If
                    End If

                Next row
            End If
            If (Session("user") <> "") Then
                msgPanel.Text = ""
                For Each row As DataRow In dt.Rows
                    Dim usr As String
                    comm = New SqlCommand("proc_getUserID", con)
                    con.Open()
                    comm.CommandType = CommandType.StoredProcedure
                    paramSender = New SqlParameter( _
                        "@ID", SqlDbType.VarChar, 50)
                    paramSender.Value = row.Item("Uid")
                    comm.Parameters.Add(paramSender)
                    usr = comm.ExecuteScalar
                    con.Close()
                    If (row.Item("Sender").Equals(Session("ID").ToString)) Then
                        msgPanel.Text += "<b>Me" & "(" & usr & ")" & "</b>:" & row.Item("Msg") & "<br/>"

                    Else
                        'If (usr.Equals(Session("Name").ToString)) Then
                        'Dim usr As String
                        comm = New SqlCommand("proc_getUserID", con)
                        con.Open()
                        comm.CommandType = CommandType.StoredProcedure
                        paramSender = New SqlParameter( _
                            "@ID", SqlDbType.VarChar, 50)
                        paramSender.Value = row.Item("Sender")
                        comm.Parameters.Add(paramSender)
                        usr = comm.ExecuteScalar
                        con.Close()
                        msgPanel.Text += "<b>" & usr & "</b> : " & row.Item("Msg") & "<br/>"


                        '    Else
                        '    msgPanel.Text += "<b>" & usr & "</b> : " & row.Item("Msg") & "<br/>"

                        '    'If (dt.Rows.Count() > y) Then
                        '    '    Sound.SoundLocation = "D:\AIMS\AIMS_20130725SRC\Images\msg.wav"  'ex.: c:\mysound.wav  
                        '    '    Sound.Load()
                        '    '    Sound.Play()
                        '    'End If
                        'End If
                    End If
            'If (dt.Rows.Count() > Integer.Parse(Session("y"))) Then
            '    If (row.Item("Sender") <> (Session("ID").ToString)) Then
            '        Sound.SoundLocation = "D:\AIMS\AIMS_20130725SRC\Images\msg.wav"  'ex.: c:\mysound.wav  
            '        Sound.Load()
            '        Sound.Play()
            '    End If
            'End If
            'x = x + 1
                Next row
            End If
        End If
        
        'Session("y") = x
    End Sub

    Sub current_user(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As LinkButton = DirectCast(sender, LinkButton)
        Session("user") = btn.CommandArgument
        btn.BackColor = Drawing.Color.Red
        Dim usr As String
        Dim ds As DataSet = New DataSet()
        Dim con As SqlConnection = New SqlConnection( _
            ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        con.Open()
        Dim comm As SqlCommand = New SqlCommand("proc_getUserID", con)
        comm.CommandType = CommandType.StoredProcedure
        Dim paramSender As SqlParameter = New SqlParameter( _
            "@ID", SqlDbType.VarChar, 50)
        paramSender.Value = Session("user")
        'Session("ID")
        comm.Parameters.Add(paramSender)
        usr = comm.ExecuteScalar
        con.Close()
        Label2.Text = "Current User :" + usr
    End Sub

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

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Dim con As SqlConnection = New SqlConnection( _
          ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        con.Open()
        Dim comm As SqlCommand = New SqlCommand("Clear_Message", con)
        comm.CommandType = CommandType.StoredProcedure
        Dim paramSender As SqlParameter = New SqlParameter( _
            "@ID", SqlDbType.Int)
        paramSender.Value = Session("ID")
        comm.Parameters.Add(paramSender)
        comm.ExecuteNonQuery()
        msgPanel.Text = ""
    End Sub
End Class

