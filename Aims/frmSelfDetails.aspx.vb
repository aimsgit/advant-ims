Imports System.Net
Imports System.IO
Partial Class frmSelfDetails
    Inherits BasePage
    Dim a As Integer
    Dim GlobalFunction As New GlobalFunction
    Dim idd As Integer
    Dim path, path1 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim heading As String
            heading = Session("RptFrmTitleName")
            Me.Lblheading.Text = heading
            If Session("Branchcode") = "000000000000" Then
                btnUpload1.Enabled = True
            Else
                btnUpload1.Enabled = False
            End If
            If Not Page.IsPostBack Then
                NameTextBox.Focus()
                ImageMap1.ImageUrl = "~\Images\imageupload.gif"
                Dim dt As New DataTable
                dt = selfdetailsDB.GetDeatilsByBranch(Trim(NameTextBox.Text), Trim(txtregNo.Text), Trim(txtEmail.Text), Trim(txtWebsite.Text))
                'dt = selfdetailsDB.GetDeatilsByHOID(i).Tables(0)
                NameTextBox.Text = dt.Rows(0)("MyCo_Name").ToString
                ViewState("BName") = dt.Rows(0)("MyCo_Name").ToString
                txtaddress.Text = dt.Rows(0)("Company_Address").ToString
                txtregNo.Text = dt.Rows(0)("Registration_No").ToString
                txtContactPerson.Text = dt.Rows(0)("Contact_Person").ToString
                txtContactNo1.Text = dt.Rows(0)("Contact_Number1").ToString
                txtContactNo2.Text = dt.Rows(0)("Contact_Number2").ToString
                txtcity.Text = dt.Rows(0)("City").ToString
                ddlState.Text = dt.Rows(0)("State").ToString
                txtpinCode.Text = dt.Rows(0)("Postal_Code").ToString
                txtCountry.Text = dt.Rows(0)("Country").ToString
                txtFax.Text = dt.Rows(0)("Fax_Number").ToString
                txtEmail.Text = dt.Rows(0)("Email").ToString
                txtWebsite.Text = dt.Rows(0)("Website").ToString
                ImageMap1.ImageUrl = dt.Rows(0)("Logo").ToString.Trim
                ViewState("ImageTime") = dt.Rows(0)("Logo").ToString.Trim
                CoIdTextBox.Text = dt.Rows(0)("MyCo_Id").ToString


                NameTextBox.ReadOnly = True
                txtaddress.ReadOnly = True
                txtregNo.ReadOnly = True
                txtContactPerson.ReadOnly = True
                txtContactNo1.ReadOnly = True
                txtContactNo2.ReadOnly = True
                txtcity.ReadOnly = True
                ddlState.ReadOnly = True
                txtpinCode.ReadOnly = True
                txtCountry.ReadOnly = True
                txtFax.ReadOnly = True
                txtEmail.ReadOnly = True
                txtWebsite.ReadOnly = True
                CoIdTextBox.ReadOnly = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub UploadLogo(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload1.Click
        btnUpload1.Enabled = True
        PhotoUpload(0)
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Sub PhotoUpload(ByVal i As Int64)
        If FileUpload1.PostedFile.ContentLength <= 30000 Then
            Try
                If ViewState("ImageTime") <> Nothing Then
                    'Dim Foto As String = Replace(ViewState("ImageTime"), "~/", "")
                    Dim Foto As String = Session("Path") + ViewState("ImageTime").ToString.Replace("~/", "")
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
                txtpath.Text = path1
                Me.ImageMap1.ImageUrl = txtpath.Text
            Catch ex As Exception
                lblgreen.Text = ""
                lblmsg.Text = "Error while Uploading Image. Please refresh the page and try once again"
            End Try
        Else
            lblmsg.Text = "Photo Size should be less than or equal to 30 KB."
            lblgreen.Text = ""
        End If
    End Sub
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        NameTextBox.Focus()
        lblgreen.Text = ""
        lblmsg.Text = ""
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
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
                Prop.State = ddlState.Text
                Prop.Code = txtpinCode.Text
                Prop.Country = txtCountry.Text
                Prop.Fax = txtFax.Text
                Prop.Email = txtEmail.Text
                Prop.Website = txtWebsite.Text
                Prop.CoId = CoIdTextBox.Text
                'PhotoUpload(i)
                'PathUpdate(i, txtpath.Text)
                Dim check As New DataTable
                Dim typeName As String = NameTextBox.Text
                'If ViewState("BName") <> NameTextBox.Text Then
                '    Prop.Logo = ViewState("Logo")
                'Else
                Prop.Logo = ViewState("ImageTime")
                'End If
                check = BLL.CheckDuplicate(typeName)
                If check.Rows.Count > 1 Then
                    lblmsg.Text = "Data already exists."
                Else
                    BLL.Update(Prop)
                    btnDetails.Text = "VIEW"
                    Clear()
                    DispGrid()
                    GVSelfDet.Enabled = "True"
                    btnadd.Visible = False
                    lblgreen.Text = "Data Updated Successfully."
                End If
            Else
                lblmsg.Text = "You do not have permission, Cannot add data."
                lblgreen.Text = ""
            End If
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot add data."
            lblgreen.Text = ""
        End If
    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        lblmsg.Text = ""
        lblgreen.Text = ""
        If btnDetails.Text = "VIEW" Then
            DispGrid()
        ElseIf btnDetails.Text = "BACK" Then
            btnadd.Text = "ADD"
            btnDetails.Text = "VIEW"
            GVSelfDet.Enabled = True
            btnadd.Visible = False
            Clear()
            DispGrid()
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
            LinkButton.Focus()
        End If
    End Sub
    Protected Sub GVSelfDet_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVSelfDet.PageIndexChanging
        lblgreen.Visible = False
        GVSelfDet.PageIndex = e.NewPageIndex
        DispGrid()
    End Sub
    Protected Sub GVSelfDet_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVSelfDet.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblgreen.Text = ""
            lblmsg.Text = ""
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
                ddlState.Text = dt.Rows(0)("State").ToString
                txtpinCode.Text = dt.Rows(0)("Postal_Code").ToString
                txtCountry.Text = dt.Rows(0)("Country").ToString
                txtFax.Text = dt.Rows(0)("Fax_Number").ToString
                txtEmail.Text = dt.Rows(0)("Email").ToString
                txtWebsite.Text = dt.Rows(0)("Website").ToString
                ImageMap1.ImageUrl = dt.Rows(0)("Logo").ToString.Trim
                ViewState("ImageTime") = dt.Rows(0)("Logo").ToString.Trim
                CoIdTextBox.Text = dt.Rows(0)("MyCo_Id").ToString
                btnadd.Visible = True
                btnadd.Text = "UPDATE"
                btnDetails.Text = "BACK"
                GVSelfDet.DataSource = dt
                GVSelfDet.DataBind()
                GVSelfDet.Enabled = False
                GVSelfDet.Visible = True
                'End If
            Else
                lblmsg.Text = "You do not have permission, Cannot edit data."
            End If
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot edit data."
            lblgreen.Text = ""
        End If
    End Sub
    Sub Clear()
        NameTextBox.Text = ""
        txtaddress.Text = ""
        txtregNo.Text = ""
        txtContactPerson.Text = ""
        txtContactNo1.Text = ""
        txtContactNo2.Text = ""
        txtcity.Text = ""
        txtpinCode.Text = ""
        txtCountry.Text = ""
        txtFax.Text = ""
        txtEmail.Text = ""
        txtWebsite.Text = ""
        txtpath.Text = ""
        ImageMap1.ImageUrl = "~/Images/imageupload.gif"
        ViewState("ImageTime") = ""
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
End Class

