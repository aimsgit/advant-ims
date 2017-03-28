
Partial Class PerformanceParameter
    Inherits BasePage
    Dim dt As New DataTable
    Dim AppParams As New PerformanceAppriasal

    Protected Sub btnGenrate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenrate.Click

        Dim TP As Integer
        Dim sp As Integer

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim app As Integer
            app = ddlAppraisalP.SelectedValue
            dt = AppParams.CheckFeedBackGenStatus(app)
            If dt.Rows.Count > 0 Then
                msginfo.Text = ValidationMessage(1044)
                lblMsg.Text = ValidationMessage(1014)
            Else
                TP = ddlAppraisalP.SelectedValue

                sp = txtPerfCycle.Text
                AppParams.GenerateParameters(TP, sp)
                DisplayGrid()
                clrar()
            End If

        Else
            msginfo.Text = ValidationMessage(1045)
            lblMsg.Text = ValidationMessage(1014)
        End If

       
    End Sub
    Sub clrar()
        txtPerfCycle.Text = ""
    End Sub
    Sub DisplayGrid()
        Dim app As Integer = ddlAppraisalP.SelectedValue
        dt = AppParams.ViewParameters(app)
        If dt.Rows.Count = 0 Then
            msginfo.Text = ValidationMessage(1023)
            lblMsg.Text = ValidationMessage(1014)
            GVPerformance.Visible = False
        Else
            msginfo.Text = ValidationMessage(1014)
            lblMsg.Text = ValidationMessage(1014)
            GVPerformance.Visible = True
            GVPerformance.DataSource = dt
            GVPerformance.DataBind()
           
        End If

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
    ' ''Retriving the text of controls based on Language
    '
    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
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

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlAppraisalP.Focus()

        Dim heading As String
        heading = Session("RptFrmTitleName")

        Me.Lblheading.Text = heading
        
    End Sub

    Protected Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim FeedBackId, Max, Min As Integer
            Dim ParameterName As String
            If GVPerformance.Rows.Count = 0 Then
                msginfo.Text = ValidationMessage(1049)
                lblMsg.Text = ValidationMessage(1014)
                Exit Sub
            End If
            For Each Grid As GridViewRow In GVPerformance.Rows
                If CType(Grid.FindControl("txtParameterName"), TextBox).Text = "" Then
                    msginfo.Text = "Please Fill All Details."
                    lblMsg.Text = ""
                    Exit Sub
                End If
                If CType(Grid.FindControl("txtMax"), TextBox).Text = "" Then
                    msginfo.Text = "Please Fill All Details."
                    lblMsg.Text = ""
                    Exit Sub
                End If
                If CType(Grid.FindControl("txtMin"), TextBox).Text = "" Then
                    msginfo.Text = "Please Fill All Details."
                    lblMsg.Text = ""
                    Exit Sub
                End If
            Next
            For Each Grid As GridViewRow In GVPerformance.Rows
                FeedBackId = CType(Grid.FindControl("lblPId"), HiddenField).Value
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

                        AppParams.UpdateFeedBackParameters(FeedBackId, ParameterName, Max, Min)
                        lblMsg.Text = ValidationMessage(1053)
                        msginfo.Text = ValidationMessage(1014)
                    End If
                ElseIf ParameterName = "" And Max = 0 And Min = 0 Then
                    Max = -1

                    Min = -1

                    AppParams.UpdateFeedBackParameters(FeedBackId, ParameterName, Max, Min)
                    lblMsg.Text = ValidationMessage(1053)
                    msginfo.Text = ValidationMessage(1014)
                End If
            Next
        Else
            msginfo.Text = ValidationMessage(1021)
            lblMsg.Text = ValidationMessage(1014)
        End If
       
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim app As Integer
            app = ddlAppraisalP.SelectedValue
            dt = AppParams.ViewParameters(app)
            If dt.Rows.Count = 0 Then
                msginfo.Text = ValidationMessage(1047)
                lblMsg.Text = ValidationMessage(1014)
            Else
                AppParams.ClearParameters(app)
                lblMsg.Text = ValidationMessage(1046)
                msginfo.Text = ValidationMessage(1014)
                GVPerformance.Visible = False
                dt.Clear()
                GVPerformance.DataSource = Nothing
                GVPerformance.DataBind()
                
            End If
        Else
            msginfo.Text = ValidationMessage(1048)
            lblMsg.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        DisplayGrid()
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GVPerformance_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVPerformance.PageIndexChanging
        GVPerformance.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVPerformance.PageIndex
        DisplayGrid()
    End Sub
End Class
