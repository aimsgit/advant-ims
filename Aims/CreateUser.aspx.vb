
Partial Class CreateUser
    Inherits BasePage
    Dim GlobalFunction As New GlobalFunction
    Protected Sub btnCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        Dim i As Int16 = 0
        Dim userName As String = txtUserId.Text

        'this value is either encrypted or hashed and is never displayed 
        Dim password As String = txtPassword.Text

        Dim email As String = txtEmail.Text
        Dim passwordQuestion As String = txtPasswordQuestion.Text

        'this value is either encrypted or hashed and is never displayed
        Dim passwordAnswer As String = txtPasswordAnswer.Text

        Dim result As MembershipCreateStatus
        Membership.CreateUser(userName, password, email, passwordQuestion, passwordAnswer, True, result)

        lblResults.Visible = True
        Select Case result
            Case MembershipCreateStatus.Success
                Dim User As MembershipUser
                User = Membership.GetUser(txtUserId.Text)
                Dim UserGUID As Object = User.ProviderUserKey
                'i = UserDetailsDB.Insert(UserGUID.ToString, txtUserId.Text, CDate(Me.txtExpiry.Text))
                If i > 0 Then
                    txtUserId.Text = Nothing
                    txtPassword.Text = Nothing
                    txtEmail.Text = Nothing
                    txtPasswordQuestion.Text = Nothing
                    txtPasswordAnswer.Text = Nothing
                    lblResults.Text = "User successfully created!"
                End If
                'lblResults.Text = "User successfully created!"
            Case MembershipCreateStatus.InvalidUserName
                lblResults.Text = "The username format was invalid.  Please enter a different username."
                'MsgBox(lblResults.Text)
            Case MembershipCreateStatus.InvalidPassword
                If password.Length < 7 Then
                    lblResults.Text = "The password should be at least 7 characters in length."
                Else
                    lblResults.Text = "The password should have at least one special character .  Please enter a new password."
                End If
            Case MembershipCreateStatus.InvalidEmail
                lblResults.Text = "The email format was invalid.  Please enter a different username."
            Case MembershipCreateStatus.InvalidQuestion
                lblResults.Text = "The password question format was invalid.  Please enter a different question."
            Case MembershipCreateStatus.InvalidAnswer
                lblResults.Text = "The password answer format was invalid.  Please enter a different answer."
            Case MembershipCreateStatus.DuplicateUserName
                lblResults.Text = "The username is already in use.  Please enter a new username."
            Case MembershipCreateStatus.DuplicateEmail
                lblResults.Text = "The email address is already in use.  Please enter a different email address."
            Case Else
                lblResults.Text = "An error occurred while creating the user."
        End Select
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("Admin") = 1 Then
                Dim Bll As New EmployeeManager
                Label2.Visible = True
                ddlBranch.Visible = True
                ddlBranch.DataSource = Bll.Getbranch()
                ddlBranch.DataBind()
                Session("NewBranchID") = ""
            Else
                Label2.Visible = False
                ddlBranch.Visible = False
            End If
        End If
    End Sub

    Protected Sub AutoCompleteExtender2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender2.PreRender
        Try
            Session("sesInstitute") = HttpContext.Current.Session("InstituteID")
            Session("sesbranch") = HttpContext.Current.Session("BranchID")
            If txtEmp.Text <> "" Then
                Session("EMPID") = GlobalFunction.IdCutter(txtEmp.Text)
            End If
        Catch
            txtEmp.Text = "Not a valid Employee.Try again."
            txtEmp.ForeColor = Drawing.Color.Red
        End Try
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub

    Protected Sub ddlBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("NewBranchID") = ddlBranch.SelectedValue
    End Sub
End Class
