Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Imports Microsoft.VisualBasic.Strings
Partial Class frmInvestmentSectionMaster
    Inherits BasePage
    Dim EL As New ELInvestmentSectionMaster
    Dim BL As New BLInvestmentSectionMaster
    Dim dt As New DataTable

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        ddlSection.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then



            Try
                If btnsave.Text = "UPDATE" Then
                    EL.ID = ViewState("InvSection_Auto_ID")
                    If ddlSection.SelectedValue = 0 Then
                        lblErrorMsg.Text = "Section field is mandatory."
                        msginfo.Text = ""
                        Exit Sub
                    Else
                        EL.SectionID = ddlSection.SelectedValue

                    End If

                    If TxtDescription.Text = "" Then
                        lblErrorMsg.Text = "Description  field is mandatory."
                        msginfo.Text = ""
                        Exit Sub
                    Else
                        EL.Description = TxtDescription.Text

                    End If
                    If txtSubDescription.Text = "" Then
                        lblErrorMsg.Text = "Sub Description  field is mandatory."
                        msginfo.Text = ""
                        Exit Sub
                    Else
                        EL.SubDescription = txtSubDescription.Text


                    End If


                    If dt.Rows.Count > 0 Then
                        lblErrorMsg.Visible = True
                        lblErrorMsg.Text = "Data already exists."
                        msginfo.Text = ""
                        btnsave.Text = "ADD"
                        btndetails.Text = "VIEW"

                    Else

                        BL.UpdateInvestment(EL)

                        btnsave.Text = "ADD"
                        btndetails.Text = "VIEW"
                        lblErrorMsg.Text = ""
                        msginfo.Visible = True
                        msginfo.Text = "Data updated successfully."
                        clear()
                        GridView1.PageIndex = ViewState("PageIndex")


                        DisplayInvestmentDetails()

                    End If





                ElseIf btnsave.Text = "ADD" Then

                    If ddlSection.SelectedValue = 0 Then
                        lblErrorMsg.Text = "Section field is mandatory."
                        msginfo.Text = ""
                        Exit Sub
                    Else
                        EL.SectionID = ddlSection.SelectedValue

                    End If

                    If TxtDescription.Text = "" Then
                        lblErrorMsg.Text = "Description  field is mandatory."
                        msginfo.Text = ""
                        Exit Sub
                    Else
                        EL.Description = TxtDescription.Text

                    End If
                    If txtSubDescription.Text = "" Then
                        lblErrorMsg.Text = "Sub Description  field is mandatory."
                        msginfo.Text = ""
                        Exit Sub
                    Else
                        EL.SubDescription = txtSubDescription.Text


                    End If

                    If dt.Rows.Count > 0 Then
                        lblErrorMsg.Visible = True
                        lblErrorMsg.Text = "Data already exists."
                        msginfo.Text = ""
                        btnsave.Text = "ADD"
                        btndetails.Text = "VIEW"
                    Else
                        BL.InsertRecordInv(EL)
                        btnsave.Text = "ADD"
                        lblErrorMsg.Text = ""
                        msginfo.Visible = True
                        msginfo.Text = "Data saved successfully."
                        clear()
                    End If
                    GridView1.Enabled = True
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    DisplayInvestmentDetails()
                End If
            Catch ex As Exception

                lblErrorMsg.Text = "Invalid data."
            End Try
        End If




    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DisplayInvestmentDetails()
        GridView1.Visible = True
    End Sub

    Protected Sub btndetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetails.Click

        LinkButton.Focus()

        If btndetails.Text = "VIEW" Then
            GridView1.Enabled = True

            lblErrorMsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            'GridView1.PageIndex = ViewState("PageIndex")
            EL.SectionID = ddlSection.SelectedValue
            DisplayInvestmentDetails()

        ElseIf btndetails.Text = "BACK" Then
            GridView1.Enabled = True
            btnsave.Text = "ADD"
            btndetails.Text = "VIEW"
            clear()
            GridView1.PageIndex = ViewState("PageIndex")
            DisplayInvestmentDetails()

            lblErrorMsg.Text = ""
            msginfo.Text = ""
        End If
    End Sub

    Sub DisplayInvestmentDetails()
        Dim dt As New DataTable
        EL.ID = 0


        dt = BL.DisplaInvestment(EL)

        If dt.Rows.Count > 0 Then
            
            GridView1.Visible = True
            GridView1.Enabled = True
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.PageIndex = ViewState("PageIndex")
            LinkButton.Focus()
        End If
        If dt.Rows.Count = 0 Then
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "No records to display."
            msginfo.Text = ""
        End If
    End Sub
    Sub clear()
        TxtDescription.Text = ""
        txtSubDescription.Text = ""
        
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim ex As New Integer
        EL.ID = ViewState("InvSection_Auto_ID")
        ddlSection.Items.Clear()
        ddlSection.DataSourceID = "ObjSection"
        ddlSection.DataBind()
        ddlSection.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblSection"), Label).Text



        TxtDescription.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblDescription"), Label).Text
        txtSubDescription.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSubDescription"), Label).Text
        



        ex = CType(GridView1.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value

        ViewState("InvSection_Auto_ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
        btnsave.Text = "UPDATE"
        btndetails.Text = "BACK"
        EL.ID = ViewState("InvSection_Auto_ID")
        dt = BL.DisplaInvestment(EL)
        GridView1.DataSource = dt
        GridView1.DataBind()


        GridView1.Enabled = False
        GridView1.Visible = True

    End Sub
    Protected Sub Grid_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("InvSection_Auto_ID") = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            EL.ID = ViewState("InvSection_Auto_ID")
            BL.ChangeFlagInv(EL)
            DisplayInvestmentDetails()
            GridView1.Visible = True
            lblErrorMsg.Text = ""
            msginfo.Text = "Data Deleted Successfully."
            ddlSection.Focus()
            GridView1.PageIndex = ViewState("PageIndex")

            dt = BL.DisplaInvestment(EL)
            GridView1.DataSource = dt
            GridView1.DataBind()

            GridView1.Enabled = True
            GridView1.Visible = True
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            msginfo.Text = ""
        End If

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
        EL.ID = 0
        EL.SectionID = ddlSection.SelectedValue
       

        dt = BL.DisplaInvestment(EL)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Enabled = True
        GridView1.Visible = True
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

End Class
