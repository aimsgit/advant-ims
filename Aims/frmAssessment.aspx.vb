Partial Class frmAssessment
    Inherits BasePage

    Dim BLL As New AssessmentB
    Dim dt As New DataTable
    Dim el As New Assessment
    Dim Dl As New AssessmentD
    Dim id1 As Integer
    Dim dispid As String

    Protected Sub BtnSave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then

            ' code for duplicate data By sheela 13-3-2012
            Dim EL As New Assessment
            EL.Name = TxtAssessmentName.Text
            EL.SeqNo = txtSequence.Text
            If BtnSave.CommandName = "ADD" Then
                dt = BLL.GetDuplicateCertificateMaster(EL)

                If dt.Rows.Count > 0 Then
                    msginfo.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1030)
                Else
                    Dim i As New Integer
                    i = BLL.InsertRecord(TxtAssessmentName.Text, txtSequence.Text)
                    ViewState("dispId ") = CStr(i) + "," + ViewState("dispId ")
                    msginfo.Text = ValidationMessage(1020)
                    lblmsg.Text = ValidationMessage(1014)
                    Clear()
                    id1 = 0
                    dt = Dl.GetrecordsById(ViewState("dispId "))
                    'dt = BAL.GetEnquiry(enq)
                    GrdAssessment.Visible = True
                    GrdAssessment.DataSource = dt
                    GrdAssessment.DataBind()
                    btn_enabled()
                    Multilingual()
                End If

            ElseIf BtnSave.CommandName = "UPDATE" Then

                EL.ID = ViewState("ID")
                dt = BLL.GetDuplicateCertificateMaster(EL)

                If dt.Rows.Count > 0 Then
                    msginfo.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1030)
                Else
                    EL.Name = TxtAssessmentName.Text
                    EL.SeqNo = txtSequence.Text
                    Dim i As Int64 = BLL.UpdateRecord(EL)
                    If i > 0 Then
                        msginfo.Text = ValidationMessage(1017)
                        lblmsg.Text = ValidationMessage(1014)
                        Clear()
                        btn_enabled()
                        Binddata(id1)
                    Else
                        msginfo.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1031)
                    End If
                End If
            End If
        Else
            lblmsg.Text = ValidationMessage(1021)
            msginfo.Text = ValidationMessage(1014)
        End If

    End Sub


    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click

        ' code for Display data By sheela 13-3-2012
        If (BtnDetails.CommandName = "VIEW") Then
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            id1 = 0
            Binddata(id1)
            btn_enabled()
            GrdAssessment.Visible = True
            'Clear()
        ElseIf BtnDetails.CommandName = "BACK" Then

            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            id1 = 0
            Binddata(id1)
            btn_enabled()
            GrdAssessment.Visible = True
            Clear()

            Multilingual()
        End If
    End Sub
    Sub GridviewItemUpdated(ByVal sender As Object, ByVal e As GridViewUpdatedEventArgs)
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1020)
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            Control_Text_Multilingual()
        End If
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Assessment Details")
    End Sub
    Protected Sub GrdAssessment_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdAssessment.PageIndexChanging
        GrdAssessment.PageIndex = e.NewPageIndex
        Binddata(id1)
    End Sub
    Protected Sub GrdAssessment_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdAssessment.RowDeleting

        ' code for Row Deleting By sheela 13-3-2012
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim id As Int64 = Int64.Parse(GrdAssessment.DataKeys(e.RowIndex).Value.ToString)
            Dim Status As Boolean
            Status = globalcnn.Del_Validation(id, "Assessment")
            If (Status) = True Then
                lblmsg.Text = ValidationMessage(1064)
                msginfo.Text = ValidationMessage(1014)
                e.Cancel = True
            Else
                BLL.ChangeFlag(id)
                Binddata(id1)
                lblmsg.Text = ValidationMessage(1014)
                msginfo.Text = ValidationMessage(1028)
            End If
        Else
            lblmsg.Text = ValidationMessage(1029)
            msginfo.Text = ValidationMessage(1014)
        End If

    End Sub

    Protected Sub GrdAssessment_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrdAssessment.RowEditing

        ' code for Row Editing By sheela 13-3-2012
        Dim f As New Assessment
        btn_disabled()
        TxtAssessmentName.Text = CType(GrdAssessment.Rows(e.NewEditIndex).Cells(1).FindControl("lblname"), Label).Text
        txtSequence.Text = CType(GrdAssessment.Rows(e.NewEditIndex).Cells(1).FindControl("lblSeqNo"), Label).Text
        ViewState("ID") = CType(GrdAssessment.Rows(e.NewEditIndex).FindControl("Cid"), HiddenField).Value
        id1 = ViewState("ID")
        Binddata(id1)
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        
    End Sub
    Sub btn_enabled()
        BtnSave.CommandName = "ADD"
        BtnDetails.CommandName = "VIEW"
        GrdAssessment.Enabled = True
        TxtAssessmentName.Text = ""
    End Sub
    Sub btn_disabled()
        BtnSave.CommandName = "UPDATE"
        BtnDetails.CommandName = "BACK"
        GrdAssessment.Enabled = False
        TxtAssessmentName.Text = ""
    End Sub
    Sub Binddata(ByVal id1 As Long)
        ' code for Bind data By sheela 13-3-2012
        Dim dt As Data.DataTable
        dt = BLL.getRecords(id1)
        If dt.Rows.Count > 0 Then
            GrdAssessment.DataSource = dt
            GrdAssessment.DataBind()
            GrdAssessment.Visible = True
            LinkButton.Focus()
            Multilingual()
        Else
            lblmsg.Text = ValidationMessage(1023)
            msginfo.Text = ValidationMessage(1014)
            GrdAssessment.Visible = False
        End If
    End Sub
    Sub Clear()
        TxtAssessmentName.Text = ""
        txtSequence.Text = ""
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    ''Code Written for Multilingual By Ajit Kumar Singh on 12th Aug
    ''Retriving the text of controls based on Language
    Sub Multilingual()
        Dim j As Integer
        Dim k As Integer
        Dim dtl As DataTable
        dtl = Session("Control_Text")
        Dim i As Integer = dtl.Rows.Count
        While (i <> 0)
            If dtl.Rows(i - 1).Item("ControlType") = "Label" Then
                Dim myLabel As Label = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Label)
                myLabel.Text = dtl.Rows(i - 1).Item("Default_Text")
                i = i - 1
            ElseIf dtl.Rows(i - 1).Item("ControlType") = "Button" Then
                If dtl.Rows(i - 1).Item("ControlCommandName") = BtnSave.CommandName Then
                    Dim myButton As Button = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Button)
                    myButton.Text = dtl.Rows(i - 1).Item("Default_Text")
                    i = i - 1
                ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = BtnDetails.CommandName Then
                    Dim myButton As Button = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Button)
                    myButton.Text = dtl.Rows(i - 1).Item("Default_Text")
                    i = i - 1
                Else
                    i = i - 1
                End If

            ElseIf dtl.Rows(i - 1).Item("ControlType") = "GridLabel" Then
                j = GrdAssessment.Columns.Count
                While (j <> 0)
                    If GrdAssessment.Columns(j - 1).HeaderText = dtl.Rows(i - 1).Item("ControlCommandName") Then
                        GrdAssessment.Columns(j - 1).HeaderText = dtl.Rows(i - 1).Item("Default_Text")
                    End If
                    j = j - 1
                End While
                i = i - 1
            ElseIf dtl.Rows(i - 1).Item("ControlType") = "GridButton" Then
                k = GrdAssessment.Rows.Count
                If dtl.Rows(i - 1).Item("ControlCommandName") = "Acknowledge" Then
                    While (k <> 0)
                        Dim lnkCanc As LinkButton = CType(GrdAssessment.Rows(k - 1).FindControl(dtl.Rows(i - 1).Item("ControlId")), LinkButton)
                        lnkCanc.Text = dtl.Rows(i - 1).Item("Default_Text")
                        k = k - 1
                    End While
                ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = "Edit" Then
                    k = GrdAssessment.Rows.Count
                    While (k <> 0)
                        Dim lnkCanc As LinkButton = CType(GrdAssessment.Rows(k - 1).FindControl(dtl.Rows(i - 1).Item("ControlId")), LinkButton)
                        lnkCanc.Text = dtl.Rows(i - 1).Item("Default_Text")
                        k = k - 1
                    End While
                ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = "Delete" Then
                    k = GrdAssessment.Rows.Count
                    While (k <> 0)
                        Dim lnkCanc As LinkButton = CType(GrdAssessment.Rows(k - 1).FindControl(dtl.Rows(i - 1).Item("ControlId")), LinkButton)
                        lnkCanc.Text = dtl.Rows(i - 1).Item("Default_Text")
                        k = k - 1
                    End While
                End If
                i = i - 1
            ElseIf dtl.Rows(i - 1).Item("ControlType") = "CheckBox" Then
                Dim myCheckbox As CheckBox = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), CheckBox)
                myCheckbox.Text = dtl.Rows(i - 1).Item("Default_Text")
                i = i - 1
            ElseIf dtl.Rows(i - 1).Item("ControlType") = "RadioButtonList" Then
                Dim myRadiobutton As RadioButtonList = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), RadioButtonList)
                Dim a As Integer = myRadiobutton.Items.Count
                While (a <> 0)
                    For Each li As ListItem In myRadiobutton.Items
                        If li.Value = dtl.Rows(i - 1).Item("ControlCommandName") Then
                            li.Text = dtl.Rows(i - 1).Item("Default_Text")
                        End If
                    Next
                    a = a - 1
                End While
                i = i - 1
            End If
        End While
    End Sub
    Public Sub Control_Text_Multilingual()
        Dim dtll As DataTable
        Dim FormName As String = Session("Code")
        Dim LanguageID As Integer
        If Session("LanguageID") = "" Then
            LanguageID = 0
        Else
            LanguageID = Session("LanguageID")
        End If
        If LanguageID <> 0 Then
            dtll = GlobalFunction.GetChangeLanguage(FormName, LanguageID)
            Session("Control_Text") = dtll
            Multilingual()
        End If
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
