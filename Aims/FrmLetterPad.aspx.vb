Partial Class FrmLetterPad
    Inherits BasePage
    Dim alt As String
    Dim LetterPad As New LetterPad
    Dim BLLetterPadManager As New LetterPadManager
    Dim DLLetterPadDB As New LetterPadDB
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            TxtRef_Date.Text = Format(Today, "dd-MMM-yyyy")
            txtRefNo.Focus()
        End If
    End Sub
    Sub view(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        txtRefNo.Focus()
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        lblmsg.Text = ""
        msginfo.Text = ""
        LetterPad.Ref_ID_Auto = 0
        If btnDetails.Text = "VIEW" Then
            LetterPadManager.GetLetterPad(LetterPad)
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            display()
            GridView1.Visible = True
        ElseIf btnDetails.Text = "BACK" Then
            btnsave.Text = "ADD"
            btnDetails.Text = "VIEW"
            btnprntlettr.Enabled = True
            GridView1.PageIndex = ViewState("PageIndex")
            display()
            clear()
            TxtRef_Date.Text = Format(Today, "dd-MMM-yyyy")
        End If
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot delete data."
        'lblmsg.Text = ""
        'End If
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprntlettr.Click
        'Code For Report Button By Nitin 07/06/2012
        If ChkBoxHeader.Checked = True Then
            Dim id As String = ""
            Dim check As String = ""
            Dim id1 As String = ""
            Dim count As New Integer
            For Each grid As GridViewRow In GridView1.Rows
                If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("lblRef_ID"), HiddenField).Value.ToString
                    id = check + "," + id
                    count = count + 1
                Else
                    msginfo.Text = ""
                    lblmsg.Text = ""
                End If
            Next
            Try
                If count > 1 Then
                    msginfo.Text = "Select one record."
                    lblmsg.Text = ""
                Else
                    id = Left(id, id.Length - 1)
                    If txtRefNo.Text = "" Then
                        LetterPad.Ref_ID_Auto = ViewState("Ref_ID_Auto")
                        Dim Ref_ID As Integer
                        Ref_ID = id
                        Dim qrystring As String = "FrmLetterPadV1.aspx?" & QueryStr.Querystring() & "&Ref_ID=" & Ref_ID
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                    Else
                        msginfo.Text = ""
                        lblmsg.Text = ""
                    End If
                End If
            Catch ex As Exception
                msginfo.Text = "Select one record."
                lblmsg.Text = ""
            End Try
        Else
            Dim id As String = ""
            Dim check As String = ""
            Dim id1 As String = ""
            Dim count As New Integer
            For Each grid As GridViewRow In GridView1.Rows
                If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("lblRef_ID"), HiddenField).Value.ToString
                    id = check + "," + id
                    count = count + 1
                Else
                    msginfo.Text = ""
                    lblmsg.Text = ""
                End If
            Next
            Try
                If count > 1 Then
                    msginfo.Text = "Select one record."
                    lblmsg.Text = ""
                Else
                    id = Left(id, id.Length - 1)
                    If txtRefNo.Text = "" Then
                        LetterPad.Ref_ID_Auto = ViewState("Ref_ID_Auto")
                        Dim Ref_ID As Integer
                        Ref_ID = id
                        Dim qrystring As String = "FrmLetterPadV.aspx?" & QueryStr.Querystring() & "&Ref_ID=" & Ref_ID
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                        msginfo.Text = ""
                        lblmsg.Text = ""
                    Else
                        msginfo.Text = ""
                        lblmsg.Text = ""
                    End If
                End If
            Catch ex As Exception
                msginfo.Text = "Select one record."
                lblmsg.Text = ""
            End Try
        End If
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Letter Pad")
    End Sub
    Protected Sub btnRecover_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("RecoverForm") = "frmLetterPad"
        Response.Redirect("Recover.aspx")
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        GridView1.DataBind()
        display()
        GridView1.Visible = True
    End Sub

    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.Columns(1).Visible = True
    End Sub
    'code for Row updating by Nitin 06/06/2012
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        msginfo.Text = ""
        lblmsg.Text = ""
        ViewState("Ref_ID_Auto") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRef_ID"), HiddenField).Value
        TxtRef_Date.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRef_Date"), Label).Text
        txtRefNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Ref_No1"), Label).Text
        txtFrom.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblFromm"), Label).Text
        txtref_Per.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Ref_Person1"), Label).Text
        txtSalutation.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSalutationn"), Label).Text
        txtSub.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Subject1"), Label).Text
        TxtCont.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("ContentLP1"), Label).Text
        'txtSignature.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSignaturee"), Label).Text
        txtSignature.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSignaturee"), Label).Text
        LetterPad.Ref_ID_Auto = ViewState("Ref_ID_Auto")
        dt = LetterPadManager.GetLetterPad(LetterPad)
        GridView1.DataSource = dt
        GridView1.DataBind()
        displaySingleRow()
        btnprntlettr.Enabled = False
        GridView1.Enabled = False
        btnsave.Text = "UPDATE"
        btnDetails.Text = "BACK"
        GridView1.Visible = True

        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If
    End Sub
    'code For View Detils By Nitin 06/06/2012
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        lblmsg.Text = ""
        msginfo.Text = ""
        LetterPad.Ref_ID_Auto = 0
        If btnDetails.Text = "VIEW" Then
            LetterPadManager.GetLetterPad(LetterPad)
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            display()
            GridView1.Visible = True
        ElseIf btnDetails.Text = "BACK" Then
            btnsave.Text = "ADD"
            btnDetails.Text = "VIEW"
            GridView1.PageIndex = ViewState("PageIndex")
            display()
            clear()
        End If
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot delete data."
        'lblmsg.Text = ""
        'End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            BLLetterPadManager.ChangeFlag(CType(GridView1.Rows(e.RowIndex).FindControl("lblRef_ID"), HiddenField).Value())
            GridView1.DataBind()
            lblmsg.Text = "Data Deleted Successfully."
            txtRefNo.Focus()
            msginfo.Text = ""
            GridView1.Visible = True
            GridView1.Enabled = True
            GridView1.PageIndex = ViewState("PageIndex")
            display()
            clear()
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If

    End Sub
    'code for Insert and Update Data  by Nitin 06/06/2012
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        txtRefNo.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If btnsave.Text = "ADD" Then
                    LetterPad.Ref_Date = TxtRef_Date.Text
                    LetterPad.Ref_No = txtRefNo.Text
                    LetterPad.Ref_Person = txtref_Per.Text
                    LetterPad.Subject = txtSub.Text
                    LetterPad.ContentLP = TxtCont.Text
                    LetterPad.From = txtFrom.Text
                    LetterPad.Salutation = txtSalutation.Text
                    LetterPad.Signature = txtSignature.Text
                    LetterPad.Ref_ID_Auto = ViewState("Ref_ID_Auto")
                    dt = BLLetterPadManager.CheckDuplicate(LetterPad)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = "Data already exists."
                        lblmsg.Text = ""
                    Else
                        BLLetterPadManager.InsertRecord(LetterPad)
                        lblmsg.Text = "Data Saved Successfully. "
                        msginfo.Text = ""
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0
                        display()
                        clear()
                        TxtRef_Date.Text = Format(Today, "dd-MMM-yyyy")
                    End If
                ElseIf btnsave.Text = "UPDATE" Then
                    LetterPad.Ref_Date = TxtRef_Date.Text
                    LetterPad.Ref_No = txtRefNo.Text
                    LetterPad.Ref_Person = txtref_Per.Text
                    LetterPad.Subject = txtSub.Text
                    LetterPad.ContentLP = TxtCont.Text
                    LetterPad.From = txtFrom.Text
                    LetterPad.Salutation = txtSalutation.Text
                    LetterPad.Signature = txtSignature.Text
                    LetterPad.Ref_ID_Auto = ViewState("Ref_ID_Auto")
                    dt = BLLetterPadManager.CheckDuplicate(LetterPad)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = "Data already exists."
                        lblmsg.Text = ""
                    Else
                        BLLetterPadManager.UpdateRecord(LetterPad)
                        lblmsg.Text = "Data Updated Successfully."
                        msginfo.Text = ""
                        btnprntlettr.Enabled = True
                        btnsave.Text = "ADD"
                        btnDetails.Text = "VIEW"
                        GridView1.PageIndex = ViewState("PageIndex")
                        display()
                        clear()
                        TxtRef_Date.Text = Format(Today, "dd-MMM-yyyy")
                    End If
                End If
            Catch ex As InvalidCastException
                msginfo.Text = "Enter correct date."
                lblmsg.Text = ""
            End Try
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
        End If
    End Sub
    'code for display Single row of grid by Nitin 06/06/2012
    Public Sub displaySingleRow()
        LetterPad.Ref_ID_Auto = ViewState("Ref_ID_Auto")
        GridView1.Enabled = True
        dt = LetterPadManager.GetLetterPad(LetterPad)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
        Else
            lblmsg.Text = ""
            msginfo.Text = "No records to display."

        End If
        GridView1.Enabled = True
        GridView1.Visible = True
    End Sub
    'code for display Single row of grid by Nitin 06/06/2012
    Public Sub display()
        LinkButton1.Focus()
        LetterPad.Ref_ID_Auto = 0
        GridView1.Enabled = True
        dt = LetterPadManager.GetLetterPad(LetterPad)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
        Else
            lblmsg.Text = ""
            msginfo.Text = "No records to display."

        End If
        GridView1.Enabled = True
        GridView1.Visible = True
    End Sub
    Sub clear()
        'TxtRef_Date.Text = ""
        txtRefNo.Text = ""
        txtref_Per.Text = ""
        txtSub.Text = ""
        TxtCont.Text = ""
        txtFrom.Text = ""
        txtSalutation.Text = ""
        txtSignature.Text = ""
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
        LetterPad.Ref_ID_Auto = 0
        GridView1.Enabled = True
        dt = LetterPadManager.GetLetterPad(LetterPad)
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
