Imports System.IO
Imports System.Collections.Generic
Imports System.Data
Imports StudentManager
Partial Class FrmEmpTransferwitoutTreeview
    Inherits BasePage
    Dim GlobalFunction As New GlobalFunction
    Dim Chk As Boolean = False
    Dim Bnk As New BankManager
    Dim Ent As New EmpTransE
    Dim empb As New EmpTranferB


    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        txtEmp.Focus()
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                Dim dt As New DataTable

                'Ent.EmpCD = txtEmp.Text
                Ent.EmpName = txtEmpName.Text
                Ent.DOL = txtDOL.Text

                Ent.FRMBRANCH = txtEmpBranch.Text
                If Ent.FRMBRANCH = "" Then
                    lblmsg.Text = " Enter Correct Employee Code."
                    msginfo.Text = ""
                Else
                    'End If
                    Ent.TransferRemarks = txtRemarks.Text
                    Ent.TOBRANCH = ddlToBrch.Text
                    Ent.DOJ = txtDOJ.Text
                    Ent.EmpID = HidempId.Value
                    Ent.EmpCode = txtEmp.Text

                    Dim split As String() = ddlToBrch.SelectedItem.Text.Split(New Char() {":"})

                    If (txtEmpBranch.Text = split(1)) Then
                        msginfo.Text = ""
                        lblmsg.Text = "From Branch and To Branch cannot be Same."
                        ddlToBrch.Focus()

                    ElseIf (CDate(txtDOL.Text) > CDate(txtDOJ.Text)) Then
                        msginfo.Text = ""
                        lblmsg.Text = " Date Of Joining should be greater than Date Of Leaving."
                        txtDOJ.Focus()
                    Else

                        empb.InsertRecord(Ent)
                        'GridView1.DataBind()
                        GridView1.Visible = True
                        msginfo.Text = ""
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0
                        dispgrid()
                        msginfo.Text = "Employee Transfer request sent for approval.<br />On approval current USERID will be Deleted. Please create new USERID in " + split(1) + "."
                        lblmsg.Text = ""
                        clear()
                    End If
                End If
            Else
                lblmsg.Text = "You do not belong to this branch, Cannot tranfer employee."
                msginfo.Text = ""
            End If

        Catch ex As Exception
            lblmsg.Text = " Enter Correct Date."
        End Try
    End Sub

    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        LinkButton1.Focus()

        'Ent.id = 0
        lblmsg.Text = ""
        msginfo.Text = ""
        ViewState("PageIndex") = 0
        GridView1.PageIndex = 0
        dispgrid()
        GridView1.Visible = True
        GridView1.Enabled = True

    End Sub

    Sub dispgrid()
        Dim empd As New EmpTranferB
        'Dim pre As String
        'pre = txtEmp.Text
        Dim dt As New DataTable
        Try
            dt = empd.GetEmpDetails()
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
                For Each rows As GridViewRow In GridView1.Rows
                    If CType(rows.FindControl("Label3"), Label).Text = "01-Jan-3000" Then
                        CType(rows.FindControl("Label3"), Label).Text = ""
                    End If
                    If CType(rows.FindControl("Label5"), Label).Text = "01-Jan-3000" Then
                        CType(rows.FindControl("Label5"), Label).Text = ""
                    End If
                Next
            Else
                lblmsg.Text = "No records to display."
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Sub Enable()
        GridView1.Enabled = True
        BtnDetails.Visible = True
    End Sub
    Sub Disable()
        GridView1.Enabled = False
        BtnDetails.Visible = False
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        dispgrid()
    End Sub
    Sub clear()
        txtEmp.Text = ""
        txtEmpName.Text = ""
        txtEmpBranch.Text = ""
        txtRemarks.Text = ""
        ddlToBrch.SelectedValue = 0
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            txtDOJ.Text = Format(Today, "dd-MMM-yyyy")
            txtDOL.Text = Format(Today, "dd-MMM-yyyy")
            txtEmp.Focus()
        End If
        BtnDetails.Visible = True
        BtnSave.Visible = True
        If Session("RowID") <> "" Then
            Dim dt As New DataTable
            Try
                Dim empd As New EmpTranferB
                dt = empd.GetEmpDetails(CInt(Session("RowID")))
                If dt.Rows.Count > 0 Then
                    txtEmp.Text = dt.Rows(0).Item("Emp_Code")
                    txtEmp.ReadOnly = True
                    txtEmpName.Text = dt.Rows(0).Item("Emp_Name")
                    txtEmpName.ReadOnly = True
                    txtDOL.Text = Format(dt.Rows(0).Item("ToBeDOL"), "dd-MMM-yyyy")
                    txtDOL.ReadOnly = True
                    txtEmpBranch.Text = dt.Rows(0).Item("BranchName")
                    txtEmpBranch.ReadOnly = True
                    ddlToBrch.SelectedValue = dt.Rows(0).Item("ToBeTransferedTo")
                    ddlToBrch.Enabled = False
                    txtDOJ.Text = Format(dt.Rows(0).Item("ToBeDOJ"), "dd-MMM-yyyy")
                    txtDOJ.ReadOnly = True
                    txtRemarks.Text = dt.Rows(0).Item("TranferRemarks")
                    txtRemarks.ReadOnly = True
                    BtnDetails.Visible = False
                    BtnSave.Visible = False
                Else
                    lblmsg.Text = "No records to display."
                End If
            Catch ex As Exception
            End Try
            Session("RowID") = ""
        Else
            BtnDetails.Visible = True
            BtnSave.Visible = True
        End If
    End Sub

    Protected Sub ddlToBrch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlToBrch.TextChanged
        ddlToBrch.Focus()
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        Dim empd As New EmpTranferB
        dt = empd.GetEmpDetails()
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
    End Sub
    Public Property dir() As SortDirection
        Get
            If ViewState("dirState") Is Nothing Then
                ViewState("dirState") = SortDirection.Descending
            End If
            Return DirectCast(ViewState("dirState"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("dirState") = value
        End Set
    End Property
End Class


