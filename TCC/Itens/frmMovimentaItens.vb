Imports MySql.Data.MySqlClient

Public Class frmMovimentaItens
    Dim quantidade As Integer = 0

    Private Sub frmMovimentaItens_Load(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Activated

        carregaDgv()
        carregaCbo2()
    End Sub
    Private Sub carregaDgv()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            dgvItens.Invoke(Sub()
                                dgvItens.Columns.Clear()
                                dgvItens.ClearSelection()
                                dgvItens.DataSource = Nothing
                                dgvItens.Refresh()
                                dgvItens.AllowDrop = False
                                dgvItens.AllowUserToAddRows = False
                                dgvItens.AllowUserToResizeRows = False
                                dgvItens.AllowUserToDeleteRows = False
                                dgvItens.AllowUserToOrderColumns = False
                                dgvItens.AllowUserToResizeColumns = False
                                dgvItens.MultiSelect = False
                            End Sub)
            sql = ""
            sql += "SELECT id_item, nm_item, quantidade  FROM itens i "

            Dim numeric As New NumericUpDownColumn
            With numeric
                .HeaderText = "Quantidade"
                .Name = "qtd"
                .AutoSizeMode =
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With

            Dim CheckBox As New DataGridViewCheckBoxColumn()
            With CheckBox
                .CellTemplate = New DataGridViewCheckBoxCell()
                .HeaderText = ""
                .Name = "cbkMenu"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .FlatStyle = FlatStyle.Standard
            End With


            'Dim txt As New DataGridViewTextBoxColumn
            'With txt
            '    .CellTemplate = New DataGridViewTextBoxCell()
            '    .HeaderText = ""
            '    .Name = "aa"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    '.FlatStyle = FlatStyle.Standard
            'End With

            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)

            dgvItens.Invoke(Sub()
                                dgvItens.DataSource = ds.Tables(0)
                                dgvItens.Columns.Insert(0, CheckBox)
                                dgvItens.Columns(0).Width = 10

                                dgvItens.Columns(1).Visible = False

                                dgvItens.Columns(2).HeaderText = "Item"
                                dgvItens.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(2).ReadOnly = True

                                dgvItens.Columns(3).HeaderText = "Quantidade em estoque"
                                dgvItens.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                                dgvItens.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(3).ReadOnly = True

                                dgvItens.Columns.Insert(4, numeric)

                                dgvItens.Columns(4).HeaderText = "Qtd a ser movida"
                                ' dgvItens.Columns(4).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                                'dgvItens.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
                                'dgvItens.Columns(4).ReadOnly = True

                            End Sub)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub
    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvItens.EditingControlShowing
       ' Dim tb As TextBox = CType(e.Control, TextBox)
        'AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
    End Sub
    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = vbBack Then
            e.Handled = True
        End If
    End Sub
    Private Sub carregaCbo2()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String
        Try

            sql = ""
            sql += "SELECT 0 'id_usuario','Selecione um usuário' nm_usuario FROM DUAL UNION ALL SELECT id_usuario,nm_usuario FROM usuarios"

            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)
            Dim filtro As DataView = ds.Tables(0).DefaultView
            filtro.RowFilter = ""
            cboUsuarios.DataSource = filtro.ToTable(True, "id_usuario", "nm_usuario")
            cboUsuarios.Invoke(Sub()
                                   With cboUsuarios
                                       .ValueMember = "id_usuario"
                                       .DisplayMember = "nm_usuario"
                                       .SelectedIndex = -1
                                       .Text = ""
                                   End With
                               End Sub)
            cboUsuarios.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        quantidade = 0
    End Sub

    Private Sub btnConfima_Click(sender As Object, e As EventArgs) Handles btnConfima.Click

        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim conn2 As New MySqlConnection(My.Settings.conexao)
        Dim sql As String
        Dim msg As Integer = 0
        Dim msg2 As Integer = 0
        For i As Integer = 0 To dgvItens.Rows.Count - 1
            If dgvItens.Rows(i).Cells(0).Value = True Then
                msg += 1
            End If
        Next

        If msg = 0 Then
            MsgBox("Selecione pelo menos um item", vbExclamation, "Atenção!!")
            Exit Sub
        End If

        Try
            For i As Integer = 0 To dgvItens.Rows.Count - 1
                If dgvItens.Rows(i).Cells(0).Value = True Then
                    If dgvItens.Rows(i).Cells(4).Value <= dgvItens.Rows(i).Cells(3).Value Then
                        sql = ""
                        sql += "UPDATE itens SET quantidade = quantidade-" & dgvItens.Rows(i).Cells(4).Value & " WHERE id_item =" & dgvItens.Rows(i).Cells(1).Value
                        conn.Close()
                        conn.Open()

                        Dim comando As New MySqlCommand(sql, conn)
                        comando.ExecuteReader()

                        sql = ""
                        sql += "INSERT INTO movimenta_itens (id_responsavel,id_receptor,data_mov_it,quantidade_movida,id_item) "
                        sql += " VALUES('" & id_usuario & "',"
                        sql += cboUsuarios.SelectedValue.ToString + ","
                        sql += "NOW(),"
                        sql += dgvItens.Rows(i).Cells(4).Value.ToString
                        sql += ", " & dgvItens.Rows(i).Cells(1).Value & ")"
                        conn2.Close()
                        conn2.Open()

                        Dim comando2 As New MySqlCommand(sql, conn2)
                        comando2.ExecuteReader()
                        msg2 += 1
                    Else
                        MsgBox("O do item " & dgvItens.Rows(i).Cells(2).Value.ToString & " não foi movido por falta no estoque", vbExclamation, "Atenção")
                    End If
                End If
            Next

            If msg2 >= 1 Then
                If msg = 1 Then
                    MsgBox("O item foi movido com sucesso", vbInformation, "Atenção!!")
                Else
                    MsgBox("Os itens foram movidos com sucesso", vbInformation, "Atenção")
                End If
                carregaDgv()
                carregaCbo2()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    Private Sub dgvItens_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellClick
        dgvItens.BeginEdit(True)

    End Sub
End Class