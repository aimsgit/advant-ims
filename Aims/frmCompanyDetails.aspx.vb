
Partial Class frmCompanyDetails
    Inherits BasePage
    Dim BL As New CompanyManagerB
    Dim dt As New DataTable
    Dim EL As New CompanyDetails
    Dim id1 As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            TextCompName.Focus()
            
        End If
        lblmsg.Text = ValidationMessage(1014)
        ClientScript.RegisterHiddenField("_EVENTTARGET", "btnSave")
        ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & TextCompName.ClientID & "').focus();</script>")
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then

            Dim id As Int64 = Int64.Parse(GridView1.DataKeys(e.RowIndex).Value.ToString)
            BL.ChangeFlag(id)
            GridView1.PageIndex = ViewState("PageIndex")
            Binddata(id1)
            lblmsg.Text = ValidationMessage(1028)
            msginfo.Text = ValidationMessage(1014)
            TextCompName.Focus()
            Binddata(id1)
            'End If
        Else
            lblmsg.Text = ValidationMessage(1029)
            msginfo.Text = ValidationMessage(1014)
        End If

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then

        btn_disabled()
        TextCompName.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("label1"), Label).Text
        ViewState("PCId") = CType(GridView1.Rows(e.NewEditIndex).FindControl("RID"), HiddenField).Value
        TextContPer.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(2).FindControl("label2"), Label).Text
        ViewState("PCId") = CType(GridView1.Rows(e.NewEditIndex).FindControl("RID"), HiddenField).Value
        TextContNo.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(3).FindControl("label3"), Label).Text
        ViewState("PCId") = CType(GridView1.Rows(e.NewEditIndex).FindControl("RID"), HiddenField).Value
        TextAdd.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(4).FindControl("label4"), Label).Text
        ViewState("PCId") = CType(GridView1.Rows(e.NewEditIndex).FindControl("RID"), HiddenField).Value
        BtnSave.CommandName = "UPDATE"
        BtnSave.Text = "UPDATE"
        BtnDetails.Text = "BACK"
        id1 = ViewState("PCId")
        EL.Id = ViewState("PCId")
        Binddata(id1)
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
    End Sub
    Sub cancel1(ByVal sender As Object, ByVal e As System.EventArgs)
        Objcompany.SelectParameters.Clear()
        ID = 0
        Objcompany.SelectParameters.Add("id", ID)
        GridView1.DataBind()
        GridView1.Enabled = True
        GridView1.Columns(1).Visible = True
        
    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        TextCompName.Focus()
        LinkButton1.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then

            Dim EL As New CompanyDetails
            EL.Name = TextCompName.Text
            EL.ContactPerson = TextContPer.Text
            EL.ContactNo = TextContNo.Text
            EL.Address = TextAdd.Text
            If BtnSave.CommandName = "ADD" Then
                dt = BL.GetDuplicateCertificateMaster(EL)
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ValidationMessage(1030)
                    msginfo.Text = ValidationMessage(1014)
                Else
                    BL.InsertRecord(EL)
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1020)
                    id1 = 0
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    Binddata(id1)
                    btn_enabled()
                    GridView1.Visible = True
                End If

            ElseIf BtnSave.CommandName = "UPDATE" Then
                EL.Id = ViewState("PCId")
                EL.Name = TextCompName.Text
                EL.ContactPerson = TextContPer.Text
                EL.ContactNo = TextContNo.Text
                EL.Address = TextAdd.Text
                dt = BL.GetDuplicateCertificateMaster(EL)
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ValidationMessage(1030)
                    msginfo.Text = ValidationMessage(1014)
                Else
                    Dim i As Int64 = BL.UpdateRecord(EL)
                    BtnSave.Text = "ADD"
                    BtnDetails.Text = "VIEW"
                    If i > 0 Then
                        lblmsg.Text = ValidationMessage(1014)
                        msginfo.Text = ValidationMessage(1017)
                        TextCompName.Focus()
                        btn_enabled()
                        GridView1.PageIndex = ViewState("PageIndex")
                        EL.Id = 0
                        Binddata(id1)
                    Else
                        lblmsg.Text = ValidationMessage(1031)
                        msginfo.Text = ValidationMessage(1014)
                    End If
                End If
            End If
        Else
            lblmsg.Text = ValidationMessage(1021)
            msginfo.Text = ValidationMessage(1014)
        End If

    End Sub
    Protected Sub BtnDetails_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        TextCompName.Focus()
        LinkButton1.Focus()
        If BtnDetails.CommandName = "VIEW" Then
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            id1 = 0
            Binddata(id1)
            btn_enabled()
            GridView1.Visible = True
        Else
            BtnSave.CommandName = "ADD"
            BtnSave.Text = "ADD"
            BtnDetails.CommandName = "VIEW"
            BtnDetails.Text = "VIEW"
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            GridView1.PageIndex = ViewState("PageIndex")
            GridView1.Enabled = True
            Binddata(id1)
            Clear()
        End If

    End Sub
    Protected Sub GrdCertificate_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        Binddata(id1)
        GridView1.Visible = True
    End Sub
    Sub btn_enabled()
        BtnSave.CommandName = "ADD"
        BtnDetails.CommandName = "VIEW"
        GridView1.Enabled = True
        TextCompName.Text = ""
        TextContPer.Text = ""
        TextContNo.Text = ""
        TextAdd.Text = ""
    End Sub
    Sub btn_disabled()
        BtnSave.CommandName = "UPDATE"
        BtnDetails.CommandName = "BACK"
        GridView1.Enabled = False
        TextCompName.Text = ""
        TextContPer.Text = ""
        TextContNo.Text = ""
        TextAdd.Text = ""
    End Sub
    Sub AlertEnterAllFields(ByVal str As String)
        msginfo.Text = ValidationMessage(1014)
        lblmsg.Text = str
        msginfo.Text = ValidationMessage(1014)
    End Sub
    Sub AlertEnterAllField(ByVal str As String)
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = str
        lblmsg.Text = ValidationMessage(1014)
    End Sub
    Sub Binddata(ByVal id1 As Long)
        Try
            Dim dt As New Data.DataTable
            dt = BL.GetRecords(id1)
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
                
            Else
                GridView1.DataSource = Nothing
                GridView1.DataBind()
                lblmsg.Text = ValidationMessage(1023)
                msginfo.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub Clear()
        TextCompName.Text = ""
        TextContPer.Text = ""
        TextContNo.Text = ""
        TextAdd.Text = ""
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
        Dim dt As New Data.DataTable
        dt = BL.GetRecords(id1)
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
End Class
