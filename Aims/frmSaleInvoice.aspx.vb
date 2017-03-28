
Partial Class frmSaleInvoice
    Inherits BasePage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            'txtFromDate.Text = Format(Today, "dd-MMM-yyyy")
            'txtToDate.Text = Format(Today, "dd-MMM-yyyy")
            txtInvdate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub

    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim dt2 As DataTable
        Dim openclosestatus As Integer = Request.QueryString.Get(("openclosestatus"))
        If openclosestatus = 0 Then
            If ChkBoxHeader.Checked = False Then
                Dim ID As String = Request.QueryString.Get(("ID"))
                Dim BranchCode As String = Request.QueryString.Get(("BranchCode"))
                Dim SetUp As String = Request.QueryString.Get(("SetUp"))
                Dim setupcharge As Double = Request.QueryString.Get(("setupcharge"))

                Dim Fromdate As String
                Dim ToDate As String
                Dim Yearfrom As String
                Dim YearTo As String
                Dim InvoiceNo As String
                Dim Invdate As Date
                If txtInvdate.Text = "" Then
                    Invdate = Format(Today(), "dd-MMM-yyyy")
                Else
                    Invdate = txtInvdate.Text
                End If

                Fromdate = cmbFrom.SelectedValue
                ToDate = CmbTo.SelectedValue
                InvoiceNo = txtInvoiceNo.Text
               
                If txtInvoiceNo.Text = "" Then
                    lblmsg.Text = " Enter Invoice Number."
                    lblmsgG.Text = ""
                Else

                    'dt2 = DLClientContractMaster.ChkDuplicateData(InvoiceNo)
                    'If dt2.Rows.Count > 0 Then
                    '    lblmsg.Text = "Data is already generated."
                    '    lblmsgG.Text = ""
                    'Else
                    Yearfrom = ddlYear.SelectedItem.ToString
                    YearTo = ddlYearTo.SelectedItem.ToString
                    If Yearfrom > YearTo Then
                        lblmsg.Text = "From Year cannot be Greater than To Year."
                        lblmsgG.Text = ""
                    Else
                        If Yearfrom = YearTo Then
                            If Fromdate > ToDate Then
                                lblmsg.Text = "From Month cannot be Greater than To Month."
                                lblmsgG.Text = ""
                            Else
                                lblmsg.Text = ""
                                lblmsgG.Text = ""
                                If SetUp = "True" Then
                                    Dim qrystring As String = "RPT_SaleInvoiceV.aspx?" & QueryStr.Querystring() & "&Branch_Code=" & BranchCode & "&ID=" & ID & "&FromDate=" & Fromdate & "&ToDate=" & ToDate & "&SetUp=" & SetUp & "&Yearfrom=" & Yearfrom & "&YearTo=" & YearTo & "&InvoiceNo=" & InvoiceNo & "&setupcharge=" & setupcharge & "&Invdate=" & Invdate
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
                                Else
                                    Dim qrystring As String = "RPT_SaleInvoiceV1.aspx?" & QueryStr.Querystring() & "&Branch_Code=" & BranchCode & "&ID=" & ID & "&FromDate=" & Fromdate & "&ToDate=" & ToDate & "&SetUp=" & SetUp & "&Yearfrom=" & Yearfrom & "&YearTo=" & YearTo & "&InvoiceNo=" & InvoiceNo & "&setupcharge=" & setupcharge & "&Invdate=" & Invdate
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
                                End If
                            End If

                        Else
                            lblmsg.Text = ""
                            lblmsgG.Text = ""
                            If SetUp = "True" Then
                                Dim qrystring As String = "RPT_SaleInvoiceV.aspx?" & QueryStr.Querystring() & "&Branch_Code=" & BranchCode & "&ID=" & ID & "&FromDate=" & Fromdate & "&ToDate=" & ToDate & "&SetUp=" & SetUp & "&Yearfrom=" & Yearfrom & "&YearTo=" & YearTo & "&InvoiceNo=" & InvoiceNo & "&setupcharge=" & setupcharge & "&Invdate=" & Invdate
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
                            Else
                                Dim qrystring As String = "RPT_SaleInvoiceV1.aspx?" & QueryStr.Querystring() & "&Branch_Code=" & BranchCode & "&ID=" & ID & "&FromDate=" & Fromdate & "&ToDate=" & ToDate & "&SetUp=" & SetUp & "&Yearfrom=" & Yearfrom & "&YearTo=" & YearTo & "&InvoiceNo=" & InvoiceNo & "&setupcharge=" & setupcharge & "&Invdate=" & Invdate
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
                            End If
                        End If


                    End If
                    'End If
                End If


            Else
                Dim ID As String = Request.QueryString.Get(("ID"))
                Dim BranchCode As String = Request.QueryString.Get(("BranchCode"))
                Dim SetUp As String = Request.QueryString.Get(("SetUp"))
                Dim setupcharge As Double = Request.QueryString.Get(("setupcharge"))
                Dim Fromdate As Integer
                Dim ToDate As Integer
                Dim Yearfrom As Integer
                Dim YearTo As Integer
                Dim InvoiceNo As String
                Dim Invdate As Date
                If txtInvdate.Text = "" Then
                    Invdate = Format(Today(), "dd-MMM-yyyy")
                Else
                    Invdate = txtInvdate.Text
                End If
                Fromdate = cmbFrom.SelectedValue
                ToDate = CmbTo.SelectedValue
                InvoiceNo = txtInvoiceNo.Text

                If txtInvoiceNo.Text = "" Then
                    lblmsg.Text = " Enter Invoice Number."
                    lblmsgG.Text = ""
                Else
                    'dt2 = DLClientContractMaster.ChkDuplicateData(InvoiceNo)
                    'If dt2.Rows.Count > 0 Then
                    '    lblmsg.Text = "Data is already generated."
                    '    lblmsgG.Text = ""
                    'Else
                    Yearfrom = ddlYear.SelectedItem.ToString
                    YearTo = ddlYearTo.SelectedItem.ToString
                    If Yearfrom > YearTo Then
                        lblmsg.Text = "From Year cannot be Greater than To Year."
                        lblmsgG.Text = ""
                    Else
                        If Yearfrom = YearTo Then
                            If Fromdate > ToDate Then
                                lblmsg.Text = "From Month cannot be Greater than To Month."
                                lblmsgG.Text = ""
                            Else
                                lblmsg.Text = ""
                                If SetUp = "True" Then
                                    Dim qrystring As String = "RPT_SaleInvoiceV2.aspx?" & QueryStr.Querystring() & "&Branch_Code=" & BranchCode & "&ID=" & ID & "&FromDate=" & Fromdate & "&ToDate=" & ToDate & "&SetUp=" & SetUp & "&Yearfrom=" & Yearfrom & "&YearTo=" & YearTo & "&InvoiceNo=" & InvoiceNo & "&setupcharge=" & setupcharge & "&Invdate=" & Invdate
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
                                Else
                                    Dim qrystring As String = "RPT_SaleInvoiceV3.aspx?" & QueryStr.Querystring() & "&Branch_Code=" & BranchCode & "&ID=" & ID & "&FromDate=" & Fromdate & "&ToDate=" & ToDate & "&SetUp=" & SetUp & "&Yearfrom=" & Yearfrom & "&YearTo=" & YearTo & "&InvoiceNo=" & InvoiceNo & "&setupcharge=" & setupcharge & "&Invdate=" & Invdate
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
                                End If
                            End If

                        Else
                            lblmsg.Text = ""
                            If SetUp = "True" Then
                                Dim qrystring As String = "RPT_SaleInvoiceV2.aspx?" & QueryStr.Querystring() & "&Branch_Code=" & BranchCode & "&ID=" & ID & "&FromDate=" & Fromdate & "&ToDate=" & ToDate & "&SetUp=" & SetUp & "&Yearfrom=" & Yearfrom & "&YearTo=" & YearTo & "&InvoiceNo=" & InvoiceNo & "&setupcharge=" & setupcharge & "&Invdate=" & Invdate
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
                            Else
                                Dim qrystring As String = "RPT_SaleInvoiceV3.aspx?" & QueryStr.Querystring() & "&Branch_Code=" & BranchCode & "&ID=" & ID & "&FromDate=" & Fromdate & "&ToDate=" & ToDate & "&SetUp=" & SetUp & "&Yearfrom=" & Yearfrom & "&YearTo=" & YearTo & "&InvoiceNo=" & InvoiceNo & "&setupcharge=" & setupcharge & "&Invdate=" & Invdate
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
                            End If
                        End If


                    End If
                    'End If
                End If
            End If

        Else
            lblmsg.Text = "Cannot Generate data Contract is already closed."

        End If
    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click

        Dim Chkid As Integer
        If ChkBoxHeader.Checked = True Then
            Chkid = 1
        Else
            Chkid = 0
        End If
        Dim SetUp As String = Request.QueryString.Get(("SetUp"))
        Dim InvoiceNo As String
        InvoiceNo = txtInvoiceNo.Text
        Dim BranchCode As String = Request.QueryString.Get(("BranchCode"))

        If txtInvoiceNo.Text = "" Then
            lblmsg.Text = " Enter Invoice Number."
            lblmsgG.Text = ""
        Else

            lblmsg.Text = ""
            lblmsgG.Text = ""
            Dim qrystring As String = "RPT_SaleInvoiceVeiw.aspx?" & QueryStr.Querystring() & "&BranchCode=" & BranchCode & "&InvoiceNo=" & InvoiceNo & "&Chkid=" & Chkid & "&SetUp=" & SetUp
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)

        End If
    End Sub
    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click

        'Dim ID As String = Request.QueryString.Get(("ID"))
        'Dim BranchCode As String = Request.QueryString.Get(("BranchCode"))
        'Dim SetUp As String = Request.QueryString.Get(("SetUp"))

        Dim InvoiceNo As String
        InvoiceNo = txtInvoiceNo.Text
        'Dim BranchCode As String = Request.QueryString.Get(("BranchCode"))

        If txtInvoiceNo.Text = "" Then
            lblmsg.Text = " Enter Invoice Number."
            lblmsgG.Text = ""
        Else

            'If DLClientContractMaster.ClearInvoiceData(InvoiceNo) = 0 Then
            '    lblmsg.Text = "Data connot be cleared."
            '    lblmsgG.Text = ""
            'Else
            '    lblmsgG.Text = "Data is cleared."
            '    lblmsg.Text = ""
            'End If
        End If

    End Sub

    Protected Sub btnPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Dim ID As String = Request.QueryString.Get(("ID"))
        Dim InvoiceNo As String
        InvoiceNo = txtInvoiceNo.Text
        'Dim BranchCode As String = Request.QueryString.Get(("BranchCode"))
        Dim SetUp As String = Request.QueryString.Get(("SetUp"))
        If txtInvoiceNo.Text = "" Then
            lblmsg.Text = " Enter Invoice Number."
            lblmsgG.Text = ""
        Else

            If DLClientContractMaster.PostData(InvoiceNo, ID, SetUp) = 0 Then
                lblmsg.Text = "Data cannot be posted."
                lblmsgG.Text = ""
            Else
                lblmsgG.Text = "Data is Posted."
                lblmsg.Text = ""
            End If
        End If
    End Sub
End Class


