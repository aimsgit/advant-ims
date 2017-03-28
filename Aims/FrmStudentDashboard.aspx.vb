
Partial Class FrmStudentDashboard
    Inherits BasePage
    Dim StdID As Integer
    Dim StdCode As String
    Dim dt As New DataTable

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim heading As String
            heading = Session("RptFrmTitleName")
            Me.Lblheading.Text = heading
            If Session("LoginType") = "Others" Then
                'lblNames.Text = Session("StudentCode")
                'lblCodes.Text = Session("FrmParentName")
                'If Not IsPostBack Then
                HideTextboxes.Visible = False
                Hidebutton.Visible = False
                txtStdCode.Visible = False
                lblStdCode.Visible = False
                btnGenerate.Visible = False
                BtnBack.Visible = False
                dt = DBStudentDashboard.stddetails()
                If dt.Rows.Count > 0 Then
                    lblNames.Text = dt.Rows(0).Item("StdName").ToString
                    'txtfinanceyrs.Text = dt.Rows(0).Item("FinancialYear").ToString
                    lblCodes.Text = dt.Rows(0).Item("StdCode").ToString
                    StdID = dt.Rows(0).Item("Std_Id").ToString
                    StdCode = dt.Rows(0).Item("StdCode").ToString

                    dt = DBStudentDashboard.Generate(StdID, StdCode)
                    GridStudentDashBoard.Visible = True
                    GridStudentDashBoard.DataSource = dt
                    GridStudentDashBoard.DataBind()
                    'End If
                End If
            Else
                If Session("Form") = "frmStudentEnquiryForm.aspx" Then
                    Dim StdName As String
                    HideTextboxes.Visible = False
                    Hidebutton.Visible = False
                    txtStdCode.Visible = False
                    lblStdCode.Visible = False
                    btnGenerate.Visible = False
                    BtnBack.Visible = False
                    StdID = Request.QueryString.Get("StdID")
                    StdCode = Request.QueryString.Get("StdCode")
                    StdName = Request.QueryString.Get("StdName")
                    lblNames.Text = StdName
                    lblCodes.Text = StdCode
                    dt = DBStudentDashboard.Generate(StdID, StdCode)
                    GridStudentDashBoard.Visible = True
                    GridStudentDashBoard.DataSource = dt
                    GridStudentDashBoard.DataBind()
                    Exit Try
                End If
                lblCodes.Text = txtStdCode.Text
                If txtStdCode.Text <> "" Then
                    Splitter1(txtStdCode.Text)
                    lblname.Text = "Name : "
                    lblcode.Text = "Code : "
                Else
                    txtStdCode.AutoPostBack = True
                    Splitter1(txtStdCode.Text)
                    lblname.Text = ""
                    lblcode.Text = ""
                    lblNames.Text = ""
                End If
            End If
        Catch ex As Exception
            Response.Redirect("LogIn.aspx")
        End Try
    End Sub
    Sub Splitter1(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("StdCode") = parts(0).ToString()
            txtStdCode.Text = parts(0).ToString()
            lblNames.Text = parts(1).ToString()
            StdID = parts(2).ToString()
            ViewState("StdID") = StdID
            lblCodes.Text = txtStdCode.Text
            lblerrmsg.Text = ""
        Else
            txtStdCode.AutoPostBack = True
        End If
    End Sub

    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click

        Dim dt As New DataTable
        Try
            If Session("LoginType") = "Others" Then
                'txtStdCode.Visible = False
                'lblStdCode.Visible = False
                'dt = DBStudentDashboard.stddetails()
                'If dt.Rows.Count > 0 Then
                '    lblNames.Text = dt.Rows(0).Item("StdName").ToString
                '    lblCodes.Text = dt.Rows(0).Item("StdCode").ToString
                '    StdID = dt.Rows(0).Item("Std_Id").ToString
                '    dt = DBStudentDashboard.Generate(StdID)
                '    GridStudentDashBoard.Visible = True
                '    GridStudentDashBoard.DataSource = dt
                '    GridStudentDashBoard.DataBind()

                'End If
            Else

                StdID = ViewState("StdID")
                StdCode = ViewState("StdCode")
                If txtStdCode.Text = "" Then
                    lblerrmsg.Text = "Please Select Mandatory field."
                    GridStudentDashBoard.Visible = False
                    lblcode.Text = ""
                    lblCodes.Text = ""
                    lblname.Text = ""
                    lblNames.Text = ""

                Else
                    LinkButton1.Focus()
                    dt = DBStudentDashboard.Generate(StdID, StdCode)
                    If dt.Rows.Count > 0 Then
                        GridStudentDashBoard.Visible = True
                        GridStudentDashBoard.DataSource = dt
                        GridStudentDashBoard.DataBind()
                        lblerrmsg.Text = ""
                    Else
                        lblerrmsg.Text = "No Record to Display."
                        GridStudentDashBoard.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception
            lblerrmsg.Text = "Enter correct data."
        End Try
    End Sub

    Protected Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Response.Redirect("Default2.aspx")
    End Sub

    Protected Sub txtStdCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStdCode.TextChanged
        GridStudentDashBoard.Visible = False
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
