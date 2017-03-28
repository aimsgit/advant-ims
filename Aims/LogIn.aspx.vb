Imports System.Net.NetworkInformation

Partial Class LogIn
    Inherits System.Web.UI.Page
    Dim LOG As New DataTable
    Dim dt, dt1, dt2 As New DataTable
    Dim userName, password, Spassword, MAC, LocalMAC, Check As String
    Dim Ip, Country, City As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' pannel 2 is security password page. on page load not to be run for Pannel2.

        If Not IsPostBack Then
            'If Panel2.Visible = False Then
            Session("LoginAttempts") = 0
            If (Session("Chat") = "") Then
                Me.txtUserId.Focus()
            End If

            'dt = UserDetailsDB.GetLogInNewsEvents()
            dt = DLLogin.GetImage()
            Dim rndNumber As New Random()
            If (dt.Rows.Count > 0) Then
                Image2.ImageUrl = dt.Rows(0).Item(0)
                Image4.ImageUrl = dt.Rows(0).Item(0)
            End If
            dt = DLLogin.GetLoginFontColor()
            If (dt.Rows.Count > 0) Then
                Label2.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows(0).Item(0).ToString)
                Label7.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows(0).Item(0).ToString)
            End If
            dt = UserDetailsDB.GetHeader()
            Label2.Text = dt.Rows(0).Item("ContentText")
            dt = UserDetailsDB.GetHeader1()
            Label7.Text = dt.Rows(0).Item("ContentText")
            'Try

            '    Dim request As HttpRequest = HttpContext.Current.Request

            Ip = Request.UserHostAddress

            '    Dim url As String = String.Empty

            '    url = String.Format("http://freegeoip.net/xml/" + request.UserHostAddress)

            '    Dim doc As New System.Xml.XmlDocument
            '    doc.Load(url)
            '    Dim list = doc.GetElementsByTagName("CountryName")
            '    For Each item As System.Xml.XmlElement In list
            '        Country = item.InnerText
            '    Next
            '    list = doc.GetElementsByTagName("City")
            '    For Each item As System.Xml.XmlElement In list
            '        City = item.InnerText
            '    Next
            Try
                Dim R As DataTable = DLLogin.CheckIP(Ip)
                If (R.Rows.Count() > 0) Then
                    Response.Redirect("~/frmBlacklist.aspx", True)
                End If
                Country = ""
                City = ""
                Dim data As DataTable
                data = DLLogin.InsertIP(Ip, Country, City)
                Session("IP_ID") = data.Rows(0).Item(0)

            Catch ex As Exception
                lblSResult.Visible = True
                lblSResult.Text = ex.Message.ToString
                lblResults.Focus()
            End Try
            'End If
        End If
        'Panel2.Visible = True
    End Sub
    Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        'If CheckBox1.Checked = True Then
        Session("LoginAttempts") = Session("LoginAttempts") + 1
        If Session("LoginAttempts") <= 3 Then
            userName = txtUserId.Text
            password = RijndaelSimple.Encrypt(txtPassword.Text,
                                               RijndaelSimple.passPhrase,
                                               RijndaelSimple.saltValue,
                                               RijndaelSimple.hashAlgorithm,
                                               RijndaelSimple.passwordIterations,
                                               RijndaelSimple.initVector,
                                               RijndaelSimple.keySize)


            If RadioButtonList1.SelectedValue = 1 Or RadioButtonList1.SelectedValue = 4 Then
                StaffLogin()
                'Panel3.Visible = False
                'Panel2.Visible = True
            Else
                Parent_StudentLogin()
                'Panel3.Visible = False
                'Panel2.Visible = True
            End If

            Exit Sub
        End If
        UserDetailsDB.SetLoginBlockedTime(Trim(txtUserId.Text))
        lblResults.Visible = True
        lblResults.Text = "You have made three failed attempts at login. Your account is locked for 20 mts. Please contact Admin."
        Session("LoginAttempts") = 0
        'HttpContext.Current.Session.Abandon()
    End Sub
    Sub Parent_StudentLogin()
        dt = UserDetailsDB.GetParentOnlineInfo(Trim(userName), Trim(password), Trim(Spassword), RadioButtonList1.SelectedItem.Text) 'spassword
        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then

                Dim usrid As Integer = dt.Rows(0)("UserDetailsID").ToString.Trim
                If dt.Rows(0)("InstExpiryDate") > Today Then
                    If dt.Rows(0)("BranchExpiry") > Today Then
                        If dt.Rows(0)("ExpDate") > Today.Date Then
                            LOG = UserDetailsDB.insert(usrid, RadioButtonList1.SelectedItem.Text)
                            Session("BranchName") = dt.Rows(0)("BranchName").ToString.Trim
                            Session("BranchAddress") = dt.Rows(0)("Address").ToString.Trim
                            Session("LoginType") = "Others"
                            Session("UserName") = dt.Rows(0)("UserName").ToString.Trim
                            Session("DT") = dt
                            Session("SPassword") = dt.Rows(0)("SPassword")
                            'Panel3.Visible = False
                            'Panel2.Visible = True
                            'txtSPassword.Focus()
                            'lblBranch.Text = "WELCOME TO " + Session("BranchName")
                            'Try
                            '    DLLogin.UpdateIP(Session("IP_ID"), Session("BranchCode"))
                            'Catch ex As Exception
                            SessionAllocation()
                            Response.Redirect("~Main.aspx", True)
                            'End Try
                            'Response.Redirect("~/Default.aspx", True)

                        Else
                            lblResults.Visible = True
                            lblResults.Text = "Log Id Expired!"
                        End If
                    Else
                        lblResults.Visible = True
                        lblResults.Text = "Branch has been Expired!"
                    End If
                Else
                    lblResults.Visible = True
                    lblResults.Text = "Institute has been Expired!"
                End If
            Else
                lblResults.Visible = True
                lblResults.Text = "Unsuccessful login.Please re-enter your information and try again."
            End If
        Else
            lblResults.Visible = True
            lblResults.Text = "Unsuccessful login.Please re-enter your information and try again."
        End If
    End Sub
    Sub StaffLogin()

        dt = UserDetailsDB.GetOnlineUserInfo(userName.Trim, password.Trim, Trim(Spassword))
        Try
            If Not isdbnull(dt.Rows(0)("LoginBlockedUpto")) Then
                If dt.Rows(0)("LoginBlockedUpto") > now() Then
                    lblResults.Visible = True
                    lblResults.Text = "Your login is blocked till " + dt.Rows(0)("LoginBlockedUpto").tostring + " .Please wait."
                    Exit Sub
                End If
            End If
        Catch ex As Exception
        End Try
        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then

                Dim usrid As Integer = dt.Rows(0)("UserDetailsID").ToString.Trim
                dt1 = UserDetailsDB.CheckAlreadyLogged(usrid)
                If dt.Rows(0)("InstExpiryDate") > Today Then
                    If dt.Rows(0)("BranchExpiry") > Today Then
                        If dt.Rows(0)("ExpDate") > Today.Date Then
                            If dt.Rows(0)("Status") = "S" Or dt.Rows(0)("Status") = "C" Then
                                lblResults.Visible = True
                                lblResults.Text = "Your Account is Blocked."
                            Else
                                If dt.Rows(0)("BranchStatus") = "S" Or dt.Rows(0)("BranchStatus") = "C" Then
                                    lblResults.Visible = True
                                    lblResults.Text = "Your Account is Blocked."
                                Else
                                    LOG = UserDetailsDB.insert(usrid, "Employee")
                                    GlobalFunction.logid = LOG.Rows(0).Item("LogID")
                                    Session("LogID") = LOG.Rows(0)("LogID").ToString()
                                    Session("DT") = dt
                                    Session("UserName") = userName.Trim
                                    Session("SPassword") = dt.Rows(0)("SPassword")
                                    Session("Password") = RijndaelSimple.Decrypt(password,
                                           RijndaelSimple.passPhrase,
                                           RijndaelSimple.saltValue,
                                           RijndaelSimple.hashAlgorithm,
                                           RijndaelSimple.passwordIterations,
                                           RijndaelSimple.initVector,
                                           RijndaelSimple.keySize)
                                    Session("BranchName") = dt.Rows(0)("BranchName").ToString.Trim
                                    Session("BranchCode") = dt.Rows(0)("Branchcode").ToString
                                    Session("BranchAddress") = dt.Rows(0)("BranchAddress").ToString.Trim
                                    'If Session("SPassword") <> "dumPWev53hJPQ+lQOTnJwQ==" Then
                                    Panel3.Visible = False
                                    Panel2.Visible = True
                                    txtSPassword.Focus()
                                    lblBranch.Text = "Welcome To " + Session("BranchName")
                                    'Else

                                    '    Response.Redirect("~/Default.aspx", True)

                                    'End If
                                End If
                            End If
                        Else
                            lblResults.Visible = True
                            lblResults.Text = "Log Id Expired!"
                        End If
                    Else
                        lblResults.Visible = True
                        lblResults.Text = "Branch has Expired!"
                    End If
                Else
                    lblResults.Visible = True
                    lblResults.Text = "Institute has Expired!"
                End If
            Else
                lblResults.Visible = True
                lblResults.Text = "Unsuccessful login.Please re-enter your information and try again."
            End If
        Else
            lblResults.Visible = True
            lblResults.Text = "Unsuccessful login.Please re-enter your information and try again."
        End If
        'Else
        '    lblResults.Visible = True
        '    lblResults.Text = "Please accept terms and conditions before Login."
        'End If
    End Sub
    Sub SessionAllocation()
        dt = Session("DT")
        If Session("LoginType") <> "Others" Then
            Session("BranchType_ID") = dt.Rows(0)("BranchTypeCode").ToString.Trim
            Session("BranchType_Parent") = Session("BranchType_ID")
            Session("AccessLevel") = dt.Rows(0)("AccessLevel").ToString.Trim
            Session("UserID") = dt.Rows(0)("UserDetailsID").ToString.Trim
            Session("ParentName") = Session("BranchName")
            Session("BranchTypeName") = dt.Rows(0)("BranchTypeName").ToString.Trim
            Session("EmpID") = dt.Rows(0)("EmpID").ToString.Trim
            Session("EmpName") = dt.Rows(0)("Emp_Name").ToString.Trim
            'Begin Edit by Kusum
            Session("UserPrefix") = dt.Rows(0)("Prefix").ToString
            If dt.Rows(0)("ImgBranch").ToString.Equals("") Then
                Session("DefaultIMG") = dt.Rows(0)("ImgDefault").ToString
            Else
                Session("DefaultIMG") = dt.Rows(0)("ImgBranch").ToString
            End If
            Session("HeaderTextColor") = dt.Rows(0)("HeaderTextColor").ToString
            Session("Logo") = dt.Rows(0)("BranchLogo").ToString
            Session("InstituteLogo") = dt.Rows(0)("InstituteLogo").ToString
            Session("ParentInstituteLogo") = dt.Rows(0)("InstituteLogo").ToString
            Session("ImgHeader") = dt.Rows(0)("ImgHeader").ToString
            Session("ParentUserPrefix") = dt.Rows(0)("Prefix").ToString
            If dt.Rows(0)("ImgBranch").ToString.Equals("") Then
                Session("ParentDefaultIMG") = dt.Rows(0)("ImgDefault").ToString
            Else
                Session("ParentDefaultIMG") = dt.Rows(0)("ImgBranch").ToString
            End If
            Session("ParentHeaderTextColor") = dt.Rows(0)("HeaderTextColor").ToString
            Session("ParentImgHeader") = dt.Rows(0)("ImgHeader").ToString
            Session("ParentLogo") = dt.Rows(0)("BranchLogo").ToString
            Session("ParentInstituteLogo") = dt.Rows(0)("InstituteLogo").ToString
            Session("TagLine") = dt.Rows(0)("TagLine").ToString
            Session("ParentTagLine") = dt.Rows(0)("TagLine").ToString
            Session("IncludeInsName") = dt.Rows(0)("IncludeInsName").ToString
            Session("ParentIncludeInsName") = dt.Rows(0)("IncludeInsName").ToString
            Session("LanguageID") = dt.Rows(0)("LanguageID").ToString
            If dt.Rows(0)("DeptID").ToString = "" Then
                Session("DeptId") = 0
            Else
                Session("DeptId") = dt.Rows(0)("DeptID").ToString
            End If
            GlobalFunction.logid = Session("LogID")
            'Session("Password") = txtPassword.Text
            'End Edit by Kusum
            Session("sesHOID") = dt.Rows(0)("HoCode").ToString
            'User(Role)
            Session("UserRole") = dt.Rows(0)("Roles").ToString
            Session("ParentBranch") = dt.Rows(0)("BranchCode").ToString
            'BranchCode instead of Branch ID
            Session("BranchCode") = Session("ParentBranch")
            'Privilages()
            'If Session("Branchcode") = "000000000000" Then
            '    Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
            '    LocalMAC = nics(0).GetPhysicalAddress.ToString
            '    Check = UserDetailsDB.GetMacAddress(LocalMAC)
            '    'MAC = dt2.Rows(0).Item("Config_Value").ToString

            '    If Check = "" Then
            '        '  Dim Theme As String() = Split(Session("MAC"), ",")
            '        If MAC <> LocalMAC Then
            '            lblResults.Visible = True
            '            lblResults.Text = "Access Denied."
            '            Exit Sub
            '        End If
            '    End If
            'End If
            Session("Privilages") = dt.Rows(0)("Privilages").ToString
            'EmpCode instead of EmpID
            Session("EmpCode") = dt.Rows(0)("EmpCode").ToString
            'UserCode instead of userid
            Session("UserCode") = dt.Rows(0)("UserName").ToString
            Session("InstituteName") = dt.Rows(0)("InstituteName").ToString
            Session("ParentInstituteName") = Session("InstituteName")
            Session("InstituteCode") = dt.Rows(0)("InstituteCode").ToString.Trim
            Session("ParentInstituteCode") = Session("InstituteCode")
            Session("Accesslevel") = dt.Rows(0)("AccessLevel").ToString.Trim
            ''''''''''''''
            Session("Company_Address") = dt.Rows(0)("Company_Address").ToString.Trim
            Session("City") = dt.Rows(0)("City").ToString.Trim
            Session("Postal_Code") = dt.Rows(0)("Postal_Code").ToString.Trim
            Session("State") = dt.Rows(0)("State").ToString.Trim
            Session("Country") = dt.Rows(0)("Country").ToString.Trim
            Session("Contact_Number1") = dt.Rows(0)("Contact_Number1").ToString.Trim
            Session("Fax_Number") = dt.Rows(0)("Fax_Number").ToString.Trim
            Session("FromEmailID") = IIf(dt.Rows(0)("FromEmailID").ToString.Trim Is DBNull.Value, "", dt.Rows(0)("FromEmailID").ToString.Trim)
            Session("FromPassword") = IIf(dt.Rows(0)("FromPassword").ToString.Trim Is DBNull.Value, "", dt.Rows(0)("FromPassword").ToString.Trim)
            Session("SMTPHost") = IIf(dt.Rows(0)("SMTPHost").ToString.Trim Is DBNull.Value, "", dt.Rows(0)("SMTPHost").ToString.Trim)
            ''''''''''''''
            'office session
            Session("RptFrmTitleName") = ""
            Session("FrmParentName") = ""
            Session("Office") = "I"
            Session("LinknameList") = UserDetailsDB.GetLinkName()
            Session("ChildNodes") = Session("LinknameList") 'TreeViewDB.GetChildlist()
            Session("ParentList") = UserDetailsDB.GetParentName() 'TreeViewDB.GetTVParentNodes
            Session("SecurityCheck") = UserDetailsDB.CheckSecurityCheck()
            Session("LoginType") = "Employee"
            Session("EmailService") = dt.Rows(0)("EmailService")
            Session("SMSService") = dt.Rows(0)("SMSService")
            'added Report Branch Code and Report Branch Name in session 
            'Anchala Verma 16-Apr-2014
            Session("ReportBranch") = dt.Rows(0)("ReportBranch")
            Session("ReportBranchName") = dt.Rows(0)("ReportBranchName")
            LOG.Dispose()
            dt1.Dispose()
            dt.Dispose()
            ''Creating Session LanguageID & ValidationMessage By Ajit Kumar Singh
            Session("LanguageID") = dt.Rows(0)("LanguageID").ToString
            ValidationMessageJS()
        Else
            Session("UserRole") = dt.Rows(0)("Roles").ToString
            Session("logid") = LOG.Rows(0).Item("LogID")
            Session("InsExpiryDate") = dt.Rows(0)("InstExpiryDate")
            Session("BranchExpiry") = dt.Rows(0)("BranchExpiry")
            If dt.Rows(0)("ImgBranch").ToString.Equals("") Then
                Session("DefaultIMG") = dt.Rows(0)("ImgDefault").ToString
            Else
                Session("DefaultIMG") = dt.Rows(0)("ImgBranch").ToString
            End If
            Session("HeaderTextColor") = dt.Rows(0)("HeaderTextColor").ToString
            Session("Logo") = dt.Rows(0)("BranchLogo").ToString
            Session("InstituteLogo") = dt.Rows(0)("InstituteLogo").ToString
            Session("ImgHeader") = dt.Rows(0)("ImgHeader").ToString
            Session("InstituteName") = dt.Rows(0)("MyCo_Name").ToString
            Session("UserName") = userName.Trim
            Session("StudentCode") = dt.Rows(0)("StudentCode").ToString.Trim
            Session("StudentName") = dt.Rows(0)("STD_FullName").ToString.Trim
            Session("BranchCode") = dt.Rows(0)("BranchCode").ToString.Trim
            Session("ParentBranch") = dt.Rows(0)("BranchCode").ToString.Trim
            Session("Privilages") = dt.Rows(0)("Privilages").ToString.Trim
            Session("BatchNo") = dt.Rows(0)("Batch_No").ToString.Trim
            Session("BatchID") = dt.Rows(0)("BatchID").ToString.Trim
            Session("UserID") = dt.Rows(0)("UserDetailsID").ToString.Trim
            Session("TagLine") = dt.Rows(0)("TagLine").ToString
            Session("ParentTagLine") = dt.Rows(0)("TagLine").ToString
            Session("IncludeInsName") = dt.Rows(0)("IncludeInsName").ToString
            Session("UserName") = dt.Rows(0)("Username").ToString
            Session("RptFrmTitleName") = ""
            Session("FrmParentName") = ""
            Session("Office") = "I"
            'Session("LinknameList") = UserDetailsDB.GetParentsLinkName()
            'Session("ChildNodes") = Session("LinknameList")
            'Session("ParentList") = UserDetailsDB.GetParentsName()
            Session("UserCode") = ""
            'Session("AccessLevel") = "05"
            'Session("LanguageID") = dt.Rows(0)("LanguageID").ToString
            'Session("EmailService") = dt.Rows(0)("EmailService")
            'Session("SMSService") = dt.Rows(0)("SMSService")
            ''Creating Session LanguageID & ValidationMessage By Ajit Kumar Singh
            Session("LanguageID") = dt.Rows(0)("LanguageID").ToString
            'added Report Branch Code and Report Branch Name in session 
            'Anchala Verma 16-Apr-2014
            Session("ReportBranch") = dt.Rows(0)("ReportBranch")
            Session("ReportBranchName") = dt.Rows(0)("ReportBranchName")
            ValidationMessageJS()
        End If
    End Sub


    Protected Sub btnok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnok.Click
        btnok.Enabled = False

        If Session("SPassword") = RijndaelSimple.Encrypt(txtSPassword.Text,
                                           RijndaelSimple.passPhrase,
                                           RijndaelSimple.saltValue,
                                           RijndaelSimple.hashAlgorithm,
                                           RijndaelSimple.passwordIterations,
                                           RijndaelSimple.initVector,
                                           RijndaelSimple.keySize) Then
            Try
                DLLogin.UpdateIP(Session("IP_ID"), Session("BranchCode"))
            Catch ex As Exception

            End Try
            SessionAllocation()

            Response.Redirect("~/Main.aspx", True)
        Else
            lblSResult.Visible = True
            btnok.Enabled = True
            lblSResult.Text = "Unsuccessful login.Please re-enter your information and try again."
            txtSPassword.Focus()
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Session("Chat") = "Chat"
    End Sub
    '' This Function put all validation message based on language into Session
    '' Created By Ajit kumar singh 24-AUG-2013
    Public Sub ValidationMessageJS()
        Dim dtVal As DataTable
        Dim LanguageID As Integer
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        dtVal = GlobalFunction.GetValidationMessage(LanguageID)
        Dim X As Integer = dtVal.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            str += dtVal.Rows(i).Item("MessageCode").ToString() + ":" + dtVal.Rows(i).Item("MessageText").ToString() + ":"
            If (dtVal.Rows(i).Item("MessageCode").ToString().Equals("4000")) Then
                Session("Process") = dtVal.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Session("Validation") = str
        Session("ValidationTable") = dtVal
    End Sub

    Protected Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Panel3.Visible = True
        Panel2.Visible = False
        txtUserId.Text = ""
        txtPassword.Text = ""
        lblSResult.Text = ""
        lblResults.Text = ""
    End Sub
    Protected Sub log1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles log1.Click
        Response.Redirect("FrmEnquiryLogin.aspx")
    End Sub
End Class
