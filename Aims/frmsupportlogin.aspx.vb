Imports System.Data.SqlClient

Partial Class frmsupportlogin
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

        If (txtUserID.Text.Equals("") And txtpass.Text.Equals("")) Then
            Label1.Text = "Enter ALL Details"
            Exit Sub

        Else


            Dim password As String = RijndaelSimple.Encrypt(txtpass.Text, _
                                           RijndaelSimple.passPhrase, _
                                           RijndaelSimple.saltValue, _
                                           RijndaelSimple.hashAlgorithm, _
                                           RijndaelSimple.passwordIterations, _
                                           RijndaelSimple.initVector, _
                                           RijndaelSimple.keySize)
            Dim dt As DataTable = New DataTable()
            Dim con As SqlConnection = New SqlConnection( _
            ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
            con.Open()
            'Dim ID As Integer
            Dim comm As SqlCommand = New SqlCommand("proc_getTech", con)
            comm.CommandType = CommandType.StoredProcedure
            Dim paramSender As SqlParameter = New SqlParameter( _
                "@User", SqlDbType.VarChar, 50)
            paramSender.Value = txtUserID.Text
            comm.Parameters.Add(paramSender)

            Dim parampass As SqlParameter = New SqlParameter( _
                "@Pass", SqlDbType.VarChar, 50)
            parampass.Value = password
            comm.Parameters.Add(parampass)

            Dim da As SqlDataAdapter = New SqlDataAdapter(comm)
            da.Fill(dt)
            If (dt.Rows.Count > 0) Then
                Session("Name") = txtUserID.Text
                Session("ID") = dt.Rows(0).Item(0)
                con = New SqlConnection( _
                ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
                con.Open()
                comm = New SqlCommand("Proc_DeleteChat", con)
                comm.CommandType = CommandType.StoredProcedure
                paramSender = New SqlParameter( _
                    "@ID", SqlDbType.Int)
                paramSender.Value = HttpContext.Current.Session("ID")
                comm.Parameters.Add(paramSender)
                comm.ExecuteNonQuery()
                Session("chat") = "Support"
                Response.Redirect("Chatmain.aspx")
            Else
                Label1.Text = "Enter Correct Username and Password"

                txtpass.Text = ""
                txtUserID.Text = ""
                Exit Sub

            End If
        End If

        

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
