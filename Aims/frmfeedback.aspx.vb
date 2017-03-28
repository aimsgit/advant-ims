Partial Class frmfeedback
    Inherits System.Web.UI.Page
    Dim el As New ELFeedBackDetails
    Dim DL As New DLFeedBack
    Dim BL As New BLFeedBack
    Dim dt As New DataTable

    Protected Sub btnsend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsend.Click

        If Session("LoginType") = "Others" Then
            el.StudentCode = Session("StudentCode")
            dt = DLFeedBack.GetStudentDetails(el)
            el.Email = dt.Rows(0).Item("Std_email").ToString
            el.ContactNo = dt.Rows(0).Item("ContactNo").ToString
            el.ChildLink = Session("Code")
            el.FeedBack = RBEmpType.Text
            el.Suggestion = txtsuggst.Text
            el.BranchName = Session("BranchName")
            el.UserName = Session("StudentName")
            DL.InsertFeedBackStudent(el)
            Dim session1 As String
            session1 = Session("Form")
            'If Session("Form") = "" Then
            Response.Redirect("Main.aspx")
        Else
            el.Empid = Session("EmpId")
            dt = DLFeedBack.GetENPLOYEEDetails(el)
            el.Email = dt.Rows(0).Item("Email").ToString
            el.ContactNo = dt.Rows(0).Item("ContactNo").ToString
            el.ChildLink = Session("Code")
            el.FeedBack = RBEmpType.Text
            el.Suggestion = txtsuggst.Text
            el.BranchName = Session("BranchName")
            el.UserName = Session("EmpName")
            DL.InsertFeedBackEmp(el)
            Dim session1 As String
            session1 = Session("Form")
            'If Session("Form") = "" Then
            Response.Redirect("Main.aspx")

            'Else
            'Response.Redirect("" + session1 + "")

            'lblsend.Text = "Data send successfully"
            'txtsuggst.Text = ""
            'End If
        End If
    End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'If Not IsPostBack Then



    '    '    Dim heading As String
    '    '    Dim code As Integer
    '    '    Dim empid As String
    '    '    heading = Session("RptFrmTitleName")
    '    '    Me.lblHeading.Text = heading
    '    '    code = Session("Code")
    '    '    empid = Session("EmpId")
    '    'End If
    'End Sub
End Class
