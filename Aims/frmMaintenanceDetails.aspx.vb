Partial Class frmMaintenanceDetails
    Inherits BasePage
    Dim alt As String
    Dim sql As String
    Dim BLL As New MachineMaintenenceBL

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim ID As HiddenField = CType(GridView1.Rows(e.RowIndex).Cells(2).FindControl("MID"), HiddenField)
        Dim i As Integer
        i = ID.Value
        BLL.ChangeFlag(i)
        DisplayGridValue()
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        If ddlMainType.Items.Count > 0 Then
            'Dim Rda As New OleDbDataAdapter
            Dim Rdt As New DataTable
            Dim Inst, Bran, type As String
            Inst = Session("InstituteID")
            Bran = Session("BranchID")
            If ddlMainType.Items.Count <> 0 Then
                type = ddlMainType.SelectedItem.Value
            Else
                type = 0
            End If
            'Dim dll As New GlobalDataSetTableAdapters.DispGV_MaintenanceTableAdapter

            Dim dt As New Data.DataTable
            If type = 4 Or type = 3 Then
                dt = MachineMaintenanceDB.DispGV_MaintenanceRPT(Inst, Bran, type)
                If dt.Rows.Count = 0 Then
                    lblErrorMsg.Text = "No records to display"
                Else
                    Dim qrystring As String = "rptMaintainanceType.aspx?" & QueryStr.Querystring() & "&MaintenanceType=" & type
                    ClientScript.RegisterStartupScript(Me.GetType, "Startup", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80') </script>")
                End If
            ElseIf type = 5 Then
                Rdt = MachineMaintenanceDB.GetRPT_MachineMaintenence(Session("InstituteID"), Session("BranchID"), type)
                If Rdt.Rows.Count = 0 Then
                    lblErrorMsg.Text = "No records to display"
                Else
                    Dim qrystring As String = "rptMaintainanceType.aspx?" & QueryStr.Querystring() & "&MaintenanceType=" & type
                    ClientScript.RegisterStartupScript(Me.GetType, "Startup", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80') </script>")
                End If
            Else
                dt = MachineMaintenanceDB.DispGV_MaintenanceRPT(Inst, Bran, type)
                If dt.Rows.Count = 0 Then
                    lblErrorMsg.Text = "No records to display"
                Else
                    Dim qrystring As String = "rptMaintainanceType.aspx?" & QueryStr.Querystring() & "&MaintenanceType=" & type
                    ClientScript.RegisterStartupScript(Me.GetType, "Startup", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80') </script>")
                End If
            End If
        End If
    End Sub

    Sub DisplayGridValue()
        If ddlMainType.Items.Count > 0 Then
            Dim dt As New DataTable
            'Dim ins As Integer = Session("InstituteID")
            'Dim brn As Integer = Session("BranchID")
            Dim mnt As Integer = ddlMainType.SelectedItem.Value
            'dt = BLL.MachineMaintenenceGridFill(mnt)
            If dt.Rows.Count = 0 Then
                GridView1.DataSource = Nothing
                GridView1.DataBind()
                Panel1.Visible = False
            Else
                Panel1.Visible = True
                GridView1.DataSource = dt.DefaultView
                GridView1.Columns(0).Visible = False
                If ddlMainType.SelectedItem.Value = 1 Then
                    GridView1.Columns(9).Visible = False
                    GridView1.Columns(10).Visible = False
                    GridView1.Columns(11).Visible = False

                    GridView1.Columns(12).Visible = True
                    GridView1.Columns(13).Visible = True
                    GridView1.Columns(14).Visible = True
                    GridView1.Columns(15).Visible = True
                    GridView1.Columns(16).Visible = True
                    GridView1.Columns(17).Visible = True

                    GridView1.DataBind()
                ElseIf ddlMainType.SelectedItem.Value = 4 Then
                    GridView1.Columns(9).Visible = True
                    GridView1.Columns(10).Visible = True
                    GridView1.Columns(11).Visible = True

                    GridView1.Columns(12).Visible = False
                    GridView1.Columns(13).Visible = False
                    GridView1.Columns(14).Visible = False
                    GridView1.Columns(15).Visible = False
                    GridView1.Columns(16).Visible = False
                    GridView1.Columns(17).Visible = False
                    GridView1.DataBind()
                Else
                    GridView1.Columns(9).Visible = False
                    GridView1.Columns(10).Visible = False
                    GridView1.Columns(11).Visible = False
                    GridView1.Columns(12).Visible = False
                    GridView1.Columns(13).Visible = False
                    GridView1.Columns(14).Visible = False
                    GridView1.Columns(15).Visible = False
                    GridView1.Columns(16).Visible = False
                    GridView1.Columns(17).Visible = False
                    GridView1.DataBind()
                End If
            End If
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & ddlInstitute.ClientID & "').focus();</script>")
        lblErrorMsg.Text = ""
        ddlMainType.Focus()
        DisplayGridValue()
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("frmMaintenance.aspx")
    End Sub
    Protected Sub ddlMainType_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMainType.DataBound
        DisplayGridValue()
    End Sub
    Protected Sub ddlMainType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMainType.SelectedIndexChanged
        DisplayGridValue()
        'Dim inst As Integer = Session("InstituteID")
        'Dim bran As Integer = Session("BranchID")
        'Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "rptMaintainanceType.aspx?Insti=" & inst & "&Branch=" & bran & "&MaintenanceType=" & ddlMainType.SelectedItem.Value
        'ClientScript.RegisterStartupScript(Me.GetType, "Startup", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80') </script>")
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Machine Maintenance")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
