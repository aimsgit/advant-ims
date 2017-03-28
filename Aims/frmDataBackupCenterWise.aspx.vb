Imports System.IO
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WebForms
Imports System.Web.UI.WebControls.GridView
Imports System.Collections.Generic
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Web.UI.HtmlTextWriter

Partial Class frmDataBackupCenterWise
    Inherits BasePage
    Dim Bl As New BLfrmDataBackupCenterWise
    Dim EL As New ELfrmDataBackupCenterWise
    Dim DL As New DLfrmDataBackupCenterWise
    Dim dt, dt1 As New DataTable

    Protected Property Rows() As Integer
        Get
            If Not ViewState("Rows") Is Nothing Then
                Return CInt(Fix(ViewState("Rows")))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("Rows") = value
        End Set
    End Property

    ' Columns property to hold the Columns in the ViewState
    Protected Property Columns() As Integer
        Get
            If Not ViewState("Columns") Is Nothing Then
                Return CInt(Fix(ViewState("Columns")))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("Columns") = value
        End Set
    End Property
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        'If (btnView.ID = "btnView") Then
        'BtnExport.Visible = True
        PlaceHolder1.Controls.Clear()
        ' Fetch the number of Rows and Columns for the table 
        ' using the properties
        Dim tblRows As Integer = Rows
        Dim tblCols As Integer = Columns
        ' Create a Table and set its properties 
        Dim tbl As Table = New Table()
        ' Add the table to the placeholder control
        PlaceHolder1.Controls.Add(tbl)
        EL.BranchCode = ddlBranchName.SelectedValue

        If RbType.SelectedValue = "" Then
            lblError.Text = "Select a Table."
            Exit Sub
        Else
            lblError.Text = ""
            lblS.Text = ""
            EL.RbId = RbType.SelectedValue

            dt = Bl.GetGridData(EL)

            If dt.Rows.Count <> 0 Then
                lblError.Text = ""
                Dim Str(100) As String
                ID = ID.Replace("[", "")
                ID = ID.Replace("]", "")
                Str = ID.Split(",")
                Dim Row As Integer = dt.Rows.Count
                Dim column As Integer = dt.Columns.Count
                Dim photo As Integer = 0
                ' Now iterate through the table and add your controls 
                For r As Integer = -1 To Row - 1
                    'StrBuild.Append(vbCrLf + "|")
                    Dim tr As TableRow = New TableRow()
                    'tr.BorderColor = Drawing.Color.Black
                    'tr.BorderStyle = BorderStyle.Solid
                    For c As Integer = 0 To column - 1
                        'StrBuild.Append(dt.Rows(r)(c))
                        'StrBuild.Append("|")
                        Dim tc As TableCell = New TableCell()
                        Dim Label As Label = New Label()
                        If r = -1 Then
                            Label.Text = dt.Columns(c).ColumnName
                            'If Label.Text = "Student Photo" Then
                            '    photo = c
                            'End If
                            Label.ForeColor = Drawing.Color.Navy
                            Label.Font.Bold = True
                            ' Add the control to the TableCell
                            tc.Controls.Add(Label)
                            tc.Wrap = False
                            tc.VerticalAlign = VerticalAlign.Bottom
                            tc.HorizontalAlign = HorizontalAlign.Justify
                            ' Add the TableCell to the TableRow
                            tr.Cells.Add(tc)
                            tc.BorderColor = Drawing.Color.LightGray
                            tc.BorderStyle = BorderStyle.Ridge
                            tc.BorderWidth = 1.5
                        Else
                            If (dt.Rows(r)(c).ToString Is DBNull.Value) Then
                                Label.Text = "  "
                                Label.BorderColor = Drawing.Color.White
                                Label.BorderStyle = BorderStyle.None
                                Label.BorderWidth = 1
                                ' Add the control to the TableCell
                                tc.Controls.Add(Label)
                                tc.VerticalAlign = VerticalAlign.Bottom
                                tc.HorizontalAlign = HorizontalAlign.Left
                                ' Add the TableCell to the TableRow
                                tr.Cells.Add(tc)
                                tc.BorderColor = Drawing.Color.LightGray
                                tc.BorderStyle = BorderStyle.Ridge
                                tc.BorderWidth = 1
                            End If
                            If (dt.Rows(r)(c).ToString = "") Then
                                Label.Text = "  "
                                Label.BorderColor = Drawing.Color.White
                                Label.BorderStyle = BorderStyle.None
                                Label.BorderWidth = 1
                                ' Add the control to the TableCell
                                tc.Controls.Add(Label)
                                tc.VerticalAlign = VerticalAlign.Bottom
                                tc.HorizontalAlign = HorizontalAlign.Left
                                ' Add the TableCell to the TableRow
                                tr.Cells.Add(tc)
                                tc.BorderColor = Drawing.Color.LightGray
                                tc.BorderStyle = BorderStyle.Ridge
                                tc.BorderWidth = 1
                                '    End If
                                'Else
                                'Label.Text = " "
                                '' Add the control to the TableCell
                                'tc.Controls.Add(Label)
                                'tc.VerticalAlign = VerticalAlign.Bottom
                                'tc.HorizontalAlign = HorizontalAlign.Left
                                '' Add the TableCell to the TableRow
                                'tr.Cells.Add(tc)
                                'tc.BorderColor = Drawing.Color.LightGray
                                'tc.BorderStyle = BorderStyle.Ridge
                                'tc.BorderWidth = 1
                            Else
                                Label.Text = dt.Rows(r)(c).ToString
                                ' Add the control to the TableCell
                                tc.Controls.Add(Label)
                                tc.VerticalAlign = VerticalAlign.Bottom
                                tc.HorizontalAlign = HorizontalAlign.Left
                                ' Add the TableCell to the TableRow
                                tr.Cells.Add(tc)
                                tc.BorderColor = Drawing.Color.LightGray
                                tc.BorderStyle = BorderStyle.Ridge
                                tc.BorderWidth = 1
                                '    End If
                                'Else
                                'Label.Text = dt.Rows(r)(c).ToString
                                '' Add the control to the TableCell
                                'tc.Controls.Add(Label)
                                'tc.VerticalAlign = VerticalAlign.Bottom
                                'tc.HorizontalAlign = HorizontalAlign.Left
                                '' Add the TableCell to the TableRow
                                'tr.Cells.Add(tc)
                                'tc.BorderColor = Drawing.Color.LightGray
                                'tc.BorderStyle = BorderStyle.Ridge
                                'tc.BorderWidth = 1
                            End If
                        End If

                    Next
                    ' Add the TableRow to the Table
                    tbl.Rows.Add(tr)
                Next
                'lbldate.Text = Format(Now, "dd-MMM-yyyy hh:mm tt")
            Else
                lblError.Text = "No Records to Display."
                'Image1.Visible = False
                'HeaderPanel.Visible = False
                'lblerr.Visible = True
                'footerpanel.Visible = False
            End If
        End If
        ' This parameter helps determine in the LoadViewState event,
        ' whether to recreate the dynamic controls or not
        ViewState("dynamictable") = True
        'End If
    End Sub

    Protected Sub BtnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        Dim sw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()
        Dim GVDataBackupCenterWise As New GridView()
        GVDataBackupCenterWise.AllowPaging = False
        EL.BranchCode = ddlBranchName.SelectedValue
        Dim val = RbType.SelectedItem.Text
        EL.RbId = RbType.SelectedValue
        dt = Bl.GetGridData(EL)
        GVDataBackupCenterWise.DataSource = dt
        GVDataBackupCenterWise.DataBind()
        Dim style As String = "<style>.text {mso-number-format:\@;}</style>"
        Page.Response.AddHeader("content-disposition", "attachment;filename=" + val + ".xls")
        Page.Response.ContentType = "application/vnd.ms-excel"
        Page.Response.Charset = ""
        Page.EnableViewState = False
        frm.Attributes("runat") = "server"
        Controls.Add(frm)
        frm.Controls.Add(GVDataBackupCenterWise)
        frm.RenderControl(hw)
        Response.Write(style)
        'Response.Write(sw.ToString())
        Response.Output.Write(style & sw.ToString())
        Response.Flush()
        Response.End()
    End Sub
   
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not Page.IsPostBack Then
        '    BtnExport.Visible = True
        'End If
        If Not IsPostBack Then

            ddlBranchName.SelectedValue = Session("BranchCode")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + Panel2.ClientID + "').style.visibility='visible';", True)
        End If

       
    End Sub
End Class
