Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Partial Class frmEmpAttendance
    Inherits BasePage
    Dim BL As New EmpAttdBL
    Dim EL As New Employee
    Dim dt As New Data.DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        Try
            txtAttdDate.Text = Format(Today, "dd-MMM-yyyy")
            If Not IsPostBack Then
                txtAttDate2.Text = Format(Today, "dd-MMM-yyyy")
                txtEmpName.Text = Session("EmpName")
                txtEmpCode.Text = Session("EmpCode")
                HidEmpId.Value = Session("EmpID")
                EL.Emp_Id = Session("EmpID")
                dt = BL.EmpAttd(EL)
                If dt.Rows.Count > 0 Then
                    txtTimein.Text = dt.Rows(0).Item("LoginTime").ToString()
                    txtTimeout.Text = dt.Rows(0).Item("LogoffTime").ToString()
                    txtRemarks.Text = dt.Rows(0).Item("Remarks").ToString()
                Else
                    txtTimein.Text = ""
                    txtTimeout.Text = ""
                End If
            End If
            txtAttdDate.Enabled = False
            txtEmpCode.Enabled = False
            txtEmpName.Enabled = False
            txtTimein.Enabled = False
            txtTimeout.Enabled = False
            btnTimeIN.Focus()
        Catch ex As Exception
            lblErrorMsg.Text = "Not Accessible for Institute Admin."
            lblmsg.Text = ""
            btnTimeIN.Enabled = False
            btnTimeout.Enabled = False
        End Try
    End Sub
    Protected Sub GVEmpAttd_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVEmpAttd.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim El As New Employee
            El.AttendanceID = CType(GVEmpAttd.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            Dim i As Integer = BL.GetByDeleteEmp(El)
            lblmsg.Text = "Data deleted Successfully."
            btnTimeIN.Focus()
            lblErrorMsg.Text = ""
            El.StartDate = txtAttdDate.Text
            El.EndDate = txtAttDate2.Text
            dt = BL.getDetails(El)
            If dt.Rows.Count > 0 Then
                dt = BL.getDetails(El)
                GVEmpAttd.DataSource = dt
                GVEmpAttd.Visible = True
                GVEmpAttd.DataBind()
                GVEmpAttd.PageIndex = ViewState("PageIndex")
                DisplayGrid()
            Else
                lblmsg.Text = ""
                lblErrorMsg.Text = "No Records to display."
                btnTimeIN.Focus()
                txtTimein.Text = ""
                GVEmpAttd.Visible = False
                txtTimeout.Text = ""
                txtRemarks.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub btnTimeIN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimeIN.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblErrorMsg.Text = ""
            EL.Emp_Code = txtEmpCode.Text
            EL.Emp_Id = Session("EmpID")
            EL.StartDate = txtAttdDate.Text
            EL.Remarks = txtRemarks.Text
            dt = BL.EmpAttendanceduplicate(EL)
            If dt.Rows.Count > 0 Then
                lblErrorMsg.Visible = True
                lblErrorMsg.Text = "You are already logged In."
                btnTimeIN.Focus()
                GVEmpAttd.Visible = False
                lblmsg.Text = ""
            Else
                EL.Emp_Code = txtEmpCode.Text
                EL.Emp_Id = Session("EmpID")
                txtTimein.Text = BL.getTimeIn(EL)
                lblmsg.Text = "You have been successfully logged In."
                btnTimeout.Focus()
                lblErrorMsg.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot Time In."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub btnTimeout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimeout.Click
        'If txtTimeout.Text <> "" Then
        '    lblErrorMsg.Text = "You are already logged out."
        '    lblmsg.Text = ""
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If txtTimein.Text = "" Then
                lblErrorMsg.Text = "First you have to login."
                btnTimeIN.Focus()
                txtTimein.Focus()
                lblmsg.Text = ""
            Else
                'txtTimeout.Text = TimeOfDay()
                EL.Emp_Id = Session("EmpID")
                EL.Remarks = txtRemarks.Text
                txtTimeout.Text = BL.getTimeout(EL)
                lblmsg.Text = "You have been successfully logged out."
                btnview.Focus()
                GVEmpAttd.Visible = False
                lblErrorMsg.Text = ""
                'btnTimeout.Enabled = False
                'btnTimeIN.Enabled = False
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot Time Out."
            lblmsg.Text = ""
        End If

          
    End Sub

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        LinkButton1.Focus()
        lblErrorMsg.Text = ""
        lblmsg.Text = ""
        Try
            EL.StartDate = txtAttdDate.Text
            If txtAttDate2.Text = "" Then
                lblmsg.Text = ""
                lblErrorMsg.Text = "Please Select from Date."
                txtAttDate2.Focus()
                Exit Sub
            Else
                EL.EndDate = txtAttDate2.Text
                If CType(txtAttDate2.Text, Date) > CType(txtAttdDate.Text, Date) Then
                    lblmsg.Text = ""
                    lblErrorMsg.Text = "From date should not be greater than date."
                    txtAttDate2.Focus()
                    Exit Sub
                End If
            End If
            dt = BL.getDetails(EL)
            If dt.Rows.Count > 0 Then
                GVEmpAttd.DataSource = dt
                GVEmpAttd.Visible = True
                ViewState("PageIndex") = 0
                GVEmpAttd.PageIndex = 0
                GVEmpAttd.DataBind()
            Else
                lblErrorMsg.Text = "No Records to display."
                lblmsg.Text = ""
                txtTimein.Text = ""
                txtTimeout.Text = ""
                txtRemarks.Text = ""
                GVEmpAttd.Visible = False
            End If
        Catch ex As InvalidCastException
            lblErrorMsg.Text = "Date is not valid."
            txtAttDate2.Focus()
            lblmsg.Text = ""
        End Try
    End Sub
    Sub DisplayGrid()
        Try
            EL.StartDate = txtAttdDate.Text
            EL.EndDate = txtAttDate2.Text
            dt = BL.getDetails(EL)
            If dt.Rows.Count > 0 Then
                GVEmpAttd.DataSource = dt
                GVEmpAttd.Visible = True
                GVEmpAttd.DataBind()
            Else
                lblErrorMsg.Text = "No Records to display."
                txtAttDate2.Focus()
                lblmsg.Text = ""
                txtTimein.Text = ""
                txtTimeout.Text = ""
                txtRemarks.Text = ""
                GVEmpAttd.Visible = False
            End If
        Catch ex As InvalidCastException
            lblErrorMsg.Text = "Please select from date."
            txtAttDate2.Focus()
            lblmsg.Text = ""
        End Try
    End Sub
    Protected Sub GVEmpAttd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVEmpAttd.PageIndexChanging
        GVEmpAttd.PageIndex = e.NewPageIndex
        'GVEmpAttd.DataSource = dt
        'GVEmpAttd.DataBind()
        ViewState("PageIndex") = GVEmpAttd.PageIndex
        DisplayGrid()
        GVEmpAttd.Visible = True
    End Sub

    Protected Sub GVEmpAttd_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVEmpAttd.Sorting
       
        Dim sortingDirection As String = String.Empty
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        EL.StartDate = txtAttdDate.Text
        EL.EndDate = txtAttDate2.Text
        dt = BL.getDetails(EL)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVEmpAttd.DataSource = sortedView
        GVEmpAttd.DataBind()
    End Sub

    Public Property dir() As SortDirection
        Get
            If ViewState("dirState") Is Nothing Then
                ViewState("dirState") = SortDirection.Descending
            End If
            Return DirectCast(ViewState("dirState"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("dirState") = Value
        End Set
    End Property
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
