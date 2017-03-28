
Partial Class FrmAssetDetails
    Inherits BasePage
    '  Dim Sql As String
    Dim bl As New AssetDetailsB
    Dim dl As New AssetDetailsDB
    Dim AD As New AssetDetails
    Dim dt, dt1 As New DataTable
    Dim GlobalFunction As New GlobalFunction
    Dim path, path1 As String
    Sub Splitter(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("EmpCode") = parts(0).ToString()
            HidsEId.Value = parts(0).ToString()
            HidECode.Value = parts(1).ToString()
            txtreceivedby.Text = parts(2).ToString()

        Else
            txtreceivedby.AutoPostBack = True
        End If
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If btnAdd.Text = "UPDATE" Then
                    ddlYear.Enabled = False
                    AssetDep.Enabled = False
                    AD.AssetName = txtassetname.Text
                    AD.AssetType = ddlassetType.SelectedValue
                    AD.Bookvalueprice = txtbookvalue.Text
                    AD.AssetCode = txtassetcode.Text
                    AD.supplier = ddlsupplier.SelectedValue

                    If txtreceivedby.Text = "" Then
                        AD.Receivedby = 0
                    Else
                        AD.Receivedby = HidsEId.Value
                    End If
                    AD.Manufacturer = ddlmanufacturer.SelectedValue
                    If DDLDeptType.SelectedValue = 0 Then
                        AD.Location = 0
                    Else
                        AD.Location = DDLDeptType.SelectedValue
                    End If

                    AD.Machineslno = txtMachineSerialNo.Text
                    AD.Paymentmethod = ddlpaymentmethod.SelectedValue
                    AD.Motorslno = txtMachineSerialNo.Text
                    If txtpurDate.Text = "" Then
                        AD.purchasedate = "1/1/1900"
                    Else
                        AD.purchasedate = txtpurDate.Text
                    End If
                    AD.Modelno = txtModelNo.Text
                    AD.Billtype = ddlbilltype.SelectedValue
                    AD.invoiceno = txtInvNo.Text
                    If txtinvoiceNo.Text = "" Then
                        AD.Invvalue = 0
                    Else
                        AD.Invvalue = txtinvoiceNo.Text
                    End If
                    AD.broughtby = txtbroughtby.Text
                    If txtamtpaid.Text = "" Then
                        AD.amountpaid = 0
                    Else
                        AD.amountpaid = txtamtpaid.Text
                    End If
                    AD.Description = txtdescription.Text
                    If txtqty.Text = "" Then
                        AD.Quantity = 1
                    Else
                        AD.Quantity = txtqty.Text
                    End If
                    AD.sentby = txtsentby.Text

                    AD.InsuredTo = txtInsuredTo.Text

                    If txtInsuredAmt.Text = "" Then
                        AD.InsuredAmt = 0
                    Else
                        AD.InsuredAmt = txtInsuredAmt.Text
                    End If
                    If TxtPremiumAmt.Text = "" Then
                        AD.PremiumAmt = 0
                    Else
                        AD.PremiumAmt = TxtPremiumAmt.Text
                    End If
                    If TxtDueDate.Text = "" Then
                        AD.DueDate = "1/1/9100"
                    Else
                        AD.DueDate = TxtDueDate.Text
                    End If
                    If TxtPaidAmt.Text = "" Then
                        AD.Insuranceamtpaid = 0
                    Else
                        AD.Insuranceamtpaid = TxtPaidAmt.Text
                    End If
                    AD.Warranty = ddlWarranty.SelectedValue
                    If txtWP.Text = "" Then
                        AD.Warrantyp = 0
                    Else
                        AD.Warrantyp = txtWP.Text
                    End If

                    AD.Guaranty = ddlguaranty.SelectedValue
                    If txtGp.Text = "" Then
                        AD.Guarantyp = 0
                    Else
                        AD.Guarantyp = txtGp.Text
                    End If

                    AD.AMC_To = txtAMCTo.Text
                    If txtStartDate.Text = "" Then
                        AD.AMC_SDate = "1/1/9100"
                    Else
                        AD.AMC_SDate = txtStartDate.Text
                    End If
                    If txtEndDate.Text = "" Then
                        AD.AMC_EDate = "1/1/9100"
                    Else
                        AD.AMC_EDate = txtEndDate.Text
                    End If
                    If txtPaid.Text = "" Then
                        AD.PremiumPaidDate = "1/1/9100"
                    Else
                        AD.PremiumPaidDate = txtPaid.Text
                    End If
                    If txtAMCAmount.Text = "" Then
                        AD.AMC_Amount = 0
                    Else
                        AD.AMC_Amount = txtAMCAmount.Text
                    End If
                    If ViewState("ImageTime") = Nothing Then
                        AD.APhoto = ""
                    Else
                        AD.APhoto = ViewState("ImageTime")

                    End If
                    AD.DesType = ddlDereciationRate.SelectedValue
                    If ddlDereciationRate.SelectedValue = 0 Then
                        AD.DesType = 0
                    Else
                        AD.DepreciationType = ddlDepreciationrate1.SelectedValue
                    End If
                    AD.RegistrationNo = txtVRegNum.Text
                    If txtYearRegis.Text = "" Then
                        AD.Registrationdate = "1/1/1900"
                    Else
                        AD.Registrationdate = txtYearRegis.Text
                    End If
                    If CDate(IIf(txtStartDate.Text <> "", txtStartDate.Text, "1/1/1900")) > CDate(IIf(txtEndDate.Text <> "", txtEndDate.Text, "1/1/9100")) Then
                        lblErrorMsg.Text = "AMC End Date cannot be lesser than AMC Start Date."
                        lblmsg.Text = ""
                        Exit Sub
                    End If
                    If txtStartDate.Text <> "" And txtpurDate.Text <> "" Then
                        If CDate(IIf(txtStartDate.Text <> "", txtStartDate.Text, "1/1/1900")) < CDate(IIf(txtpurDate.Text <> "", txtpurDate.Text, "1/1/9100")) Then
                            lblErrorMsg.Text = "AMC Start Date cannot be lesser than Purchase Date."
                            lblmsg.Text = ""
                            Exit Sub
                        End If
                    End If
                    If txtStartDate.Text <> "" And txtPaid.Text <> "" Then
                        If CDate(IIf(txtStartDate.Text <> "", txtStartDate.Text, "1/1/1900")) < CDate(IIf(txtPaid.Text <> "", txtPaid.Text, "1/1/9100")) Then
                            lblErrorMsg.Text = "AMC Start Date cannot be lesser than Premium Paid Date."
                            lblmsg.Text = ""
                            Exit Sub
                        End If
                    End If
                    If txtStartDate.Text <> "" And txtPaid.Text <> "" Then
                        If CDate(IIf(txtpurDate.Text <> "", txtpurDate.Text, "1/1/1900")) > CDate(IIf(TxtDueDate.Text <> "", TxtDueDate.Text, "1/1/9100")) Then
                            lblErrorMsg.Text = "Due Date cannot be lesser than Purchase Date."
                            lblmsg.Text = ""
                            Exit Sub
                        End If
                    End If
                    If txtpurDate.Text <> "" And txtPaid.Text <> "" Then
                        If CDate(IIf(txtpurDate.Text <> "", txtpurDate.Text, "1/1/1900")) > CDate(IIf(txtPaid.Text <> "", txtPaid.Text, "1/1/9100")) Then
                            lblErrorMsg.Text = "Premium Paid Date cannot be lesser than Purchase Date."
                            lblmsg.Text = ""
                            Exit Sub
                        End If
                    End If
                    'If txtgrnno.Text = "" Then
                    '    AD.Grnno = 0
                    'Else
                    AD.Grnno = txtgrnno.Text
                    'End If
                    'If txtmrnno.Text = "" Then
                    '    AD.Mrnno = 0
                    'Else
                    AD.Mrnno = txtmrnno.Text
                    'End If
                    If ddlassetstat.SelectedValue = 0 Then
                        ddlassetstat.SelectedValue = 0
                    Else
                        AD.Assetstatus = ddlassetstat.SelectedValue
                    End If
                    If txtinvoicedate.Text = "" Then
                        AD.invoicedate = "1/1/9100"
                    Else
                        AD.invoicedate = txtinvoicedate.Text
                    End If
                    AD.Po = txtpo.Text
                    AD.Id = ViewState("AssetDet_Id")
                    dt = bl.GetDuplicateAssetDetails(AD)
                    If dt.Rows.Count > 0 Then
                        lblErrorMsg.Text = "Data already exists."
                    Else
                        bl.UpdateRecord(AD)
                        btnAdd.Text = "ADD"
                        GridView1.Visible = True
                        btnView.Text = "VIEW"
                        clear()
                        lblmsg.Text = "Data Updated Successfully."
                        lblErrorMsg.Text = ""
                        DispGrid()
                    End If

                ElseIf btnAdd.Text = "ADD" Then
                    AD.AssetName = txtassetname.Text
                    AD.AssetType = ddlassetType.SelectedValue
                    AD.Bookvalueprice = txtbookvalue.Text
                    AD.AssetCode = txtassetcode.Text
                    AD.supplier = ddlsupplier.SelectedValue

                    If txtreceivedby.Text = "" Then
                        AD.Receivedby = 0
                    Else
                        AD.Receivedby = HidsEId.Value
                    End If
                    AD.Manufacturer = ddlmanufacturer.SelectedValue
                    If DDLDeptType.SelectedValue = 0 Then
                        AD.Location = 0
                    Else
                        AD.Location = DDLDeptType.SelectedValue
                    End If
                    AD.Machineslno = txtMachineSerialNo.Text
                    AD.Paymentmethod = ddlpaymentmethod.SelectedValue
                    AD.Motorslno = txtMachineSerialNo.Text

                    If txtpurDate.Text = "" Then
                        AD.purchasedate = "1/1/1900"
                    Else
                        AD.purchasedate = txtpurDate.Text
                    End If

                    AD.Modelno = txtModelNo.Text
                    AD.Billtype = ddlbilltype.SelectedValue
                    AD.invoiceno = txtInvNo.Text
                    If txtinvoiceNo.Text = "" Then
                        AD.Invvalue = 0
                    Else
                        AD.Invvalue = txtinvoiceNo.Text
                    End If

                    AD.broughtby = txtbroughtby.Text
                    If txtamtpaid.Text = "" Then
                        AD.amountpaid = 0
                    Else
                        AD.amountpaid = txtamtpaid.Text
                    End If
                    AD.Description = txtdescription.Text
                    If txtqty.Text = "" Then
                        AD.Quantity = 1
                    Else
                        AD.Quantity = txtqty.Text
                    End If
                    AD.sentby = txtsentby.Text
                    AD.InsuredTo = txtInsuredTo.Text
                    If txtInsuredAmt.Text = "" Then
                        AD.InsuredAmt = 0
                    Else
                        AD.InsuredAmt = txtInsuredAmt.Text
                    End If
                    If TxtPremiumAmt.Text = "" Then
                        AD.PremiumAmt = 0
                    Else
                        AD.PremiumAmt = TxtPremiumAmt.Text
                    End If
                    If TxtDueDate.Text = "" Then
                        AD.DueDate = "1/1/9100"
                    Else
                        AD.DueDate = TxtDueDate.Text
                    End If
                    If TxtPaidAmt.Text = "" Then
                        AD.Insuranceamtpaid = 0
                    Else
                        AD.Insuranceamtpaid = TxtPaidAmt.Text
                    End If
                    AD.Id = 0
                    AD.Warranty = ddlWarranty.SelectedValue
                    AD.RegistrationNo = txtVRegNum.Text
                    If txtYearRegis.Text = "" Then
                        AD.Registrationdate = "1/1/1900"
                    Else
                        AD.Registrationdate = txtYearRegis.Text
                    End If

                    If txtWP.Text = "" Then
                        AD.Warrantyp = 0
                    Else
                        AD.Warrantyp = txtWP.Text
                    End If

                    AD.Guaranty = ddlguaranty.SelectedValue

                    If txtGp.Text = "" Then
                        AD.Guarantyp = 0
                    Else
                        AD.Guarantyp = txtGp.Text
                    End If

                    AD.AMC_To = txtAMCTo.Text
                    If txtStartDate.Text = "" Then
                        AD.AMC_SDate = "1/1/9100"
                    Else
                        AD.AMC_SDate = txtStartDate.Text
                    End If
                    If txtEndDate.Text = "" Then
                        AD.AMC_EDate = "1/1/9100"
                    Else
                        AD.AMC_EDate = txtEndDate.Text
                    End If
                    If txtPaid.Text = "" Then
                        AD.PremiumPaidDate = "1/1/9100"
                    Else
                        AD.PremiumPaidDate = txtPaid.Text
                    End If
                    If txtAMCAmount.Text = "" Then
                        AD.AMC_Amount = 0
                    Else
                        AD.AMC_Amount = txtAMCAmount.Text
                    End If
                    If ViewState("ImageTime") = Nothing Then
                        AD.APhoto = ""
                    Else
                        AD.APhoto = ViewState("ImageTime")
                    End If
                    AD.DesType = ddlDereciationRate.SelectedValue
                    If ddlDereciationRate.SelectedValue = 0 Then
                        AD.DesType = 0
                    Else
                        AD.DepreciationType = ddlDepreciationrate1.SelectedValue
                    End If
                    If CDate(IIf(txtStartDate.Text <> "", txtStartDate.Text, "1/1/1900")) > CDate(IIf(txtEndDate.Text <> "", txtEndDate.Text, "1/1/9100")) Then
                        lblErrorMsg.Text = "AMC End Date cannot be lesser than AMC Start Date."
                        lblmsg.Text = ""
                        Exit Sub
                    End If
                    If txtStartDate.Text <> "" And txtpurDate.Text <> "" Then
                        If CDate(IIf(txtStartDate.Text <> "", txtStartDate.Text, "1/1/1900")) < CDate(IIf(txtpurDate.Text <> "", txtpurDate.Text, "1/1/9100")) Then
                            lblErrorMsg.Text = "AMC Start Date cannot be lesser than Purchase Date."
                            lblmsg.Text = ""
                            Exit Sub
                        End If
                    End If
                    If txtStartDate.Text <> "" And txtPaid.Text <> "" Then
                        If CDate(IIf(txtStartDate.Text <> "", txtStartDate.Text, "1/1/1900")) < CDate(IIf(txtPaid.Text <> "", txtPaid.Text, "1/1/9100")) Then
                            lblErrorMsg.Text = "AMC Start Date cannot be lesser than Premium Paid Date."
                            lblmsg.Text = ""
                            Exit Sub
                        End If
                    End If
                    If txtStartDate.Text <> "" And txtPaid.Text <> "" Then
                        If CDate(IIf(txtpurDate.Text <> "", txtpurDate.Text, "1/1/1900")) > CDate(IIf(TxtDueDate.Text <> "", TxtDueDate.Text, "1/1/9100")) Then
                            lblErrorMsg.Text = "Due Date cannot be lesser than Purchase Date."
                            lblmsg.Text = ""
                            Exit Sub
                        End If
                    End If
                    If txtpurDate.Text <> "" And txtPaid.Text <> "" Then
                        If CDate(IIf(txtpurDate.Text <> "", txtpurDate.Text, "1/1/1900")) > CDate(IIf(txtPaid.Text <> "", txtPaid.Text, "1/1/9100")) Then
                            lblErrorMsg.Text = "Premium Paid Date cannot be lesser than Purchase Date."
                            lblmsg.Text = ""
                            Exit Sub
                        End If
                    End If
                    'If txtgrnno.Text = "" Then
                    '    AD.Grnno = 0
                    'Else
                    AD.Grnno = txtgrnno.Text
                    'End If
                    'If txtmrnno.Text = "" Then
                    '    AD.Mrnno = 0
                    'Else
                    AD.Mrnno = txtmrnno.Text
                    'End If
                    If ddlassetstat.SelectedValue = 0 Then
                        ddlassetstat.SelectedValue = 0
                    Else
                        AD.Assetstatus = ddlassetstat.SelectedValue
                    End If
                    If txtinvoicedate.Text = "" Then
                        AD.invoicedate = "1/1/9100"
                    Else
                        AD.invoicedate = txtinvoicedate.Text
                    End If
                    AD.Po = txtpo.Text
                    dt = bl.GetDuplicateAssetDetails(AD)
                    If dt.Rows.Count > 0 Then
                        lblErrorMsg.Text = "Data already exists."
                        lblmsg.Text = ""
                    Else
                        bl.InsertRecord(AD)

                        lblmsg.Text = "Data Saved Successfully."
                        lblErrorMsg.Text = ""
                        DispGrid()
                        clear()
                    End If

                End If
            Catch ex As Exception
                lblErrorMsg.Text = "Date is Not Valid."
            End Try
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add/Update data."
            lblmsg.Text = ""
        End If
        ddlassetType.Focus()
    End Sub
    Protected Sub Upload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Upload.Click
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
                    lblErrorMsg.Text = ""
                    path = "E" & txtassetcode.Text.Trim.ToString().Replace(" ", "") + TimeOfDay.ToString().Replace("/", "").Replace(":", "") & ".jpg"
                    If (FileUpload1.PostedFile.ContentType.ToLower() = "image/gif" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/jpeg" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/tiff" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/pjpeg" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/x-png" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/jpg" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/tif" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/bmp") Then


                        'path = (Server.MapPath("Images/") + Convert.ToString(Guid.NewGuid()) + FileUpload1.FileName)
                        'FileUpload1.SaveAs(path)
                        Me.FileUpload1.SaveAs(Server.MapPath("~/Images/" & path))
                        path1 = "~/Images/" & path
                        ViewState("ImageTime") = "~/Images/" & path
                        txtpath.Text = path1
                        Me.ImageMap1.ImageUrl = txtpath.Text
                    Else
                        lblErrorMsg.Text = "Photo format should be gif/jpeg/jpg/pjpeg/bmp/x-png/tif/tiff ."
                    End If
                Catch ex As Exception
                    lblmsg.Text = ""
                    lblErrorMsg.Text = "Error while Uploading Image. Please refresh the page and try once again."
                End Try
            Else
                lblErrorMsg.Text = "Photo Size should be less than or equal to 30 KB."
                lblmsg.Text = ""
            End If
        Else
            lblErrorMsg.Text = "Browse to upload the photo."
            lblmsg.Text = ""
        End If
    End Sub
    Sub clear()
        txtpo.Text = ""
        txtgrnno.Text = ""
        txtmrnno.Text = ""
        txtinvoicedate.Text = ""
        txtassetname.Text = ""
        'ddlassetType.ClearSelection()
        'ddldepreciationrate.ClearSelection()
        txtbookvalue.Text = " "
        txtassetcode.Text = ""
        'ddlsupplier.ClearSelection()
        txtreceivedby.Text = ""
        'ddlmanufacturer.ClearSelection()
        'txtlocation.Text = ""
        txtMachineSerialNo.Text = ""
        'ddlpaymentmethod.ClearSelection()
        txtMachineSerialNo.Text = ""
        txtpurDate.Text = ""
        txtModelNo.Text = ""
        'ddlbilltype.ClearSelection()
        txtInvNo.Text = ""
        txtbroughtby.Text = ""
        txtamtpaid.Text = ""
        txtdescription.Text = ""
        'txtqty.Text = ""
        txtsentby.Text = ""
        txtInsuredTo.Text = ""
        txtInsuredAmt.Text = ""
        TxtPremiumAmt.Text = ""
        TxtDueDate.Text = ""
        TxtPaidAmt.Text = ""
        txtGp.Text = ""
        txtWP.Text = ""
        txtAMCAmount.Text = ""
        txtAMCTo.Text = ""
        txtStartDate.Text = ""
        txtEndDate.Text = ""
        ImageMap1.ImageUrl = "~\Images\imageupload.gif"
        txtinvoiceNo.Text = ""
        ViewState("ImageTime") = ""
        txtpath.Text = ""
        ddlDepreciationrate1.ClearSelection()
        txtPaid.Text = ""
        txtYearRegis.Text = ""
        txtVRegNum.Text = ""
    End Sub
    Sub DispGrid()
        Dim dt As New DataTable
        AD.AssetDet_Id = 0
        '  el.AssetType_ID = 0
        If ddlassetType.SelectedValue = "0" Then
            AD.AssetType = 0
        Else
            AD.AssetType = ddlassetType.SelectedValue
        End If
        If txtassetname.Text = "" Then
            AD.AssetName = 0
        Else
            AD.AssetName = txtassetname.Text
        End If
        If txtreceivedby.Text = "" Then
            AD.Receivedby = 0
        Else
            AD.Receivedby = HidsEId.Value
        End If
        If txtpurDate.Text = "" Then
            AD.purchasedate = "01/01/1900"
        Else
            AD.purchasedate = CDate(txtpurDate.Text)

        End If
        GridView1.Enabled = True
        dt = bl.GetAssetDetails(AD)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            LinkButton1.Focus()
            'For Each grid As GridViewRow In GridView1.Rows
            '    If CType(grid.FindControl("lbl13"), Label).Text = "01-Jan-1900" Then
            '        CType(grid.FindControl("lbl13"), Label).Text = ""
            '    End If
            '    If CType(grid.FindControl("lbl25"), Label).Text = "01-Jan-1900" Then
            '        CType(grid.FindControl("lbl25"), Label).Text = ""
            '    End If
            'Next
        Else
            lblmsg.Text = ""
            lblErrorMsg.Text = "No records to display."
            GridView1.Visible = False
        End If
    End Sub
    Protected Sub AutoCompleteExtender1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender1.PreRender
        Dim str1 As String
        Try
            If txtreceivedby.Text <> "" Then
                str1 = GlobalFunction.IdCutter(txtreceivedby.Text)
            End If
        Catch
            txtreceivedby.Text = "Not a valid option.Try again."
            txtreceivedby.ForeColor = Drawing.Color.Red
        End Try
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If btnView.Text = "VIEW" Then
            lblmsg.Text = ""
            lblErrorMsg.Text = ""
            DispGrid()
        ElseIf btnView.Text = "BACK" Then
            ddlYear.Enabled = False
            AssetDep.Enabled = False
            btnAdd.Text = "ADD"
            btnView.Text = "VIEW"
            lblmsg.Text = ""
            lblErrorMsg.Text = ""
            clear()
            DispGrid()
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        DispGrid()
        GridView1.Visible = True
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim Photo As String = Session("Path") + CType(GridView1.Rows(e.RowIndex).FindControl("LabelEmp_Photo"), Image).ImageUrl.Replace("~/", "")
            If IO.File.Exists(Photo) Then
                IO.File.Delete(Photo)
            End If
            bl.ChangeFlag(CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("RAD"), HiddenField).Value)
            GridView1.DataBind()
            lblErrorMsg.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            Dim dt As New DataTable
            AD.AssetDet_Id = 0
            '  el.AssetType_ID = 0
            If ddlassetType.SelectedValue = "0" Then
                AD.AssetType = 0
            Else
                AD.AssetType = ddlassetType.SelectedValue
            End If
            If txtassetname.Text = "" Then
                AD.AssetName = 0
            Else
                AD.AssetName = txtassetname.Text
            End If
            If txtreceivedby.Text = "" Then
                AD.Receivedby = 0
            Else
                AD.Receivedby = HidsEId.Value
            End If
            If txtpurDate.Text = "" Then
                AD.purchasedate = "01/01/1900"
            Else
                AD.purchasedate = CDate(txtpurDate.Text)

            End If
            GridView1.Enabled = True
            dt = bl.GetAssetDetails(AD)
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            LinkButton1.Focus()
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        ddlYear.Enabled = True
        AssetDep.Enabled = True
        lblmsg.Text = ""
        lblErrorMsg.Text = ""
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        Dim dt As New DataTable
        btnAdd.Text = "UPDATE"
        btnView.Text = True
        btnView.Text = "BACK"
        GridView1.Visible = True
        ViewState("AssetDet_Id") = CType(GridView1.Rows(e.NewEditIndex).FindControl("RAD"), HiddenField).Value
        txtassetname.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl1"), Label).Text
        ddlassetType.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl2"), Label).Text
        'ddldepreciationrate.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl3"), Label).Text
        txtbookvalue.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl4"), Label).Text
        txtassetcode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl5"), Label).Text
        ddlsupplier.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl6"), Label).Text
        HidsEId.Value = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl7"), Label).Text
        txtreceivedby.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblEmpName"), Label).Text.Trim
        ddlmanufacturer.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl8"), Label).Text
        If DDLDeptType.SelectedValue = 0 Then
            CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl9"), Label).Text = 0
        Else
            DDLDeptType.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl9"), Label).Text
        End If


        txtMachineSerialNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl10"), Label).Text
        ddlpaymentmethod.Items.Clear()
        ddlpaymentmethod.DataSourceID = "cmbpaymentmethod"
        ddlpaymentmethod.DataBind()
        ddlpaymentmethod.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl11"), Label).Text
        txtpurDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl13"), Label).Text
        txtModelNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl14"), Label).Text
        ddlbilltype.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl15"), Label).Text
        txtInvNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl16"), Label).Text
        txtbroughtby.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl17"), Label).Text
        txtamtpaid.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl18"), Label).Text
        txtdescription.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl19"), Label).Text
        txtqty.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl20"), Label).Text
        txtsentby.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl21"), Label).Text
        txtInsuredTo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl22"), Label).Text.Trim
        txtInsuredAmt.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl23"), Label).Text
        TxtPremiumAmt.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl24"), Label).Text
        TxtDueDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl25"), Label).Text
        TxtPaidAmt.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl26"), Label).Text
        ddlguaranty.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblGurranty"), Label).Text
        txtGp.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblGurrantyPeriod"), Label).Text
        ddlWarranty.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblwarranty"), Label).Text
        txtWP.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblWarrantyPeriod"), Label).Text
        txtAMCTo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblAmcTo"), Label).Text
        txtStartDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblAMCStDate"), Label).Text
        txtEndDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblEndDate"), Label).Text
        txtAMCAmount.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("AmcAmount"), Label).Text
        'txtpath.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPhoto"), Label).Text
        ddlDepreciationrate1.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDepreciationrate"), Label).Text
        ImageMap1.ImageUrl = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPhoto1"), Label).Text
        txtinvoiceNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblINvValue"), Label).Text
        ViewState("ImageTime") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPhoto1"), Label).Text.Trim
        txtPaid.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPaid"), Label).Text
        ddlDereciationRate.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDesType"), Label).Text
        If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRegDate"), Label).Text = "01-Jan-1900" Then
            txtYearRegis.Text = ""
        Else
            txtYearRegis.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRegDate"), Label).Text
        End If
        txtVRegNum.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRegNo"), Label).Text
        txtgrnno.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblgrn"), Label).Text
        txtmrnno.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblmrn"), Label).Text
        If ddlassetstat.SelectedValue = 0 Then
            CType(GridView1.Rows(e.NewEditIndex).FindControl("lblasset"), Label).Text = 0
        Else
            ddlassetstat.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblasset"), Label).Text
        End If

        txtpo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblpo"), Label).Text
        txtinvoicedate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblinvoicedate"), Label).Text

        AD.AssetDet_Id = ViewState("AssetDet_Id")
        AD.AssetType = 0
        AD.AssetName = 0
        AD.Receivedby = 0
        AD.purchasedate = "01/01/1900"

        dt = bl.GetAssetDetails(AD)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = False

        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If

    End Sub


    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            ddlassetType.Focus()
            txtqty.Text = "1"
            ddlYear.Enabled = False
            AssetDep.Enabled = False
        End If
        If ImageMap1.ImageUrl = "" Then
            ImageMap1.ImageUrl = "~\Images\imageupload.gif"
        End If
        If txtreceivedby.Text <> "" Then
            Splitter(txtreceivedby.Text)
        Else
            txtreceivedby.AutoPostBack = True
            Splitter(txtreceivedby.Text)
        End If
    End Sub

    'Protected Sub ddlDepreciationrate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepreciationrate.SelectedIndexChanged
    '    AD.AssetType = ddlassetType.SelectedValue
    '    AD.DType = ddlDepreciationrate.SelectedValue
    '    If ddlDepreciationrate.SelectedValue = 0 Then
    '        txtDereciationRate.Text = ""
    '        ddlDepreciationrate.SelectedItem.Text = "Select"
    '    Else
    '        dt = bl.DType(AD)
    '        If dt.Rows.Count > 0 Then

    '            If dt.Rows(0).Item("Rate").ToString = "" Then
    '                txtDereciationRate.Text = 0
    '            Else
    '                txtDereciationRate.Text = Format(dt.Rows(0).Item("Rate"), "0.00")
    '            End If
    '        End If
    '    End If
    '    txtDereciationRate.Focus()
    'End Sub

    Protected Sub ddlassetType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlassetType.SelectedIndexChanged
        'txtDereciationRate.Text = ""
    End Sub

    Protected Sub ddlguaranty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlguaranty.SelectedIndexChanged
        If ddlguaranty.SelectedValue = "N" Then
            txtGp.Enabled = False
            txtGp.Text = ""
        Else
            txtGp.Enabled = True
        End If
    End Sub

    Protected Sub ddlWarranty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlWarranty.SelectedIndexChanged
        If ddlWarranty.SelectedValue = "N" Then
            txtWP.Enabled = False
            txtWP.Text = ""
        Else
            txtWP.Enabled = True
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

        Dim dt As New DataTable
        AD.AssetDet_Id = 0
        '  el.AssetType_ID = 0
        If ddlassetType.SelectedValue = "0" Then
            AD.AssetType = 0
        Else
            AD.AssetType = ddlassetType.SelectedValue
        End If
        If txtassetname.Text = "" Then
            AD.AssetName = 0
        Else
            AD.AssetName = txtassetname.Text
        End If
        If txtreceivedby.Text = "" Then
            AD.Receivedby = 0
        Else
            AD.Receivedby = HidsEId.Value
        End If
        If txtpurDate.Text = "" Then
            AD.purchasedate = "01/01/1900"
        Else
            AD.purchasedate = CDate(txtpurDate.Text)

        End If
        GridView1.Enabled = True
        dt = bl.GetAssetDetails(AD)

        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Visible = True
        LinkButton1.Focus()
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

    Protected Sub AssetDep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AssetDep.Click
        AD.DesType = ddlDereciationRate.SelectedValue
        AD.DepreciationType = ddlDepreciationrate1.SelectedValue
        AD.Id = ViewState("AssetDet_Id")
        AD.DepreciationYear = ddlYear.SelectedItem.Text
        Dim i As Integer = AssetDetailsDB.AssetDep(AD)
        If i > 0 Then
            lblmsg.Text = "Asset Depreciation is done."
            lblErrorMsg.Text = ""
        Else
            lblErrorMsg.Text = "Asset Depreciation cannot be done."
            lblmsg.Text = ""
        End If

    End Sub
End Class