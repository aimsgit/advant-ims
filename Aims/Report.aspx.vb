
Partial Class Report
    Inherits BasePage
    Dim SearchKey As String
    'Dim Id As Integer
    Dim b As New BLslssbhierarchytreeview
    Dim slssb As New slssbhierarchytreeview
    Dim dt, dttree As New DataTable
    Dim DSDDDL As Integer
    Dim GSDDDL As Integer
    Dim str, brcode As String
    Dim count, i As Integer
    Dim split As String()
    Dim splittree As String()
    Dim splitt As String()
    Dim splitval As String
    Dim n1, n2, n3, n4, n5 As Integer
    Dim Zone, RO, HUB, Center As String
    Protected Sub GrdReport_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrdReport.RowEditing
        Dim Link As String = CType(GrdReport.Rows(e.NewEditIndex).FindControl("HFLinkName"), HiddenField).Value
        Dim QryStr As String = CType(GrdReport.Rows(e.NewEditIndex).FindControl("HFQryStr"), HiddenField).Value
        Dim Heading As String = CType(GrdReport.Rows(e.NewEditIndex).FindControl("HFHeading"), HiddenField).Value
        If CType(GrdReport.Rows(e.NewEditIndex).FindControl("HFDirectLink"), HiddenField).Value = "Y" Then
            Dim Str1 As String = Link + "?QS=" + QryStr + "&heading=" + Heading
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & Str1 & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        Else
            Dim Str1 As String = Link + "?QS=" + QryStr + "&heading=" + Heading
            Session("HelpLink") = UserDetailsDB.GetHelpLink(Link, "R")
            'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & Str1 & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            Response.Redirect(Str1)
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim heading As String
        'heading = Session("RptFrmTitleName")
        'Me.Lblheading.Text = heading
        str = Session("BranchCode")
        'If Not IsPostBack Then
        '    lblParentBranch.Text = "You are Here >> " + Session("BranchName")
        '    brcode = Trim(Session("InstituteCode")) + "00000000"
        '    ddlHO.SelectedValue = brcode
        '    ddloffice.Focus()
        'End If
        If Not IsPostBack Then
            Id = 0
            ViewState("SearchKey") = txtSearchKey.Text
            disp(Id, ViewState("SearchKey"))
        Else
            Id = 1
            ViewState("SearchKey") = txtSearchKey.Text
            disp(Id, ViewState("SearchKey"))
        End If

    End Sub
    Sub disp(ByVal Id As Integer, ByVal SearchKey As String)
        Dim dt As New DataTable
        dt = DLReport.GetReportData(Id, ViewState("SearchKey"), ddlModule.SelectedValue)
        If dt.Rows.Count > 0 Then
            GrdReport.DataSource = dt
            GrdReport.DataBind()
            GrdReport.Visible = True
            GrdReport.Enabled = True
        Else
            txtSearchKey.Text = "Search not found."
            txtSearchKey.ForeColor = Drawing.Color.IndianRed
            GrdReport.Visible = False
        End If
    End Sub

    Protected Sub txtSearchKey_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchKey.TextChanged
        ViewState("SearchKey") = txtSearchKey.Text
        If ViewState("SearchKey") <> "Search" Then
            Id = 1
        End If
        txtSearchKey.ForeColor = Drawing.Color.Black
        disp(Id, ViewState("SearchKey"))
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Id = 0
        SearchKey = txtSearchKey.Text
        ViewState("SearchKey") = 0
        disp(Id, ViewState("SearchKey"))
        txtSearchKey.Text = "Search"
        txtSearchKey.ForeColor = Drawing.Color.Black
    End Sub
    Function len() As Integer
        Dim i As Integer
        str = Session("BranchCode")
        For i = str.Length - 1 To 0 Step -1
            If str(i) = "0" Then
                str = str.Remove(i, 1)
            Else
                i = 0
            End If
        Next
        Return str.Length
    End Function
    'Protected Sub GotoParent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GotoParent.Click
    '    Try
    '        Session("BranchCode") = Session("ParentBranch")
    '        Session("BranchName") = Session("ParentName")
    '        Session("BranchType_ID") = Session("BranchType_Parent")
    '        Session("InstituteCode") = Session("ParentInstituteCode")
    '        Session("InstituteName") = Session("ParentInstituteName")
    '        lblParentBranch.Text = "You are Here >> " + Session("BranchName")
    '        Session("TagLine") = Session("ParentTagLine")
    '        Session("IncludeInsName") = Session("ParentIncludeInsName")
    '        Session("DefaultIMG") = Session("ParentDefaultIMG")
    '        Session("HeaderTextColor") = Session("ParentHeaderTextColor")
    '        Session("Logo") = Session("ParentLogo")
    '        Session("InstituteLogo") = Session("ParentInstituteLogo")
    '        Session("ImgHeader") = Session("ParentImgHeader")

    '        ddlHO.DataSourceID = "objHO"
    '        Response.Redirect("Report.aspx")
    '    Catch ex As Exception
    '        lblmsg.Text = "You are at the same branch."
    '    End Try
    'End Sub
    'Protected Sub ddlHO_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHO.PreRender
    '    If ddlHO.Items.Count > 0 Then
    '        If ddlHO.Items(0).Text <> "Select" Then
    '            ddlHO.Items.Insert(0, "Select")
    '        End If
    '    Else
    '        ddlHO.Items.Insert(0, "Select")
    '    End If
    '    'If Not IsPostBack Then
    '    n1 = 0
    '    n2 = 0
    '    n3 = 0
    '    n4 = 0
    '    n5 = 0

    '    dttree = DLslssbhierarchytreeview.FillListView(ddlHO.SelectedValue.ToString)
    '    If dttree Is Nothing = False Then
    '        If (dttree.Rows.Count > 0) Then
    '            For Each row As DataRow In dttree.Rows
    '                splittree = row.Item(1).ToString.Split(":")
    '                If (CInt(splittree(0)) = 1) Then
    '                    n1 = n1 + 1
    '                End If
    '                If (CInt(splittree(0)) = 2) Then
    '                    n2 = n2 + 1
    '                End If
    '                If (CInt(splittree(0)) = 3) Then
    '                    n3 = n3 + 1
    '                End If
    '                If (CInt(splittree(0)) = 4) Then
    '                    n4 = n4 + 1
    '                End If
    '                If (CInt(splittree(0)) = 5) Then
    '                    n5 = n5 + 1
    '                End If
    '            Next row

    '            Static Dim StrHO(n1 - 1) As String
    '            Static Dim StrZone(n2 - 1) As String
    '            Static Dim StrRO(n3 - 1) As String
    '            Static Dim StrHUB(n4 - 1) As String
    '            Static Dim StrCenter(n5 - 1) As String

    '            n1 = 0
    '            n2 = 0
    '            n3 = 0
    '            n4 = 0
    '            n5 = 0

    '            For Each row As DataRow In dttree.Rows
    '                splittree = row.Item(1).ToString.Split(":")
    '                If (CInt(splittree(0)) = 1) Then
    '                    StrHO(n1) = Trim(splittree(1)) + "," + row.Item(0).ToString
    '                    n1 = n1 + 1
    '                End If
    '                If (CInt(splittree(0)) = 2) Then
    '                    StrZone(n2) = Trim(splittree(1)) + "," + row.Item(0).ToString
    '                    n2 = n2 + 1
    '                End If
    '                If (CInt(splittree(0)) = 3) Then
    '                    StrRO(n3) = Trim(splittree(1)) + "," + row.Item(0).ToString
    '                    n3 = n3 + 1
    '                End If
    '                If (CInt(splittree(0)) = 4) Then
    '                    StrHUB(n4) = Trim(splittree(1)) + "," + row.Item(0).ToString
    '                    n4 = n4 + 1
    '                End If
    '                If (CInt(splittree(0)) = 5) Then
    '                    StrCenter(n5) = Trim(splittree(1)) + "," + row.Item(0).ToString
    '                    n5 = n5 + 1
    '                End If
    '            Next row

    '            TreeView1.Nodes.Clear()

    '            'HO entried
    '            TreeView1.Nodes.Add(New TreeNode("<FONT COLOR='Indigo'>" + dttree.Rows(0).Item(0).ToString + "</FONT>", dttree.Rows(0).Item(1).ToString))
    '            count = dttree.Rows.Count

    '            For i As Integer = 1 To count - 1
    '                splittree = dttree.Rows(i).Item(1).ToString.Split(":")

    '                Zone = ""
    '                RO = ""
    '                HUB = ""

    '                'zone entried
    '                If (CInt(splittree(0)) = 2) Then
    '                    TreeView1.Nodes(0).ChildNodes.Add(New TreeNode("<FONT COLOR='Green'>" + dttree.Rows(i).Item(0).ToString + "</FONT>", dttree.Rows(i).Item(1).ToString))
    '                End If

    '                'RO entried
    '                If (CInt(splittree(0)) = 3) Then
    '                    For j As Integer = 0 To n2 - 1
    '                        If (StrZone(j).Substring(0, 6).Equals(Trim(splittree(1)).Substring(0, 6))) Then
    '                            TreeView1.Nodes(0).ChildNodes(j).ChildNodes.Add(New TreeNode("<FONT COLOR='OrangeRed'>" + dttree.Rows(i).Item(0).ToString + "</FONT>", dttree.Rows(i).Item(1).ToString))
    '                        End If
    '                    Next
    '                End If
    '                Dim rcount As Integer = 2
    '                'HUB entried
    '                If (CInt(splittree(0)) = 4) Then
    '                    For j As Integer = 0 To n3 - 1
    '                        splitt = StrRO(j).ToString.Split(",")
    '                        If (splitt(0).Substring(0, 8).Equals(Trim(splittree(1)).Substring(0, 8))) Then
    '                            If (splitt.Length > 2) Then
    '                                RO = splitt(1)
    '                                While (rcount < splitt.Length)
    '                                    RO = RO + "," + splitt(rcount)
    '                                    rcount = rcount + 1
    '                                End While
    '                                Exit For
    '                            Else
    '                                RO = splitt(1)
    '                                Exit For
    '                            End If
    '                        End If
    '                    Next
    '                    Dim SNode As TreeNode = FindInTreeview("<FONT COLOR='OrangeRed'>" + RO + "</FONT>", TreeView1.Nodes)
    '                    SNode.ChildNodes.Add(New TreeNode("<FONT COLOR='MediumOrchid'>" + dttree.Rows(i).Item(0).ToString + "</FONT>", dttree.Rows(i).Item(1).ToString))
    '                End If
    '                Dim hcount As Integer = 2
    '                'Center entried
    '                If (CInt(splittree(0)) = 5) Then
    '                    For j As Integer = 0 To n4 - 1
    '                        splitt = StrHUB(j).ToString.Split(",")
    '                        If (splitt(0).Substring(0, 10).Equals(Trim(splittree(1)).Substring(0, 10))) Then
    '                            If (splitt.Length > 2) Then
    '                                HUB = splitt(1)
    '                                While (hcount < splitt.Length)
    '                                    HUB = HUB + "," + splitt(hcount)
    '                                    hcount = hcount + 1
    '                                End While
    '                                Exit For
    '                            Else
    '                                HUB = splitt(1)
    '                                Exit For
    '                            End If
    '                        End If
    '                    Next
    '                    Dim SNode As TreeNode = FindInTreeview("<FONT COLOR='MediumOrchid'>" + HUB + "</FONT>", TreeView1.Nodes)
    '                    SNode.ChildNodes.Add(New TreeNode(dttree.Rows(i).Item(0).ToString, dttree.Rows(i).Item(1).ToString))
    '                End If
    '            Next
    '            TreeView1.ExpandDepth = 1
    '        Else
    '            TreeView1.Nodes.Clear()
    '        End If
    '    End If
    'End Sub

    Function FindInTreeview(ByVal strSearch As String, ByVal Nodes As TreeNodeCollection) As TreeNode
        Dim ret As TreeNode

        '~~> Loop through each TreeNode
        For Each TrNode As TreeNode In Nodes
            '~~> Compare node text with search text
            If TrNode.Text = strSearch Then
                Return TrNode
            End If

            '~~> Do recursive search if there are child nodes
            If TrNode.ChildNodes.Count > 0 Then
                ret = FindInTreeview(strSearch, TrNode.ChildNodes)
                If Not ret Is Nothing Then
                    Return ret
                End If
            End If
        Next
        Return Nothing
    End Function

    'Protected Sub ddlHO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHO.SelectedIndexChanged
    '    ViewState("branchcode") = ddlHO.SelectedItem.Value
    '    ViewState("Branchname") = ddlHO.SelectedItem.ToString
    '    ViewState("BranchType") = "HO"
    '    ViewState("Institute") = ddlHO.SelectedItem.ToString
    '    ListBox1.Items.Clear()
    '    ListBox1.DataSourceID = "ObjBranchName"
    'End Sub

    'Protected Sub ddlHO_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHO.TextChanged
    '    ddlHO.Focus()
    'End Sub

    'Protected Sub ddloffice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddloffice.TextChanged
    '    ddloffice.Focus()
    'End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    'Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.SelectedNodeChanged
    '    TreeView1.SelectedNodeStyle.ForeColor = Drawing.Color.Red
    '    TreeView1.SelectedNodeStyle.Font.Bold = True

    '    Try
    '        If ddlHO.SelectedValue = "Select" Then
    '            lblmsg.Text = "HO Field id Mandatory."
    '        Else
    '            split = TreeView1.SelectedNode.Value.ToString.Split(":")
    '            If CInt(split(0)) > CInt(Session("Accesslevel")) Then
    '                If ddloffice.SelectedValue = 1 Then
    '                    Session("Office") = "I"
    '                Else
    '                    Session("Office") = "A"
    '                End If
    '                Session("BranchType_ID") = Trim(split(0))
    '                Session("BranchCode") = Trim(split(1))
    '                split = TreeView1.SelectedNode.Text.ToString.Split(":")
    '                Session("BranchName") = Trim(split(1))
    '                Session("BranchTypeName") = Trim(split(0))
    '                Session("InstituteCode") = Left(ddlHO.SelectedValue.ToString, 4)
    '                Session("InstituteName") = ddlHO.SelectedItem.ToString

    '                Dim dt As DataTable = selfdetailsDB.GetSelfDetailsByUID()
    '                If dt.Rows.Count > 0 Then
    '                    Session("DefaultIMG") = dt.Rows(0)("ImgDefault").ToString
    '                    Session("HeaderTextColor") = dt.Rows(0)("HeaderTextColor").ToString
    '                    Session("InstituteLogo") = dt.Rows(0)("InsLogo").ToString
    '                    Session("Logo") = dt.Rows(0)("Logo").ToString
    '                    Session("ImgHeader") = dt.Rows(0)("ImgHeader").ToString
    '                    Session("TagLine") = dt.Rows(0)("Tagline").ToString
    '                    Session("IncludeInsName") = dt.Rows(0)("IncludeInsName").ToString
    '                End If

    '                lblParentBranch.Text = "You are Here >> " + Session("BranchName")
    '                Response.Redirect("Report.aspx")
    '                lblmsg.Text = ""
    '            Else
    '                lblmsg.Text = "Permission denied!!! you cannot navigate to higher hierarchy."
    '            End If
    '        End If
    '    Catch ex As Exception
    '        lblmsg.Text = "Select any Branch Name and then click on Submit."
    '    End Try
    'End Sub

    Protected Sub ddlModule_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlModule.SelectedIndexChanged
        txtSearchKey.Text = ""
        ViewState("SearchKey") = txtSearchKey.Text
        disp(ID, ViewState("SearchKey"))
    End Sub
End Class
