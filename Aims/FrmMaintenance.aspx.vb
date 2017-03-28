Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Partial Class FrmMaintenance
    Inherits BasePage
    'Dim SLL As New StudentResult.StdResultB
    Dim CLL As New CourseManager
    Dim BLL As New MachineMaintenenceBL
    Dim Prop As New MachineMaintenence
    Dim GlobalFunction As New GlobalFunction
    Dim id1 As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblErrorMsg.Text = ""
        ddlMainType.Focus()
        If Not IsPostBack Then
            PnlNeedle.Visible = False
            PnlMachineBroke.Visible = False
            Institute_Branch(sender, e)
        End If
    End Sub

    Sub Batch()
    End Sub

    Sub MainType(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddlMainType.SelectedItem.Value <> "Select" Then
            PnlNeedle.Visible = True
        Else
            PnlNeedle.Visible = False
        End If
        If ddlMainType.SelectedItem.Value <> "Select" Then
            PnlMachineBroke.Visible = True
        Else
            PnlMachineBroke.Visible = False
        End If
    End Sub

    Sub Manufacture(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddlManufacture.Items.Count > 0 Then
            GetMachineType()
        End If
        If ddlMachineType.Items.Count <> 0 Then
            ModelSerial()
            'Course()
        End If
    End Sub

    Sub MachineType(ByVal sender As Object, ByVal e As System.EventArgs)
        ddlManufacture.DataSource = ""
        ddlManufacture.DataBind()
        ddlMachineType.DataSource = ""
        ddlMachineType.DataBind()
        ddlModel.DataSource = ""
        ddlModel.DataBind()
        ddlSerial.DataSource = ""
        ddlSerial.DataBind()
    End Sub

    Sub Institute_Branch(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dt As New DataTable
        'Dim ins As Integer = Session("InstituteID")
        'Dim brn As Integer = Session("BranchID")
        dt = BLL.GetMaintnceManufByIB()
        If dt.Rows.Count = 0 Then
            MachineType(sender, e)
        Else
            ddlManufacture.DataSource = dt
            ddlManufacture.DataBind()
            Manufacture(sender, e)
        End If
    End Sub

    'Sub course()
    '    Dim dt As New DataTable
    '    'Dim ins As Integer = Session("InstituteID")
    '    'Dim brn As Integer = Session("BranchID")
    '    dt = CLL.CourseFrmDispCourse()
    '    'If dt.Rows.Count = 0 Then
    '    '    'ddlCourse.DataSource = ""
    '    '    'ddlCourse.DataBind()
    '    '    'ddlBatch.DataSource = ""
    '    '    'ddlBatch.DataBind()
    '    'Else
    '    '    'ddlCourse.DataSource = dt
    '    '    'ddlCourse.DataBind()
    '    'End If
    'End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            'ObjMaintenance.Insert()
            Prop.EntryDate = Format(Today, "dd-MMM-yyyy")
            Prop.MachineMake = ddlManufacture.SelectedItem.Value
            Prop.MachineModel = ddlModel.SelectedItem.Value
            Prop.MachineNo = ddlSerial.SelectedItem.Value
            Prop.MachineType = ddlMachineType.SelectedItem.Value
            Prop.MaintenenceType = ddlMainType.SelectedItem.Value
            Prop.CleanedDate = txtServiceDate.Text
            Prop.DueDate = txtDueDate.Text
            Prop.TimeStopped = txtTStopped.Text
            Prop.PartChanged = txtPchanged.Text
            Prop.TimeRun = txtTRun.Text
            Prop.Operation = txtOperation.Text
            Prop.OperationName = txtOName.Text
            Prop.Needle = txtNeedle.Text
            Prop.Parts = txtParts.Text
            If ddlCourse.Text <> "" Then
                Prop.CourseId = GlobalFunction.IdCutter(ddlCourse.Text)
            ElseIf ddlBatch.Text <> "" Then
                Prop.BatchNo = GlobalFunction.IdCutter(ddlBatch.Text)
            End If
            Prop.Remarks = txtRemarks.Text
            'Prop.InstituteId = Session("InstituteID")
            'Prop.BranchId = Session("BranchID")
            BLL.Insert(Prop)
            lblErrorMsg.Text = "Data Saved SuccessFully"
        Catch ex As Exception
            lblErrorMsg.Text = "Enter all the values"
            'MsgBox("Enter all th values")
            'Response.Write(ex.ToString)
        End Try
        'Clear()
    End Sub

    Sub Clear()
        ddlManufacture.SelectedItem.Selected = False
        ddlModel.SelectedItem.Selected = False
        ddlSerial.SelectedItem.Selected = False
        ddlMachineType.SelectedItem.Selected = False
        ddlMainType.SelectedItem.Selected = False
        ddlModel.SelectedItem.Selected = False
        ddlSerial.SelectedItem.Selected = False
        txtServiceDate.Text = ""
        txtDueDate.Text = ""
        txtTStopped.Text = ""
        txtPchanged.Text = ""
        txtTRun.Text = ""
        txtOperation.Text = ""
        txtOName.Text = ""
        txtNeedle.Text = ""
        txtParts.Text = ""
        txtRemarks.Text = ""
        ddlMachineType.SelectedItem.Text = ""
        ddlSerial.SelectedItem.Text = ""
        ddlModel.SelectedItem.Text = ""
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        DisplayGridValue()
    End Sub


    'Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
    '    MyBase.ValidateFormView("Machine Maintenance")
    'End Sub

    Sub GetMachineType()
        ddlMachineType.DataSource = BLL.GetMachinMaintenenceByIBMf(ddlManufacture.SelectedItem.Value)
        ddlMachineType.DataBind()
    End Sub
    Sub ModelSerial()
        ddlModel.DataSource = BLL.GetMachinMaintnceByIBMfMt(ddlMachineType.SelectedItem.Value, ddlManufacture.SelectedItem.Value)
        ddlModel.DataBind()
        ddlSerial.DataSource = BLL.GetMachinMaintnceByIBMfMt(ddlMachineType.SelectedItem.Value, ddlManufacture.SelectedItem.Value)
        ddlSerial.DataBind()
    End Sub

    Protected Sub ddlManufacture_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlManufacture.SelectedIndexChanged
        GetMachineType()
        If ddlMachineType.Items.Count > 0 Then
            ModelSerial()
        Else
            ddlModel.DataSource() = ""
            ddlModel.DataBind()
            ddlSerial.DataSource() = ""
            ddlSerial.DataBind()
        End If
    End Sub

    Protected Sub ddlMachineType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMachineType.SelectedIndexChanged
        ModelSerial()
    End Sub

    'Protected Sub AutoCompleteExtender2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender2.PreRender
    '    Try
    '        Session("sesInstitute") = Session("Office")
    '        Session("sesbranch") = Session("BranchCode")
    '        If ddlCourse.Text <> "" Then
    '            Session("sesCourse") = GlobalFunction.IdCutter(ddlCourse.Text)
    '        End If
    '    Catch
    '        ddlCourse.Text = "Not a valid option.Try again."
    '        ddlCourse.ForeColor = Drawing.Color.Red
    '    End Try
    'End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
    Sub DisplayGridValue()
        If ddlMainType.Items.Count > 0 Then
            Dim dt As New DataTable
            'Dim ins As Integer = Session("InstituteID")
            'Dim brn As Integer = Session("BranchID")
            Dim mnt As Integer = ddlMainType.SelectedItem.Value
            id1 = ViewState("MID")
            dt = BLL.MachineMaintenenceGridFill(mnt, id1)
            If dt.Rows.Count = 0 Then
                GridView1.DataSource = Nothing
                GridView1.DataBind()
                'Panel1.Visible = False
            Else
                'Panel1.Visible = True
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

   
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim ID As HiddenField = CType(GridView1.Rows(e.RowIndex).Cells(2).FindControl("MID"), HiddenField)
        Dim i As Integer
        i = ID.Value
        BLL.ChangeFlag(i)
        DisplayGridValue()
        lblErrorMsg.Text = "Data Deleted SuccessFully"
    End Sub
    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging

        GridView1.PageIndex = e.NewPageIndex

    End Sub
End Class
