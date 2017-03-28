Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports System.Drawing

Partial Class frm_ImportStdCode
    Inherits BasePage
    Dim DL As New DLImportStdCode
    Dim dt, dt1, dt3, dt4 As New DataTable


    Protected Sub btnupdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdate.Click


        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                Dim dt2 As New Table
                Dim TempCode As String
                Dim UniversityCode As String
                For Each grid As GridViewRow In GVImport.Rows
                    TempCode = CType(grid.FindControl("LabelStdCode"), Label).Text.ToString
                    UniversityCode = CType(grid.FindControl("LabelStdname"), Label).Text.ToString

                    DLImportStdCode.Update(TempCode, UniversityCode)
                Next

                lblerrmsg.Text = ""
                lblmsgifo.Text = "Data Updated Successfully."
                txtData.Text = ""
            Catch ex As Exception
                lblerrmsg.Text = ""
                lblmsgifo.Text = ""
            End Try
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        'If Not IsPostBack Then
        '   
        'End If
    End Sub

    Protected Sub btnimport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnimport.Click


        If (Session("BranchCode") = Session("ParentBranch")) Then

            lblerrmsg.Text = " "
            lblmsgifo.Text = ""
            Dim row, col, count, count1, recordupdate As Integer
            Dim check As String
            recordupdate = recordupdate + 1
            Try
                Dim store As String = txtData.Text
                'Dim rowdata() As String = store.Split("\n")

                Dim rowdata As String() = store.Split(ControlChars.CrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                'Dim rowdata As String() = store.Split(ControlChars.CrLf.ToCharArray)
                ' CChar(vbCrLf)
            
                row = 0


                Dim dcID = New DataColumn("TemporaryNumber", GetType(String))
                Dim dcName = New DataColumn("UniversityNumber", GetType(String))
                Dim StdName = New DataColumn("Name", GetType(String))
                Dim AcademicYear = New DataColumn("AcademicYear", GetType(String))
                Dim Batch = New DataColumn("Batch", GetType(String))

                dt.Columns.Add(dcID)
                dt.Columns.Add(dcName)
                dt.Columns.Add(StdName)
                dt.Columns.Add(AcademicYear)
                dt.Columns.Add(Batch)
                'For i = 1 To 10
                '    dt.Rows.Add(i, "Row #" & i)
                'Next
                Dim name As String
                Dim name1 As String
                Dim Std As String
                Dim Academic As String
                Dim BatchNo As String
                ' el.BatchId = rowdata(0).ToString
                While row <= rowdata.Count - 1
                    Dim coldata As String = rowdata(row).ToString
                    Dim coldata1 As String() = coldata.Split(New Char() {vbTab})
                    Dim coldata2 As String = ""
                    Dim coldata3 As String = ""
                    Dim coldata4 As String = ""
                    col = 0
                    'Dim count As Integer = coldata1.Count
                    While col <= coldata1.Count - 1
                        'Dim coldata As String = rowdata(row - 1).ToString
                        'Dim coldata1 As String() = coldata.Split(New Char() {vbTab})
                        name = coldata1(0).Trim
                        name1 = coldata1(1).Trim
                        'Std = coldata2(2).Trim
                        'Academic = coldata3(3).Trim
                        'BatchNo = coldata4(4).Trim
                        col = col + 1

                    End While
                    dt4 = DLImportStdCode.ImportStdCode2(name)
                    If dt4.Rows.Count > 0 Then
                        dt.Rows.Add(name, name1, Std, Academic, BatchNo)
                    End If
                    row = row + 1
                    'dt.Rows.Add(name, name1, Std, Academic, BatchNo)
                    'row = row + 1
                End While
                If dt.Rows.Count > 0 Then
                    GVImport.DataSource = dt
                    GVImport.DataBind()

                Else
                    lblerrmsg.Text = "No Records to Display."
                    GVImport.Visible = False
                    lblmsgifo.Text = ""
                    Exit Sub
                End If
                For Each grid As GridViewRow In GVImport.Rows

                    check = CType(grid.FindControl("LabelStdCode"), Label).Text.ToString
                    ID = ID + "," + check

                Next
                dt3 = DLImportStdCode.ImportStdCode1(ID)
                If dt3.Rows.Count > 0 Then


                    For Each grid As GridViewRow In GVImport.Rows

                        ID = CType(grid.FindControl("LabelStdCode"), Label).Text.ToString
                        dt1 = DLImportStdCode.ImportStdCode(ID)
                        If dt1.Rows.Count > 0 Then

                            CType(grid.FindControl("Label2"), Label).Text = dt1.Rows(0).Item(0)
                            CType(grid.FindControl("Label3"), Label).Text = dt1.Rows(0).Item(3)
                            CType(grid.FindControl("Label1"), Label).Text = dt1.Rows(0).Item(4)
                            lblmsgifo.Text = "Record(s) Generated Successfully."
                            GVImport.Visible = True
                        End If
                    Next
                    'dt1 = DLImportStdCode.ImportStdCode(ID)
                    'If dt1.Rows.Count > 0 Then
                    '    GridView1.DataSource = dt1
                    '    GridView1.DataBind()
                    '    panel1.Visible = False
                    'Else
                    '    lblerrmsg.Text = "No Record Display."
                    'End If
                Else
                    lblerrmsg.Text = "No Records to Display."
                    GVImport.Visible = False
                    lblmsgifo.Text = ""
                    Exit Sub
                End If
            Catch ex As Exception
                lblerrmsg.Text = " "
                lblmsgifo.Text = ""
            End Try
        End If
    End Sub

    Protected Sub btnclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnclear.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                lblerrmsg.Text = ""
                lblmsgifo.Text = ""
                GVImport.DataSource = Nothing
                GVImport.DataBind()
                lblmsgifo.Text = "Data Cleared Successfully."
            Catch ex As Exception
                lblerrmsg.Text = ""
                lblmsgifo.Text = ""


            End Try
        End If
    End Sub
End Class
