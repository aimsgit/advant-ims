Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class FeeCollectionBL
    Dim a As New feeCollectionDL
    'Public Function GetStudentCode(ByVal prefixText As String) As Data.DataTable
    '    'Return feeCollectionDL.GetStudent(prefixText)
    'End Function
    Public Function SemesterCombo() As Data.DataTable
        Return a.SemesterComboD()
    End Function

    Public Function SemesterCombo1(ByVal batch As Integer) As Data.DataTable
        Return a.SemesterComboD1(batch)
    End Function

    Public Function SemesterComboAss() As Data.DataTable
        Return a.SemesterComboAsse()
    End Function
    Public Function SemesterComboNew(ByVal batch As Integer) As Data.DataTable
        Return a.SemesterComboDNew(batch)
    End Function
    Public Function SemesterCombo12(ByVal batch As Integer) As Data.DataTable
        Return a.SemesterCombo12(batch)
    End Function
    Public Function SemesterCombo2(ByVal batch As Integer) As Data.DataTable
        Return a.SemesterCombo2(batch)
    End Function
    Public Function BankCombo() As Data.DataTable
        Return a.BankComboD()
    End Function
    Public Function PaymentMethodCombo() As Data.DataTable
        Return a.PaymentMethodComboD()
    End Function
  
    Public Function getGrd1(ByVal b As Integer, ByVal AYear As Integer, ByVal Category As Integer) As Data.DataTable
        Return a.getGrd1(b, AYear, Category)
    End Function

    Public Function TotalFeePaid(ByVal STD_ID As Integer, ByVal Semester As Integer) As Data.DataTable
        Return a.TotalFeePaid(STD_ID, Semester)
    End Function
    Public Function getGrd2(ByVal El As FeeCollectionEl) As Data.DataTable
        Return a.getGrd2(El)
    End Function
    Public Function InsertRecord(ByVal b As FeeCollectionEl) As Integer
        Return a.InsertRecord(b)
    End Function
    Public Function insert(ByVal b As FeeCollectionEl) As Integer
        Return a.insert(b)   'created by shailesh for adhoc
    End Function
    Public Function UpdateRecord(ByVal El As FeeCollectionEl) As Integer
        Return a.UpdateRecord(El)
    End Function

    Public Function Update(ByVal El As FeeCollectionEl) As Integer
        Return a.Update(El)
    End Function
    'Public Function getFeecollection(ByVal stdid As Integer) As Data.DataTable
    '    Return a.getFeecollection(stdid)
    'End Function
    Public Function getFeecollection(ByVal stdid As Integer, ByVal Sem As Integer) As Data.DataTable
        Return a.getFeecollection(stdid, Sem)
    End Function
    Public Function ChangeFlag(ByVal El As FeeCollectionEl) As Integer
        Return feeCollectionDL.ChangeFlag(El)
    End Function
    Public Function FeeCollectionReport(ByVal Bat As String, ByVal Sem As String, ByVal Payment As Integer, ByVal StudentCode As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CollectionType As Integer) As Data.DataTable

        Return a.FeeCollectionReport(Bat, Sem, Payment, StudentCode, StartDate, EndDate, CollectionType)
    End Function
    Public Function FeeCollectionStudentWiseReport(ByVal AT As String, ByVal Bat As String, ByVal Sem As String, ByVal StudentCode As Integer) As Data.DataTable

        Return a.FeeCollectionStudentWiseReport(AT, Bat, Sem, StudentCode)
    End Function
    Public Function GetSemesterCombo() As DataTable
        Return feeCollectionDL.GetSemesterCombo()
    End Function
    Public Function getAdhocFeecollection(ByVal El As FeeCollectionEl) As Data.DataTable
        Return a.getAdhocFeeCollection(El)         'Created by shailesh
    End Function
    Public Function SemesterCombo121(ByVal batch As Integer) As Data.DataTable
        Return a.SemesterCombo121(batch)
    End Function
    Public Function PostFeeCollection(ByVal i As String) As Integer
        Return a.PostFeeCollection(i)
    End Function
    Public Function SemesterCombo122(ByVal BranchCode As String, ByVal batch As Integer) As Data.DataTable
        Return a.SemesterCombo122(BranchCode, batch)
    End Function

    Public Function SemCombo(ByVal batch As Integer) As Data.DataTable
        Return a.SemComboD(batch)   'Created by Jina
    End Function

    Public Function SemCombo1(ByVal batch As Integer) As Data.DataTable
        Return a.SemCombo1D(batch)   'Created by Jina
    End Function
    Public Function AdhocFeeCollectionReport(ByVal Payment As Integer, ByVal FeeHead As Integer, ByVal StartDate As Date, ByVal EndDate As Date) As Data.DataTable

        Return a.AdhocFeeCollectionReport(Payment, FeeHead, StartDate, EndDate)
    End Function
End Class
