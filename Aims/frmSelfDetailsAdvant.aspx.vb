Imports System.Net
Imports System.IO
Partial Class frmSelfDetailsAdvant
    Inherits BasePage
    Dim a As Integer
    Dim GlobalFunction As New GlobalFunction
    Dim idd As Integer
    Dim path, path1, PathDefault, PathDefault1, PathHeader, PathHeader1 As String
    Dim Prop As New SelfDetails
    Dim BLL As New SelfDetailsB
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("BranchCode") <> "000000000000" Then
            Response.Redirect("AccessDenied.aspx")
        Else
            If Not Page.IsPostBack Then
                txtCreationDate.Text = Format(Today, "dd-MMM-yyyy")
                ImageMap1.ImageUrl = "~\Images\imageupload.gif"
                ImageMapDefault.ImageUrl = "~\Images\Schoolmgmt.jpg"
                ImageMapHeader.ImageUrl = "~\Images\header.gif"
            End If
        End If
    End Sub
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                If txtAdminName.Text <> "" And txtAdminPass.Text <> "" And txtExpiryDate.Text <> "" Then
                    If btnadd.Text = "ADD" Then
                        Prop.Name = NameTextBox.Text
                        Prop.Address = txtaddress.Text
                        If cbHO.Checked Then
                            Prop.HoFlag = 1
                        Else
                            Prop.HoFlag = 0
                        End If
                        Prop.Registration = txtregNo.Text
                        Prop.Contactperson = txtContactPerson.Text
                        Prop.Contactno1 = txtContactNo1.Text
                        Prop.Contactno2 = txtContactNo2.Text
                        Prop.City = txtcity.Text
                        Prop.State = txtState.Text
                        Prop.Code = txtpinCode.Text
                        Prop.Country = txtCountry.Text
                        Prop.Fax = txtFax.Text
                        Prop.Email = txtEmail.Text
                        Prop.Website = txtWebsite.Text
                        If txtCreationDate.Text = "" Then
                            Prop.CreationDate = "1900-01-01"
                        Else
                            Prop.CreationDate = txtCreationDate.Text
                        End If
                        If ViewState("ImageTime") = "" Then
                            Prop.Logo = "~\Images\imageupload.gif"
                        Else
                            Prop.Logo = ViewState("ImageTime")
                        End If
                        If ViewState("ImageTimeDefault") = "" Then
                            Prop.logoDefault = "~\Images\Schoolmgmt.jpg"
                        Else
                            Prop.logoDefault = ViewState("ImageTimeDefault")
                        End If
                        If ViewState("ImageTimeHeader") = "" Then
                            Prop.logoHeader = "~\Images\header.gif"
                        Else
                            Prop.logoHeader = ViewState("ImageTimeHeader")
                        End If
                        Prop.HeaderColor = DDLColor.SelectedValue
                        Prop.Prefix = txtPrefix.Text
                        Prop.AdminName = txtAdminName.Text
                        Prop.AdminPassword = RijndaelSimple.Encrypt(txtAdminPass.Text.Trim, _
                                                  RijndaelSimple.passPhrase, _
                                                  RijndaelSimple.saltValue, _
                                                  RijndaelSimple.hashAlgorithm, _
                                                  RijndaelSimple.passwordIterations, _
                                                  RijndaelSimple.initVector, _
                                                  RijndaelSimple.keySize)
                        Prop.PasswordExpiryDate = txtExpiryDate.Text
                        Prop.Status = DDLStatus.SelectedValue

                        Dim check, Prefix As New DataTable
                        Dim typeName As String = NameTextBox.Text
                        check = BLL.CheckDuplicate(typeName)
                        Prefix = BLL.CheckPrefixDupli(txtPrefix.Text, 0)
                        If check.Rows.Count > 0 Then
                            lblmsg.Text = "Data already exists."
                            lblgreen.Text = ""
                        ElseIf Prefix.Rows.Count > 0 Then
                            lblmsg.Text = "'" + txtPrefix.Text + "'" + " Prefix is already used for " + Prefix.Rows(0)("MyCo_Name").ToString + " Institute."
                            lblgreen.Text = ""
                        Else
                            BLL.Insert(Prop)
                            If GlobalFunction.ErrorMsg <> "Error" Then
                                lblgreen.Text = "Data Saved Successfully."
                                lblmsg.Text = ""
                                Clear()
                                ViewState("PageIndex") = 0
                                GVSelfDet.PageIndex = 0
                                DispGrid()
                                txtCreationDate.Text = Format(Today, "dd-MMM-yyyy")
                            Else
                                lblgreen.Text = ""
                                lblmsg.Text = "Error occured while saving data please try again."
                            End If
                        End If
                    ElseIf btnadd.Text = "UPDATE" Then
                        Dim Prop As New SelfDetails
                        Dim BLL As New SelfDetailsB
                        Dim i As Int64 = CoIdTextBox.Text
                        Prop.Name = NameTextBox.Text
                        Prop.Address = txtaddress.Text
                        If cbHO.Checked Then
                            Prop.HoFlag = 1
                        Else
                            Prop.HoFlag = 0
                        End If
                        Prop.Registration = txtregNo.Text
                        Prop.Contactperson = txtContactPerson.Text
                        Prop.Contactno1 = txtContactNo1.Text
                        Prop.Contactno2 = txtContactNo2.Text
                        Prop.City = txtcity.Text
                        Prop.State = txtState.Text
                        Prop.Code = txtpinCode.Text
                        Prop.Country = txtCountry.Text
                        Prop.Fax = txtFax.Text
                        Prop.Email = txtEmail.Text
                        Prop.Website = txtWebsite.Text
                        Prop.CoId = CoIdTextBox.Text
                        If txtCreationDate.Text = "" Then
                            Prop.CreationDate = "1900-01-01"
                        Else
                            Prop.CreationDate = txtCreationDate.Text
                        End If

                        Dim check, Prefix As New DataTable
                        Dim typeName As String = NameTextBox.Text
                        If ViewState("ImageTime") = "" Then
                            Prop.Logo = "~\Images\imageupload.gif"
                        Else
                            Prop.Logo = ViewState("ImageTime")
                        End If
                        If ViewState("ImageTimeDefault") = "" Then
                            Prop.logoDefault = "~\Images\Schoolmgmt.jpg"
                        Else
                            Prop.logoDefault = ViewState("ImageTimeDefault")
                        End If
                        If ViewState("ImageTimeHeader") = "" Then
                            Prop.logoHeader = "~\Images\header.gif"
                        Else
                            Prop.logoHeader = ViewState("ImageTimeHeader")
                        End If
                        Prop.HeaderColor = DDLColor.SelectedValue
                        Prop.Prefix = txtPrefix.Text
                        Prop.AdminName = txtAdminName.Text
                        Prop.AdminPassword = RijndaelSimple.Encrypt(txtAdminPass.Text.Trim, _
                                                  RijndaelSimple.passPhrase, _
                                                  RijndaelSimple.saltValue, _
                                                  RijndaelSimple.hashAlgorithm, _
                                                  RijndaelSimple.passwordIterations, _
                                                  RijndaelSimple.initVector, _
                                                  RijndaelSimple.keySize)
                        Prop.PasswordExpiryDate = txtExpiryDate.Text
                        Prop.Status = DDLStatus.SelectedValue

                        check = BLL.CheckDuplicate(typeName)
                        Prefix = BLL.CheckPrefixDupli(txtPrefix.Text, i)
                        If check.Rows.Count > 1 Then
                            lblmsg.Text = "Data already exists."
                            lblgreen.Text = ""
                        ElseIf Prefix.Rows.Count > 0 Then
                            lblmsg.Text = "'" + txtPrefix.Text + "'" + " Prefix is already used for " + Prefix.Rows(0)("MyCo_Name").ToString + " Institute."
                            lblgreen.Text = ""
                        Else
                            BLL.UpdateAdvant(Prop)
                            If GlobalFunction.ErrorMsg <> "Error" Then
                                btnadd.Text = "ADD"
                                btnDetails.Text = "VIEW"
                                Clear()
                                GVSelfDet.PageIndex = ViewState("PageIndex")
                                DispGrid()
                                GVSelfDet.Enabled = "True"
                                lblgreen.Text = "Data Updated Successfully."
                                lblmsg.Text = ""
                                'txtPrefix.Enabled = True
                                txtAdminName.Enabled = True
                                txtAdminPass.Enabled = True
                                txtCreationDate.Text = Format(Today, "dd-MMM-yyyy")
                            Else
                                lblgreen.Text = ""
                                lblmsg.Text = "Error occured while saving data please try again."
                            End If
                        End If
                    End If
                Else
                    lblgreen.Text = ""
                    lblmsg.Text = "Please enter Username, Password and Expiry Date"
                End If
            Else
                lblgreen.Text = ""
                lblmsg.Text = "No Write Permission!"
            End If
        Else
            lblgreen.Text = ""
            lblmsg.Text = "No Write Permission!"
        End If
    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        lblmsg.Text = ""
        lblgreen.Text = ""
        a = GlobalFunction.UserPrivilage()
        If a = 1 Or a = 2 Or a = 3 Or a = 4 Then
            If btnDetails.Text = "VIEW" Then
                ViewState("PageIndex") = 0
                GVSelfDet.PageIndex = 0
                DispGrid()
            ElseIf btnDetails.Text = "BACK" Then
                btnadd.Text = "ADD"
                btnDetails.Text = "VIEW"
                GVSelfDet.Enabled = True
                'txtPrefix.Enabled = True
                txtAdminName.Enabled = True
                txtAdminPass.Enabled = True
                Clear()
                GVSelfDet.PageIndex = ViewState("PageIndex")
                DispGrid()
            End If
        Else
            lblgreen.Text = ""
            lblmsg.Text = "No Read Permission!"
        End If
    End Sub
    Sub DispGrid()
        Dim dt As New DataTable
        dt = selfdetailsDB.GetDeatilsByBranch(Trim(NameTextBox.Text), Trim(txtregNo.Text), Trim(txtEmail.Text), Trim(txtWebsite.Text))
        If dt.Rows.Count > 0 Then

            GVSelfDet.DataSource = dt
            GVSelfDet.DataBind()
            GVSelfDet.Visible = True
            GVSelfDet.Enabled = True
        Else
            GVSelfDet.Visible = False
            lblmsg.Text = "No records to display."
        End If
    End Sub
    Protected Sub GVSelfDet_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVSelfDet.PageIndexChanging
        lblgreen.Visible = False
        GVSelfDet.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVSelfDet.PageIndex
        DispGrid()
    End Sub
    Protected Sub GVSelfDet_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVSelfDet.RowDeleting
        Dim qrystring As String = "frmSelfDetailsTenantSel.aspx?" & "&InstID=" & CType(GVSelfDet.Rows(e.RowIndex).FindControl("lblInstCode"), Label).Text

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=950,height=650,left=40,top=20')</script>", False)
    End Sub
    Protected Sub GVSelfDet_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GVSelfDet.RowUpdating
        Dim InstCode As String = CType(GVSelfDet.Rows(e.RowIndex).FindControl("lblInstCode"), Label).Text
        BLL.DeleteBranchData(Trim(InstCode))
        lblgreen.Text = "Institute Data Deleted Successfully"
        lblmsg.Text = ""
        DispGrid()
    End Sub
    Protected Sub GVSelfDet_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVSelfDet.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                Dim i As Int64 = CType(CType(GVSelfDet.Rows(e.NewEditIndex).FindControl("lblId"), HiddenField).Value, Int64)
                Dim dt As New DataTable
                'If selfdetailsDB.GetDeatilsByBranch.Tables.Count > 0 Then
                dt = selfdetailsDB.GetDeatilsByHOID(i).Tables(0)
                NameTextBox.Text = dt.Rows(0)("MyCo_Name").ToString
                ViewState("BName") = dt.Rows(0)("MyCo_Name").ToString
                txtaddress.Text = dt.Rows(0)("Company_Address").ToString
                txtregNo.Text = dt.Rows(0)("Registration_No").ToString
                txtContactPerson.Text = dt.Rows(0)("Contact_Person").ToString
                txtContactNo1.Text = dt.Rows(0)("Contact_Number1").ToString
                txtContactNo2.Text = dt.Rows(0)("Contact_Number2").ToString
                txtcity.Text = dt.Rows(0)("City").ToString
                txtState.Text = dt.Rows(0)("State").ToString
                txtpinCode.Text = dt.Rows(0)("Postal_Code").ToString
                txtCountry.Text = dt.Rows(0)("Country").ToString
                txtFax.Text = dt.Rows(0)("Fax_Number").ToString
                txtEmail.Text = dt.Rows(0)("Email").ToString
                txtWebsite.Text = dt.Rows(0)("Website").ToString
                ImageMap1.ImageUrl = dt.Rows(0)("Logo").ToString.Trim
                ViewState("ImageTime") = dt.Rows(0)("Logo").ToString.Trim
                ImageMapDefault.ImageUrl = dt.Rows(0)("ImgDefault").ToString.Trim
                ViewState("ImageTimeDefault") = dt.Rows(0)("ImgDefault").ToString.Trim
                ImageMapHeader.ImageUrl = dt.Rows(0)("ImgHeader").ToString.Trim
                ViewState("ImageTimeHeader") = dt.Rows(0)("ImgHeader").ToString.Trim
                DDLColor.SelectedValue = dt.Rows(0)("HeaderTextColor").ToString.Trim
                txtPrefix.Text = dt.Rows(0)("Prefix").ToString.Trim
                If dt.Rows(0)("Creationdate").ToString.Trim <> "" Then
                    Dim CreationDate As DateTime = dt.Rows(0)("Creationdate")
                    txtCreationDate.Text = Format(CreationDate, "dd-MMM-yyyy")
                Else
                    txtCreationDate.Text = ""
                End If

                CoIdTextBox.Text = dt.Rows(0)("MyCo_Id").ToString
                txtAdminName.Text = dt.Rows(0)("UserName").ToString
                txtAdminPass.Text = RijndaelSimple.Decrypt(dt.Rows(0)("Password").ToString.Trim, _
                                                  RijndaelSimple.passPhrase, _
                                                  RijndaelSimple.saltValue, _
                                                  RijndaelSimple.hashAlgorithm, _
                                                  RijndaelSimple.passwordIterations, _
                                                  RijndaelSimple.initVector, _
                                                  RijndaelSimple.keySize)
                Dim ExpDate As DateTime = dt.Rows(0)("ExpDate")
                txtExpiryDate.Text = Format(ExpDate, "dd-MMM-yyyy")
                DDLStatus.SelectedValue = dt.Rows(0)("Status").ToString

                'txtPrefix.Enabled = False
                txtAdminName.Enabled = False
                txtAdminPass.Enabled = False

                btnadd.Visible = True
                btnadd.Text = "UPDATE"
                btnDetails.Text = "BACK"
                lblgreen.Text = ""
                lblmsg.Text = ""
                GVSelfDet.DataSource = dt
                GVSelfDet.DataBind()
                GVSelfDet.Enabled = False
                GVSelfDet.Visible = True
                'End If
            Else
                lblgreen.Text = ""
                lblmsg.Text = "No Edit Permission!"
            End If
        Else
            lblgreen.Text = ""
            lblmsg.Text = "No Edit Permission!"
        End If
    End Sub
    Protected Sub btnDeleteJunk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteJunk.Click
        BLL.DeleteJunkData()
        lblgreen.Text = "Junk Data Deleted Successfully"
        lblmsg.Text = ""
    End Sub
    Sub Clear()
        NameTextBox.Text = ""
        txtaddress.Text = ""
        txtregNo.Text = ""
        txtContactPerson.Text = ""
        txtContactNo1.Text = ""
        txtContactNo2.Text = ""
        txtcity.Text = ""
        txtState.Text = ""
        txtpinCode.Text = ""
        txtCountry.Text = ""
        txtFax.Text = ""
        txtEmail.Text = ""
        txtWebsite.Text = ""
        ImageMap1.ImageUrl = "~/Images/imageupload.gif"
        ImageMapDefault.ImageUrl = "~\Images\Schoolmgmt.jpg"
        ImageMapHeader.ImageUrl = "~\Images\header.gif"
        ViewState("ImageTime") = ""
        ViewState("ImageTimeDefault") = ""
        ViewState("ImageTimeHeader") = ""
        DDLColor.ClearSelection()
        txtPrefix.Text = ""
        txtAdminName.Text = ""
        txtAdminPass.Text = ""
        txtExpiryDate.Text = ""
        DDLStatus.ClearSelection()
    End Sub
    Public Sub uploadFileUsingFTP(ByVal CompleteFTPPath As String, ByVal CompleteLocalPath As String, Optional ByVal UName As String = "", Optional ByVal PWD As String = "")
        'Create a FTP Request Object and Specfiy a Complete Path
        Dim reqObj As FtpWebRequest = WebRequest.Create(CompleteFTPPath)
        'Call A FileUpload Method of FTP Request Object
        reqObj.Method = WebRequestMethods.Ftp.UploadFile
        'If you want to access Resourse Protected You need to give User Name      and PWD
        reqObj.Credentials = New NetworkCredential(UName, PWD)
        'FileStream object read file from Local Drive
        Dim streamObj As FileStream = File.OpenRead(CompleteLocalPath)
        'Store File in Buffer
        Dim buffer(streamObj.Length) As Byte
        'Read File from Buffer
        streamObj.Read(buffer, 0, buffer.Length)
        'Close FileStream Object Set its Value to nothing
        streamObj.Close()
        streamObj = Nothing
        'Upload File to ftp://localHost/ set its object to nothing
        reqObj.GetRequestStream().Write(buffer, 0, buffer.Length)
        reqObj = Nothing
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub BtnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        Dim qrystring As String = "RptClientMasterDetailsV.aspx?" & QueryStr.Querystring()
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
    End Sub
    Protected Sub UploadLogo(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload1.Click
        PhotoUpload()
    End Sub
    Sub PhotoUpload()
        Try
            If ViewState("ImageTime") <> Nothing Then
                Dim Foto As String = Session("Path") + ViewState("ImageTime").ToString.Replace("~/", "")
                Foto = Foto.Replace("/", "\")
                If IO.File.Exists(Foto) Then
                    IO.File.Delete(Foto)
                End If
            End If
            ViewState("ImageTime") = ""
            lblmsg.Text = ""
            lblgreen.Text = ""
            path = "E" & NameTextBox.Text.Trim.ToString().Replace(" ", "") + TimeOfDay.ToString().Replace("/", "").Replace(":", "") & ".jpg"
            Me.FileUpload1.SaveAs(Server.MapPath("~/Images/" & path))
            path1 = "~/Images/" & path
            ViewState("ImageTime") = "~/Images/" & path
            Me.ImageMap1.ImageUrl = path1
        Catch ex As Exception
            lblgreen.Text = ""
            lblmsg.Text = "Error while Uploading Logo. Please refresh the page and try once again"
        End Try
    End Sub
    Protected Sub btnUploadDefault_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadDefault.Click
        PhotoUploadDefault()
    End Sub
    Sub PhotoUploadDefault()
        Try
            If ViewState("ImageTimeDefault") <> Nothing Then
                Dim Foto As String = Session("Path") + ViewState("ImageTimeDefault").ToString.Replace("~/", "")
                Foto = Foto.Replace("/", "\")
                If IO.File.Exists(Foto) Then
                    IO.File.Delete(Foto)
                End If
            End If
            ViewState("ImageTimeDefault") = ""
            lblmsg.Text = ""
            lblgreen.Text = ""
            PathDefault = "D" & NameTextBox.Text.Trim.ToString().Replace(" ", "") + TimeOfDay.ToString().Replace("/", "").Replace(":", "") & ".jpg"
            Me.FileUploadDefault.SaveAs(Server.MapPath("~/Images/" & PathDefault))
            PathDefault1 = "~/Images/" & PathDefault
            ViewState("ImageTimeDefault") = "~/Images/" & PathDefault
            Me.ImageMapDefault.ImageUrl = PathDefault1
        Catch ex As Exception
            lblgreen.Text = ""
            lblmsg.Text = "Error while Uploading Default Image. Please refresh the page and try once again"
        End Try
    End Sub
    Protected Sub btnUploadHeader_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadHeader.Click
        PhotoUploadHeader()
    End Sub
    Sub PhotoUploadHeader()
        Try
            If ViewState("ImageTimeHeader") <> Nothing Then
                Dim Foto As String = Session("Path") + ViewState("ImageTimeHeader").ToString.Replace("~/", "")
                Foto = Foto.Replace("/", "\")
                If IO.File.Exists(Foto) Then
                    IO.File.Delete(Foto)
                End If
            End If
            ViewState("ImageTimeHeader") = ""
            lblmsg.Text = ""
            lblgreen.Text = ""
            PathHeader = "H" & NameTextBox.Text.Trim.ToString().Replace(" ", "") + TimeOfDay.ToString().Replace("/", "").Replace(":", "") & ".jpg"
            Me.FileUploadHeader.SaveAs(Server.MapPath("~/Images/" & PathHeader))
            PathHeader1 = "~/Images/" & PathHeader
            ViewState("ImageTimeHeader") = "~/Images/" & PathHeader
            Me.ImageMapHeader.ImageUrl = PathHeader1
        Catch ex As Exception
            lblgreen.Text = ""
            lblmsg.Text = "Error while Uploading Header Image. Please refresh the page and try once again"
        End Try
    End Sub
End Class
