
Partial Class frmSelfDetailsTenantSel
    Inherits BasePage
    Dim SelfDetailsB As New SelfDetailsB
    Dim GlobalFunction As New GlobalFunction
    Dim dt As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            ViewState("InstID") = Request.QueryString.Get("InstID")
            dt = SelfDetailsB.GetTenantModuleList(ViewState("InstID"))
            GVSelfDet.DataSource = dt
            GVSelfDet.DataBind()
            For Each rows As GridViewRow In GVSelfDet.Rows
                If CType(rows.FindControl("lblSelect"), Label).Text = "Y" Then
                    CType(rows.FindControl("ChkSelect"), CheckBox).Checked = True
                End If
            Next
            btnBack.Attributes.Add("onclick", "self.close();")
        End If
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim id As String = ""
        Dim id1 As String = ""
        Dim check As String = ""
        Dim count As New Integer
        Dim ParentId As String = ""
        For Each grid As GridViewRow In GVSelfDet.Rows
            If CType(grid.FindControl("ChkSelect"), CheckBox).Checked = True Then
                check = CType(grid.FindControl("lblParentName"), Label).Text
                ParentId = CType(grid.FindControl("lblGVMNIDAuto"), Label).Text
                id = check + "," + id
                id1 = ParentId + "," + id1
                count = count + 1
            End If
        Next
        If id = "" Then
            lblmsg.Text = "Select Atleast one Module to Update"
            lblgreen.Text = ""
        Else
            If ViewState("InstID") <> "0000" Then
                id = Left(id, id.Length - 1)
                id1 = Left(id1, id1.Length - 1)
                SelfDetailsB.UpdateTenantRoles(id, ViewState("InstID"), id1)
                If GlobalFunction.ErrorMsg = "Error" Then
                Else
                    lblmsg.Text = ""
                    lblgreen.Text = "Data Updated Successfully."
                End If
            Else
                lblmsg.Text = "Cannot update Super Admin modules."
                lblgreen.Text = ""
            End If

        End If
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Write("<script language='javascript'> { self.close() }</script>")
    End Sub
    Sub CheckAll()
        If CType(GVSelfDet.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVSelfDet.Rows
                CType(grid.FindControl("ChkSelect"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GVSelfDet.Rows
                CType(grid.FindControl("ChkSelect"), CheckBox).Checked = False
            Next
        End If
    End Sub
End Class
