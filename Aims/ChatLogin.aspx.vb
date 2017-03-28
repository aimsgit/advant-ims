Imports System.Data.SqlClient
Imports System.Data


Partial Public Class ChatLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = ""
        
        'If (Not IsPostBack) Then
        '    RadioButton1.Checked = True
        '    txtpass.Visible = False
        '    lblpass.Visible = False
        'End If
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
        Dim str As String = txtUserID.Text

        If (txtUserID.Text.Equals("")) Then
            Label1.Text = "Enter Username"
            Exit Sub

        Else

            Dim dt As DataTable = New DataTable()
            Dim con As SqlConnection = New SqlConnection( _
                ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
            con.Open()
            Dim comm As SqlCommand = New SqlCommand("proc_getOnlineUser", con)
            comm.CommandType = CommandType.StoredProcedure
            Dim paramSender As SqlParameter = New SqlParameter( _
               "@ID", SqlDbType.Int)
            paramSender.Value = 1
            comm.Parameters.Add(paramSender)
            Dim da As SqlDataAdapter = New SqlDataAdapter(comm)
            da.Fill(dt)
            'If (dt.Rows.Count > 10) Then
            '    Label1.Text = "Technical Team is busy ,Try after sometime....."
            '    Exit Sub
            'Else
            con = New SqlConnection( _
            ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
            con.Open()
            Dim ID As Integer
            comm = New SqlCommand("Proc_InsertUsername", con)
            comm.CommandType = CommandType.StoredProcedure
            paramSender = New SqlParameter( _
                "@Username", SqlDbType.VarChar, 50)
            paramSender.Value = txtUserID.Text
            comm.Parameters.Add(paramSender)
            ID = comm.ExecuteScalar
            Session("Name") = txtUserID.Text
            Session("ID") = ID
            Session("chat") = "User"
            Response.Redirect("Chatmain.aspx")

            'FormsAuthentication.RedirectFromLoginPage(txtUserID.Text, False)
            'End If
        End If


        'If (RadioButton2.Checked = True) Then
        '    Dim password As String = RijndaelSimple.Encrypt(txtpass.Text, _
        '                                   RijndaelSimple.passPhrase, _
        '                                   RijndaelSimple.saltValue, _
        '                                   RijndaelSimple.hashAlgorithm, _
        '                                   RijndaelSimple.passwordIterations, _
        '                                   RijndaelSimple.initVector, _
        '                                   RijndaelSimple.keySize)
        '    Dim dt As DataTable = New DataTable()
        '    Dim con As SqlConnection = New SqlConnection( _
        '    ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        '    con.Open()
        '    'Dim ID As Integer
        '    Dim comm As SqlCommand = New SqlCommand("proc_getTech", con)
        '    comm.CommandType = CommandType.StoredProcedure
        '    Dim paramSender As SqlParameter = New SqlParameter( _
        '        "@User", SqlDbType.VarChar, 50)
        '    paramSender.Value = txtUserID.Text
        '    comm.Parameters.Add(paramSender)

        '    Dim parampass As SqlParameter = New SqlParameter( _
        '        "@Pass", SqlDbType.VarChar, 50)
        '    parampass.Value = password
        '    comm.Parameters.Add(parampass)

        '    Dim da As SqlDataAdapter = New SqlDataAdapter(comm)
        '    da.Fill(dt)
        '    If (dt.Rows.Count > 0) Then
        '        Session("Name") = txtUserID.Text
        '        Session("ID") = dt.Rows(0).Item(0)
        '        con = New SqlConnection( _
        '        ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        '        con.Open()
        '        comm = New SqlCommand("Proc_DeleteChat", con)
        '        comm.CommandType = CommandType.StoredProcedure
        '        paramSender = New SqlParameter( _
        '            "@ID", SqlDbType.Int)
        '        paramSender.Value = HttpContext.Current.Session("ID")
        '        comm.Parameters.Add(paramSender)
        '        comm.ExecuteNonQuery()

        '        Response.Redirect("ChatDefault.aspx")
        '    Else
        '        Label1.Text = "Enter Correct Username and Password"
        '        RadioButton2.Checked = True
        '        txtpass.Text = ""
        '        txtUserID.Text = ""
        '        Exit Sub

        '    End If
        'End If

        'If (((txtUserID.Text.ToUpper() = "USER1") And _
        '           (txtPassword.Text = "User1@123")) Or _
        '           ((txtUserID.Text.ToUpper() = "USER2") And _
        '           (txtPassword.Text = "User2@123")) Or _
        '           ((txtUserID.Text.ToUpper() = "USER3") And _
        '           (txtPassword.Text = "User3@123"))) Then
        '    FormsAuthentication.RedirectFromLoginPage _
        '         (txtUserID.Text, False)
        'End If

    End Sub

    'Protected Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
    '    RadioButton2.Checked = False
    '    txtUserID.Enabled = True
    '    txtUserID.Text = ""
    '    txtpass.Visible = False
    '    lblpass.Visible = False
    '    txtUserID.Focus()
    'End Sub

    'Protected Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
    '    RadioButton1.Checked = False
    '    txtpass.Visible = True
    '    lblpass.Visible = True
    '    txtUserID.Text = ""
    '    txtUserID.Focus()
    'End Sub
End Class