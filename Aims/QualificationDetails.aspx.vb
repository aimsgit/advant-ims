Partial Class QualificationDetails
    Inherits BasePage
    Dim BAL As New QualificationManager
    Dim DA As New QualificationDB
    Dim quali As New Qualification
    Dim c As New CertificateReceived
    Dim EL As New Experience
    Dim EBL As New ExperienceManager
    Dim a As Integer
    Dim dt As DataTable
    Dim ELMed As New ElMedicalDetails
    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        txtExamination.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then

            Dim y As String
            quali.Std_code = ViewState("a")
            If ddlsubcertificate.SelectedValue = "Select" Then
                y = ""
            Else
                y = ddlsubcertificate.SelectedValue
            End If
            quali.Subcertificate = y
            'ddlYear.Items.Clear()
            'ddlYear.DataSourceID = "ObjMkt"
            'ddlYear.DataBind()
            'Dim date1 As String
            'date1 = ddlYear.SelectedItem.Text
            'Dim dt As DataTable
            'dt = QualificationDB.GetYear(date1)
            'Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
            'ddlYear.SelectedValue = value

            quali.YearofPassing = ddlYear.SelectedItem.Text

            quali.Marks = txtMarks.Text
            quali.Board_Univ = txt_BOU.Text
            quali.Name = txtExamination.Text
            quali.Subject1 = txtSub.Text
            quali.Subject2 = txtSub2.Text
            quali.Subject3 = txtSub3.Text
            quali.Rank = txtRank.Text
            quali.AdminDistrict = txtDistrict.Text
            quali.Medium = txtMedium.Text
            If txt_marks.Text = "" Then
                quali.TotalMarks = 0
            Else
                quali.TotalMarks = txt_marks.Text
            End If

            quali.Zindex = TxtZindex.Text
            quali.Stream = txtstream.Text
            If txtattempt.Text = "" Then
                quali.Attempt = 0
            Else
                quali.Attempt = txtattempt.Text
            End If

            If btnInsert.Text = "ADD" Then
                Dim dt1 As DataTable
                dt1 = QualificationDB.GetDuplicateQualification(quali)
                If dt1.Rows.Count > 0 Then
                    ClearControles()
                    msginfo.Text = ValidationMessage(1014)
                    lblE.Text = ValidationMessage(1030)
                    Dgrid1(0)
                    GV_qualific.Enabled = True
                Else
                    BAL.InsertRecord(quali)
                    ClearControles()
                    msginfo.Text = ValidationMessage(1020)
                    lblE.Text = ValidationMessage(1014)
                    Dgrid1(0)
                    GV_qualific.Enabled = True
                    Dim date1 As String
                    date1 = Session("CurrentYear")
                    Dim dt As DataTable
                    dt = QualificationDB.GetYear(date1)
                    Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
                    ddlYear.SelectedValue = value
                End If
            Else
                btnInsert.Text = "UPDATE"
                quali.Qualification_ID = ViewState("id")
                BAL.InsertRecord(quali)
               
                ClearControles()
                msginfo.Text = ValidationMessage(1017)
                lblE.Text = ValidationMessage(1014)
                btnInsert.Text = "ADD"
                btnView.Text = "VIEW"
                Dgrid1(0)
                GV_qualific.Enabled = True
                Dim date1 As String
                date1 = Session("CurrentYear")
                Dim dt As DataTable
                dt = QualificationDB.GetYear(date1)
                Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
                ddlYear.SelectedValue = value
            End If
        Else
            lblE.Text = ValidationMessage(1021)
            msginfo.Text = ValidationMessage(1014)
            Dgrid1(0)
            GV_qualific.Enabled = False
        End If


    End Sub
    Protected Sub btnExper_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExper.Click
        txtName.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Std_code = ViewState("a")
            EL.ExperienceType = DDLExperienceType.SelectedValue
            EL.Name = txtName.Text

            EL.Natureofjob = txtNIJ.Text
            If txtFromDt.Text = "" Then
                txtFromDt.Text = Format(Today, "dd-MMM-yyyy")
            Else
                EL.FromDate = txtFromDt.Text
            End If

            If txtToDate.Text = "" Then
                txtToDate.Text = Format(Today, "dd-MMM-yyyy")
            Else
                EL.ToDate = txtToDate.Text
            End If
            'EL.FromDate = txtFromDt.Text
            'EL.ToDate = txtToDate.Text
            EL.RemarksE = txtremarks.Text
            EL.Certificate = TextBox4.Text



            If btnExper.Text = "ADD" Then
                EBL.InsertRecord(EL)
                Dgrid2(0)
                lblS.Text = ValidationMessage(1020)
                msginfo1.Text = ValidationMessage(1014)
                GV_Exp.Enabled = True
                ClearControls1()


            Else
                EL.ExpId = ViewState("id1")
                EBL.InsertRecord(EL)
                lblS.Text = ValidationMessage(1017)
                msginfo1.Text = ValidationMessage(1014)
                btnExper.Text = "ADD"
                btnDet.Text = "VIEW"
                Dgrid2(0)
                GV_Exp.Enabled = True
                ClearControls1()


            End If
        Else
            msginfo1.Text = ValidationMessage(1021)
            lblS.Text = ValidationMessage(1014)
            Dgrid2(0)
            GV_Exp.Enabled = False
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        'TextBox4.Attributes.Add("onchange", "DefaultValue();")
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading

        TextBox4.Text = Session("FilePath")
       


        


        'ddlYear.Items.Clear()
        'ddlYear.DataSourceID = "ObjSelectYear"
        'ddlYear.DataBind()

        'Dim date1 As String
        'date1 = Session("CurrentYear")
        'Dim dt As DataTable
        'dt = QualificationDB.GetYear(date1)
        'Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
        'ddlYear.SelectedValue = value

        Try
            Dim scode As String = Request.QueryString.Get("Stdcode")
            Dim sID As Integer = Request.QueryString.Get("ID")
            If scode <> "" And sID <> Nothing Then
                txtStudentcode.Text = ViewState("Text")
                a = sID
                txtExamination.Focus()
            Else
                If txtStudentcode.Text <> "" Then
                    If IsNothing(a) Then

                        Dim s As String = txtStudentcode.Text
                        Dim words As String() = s.Split(New Char() {":"c})
                        a = words(2)
                    End If
                Else
                    txtStudentcode.Focus()

                End If
            End If

            GV_qualific.Visible = False
            GV_Exp.Visible = False

            msginfo.Text = ValidationMessage(1014)
            msginfo1.Text = ValidationMessage(1014)

            lblS.Text = ValidationMessage(1014)

            lblE.Text = ValidationMessage(1014)
        Catch ex As Exception
            lblE.Text = ValidationMessage(1022)
            msginfo.Text = ValidationMessage(1014)
            msginfo1.Text = ValidationMessage(1014)



            GV_qualific.Visible = False
            GV_Exp.Visible = False

        End Try

    End Sub
    Protected Sub btnfee_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnfee.Click
        Session("RptFrmTitleName") = "FEE COLLECTION"
        Response.Redirect("FormFeeCollection.aspx?Type=" & 1 & "&StdCode=" & Session("std_code"))
    End Sub
    Private Sub ClearControles()
        Me.txt_BOU.Text = ""
        Me.txt_marks.Text = ""
        Me.txtExamination.Text = ""
        Me.txtMedium.Text = ""
        Me.txtSub.Text = ""
        Me.txtSub2.Text = ""
        Me.txtSub3.Text = ""
        Me.txtRank.Text = ""
        Me.txtDistrict.Text = ""
        Me.txtMarks.Text = ""
        Me.TxtZindex.Text = ""
        Me.txtattempt.Text = ""
        Me.txtstream.Text = ""

        'Me.txt_YOP.Text = ""
        Me.ddlsubcertificate.SelectedValue = "Select"

    End Sub

    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Response.Redirect("Registration.aspx")
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub


    Protected Sub btnDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDet.Click
        txtName.Focus()
        If btnDet.Text = "VIEW" Then
            If txtStudentcode.Text <> "" Then
                GV_Exp.Enabled = True
                Dgrid2(0)
            Else
                msginfo1.Text = ValidationMessage(1155)
            End If
        Else
            btnDet.Text = "VIEW"
            btnExper.Text = "ADD"
         
            Dgrid2(0)
            ClearControls1()
            GV_Exp.Enabled = True
        End If

    End Sub
    Public Sub Dgrid2(ByVal y As Integer)
        Dim dt As DataTable
        dt = ExperienceDB.GetExperience2(ViewState("a"), y)
        If dt.Rows.Count > 0 Then
            GV_Exp.DataSource = dt
            GV_Exp.DataBind()
           
            GV.Visible = False
            GV_Exp.Visible = True

        Else
            lblS.Text = ValidationMessage(1014)
            msginfo1.Text = ValidationMessage(1023)
           

            GV_Exp.Visible = False
            GV_qualific.Visible = False
        End If
    End Sub
    Public Sub ClearControls1()
        Me.txtName.Text = ""
        Me.txtNIJ.Text = ""
        Session("FilePath") = ""
        Me.TextBox4.Text = ""
        txtremarks.Text = ""

    End Sub
    Public Sub ClearControls2()

        Me.txtremarks.Text = ""
    End Sub


   

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        txtExamination.Focus()
        Dim date1 As String
        date1 = Session("CurrentYear")
        Dim dt As DataTable
        dt = QualificationDB.GetYear(date1)
        Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
        ddlYear.SelectedValue = value
        If btnView.Text = "VIEW" Then
            If txtStudentcode.Text <> "" Then
                GV_qualific.Enabled = True
                Dgrid1(0)
            Else
                lblE.Text = ValidationMessage(1155)
            End If
        Else
            btnView.Text = "VIEW"
            btnInsert.Text = "ADD"
            GV_qualific.Enabled = True
            Dgrid1(0)
            ClearControles()

        End If

    End Sub
    Public Sub Dgrid1(ByVal x As Integer)
        Dim dt As DataTable
        GV.Visible = "True"
        dt = QualificationDB.GetQualification(ViewState("a"), x)
        If dt.Rows.Count > 0 Then
            GV_qualific.DataSource = dt
            GV_qualific.DataBind()
            
            GV_qualific.Visible = True
        Else
            GV.Visible = "False"
            lblS.Text = ValidationMessage(1014)
            lblE.Text = ValidationMessage(1023)
            msginfo.Text = ValidationMessage(1014)
           

            GV_Exp.Visible = False
            GV_qualific.Visible = False
        End If

    End Sub

    Protected Sub GV_qualific_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GV_qualific.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("id") = CType(GV_qualific.Rows(e.RowIndex).FindControl("Qualification_ID"), HiddenField).Value
            BAL.ChangeFlag(ViewState("id"))
            txtExamination.Focus()
            Dgrid1(0)
            lblE.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1028)
        Else
            lblE.Text = ValidationMessage(1029)
            msginfo.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub GV_qualific_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GV_qualific.RowEditing
        txtExamination.Focus()
        Dim x As String
        txtStudentcode.Text = ViewState("Text")
        x = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("lbl_Certificate"), Label).Text
        If x = "" Then
            ddlsubcertificate.SelectedValue = x
        ElseIf x = "Xerox" Then
            ddlsubcertificate.SelectedValue = "Xerox"
        ElseIf x = "Original" Then
            ddlsubcertificate.SelectedValue = "Original"
        End If
        txtExamination.Text = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("lblname"), Label).Text
        txtSub.Text = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("lbl_Subject1"), Label).Text
        txt_BOU.Text = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("lbl_universe"), Label).Text
        txtSub2.Text = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("lbl_Subject2"), Label).Text
        txtSub3.Text = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("lbl_Subject3"), Label).Text
        txt_marks.Text = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("lbl_Totmarks"), Label).Text
        txtMedium.Text = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("lbl_Medium"), Label).Text
        txtRank.Text = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("lbl_Rank"), Label).Text
        txtDistrict.Text = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("lbl_AdminDistrict"), Label).Text
        TxtZindex.Text = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("lbl_Zindx"), Label).Text
        txtstream.Text = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("lblstream"), Label).Text
        txtattempt.Text = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("lblattempt"), Label).Text


        Dim date1 As String
        date1 = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("lbl_YOP"), Label).Text
        Dim dt As DataTable
        dt = QualificationDB.GetYear(date1)
        Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
        ddlYear.SelectedValue = value
        txtMarks.Text = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("lbl_marks"), Label).Text
        ViewState("id") = CType(GV_qualific.Rows(e.NewEditIndex).FindControl("Qualification_ID"), HiddenField).Value
        btnInsert.Text = "UPDATE"
        btnView.Text = "BACK"
        
        Dgrid1(ViewState("id"))
        GV_qualific.Enabled = False


    End Sub

    Protected Sub GV_Exp_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GV_Exp.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("id") = CType(GV_Exp.Rows(e.RowIndex).FindControl("ExpId"), HiddenField).Value
            ExperienceDB.ChangeFlag(ViewState("id"))
            txtName.Focus()
            Dgrid2(0)
            GV_Exp.Enabled = True
            msginfo1.Text = ValidationMessage(1014)
            lblS.Text = ValidationMessage(1028)
        Else
            lblE.Text = ValidationMessage(1029)
            msginfo.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub GV_Exp_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GV_Exp.RowEditing
        txtName.Focus()
        DDLExperienceType.SelectedValue = CType(GV_Exp.Rows(e.NewEditIndex).FindControl("ExperienceTypeID"), Label).Text

        'txtNOY.Text = CType(GV_Exp.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        txtNIJ.Text = CType(GV_Exp.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        txtName.Text = CType(GV_Exp.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        txtremarks.Text = CType(GV_Exp.Rows(e.NewEditIndex).FindControl("LabelRemark"), Label).Text
        txtFromDt.Text = CType(GV_Exp.Rows(e.NewEditIndex).FindControl("lblfromdate"), Label).Text
        txtToDate.Text = CType(GV_Exp.Rows(e.NewEditIndex).FindControl("lbltodate"), Label).Text
        TextBox4.Text = CType(GV_Exp.Rows(e.NewEditIndex).FindControl("LabelCer"), Label).Text
        ViewState("id1") = CType(GV_Exp.Rows(e.NewEditIndex).FindControl("ExpId"), HiddenField).Value
        btnExper.Text = "UPDATE"
        btnDet.Text = "BACK"
       
        Dgrid2(ViewState("id1"))
        GV_Exp.Enabled = False
    End Sub

   

    Protected Sub txtStudentcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStudentcode.TextChanged
        Try
            Dim s As String = txtStudentcode.Text
            Dim words As String() = s.Split(New Char() {":"c})
            txtStudentcode.Text = words(0) + ":" + words(1)
            ViewState("a") = words(2)
            ViewState("Text") = txtStudentcode.Text
            GV_Exp.Visible = False
            GV_qualific.Visible = False
        Catch ex As Exception
            ViewState("a") = 1
            ViewState("Text") = ""
            lblE.Text = ValidationMessage(1156)
            GV_Exp.Visible = False
            GV_qualific.Visible = False
        End Try
    End Sub

    Protected Sub GV_qualific_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GV_qualific.Sorting

        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        dt = QualificationDB.GetQualification(ViewState("a"), 0)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GV_qualific.DataSource = sortedView
        GV_qualific.DataBind()
       
        GV_qualific.Visible = True
        GV_qualific.Focus()
    End Sub

    Protected Sub GV_Exp_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GV_Exp.Sorting

        Dim sortingDirection As String = String.Empty
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        dt = ExperienceDB.GetExperience2(ViewState("a"), 0)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GV_Exp.DataSource = sortedView
        GV_Exp.DataBind()
      
        GV_Exp.Visible = True
        GV_Exp.Focus()
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
    Sub clear()
        HidstdId.Value = ""
        txtStdCode2.Text = ""
        HidId.Value = ""
        txtHeight1.Text = ""
        txtWeight1.Text = ""
        txtHeight1.Text = ""
        txtIdentificationMark1.Text = ""
        txtBloodGroup1.Text = ""
        txtImmunizationRecord1.Text = ""
        txtDetailsofanyseriousillness1.Text = ""
        txtParticularsofanyallergies1.Text = ""
        txtEmergencyContactName1.Text = ""
        txtEmergencyContactNumber1.Text = ""
        txtDisabilitiesifany1.Text = ""
    End Sub
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try

                ELMed.Std_ID = HidstdId.Value
                'ELMed.Id = IIf(HidId.Value = Nothing, 0, HidId.Value)
                ELMed.Height = txtHeight1.Text
                ELMed.Weight = txtWeight1.Text
                ELMed.Height = txtHeight1.Text
                ELMed.IdentificationMark = txtIdentificationMark1.Text
                ELMed.BloodGroup = txtBloodGroup1.Text
                ELMed.ImmunizationRecord = txtImmunizationRecord1.Text
                ELMed.Detailsofanyseriousillness = txtDetailsofanyseriousillness1.Text
                ELMed.Particularsofanyallergies = txtParticularsofanyallergies1.Text
                ELMed.EmergencyContactName = txtEmergencyContactName1.Text
                ELMed.EmergencyContactNumber = txtEmergencyContactNumber1.Text
                ELMed.Disabilitiesifany = txtDisabilitiesifany1.Text
                ELMed.LoginType = "Student"
                ELMed.Id = ViewState("lblId")
                If btnadd.Text = "ADD" Then
                    dt = DlMedicalDetails.GetDuplicate(ELMed)
                    If dt.Rows.Count > 0 Then
                        lblRed.Text = "Data already Exists."
                        lblGreen.Text = ""
                        DisplayMedical(0)
                        'Exit Sub
                    Else

                        Dim i As Integer = DlMedicalDetails.Insert(ELMed)
                        If i > 0 Then
                            lblGreen.Text = ValidationMessage(1020)
                            lblRed.Text = ValidationMessage(1014)
                            DisplayMedical(0)
                            clear()
                        End If
                    End If

                Else
                    dt = DlMedicalDetails.GetDuplicate(ELMed)
                    If dt.Rows.Count > 0 Then
                        lblRed.Text = "Data already Exists."
                        lblGreen.Text = ""
                        DisplayMedical(0)
                        'Exit Sub
                    Else

                        ELMed.Id = ViewState("lblId")
                        Dim i As Integer = DlMedicalDetails.Update(ELMed)
                        If i > 0 Then
                            lblGreen.Text = ValidationMessage(1017)
                            lblRed.Text = ValidationMessage(1014)
                            clear()
                            btnadd.CommandName = "ADD"
                            btnView.CommandName = "VIEW"
                            btnadd.Text = "ADD"
                            btnView.Visible = True
                            btnView.Text = "VIEW"
                            DisplayMedical(0)
                            
                        End If
                    End If
                End If


            Catch ex As Exception
                lblRed.Text = ValidationMessage(1132)
                lblGreen.Text = ValidationMessage(1014)
            End Try
        Else
            lblRed.Text = ValidationMessage(1021)
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        LinkButton3.Focus()
        Try
            lblRed.Text = ValidationMessage(1014)
            lblGreen.Text = ValidationMessage(1014)
            'btnadd.Text = "ADD3"
            'btnBack.Text = "VIEW3"
            If btnBack.Text = "VIEW" Then
                DisplayMedical(0)
               
            Else
                DisplayMedical(0)

                clear()
                GridMedical.Enabled = True
                btnadd.Text = "ADD"
                btnBack.Text = "VIEW"
             
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub DisplayMedical(ByVal i As Integer)
        Dim dt As New DataTable
        ELMed.Id = i
        ELMed.LoginType = "Student"
        dt = DlMedicalDetails.GetData(ELMed)
        If dt.Rows.Count <> 0 Then
            GridMedical.DataSource = dt
            GridMedical.DataBind()
           
            GridMedical.Visible = True
            GridMedical.Enabled = True
        Else
            lblRed.Text = ValidationMessage(1023)
            lblGreen.Text = ValidationMessage(1014)
          
            GridMedical.Visible = False
        End If
    End Sub

    Protected Sub GridMedical_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridMedical.PageIndexChanging
        Try
            GridMedical.PageIndex = e.NewPageIndex
            ViewState("PageIndex") = GridMedical.PageIndex
            GridMedical.DataBind()
          
            DisplayMedical(0)
        Catch ex As Exception

        End Try
    End Sub

    'Protected Sub GridMedical_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridMedical.RowDeleting
    '    lblRed.Text = ""
    '    lblGreen.Text = ""
    '    If (Session("BranchCode") = Session("ParentBranch")) Then
    '        ELMed.Id = CType(GridMedical.Rows(e.RowIndex).Cells(1).FindControl("lblID"), System.Web.UI.WebControls.Label).Text
    '        DlMedicalDetails.GetDelete(ELMed)
    '        GridMedical.DataBind()
    '        lblRed.Text = ""
    '        lblGreen.Text = "Data Deleted Successfully."
    '        GridMedical.PageIndex = ViewState("PageIndex")
    '        DisplayMedical(0)
    '    Else
    '        lblRed.Text = "You do not belong to this branch, Cannot delete data."
    '        lblGreen.Text = ""
    '    End If
    'End Sub
    Protected Sub GridMedical_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridMedical.RowDeleting
        lblRed.Text = ValidationMessage(1014)
        lblGreen.Text = ValidationMessage(1014)
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ELMed.Id = CType(GridMedical.Rows(e.RowIndex).Cells(1).FindControl("lblID"), System.Web.UI.WebControls.Label).Text
            DlMedicalDetails.GetDelete(ELMed)
            DisplayMedical(0)
            GridMedical.Visible = True

            GridMedical.PageIndex = ViewState("PageIndex")
            DisplayMedical(0)
            clear()
            lblRed.Text = ValidationMessage(1014)
            lblGreen.Text = ValidationMessage(1028)
        Else
            lblRed.Text = ValidationMessage(1029)
            lblGreen.Text = ValidationMessage(1014)
        End If

    End Sub

    Protected Sub GridMedical_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridMedical.RowEditing
        lblRed.Text = ValidationMessage(1014)
        lblGreen.Text = ValidationMessage(1014)
        Try
            ViewState("lblId") = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblID"), System.Web.UI.WebControls.Label).Text
            HidstdId.Value = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblStdId"), System.Web.UI.WebControls.Label).Text
            txtStdCode2.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblcode"), System.Web.UI.WebControls.Label).Text
            txtHeight1.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblHeight"), System.Web.UI.WebControls.Label).Text
            txtWeight1.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblWeight"), System.Web.UI.WebControls.Label).Text
            txtIdentificationMark1.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblIdentificationMark"), System.Web.UI.WebControls.Label).Text
            txtBloodGroup1.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblBloodGroup"), System.Web.UI.WebControls.Label).Text
            txtImmunizationRecord1.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblImmunizationRecord"), System.Web.UI.WebControls.Label).Text
            txtDetailsofanyseriousillness1.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblDetailsofanyseriousillness"), System.Web.UI.WebControls.Label).Text
            txtParticularsofanyallergies1.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblParticularsofanyallergies"), System.Web.UI.WebControls.Label).Text
            txtEmergencyContactName1.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblEmergencyContactName"), System.Web.UI.WebControls.Label).Text
            txtEmergencyContactNumber1.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblEmergencyContactNumber"), System.Web.UI.WebControls.Label).Text
            txtDisabilitiesifany1.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblDisabilitiesifany"), System.Web.UI.WebControls.Label).Text
            ELMed.Id = ViewState("lblId")
            btnadd.Text = "UPDATE"
            btnBack.Text = "BACK"
            
            Dim dt As New DataTable
            GridMedical.Enabled = False
            DisplayMedical(ELMed.Id)
        Catch ex As Exception
            lblRed.Text = ValidationMessage(1022)
            lblGreen.Text = ValidationMessage(1014)
        End Try
    End Sub

    Protected Sub txtStdCode2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStdCode2.TextChanged
        Try
            Dim s As String = txtStdCode2.Text
            Dim words As String() = s.Split(New Char() {":"c})
            txtStdCode2.Text = words(0) + ":" + words(1)
            HidstdId.Value = words(2)
            ViewState("Ma") = words(2)
            ViewState("MText") = txtStudentcode.Text
            GridMedical.Visible = False
        Catch ex As Exception
            lblE.Text = ValidationMessage(1023)
            GridMedical.Visible = False
        End Try
    End Sub
    'Code written fro multilingual by Niraj on 10 aug 2013
    ''Retriving the text of controls based on Language

    
   
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        Try
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
        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try
        Return 0
    End Function
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub

End Class