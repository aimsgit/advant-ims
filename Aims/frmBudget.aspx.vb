
Partial Class frmBudget
    Inherits BasePage
    Dim Budget As New Budget
    Dim DLBudget As New DLBudget
    Dim BLBudget As New BLBudget
    Dim dt, dt1 As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
        If Not Page.IsPostBack Then
            Dim heading As String
            ViewState("heading") = Session("RptFrmTitleName")
            Me.Lblheading.Text = ViewState("heading")
            txtApprvedDate.Text = Format(Today, "dd-MMM-yyyy")
            txtRevisedBudgetDate.Text = Format(Today, "dd-MMM-yyyy")
            txtStatusDate.Text = Format(Today, "dd-MMM-yyyy")
            'txtRevisedBudget.Text = 0.0
            ddlacadyear.Focus()

        End If
        Calculate()
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ddlacadyear.Focus()
        'code for Insert And Update Budget by Nitin 23-05-2012
        If (Session("BranchCode") = Session("ParentBranch")) Then
            msginfo.Text = ""
            lblmsg.Text = ""
            Try
                Budget.Year = ddlacadyear.SelectedValue
                Budget.Project_ID = DdlProjectName.SelectedValue

                If TxtProjecttEstimate.Text = "" Then
                    Budget.Project_Estimate = 0
                Else
                    Budget.Project_Estimate = TxtProjecttEstimate.Text
                End If
                If txtEstimateDate.Text = "" Then
                    msginfo.Text = "Estimate Date is Mandatory."
                    lblmsg.Text = ""
                Else
                    Budget._DateOfEstimation = txtEstimateDate.Text
                End If
                If txtApprvedBudget.Text = "" Then
                    Budget.Approved_Budget = 0
                Else
                    Budget.Approved_Budget = txtApprvedBudget.Text
                End If

                If txtApprvedDate.Text = "" Then
                    msginfo.Text = "Approval Date is Mandatory."
                    lblmsg.Text = ""
                Else
                    Budget.DateOfApproval = txtApprvedDate.Text
                End If

                If txtRevisedBudget.Text = "" Then
                    Budget.Revised_Budget = 0.0
                Else
                    Budget.Revised_Budget = txtRevisedBudget.Text
                End If

                If txtRevisedBudgetDate.Text = "" Then
                    Budget.DateRevBudget = "1/1/3000"
                Else
                    Budget.DateRevBudget = txtRevisedBudgetDate.Text
                End If

                If txtAmountUsed.Text = "" Then
                    Budget.AmountUsed = 0.0
                Else
                    Budget.AmountUsed = txtAmountUsed.Text
                End If
                If txtAmountUsedpercnt.Text = "" Then
                    Budget.AmountUsedPercent = 0
                Else
                    Budget.AmountUsedPercent = txtAmountUsedpercnt.Text
                End If

                If txtProjectProgress.Text = "" Then
                    Budget.Progress_Percent = 0.0
                Else
                    Budget.Progress_Percent = txtProjectProgress.Text
                End If

                If txtStatusDate.Text = "" Then
                    Budget.Status_Date = "1/1/3000"
                Else
                    Budget.Status_Date = txtStatusDate.Text
                End If

                Budget.Remarks = txtRemarks.Text

                If txtAmountUsed.Text = "" Then
                    txtAmountUsed.Text = 0
                Else
                    Budget.Used_Budget = txtAmountUsed.Text
                End If

                'And txtRevisedBudget.Text = "0.00"

                'If txtRevisedBudget.Text = "" Then
                '    Dim AmountUsed As Long
                '    AmountUsed = (txtAmountUsed.Text) * 100 / (txtApprvedBudget.Text)
                '    txtAmountUsedpercnt.Text = AmountUsed
                '    AmountUsed = ViewState("AmountUsed")

                'ElseIf txtRevisedBudget.Text = "0.00" Then
                '    txtRevisedBudget.Text = 0.0
                'Else
                '    Dim Amtusd As Double
                '    Amtusd = ((CInt(txtAmountUsed.Text) * 100) / CInt(txtRevisedBudget.Text))
                '    txtAmountUsedpercnt.Text = Amtusd
                'End If
                'Budget.AmountUsedPercent = ViewState("AmountUsed")



                If BtnSave.Text = "UPDATE" Then
                    Budget.BudgetID = ViewState("BudgetID")
                    dt = BLBudget.CheckDuplicate(Budget)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = "Data Already Exists."
                        lblmsg.Text = ""
                    Else
                        If Budget.DateOfEstimation > Budget.Status_Date Then
                            msginfo.Text = "Status date should be greater than estimate date"
                            lblmsg.Text = ""
                            txtStatusDate.Focus()
                        Else

                            BLBudget.Update(Budget)
                            lblmsg.Text = "Data Updated Successfully."
                            msginfo.Text = ""
                            BtnSave.Text = "ADD"
                            BtnDetails.Text = "VIEW"
                            ''DisplayGrid()
                            GridView1.PageIndex = ViewState("PageIndex")
                            display()
                            GridView1.Visible = True
                            clear()
                            'txtRevisedBudget.Text = 0
                        End If
                    End If
                ElseIf BtnSave.Text = "ADD" Then
                    If Budget.DateOfEstimation > Budget.Status_Date Then
                        msginfo.Text = "Status date should be greater than estimate date"
                        lblmsg.Text = ""
                        txtStatusDate.Focus()
                    Else
                        Budget.BudgetID = 0
                        dt = BLBudget.CheckDuplicate(Budget)
                        If dt.Rows.Count > 0 Then
                            msginfo.Text = "Data Already Exists."
                            lblmsg.Text = ""
                        Else
                            BLBudget.Insert(Budget)
                            lblmsg.Text = "Data Saved Successfully."
                            msginfo.Text = ""
                            ''DisplayGrid()
                            ViewState("PageIndex") = 0
                            GridView1.PageIndex = 0
                            display()
                            clear()
                            'txtRevisedBudget.Text = 0
                        End If
                    End If
                End If
            Catch ex As Exception
                msginfo.Text = "Enter correct data."
                lblmsg.Text = ""
            End Try
        Else
            msginfo.Text = "You do not belong to this branch, cannot add/update data."
            lblmsg.Text = ""
        End If
    End Sub
    Sub clear()
        TxtProjecttEstimate.Text = ""
        txtEstimateDate.Text = ""
        txtApprvedBudget.Text = ""
        'txtApprvedDate.Text = ""
        txtRevisedBudget.Text = ""
        'txtRevisedBudgetDate.Text = ""
        txtAmountUsed.Text = ""
        txtAmountUsedpercnt.Text = ""
        txtProjectProgress.Text = ""
        'txtStatusDate.Text = ""
        txtRemarks.Text = ""
    End Sub
    Sub DisplayGrid()
        Budget.BudgetID = 0
        dt = BLBudget.GetBudget(Budget)
        
        
        If dt.Rows.Count > 0 Then

            GridView1.DataSource = dt
            GridView1.DataBind()
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblrevisedBudgetDate"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("lblrevisedBudgetDate"), Label).Text = ""
                End If
            Next
            
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblStatusDate"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("lblStatusDate"), Label).Text = ""
                End If
            Next
        Else
            lblmsg.Text = ""
            msginfo.Text = "No records to display."
        End If
    End Sub
    Sub display()
        Budget.BudgetID = 0
        If ddlacadyear.SelectedValue = "" Then
            Budget.Year = 0
        Else
            Budget.Year = ddlacadyear.SelectedValue
        End If

        If DdlProjectName.SelectedValue = "" Then
            Budget.Project_ID = 0
        Else
            Budget.Project_ID = DdlProjectName.SelectedValue
        End If
        dt = BLBudget.GetBudget(Budget)
       
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblrevisedBudgetDate"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("lblrevisedBudgetDate"), Label).Text = ""
                End If
            Next
            'For Each rows As GridViewRow In GridView1.Rows
            '    If Format(CType(rows.FindControl("lblrevisedBudgetDate"), Label).Text, "dd-MMM-yyyy") = "01-Jan-3000" Then
            '        CType(rows.FindControl("lblrevisedBudgetDate"), Label).Text = ""
            '    End If
            'Next
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblStatusDate"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("lblStatusDate"), Label).Text = ""
                End If
            Next
            'If txtRevisedBudget.Text = "" Then
            '    GridView1.Columns(10).Visible = True
            '    GridView1.Columns(11).Visible = False
            'Else
            '    GridView1.Columns(11).Visible = True
            '    GridView1.Columns(10).Visible = False
            'End If
            GridView1.Enabled = True
            GridView1.Visible = True


        Else
            'msginfo.Visible = True
            lblmsg.Text = ""
            msginfo.Text = "No records to display."
        End If
    End Sub
    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        LinkButton1.Focus()
        'code for Get Budget Details By Nitin 23-05-2012

        lblmsg.Text = ""
        msginfo.Text = ""
        If BtnDetails.Text = "VIEW" Then
            If ddlacadyear.SelectedValue = "" Then
                Budget.Year = 0
            Else
                Budget.Year = ddlacadyear.SelectedValue
            End If

            If DdlProjectName.SelectedValue = "" Then
                Budget.Project_ID = 0
            Else
                Budget.Project_ID = DdlProjectName.SelectedValue
            End If
            If txtRevisedBudget.Text = "" Then
                Budget.Revised_Budget = 0
            Else
                Budget.Revised_Budget = txtRevisedBudget.Text
            End If
            BLBudget.GetBudget(Budget)
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            'display()
            DisplayGrid()
            GridView1.Visible = True
            'clear()
            'txtRevisedBudget.Text = 0.0
        ElseIf BtnDetails.Text = "BACK" Then
            BtnSave.Text = "ADD"
            BtnDetails.Text = "VIEW"
            GridView1.PageIndex = ViewState("PageIndex")
            DisplayGrid()
            GridView1.Visible = True
            GridView1.Enabled = True
            clear()
            'txtRevisedBudget.Text = 0.0
        End If
      
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        'code for Row Changing For Grid By Nitin 23-05-2012
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        GridView1.DataBind()
        DisplayGrid()
        GridView1.Visible = True
    End Sub

    'code for Delete Budget By Nitin  23-05-2012
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            BLBudget.DeleteBudget(CType(GridView1.Rows(e.RowIndex).FindControl("lblBudgetID"), HiddenField).Value())
            GridView1.DataBind()
            lblmsg.Text = "Data deleted Successfully."
            msginfo.Text = ""
            ddlacadyear.Focus()
            GridView1.PageIndex = ViewState("PageIndex")
            'DisplayGrid()
            Budget.BudgetID = 0
            dt = BLBudget.GetBudget(Budget)
            GridView1.DataSource = dt
            GridView1.DataBind()
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblrevisedBudgetDate"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("lblrevisedBudgetDate"), Label).Text = ""
                End If
            Next

            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblStatusDate"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("lblStatusDate"), Label).Text = ""
                End If
            Next
            GridView1.Visible = True
            'clear()
            'txtRevisedBudget.Text = 0
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub

    'code for Row Editting Budget  By Nitin 24-05-2012

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing

        msginfo.Text = ""
        lblmsg.Text = ""
        'BLBudget.BudgetID = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblTranid"), HiddenField).Value
        ViewState("BudgetID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblBranchIDAuto"), Label).Text
        ddlacadyear.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblAcode"), Label).Text
        DdlProjectName.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblprjctMastr"), Label).Text
        TxtProjecttEstimate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblProjectestimate"), Label).Text
        txtEstimateDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbldateofEstimation"), Label).Text
        txtApprvedBudget.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblApprovedBudget"), Label).Text
        txtApprvedDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblApprovedDate"), Label).Text
        txtRevisedBudget.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRevisedBudget"), Label).Text
        txtRevisedBudgetDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblrevisedBudgetDate"), Label).Text
        txtAmountUsed.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblAmountUsed"), Label).Text
        'If txtRevisedBudget.Text = "" Then
        '    txtAmountUsedpercnt.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPerAmntUseddd"), Label).Text
        'Else
        '    txtAmountUsedpercnt.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPerAmntUsed"), Label).Text
        'End If
        txtProjectProgress.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblProjectProgress"), Label).Text
        txtStatusDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblStatusDate"), Label).Text
        txtRemarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
        Calculate()
        Budget.BudgetID = ViewState("BudgetID")
        BtnSave.Text = "UPDATE"
        BtnDetails.Text = "BACK"
        Budget.BudgetID = ViewState("BudgetID")
        dt = BLBudget.GetBudget(Budget)
        GridView1.DataSource = dt
        GridView1.DataBind()
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblrevisedBudgetDate"), Label).Text = "01-Jan-3000" Then
                CType(rows.FindControl("lblrevisedBudgetDate"), Label).Text = ""
            End If
        Next
        'For Each rows As GridViewRow In GridView1.Rows
        '    If Format(CType(rows.FindControl("lblrevisedBudgetDate"), Label).Text, "dd-MMM-yyyy") = "01-Jan-3000" Then
        '        CType(rows.FindControl("lblrevisedBudgetDate"), Label).Text = ""
        '    End If
        'Next
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblStatusDate"), Label).Text = "01-Jan-3000" Then
                CType(rows.FindControl("lblStatusDate"), Label).Text = ""
            End If
        Next
        'If txtRevisedBudget.Text = "" Then
        '    GridView1.Columns(10).Visible = True
        '    GridView1.Columns(11).Visible = False
        'Else
        '    GridView1.Columns(11).Visible = True
        '    GridView1.Columns(10).Visible = False
        'End If
        GridView1.Enabled = True
        GridView1.Visible = True
        GridView1.Enabled = False
        GridView1.Visible = True
      
    End Sub
    'Code For Auto Fill percentage of amount used  By Nitin 24-05-2012
    

    Protected Sub ddlacadyear_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlacadyear.TextChanged
        ddlacadyear.Focus()
    End Sub

   
    Sub Calculate()
        Dim AmtUsedPer As Integer

        If txtRevisedBudget.Text = "" Or txtRevisedBudget.Text = "0" Or txtRevisedBudget.Text = "0.00" Then
            If txtAmountUsed.Text = "" Or txtAmountUsed.Text = "0" Or txtAmountUsed.Text = "0.00" Then
                txtAmountUsedpercnt.Text = 0
            Else
                AmtUsedPer = (txtAmountUsed.Text) * 100 / (txtApprvedBudget.Text)
                txtAmountUsedpercnt.Text = AmtUsedPer
            End If
        Else

            If txtAmountUsed.Text = "" Or txtAmountUsed.Text = "0" Or txtAmountUsed.Text = "0.00" Then
                txtAmountUsedpercnt.Text = 0
            Else
                AmtUsedPer = (txtAmountUsed.Text) * 100 / (txtRevisedBudget.Text)
                txtAmountUsedpercnt.Text = AmtUsedPer
            End If
        End If
    End Sub

    Protected Sub txtAmountUsed_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountUsed.TextChanged
        Calculate()
    End Sub

    Protected Sub txtRevisedBudget_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRevisedBudget.TextChanged
        Calculate()
    End Sub

    Protected Sub txtApprvedBudget_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApprvedBudget.TextChanged
        Calculate()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
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
        Budget.BudgetID = 0
        dt = BLBudget.GetBudget(Budget)
            
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

