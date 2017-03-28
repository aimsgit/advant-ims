
Imports System.Data
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Net

Partial Class frmdocmgmt
    Inherits BasePage
    Dim EL As New ELDocUpload
    Dim BL As New BLDocUpload
    Dim DL As New DLDocUpload
    Dim dt, dt1, dt2 As DataTable
    Dim dispId, configvalue, FileLinkName, FilePathN, UserName, Password As String
    Dim strHostName As String = ""
    Dim PathName As String = ""
    Dim Arr As String()
    Dim Save, Update As Integer

    Protected Sub btnupload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupload.Click

        Dim name As String = FileUpload1.FileName
        FileUpload1.SaveAs(Server.MapPath("~/UploadDocument/" + name))
        Dim path As String = Server.MapPath("~/UploadDocument/" + name)
        Dim fInfo As New FileInfo(path)

        Dim numBytes As Long = fInfo.Length

        Dim fStream As New FileStream(path, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fStream)
        Dim data As Byte() = br.ReadBytes(CInt(numBytes))
        Dim CallWebService As New TransportWeb()
        Dim txtRevDate As Date
        Dim sGetValue As String = CallWebService.DocumentUpload(data, path, txtdesc.Text, txtRev.Text, txtRevDate, txtremarks.Text)
        lblG.Text = sGetValue
        br.Close()
        fStream.Close()


    End Sub

    Protected Sub btnlink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlink.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try


                strHostName = Request.UserHostName
                If (strHostName.Equals("")) Then
                    strHostName = Request.UserHostAddress
                End If
                PathName = IO.Path.GetDirectoryName(FileUpload1.PostedFile.FileName)
                Arr = PathName.Split("\")
                EL.Link = "\\" & strHostName & "\" & Arr(Arr.Length - 1) & "\" & FileUpload1.FileName
                EL.Desc = txtdesc.Text
                EL.RevNo = txtRev.Text
                EL.RevDate = txtRevDate.Text
                EL.Remarks = txtremarks.Text
                EL.id = 0
                If btnlink.Text.Equals("LINK") Then
                    BL.InsertRecord(EL)
                    lblG.Text = "Link Saved Sucessfully."
                    lblR.Text = ""
                    disp()
                    Clear()
                    EL.Link = Nothing
                    EL.Desc = Nothing
                    EL.RevNo = Nothing
                    EL.RevDate = Nothing
                    EL.Remarks = Nothing

                Else
                    EL.id = CInt(ViewState("id"))
                    BL.UpdateRecord(EL)
                    lblG.Text = "Link Updated Sucessfully."
                    lblR.Text = ""
                    Clear()
                    btnlink.CommandName = "LINK"
                    btnsearch.CommandName = "VIEW"
                    btnlink.Text = "LINK"
                    btnsearch.Visible = True
                    btnsearch.Text = "SEARCH"

                    disp()
                End If
            Catch e1 As Exception
                lblG.Text = ""
                lblR.Text = ""
            End Try
        Else
            lblG.Text = ""
            lblR.Text = ""
        End If
        'Else
        'lblerrmsg.Text = "You don't have Write Privilages. "
    End Sub
    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        lblR.Text = ""
        lblG.Text = ""
        EL.Desc = txtdesc.Text
        EL.id = 0
        If btnsearch.Text.Equals("VIEW") Then
            disp()
            gvdoc.Visible = "true"
        Else
            Clear()
            btnlink.CommandName = "LINK"
            btnsearch.CommandName = "VIEW"
            EL.Desc = ""
            EL.id = 0
            btnlink.Text = "LINK"
            btnsearch.Visible = True
            btnsearch.Text = "VIEW"
            disp()
        End If
    End Sub
    Sub disp()
        'EL.Desc = txtdesc.Text
        dt = BL.GetGridData(EL)
        If dt.Rows.Count > 0 Then
            gvdoc.DataSource = dt
            gvdoc.DataBind()
            gvdoc.Visible = True
            gvdoc.Enabled = True
        Else
            lblR.Text = "No Records to display."
            lblG.Text = ""
        End If
    End Sub
    Sub Clear()
        txtdesc.Text = ""
        txtremarks.Text = ""
        txtRev.Text = ""
        txtRevDate.Text = ""
        FileUpload1.Attributes.Clear()
    End Sub
    Protected Sub DownloadFile(ByVal sender As Object, ByVal e As EventArgs)

        Dim filePath As String = CType(sender, LinkButton).CommandArgument
        If (filePath <> " ") Then
            Response.ContentType = ContentType
            Response.AppendHeader("Content-Disposition", ("attachment; filename=" + Path.GetFileName(filePath)))
            Response.WriteFile(filePath)
            Response.End()
        Else
            lblG.Text = "File Not Found."
        End If


    End Sub
    Public Shared Sub Download(ByVal sFileName As String, ByVal sFilePath As String)
        HttpContext.Current.Response.ContentType = "APPLICATION/OCTET-STREAM"
        Dim Header As [String] = "Attachment; Filename=" & sFileName
        HttpContext.Current.Response.AppendHeader("Content-Disposition", Header)
        Dim Dfile As New System.IO.FileInfo(sFilePath)
        HttpContext.Current.Response.WriteFile(Dfile.FullName)
        HttpContext.Current.Response.[End]()
    End Sub
    Protected Sub gvdoc_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvdoc.RowDeleting
        Dim rowsaffected As Integer
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = (CType(gvdoc.Rows(e.RowIndex).FindControl("lblFid"), Label).Text)
            rowsaffected = BL.DeleteDoc(EL)
            lblR.Text = ""
            lblG.Text = "Data Deleted Suceesfully."
            EL.id = 0
            EL.Desc = ""
            disp()
        End If
    End Sub
    Protected Sub gvdoc_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvdoc.RowEditing

        btnlink.CommandName = "UPDATE"

        lblG.Text = ""
        lblR.Text = ""
        'FileUpload1.t = CType(gvdoc.Rows(e.NewEditIndex).FindControl("FID"), Label).Text
        txtdesc.Text = CType(gvdoc.Rows(e.NewEditIndex).FindControl("lblsemname"), Label).Text
        txtRev.Text = CType(gvdoc.Rows(e.NewEditIndex).FindControl("lblcatname"), Label).Text
        txtRevDate.Text = CType(gvdoc.Rows(e.NewEditIndex).FindControl("lblfeehead"), Label).Text
        txtremarks.Text = CType(gvdoc.Rows(e.NewEditIndex).FindControl("lblamt"), Label).Text
        ViewState("id") = CType(gvdoc.Rows(e.NewEditIndex).FindControl("lblFid"), Label).Text
        btnlink.CommandName = "UPDATE"
        btnsearch.CommandName = "BACK"
        btnlink.Text = "UPDATE"
        btnsearch.Visible = True
        btnsearch.Text = "BACK"
        EL.id = ViewState("id")
        EL.Desc = ""
        disp()
        gvdoc.DataSource = dt
        gvdoc.DataBind()
        
        gvdoc.Enabled = False
        lblG.Text = ""
        lblR.Text = ""
    End Sub

    'Sub LinkButton12()
    '    Session("Link") = CType(gvdoc.Item("lnkDownload"), String)


    '    Response.Redirect("frmBookIssue.aspx")
    'End Sub

    Protected Sub gvdoc_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvdoc.SelectedIndexChanging
        Session("Link") = CType(gvdoc.Rows(e.NewSelectedIndex).FindControl("lnkDownload"), LinkButton).Text()
        Response.Redirect("frmBookIssue.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            ViewState("heading") = Session("RptFrmTitleName")
            Me.Lblheading.Text = ViewState("heading")
        End If
        'Try

        '    dt = DLDocUpload.Getupload()
        '    If (dt.Rows.Count > 0) Then
        '        configvalue = dt.Rows(0).Item(0)
        '    Else
        '        configvalue = ""
        '    End If
        '    dt = DLDocUpload.GetDocUserName()
        '    If (dt.Rows.Count > 0) Then
        '        UserName = dt.Rows(0).Item(0)
        '    Else
        '        UserName = ""
        '    End If
        '    dt = DLDocUpload.GetDocPassword()
        '    If (dt.Rows.Count > 0) Then
        '        Password = dt.Rows(0).Item(0)
        '    Else
        '        Password = ""
        '    End If
        '    dt = DLDocUpload.GetDocFilePathToUpload()
        '    If (dt.Rows.Count > 0) Then
        '        FilePathN = dt.Rows(0).Item(0)
        '    Else
        '        FilePathN = ""
        '    End If

        'Catch ex As Exception
        '    lblR.Text = "Enter correct FTP UserName,Password and File path in Configuration Table."
        'End Try
        If Not IsPostBack Then
            Save = 0
            Update = 0
        End If
    End Sub

    Protected Sub FileUpload1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileUpload1.Init

    End Sub

    Protected Sub gvdoc_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvdoc.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        EL.id = 0
        EL.Desc = txtdesc.Text
        dt = BL.GetGridData(EL)
        'GrdAcdYear.DataSource = dt

        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        gvdoc.DataSource = sortedView
        gvdoc.DataBind()
        gvdoc.Enabled = True
        gvdoc.Visible = True
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
