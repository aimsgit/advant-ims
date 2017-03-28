Partial Class frmhierarchytree
    Inherits BasePage
    Dim b As New BLslssbhierarchytreeview
    Dim slssb As New slssbhierarchytreeview
    Dim dt As New DataTable
    Dim DSDDDL As Integer
    Dim GSDDDL As Integer
    Dim str, brcode As String
    Dim split As String()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        str = Session("BranchCode")
        If Not IsPostBack Then
            lblParentBranch.Text = "You are Here >> " + Session("BranchName")
            brcode = Trim(Session("InstituteCode")) + "00000000"
            ddlHO.SelectedValue = brcode
            ddloffice.Focus()

        End If
    End Sub
    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Try
            If ddlHO.SelectedValue = "Select" Then
                lblmsg.Text = "HO Field id Mandatory."
            Else
                split = ListBox1.SelectedValue.ToString.Split(":")
                If CInt(split(0)) > CInt(Session("Accesslevel")) Then
                    If ddloffice.SelectedValue = 1 Then
                        Session("Office") = "I"
                    Else
                        Session("Office") = "A"
                    End If
                    Session("BranchType_ID") = Trim(split(0))
                    Session("BranchCode") = Trim(split(1))
                    split = ListBox1.SelectedItem.ToString.Split(":")
                    Session("BranchName") = Trim(split(1))
                    Session("BranchTypeName") = Trim(split(0))
                    Session("InstituteCode") = Left(ddlHO.SelectedValue.ToString, 4)
                    Session("InstituteName") = ddlHO.SelectedItem.ToString

                    Dim dt As DataTable = selfdetailsDB.GetSelfDetailsByUID()
                    If dt.Rows.Count > 0 Then
                        Session("DefaultIMG") = dt.Rows(0)("ImgDefault").ToString
                        Session("HeaderTextColor") = dt.Rows(0)("HeaderTextColor").ToString
                        Session("InstituteLogo") = dt.Rows(0)("InsLogo").ToString
                        Session("Logo") = dt.Rows(0)("Logo").ToString
                        Session("ImgHeader") = dt.Rows(0)("ImgHeader").ToString
                        Session("TagLine") = dt.Rows(0)("Tagline").ToString
                        Session("IncludeInsName") = dt.Rows(0)("IncludeInsName").ToString
                    End If

                    lblParentBranch.Text = "You are Here >> " + Session("BranchName")
                    Response.Redirect("Default2.aspx")
                    lblmsg.Text = ""
                Else
                    lblmsg.Text = "Permission denied!!! you cannot navigate to higher hierarchy."
                End If
            End If
        Catch ex As Exception
            lblmsg.Text = "Select any Branch Name and then click on Submit."
        End Try
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
    Protected Sub GotoParent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GotoParent.Click
        Try
            Session("BranchCode") = Session("ParentBranch")
            Session("BranchName") = Session("ParentName")
            Session("BranchType_ID") = Session("BranchType_Parent")
            Session("InstituteCode") = Session("ParentInstituteCode")
            Session("InstituteName") = Session("ParentInstituteName")
            lblParentBranch.Text = "You are Here >> " + Session("BranchName")
            Session("TagLine") = Session("ParentTagLine")
            Session("IncludeInsName") = Session("ParentIncludeInsName")
            Session("DefaultIMG") = Session("ParentDefaultIMG")
            Session("HeaderTextColor") = Session("ParentHeaderTextColor")
            Session("Logo") = Session("ParentLogo")
            Session("InstituteLogo") = Session("ParentInstituteLogo")
            Session("ImgHeader") = Session("ParentImgHeader")

            ddlHO.DataSourceID = "objHO"
            Response.Redirect("Default2.aspx")
        Catch ex As Exception
            lblmsg.Text = "You are the the same branch."
        End Try
    End Sub
    Protected Sub ddlHO_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHO.PreRender
        If ddlHO.Items.Count > 0 Then
            If ddlHO.Items(0).Text <> "Select" Then
                ddlHO.Items.Insert(0, "Select")
            End If
        Else
            ddlHO.Items.Insert(0, "Select")
        End If
    End Sub

    Protected Sub ddlHO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHO.SelectedIndexChanged
        ViewState("branchcode") = ddlHO.SelectedItem.Value
        ViewState("Branchname") = ddlHO.SelectedItem.ToString
        ViewState("BranchType") = "HO"
        ViewState("Institute") = ddlHO.SelectedItem.ToString
        ListBox1.Items.Clear()
        ListBox1.DataSourceID = "ObjBranchName"
    End Sub

    Protected Sub ddlHO_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHO.TextChanged
        ddlHO.Focus()
    End Sub

    Protected Sub ddloffice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddloffice.TextChanged
        ddloffice.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
