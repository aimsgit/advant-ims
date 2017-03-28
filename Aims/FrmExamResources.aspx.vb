'Imports System.IO
'Imports System.Data
'Imports System.Collections.Generic
'Imports System.Data.SqlClient

Partial Class FrmExamResources
    Inherits BasePage
    Dim El As New ELExamResources
    Dim BL As New BLExamResources
    Dim DL As New DLExamResources
    Dim Dt1, Dt2 As DataTable

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                El.BatchNameId = ddlExamBatch.SelectedValue
                El.ResTypeId = ddlResType.SelectedItem.Text
                El.ResNameId = ddlResName.SelectedValue
                El.Capacity = txtCapacity.Text
                El.Branchcode = ddlBranch.SelectedValue
                btnPublish.Enabled = True
                If btnSave.Text = "UPDATE" Then
                    El.id = ViewState("id")
                    Dt1 = DLExamResources.GetDuplData(El)
                    If Dt1.Rows.Count > 0 Then
                        DisplayGrid(0)
                        lblmsgifo.Text = ""
                        lblerrmsg.Text = "Data already exists."
                        btnSave.Text = "ADD"
                        btnView.Text = "VIEW"
                    Else
                        El.id = ViewState("id")
                        BL.UpdateRecord(El)
                        btnSave.Text = "ADD"
                        btnView.Text = "VIEW"
                        GrdExamResources.PageIndex = ViewState("PageIndex")
                        DisplayGrid(0)
                        'txtCapacity.Text = ""
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Updated Successfully."
                    End If
                ElseIf btnSave.Text = "ADD" Then
                    El.id = 0
                    Dt1 = DLExamResources.GetDuplData(El)
                    If Dt1.Rows.Count > 0 Then
                        DisplayGrid(0)
                        lblmsgifo.Text = ""
                        lblerrmsg.Text = "Data already exists."
                    Else
                        Dim ExamBatchId As Integer
                        ExamBatchId = ddlExamBatch.SelectedValue
                        '1
                        If DL.CountData(ExamBatchId).Tables(0).Rows(0).Item(0) = "Y" Then
                            lblerrmsg.Text = "This Record is  Locked,You cann't add the data"
                            lblmsgifo.Text = ""
                            Exit Sub
                        Else
                            El.id = 0
                            BL.InsertRecord(El)
                            lblerrmsg.Text = ""
                            ViewState("PageIndex") = 0
                            GrdExamResources.PageIndex = 0
                            DisplayGrid(0)
                            lblerrmsg.Text = ""
                            lblmsgifo.Text = "Data Saved Successfully."
                        End If
                    End If
                End If
            Catch e1 As Exception
                lblerrmsg.Text = "Enter Correct Data."
                lblmsgifo.Text = ""
            End Try
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsgifo.Text = ""
        End If
    End Sub
    Sub DisplayGrid(ByVal Id As Integer)
        btnPublish.Enabled = True
        El.BatchNameId = ddlExamBatch.SelectedValue
        El.ResTypeId = ddlResType.SelectedItem.ToString
        If ddlResName.SelectedValue = "" Then
            El.ResNameId = 0
        Else
            El.ResNameId = ddlResName.SelectedValue
        End If

        El.Branchcode = ddlBranch.SelectedValue
        Dt1 = BL.GetGridData(El, Id)
        If Dt1.Rows.Count = 0 Then
            GrdExamResources.DataSource = Nothing
            GrdExamResources.DataBind()
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
        Else
            Dim BatchNameId As Integer
            BatchNameId = ddlExamBatch.SelectedValue
            If DL.CountData(BatchNameId).Tables(0).Rows(0).Item(0) = "Y" Then
                GrdExamResources.DataSource = Dt1
                GrdExamResources.DataBind()
                GrdExamResources.Enabled = False
                GrdExamResources.Visible = True
                LinkButton.Focus()
            Else
                GrdExamResources.DataSource = Dt1
                GrdExamResources.DataBind()
                GrdExamResources.Enabled = True
                GrdExamResources.Visible = True
                LinkButton.Focus()
            End If
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        'Dim val As Integer
        'val = ddlExamBatch.SelectedValue
        'If val = 0 Then
        '    lblerrmsg.Text = "Select any Batch Field."
        '    Exit Sub
        'End If
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        btnPublish.Enabled = True
        If btnView.Text <> "BACK" Then
            ViewState("PageIndex") = 0
            GrdExamResources.PageIndex = 0
            DisplayGrid(0)
            GrdExamResources.Visible = True
        Else
            btnView.Text = "VIEW"
            btnSave.Text = "ADD"
            GrdExamResources.PageIndex = ViewState("PageIndex")
            DisplayGrid(0)
            'txtCapacity.Text = ""

        End If

    End Sub
    Protected Sub GrdExamResources_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdExamResources.RowDeleting

        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("id") = CType(GrdExamResources.Rows(e.RowIndex).Cells(1).FindControl("lblId"), Label).Text
            El.id = ViewState("id")
            El.ResTypeId = ddlResType.SelectedItem.ToString
            El.ResNameId = (ddlResName.SelectedValue)
            El.Branchcode = ddlBranch.SelectedValue
            Dim dt1 As DataTable
            dt1 = BL.GetGridData(El, El.id)
            If dt1.Rows(0).Item("LockFlag") = "Y" Then
                lblerrmsg.Text = "This Record is  Locked,You cann't delete the data"
                lblmsgifo.Text = ""
                Exit Sub
            Else
                El.id = CType(GrdExamResources.Rows(e.RowIndex).Cells(1).FindControl("lblId"), Label).Text
                If BL.ChangeFlag(El) Then
                    lblerrmsg.Text = ""
                    lblmsgifo.Text = "Data Deleted Successfully."
                    GrdExamResources.PageIndex = ViewState("PageIndex")
                    DisplayGrid(0)
                    GrdExamResources.Enabled = True
                End If
            End If
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsgifo.Text = ""
        End If
    End Sub
    Protected Sub GrdExamResources_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdExamResources.PageIndexChanging
        GrdExamResources.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GrdExamResources.PageIndex
        DisplayGrid(0)
    End Sub
    Protected Sub GrdExamResources_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrdExamResources.RowEditing
        ViewState("id") = CType(GrdExamResources.Rows(e.NewEditIndex).FindControl("lblId"), Label).Text
        El.id = ViewState("id")
        El.ResTypeId = ddlResType.SelectedItem.ToString
        El.ResNameId = (ddlResName.SelectedValue)
        El.Branchcode = ddlBranch.SelectedValue

        Dim dt1 As DataTable
        dt1 = BL.GetGridData(El, El.id)
        If dt1.Rows(0).Item("LockFlag") = "Y" Then
            lblerrmsg.Text = "This Record is  Locked,You cann't Edit the data"
            lblmsgifo.Text = ""
            Exit Sub
        Else
            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
            ddlExamBatch.SelectedValue = CType(GrdExamResources.Rows(e.NewEditIndex).FindControl("lblBatchId"), Label).Text
            ViewState("id") = CType(GrdExamResources.Rows(e.NewEditIndex).FindControl("lblId"), Label).Text
            ddlBranch.SelectedValue = CType(GrdExamResources.Rows(e.NewEditIndex).FindControl("lblBranch"), Label).Text
            ddlResType.Items.Clear()
            ddlResType.DataSourceID = "ObjResType"
            ddlResType.DataBind()
            ddlResType.SelectedValue = CType(GrdExamResources.Rows(e.NewEditIndex).FindControl("lblRID"), Label).Text
            ddlResName.Items.Clear()

            If ddlResType.SelectedItem.ToString = "Invigilator " Or ddlResType.SelectedItem.ToString = "Evaluator" Or ddlResType.SelectedItem.ToString = "Paper Setter" Then
                Dim dt As DataTable
                dt = LeaveApplicationDL.GetEmpcombo(ddlBranch.SelectedValue)
                ddlResName.DataTextField = dt.Columns("Emp_Name").ToString
                ddlResName.DataValueField = dt.Columns("EmpID").ToString
                ddlResName.DataSource = dt
                ddlResName.DataBind()
            Else

                Dim dt As DataTable
                dt = DLExamResources.GetResourcename(ddlResType.SelectedValue, ddlBranch.SelectedValue)
                ddlResName.DataTextField = dt.Columns("ResourceName").ToString
                ddlResName.DataValueField = dt.Columns("AutoID").ToString
                ddlResName.DataSource = dt
                ddlResName.DataBind()

            End If


            ddlResName.SelectedValue = CType(GrdExamResources.Rows(e.NewEditIndex).FindControl("lblResNameId"), Label).Text
            If ddlResType.SelectedItem.ToString = "Invigilator " Or ddlResType.SelectedItem.ToString = "Evaluator" Or ddlResType.SelectedItem.ToString = "Paper Setter" Then
                txtCapacity.Text = CType(GrdExamResources.Rows(e.NewEditIndex).FindControl("lblCalpacity"), Label).Text
                txtCapacity.Enabled = True
            Else
                txtCapacity.Text = CType(GrdExamResources.Rows(e.NewEditIndex).FindControl("lblCalpacity"), Label).Text
                txtCapacity.Enabled = False

            End If

            btnSave.Text = "UPDATE"
            btnView.Text = "BACK"
            El.id = ViewState("id")
            El.ResTypeId = ddlResType.SelectedItem.ToString
            El.ResNameId = (ddlResName.SelectedValue)
            El.Branchcode = ddlBranch.SelectedValue
            dt1 = BL.GetGridData(El, El.id)
            GrdExamResources.DataSource = dt1
            GrdExamResources.DataBind()
            GrdExamResources.Enabled = False
            btnPublish.Enabled = False
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ddlEmpName.Visible = False
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        Dim s As String
        s = ddlExamBatch.SelectedValue
        If ddlExamBatch.SelectedValue = "0" Then
            txtCapacity.Text = ""
        End If
        If Not Page.IsPostBack Then

            txtCapacity.Text = ""
        End If
    End Sub

    Protected Sub ddlResName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlResName.SelectedIndexChanged


        If ddlResName.SelectedValue = "0" Then
            txtCapacity.Text = ""
        Else

            El.id = ddlResName.SelectedValue
            El.Branchcode = ddlBranch.SelectedValue
            Dt2 = DLExamResources.GetCapacityAutoFill(El)
            If Dt2.Rows.Count > 0 Then

                If Dt2.Rows(0).Item("Capacity").ToString = "" Then
                    txtCapacity.Text = 0
                Else
                    txtCapacity.Text = (Dt2.Rows(0).Item("Capacity"))
                End If
            End If
        End If
    End Sub

    Protected Sub btnPublish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPublish.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim msg As String = ""
            '"<Table><tr><td> ResourceName ,  capacity,    ExamBatch,    ResourceType </ td></ tr>"
            El.BatchNameId = ddlExamBatch.SelectedValue
            Dim Val As Integer
            Val = ddlExamBatch.SelectedValue
            If Val = 0 Then
                lblerrmsg.Text = "Select any Batch Field."
                Exit Sub
            End If
            El.ResTypeId = ddlResType.SelectedItem.ToString
            If ddlResName.SelectedValue = "" Then
                El.ResNameId = 0
            Else
                El.ResNameId = ddlResName.SelectedValue
            End If
            El.Branchcode = ddlBranch.SelectedValue
            Dim ID As Integer = 0
            Dt1 = DLExamResources.GetpublishGridData(El, ID)
            If Dt1.Rows.Count = 0 Then
                lblmsgifo.Text = ""
                lblerrmsg.Text = "No records to Publish."
            Else

                msg = "<table> <tr style=""border-style: solid; border-width: thin""> " + msg
                msg = msg + " <td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Branch Name" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Exam Batch" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Resource Type" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Resource Name" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Allocate Capacity" + "</td>" + "</tr><br><tr style=""border-style: solid: solid; border-width: thin"">"
                For i As Integer = 0 To Dt1.Rows.Count - 1
                    For j As Integer = 0 To Dt1.Columns.Count - 1

                        msg = msg + "<td  style=""border-style: solid; border-width: thin"">" + Dt1.Rows(i)(j).ToString + "</td>"

                    Next
                    msg = msg + "</tr><tr style=""border-style: solid: solid; border-width: thin"">"

                Next
                msg = msg + "</table>"
                DLExamResources.UpdatePublish(El)
                DLExamResources.publish(msg)
                lblmsgifo.Text = "Data is published in Notice Board."
                lblerrmsg.Text = ""
            End If
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot publish data."
            lblmsgifo.Text = ""
        End If
    End Sub

    Protected Sub ddlResType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlResType.SelectedIndexChanged
        If ddlResType.SelectedItem.ToString = "Invigilator " Or ddlResType.SelectedItem.ToString = "Evaluator" Or ddlResType.SelectedItem.ToString = "Paper Setter" Then
            txtCapacity.Enabled = True
        Else
            txtCapacity.Enabled = False
        End If

        If ddlResName.SelectedValue = "0" Then
            txtCapacity.Text = ""
        End If
        If ddlResType.SelectedItem.ToString = "Invigilator " Or ddlResType.SelectedItem.ToString = "Evaluator" Or ddlResType.SelectedItem.ToString = "Paper Setter" Then
            Dim dt As DataTable
            dt = LeaveApplicationDL.GetEmpcombo(ddlBranch.SelectedValue)
            ddlResName.DataTextField = dt.Columns("Emp_Name").ToString
            ddlResName.DataValueField = dt.Columns("EmpID").ToString
            ddlResName.DataSource = dt
            ddlResName.DataBind()
        Else

            Dim dt As DataTable
            dt = DLExamResources.GetResourcename(ddlResType.SelectedValue, ddlBranch.SelectedValue)
            ddlResName.DataTextField = dt.Columns("ResourceName").ToString
            ddlResName.DataValueField = dt.Columns("AutoID").ToString
            ddlResName.DataSource = dt
            ddlResName.DataBind()

        End If

    End Sub

    Protected Sub ddlBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.SelectedIndexChanged
        ddlResName.SelectedValue = 0
        'ddlResType.SelectedValue = "Select"

    End Sub

    Protected Sub GrdExamResources_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GrdExamResources.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        btnPublish.Enabled = True
        El.BatchNameId = ddlExamBatch.SelectedValue
        El.ResTypeId = ddlResType.SelectedItem.ToString
        El.ResNameId = ddlResName.SelectedValue
        El.Branchcode = ddlBranch.SelectedValue
        Dt1 = BL.GetGridData(El, 0)

        Dim sortedView As New DataView(Dt1)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GrdExamResources.DataSource = sortedView
        GrdExamResources.DataBind()
        GrdExamResources.Enabled = True
        GrdExamResources.Visible = True
        LinkButton.Focus()
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
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        Try

            'Dim Message As String
            dt2 = Session("ValidationTable")
            Dim X As Integer = dt2.Rows.Count() - 1
            Dim str As String = " "
            For i As Integer = 0 To X
                If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                    Return dt2.Rows(i).Item("MessageText").ToString()
                End If
            Next
        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try
        Return 0
    End Function
    Protected Sub btnLock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLock.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim Check As String
            Dim BatchNameId As Integer
            BatchNameId = ddlExamBatch.SelectedValue
            If BatchNameId = 0 Then
                lblerrmsg.Text = "Select any Batch Field."
                Exit Sub
            End If

            Dim Dt1 As DataSet
            ' Dt1 = DL.GetGridData(El, ID)
            'Dim dt3 As DataSet
            Dt1 = DL.CntData(BatchNameId)
            If Dt1.Tables(0).Rows.Count > 0 Then
                ControlsPanel.Visible = False
                PasswordPanel.Visible = True
                txtPassword.Focus()
                lblpassError.Text = ""
            Else
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                lblerrmsg.Text = ""
                lblmsgifo.Text = ""
                lblmsgifo.Text = "No Records to Lock/Unlock."
            End If
        Else
            lblmsgifo.Text = "You do not belong to this branch, Cannot Lock/Unlock data."
            lblerrmsg.Text = ""
        End If
    End Sub

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Check As String
        Dim BatchNameId As Integer
        'Dim ResTypeId, Capacity, Branchcode As String
        If txtPassword.Text = Session("Password") Then
            ' Dim BatchNameId As Integer

            BatchNameId = ddlExamBatch.SelectedValue
            '1
            If DL.CountData(BatchNameId).Tables(0).Rows(0).Item(0) = "N" Then
                Dim roweffected As Integer = DL.UpdateLockFlag(BatchNameId)
                If roweffected > 0 Then
                    ControlsPanel.Visible = True
                    PasswordPanel.Visible = False
                    lblmsgifo.Text = ""
                    'DL.UpdateLockFlag(BatchNameId)
                    lblerrmsg.Text = roweffected.ToString + " Records are Locked."
                    DisplayGrid(0)
                    GrdExamResources.Enabled = False
                End If
                '1
            Else

                Dim role As String
                role = Session("UserRole")
                'Dim checkUnlock As String
                ' dt1 = DLNew_StudentMarks.CheckUnlockStatus(role)
                '2
                If Session("SecurityCheck") = "Security Check" Then

                    Dt1 = DLExamResources.GetunlockData(role)
                    '3
                    If Dt1.Rows.Count < 1 Then
                        lblerrmsg.Text = "You don't have Unlock Permission."
                        lblmsgifo.Text = ""
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        GrdExamResources.Enabled = False
                    Else
                        Check = Dt1.Rows(0)("Result").ToString.Trim

                        'check = dt.Rows(0)("Result").ToString.Trim
                        '4
                        If Check = "" Then
                            lblerrmsg.Text = "You don't have Unlock Permission."
                            lblmsgifo.Text = ""
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            GrdExamResources.Enabled = False
                            '4
                        Else
                            Dim roweffected As Integer = DLExamResources.UnLockData(BatchNameId)
                            If roweffected > 0 Then
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                lblerrmsg.Text = ""
                                lblmsgifo.Text = roweffected.ToString + " Records Unlocked."
                                DisplayGrid(0)
                                GrdExamResources.Enabled = True
                            End If
                            '4
                        End If
                        '3
                    End If
                    '2
                Else
                    Dim roweffected As Integer = DLExamResources.UnLockData(BatchNameId)
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = roweffected.ToString + " records Unlocked."
                        GrdExamResources.Enabled = True
                    End If
                    '2
                End If
                '1
            End If
        ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
            ControlsPanel.Visible = True
            PasswordPanel.Visible = False
            lblmsgifo.Text = ""
            lblerrmsg.Text = ""
            lblerrmsg.Text = "Enter correct password"
            lblmsgifo.Text = ""
        End If
    End Sub

End Class
