
Partial Class FrmInstituteWiseDrillDown
    Inherits BasePage
    Dim BL As New BLInstituteWiseBranchCount
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim HOCode As String = Request.QueryString.Get(("HOCode"))
        Dim BranchType As String = Request.QueryString.Get(("BranchType"))
        Dim BranchName As String = Request.QueryString.Get(("BranchName"))
        
        Select Case Val(BranchType)
            Case "02"
                Lblheading.Text = BranchName + " - Zone"
                panel1.Visible = True
                GVZoneList.Visible = True
                dt = BL.GetInstituteWiseBranchZone(HOCode)
                If dt.Rows.Count > 0 Then
                    GVZoneList.DataSource = dt
                    GVZoneList.DataBind()
                Else
                    lblError.Text = "No Records to Display."
                End If
            Case "03"
                Lblheading.Text = BranchName + " - RO"
                panel2.Visible = True
                GVRO.Visible = True
                dt = BL.GetInstituteWiseBranchRO(HOCode)
                If dt.Rows.Count > 0 Then
                    GVRO.DataSource = dt
                    GVRO.DataBind()
                Else
                    lblError.Text = "No Records to Display."
                End If
            Case "04"
                Lblheading.Text = BranchName + " - HUB"
                panel3.Visible = True
                GVHUB.Visible = True
                dt = BL.GetInstituteWiseBranchHUB(HOCode)
                If dt.Rows.Count > 0 Then
                    GVHUB.DataSource = dt
                    GVHUB.DataBind()
                Else
                    lblError.Text = "No Records to Display."
                End If
            Case "05"
                Lblheading.Text = BranchName + " - Center"
                panel4.Visible = True
                GVCenter.Visible = True
                dt = BL.GetInstituteWiseBranchCenter(HOCode)
                If dt.Rows.Count > 0 Then
                    GVCenter.DataSource = dt
                    GVCenter.DataBind()
                Else
                    lblError.Text = "No Records to Display."
                End If
            Case Else
        End Select
        Me.Title = Lblheading.Text
    End Sub
End Class
