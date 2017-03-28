
Partial Class frmLateralEntry
    Inherits BasePage
    Dim BAL As New LateralEntryB
    Dim DA As New LateralEntryDB
    Dim lateral As New LateralEntry
    Dim code As String
    Sub Parameters()
        lateral = New LateralEntry
        lateral.Id = 0
        lateral.StdCode = code
        lateral.AdmissionYear = Me.txtadmissionyear.Text
        lateral.FeePaid = Me.txtfee.Text
        lateral.AttendedExam = Me.txtattendedexam.Text
    End Sub
    Public Sub GetInputParameters(ByVal source As Object, ByVal e As ObjectDataSourceMethodEventArgs)
        Parameters()
        e.InputParameters.Clear()
        e.InputParameters.Add("l", lateral)
    End Sub
    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        odsLateralEntry.Insert()
        GV_lateralentry.DataBind()
        txtadmissionyear.Text = ""
        txtfee.Text = ""
        txtattendedexam.Text = ""
    End Sub
    Sub UpdateParameters()
        lateral = New LateralEntry
        lateral.Id = CType(GV_lateralentry.Rows(GV_lateralentry.EditIndex).Cells(0).FindControl("LID"), HiddenField).Value
        lateral.StdCode = CType(GV_lateralentry.Rows(GV_lateralentry.EditIndex).Cells(1).FindControl("Hcode"), HiddenField).Value
        lateral.AdmissionYear = CType(GV_lateralentry.Rows(GV_lateralentry.EditIndex).Cells(2).FindControl("txtadmissionyear"), TextBox).Text
        lateral.FeePaid = CType(GV_lateralentry.Rows(GV_lateralentry.EditIndex).Cells(3).FindControl("txtfee"), TextBox).Text
        lateral.AttendedExam = CType(GV_lateralentry.Rows(GV_lateralentry.EditIndex).FindControl("txtattendedexam"), TextBox).Text
    End Sub
    Public Sub GetUpdateParameters(ByVal source As Object, ByVal e As ObjectDataSourceMethodEventArgs)
        UpdateParameters()
        e.InputParameters.Clear()
        e.InputParameters.Add("l", lateral)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        code = Request.QueryString("StdCode")
    End Sub
    Protected Sub odsLateralEntry_Deleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles odsLateralEntry.Deleted
        odsLateralEntry.DataObjectTypeName = ""
    End Sub

    Protected Sub odsLateralEntry_Deleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles odsLateralEntry.Deleting
        odsLateralEntry.DataObjectTypeName = "Qualification"
    End Sub

    Protected Sub odsLateralEntry_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles odsLateralEntry.Inserted
        GV_lateralentry.DataBind()
    End Sub
    Public Sub GetCertiIssued(ByVal source As Object, ByVal e As ObjectDataSourceMethodEventArgs)
        Dim certiIssued As New CertificateIssuedLateral
        certiIssued.Qualification_ID = 0
        certiIssued.Std_code = code
        certiIssued.Name = txtExam.Text
        certiIssued.Board_Univ = txtboard.text
        certiIssued.YearofPassing = txtyear.text
        certiIssued.Marks = txtmarks.text
        e.InputParameters.Clear()
        e.InputParameters.Add("ci", certiIssued)
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        odCertiIssued.Insert()
        GV_CertiIssued.DataBind()
        Me.txtExam.Text = ""
        Me.txtboard.Text = ""
        Me.txtyear.Text = ""
        Me.txtmarks.Text = ""
    End Sub
    Public Sub UpdateCertiIssued(ByVal source As Object, ByVal e As ObjectDataSourceMethodEventArgs)
        Dim certiIssued As New CertificateIssuedLateral
        certiIssued.Qualification_ID = CType(GV_CertiIssued.Rows(GV_CertiIssued.EditIndex).Cells(0).FindControl("Qualification_ID"), HiddenField).Value
        certiIssued.Std_code = CType(GV_CertiIssued.Rows(GV_CertiIssued.EditIndex).Cells(1).FindControl("Hcode"), HiddenField).Value
        certiIssued.Name = CType(GV_CertiIssued.Rows(GV_CertiIssued.EditIndex).Cells(2).FindControl("txt_QID"), TextBox).Text
        certiIssued.Board_Univ = CType(GV_CertiIssued.Rows(GV_CertiIssued.EditIndex).Cells(3).FindControl("TextBox4"), TextBox).Text
        certiIssued.Marks = CType(GV_CertiIssued.Rows(GV_CertiIssued.EditIndex).Cells(4).FindControl("TextBox3"), TextBox).Text
        certiIssued.YearofPassing = CType(GV_CertiIssued.Rows(GV_CertiIssued.EditIndex).FindControl("TextBox2"), TextBox).Text
        e.InputParameters.Clear()
        e.InputParameters.Add("ci", certiIssued)
    End Sub

    Protected Sub odCertiIssued_Deleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles odCertiIssued.Deleted
        odCertiIssued.DataObjectTypeName = ""
    End Sub

    Protected Sub odCertiIssued_Deleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles odCertiIssued.Deleting
        odCertiIssued.DataObjectTypeName = "CertificateIssuedLateral"
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Response.Redirect("Registration.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
