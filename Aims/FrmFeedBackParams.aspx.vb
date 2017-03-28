
Partial Class FrmFeedBackParams
    Inherits BasePage
    Dim dt As New DataTable
    Dim FeedParams As New FeedBackParamsBL
    Dim EL As New ELFeedbackDept
    Dim BL As New FeedBackParamsBL

    Protected Sub btnGenrate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenrate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            dt = FeedParams.CheckFeedBackGenStatus()
            If dt.Rows.Count > 0 Then
                msginfo.Text = ValidationMessage(1044)
                lblMsg.Text = ValidationMessage(1014)
            Else

                FeedParams.GenerateParameters()
                DisplayGrid()
            End If
        Else
            msginfo.Text = ValidationMessage(1045)
            lblMsg.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub DisplayGrid()
        dt = FeedParams.ViewParameters()
        If dt.Rows.Count = 0 Then
            msginfo.Text = ValidationMessage(1023)
            lblMsg.Text = ValidationMessage(1014)
            GVFeedBack.Visible = False
        Else
            msginfo.Text = ValidationMessage(1014)
            lblMsg.Text = ValidationMessage(1014)
            GVFeedBack.Visible = True
            panel1.Visible = True
            GVFeedBack.Visible = True
            GVFeedBack.DataSource = dt
            GVFeedBack.DataBind()

        End If

    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        DisplayGrid()
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then

            dt = FeedParams.ViewParameters()
            If dt.Rows.Count = 0 Then
                msginfo.Text = ValidationMessage(1047)
                lblMsg.Text = ValidationMessage(1014)
            Else
                FeedParams.ClearParameters()
                lblMsg.Text = ValidationMessage(1046)
                msginfo.Text = ValidationMessage(1014)
                GVFeedBack.Visible = False
                panel1.Visible = False
                dt.Clear()
                GVFeedBack.DataSource = Nothing
                GVFeedBack.DataBind()

            End If
        Else
            msginfo.Text = ValidationMessage(1048)
            lblMsg.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim FeedBackId, Max, Min, Weightage As Integer
            Dim ParameterName As String
            If GVFeedBack.Rows.Count = 0 Then
                msginfo.Text = ValidationMessage(1049)
                lblMsg.Text = ValidationMessage(1014)
                Exit Sub
            End If
            For Each Grid As GridViewRow In GVFeedBack.Rows
                FeedBackId = CType(Grid.FindControl("lblFeedbackId"), HiddenField).Value
                ParameterName = CType(Grid.FindControl("txtParameterName"), TextBox).Text
                If CType(Grid.FindControl("txtMax"), TextBox).Text = "" Then
                    Max = 0
                Else
                    Max = CType(Grid.FindControl("txtMax"), TextBox).Text
                End If
                If CType(Grid.FindControl("txtMin"), TextBox).Text = "" Then
                    Min = 0
                Else
                    Min = CType(Grid.FindControl("txtMin"), TextBox).Text
                End If
                If CType(Grid.FindControl("txtweight"), TextBox).Text = "" Then
                    Weightage = 1
                Else
                    Weightage = CType(Grid.FindControl("txtweight"), TextBox).Text
                End If
                If ParameterName <> "" Then

                    If CType(Grid.FindControl("txtMax"), TextBox).Text = "" Then
                        msginfo.Text = ValidationMessage(1050)
                        lblMsg.Text = ValidationMessage(1014)
                        Exit For
                    ElseIf CType(Grid.FindControl("txtMin"), TextBox).Text = "" Then
                        msginfo.Text = ValidationMessage(1051)
                        lblMsg.Text = ValidationMessage(1014)
                        Exit For
                    ElseIf Max < Min Then
                        msginfo.Text = ValidationMessage(1052)
                        lblMsg.Text = ValidationMessage(1014)
                        Exit For
                    Else

                        Max = CType(Grid.FindControl("txtMax"), TextBox).Text

                        Min = CType(Grid.FindControl("txtMin"), TextBox).Text

                        'Weightage = CType(Grid.FindControl("txtweight"), TextBox).Text

                        FeedParams.UpdateFeedBackParameters(FeedBackId, ParameterName, Max, Min, Weightage)
                        lblMsg.Text = ValidationMessage(1053)
                        msginfo.Text = ValidationMessage(1014)
                    End If
                ElseIf ParameterName = "" And Max = 0 And Min = 0 Then
                    Max = -1

                    Min = -1

                    FeedParams.UpdateFeedBackParameters(FeedBackId, ParameterName, Max, Min, Weightage)
                    lblMsg.Text = ValidationMessage(1053)
                    msginfo.Text = ValidationMessage(1014)
                End If
            Next
        Else
            msginfo.Text = ValidationMessage(1021)
            lblMsg.Text = ValidationMessage(1014)
        End If
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            TxtStartdate.Text = Format(Today, "dd-MMM-yyyy")
            txtEnddate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GVFeedBack_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVFeedBack.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        dt = FeedParams.ViewParameters()
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVFeedBack.DataSource = sortedView
        GVFeedBack.DataBind()
        GVFeedBack.Visible = True
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
    ''Code Written for Multilingual By Ajit Kumar Singh on 12th Aug
    ''Retriving the text of controls based on Language
   
    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        dt2 = Session("ValidationTable")
        If dt2 Is Nothing Then
            Response.Redirect("LogIn.aspx")
        End If
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function


    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        ddlDepartment.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then

            Try
                If btnsave.Text = "UPDATE" Then
                    If CType(TxtStartdate.Text, Date) > CType(txtEnddate.Text, Date) Then
                        lblmsginfo.Text = ""
                        lblErrorMsg.Text = "Start Date should be lesser than End Date."
                        Exit Sub
                    End If


                    'EL.DeptID = ddlDepartment.SelectedValue

                    'EL.ID = ViewState("DeptID")
                    'EL.EndDate = txtEnddate.Text
                    'EL.StartDate = TxtStartdate.Text
                    'EL.DeptName = ddlDepartment.SelectedItem.Text

                    'BL.UpdateDeptFeedBack(EL)

                    'btnsave.Text = "ADD"
                    'btndetails.Text = "VIEW"
                    'lblErrorMsg.Text = ""
                    'lblmsginfo.Visible = True
                    'lblmsginfo.Text = "Data updated successfully."
                    'clear()
                    'GridView1.PageIndex = ViewState("PageIndex")
                    'DisplayDeptFeedback()
                    'ElseIf btnsave.Text = "ADD" Then

                    EL.DeptID = ddlDepartment.SelectedValue
                    EL.EndDate = txtEnddate.Text
                    EL.StartDate = TxtStartdate.Text
                    EL.DeptName = ddlDepartment.SelectedItem.Text
                    dt = FeedBackParamsDL.GetDuplData(EL)
                    If dt.Rows.Count > 0 Then
                        DisplayGrid()
                        lblmsginfo.Text = ""
                        lblErrorMsg.Text = "Data already exists."
                        btnsave.Text = "UPDATE"
                        btndetails.Text = "VIEW"

                    Else
                        BL.InsertRecordFeed(EL)
                        lblmsginfo.Text = ""
                        lblmsginfo.Visible = True
                        lblErrorMsg.Text = ""
                        lblmsginfo.Text = "Data updated successfully."
                        btnsave.Text = "UPDATE"
                        btndetails.Text = "VIEW"
                        clear()
                    End If
                End If
                GridView1.Enabled = True
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0
                DisplayDeptFeedback()
            Catch ex As Exception
                lblErrorMsg.Text = "Invalid data."
            End Try
        End If


    End Sub

    Protected Sub btndetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetails.Click

        LinkButton1.Focus()

        If btndetails.Text = "VIEW" Then
            EL.DeptID = ddlDepartment.SelectedValue
            EL.EndDate = txtEnddate.Text
            EL.StartDate = TxtStartdate.Text
            GridView1.Enabled = True

            lblErrorMsg.Text = ""
            lblmsginfo.Text = ""
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            GridView1.PageIndex = ViewState("PageIndex")

            DisplayDeptFeedback()

        ElseIf btndetails.Text = "BACK" Then
            GridView1.Enabled = True
            panel1.Visible = True
            GridView1.Visible = True
            btnsave.Text = "UPDATE"
            btndetails.Text = "VIEW"
            'clear()
            GridView1.PageIndex = ViewState("PageIndex")
            DisplayDeptFeedback()

            lblErrorMsg.Text = ""
            msginfo.Text = ""
        End If
    End Sub

    Sub DisplayDeptFeedback()
        Dim dt As New DataTable
        EL.ID = 0

        dt = BL.DisplayDeptFeedback(EL)

        If dt.Rows.Count > 0 Then
            panel1.Visible = True
            GridView1.Visible = True
            GridView1.Enabled = True
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.PageIndex = ViewState("PageIndex")
            LinkButton1.Focus()
        End If
        If dt.Rows.Count = 0 Then
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "No records to display."
            msginfo.Text = ""
            GridView1.Visible = "false"
        End If
    End Sub
    Sub clear()
        'TxtStartdate.Text = ""
        'txtEnddate.Text = ""
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim ex As New Integer
        EL.ID = ViewState("DeptID")
        ddlDepartment.Items.Clear()
        ddlDepartment.DataSourceID = "ObjDepartment"
        ddlDepartment.DataBind()
        ddlDepartment.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblDeptId"), Label).Text

        TxtStartdate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblFeedbackStartDate"), Label).Text
        txtEnddate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblFeedBackEndDate"), Label).Text

        ex = CType(GridView1.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value

        ViewState("DeptID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
        btnsave.Text = "UPDATE"
        btndetails.Text = "BACK"
        EL.ID = ViewState("DeptID")
        dt = BL.DisplayDeptFeedback(EL)
        GridView1.DataSource = dt
        GridView1.DataBind()


        GridView1.Enabled = False
        GridView1.Visible = True

    End Sub
    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        If (Session("BranchCode") = Session("ParentBranch")) Then

            Dim role As String
            Dim check As String

            role = Session("UserRole")

            Dim DeptID As Integer = CType(GridView1.Rows(e.RowIndex).FindControl("LblDeptId"), Label).Text
            Try
                If Session("SecurityCheck") = "Security Check" Then

                    dt = FeedBackParamsDL.CheckPublishFeedback(role)
                    If dt.Rows.Count < 1 Then
                        lblErrorMsg.Text = "You don't have permission to publish."
                        lblmsginfo.Text = ValidationMessage(1014)

                    Else
                        check = dt.Rows(0)("Result").ToString.Trim
                        If check = "" Then
                            lblErrorMsg.Text = "You don't have permission to publish."
                            lblmsginfo.Text = ValidationMessage(1014)

                        Else

                            Dim roweffected As Integer = BL.PublishFeedback(DeptID)
                            If roweffected > 0 Then

                                msginfo.Text = ValidationMessage(1014)
                                'lblMsg.Text = "Feedback have been published successfully."
                                lblmsginfo.Text = roweffected.ToString + "  " + "Records have been published successfully."

                            Else
                                lblErrorMsg.Text = "No records to publish."
                            End If
                        End If
                    End If
                End If


            Catch ex As Exception
                lblErrorMsg.Text = "Enter Correct Date."
                lblMsg.Text = ""

            End Try


        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot vacate student."
            lblMsg.Text = ""
        End If
    End Sub
End Class
