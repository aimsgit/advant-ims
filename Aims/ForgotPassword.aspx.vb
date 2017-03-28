Imports System.Data.SqlClient

Partial Class ForgotPassword
    Inherits BasePage
    Dim DL As New DLForgotPassword

    Protected Sub btnok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnok.Click
        Dim vm As String
        Dim dt3, dt1 As DataTable
        Dim parm_msg, parm_phonesp, parm_msgfrm, parm_date As SqlParameter
        lblSResult.Text = ""
        lblgreen.Text = ""
        txtemailid.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                Dim Email As String
                Dim EmailID As String
                Dim dt As New DataTable
                Dim RbId As Integer
                Dim userId As String
                Dim UserName As String
                RbId = RadioButtonList1.SelectedValue
                userId = txtemailid.Text
                dt = DLForgotPassword.GetforgotPass(RbId, userId)
                EmailID = dt.Rows(0).Item("Email")
                If EmailID = "" Then
                    clear()
                    lblSResult.Text = "Email ID Not Found. Please Contact Your Administrator."
                    Exit Sub
                Else
                    'lblRed.Visible = True
                    Dim Name As String
                    Dim Password As String
                    Name = dt.Rows(0).Item("Name")
                    UserName = dt.Rows(0).Item("UserName")
                    Password = RijndaelSimple.Decrypt(dt.Rows(0).Item("Password"), _
                                           RijndaelSimple.passPhrase, _
                                           RijndaelSimple.saltValue, _
                                           RijndaelSimple.hashAlgorithm, _
                                           RijndaelSimple.passwordIterations, _
                                           RijndaelSimple.initVector, _
                                           RijndaelSimple.keySize)


                    'Dim str As String = ""
                    'Dim Msg As String = "PASSWORD RECOVERY  FOR ADVANTIMS.COM. <br/><br/> Dear " + Name + ", <br/><br/> Please Find Your UserID And Password as Below : <br/> User ID : " + UserName + " <br/> Password : " + Password + " "
                    'Dim connection As New SqlClient.SqlConnection()
                    'connection.ConnectionString = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
                    'connection.Open()
                    'Dim cmd As New SqlCommand()
                    'vm = "insert into Outbox_tbl (ToPhone,Message,prefix,BranchCode,CommunicationMode) values(@ToPhone,@Message,@Prefix,@BranchCode,@Mode)"

                    'cmd.Connection = connection
                    'cmd.CommandText = vm
                    'parm_phonesp = New SqlParameter
                    Email = dt.Rows(0).Item("Email")
                    'parm_phonesp.ParameterName = "@ToPhone"
                    'parm_phonesp.Value = Email
                    'parm_phonesp.DbType = DbType.String
                    'cmd.Parameters.Add(parm_phonesp)

                    'parm_msg = New SqlParameter
                    'parm_msg.ParameterName = "@Message"
                    'parm_msg.Value = Msg
                    'parm_msg.DbType = DbType.String
                    'cmd.Parameters.Add(parm_msg)

                    'parm_msgfrm = New SqlParameter
                    'parm_msgfrm.ParameterName = "@Prefix"
                    'parm_msgfrm.Value = "PASSWORD RECOVERY  FOR ADVATIMS.COM"
                    'parm_msgfrm.DbType = DbType.String
                    'cmd.Parameters.Add(parm_msgfrm)

                    'parm_date = New SqlParameter
                    'parm_date.ParameterName = "@SentDate"
                    'parm_date.Value = CDate(Date.Today)
                    'parm_date.DbType = DbType.Date
                    'cmd.Parameters.Add(parm_date)

                    'parm_msgfrm = New SqlParameter
                    'parm_msgfrm.ParameterName = "@BranchCode"
                    'parm_msgfrm.Value = "000000000000"
                    'parm_msgfrm.DbType = DbType.String
                    'cmd.Parameters.Add(parm_msgfrm)

                    'parm_msgfrm = New SqlParameter
                    'parm_msgfrm.ParameterName = "@Mode"
                    'parm_msgfrm.Value = "Email"
                    'parm_msgfrm.DbType = DbType.String
                    'cmd.Parameters.Add(parm_msgfrm)

                    'cmd.ExecuteNonQuery()
                    DLForgotPassword.InsertForgot(Name, UserName, Password, Email)
                    clear()
                    lblgreen.Text = "Your UserID And Password  has been sent to Registered Email."
                End If
            Catch ex As Exception
                lblSResult.Text = "Pleas Enter Your Correct LoginType And UserID."
                lblgreen.Text = ""
            End Try
        Else
        lblSResult.Text = "You do not belong to this branch, Cannot add/update data."
        lblgreen.Text = ""
        End If
    End Sub

    Protected Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Response.Redirect("Login.aspx")
    End Sub
    Sub clear()
        txtemailid.Text = ""
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            'Dim dt As New DataTable
            'dt = DLLogin.GetImage()
            'Dim rndNumber As New Random()
            'If (dt.Rows.Count > 0) Then

            '    Image4.ImageUrl = dt.Rows(0).Item(0)
            'End If
            'clear()
            lblSResult.Text = ""
            lblgreen.Text = ""
        End If
    End Sub
End Class
