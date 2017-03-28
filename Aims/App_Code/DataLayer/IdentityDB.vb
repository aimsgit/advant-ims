Imports System.Data
Imports System.Data.SqlClient

Namespace GlobalDataSetTableAdapters

    Partial Public Class IdentityCardTableAdapter
        'Private _transaction As OleDbTransaction
        'Private Property Transaction() As OleDbTransaction
        '    Get
        '        Return Me._transaction
        '    End Get
        '    Set(ByVal value As OleDbTransaction)
        '        Me._transaction = value
        '    End Set
        'End Property
        Private _transaction As SqlTransaction
        Private Property Transaction() As SqlClient.SqlTransaction
            Get
                Return Me._transaction
            End Get
            Set(ByVal value As SqlTransaction)
                Me._transaction = value
            End Set
        End Property

        'Public Sub BeginTransaction()
        '    If Me.Connection.State <> ConnectionState.Open Then
        '        Me.Connection.Open()
        '    End If

        '    Me.Transaction = Me.Connection.BeginTransaction()
        '    For Each command As SqlCommand In Me.CommandCollection
        '        command.Transaction = Me.Transaction
        '    Next
        '    Me.Adapter.InsertCommand.Transaction = Me.Transaction
        '    Me.Adapter.UpdateCommand.Transaction = Me.Transaction
        '    Me.Adapter.DeleteCommand.Transaction = Me.Transaction
        'End Sub

        'Public Sub CommitTransaction()
        '    Me.Transaction.Commit()
        '    Me.Connection.Close()
        'End Sub
        'Public Sub RollbackTransaction()
        '    Me.Transaction.Rollback()
        '    Me.Connection.Close()
        'End Sub
        'Public Function UpdateWithTransaction(ByVal dataTable As GlobalDataSet.IdentityCardDataTable) As Integer
        '    Me.BeginTransaction()
        '    Try
        '        Dim returnValue As Integer = Me.Adapter.Update(dataTable)
        '        Me.CommitTransaction()
        '        Return returnValue
        '    Catch
        '        Me.RollbackTransaction()
        '        Throw
        '    End Try
        'End Function
    End Class
End Namespace

 