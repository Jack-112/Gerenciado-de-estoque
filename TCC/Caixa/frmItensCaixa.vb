Imports MySql.Data.MySqlClient
Public Class frmItensCaixa
    Dim idItem As Integer = 0
    Dim idCaixa As Integer = 0
    Public valor_final As Decimal = 0
    Dim valor As Double = 0

    Private Sub frmItensCaixa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dgvItens.Invoke(Sub()
                            dgvItens.Columns.Clear()
                            dgvItens.ClearSelection()
                            dgvItens.DataSource = Nothing
                            dgvItens.Refresh()
                            dgvItens.AllowDrop = False
                            dgvItens.AllowUserToAddRows = False
                            dgvItens.AllowUserToResizeRows = False
                            dgvItens.AllowUserToOrderColumns = False
                            dgvItens.AllowUserToResizeColumns = False
                            dgvItens.MultiSelect = False
                        End Sub)
        carregaCbo()
    End Sub

    'Private Sub carregaCbo2()
    '    Dim conn As New MySqlConnection(My.Settings.conexao)
    '    Dim sql As String
    '    Try
    '        dgvItens.Invoke(Sub()
    '                            dgvItens.Columns.Clear()
    '                            dgvItens.ClearSelection()
    '                            dgvItens.DataSource = Nothing
    '                            dgvItens.Refresh()
    '                            dgvItens.AllowDrop = False
    '                            dgvItens.AllowUserToAddRows = False
    '                            dgvItens.AllowUserToResizeRows = False
    '                            dgvItens.AllowUserToOrderColumns = False
    '                            dgvItens.AllowUserToResizeColumns = False
    '                            dgvItens.MultiSelect = False
    '                        End Sub)

    '        sql = ""
    '        sql += "SELECT 0 'id_item','Selecione um item' nm_item,'' data_validade,'' valor_venda FROM DUAL UNION ALL SELECT id_item,nm_item,data_validade,valor_venda FROM tcc.itens"

    '        conn.Close()
    '        conn.Open()

    '        Dim comando As New MySqlCommand(sql, conn)
    '        Dim dr As New MySqlDataAdapter(comando)
    '        Dim ds As New DataTable
    '        dr.Fill(ds)
    '        Dim filtro As DataView = ds.DefaultView
    '        filtro.RowFilter = ""
    '        cboItens.DataSource = filtro.ToTable(True, "id_item", "nm_item")
    '        cboItens.Invoke(Sub()
    '                            With cboItens
    '                                .ValueMember = "id_item"
    '                                .DisplayMember = "nm_item"
    '                                .SelectedIndex = -1
    '                                .Text = ""
    '                            End With
    '                        End Sub)
    '        cboItens.SelectedIndex = 0
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        conn.Close()
    '        conn.Dispose()
    '    End Try
    'End Sub
    Private Sub carregaCbo()
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
                                dgvItens.AllowUserToOrderColumns = False
                                dgvItens.AllowUserToResizeColumns = False
                                dgvItens.MultiSelect = False
                            End Sub)

            sql = ""
            sql += "SELECT 0 'id_caixa','Selecione uma embalagem' nm_caixa FROM DUAL UNION ALL SELECT id_caixa,nm_caixa FROM caixas WHERE id_caixa NOT IN (SELECT id_caixa FROM caixas_fechadas)"

            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)
            Dim filtro As DataView = ds.Tables(0).DefaultView
            filtro.RowFilter = ""
            cboCaixa.DataSource = filtro.ToTable(True, "id_caixa", "nm_caixa")
            cboCaixa.Invoke(Sub()
                                With cboCaixa
                                    .ValueMember = "id_caixa"
                                    .DisplayMember = "nm_caixa"
                                    .SelectedIndex = -1
                                    .Text = ""
                                End With
                            End Sub)
            cboCaixa.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    'Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
    '    'If txtQuantidade.Value <= 0 Then
    '    '    MsgBox("Informe a quantidade ", vbExclamation, "Atenção")
    '    '    Exit Sub
    '    'End If
    '    Dim conn As New MySqlConnection(My.Settings.conexao)
    '    Dim sql As String

    '    Try
    '        sql = ""
    '        sql += "SELECT id_item,i.nm_item,c.nm_classe'ds_item',codigo_barras,DATE_FORMAT(i.data_validade,'%d/%m/%Y')data_validade,REPLACE(i.valor_venda,'.',',')valor_venda FROM tcc.itens i INNER JOIN classe_item c ON(i.classe_item=c.id_classe_item) WHERE id_item = " & cboItens.SelectedValue
    '        conn.Close()
    '        conn.Open()

    '        Dim comando As New MySqlCommand(sql, conn)
    '        Dim dr As MySqlDataReader = comando.ExecuteReader()
    '        If dr.Read Then
    '            valor = dr("valor_venda")
    '            ValorFinal()
    '            If dgvItens.Rows.Count = 0 Then
    '                dgvItens.Columns.Add(columnName:="IdItem", headerText:="IdItem")
    '                dgvItens.Columns.Add(columnName:="nomeItem", headerText:="Item")
    '                dgvItens.Columns.Add(columnName:="classe", headerText:="Classe")
    '                dgvItens.Columns.Add(columnName:="valorVenda", headerText:="Valor do item")
    '                dgvItens.Columns.Add(columnName:="dataValidade", headerText:="Data de validade")
    '                dgvItens.Columns.Add(columnName:="Quantidade", headerText:="Quantidade")

    '                dgvItens.Columns(0).ReadOnly = True
    '                dgvItens.Columns(1).ReadOnly = True
    '                dgvItens.Columns(2).ReadOnly = True
    '                dgvItens.Columns(3).ReadOnly = True
    '                dgvItens.Columns(4).ReadOnly = True
    '                dgvItens.Columns(5).ReadOnly = True
    '                dgvItens.Rows.Add(dr("id_item"), dr("nm_item"), dr("ds_item"), dr("valor_venda"), dr("data_validade"), txtQuantidade.Value)
    '            Else
    '                For i As Integer = 0 To dgvItens.Rows.Count - 1
    '                    If dr("nm_item") = dgvItens.Rows(i).Cells(1).Value.ToString And dr("ds_item") = dgvItens.Rows(i).Cells(2).Value.ToString And dr("valor_venda") = dgvItens.Rows(i).Cells(3).Value.ToString And dr("data_validade") = dgvItens.Rows(i).Cells(4).Value.ToString Then
    '                        dgvItens.Rows(i).Cells(5).Value = CDbl(dgvItens.Rows(i).Cells(5).Value) + txtQuantidade.Value
    '                        Exit Sub
    '                    End If
    '                Next i

    '                dgvItens.Rows.Add(dr("id_item"), dr("nm_item"), dr("ds_item"), dr("valor_venda"), dr("data_validade"), txtQuantidade.Value)

    '            End If
    '            dgvItens.Columns(0).Visible = False
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        conn.Close()
    '        conn.Dispose()
    '    End Try
    'End Sub
    'Private Sub ValorFinal()
    '    If txtQuantidade.Value = 1 Then
    '        valor_final += valor
    '    Else
    '        valor_final += CDbl(txtQuantidade.Value) * valor
    '    End If

    '    txtTotal.Text = "Valor da caixa: R$ " & valor_final
    'End Sub
    Private Sub btnExcluir_Click() Handles btnExcluir.Click
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String
        If dgvItens.Rows.Count > 0 Then


            If dgvItens.Rows(dgvItens.CurrentRow.Index).Cells(6).Value <> 1 Then
                dgvItens.Rows(dgvItens.CurrentRow.Index).Cells(6).Value -= 1
                valor_final -= CDbl(dgvItens.Rows(dgvItens.CurrentRow.Index).Cells(3).Value)
                txtTotal.Text = "Valor da embalagem: R$ " & valor_final
                Try
                    sql = ""
                    sql += "update itens set quantidade=quantidade+1 where id_item = " & dgvItens.Rows(dgvItens.CurrentRow.Index).Cells(0).Value
                    conn.Close()
                    conn.Open()
                    Dim comando As New MySqlCommand(sql, conn)
                    comando.ExecuteReader()
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Close()
                    conn.Dispose()
                End Try

            Else

                valor_final -= CDbl(dgvItens.Rows(dgvItens.CurrentRow.Index).Cells(3).Value)
                Try
                    sql = ""
                    sql += "update itens set quantidade=quantidade+1 where id_item = " & dgvItens.Rows(dgvItens.CurrentRow.Index).Cells(0).Value
                    conn.Close()
                    conn.Open()
                    Dim comando As New MySqlCommand(sql, conn)
                    comando.ExecuteReader()
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Close()
                    conn.Dispose()
                End Try
                If valor_final < 0 Then
                    valor_final = 0
                End If
                txtTotal.Text = "Valor da embalagem: R$ " & valor_final
                dgvItens.Rows.Remove(dgvItens.Rows(dgvItens.CurrentRow.Index))
                If dgvItens.Rows.Count = 0 Then
                    dgvItens.Invoke(Sub()
                                        dgvItens.Columns.Clear()
                                        txtTotal.Text = "Valor da embalagem: R$ 0 "
                                    End Sub)
                End If

            End If
        End If
    End Sub
    Private Sub dgvItens_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvItens.KeyDown
        If e.KeyCode = Keys.Delete And dgvItens.Rows.Count <> 0 Then


            btnExcluir_Click()

        End If
    End Sub


    Private Sub cboCaixa_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCaixa.SelectionChangeCommitted
        If cboCaixa.SelectedIndex = 0 Then
            dgvItens.Invoke(Sub()
                                dgvItens.Columns.Clear()
                                dgvItens.ClearSelection()
                                dgvItens.DataSource = Nothing
                                dgvItens.Refresh()
                                dgvItens.AllowDrop = False
                                dgvItens.AllowUserToAddRows = False
                                dgvItens.AllowUserToResizeRows = False
                                dgvItens.AllowUserToOrderColumns = False
                                dgvItens.AllowUserToResizeColumns = False
                                dgvItens.MultiSelect = False
                            End Sub)
            valor_final = 0
            txtTotal.Text = "Valor da embalagem: R$ " & valor_final
        End If

        idCaixa = cboCaixa.SelectedValue
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String
        dgvItens.Invoke(Sub()
                            dgvItens.Columns.Clear()
                            dgvItens.ClearSelection()
                            dgvItens.DataSource = Nothing
                            dgvItens.Refresh()
                            dgvItens.AllowDrop = False
                            dgvItens.AllowUserToAddRows = False
                            dgvItens.AllowUserToDeleteRows = False
                            dgvItens.AllowUserToResizeRows = False
                            dgvItens.AllowUserToResizeColumns = False
                            dgvItens.AllowUserToOrderColumns = False
                            dgvItens.MultiSelect = False
                            dgvItens.AllowUserToOrderColumns = False

                        End Sub)
        Try
            sql = ""
            sql += "SELECT i.id_item,nm_item,nm_classe,i.valor_venda,DATE_FORMAT(i.data_validade,'%d/%m/%Y')dt_validade,i.codigo_barras,e.quantidade,e.valor_total "
            sql += " FROM caixa_itens e INNER JOIN itens i ON(e.id_item=i.id_item) "
            sql += " INNER JOIN classe_item ci ON(i.classe_item=ci.id_classe_item) "
            sql += " WHERE id_caixa = " & idCaixa
            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)
            If ds.Tables(0).Rows.Count = 0 Then
                Exit Try
            End If
            dgvItens.Invoke(Sub()
                                dgvItens.DataSource = ds.Tables(0)
                                dgvItens.Columns(0).Visible = False

                                dgvItens.Columns(1).HeaderText = "Item"
                                dgvItens.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(1).ReadOnly = True

                                dgvItens.Columns(2).HeaderText = "Classe"
                                dgvItens.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                                dgvItens.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(2).ReadOnly = True

                                dgvItens.Columns(3).HeaderText = "Vl Venda"
                                dgvItens.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(3).ReadOnly = True

                                dgvItens.Columns(4).HeaderText = "Dt Validade"
                                dgvItens.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(4).ReadOnly = True

                                dgvItens.Columns(5).HeaderText = "Código de barras"
                                dgvItens.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(5).ReadOnly = True

                                dgvItens.Columns(6).HeaderText = "Quantidade"
                                dgvItens.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(6).ReadOnly = True



                            End Sub)
            txtTotal.Text = "Valor da embalagem: R$ " & ds.Tables(0).Rows(0).Item("valor_total")
            valor_final = ds.Tables(0).Rows(0).Item("valor_total")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If cboCaixa.SelectedIndex = 0 Then
            MsgBox("Selecione a embalagem !", vbExclamation, "Atenção")
            Exit Sub
        End If

        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String
        Try
            sql = ""
            sql += "delete from caixa_itens where id_caixa = " & idCaixa
            conn.Close()
            conn.Open()
            Dim comando As New MySqlCommand(sql, conn)
            comando.ExecuteReader()
            Try
                For i As Integer = 0 To dgvItens.Rows.Count - 1


                    sql = ""
                    sql += "INSERT INTO caixa_itens(id_caixa,id_item,quantidade,valor_total)"
                    sql += "VALUES(" & cboCaixa.SelectedValue & "," & dgvItens.Rows(i).Cells(0).Value & ",'" & dgvItens.Rows(i).Cells(6).Value.ToString & "',"
                    sql += " REPLACE('" & valor_final & "',',','.'))"
                    conn.Close()
                    conn.Open()
                    Dim comando2 As New MySqlCommand(sql, conn)
                    comando2.ExecuteReader()



                Next i
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            MsgBox("Embalagem salva com sucesso!", vbInformation, "Atenção!")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        frmAddItens.ShowDialog()
        txtTotal.Text = "Valor da embalagem: R$ " & valor_final
    End Sub
End Class