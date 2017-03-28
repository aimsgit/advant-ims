Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Partial Class FrmCompnyName
    Inherits BasePage
    Dim Ent As New ELInvestment
    Dim BL As New BLInvestment
    Dim dt As DataTable
    Dim EmpIdA As Integer


    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If Session("Privilages").ToString.Contains("W") Then

            If (Session("BranchCode") = Session("ParentBranch")) Then
                TxtLICP.Focus()
                If BtnSave.Text = "SUBMIT" Then
                    ' Ent.EmpIDAuto = HidempId.Value
                    Ent.EmpID = txtEmp.Text
                    Ent.Address = txtADDRESS.Text
                    Ent.EmpName = txtempc.Text
                    Ent.PanNo = txtpannum.Text
                    If txtdoj.Text = "" Then
                        Ent.DOJ = "1/1/1900"
                    Else
                        Ent.DOJ = txtdoj.Text
                    End If
                    Ent.Email = txtemail.Text
                    Ent.AccountNo = txtbankacct.Text
                    Ent.PropertyLocation = Txtlocationofprop.Text
                    Ent.Dependent1 = TextBox3.Text
                    Ent.DepRelation1 = TextBox4.Text
                    Ent.Dependent2 = TextBox5.Text
                    Ent.DepRelation2 = TextBox6.Text
                    Ent.Dependent3 = TextBox7.Text
                    Ent.DepRelation3 = TextBox8.Text
                    Ent.Dependent4 = TextBox9.Text
                    Ent.DepRelation4 = TextBox10.Text
                    Ent.Dependent5 = TextBox11.Text
                    Ent.DepRelation5 = TextBox12.Text
                    Ent.Dependent6 = TextBox13.Text
                    Ent.DepRelation6 = TextBox14.Text
                    Ent.Dependent7 = TextBox15.Text
                    Ent.DepRelation7 = TextBox16.Text
                    Ent.CellNo = txtcellnum.Text
                    Ent.ID_ID = HidII_ID.Value
                    If ChkAll.Checked = True Then
                        Ent.Agree = "Y"
                    Else
                        Ent.Agree = "N"
                    End If
                    assign()
                    BL.InsertRecord(Ent)
                    BtnSave.Text = "SUBMIT"
                    lblGreen.Text = "Data Saved Successfully."
                    lblRed.Text = ""
                End If
            Else
                lblRed.Text = "You do not belong to this branch, cannot submit data."
                lblGreen.Text = ""
            End If

        Else
            lblRed.Text = "You do not have Write Privilage."
        End If
    End Sub
    Public Sub clear()
        txtEmp.Text = ""
        txtADDRESS.Text = ""
        txtempc.Text = ""
        txtpannum.Text = ""
        txtdoj.Text = ""
        txtemail.Text = ""
        txtemail.Text = ""
        txtbankacct.Text = ""
        Txtlocationofprop.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox11.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        txtcellnum.Text = ""
        TxtLICP.Text = ""
        TxtPPF.Text = ""
        TxtNSCs.Text = ""
        Txtintersternnc.Text = ""
        TXTULIP.Text = ""
        TXTELLS.Text = ""
        TxtnotifiedMF.Text = ""
        TxtPHL.Text = ""
        TxtCEF.Text = ""
        TxtTDFP.Text = ""
        txtNewjeevan.Text = ""
        TxtSSS.Text = ""
        TxtOthers.Text = ""
        TextBox1.Text = ""
        TxtmedicalhealthChkp.Text = ""
        TxtMIMT.Text = ""
        TxtIEL.Text = ""
        TxtDeuctioRes.Text = ""
        txtsectopm80G.Text = ""
        Txtrent.Text = ""
        TxtIntrstOnHouse.Text = ""
        Txtonemonthbasic.Text = ""
        TxtMedRemb.Text = ""
        TxtIntrntExpns.Text = ""
        txtpetroldsl.Text = ""
        lblRed.Text = ""
    End Sub
    Public Sub assign()
        If TxtLICP.Text = "" Then
            Ent.LICPremium = 0
        Else
            Ent.LICPremium = TxtLICP.Text
        End If

        If TxtPPF.Text = "" Then
            Ent.PPF = 0
        Else
            Ent.PPF = TxtPPF.Text
        End If

        If TxtNSCs.Text = "" Then
            Ent.NSC = 0
        Else
            Ent.NSC = TxtNSCs.Text
        End If

        If Txtintersternnc.Text = "" Then
            Ent.IntOnNSC = 0
        Else
            Ent.IntOnNSC = Txtintersternnc.Text
        End If

        If TXTULIP.Text = "" Then
            Ent.ULIP = 0
        Else
            Ent.ULIP = TXTULIP.Text
        End If

        If TXTELLS.Text = "" Then
            Ent.ELSS = 0
        Else
            Ent.ELSS = TXTELLS.Text
        End If

        If TxtnotifiedMF.Text = "" Then
            Ent.NotdMutualFund = 0
        Else
            Ent.NotdMutualFund = TxtnotifiedMF.Text
        End If

        If TxtPHL.Text = "" Then
            Ent.PrincipalHL = 0
        Else
            Ent.PrincipalHL = TxtPHL.Text
        End If

        If TxtCEF.Text = "" Then
            Ent.ChildEduFee = 0
        Else
            Ent.ChildEduFee = TxtCEF.Text
        End If

        If TxtTDFP.Text = "" Then
            Ent.FixedDeposit = 0
        Else
            Ent.FixedDeposit = TxtTDFP.Text
        End If

        If txtNewjeevan.Text = "" Then
            Ent.AnnuityPlan = 0
        Else
            Ent.AnnuityPlan = txtNewjeevan.Text
        End If

        If TxtSSS.Text = "" Then
            Ent.SalSavScheme = 0
        Else
            Ent.SalSavScheme = TxtSSS.Text
        End If

        If TxtOthers.Text = "" Then
            Ent.Others = 0
        Else
            Ent.Others = TxtOthers.Text
        End If

        If TextBox1.Text = "" Then
            Ent.Sec80CCC = 0
        Else
            Ent.Sec80CCC = TextBox1.Text
        End If

        If TxtmedicalhealthChkp.Text = "" Then
            Ent.Sec80D = 0
        Else
            Ent.Sec80D = TxtmedicalhealthChkp.Text
        End If

        If TxtMIMT.Text = "" Then
            Ent.Sec80DD = 0
        Else
            Ent.Sec80DD = TxtMIMT.Text
        End If

        If TxtIEL.Text = "" Then
            Ent.Sec80E = 0
        Else
            Ent.Sec80E = TxtIEL.Text
        End If

        If TxtDeuctioRes.Text = "" Then
            Ent.Sec80U = 0
        Else
            Ent.Sec80U = TxtDeuctioRes.Text
        End If

        If txtsectopm80G.Text = "" Then
            Ent.Sec80G = 0
        Else
            Ent.Sec80G = txtsectopm80G.Text
        End If


        If Txtrent.Text = "" Then
            Ent.Rent = 0
        Else
            Ent.Rent = Txtrent.Text
        End If

        If TxtIntrstOnHouse.Text = "" Then
            Ent.InterestOnHL = 0
        Else
            Ent.InterestOnHL = TxtIntrstOnHouse.Text
        End If

        If Txtonemonthbasic.Text = "" Then
            Ent.LTA = 0
        Else
            Ent.LTA = Txtonemonthbasic.Text
        End If

        If TxtMedRemb.Text = "" Then
            Ent.MedicalReimbursement = 0
        Else
            Ent.MedicalReimbursement = TxtMedRemb.Text
        End If

        If TxtIntrntExpns.Text = "" Then
            Ent.InternetExp = 0
        Else
            Ent.InternetExp = TxtIntrntExpns.Text
        End If

        If TxtTelExpns.Text = "" Then
            Ent.TelephoneExp = 0
        Else
            Ent.TelephoneExp = TxtTelExpns.Text
        End If

        If txtpetroldsl.Text = "" Then
            Ent.FuelReimbursement = 0
        Else
            Ent.FuelReimbursement = txtpetroldsl.Text
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            Try
                If Session("EmpName") <> "" Then
                    Dim dt As New DataTable
                    dt = BL.EmpAutofill(Ent)
                    If dt.Rows.Count > 0 Then
                        HidII_ID.Value = dt.Rows(0).Item("II_ID").ToString

                        'txtfinanceyrs.Text = dt.Rows(0).Item("FinancialYear").ToString
                        txtfinanceyrs.Text = Format(CDate(Session("FinStartDate")), "yyyy") + "-" + Format(CDate(Session("FinEndDate")), "yy")
                        'frmbal()
                        txtEmp.Text = dt.Rows(0).Item("Emp_Code").ToString
                        txtempc.Text = dt.Rows(0).Item("Emp_Name").ToString
                        txtADDRESS.Text = dt.Rows(0).Item("Emp_Address").ToString
                        Ent.Address = txtADDRESS.Text
                        txtpannum.Text = dt.Rows(0).Item("PanNo").ToString
                        Ent.PanNo = txtpannum.Text
                        txtdoj.Text = Format(dt.Rows(0).Item("DOJ"), "dd-MMM-yyyy").ToString
                        If txtdoj.Text = "" Then
                            Ent.DOJ = "1/1/1900"
                        Else
                            Ent.DOJ = txtdoj.Text
                        End If

                        'If txtcellnum.Text = "" Then
                        txtcellnum.Text = dt.Rows(0).Item("ContactNo").ToString
                        'If txtcellnum.Text = "" Then
                        '    Ent.CellNo = 0
                        'Else
                        'Ent.CellNo = txtcellnum.Text
                        'End If
                        txtemail.Text = dt.Rows(0).Item("Email").ToString
                        Ent.Email = txtemail.Text
                        txtbankacct.Text = dt.Rows(0).Item("AccountNo").ToString
                        Ent.AccountNo = txtbankacct.Text

                        If dt.Rows(0).Item("LICPremium").ToString = "" Then
                            TxtLICP.Text = ""
                        Else
                            TxtLICP.Text = Format(dt.Rows(0).Item("LICPremium"), "0.00")
                        End If

                        If dt.Rows(0).Item("PPF").ToString = "" Then
                            TxtPPF.Text = ""
                        Else
                            TxtPPF.Text = Format(dt.Rows(0).Item("PPF"), "0.00")
                        End If


                        If dt.Rows(0).Item("NSC").ToString = "" Then
                            TxtNSCs.Text = ""
                        Else
                            TxtNSCs.Text = Format(dt.Rows(0).Item("NSC"), "0.00")

                        End If


                        If dt.Rows(0).Item("IntOnNSC").ToString = "" Then
                            Txtintersternnc.Text = ""
                        Else
                            Txtintersternnc.Text = Format(dt.Rows(0).Item("IntOnNSC"), "0.00")
                        End If

                        If dt.Rows(0).Item("ULIP").ToString = "" Then
                            TXTULIP.Text = ""
                        Else
                            TXTULIP.Text = Format(dt.Rows(0).Item("ULIP"), "0.00")
                        End If

                        If dt.Rows(0).Item("ELSS").ToString = "" Then
                            TXTELLS.Text = ""
                        Else
                            TXTELLS.Text = Format(dt.Rows(0).Item("ELSS"), "0.00")
                        End If

                        If dt.Rows(0).Item("NotdMutualFund").ToString = "" Then
                            TxtnotifiedMF.Text = ""
                        Else
                            TxtnotifiedMF.Text = Format(dt.Rows(0).Item("NotdMutualFund"), "0.00")
                        End If
                        If dt.Rows(0).Item("PrincipalHL").ToString = "" Then
                            TxtPHL.Text = ""
                        Else
                            TxtPHL.Text = Format(dt.Rows(0).Item("PrincipalHL"), "0.00")
                        End If

                        If dt.Rows(0).Item("ChildEduFee").ToString = "" Then
                            TxtCEF.Text = ""
                        Else
                            TxtCEF.Text = Format(dt.Rows(0).Item("ChildEduFee"), "0.00")
                        End If

                        If dt.Rows(0).Item("FixedDeposit").ToString = "" Then
                            TxtTDFP.Text = ""
                        Else
                            TxtTDFP.Text = Format(dt.Rows(0).Item("FixedDeposit"), "0.00")
                        End If

                        If dt.Rows(0).Item("AnnuityPlan").ToString = "" Then
                            txtNewjeevan.Text = ""
                        Else
                            txtNewjeevan.Text = Format(dt.Rows(0).Item("AnnuityPlan"), "0.00")
                        End If

                        If dt.Rows(0).Item("SalSavScheme").ToString = "" Then
                            TxtSSS.Text = ""
                        Else
                            TxtSSS.Text = Format(dt.Rows(0).Item("SalSavScheme"), "0.00")
                        End If

                        If dt.Rows(0).Item("Others").ToString = "" Then
                            TxtOthers.Text = ""
                        Else
                            TxtOthers.Text = Format(dt.Rows(0).Item("Others"), "0.00")
                        End If

                        If dt.Rows(0).Item("Sec80CCC").ToString = "" Then
                            TextBox1.Text = ""
                        Else
                            TextBox1.Text = Format(dt.Rows(0).Item("Sec80CCC"), "0.00")
                        End If

                        If dt.Rows(0).Item("Sec80D").ToString = "" Then
                            TxtmedicalhealthChkp.Text = ""
                        Else
                            TxtmedicalhealthChkp.Text = Format(dt.Rows(0).Item("Sec80D"), "0.00")
                        End If

                        If dt.Rows(0).Item("Sec80DD").ToString = "" Then
                            TxtMIMT.Text = ""
                        Else
                            TxtMIMT.Text = Format(dt.Rows(0).Item("Sec80DD"), "0.00")
                        End If

                        If dt.Rows(0).Item("Sec80E").ToString = "" Then
                            TxtIEL.Text = ""
                        Else
                            TxtIEL.Text = Format(dt.Rows(0).Item("Sec80E"), "0.00")
                        End If

                        If dt.Rows(0).Item("Sec80U").ToString = "" Then
                            TxtDeuctioRes.Text = ""
                        Else
                            TxtDeuctioRes.Text = Format(dt.Rows(0).Item("Sec80U"), "0.00")
                        End If

                        If dt.Rows(0).Item("Sec80G").ToString = "" Then
                            txtsectopm80G.Text = ""
                        Else
                            txtsectopm80G.Text = Format(dt.Rows(0).Item("Sec80G"), "0.00")
                        End If

                        If dt.Rows(0).Item("Rent").ToString = "" Then
                            Txtrent.Text = ""
                        Else
                            Txtrent.Text = Format(dt.Rows(0).Item("Rent"), "0.00")
                        End If

                        Txtlocationofprop.Text = dt.Rows(0).Item("PropertyLocation").ToString
                        Ent.PropertyLocation = Txtlocationofprop.Text

                        If dt.Rows(0).Item("InterestOnHL").ToString = "" Then
                            TxtIntrstOnHouse.Text = ""
                        Else
                            TxtIntrstOnHouse.Text = Format(dt.Rows(0).Item("InterestOnHL"), "0.00")
                        End If

                        If dt.Rows(0).Item("LTA").ToString = "" Then
                            Txtonemonthbasic.Text = ""
                        Else
                            Txtonemonthbasic.Text = Format(dt.Rows(0).Item("LTA"), "0.00")
                        End If

                        If dt.Rows(0).Item("MedicalReimbursement").ToString = "" Then
                            TxtMedRemb.Text = ""
                        Else
                            TxtMedRemb.Text = Format(dt.Rows(0).Item("MedicalReimbursement"), "0.00")
                        End If

                        If dt.Rows(0).Item("InternetExp").ToString = "" Then
                            TxtIntrntExpns.Text = ""
                        Else
                            TxtIntrntExpns.Text = Format(dt.Rows(0).Item("InternetExp"), "0.00")
                        End If

                        If dt.Rows(0).Item("TelephoneExp").ToString = "" Then
                            TxtTelExpns.Text = ""
                        Else
                            TxtTelExpns.Text = Format(dt.Rows(0).Item("TelephoneExp"), "0.00")
                        End If

                        If dt.Rows(0).Item("FuelReimbursement").ToString = "" Then
                            txtpetroldsl.Text = ""
                        Else
                            txtpetroldsl.Text = Format(dt.Rows(0).Item("FuelReimbursement"), "0.00")
                        End If
                        TextBox3.Text = dt.Rows(0).Item("Dependent1").ToString
                        Ent.Dependent1 = TextBox3.Text
                        TextBox4.Text = dt.Rows(0).Item("DepRelation1").ToString
                        Ent.DepRelation1 = TextBox4.Text
                        TextBox5.Text = dt.Rows(0).Item("Dependent2").ToString
                        Ent.Dependent2 = TextBox5.Text
                        TextBox6.Text = dt.Rows(0).Item("DepRelation2").ToString
                        Ent.DepRelation2 = TextBox6.Text
                        TextBox7.Text = dt.Rows(0).Item("Dependent3").ToString
                        Ent.Dependent3 = TextBox7.Text
                        TextBox8.Text = dt.Rows(0).Item("DepRelation3").ToString
                        Ent.DepRelation3 = TextBox8.Text
                        TextBox9.Text = dt.Rows(0).Item("Dependent4").ToString
                        Ent.Dependent4 = TextBox9.Text
                        TextBox10.Text = dt.Rows(0).Item("DepRelation4").ToString
                        Ent.DepRelation4 = TextBox10.Text
                        TextBox11.Text = dt.Rows(0).Item("Dependent5").ToString
                        Ent.Dependent5 = TextBox11.Text
                        TextBox12.Text = dt.Rows(0).Item("DepRelation5").ToString
                        Ent.DepRelation5 = TextBox12.Text
                        TextBox13.Text = dt.Rows(0).Item("Dependent6").ToString
                        Ent.Dependent6 = TextBox13.Text
                        TextBox14.Text = dt.Rows(0).Item("DepRelation6").ToString
                        Ent.DepRelation6 = TextBox14.Text
                        TextBox15.Text = dt.Rows(0).Item("Dependent7").ToString
                        Ent.Dependent7 = TextBox15.Text
                        TextBox16.Text = dt.Rows(0).Item("DepRelation7").ToString
                        Ent.DepRelation7 = TextBox16.Text
                    End If
                Else
                    ErrorMsg.Text = "Not Accessible for Institute Admin."
                    lblGreen.Text = ""
                    lblRed.Text = ""
                    BtnSave.Enabled = False
                End If
            Catch ex As Exception
                ErrorMsg.Text = "Not Accessible for Institute Admin."
                lblGreen.Text = ""
                lblRed.Text = ""
                BtnSave.Enabled = False
            End Try
        End If
        TxtLICP.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
  
End Class
