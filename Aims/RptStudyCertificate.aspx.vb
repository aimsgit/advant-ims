
Partial Class RptStudyCertificate
    Inherits BasePage
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim BrID As String
        Dim AID As Integer = DDLA_Year.SelectedValue
        Dim CID As Integer = DDLCourse.SelectedValue
        Dim BID As Integer = DDLBatch.SelectedValue
        Dim country As Integer = DDLCountry.SelectedValue
        Dim Student As Integer = ddlStudent.SelectedValue
        BrID = DDLBranch.SelectedValue
        If DDLBranch.SelectedItem.Value = "0" Or DDLA_Year.SelectedItem.Value = "0" Or DDLCourse.SelectedItem.Value = "0" Or DDLBatch.SelectedItem.Value = "0" Then
            msginfo.Visible = True
            msginfo.Text = ValidationMessage(1100)
            DDLBranch.Focus()
        Else
            Dim qrystring As String = "RptStudyCertificateV.aspx?" & QueryStr.Querystring() & "&BrID=" & BrID & "&AID=" & AID & "&CID=" & CID & "&BID=" & BID & "&country=" & country & "&Student=" & Student
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ValidationMessage(1014)
        End If

    End Sub


    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub DDLBranch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLBranch.TextChanged
        DDLBranch.Focus()
    End Sub

    Protected Sub DDLA_Year_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLA_Year.TextChanged
        DDLA_Year.Focus()
    End Sub

    Protected Sub DDLCourse_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLCourse.TextChanged
        DDLCourse.Focus()
    End Sub

    Protected Sub DDLBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLBatch.TextChanged
        DDLBatch.Focus()
    End Sub

    Protected Sub DDLCountry_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLCountry.TextChanged
        DDLCountry.Focus()
    End Sub

    Protected Sub ddlStudent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStudent.TextChanged
        ddlStudent.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            
            'If HttpContext.Current.Session("BranchType_ID") = "04" Or HttpContext.Current.Session("BranchType_ID") = "03" Or HttpContext.Current.Session("BranchType_ID") = "02" Or HttpContext.Current.Session("BranchType_ID") = "01" Then
            'Else
            DDLBranch.SelectedValue = HttpContext.Current.Session("BranchCode")
            'End If
        End If
    End Sub
    'Code written fro multilingual by Niraj on 11 Dec 2013
    ''Retriving the text of controls based on Language

    
    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        dt2 = Session("ValidationTable")
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function
End Class
