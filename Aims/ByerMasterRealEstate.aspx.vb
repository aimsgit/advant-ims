
Partial Class ByerMasterRealEstate
    Inherits BasePage
    Dim EL As New EL_BuyerMaster
    Dim BL As New BL_BuyerMaster
    Dim dt As New DataTable
    Dim path, path1, str As String
    Dim DL As New DL_BuyerMaster
    Protected Sub Btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Fname = txtFName.Text
            EL.Lname = txtLname.Text
            EL.BuyerCode = txtBuyerCode.Text
            'EL.Photo = ViewState("ImageTime")
            EL.Tin = txtTIN.Text
            EL.CST_NO = txtCSTNo.Text
            EL.PAN_NO = txtPAN.Text
            EL.Contact_Number1 = txtContactNo1.Text
            EL.Contact_Number2 = txtContactNo2.Text
            EL.Email1 = txtEmail1.Text
            EL.Email2 = txtEmail2.Text
            EL.Fax_NO = txtFaxNo.Text
            EL.Contact_Person = txtContactPerson.Text
            EL.Introducer = txtIntro.Text
            EL.Off_Address = txtAddress.Text
            EL.Res_Address = txtAddr.Text
            EL.Off_City = txtCity.Text
            EL.Res_City = txtcity1.Text
            EL.Off_District = txtDistrict.Text
            EL.Res_District = txtDistrict1.Text
            EL.Off_State = ddlState.SelectedValue
            EL.Res_State = ddlState1.SelectedValue
            EL.Off_Country = ddlCountry.SelectedValue
            EL.Res_Country = ddlCountry1.SelectedValue
            EL.Bank_Name = txtBankName.Text
            EL.Account_Number = txtAccountNo.Text
            EL.Bank_Branch = txtBankBranch.Text
            EL.Type_Of_Account = ddlType.SelectedValue
            EL.IFSC_Code = txtIFSC.Text
            If ViewState("ImageTime") = Nothing Then
                EL.Photo = ""
            Else
                EL.Photo = ViewState("ImageTime")
            End If
            If Btnadd.CommandName = "UPDATE" Then
                EL.Id = ViewState("Id")
                dt = BL.GetDuplicateBuyerMaster(EL)
                If dt.Rows.Count > 0 Then
                    msginfo.Visible = True
                    msginfo.Text = "Data Already Exists"
                    'lblmsg.Text = ""
                    'clear()
                    Exit Sub
                End If
                BL.UpdateRecord(EL)
                Btnview.Text = "VIEW"
                Btnadd.Text = "ADD"
                Btnview.CommandName = "VIEW"
                Btnadd.CommandName = "ADD"
                display()
                lblmsg.Text = "Data Updated Successfully"
                msginfo.Text = ""
                clear()
            Else
                Btnadd.CommandName = "ADD"
                EL.Fname = txtFName.Text
                EL.Lname = txtLname.Text
                EL.BuyerCode = txtBuyerCode.Text
                EL.Photo = ViewState("ImageTime")
                EL.Tin = txtTIN.Text
                EL.CST_NO = txtCSTNo.Text
                EL.PAN_NO = txtPAN.Text
                EL.Contact_Number1 = txtContactNo1.Text
                EL.Contact_Number2 = txtContactNo2.Text
                EL.Email1 = txtEmail1.Text
                EL.Email2 = txtEmail2.Text
                EL.Fax_NO = txtFaxNo.Text
                EL.Contact_Person = txtContactPerson.Text
                EL.Introducer = txtIntro.Text
                EL.Off_Address = txtAddress.Text
                EL.Res_Address = txtAddr.Text
                EL.Off_City = txtCity.Text
                EL.Res_City = txtcity1.Text
                EL.Off_District = txtDistrict.Text
                EL.Res_District = txtDistrict1.Text
                EL.Off_State = ddlState.SelectedValue
                EL.Res_State = ddlState1.SelectedValue
                EL.Off_Country = ddlCountry.SelectedValue
                EL.Res_Country = ddlCountry1.SelectedValue
                EL.Bank_Name = txtBankName.Text
                EL.Account_Number = txtAccountNo.Text
                EL.Bank_Branch = txtBankBranch.Text
                EL.Type_Of_Account = ddlType.SelectedValue
                EL.IFSC_Code = txtIFSC.Text
                If ViewState("ImageTime") = Nothing Then
                    EL.Photo = ""
                Else
                    EL.Photo = ViewState("ImageTime")
                End If
                dt = BL.GetDuplicateBuyerMaster(EL)
                If dt.Rows.Count > 0 Then
                    msginfo.Visible = True
                    msginfo.Text = "Data Already Exists"
                    'lblmsg.Text = ""
                    'clear()
                    Exit Sub
                End If
                Dim i As New Integer
                i = DL_BuyerMaster.Insert(EL)
                EL.Id = 0
                display()
                msginfo.Text = ""
                lblmsg.Text = "Data Saved Successfully"
                ViewState("dispId ") = CStr(i) + "," + ViewState("dispId ")
                clear()
            End If
        End If
    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnview.Click
        LinkButton1.Focus()
        msginfo.Text = ""

        If Btnview.Text <> "BACK" Then
            lblmsg.Text = ""

            ViewState("PageIndex") = 0
            GVBuyerMaster.PageIndex = 0
            display()
            GVBuyerMaster.Visible = True
        Else
            lblmsg.Text = ""
            msginfo.Text = ""
            GVBuyerMaster.Enabled = True
            GVBuyerMaster.PageIndex = ViewState("PageIndex")
            clear()
            Btnview.Text = "VIEW"
            Btnadd.Text = "ADD"
            display()
        End If
    End Sub
    Sub display()
        If txtFName.Text = "" Then
            EL.Fname = "0"
        Else
            EL.Fname = txtFName.Text
        End If
        If txtBuyerCode.Text = "" Then
            EL.BuyerCode = "0"
        Else
            EL.BuyerCode = txtBuyerCode.Text
        End If

        dt = BL.GridviewDetails(EL)
        If dt.Rows.Count <> 0 Then
            GVBuyerMaster.DataSource = dt

           
            GVBuyerMaster.DataBind()
            GVBuyerMaster.Visible = True
            GVBuyerMaster.Enabled = True
            
            For Each rows As GridViewRow In GVBuyerMaster.Rows
                If CType(rows.FindControl("LabelEmp_Photo"), Image).ImageUrl = "" Then
                    CType(rows.FindControl("LabelEmp_Photo"), Image).ImageUrl = "~/Images/imageupload1.gif"
                End If
            Next
            For Each rows As GridViewRow In GVBuyerMaster.Rows
                Dim x As String = CType(rows.FindControl("lblResCountry"), Label).Text
                If CType(rows.FindControl("lblResCountry"), Label).Text = "Select" Then
                    CType(rows.FindControl("lblResCountry"), Label).Text = ""
                End If
            Next
        Else
            lblmsg.Text = ""
            GVBuyerMaster.Visible = False
            msginfo.Text = "No Records to DIsplay"
        End If
    End Sub
    Sub clear()
        txtFName.Text = ""
        txtLname.Text = ""
        txtBuyerCode.Text = ""
        txtTIN.Text = ""
        txtCSTNo.Text = ""
        txtPAN.Text = ""
        Image3.ImageUrl = "~\Images\imageupload.gif"
        txtContactNo1.Text = ""
        txtContactNo2.Text = ""
        txtEmail1.Text = ""
        txtEmail2.Text = ""
        txtFaxNo.Text = ""
        txtContactPerson.Text = ""
        txtIntro.Text = ""
        txtAddr.Text = ""
        txtAddress.Text = ""
        txtCity.Text = ""
        txtcity1.Text = ""
        txtDistrict.Text = ""
        txtDistrict1.Text = ""
        txtBankBranch.Text = ""
        txtBankName.Text = ""
        ddlState.SelectedValue = 0
        ddlState1.SelectedValue = 0
        ddlCountry.SelectedValue = 0
        ddlCountry1.SelectedValue = 0
        txtAccountNo.Text = ""
        ddlType.SelectedValue = 0
        txtIFSC.Text = ""
    End Sub
    Protected Sub GVBuyerMaster_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVBuyerMaster.PageIndexChanging
        GVBuyerMaster.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVBuyerMaster.PageIndex
        display()
        Dim dt As New DataTable
        dt = BL.GridviewDetails(EL)
        GVBuyerMaster.DataSource = dt
        GVBuyerMaster.Visible = True
        GVBuyerMaster.DataBind()
    End Sub
    Protected Sub GVBuyerMaster_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVBuyerMaster.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        lblmsg.Text = ""
        msginfo.Text = ""
        txtFName.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblFirstName"), Label).Text
        txtLname.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblLastName"), Label).Text
        txtBuyerCode.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblBuyerCode"), Label).Text
        txtTIN.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblTin"), Label).Text
        txtCSTNo.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblCst"), Label).Text
        txtPAN.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblPan"), Label).Text
        txtContactNo1.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblContact1"), Label).Text
        txtContactNo2.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblContact2"), Label).Text
        txtIntro.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblIntro"), Label).Text
        txtContactPerson.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("ContactPerson2"), Label).Text
        txtEmail1.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblEmail1"), Label).Text
        txtEmail2.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblEmail2"), Label).Text
        txtAddress.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblAddress"), Label).Text
        txtCity.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblCity"), Label).Text
        ddlCountry.SelectedValue = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblCID1"), Label).Text
        ddlCountry1.SelectedValue = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblCID2"), Label).Text
        ddlState.Items.Clear()
        ddlState.DataSourceID = "ObjState"
        ddlState.DataBind()
        Dim x As Integer = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblStateId"), HiddenField).Value
        ddlState.SelectedValue = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblStateId"), HiddenField).Value

        ddlState1.Items.Clear()
        ddlState1.DataSourceID = "ObjState1"
        ddlState1.DataBind()
        Dim y As Integer = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblStateId2"), HiddenField).Value
        ddlState1.SelectedValue = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblStateId2"), HiddenField).Value

        txtAddr.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblResAddr"), Label).Text
        txtcity1.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblResCity"), Label).Text
        txtDistrict.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblDistrict"), Label).Text
        txtDistrict1.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblResDistrict"), Label).Text

        txtFaxNo.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblFaxNo"), Label).Text
        txtBankName.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblBankName"), Label).Text
        txtBankBranch.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblBankBranch"), Label).Text

        ViewState("ImageTime") = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("LabelPhotos"), Label).Text.Trim
        Image3.ImageUrl = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("LabelPhotos"), Label).Text.Trim
        txtAccountNo.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblAccNo"), Label).Text
        txtIFSC.Text = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblIFSC"), Label).Text
        ddlType.SelectedValue = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("lblTypeOfAccount"), Label).Text
        ViewState("Id") = CType(GVBuyerMaster.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
        Btnadd.Text = "UPDATE"
        Btnadd.CommandName = "UPDATE"
        EL.Id = ViewState("Id")

        EL.BuyerCode = txtBuyerCode.Text
        EL.Fname = txtFName.Text
        dt = BL.GridviewDetails(EL)
        GVBuyerMaster.DataSource = dt
        GVBuyerMaster.DataBind()
        e.Cancel = True
        GVBuyerMaster.Enabled = False
        Btnview.Text = "BACK"
        Btnview.CommandName = "BACK"
        Btnview.Visible = True
    End Sub
    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        If FileUpload1.FileName <> "" Then
            If FileUpload1.PostedFile.ContentLength <= 30000 Then
                Try
                    If ViewState("ImageTime") <> Nothing Then
                        'Dim Foto As String = Replace(ViewState("ImageTime"), "~/", "")
                        Dim Foto As String = Session("Path") + ViewState("ImageTime").ToString.Replace("~/", "")
                        If IO.File.Exists(Foto) Then
                            IO.File.Delete(Foto)
                        End If
                    End If
                    lblmsg.Text = ""
                    msginfo.Text = ""
                    path = "E" & txtBuyerCode.Text.Trim.ToString().Replace(" ", "") + TimeOfDay.ToString().Replace("/", "").Replace(":", "") & ".jpg"
                    If (FileUpload1.PostedFile.ContentType.ToLower() = "image/gif" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/jpeg" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/tiff" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/pjpeg" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/x-png" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/jpg" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/tif" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/bmp") Then


                        'path = (Server.MapPath("Images/") + Convert.ToString(Guid.NewGuid()) + FileUpload1.FileName)
                        'FileUpload1.SaveAs(path)
                        Me.FileUpload1.SaveAs(Server.MapPath("~/Images/" & path))
                        path1 = "~/Images/" & path
                        ViewState("ImageTime") = "~/Images/" & path
                        txtPath.Text = path1
                        Me.Image3.ImageUrl = txtPath.Text
                    Else
                        msginfo.Text = "Photo format should be gif/jpeg/jpg/pjpeg/bmp/x-png/tif/tiff ."
                    End If
                Catch ex As Exception
                    lblmsg.Text = ""
                    msginfo.Text = "Error while Uploading Image. Please refresh the page and try once again."
                End Try
            Else
                msginfo.Text = "Photo Size should be less than or equal to 30 KB."
                lblmsg.Text = ""
            End If
        Else
            msginfo.Text = "Browse to upload the photo."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub GVBuyerMaster_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVBuyerMaster.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Id") = CType(GVBuyerMaster.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            EL.Id = ViewState("Id")
            BL.DeleteRecord(EL.Id)
            lblmsg.Text = ""
            GVBuyerMaster.Visible = False
            GVBuyerMaster.Enabled = False
            GVBuyerMaster.PageIndex = ViewState("PageIndex")
            msginfo.Text = ""
            lblmsg.Text = "Data Deleted Successfully"
        End If
    End Sub
    Protected Sub GVBuyerMaster_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVBuyerMaster.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        EL.Id = 0
        EL.Fname = txtFName.Text
        EL.BuyerCode = txtBuyerCode.Text
        dt = BL.GridviewDetails(EL)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVBuyerMaster.DataSource = sortedView
        GVBuyerMaster.DataBind()
        GVBuyerMaster.Visible = True
        GVBuyerMaster.Enabled = True
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
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
