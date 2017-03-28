Partial Class frm16a
    Inherits BasePage
    Private Bll As New BL16a
    Private Prop As New E16a
    Private DAL As New DA16a
    'Dim DAL1 As New GlobalDataSetTableAdapters.Form16ATableAdapter
    Dim GlobalFunction As New GlobalFunction
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'ddlEmployee.DataSource = Bll.GetEmp
            'ddlEmployee.DataBind()
            ''gv16a.DataSource = DAL.showgrid(Prop)
            ''gv16a.DataBind()
            PnlAddrecord.Visible = False
            btnOK.Visible = True
            btnCancel.Visible = False
            btnPreview.Visible = False
            btnAdd.Visible = False
            ''pnlGrid.Visible = True
            gv16a.Visible = False
            btnCancl.Text = "Cancel"
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("frm16a.aspx")
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        '' pnlGrid.Visible = False
        ''gv16a.Visible = False
        btnPreview.Visible = False
        btnAdd.Visible = False
        PnlAddrecord.Visible = True
        btnCancel.Visible = False
    End Sub
    Protected Function GetEmpName(ByVal id As Long) As String
        Dim Emp As New EmployeeManager
        Dim d As EmpCombo = Emp.GetEmpID(id)
        Return d.Emp_Name
    End Function
    Protected Sub btnAddrecord_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddrecord.Click
        btnOK.Visible = False
        'Prop.Emp_name = ddlEmployee.SelectedItem.Text
        'Prop.Empid = ddlEmployee.SelectedItem.Value
        Prop.Emp_name = GlobalFunction.NameCutter(txtEmp.Text)
        Prop.Empid = GlobalFunction.IdCutter(txtEmp.Text)
        Prop.For_the_period = txtFortheperiod.Text
        Prop.Formid = txtFormID.Text
        Prop.Nature_of_payment = txtNatureofpayment.Text
        Prop.Duration = txtDuration.Text
        Prop.Taxable_amt = txtTaxableamount.Text
        Prop.deduction_date = txtDeductiondate.Text
        Prop.TDS = txtTDS.Text
        Prop.Surcharges = txtSurcharges.Text
        Prop.Education_cess = txtEducationcess.Text
        Prop.Tax_amt = txttaxamt.Text
        Prop.Payment_details = txtPaymentdetails.Text
        Prop.BSR = txtBSR.Text
        Prop.Payment_date = txtPaymentdate.Text
        Prop.Payment_identification_no = txtPayIdentificationno.Text
        Dim a As Int16 = DAL.check(Prop)
        If (a = 0) Then
            DAL.send(Prop)
            msginfo.Text = "The record is saved successfully."
            btnOK_Click(sender, e)
        Else
            MsgBox("Give Correct FormID")
        End If
        btnCancl.Text = "OK"
        ''Response.Redirect("frm16a.aspx")
    End Sub
    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Prop.Emp_name = ddlEmployee.SelectedItem.Text
        'Prop.Empid = ddlEmployee.SelectedItem.Value
        Prop.Emp_name = GlobalFunction.NameCutter(txtEmp.Text)
        Prop.Empid = GlobalFunction.IdCutter(txtEmp.Text)
        Prop.Duration = txtFortheperiod.Text
        ''DAL.showgrid(Prop)
        ''gv16a.DataSource = DAL.showgrid(Prop)
        ''gv16a.DataBind()
        gv16a.Visible = True
        ObjectDataSource1.SelectMethod = "GetDataByEmp"
        ObjectDataSource1.SelectParameters.Clear()
        ObjectDataSource1.SelectParameters.Add("Id", GlobalFunction.IdCutter(txtEmp.Text))
        ObjectDataSource1.SelectParameters.Add("duration", txtFortheperiod.Text)
        gv16a.DataSourceID = "ObjectDataSource1"
        gv16a.DataBind()
        btnCancel.Visible = True
        btnPreview.Visible = True
        btnAdd.Visible = True
        btnOK.Visible = False
    End Sub
    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        'Prop.Emp_name = ddlEmployee.SelectedItem.Text
        'Prop.Empid = ddlEmployee.SelectedItem.Value
        If txtEmp.Text <> "" Then
            Prop.Emp_name = GlobalFunction.NameCutter(txtEmp.Text)
            Prop.Empid = GlobalFunction.IdCutter(txtEmp.Text)
        Else
            Prop.Emp_name = 0
            Prop.Empid = 0
        End If
        If txtFortheperiod.Text <> "" Then
            Prop.Duration = txtFortheperiod.Text
        Else
            Prop.Duration = 0
        End If
        Dim qrystring As String = "Form16aRPT.aspx?" & QueryStr.Querystring() & "&tr=" & Prop.Empid & "&Duration=" & Prop.Duration
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    End Sub
    Protected Sub btnCancl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancl.Click
        Response.Redirect("frm16a.aspx")
    End Sub

    Protected Sub gv16a_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gv16a.RowDeleting
        'Dim id = gv16a.SelectedRow.RowIndex
        'Dim id = gv16a.Rows(e.RowIndex)
        Dim id = CInt(CType(gv16a.Rows(e.RowIndex).Cells(2).FindControl("lblId"), HiddenField).Value)
        Dim rows As Int64 = Bll.Del16a(id)
    End Sub

    Protected Sub gv16a_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gv16a.RowUpdating
        '' Prop.Empid = CType(gv16a.Rows(e.RowIndex).Cells(1).Controls(0), LiteralControl).Text
        ''Prop.Formid = CType(gv16a.Rows(e.RowIndex).Cells(2).Controls(0), LiteralControl).Text
        '' Prop.Empid = gv16a.Rows(e.RowIndex).Cells(1).Text
        ''Dim hdnid As New HiddenField()

        ''hdnid.Value = gv16a.SelectedRow.Cells(2).Text
        ''Prop.Formid = CInt(hdnid.Value)
        ''Prop.Empid = CType(gv16a.Rows(e.RowIndex).Cells(1).Controls(0), TextBox).Text
        ''Prop.Formid = CType(gv16a.Rows(e.RowIndex).Cells(2).Controls(0), TextBox).Text
        ''Prop.Nature_of_payment = CType(gv16a.Rows(e.RowIndex).Cells(3).Controls(0), TextBox).Text
        ''Prop.Duration = CType(gv16a.Rows(e.RowIndex).Cells(4).Controls(0), TextBox).Text
        ''Prop.Taxable_amt = CType(gv16a.Rows(e.RowIndex).Cells(5).Controls(0), TextBox).Text
        ''Prop.deduction_date = CType(gv16a.Rows(e.RowIndex).Cells(6).Controls(0), TextBox).Text
        ''Prop.TDS = CType(gv16a.Rows(e.RowIndex).Cells(7).Controls(0), TextBox).Text
        ''Prop.Surcharges = CType(gv16a.Rows(e.RowIndex).Cells(8).Controls(0), TextBox).Text
        ''Prop.Education_cess = CType(gv16a.Rows(e.RowIndex).Cells(9).Controls(0), TextBox).Text
        ''Prop.Tax_amt = CType(gv16a.Rows(e.RowIndex).Cells(10).Controls(0), TextBox).Text
        ''Prop.Payment_details = CType(gv16a.Rows(e.RowIndex).Cells(11).Controls(0), TextBox).Text
        ''Prop.BSR = CType(gv16a.Rows(e.RowIndex).Cells(12).Controls(0), TextBox).Text
        ''Prop.Payment_date = CType(gv16a.Rows(e.RowIndex).Cells(13).Controls(0), TextBox).Text
        ''Prop.Payment_identification_no = CType(gv16a.Rows(e.RowIndex).Cells(14).Controls(0), TextBox).Text
        ''Dim rows As Int64 = Bll.Update16a(Prop)
    End Sub

    Protected Sub AutoCompleteExtender2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender2.PreRender
        Dim str1 As String
        Try

            If txtEmp.Text <> "" Then
                str1 = GlobalFunction.IdCutter(txtEmp.Text)
            End If
        Catch
            txtEmp.Text = "Not a valid Name.Try again."
            txtEmp.ForeColor = Drawing.Color.Red
        End Try
    End Sub
    Protected Sub gv16a_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        '    Dim id = gv16a.SelectedRow.RowIndex
        '    Dim Formid = CInt(CType(gv16a.Rows(id).Cells(3).FindControl("Label2"), Label).Text)
        '    Dim rows As Int64 = Bll.Del16a(Formid)
        '    gv16a.DataBind()
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
