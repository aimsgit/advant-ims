Imports attendance
Imports System.SerializableAttribute
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Partial Class frmEmpAttdView
    Inherits BasePage
    Dim Bll As New AttendanceB
    Dim Dll As New AttendanceD
    
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim Ecode As Integer
        Dim Bcode As String
        Ecode = ddlEmpname.SelectedValue
        Bcode = CmbBranch.SelectedValue
        If txtAttdDate.Text = "" Then
            msginfo.Text = "Please enter all Mandatory Fields."
        Else
            If CmbBranch.SelectedValue = "0" Or txtAttdDate.Text = "" And txtToDate.Text = "" Then
                msginfo.Text = "Please enter all Mandatory Fields."
            Else
                Try
                    If CType(txtAttdDate.Text, Date) > CType(txtToDate.Text, Date) Then
                        msginfo.Text = "To Date should be greater than From Date."
                    Else
                        msginfo.Text = " "
                        Dim qrystring As String = "rpt_EmployeAttendanceV.aspx?" & QueryStr.Querystring() & "&AttdDate=" & txtAttdDate.Text & "&ToDate=" & txtToDate.Text & "&branchcode=" & CmbBranch.SelectedValue & "&Ecode=" & Ecode & "&Bcode=" & Bcode
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                    End If
                Catch ex As Exception
                    msginfo.Text = "Please enter all Mandatory Fields."
                End Try
            End If
        End If
    End Sub
    
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim CloseDate As Date
            Dim cd As String
            CloseDate = System.DateTime.Now
            cd = CloseDate.ToString("dd-MMM-yyyy")
            txtToDate.Text = cd
            txtAttdDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            'If HttpContext.Current.Session("BranchType_ID") = "04" Or HttpContext.Current.Session("BranchType_ID") = "03" Or HttpContext.Current.Session("BranchType_ID") = "02" Or HttpContext.Current.Session("BranchType_ID") = "01" Then
            'Else
            CmbBranch.SelectedValue = HttpContext.Current.Session("BranchCode")
            'End If
        End If


    End Sub

    Protected Sub CmbBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBranch.SelectedIndexChanged
        msginfo.Text = " "
    End Sub

    Protected Sub ddlEmpname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpname.TextChanged
        'ddlEmpname.Focus()
    End Sub
End Class
