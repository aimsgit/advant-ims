
Partial Class FormMonthlypaydetails
    Inherits BasePage
    Dim m As New MonthlyPayDetailsE
    Dim mb As New MonthlyPayDetailsB
    Dim month As String
    Dim year As Integer
    Dim Dept As Integer
    Dim dt As DataTable
    'Author-->Nakul Bharadwaj
    'Date---->30-Apr-2012

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            ddlMonth.Focus()
            'txtYear.Text = Format(Date.Today, "yyyy")
        End If
    End Sub
    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If Session("Privilages").ToString.Contains("W") Then
            If (Session("BranchCode") = Session("ParentBranch")) Then

                ddlMonth.Focus()

                month = ddlMonth.SelectedItem.Text
                year = ddlYear.SelectedItem.Text
                Dept = DDLDeptType.SelectedValue
                dt = mb.duplicate(month, year, Dept)
                Try
                    If dt.Rows.Count > 0 Then
                        lblS.Text = ""
                        lblE.Text = "Records already generated for the given month and year."
                    Else
                        mb.generate(month, year, Dept)
                        lblE.Text = ""
                        lblS.Text = "Records Generated Successfully."
                        GridView1.Visible = False
                    End If
                    month = ddlMonth.SelectedItem.Text
                    year = ddlYear.SelectedItem.Text
                    Dept = DDLDeptType.SelectedValue
                    DispGrid(month, year, Dept)

                Catch ex As Exception

                End Try
            Else
                lblE.Text = "You do not belong to this branch, cannot generate data."
                lblS.Text = ""
            End If
        Else
            lblE.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then

            lblE.Text = ""
            lblS.Text = ""
            Dim month As String
            Dim year As Integer
            Dim Dept As Integer
            month = ddlMonth.SelectedItem.Text
            year = ddlYear.SelectedItem.Text
            Dept = DDLDeptType.SelectedValue
            DispGrid(month, year, Dept)
        Else
            lblE.Text = "You do not have Read Privilage."
        End If
    End Sub

    Sub DispGrid(ByVal month As String, ByVal year As Integer, ByVal Dept As Integer)

        LinkButton1.Focus()
        Dim dt As New DataTable
        dt = mb.getgrid(month, year, Dept)
        Try
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Visible = True
                btnUpdate.Visible = True
            Else
                GridView1.Visible = False
                lblE.Text = "No Records Found."
                ddlMonth.Focus()
                lblS.Text = ""
                btnUpdate.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Session("Privilages").ToString.Contains("W") Then

            If (Session("BranchCode") = Session("ParentBranch")) Then
                Try
                    lblE.Text = ""
                    lblS.Text = ""
                    For Each grid As GridViewRow In GridView1.Rows
                        m.MD_ID = CType(grid.FindControl("MD_ID"), HiddenField).Value
                        If CType(grid.FindControl("txtdaysworked"), TextBox).Text = "" Then
                            m.DaysWorked = 0
                        Else
                            m.DaysWorked = CType(grid.FindControl("txtdaysworked"), TextBox).Text
                        End If
                        If CType(grid.FindControl("txtmonthins"), TextBox).Text = "" Then
                            m.MonthlyIncentive = "0.00"
                        Else
                            m.MonthlyIncentive = CType(grid.FindControl("txtmonthins"), TextBox).Text
                        End If
                        If CType(grid.FindControl("txtbonus"), TextBox).Text = "" Then
                            m.Bonus = "0.00"
                        Else
                            m.Bonus = CType(grid.FindControl("txtbonus"), TextBox).Text
                        End If
                        If CType(grid.FindControl("txtreimb"), TextBox).Text = "" Then
                            m.Reimbursements = "0.00"
                        Else
                            m.Reimbursements = CType(grid.FindControl("txtreimb"), TextBox).Text
                        End If

                        If CType(grid.FindControl("txtothrmonthpay"), TextBox).Text = "" Then
                            m.OtherMonthlyPayments = "0.00"
                        Else
                            m.OtherMonthlyPayments = CType(grid.FindControl("txtothrmonthpay"), TextBox).Text
                        End If
                        If CType(grid.FindControl("txtITded"), TextBox).Text = "" Then
                            m.ITDeduction = "0.00"
                        Else
                            m.ITDeduction = CType(grid.FindControl("txtITded"), TextBox).Text
                        End If
                        If CType(grid.FindControl("txtloanded"), TextBox).Text = "" Then
                            m.LoanDeduction = "0.00"
                        Else
                            m.LoanDeduction = CType(grid.FindControl("txtloanded"), TextBox).Text
                        End If
                        If CType(grid.FindControl("txttransded"), TextBox).Text = "" Then
                            m.TransportDeduction = "0.00"
                        Else
                            m.TransportDeduction = CType(grid.FindControl("txttransded"), TextBox).Text
                        End If
                        If CType(grid.FindControl("txtothrde"), TextBox).Text = "" Then
                            m.OtherDeduction = "0.00"
                        Else
                            m.OtherDeduction = CType(grid.FindControl("txtothrde"), TextBox).Text
                        End If
                        m.Remarks = CType(grid.FindControl("txtrmrk"), TextBox).Text
                        If CType(grid.FindControl("txtadvsal"), TextBox).Text = "" Then
                            m.Saladv = "0.00"
                        Else
                            m.Saladv = CType(grid.FindControl("txtadvsal"), TextBox).Text
                        End If
                        If CType(grid.FindControl("txtadvsalded"), TextBox).Text = "" Then
                            m.Advsalded = "0.00"
                        Else
                            m.Advsalded = CType(grid.FindControl("txtadvsalded"), TextBox).Text
                        End If
                        If CType(grid.FindControl("txtPLDays"), TextBox).Text = "" Then
                            m.PLDays = "0.00"
                        Else
                            m.PLDays = CType(grid.FindControl("txtPLDays"), TextBox).Text
                        End If
                        mb.update(m)

                    Next
                    lblS.Text = "Data Updated Successfully."
                    ddlMonth.Focus()
                Catch ex As Exception
                    lblE.Text = ""
                    lblS.Text = ""

                End Try
            Else
                lblE.Text = "You do not belong to this branch, cannot update data."
                lblS.Text = ""
            End If
        Else
            lblE.Text = "You do not have Write Privilage."
        End If
    End Sub
    'Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
    '    GridView1.EditIndex = -1
    '    m.MD_ID = CType(GridView1.Rows(e.RowIndex).FindControl("MD_ID"), HiddenField).Value
    '    m.DaysWorked = CType(GridView1.Rows(e.RowIndex).FindControl("txtdaysworked"), TextBox).Text
    '    m.MonthlyIncentive = CType(GridView1.Rows(e.RowIndex).FindControl("txtmonthins"), TextBox).Text
    '    m.Bonus = CType(GridView1.Rows(e.RowIndex).FindControl("txtbonus"), TextBox).Text
    '    m.Reimbursements = CType(GridView1.Rows(e.RowIndex).FindControl("txtreimb"), TextBox).Text
    '    m.OtherMonthlyPayments = CType(GridView1.Rows(e.RowIndex).FindControl("txtothrmonthpay"), TextBox).Text
    '    m.ITDeduction = CType(GridView1.Rows(e.RowIndex).FindControl("txtITded"), TextBox).Text
    '    m.LoanDeduction = CType(GridView1.Rows(e.RowIndex).FindControl("txtloanded"), TextBox).Text
    '    m.TransportDeduction = CType(GridView1.Rows(e.RowIndex).FindControl("txttransded"), TextBox).Text
    '    m.OtherDeduction = CType(GridView1.Rows(e.RowIndex).FindControl("txtothrde"), TextBox).Text
    '    m.Remarks = CType(GridView1.Rows(e.RowIndex).FindControl("txtrmrk"), TextBox).Text
    '    m.Saladv = CType(GridView1.Rows(e.RowIndex).FindControl("txtadvsal"), TextBox).Text
    '    m.Advsalded = CType(GridView1.Rows(e.RowIndex).FindControl("txtadvsalded"), TextBox).Text

    '    mb.update(m)
    '    lblS.Text = "Data Updated Sucessfully."
    '    lblE.Text = ""
    '    Dim month As String
    '    Dim year As Integer
    '    month = ddlMonth.SelectedItem.Text
    '    year = txtYear.Text
    '    DispGrid(month, year)
    '    GridView1.Visible = True
    'End Sub
    'Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
    '    GridView1.EditIndex = e.NewEditIndex
    '    Dim month As String
    '    Dim year As Integer
    '    month = ddlMonth.SelectedItem.Text
    '    year = txtYear.Text
    '    DispGrid(month, year)
    '    GridView1.Visible = True
    'End Sub
    'Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
    '    GridView1.EditIndex = -1
    '    Dim month As String
    '    Dim year As Integer
    '    month = ddlMonth.SelectedItem.Text
    '    year = txtYear.Text
    '    DispGrid(month, year)
    '    GridView1.Visible = True
    '    lblE.Text = ""
    '    lblS.Text = ""
    'End Sub

    Protected Sub ddlMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMonth.SelectedIndexChanged
        GridView1.Visible = False
        btnUpdate.Visible = False
        lblE.Text = ""
        lblS.Text = ""
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

        LinkButton1.Focus()
        Dim dt As New DataTable
        dt = mb.getgrid(ddlMonth.SelectedItem.Text, ddlYear.SelectedItem.Text, DDLDeptType.SelectedValue)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Visible = True
        btnUpdate.Visible = True
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
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging

        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        month = ddlMonth.SelectedItem.Text
        year = ddlYear.SelectedItem.Text
        Dept = DDLDeptType.SelectedValue
        DispGrid(month, year, Dept)
        GridView1.Visible = True
    End Sub
    Protected Sub btnclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnclear.Click
        If Session("Privilages").ToString.Contains("W") Then

            If (Session("BranchCode") = Session("ParentBranch")) Then
                Try
                    month = ddlMonth.SelectedItem.Text
                    year = ddlYear.SelectedItem.Text
                    Dept = DDLDeptType.SelectedValue
                    Dim clearcount As Integer = mb.ClearMarks(month, year, Dept)
                    If clearcount > 0 Then
                        lblE.Text = ""
                        lblS.Text = clearcount.ToString + " records cleared."
                        GridView1.Visible = False
                        btnUpdate.Visible = False
                    Else
                        lblS.Text = ""
                        lblE.Text = "No Records to Clear."
                    End If
                Catch ex As Exception
                    lblS.Text = ""
                    lblE.Text = "No Records to Clear."
                End Try
                'End If
            Else
                lblE.Text = "You do not belong to this branch, Cannot clear data."
                lblS.Text = ""
            End If
        Else
            lblE.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub BtnUpdateLoan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdateLoan.Click
        If Session("Privilages").ToString.Contains("W") Then

            For Each grid As GridViewRow In GridView1.Rows
                m.MD_ID = CType(grid.FindControl("MD_ID"), HiddenField).Value
                m.EmpCode = CType(grid.FindControl("lblEmpId"), Label).Text
                dt = mb.updateLoannDedc(m)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("txtloanded"), TextBox).Text = Format(dt.Rows(0).Item("MonthlyDed"), "0.00")
                Else
                    CType(grid.FindControl("txtloanded"), TextBox).Text = "0.00"
                End If
            Next
            lblS.Text = "Loan update Successfully."
            lblE.Text = ""
        Else
            lblE.Text = "You do not have Write Privilage."
        End If
    End Sub
End Class
