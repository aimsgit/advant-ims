Partial Class CertificateMaster
    Inherits BasePage
    Dim CertificateMasterB As New CertificateMasterB
    Dim BLL As New CertificateMasterB
    Dim DLL As New CertificateMasterDB
    Dim dt As New DataTable
    Dim CertificateMasterP As New CertificateMasterP
    Dim id1 As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtCertificateName.Focus()
        Me.Lblheading.Text = Session("RptFrmTitleName")
        
    End Sub

    Protected Sub BtnSave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ' code for Add data By Sheela 13-3-2012
        TxtCertificateName.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim EL As New CertificateMasterP
            EL.Name = TxtCertificateName.Text
            GrdCertificate.Enabled = True
            If BtnSave.CommandName = "ADD" Then
                msginfo.Text = ValidationMessage(1014)
                dt = BLL.GetDuplicateCertificateMaster(EL)
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ValidationMessage(1030)
                    msginfo.Text = ValidationMessage(1014)
                Else
                    Dim i As New Integer
                    i = BLL.InsertRecord(TxtCertificateName.Text)
                    ViewState("dispId ") = CStr(i) + "," + ViewState("dispId ")
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1020)
                    ViewState("PageIndex") = 0
                    GrdCertificate.PageIndex = 0
                    id1 = 0
                    Clear()
                    dt = DLL.GetrecordsById(ViewState("dispId "))
                    GrdCertificate.Visible = True
                    GrdCertificate.DataSource = dt
                    GrdCertificate.DataBind()
                    btn_enabled()


                End If
            ElseIf BtnSave.CommandName = "UPDATE" Then
                EL.ID = ViewState("Certificate_Id")
                EL.Name = TxtCertificateName.Text
                dt = BLL.GetDuplicateCertificateMaster(EL)
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ValidationMessage(1030)
                    msginfo.Text = ValidationMessage(1014)
                Else
                    Dim i As Int64 = BLL.UpdateRecord(EL)
                    If i > 0 Then
                        lblmsg.Text = ValidationMessage(1014)
                        msginfo.Text = ValidationMessage(1017)
                        btn_enabled()
                        Clear()
                        GrdCertificate.PageIndex = ViewState("PageIndex")
                        Binddata(id1)
                    Else
                        lblmsg.Text = ValidationMessage(1068)
                        msginfo.Text = ValidationMessage(1014)
                    End If
                End If
            End If
        Else
            lblmsg.Text = ValidationMessage(1021)
            msginfo.Text = ValidationMessage(1014)
        End If

    End Sub

    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        'Code for View data by sheela 13-3-2012
        If BtnDetails.CommandName = "VIEW" Then
            GrdCertificate.Enabled = True
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GrdCertificate.PageIndex = 0
            id1 = 0
            Binddata(id1)
            btn_enabled()
            GrdCertificate.Visible = True
        Else
            BtnSave.Text = "ADD"
            BtnDetails.Text = "VIEW"
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            GrdCertificate.PageIndex = ViewState("PageIndex")
            GrdCertificate.Enabled = True
            Binddata(id1)
            Clear()
        End If
    End Sub
    Sub GridviewItemUpdated(ByVal sender As Object, ByVal e As GridViewUpdatedEventArgs)
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1020)
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Certificate Details")
    End Sub
    Protected Sub GrdCertificate_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdCertificate.PageIndexChanging
        GrdCertificate.Enabled = True
        GrdCertificate.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GrdCertificate.PageIndex
        Binddata(id1)
    End Sub
    Protected Sub GrdCertificate_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdCertificate.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            'Code for delete row in gridview by sheela 13-3-2012
            Dim id As Int64 = Int64.Parse(GrdCertificate.DataKeys(e.RowIndex).Value.ToString)
            GrdCertificate.Enabled = True
            Dim Status As Boolean
            Status = globalcnn.Del_Validation(id, "Certificate")
            If (Status) = True Then
                e.Cancel = True
                lblmsg.Text = ValidationMessage(1064)
                msginfo.Text = ValidationMessage(1014)
                TxtCertificateName.Focus()
            Else
                BLL.ChangeFlag(id)
                GrdCertificate.PageIndex = ViewState("PageIndex")
                Binddata(id1)
                lblmsg.Text = ValidationMessage(1014)
                msginfo.Text = ValidationMessage(1028)
                TxtCertificateName.Focus()
            End If
        Else
            lblmsg.Text = ValidationMessage(1029)
            msginfo.Text = ValidationMessage(1014)
        End If

    End Sub

    Protected Sub GrdCertificate_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrdCertificate.RowEditing
        'code for edit data in gridview by sheela 13-3-2012
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        Dim f As New CertificateMasterP
        btn_disabled()
        TxtCertificateName.Text = CType(GrdCertificate.Rows(e.NewEditIndex).Cells(1).FindControl("lblname"), Label).Text
        ViewState("Certificate_Id") = CType(GrdCertificate.Rows(e.NewEditIndex).FindControl("Cid"), HiddenField).Value
        'code for bind data for single row nitin
        BtnSave.Text = "UPDATE"
        BtnDetails.Text = "Back"
        id1 = ViewState("Certificate_Id")
        Binddata(id1)
        GrdCertificate.Enabled = False
    End Sub
    Sub btn_enabled()
        BtnSave.CommandName = "ADD"
        BtnDetails.CommandName = "VIEW"
        TxtCertificateName.Text = ""
    End Sub
    Sub btn_disabled()
        BtnSave.CommandName = "UPDATE"
        BtnDetails.CommandName = "BACK"
        TxtCertificateName.Text = ""
    End Sub
   
    Sub Binddata(ByVal id1 As Long)
        Dim dt As Data.DataTable
        dt = BLL.getRecords(id1)
        If dt.Rows.Count > 0 Then
            GrdCertificate.DataSource = dt
            GrdCertificate.DataBind()
            LinkButton.Focus()
           
        Else
            GrdCertificate.DataSource = Nothing
            GrdCertificate.DataBind()
            lblmsg.Text = ValidationMessage(1023)
            msginfo.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub Clear()
        TxtCertificateName.Text = ""
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    
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
