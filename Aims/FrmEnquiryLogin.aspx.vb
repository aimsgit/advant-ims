
Partial Class FrmEnquiryLogin
    Inherits BasePage
    Dim el As New ELEnquiryLogin
    Dim dl As New DLEnquiryLogin
    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Try
            lblError1.Text = ""
            If txtName.Text = "" Or txtEmail.Text = "" Or txtContactNo.Text = "" Or txtPasswordR.Text = "" Then
                lblError1.Text = "Enter all fields."
                Exit Sub
            End If
            el.Name = txtName.Text
            el.EmailID = txtEmail.Text
            el.ContactNo = txtContactNo.Text
            el.Password = RijndaelSimple.Encrypt(txtPasswordR.Text, _
                                           RijndaelSimple.passPhrase, _
                                           RijndaelSimple.saltValue, _
                                           RijndaelSimple.hashAlgorithm, _
                                           RijndaelSimple.passwordIterations, _
                                           RijndaelSimple.initVector, _
                                           RijndaelSimple.keySize)
            el.Website = Page.Request.UrlReferrer.ToString 'Page.Request.Url.ToString
            If dl.Getduplicate(el).Rows.Count > 0 Then
                lblError1.Text = "Email ID already registered"
                lblError.Text = ""
            Else
                dl.Insert(el)
                lblError1.Text = ""
                txtName.Text = ""
                txtEmail.Text = ""
                txtContactNo.Text = ""
                txtPasswordR.Text = ""
                lblError1.Text = "Data Submitted Successfully."
                lblError.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        el.EmailID = txtUserName.Text
        el.Password = RijndaelSimple.Encrypt(txtPassword.Text, _
                                       RijndaelSimple.passPhrase, _
                                       RijndaelSimple.saltValue, _
                                       RijndaelSimple.hashAlgorithm, _
                                       RijndaelSimple.passwordIterations, _
                                       RijndaelSimple.initVector, _
                                       RijndaelSimple.keySize)
        el.PrvsUrl = ViewState("PrvsUrl")
        Dim dt As New DataTable
        dt = dl.Getdetails(el)
        If dt.Rows.Count > 0 Then
            HttpContext.Current.Session("StatusEnquiry") = "In"
            HttpContext.Current.Session("EnquiryName") = dt.Rows(0).Item("Name").ToString
            HttpContext.Current.Session("EnquiryEmail") = dt.Rows(0).Item("EmailID").ToString
            HttpContext.Current.Session("EnquiryContact") = dt.Rows(0).Item("ContactNo").ToString
            HttpContext.Current.Session("Office") = "I"
            HttpContext.Current.Session("Usercode") = dt.Rows(0).Item("Name").ToString + "-Online"
            HttpContext.Current.Session("Empcode") = el.EmailID + "-Online"
            HttpContext.Current.Session("BranchCode") = dt.Rows(0).Item("Branchcode").ToString
            HttpContext.Current.Session("ParentBranch") = dt.Rows(0).Item("Branchcode").ToString
            HttpContext.Current.Session("AccessLevel") = "01"
            HttpContext.Current.Session("Enquiry_AutoId") = dt.Rows(0).Item("Enquiry_AutoId").ToString
            Response.Redirect("frmEnquiry.aspx")
        Else
            lblError.Text = "Login Failed."
        End If
        dt.Dispose()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim Str1 As String
            Str1 = Page.Request.UrlReferrer.ToString
            lblError.Text = Str1
            ViewState("PrvsUrl") = Page.Request.UrlReferrer.ToString
            Session("BranchCode") = Session("BranchCode")
        End If
    End Sub
End Class
