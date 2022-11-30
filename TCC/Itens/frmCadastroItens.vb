
Imports MySql.Data.MySqlClient

Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmCadastroItens
    Dim id As Integer = 0
    Dim Editar As Boolean = False
    Dim cancela As Integer = 0
    Dim visivel As Boolean = False
    Dim visivel2 As Boolean = False
    Dim fezBusca As Boolean = False
    Dim colunaCont As Integer = 0
    Dim form As Boolean = False
    Dim yellow As Integer = 0
    Dim pink As Integer = 0
    Dim greenYellow As Integer = 0
    Private Sub frmCadastroItens_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form = True

        carregaDgv()
        carregaCbo()
        carregaCbo2()
        verificarItens()
        txtQuantidade.Maximum = 9999999
        ckFiltro.MultiColumn = 3
        ckOcultar.MultiColumn = 3
    End Sub

    Public Sub carregaCbo2()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = ""
            sql += "select 0 'id_fornecedor','Selecione um fornecedor' nome from dual union all SELECT id_fornecedor,nome FROM fornecedores"

            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)
            Dim filtro As DataView = ds.Tables(0).DefaultView
            filtro.RowFilter = ""
            cboFornecedor.DataSource = filtro.ToTable(True, "id_fornecedor", "nome")
            cboFornecedor.Invoke(Sub()
                                     With cboFornecedor
                                         .ValueMember = "id_fornecedor"
                                         .DisplayMember = "nome"
                                         .SelectedIndex = -1
                                         .Text = ""
                                     End With
                                 End Sub)
            cboFornecedor.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Public Sub verificarItens()

        For i As Integer = 0 To dgvItens.Rows.Count - 1
            If dgvItens.Rows(i).Cells(pink).Value = 1 Then
                dgvItens.Rows(i).DefaultCellStyle.BackColor = Color.Pink
            ElseIf dgvItens.Rows(i).Cells(yellow).Value = 1 Then
                dgvItens.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            ElseIf dgvItens.Rows(i).Cells(greenYellow).Value = 1 Then
                dgvItens.Rows(i).DefaultCellStyle.BackColor = Color.GreenYellow
            Else
                dgvItens.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If
        Next i

    End Sub
    Public Sub carregaCbo()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = ""
            sql += "select 0 'id_classe_item','Selecione um item' nm_classe from dual union all SELECT id_classe_item,nm_classe FROM classe_item"

            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)
            Dim filtro As DataView = ds.Tables(0).DefaultView
            filtro.RowFilter = ""
            cboClasse.DataSource = filtro.ToTable(True, "id_classe_item", "nm_classe")
            cboClasse.Invoke(Sub()
                                 With cboClasse
                                     .ValueMember = "id_classe_item"
                                     .DisplayMember = "nm_classe"
                                     .SelectedIndex = -1
                                     .Text = ""
                                 End With
                             End Sub)
            cboClasse.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub
    Private Sub montaDGV(sql As String)
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Try
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
                                dgvItens.RowHeadersVisible = False
                                dgvItens.MultiSelect = False
                            End Sub)

            conn.Close()
            conn.Open()
            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)


            dgvItens.Invoke(Sub()
                                dgvItens.DataSource = ds.Tables(0)

                                dgvItens.ColumnHeadersDefaultCellStyle.Font = New Font(dgvItens.Font, FontStyle.Bold)
                                dgvItens.Columns(0).Visible = False
                                For i As Integer = 1 To colunaCont
                                    If ds.Tables(0).Columns(i).ColumnName = "nm_item" Then

                                        dgvItens.Columns(i).HeaderText = "Item"
                                        dgvItens.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        dgvItens.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvItens.Columns(i).ReadOnly = True

                                    ElseIf ds.Tables(0).Columns(i).ColumnName = "descritivo" Then
                                        dgvItens.Columns(i).HeaderText = "Descrição"

                                        'dgvItens.Columns(i).Width = 100
                                        dgvItens.Columns(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True

                                        '  dgvItens.Columns(i).Dock = DockStyle.Fill
                                        dgvItens.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvItens.Columns(i).ReadOnly = True

                                    ElseIf ds.Tables(0).Columns(i).ColumnName = "nm_classe" Then
                                        dgvItens.Columns(i).HeaderText = "Classe"
                                        dgvItens.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        'dgvItens.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvItens.Columns(i).ReadOnly = True

                                    ElseIf ds.Tables(0).Columns(i).ColumnName = "codigo_barras" Then
                                        dgvItens.Columns(i).HeaderText = "Código de barras"
                                        dgvItens.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        dgvItens.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvItens.Columns(i).ReadOnly = True

                                    ElseIf ds.Tables(0).Columns(i).ColumnName = "data_validade" Then
                                        dgvItens.Columns(i).HeaderText = "Data de Validade"
                                        dgvItens.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        ' dgvItens.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvItens.Columns(i).ReadOnly = True

                                    ElseIf ds.Tables(0).Columns(i).ColumnName = "quantidade" Then
                                        dgvItens.Columns(i).HeaderText = "Quantidade"
                                        dgvItens.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        ' dgvItens.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvItens.Columns(i).ReadOnly = True

                                    ElseIf ds.Tables(0).Columns(i).ColumnName = "quantidadeMini" Then
                                        dgvItens.Columns(i).HeaderText = "Quantidade minima"

                                        dgvItens.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        'dgvItens.Columns(13).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvItens.Columns(i).ReadOnly = True

                                    ElseIf ds.Tables(0).Columns(i).ColumnName = "valor_custo" Then
                                        dgvItens.Columns(i).HeaderText = "Valor de custo"
                                        dgvItens.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        ' dgvItens.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvItens.Columns(i).ReadOnly = True

                                    ElseIf ds.Tables(0).Columns(i).ColumnName = "valor_venda" Then
                                        dgvItens.Columns(i).HeaderText = "Valor de venda"
                                        dgvItens.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        ' dgvItens.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvItens.Columns(i).ReadOnly = True

                                    ElseIf ds.Tables(0).Columns(i).ColumnName = "prateleira" Then
                                        dgvItens.Columns(i).HeaderText = "Prateleira"
                                        dgvItens.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        'dgvItens.Columns(9).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvItens.Columns(i).ReadOnly = True

                                    ElseIf ds.Tables(0).Columns(i).ColumnName = "andar" Then
                                        dgvItens.Columns(i).HeaderText = "Andar"
                                        dgvItens.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        'dgvItens.Columns(10).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvItens.Columns(i).ReadOnly = True

                                    ElseIf ds.Tables(0).Columns(i).ColumnName = "fornecedor" Then
                                        dgvItens.Columns(i).HeaderText = "Fornecedor"
                                        dgvItens.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        'dgvItens.Columns(10).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvItens.Columns(i).ReadOnly = True
                                    End If
                                Next

                                yellow = colunaCont + 1

                                pink = colunaCont + 2

                                greenYellow = colunaCont + 3

                                dgvItens.Columns(colunaCont + 1).Visible = False
                                dgvItens.Columns(colunaCont + 2).Visible = False
                                dgvItens.Columns(colunaCont + 3).Visible = False

                                dgvItens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                            End Sub)

            colunaCont = 0

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub





    Private Sub carregaDgv()

        'If ckFiltro.CheckedItems.Count = 0 Or txtBusca.Text = "" And fezBusca = True Then
        '    carregaDgv()
        '    Exit Sub
        'End If

        If ckFiltro.CheckedItems.Count > 0 Or txtBusca.Text <> "" Or ckOcultar.CheckedItems.Count > 0 Or form = True Then
            fezBusca = True
            Dim contador As Integer = 0
            Dim sql As String

            sql = ""
            sql += "SELECT id_item,"
            If (ckOcultar.GetItemChecked(0).ToString = True) Then
                sql += ""

            Else
                colunaCont += 1
                sql += "nm_item, "

            End If
            If (ckOcultar.GetItemChecked(1).ToString = True) Then
                sql += ""

            Else
                colunaCont += 1
                sql += "descritivo,"
            End If
            If (ckOcultar.GetItemChecked(2).ToString = True) Then
                sql += ""

            Else
                colunaCont += 1
                sql += "nm_classe, "
            End If
            If (ckOcultar.GetItemChecked(3).ToString = True) Then
                sql += ""

            Else
                colunaCont += 1
                sql += "codigo_barras, "
            End If
            If (ckOcultar.GetItemChecked(4).ToString = True) Then
                sql += ""

            Else
                colunaCont += 1
                sql += "DATE_FORMAT(data_validade,'%d/%m/%Y')data_validade, "
            End If
            If (ckOcultar.GetItemChecked(5).ToString = True) Then
                sql += ""

            Else
                colunaCont += 1
                sql += "quantidade, "
            End If
            If (ckOcultar.GetItemChecked(6).ToString = True) Then
                sql += ""

            Else
                colunaCont += 1
                sql += "quantidadeMini, "
            End If
            If (ckOcultar.GetItemChecked(7).ToString = True) Then
                sql += ""

            Else
                colunaCont += 1
                sql += "valor_custo, "
            End If
            If (ckOcultar.GetItemChecked(8).ToString = True) Then
                sql += ""

            Else
                colunaCont += 1
                sql += "valor_venda, "
            End If
            If (ckOcultar.GetItemChecked(9).ToString = True) Then
                sql += ""

            Else
                colunaCont += 1
                sql += "prateleira, "
            End If
            If (ckOcultar.GetItemChecked(10).ToString = True) Then
                sql += ""

            Else
                colunaCont += 1
                sql += "andar, "
            End If
            If (ckOcultar.GetItemChecked(11).ToString = True) Then
                sql += ""

            Else
                colunaCont += 1
                sql += "fornecedor, "
            End If
            sql += "       PertoDaValidade,"
            sql += "       Vencido,BaixoEstoque "
            sql += "FROM(SELECT id_item,i.nm_item,descritivo, "
            sql += "            c.nm_classe,codigo_barras,data_validade, "
            sql += "            quantidade,valor_custo,valor_venda, "
            sql += "            prateleira,andar, "
            sql += "            (SELECT CASE WHEN (MONTH(data_validade) = MONTH(NOW()) AND YEAR(data_validade) = YEAR(NOW()) AND DAY(data_validade)>= DAY(NOW())) "
            sql += "                           OR (MONTH(data_validade) = MONTH(NOW())+1 "
            sql += "                                AND YEAR(data_validade) = YEAR(NOW())) "
            sql += "                                Then 1 Else 0 End PertoDaValidade "
            sql += "             FROM itens a "
            sql += "                  WHERE a.id_item = i.id_item)PertoDaValidade, "
            sql += "            (SELECT CASE WHEN (MONTH(data_validade) < MONTH(NOW()) AND YEAR(data_validade) <= YEAR(NOW())) "
            sql += "            OR(MONTH(data_validade) <= MONTH(NOW()) AND YEAR(data_validade) <= YEAR(NOW()) AND DAY(data_validade)< DAY(NOW()))THEN 1 ELSE 0 END Vencido "
            sql += "             FROM itens b"
            sql += "                  WHERE b.id_item = i.id_item) Vencido,"
            sql += "           (SELECT CASE WHEN quantidade <= quantidadeMini THEN 1 ELSE 0 END BaixoEstoque "
            sql += "            FROM itens c "
            sql += "                  WHERE c.id_item = i.id_item)BaixoEstoque,"
            sql += "            quantidadeMini,f.nome fornecedor "
            sql += "     FROM itens i "
            sql += "          INNER JOIN classe_item c On(i.classe_item=c.id_classe_item) "
            sql += "          INNER JOIN fornecedores f ON (i.id_fornecedor=f.id_fornecedor))Itens "

            If ckFiltro.CheckedItems.Count > 0 Then
                sql += " WHERE "
                For Each i As Integer In ckFiltro.CheckedIndices
                    If i = 0 Then
                        If contador = 0 Then
                            sql += " andar LIKE '%" & txtBusca.Text & "%'"
                            contador += 1
                        Else
                            sql += " OR andar LIKE '%" & txtBusca.Text & "%'"
                        End If

                    ElseIf i = 1 Then
                        If contador = 0 Then
                            sql += " BaixoEstoque = 1 "
                            contador += 1
                        Else
                            sql += " OR BaixoEstoque = 1 "
                        End If

                    ElseIf i = 2 Then
                        If contador = 0 Then
                            sql += " codigo_barras LIKE '%" & txtBusca.Text & "%' "
                            contador += 1
                        Else
                            sql += " OR codigo_barras LIKE '%" & txtBusca.Text & "%' "

                        End If

                    ElseIf i = 3 Then
                        If contador = 0 Then
                            sql += " nm_classe LIKE '%" & txtBusca.Text & "%' "
                            contador += 1
                        Else
                            sql += " OR nm_classe LIKE '%" & txtBusca.Text & "%'"

                        End If

                    ElseIf i = 4 Then
                        If contador = 0 Then
                            sql += " DATE_FORMAT(data_validade,'%d/%m/%Y') LIKE '%" & txtBusca.Text & "%' "
                            contador += 1
                        Else
                            sql += " OR DATE_FORMAT(data_validade,'%d/%m/%Y') LIKE '%" & txtBusca.Text & "%' "

                        End If

                    ElseIf i = 5 Then
                        If contador = 0 Then
                            sql += " nm_item LIKE '%" & txtBusca.Text & "%' "
                            contador += 1
                        Else
                            sql += " OR nm_item LIKE '%" & txtBusca.Text & "%' "

                        End If

                    ElseIf i = 6 Then
                        If contador = 0 Then
                            sql += " prateleira LIKE '%" & txtBusca.Text & "%' "
                            contador += 1
                        Else
                            sql += " OR prateleira LIKE '%" & txtBusca.Text & "%' "

                        End If

                    ElseIf i = 7 Then
                        If contador = 0 Then
                            sql += " PertoDaValidade =1 "
                            contador += 1
                        Else
                            sql += " OR PertoDaValidade =1 "

                        End If

                    ElseIf i = 8 Then
                        If contador = 0 Then
                            sql += " quantidadeMini LIKE '%" & txtBusca.Text & "%' "
                            contador += 1
                        Else
                            sql += "  OR quantidadeMini LIKE '%" & txtBusca.Text & "%' "

                        End If

                    ElseIf i = 9 Then
                        If contador = 0 Then
                            sql += " quantidade LIKE '%" & txtBusca.Text & "%' "
                            contador += 1
                        Else
                            sql += " OR quantidade LIKE '%" & txtBusca.Text & "%'"

                        End If

                    ElseIf i = 10 Then
                        If contador = 0 Then
                            sql += " Vencido = 1 "
                            contador += 1
                        Else
                            sql += " OR Vencido = 1 "

                        End If

                    ElseIf i = 11 Then
                        If contador = 0 Then
                            sql += " valor_custo LIKE '%" & txtBusca.Text & "%' "
                            contador += 1
                        Else
                            sql += " OR valor_custo LIKE '%" & txtBusca.Text & "%'"

                        End If

                    ElseIf i = 12 Then
                        If contador = 0 Then
                            sql += " valor_venda LIKE '%" & txtBusca.Text & "%' "
                            contador += 1
                        Else
                            sql += " OR valor_venda LIKE '%" & txtBusca.Text & "%'"

                        End If
                    ElseIf i = 13 Then
                        If contador = 0 Then
                            sql += " fornecedor LIKE '%" & txtBusca.Text & "%' "
                            contador += 1
                        Else
                            sql += " OR fornecedor LIKE '%" & txtBusca.Text & "%'"

                        End If

                    End If
                Next
            Else
                sql += "WHERE andar LIKE '%" & txtBusca.Text & "%'"
                sql += " OR valor_venda LIKE '%" & txtBusca.Text & "%'"
                sql += " OR valor_custo LIKE '%" & txtBusca.Text & "%'"
                sql += " OR quantidade LIKE '%" & txtBusca.Text & "%'"
                sql += " OR quantidadeMini LIKE '%" & txtBusca.Text & "%' "
                sql += " OR prateleira LIKE '%" & txtBusca.Text & "%' "
                sql += " OR nm_item LIKE '%" & txtBusca.Text & "%' "
                sql += " OR DATE_FORMAT(data_validade,'%d/%m/%Y') LIKE '%" & txtBusca.Text & "%' "
                sql += " OR nm_classe LIKE '%" & txtBusca.Text & "%'"
                sql += " OR codigo_barras LIKE '%" & txtBusca.Text & "%' "
                sql += " OR fornecedor LIKE '%" & txtBusca.Text & "%' "
            End If
            sql += "order by nm_item"


            montaDGV(sql)

            verificarItens()
        Else
            carregaDgv()
        End If

    End Sub

    Private Sub dgvItens_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellClick
        If e.RowIndex >= 0 And Editar = False And dgvItens.Columns.Count = 16 Then
            txtNome.Text = dgvItens.Rows(e.RowIndex).Cells(1).Value
            txtDescricao.Text = dgvItens.Rows(e.RowIndex).Cells(2).Value
            cboClasse.Text = dgvItens.Rows(e.RowIndex).Cells(3).Value
            cboFornecedor.Text = dgvItens.Rows(e.RowIndex).Cells(12).Value
            txtCodigoBarras.Text = dgvItens.Rows(e.RowIndex).Cells(4).Value
            txtDataValidade.Text = dgvItens.Rows(e.RowIndex).Cells(5).Value.ToString
            txtQuantidade.Text = dgvItens.Rows(e.RowIndex).Cells(6).Value
            txtQuantidadeMini.Text = dgvItens.Rows(e.RowIndex).Cells(7).Value
            txtValorCusto.Text = dgvItens.Rows(e.RowIndex).Cells(8).Value
            txtValorVenda.Text = dgvItens.Rows(e.RowIndex).Cells(9).Value
            txtPrateleira.Text = dgvItens.Rows(e.RowIndex).Cells(10).Value
            txtAndar.Text = dgvItens.Rows(e.RowIndex).Cells(11).Value
            id = dgvItens.Rows(e.RowIndex).Cells(0).Value
            btnEditar.Enabled = True
            btnExcluir.Enabled = True
            cancela = 0
        End If
    End Sub

    Private Sub btnCancelar_Click() Handles btnCancelar.Click
        txtNome.Text = ""
        txtDescricao.Text = ""
        txtCodigoBarras.Text = ""
        cboClasse.SelectedIndex = 0
        cboFornecedor.SelectedIndex = 0
        txtDataValidade.Text = ""
        txtQuantidade.Value = 1
        txtValorCusto.Text = ""
        txtValorVenda.Text = ""
        txtQuantidadeMini.Text = ""
        txtAndar.Text = ""
        txtPrateleira.Text = ""
        txtNome.Enabled = False
        txtDescricao.Enabled = False
        txtCodigoBarras.Enabled = False
        cboClasse.Enabled = False
        cboFornecedor.Enabled = False
        txtDataValidade.Enabled = False
        txtQuantidade.Enabled = False
        txtValorCusto.Enabled = False
        txtValorVenda.Enabled = False
        txtQuantidadeMini.Enabled = False
        txtAndar.Enabled = False
        txtPrateleira.Enabled = False
        btnSalvar.Enabled = False
        btnEditar.Enabled = False
        Editar = False
        id = 0
        btnSalvar.Text = "Salvar"
        dgvItens.Enabled = True
        cancela += 1
        If cancela > 1 Then
            cancela = 0
            Me.Close()
        End If


    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If id = 0 Then
            MsgBox("Selecione um item", vbExclamation, "Atenção")
            Exit Sub
        End If
        txtNome.Enabled = True
        txtDescricao.Enabled = True
        txtCodigoBarras.Enabled = True
        cboClasse.Enabled = True
        cboFornecedor.Enabled = True
        txtDataValidade.Enabled = True
        txtQuantidade.Enabled = True
        txtValorCusto.Enabled = True
        txtValorVenda.Enabled = True
        txtQuantidadeMini.Enabled = True
        txtAndar.Enabled = True
        txtPrateleira.Enabled = True
        btnSalvar.Enabled = True
        btnSalvar.Text = "Alterar"
        Editar = True
        cancela = 0
    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        cancela = 0
        Editar = True
        txtNome.Text = ""
        txtDescricao.Text = ""
        txtCodigoBarras.Text = ""
        cboClasse.SelectedIndex = 0
        cboFornecedor.SelectedIndex = 0
        txtDataValidade.Text = ""
        txtQuantidade.Value = 1
        txtValorCusto.Text = ""
        txtValorVenda.Text = ""
        txtQuantidadeMini.Text = ""
        txtAndar.Text = ""
        txtPrateleira.Text = ""
        txtNome.Enabled = True
        txtDescricao.Enabled = True
        txtCodigoBarras.Enabled = True
        cboClasse.Enabled = True
        cboFornecedor.Enabled = True
        txtDataValidade.Enabled = True
        txtQuantidade.Enabled = True
        txtValorCusto.Enabled = True
        txtValorVenda.Enabled = True
        txtQuantidadeMini.Enabled = True
        txtAndar.Enabled = True
        txtPrateleira.Enabled = True
        btnSalvar.Enabled = True
        'dgvItens.Enabled = False
        btnSalvar.Text = "Salvar"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmAddClasse.ShowDialog()
    End Sub



    Private Sub txtCodigoBarras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoBarras.KeyPress
        Permitir_numeros(sender, e)
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        cancela = 0
        'aqui deu preguiça de fazer de outra forma, então foi no ctrl+c ctrl+v
        If txtNome.Text = "" Then
            MsgBox("Preencha o campo 'Nome'", vbExclamation, "Atenção")
            txtNome.Focus()
            Exit Sub
        ElseIf txtCodigoBarras.Text = "" Then
            MsgBox("Preencha o campo 'Código de barras'", vbExclamation, "Atenção")
            txtCodigoBarras.Focus()
            Exit Sub
        ElseIf cboClasse.SelectedIndex = 0 Then
            MsgBox("Selecione uma opção no campo 'Classe'", vbExclamation, "Atenção")
            cboClasse.Focus()
            Exit Sub
        ElseIf txtQuantidade.Text = "" Then
            MsgBox("Preencha o campo 'Quantidade'", vbExclamation, "Atenção")
            txtQuantidade.Focus()
            Exit Sub
        ElseIf txtValorCusto.Text = "" Then
            MsgBox("Preencha o campo 'Valor de custo'", vbExclamation, "Atenção")
            txtValorCusto.Focus()
            Exit Sub
        ElseIf txtValorVenda.Text = "" Then
            MsgBox("Preencha o campo 'Valor de venda'", vbExclamation, "Atenção")
            txtValorVenda.Focus()
            Exit Sub
        ElseIf txtAndar.Text = "" Then
            MsgBox("Preencha o campo 'Andar'", vbExclamation, "Atenção")
            txtAndar.Focus()
            Exit Sub
        ElseIf txtPrateleira.Text = "" Then
            MsgBox("Preencha o campo 'Prateleira'", vbExclamation, "Atenção")
            txtPrateleira.Focus()
            Exit Sub
        ElseIf txtQuantidadeMini.Text = "" Then
            MsgBox("Preencha o campo 'Quantidade minima'", vbExclamation, "Atenção")
            txtQuantidadeMini.Focus()
            Exit Sub
        ElseIf cboClasse.SelectedIndex = 0 Then
            MsgBox("Selecione uma opção no campo 'Fornecedor'", vbExclamation, "Atenção")
            txtQuantidadeMini.Focus()
            Exit Sub
        ElseIf btnSalvar.Text = "Alterar" Then
            cancela = 0
            Dim conn As New MySqlConnection(My.Settings.conexao)
            Dim sql As String

            Try
                sql = ""
                sql += "UPDATE itens SET nm_item='" & txtNome.Text & "', "
                sql += "descritivo='" & txtDescricao.Text.Replace("'", "''") & "',"
                sql += "classe_item='" & cboClasse.SelectedValue & "',"
                sql += "codigo_barras='" & txtCodigoBarras.Text & "',"
                sql += "data_validade=DATE(STR_TO_DATE('" & txtDataValidade.Text & "','%d/%m/%Y')),"
                sql += "quantidade='" & txtQuantidade.Value & "',"
                sql += "valor_custo=REPLACE('" & txtValorCusto.Text & "',',','.'),"
                sql += "valor_venda=REPLACE('" & txtValorVenda.Text & "',',','.'),"
                sql += "prateleira='" & txtPrateleira.Text & "',"
                sql += "andar='" & txtAndar.Text & "',"
                sql += "quantidadeMini='" & txtQuantidadeMini.Text & "',"
                sql += "id_fornecedor ='" & cboFornecedor.SelectedValue & "'"
                sql += " where id_item = " & id
                conn.Close()
                conn.Open()

                Dim comando As New MySqlCommand(sql, conn)
                comando.ExecuteReader()

                MsgBox("Item alterado com sucesu", vbInformation, "Informação")
                carregaDgv()
                dgvItens.Enabled = True
                txtCodigoBarras.Text = ""
                txtDataValidade.Text = ""
                txtDescricao.Text = ""
                txtNome.Text = ""
                txtQuantidade.Value = 0
                txtValorVenda.Text = ""
                txtValorCusto.Text = ""
                txtQuantidadeMini.Text = ""
                txtAndar.Text = ""
                txtPrateleira.Text = ""
                id = 0
                txtNome.Enabled = False
                txtDescricao.Enabled = False
                txtCodigoBarras.Enabled = False
                cboClasse.Enabled = False
                cboFornecedor.Enabled = False
                txtDataValidade.Enabled = False
                txtQuantidade.Enabled = False
                txtValorCusto.Enabled = False
                txtValorVenda.Enabled = False
                btnSalvar.Enabled = False
                txtQuantidadeMini.Enabled = False
                txtAndar.Enabled = False
                txtPrateleira.Enabled = False
                btnSalvar.Text = "Salvar"
                btnEditar.Enabled = False
                Editar = False
                cboClasse.SelectedIndex = 0
                cboFornecedor.SelectedIndex = 0
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
                conn.Dispose()
            End Try
        Else
            cancela = 0
            Dim conn As New MySqlConnection(My.Settings.conexao)
            Dim sql As String

            Try
                sql = ""
                sql += "insert into itens (nm_item,descritivo,codigo_barras,data_validade,quantidade,valor_custo,valor_venda,classe_item,prateleira,andar,quantidadeMini,id_fornecedor)"
                sql += "values ('" & txtNome.Text & "','" & txtDescricao.Text & "'," & txtCodigoBarras.Text & "," & "DATE(STR_TO_DATE('" & txtDataValidade.Text & "','%d/%m/%Y')),"
                sql += txtQuantidade.Value & ", REPLACE('" & txtValorCusto.Text & "',',','.'),"
                sql += "REPLACE('" & txtValorVenda.Text & "',',','.')," & cboClasse.SelectedValue & "," & txtPrateleira.Text & "," & txtAndar.Text & "," & txtQuantidadeMini.Text & "," & cboFornecedor.SelectedValue & ")"

                conn.Close()
                conn.Open()

                Dim comando As New MySqlCommand(sql, conn)
                comando.ExecuteReader()

                MsgBox("Item salvo com sucesu", vbInformation, "Informação")
                carregaDgv()
                dgvItens.Enabled = True
                txtCodigoBarras.Text = ""
                txtDataValidade.Text = ""
                txtDescricao.Text = ""
                txtNome.Text = ""
                txtQuantidade.Value = 0
                txtValorVenda.Text = ""
                txtValorCusto.Text = ""
                txtQuantidadeMini.Text = ""
                txtAndar.Text = ""
                txtPrateleira.Text = ""
                id = 0
                txtNome.Enabled = False
                txtDescricao.Enabled = False
                txtCodigoBarras.Enabled = False
                cboClasse.Enabled = False
                cboFornecedor.Enabled = False
                txtDataValidade.Enabled = False
                txtQuantidade.Enabled = False
                txtValorCusto.Enabled = False
                txtValorVenda.Enabled = False
                btnSalvar.Enabled = False
                txtQuantidadeMini.Enabled = False
                txtAndar.Enabled = False
                txtPrateleira.Enabled = False
                btnSalvar.Text = "Salvar"
                Editar = False
                cboClasse.SelectedIndex = 0
                cboFornecedor.SelectedIndex = 0
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
                conn.Dispose()
            End Try

        End If
    End Sub

    Private Sub txtValorCusto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValorCusto.KeyPress
        Permitir_dinheiro(sender, e)
    End Sub
    Private Sub txtValorVenda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValorVenda.KeyPress
        Permitir_dinheiro(sender, e)
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        If MsgBox("Deseja realmente excluir o item" & txtNome.Text & " ?", vbQuestion + vbYesNo + vbDefaultButton2, "Atenção") = vbNo Then
            Exit Sub
        End If

        cancela = 0
        Try
            sql = ""
            sql += "delete from itens where id_item = " & id
            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            comando.ExecuteReader()

            MsgBox("Item deletado com sucessu", vbInformation, "Informação")
            carregaDgv()
            id = 0

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub


    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    cancela = 0
    '    For i As Integer = 0 To dgvItens.Rows.Count - 1
    '        If dgvItens.Rows(i).Cells(6).Value <= 5 Then
    '            MsgBox("o item: " & dgvItens.Rows(i).Cells(1).Value.ToString & " " & dgvItens.Rows(i).Cells(2).Value.ToString & " esta acabando")
    '        End If
    '    Next i
    '    For i As Integer = 0 To dgvItens.Rows.Count - 1
    '        If dgvItens.Rows(i).Cells(9).Value <> 1 Then
    '            MsgBox("o item: " & dgvItens.Rows(i).Cells(1).Value.ToString & " " & dgvItens.Rows(i).Cells(2).Value.ToString & " esta perto da validade")
    '        End If
    '    Next i
    'End Sub

    Private Sub frmCadastroItens_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        verificarItens()
    End Sub

    Private Sub txtPrateleira_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrateleira.KeyPress
        Permitir_numeros(sender, e)
    End Sub

    Private Sub txtAndar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAndar.KeyPress
        Permitir_numeros(sender, e)
    End Sub

    Private Sub txtQuantidadeMini_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantidadeMini.KeyPress
        Permitir_numeros(sender, e)
    End Sub

    Private Sub dgvItens_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvItens.ColumnHeaderMouseClick
        verificarItens()
    End Sub
    Private Sub btnOcultar_Click(sender As Object, e As EventArgs) Handles btnOcultar.Click
        If visivel2 = False Then
            btnLimpa.Visible = False
            btnOkFiltro.Visible = False
            ckFiltro.Visible = False
            ckOcultar.Visible = True
            btnLimpa2.Visible = True
            btnOkFiltro2.Visible = True
            visivel2 = True
            visivel = False
            ' ckFiltro.Focus()
        Else

            ckOcultar.Visible = False
            btnLimpa2.Visible = False
            btnOkFiltro2.Visible = False
            visivel2 = False
            'filtraDgv()
            ' Button3_Click()
            btnCancelar_Click()
            cancela = 0
            carregaDgv()
        End If
    End Sub
    Private Sub btnFiltro_Click() Handles btnFiltro.Click
        If visivel = False Then
            btnLimpa2.Visible = False
            btnOkFiltro2.Visible = False
            ckOcultar.Visible = False
            ckFiltro.Visible = True
            btnLimpa.Visible = True
            btnOkFiltro.Visible = True
            visivel = True
            visivel2 = False
            ' ckFiltro.Focus()
        Else

            ckFiltro.Visible = False
            btnLimpa.Visible = False
            btnOkFiltro.Visible = False
            visivel = False
            carregaDgv()
            ' Button3_Click()
        End If

    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ExportToExcelWithFormat(dgvItens)
    End Sub



    Public Sub ExportToExcelWithFormat(ByVal dataGridView1 As Windows.Forms.DataGridView)
        Dim contador = 0
        Dim rownum = 1



        ' inicializa o aplicativo excel
        Dim excelApp = New Excel.Application()
        excelApp.Visible = True
        '  cria uma pasta de trabalho
        Dim excelbk As Excel.Workbook = excelApp.Workbooks.Add(Type.Missing)
        'Adicione uma aba à pasta de trabalho acima
        Dim xlWorkSheet1 As Excel.Worksheet = CType(excelbk.Worksheets(1), Excel.Worksheet)
        'nomeie a aba Planilha1
        With xlWorkSheet1
            .Name = "Planilha1"
        End With
        'Adiciona o nome de cada coluna do datagridview à primeira linha do Excel,
        'este será o texto do cabeçalho
        For colCount As Integer = 1 To dataGridView1.Columns.Count - 4

            Dim xlRange As Excel.Range = CType(xlWorkSheet1.Cells(rownum, colCount), Excel.Range)
            xlRange.VerticalAlignment = Excel.Constants.xlCenter
            xlRange.HorizontalAlignment = Excel.Constants.xlCenter
            xlRange.WrapText = True
            xlRange.Font.Bold = 5
            xlRange.ColumnWidth = 12
            xlRange.Columns(colCount).AutoFit

            xlRange.Borders.LineStyle = 7

            xlRange.Value2 = dataGridView1.Columns(colCount).HeaderCell.Value.ToString


        Next
        ' for each para cada linha no datagridview
        For rowCount As Integer = 0 To dataGridView1.Rows.Count - 1
            'se a linha estiver visível
            If dataGridView1.Rows(rowCount).Visible = True Then
                'incrementar o número da linha para excel
                rownum = rownum + 1
                For colCount As Integer = 1 To dataGridView1.Columns.Count - 4
                    'crie um intervalo do Excel para o rownum e o columncount
                    Dim xlRange As Excel.Range = CType(xlWorkSheet1.Cells(rownum, colCount), Excel.Range)
                    Try
                        'adicione o valor da célula gridview ao intervalo de células e defina o tamano delas
                        xlRange.VerticalAlignment = Excel.Constants.xlCenter
                        xlRange.HorizontalAlignment = Excel.Constants.xlCenter
                        xlRange.Borders.LineStyle = 7
                        xlRange.WrapText = True
                        xlRange.ColumnWidth = 12
                        xlRange.Value2 = dataGridView1.Rows(rowCount).Cells(colCount).Value
                    Catch __unusedException1__ As Exception
                        Try
                            xlRange.Value2 = ""
                        Catch __unusedException11__ As Exception

                        End Try
                    End Try
                    'defina o intervalo interior do xlrange para o estilo de linha padrão da célula
                    xlRange.Interior.Color = Drawing.ColorTranslator.ToOle(dataGridView1.Rows(rowCount).DefaultCellStyle.BackColor)

                    'defina a cor da fonte do xlrange para o styletyle.ForeColor da linha 
                    xlRange.Font.Color = dataGridView1.Rows(rowCount).Cells(colCount).Style.ForeColor.ToArgb()

                    If dataGridView1.Rows(rowCount).Cells(colCount).Style.Font IsNot Nothing Then
                        xlRange.Font.Bold = dataGridView1.Rows(rowCount).Cells(colCount).Style.Font.Bold
                        xlRange.Font.Italic = dataGridView1.Rows(rowCount).Cells(colCount).Style.Font.Italic
                        xlRange.Font.Underline = dataGridView1.Rows(rowCount).Cells(colCount).Style.Font.Underline
                        xlRange.Font.FontStyle = dataGridView1.Rows(rowCount).Cells(colCount).Style.Font.FontFamily
                    End If
                Next
                contador += 1
            End If

        Next
        Dim legenda1 As Excel.Range = CType(xlWorkSheet1.Cells(dataGridView1.Rows.Count + 4, 1), Excel.Range)
        legenda1.Borders.LineStyle = 7
        legenda1.WrapText = True
        legenda1.ColumnWidth = 12
        legenda1.Font.Bold = 5
        legenda1.VerticalAlignment = Excel.Constants.xlCenter
        legenda1.HorizontalAlignment = Excel.Constants.xlCenter
        legenda1.Value = "Vencidos"
        legenda1.Interior.Color = Color.Pink

        Dim legenda2 As Excel.Range = CType(xlWorkSheet1.Cells(dataGridView1.Rows.Count + 4, 2), Excel.Range)
        legenda2.Borders.LineStyle = 7
        legenda2.WrapText = True
        legenda2.ColumnWidth = 12
        legenda2.Font.Bold = 5
        legenda2.VerticalAlignment = Excel.Constants.xlCenter
        legenda2.HorizontalAlignment = Excel.Constants.xlCenter
        legenda2.Value = "Perto do vencimento"
        legenda2.Interior.Color = Color.Yellow

        Dim legenda3 As Excel.Range = CType(xlWorkSheet1.Cells(dataGridView1.Rows.Count + 4, 3), Excel.Range)
        legenda3.Borders.LineStyle = 7
        legenda3.WrapText = True
        legenda3.ColumnWidth = 12
        legenda3.Font.Bold = 5
        legenda3.VerticalAlignment = Excel.Constants.xlCenter
        legenda3.HorizontalAlignment = Excel.Constants.xlCenter
        legenda3.Value = "Baixo estoque"
        legenda3.Interior.Color = Color.GreenYellow

    End Sub

    Private Sub btnOkFiltro_Click(sender As Object, e As EventArgs) Handles btnOkFiltro.Click
        ckFiltro.Visible = False
        btnLimpa.Visible = False
        btnOkFiltro.Visible = False
        visivel = False

        carregaDgv()
    End Sub

    Private Sub btnLimpa_Click(sender As Object, e As EventArgs) Handles btnLimpa.Click
        ckFiltro.Visible = False
        btnLimpa.Visible = False
        btnOkFiltro.Visible = False
        visivel = False
        For Each i As Integer In ckFiltro.CheckedIndices
            ckFiltro.SetItemCheckState(i, CheckState.Unchecked)
            carregaDgv()
        Next
    End Sub

    Private Sub ckFiltro_Leave(sender As Object, e As EventArgs) Handles ckFiltro.Leave
        btnFiltro_Click()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        carregaDgv()
    End Sub





    Private Sub btnOkFiltro2_Click(sender As Object, e As EventArgs) Handles btnOkFiltro2.Click
        ckOcultar.Visible = False
        btnLimpa2.Visible = False
        btnOkFiltro2.Visible = False
        visivel2 = False
        btnCancelar_Click()
        cancela = 0
        carregaDgv()
    End Sub

    Private Sub btnLimpa2_Click(sender As Object, e As EventArgs) Handles btnLimpa2.Click
        ckOcultar.Visible = False
        btnLimpa2.Visible = False
        btnOkFiltro2.Visible = False
        visivel2 = False
        For Each i As Integer In ckOcultar.CheckedIndices
            ckOcultar.SetItemCheckState(i, CheckState.Unchecked)
            carregaDgv()
        Next
    End Sub

    Private Sub btnFiltro_Click(sender As Object, e As EventArgs) Handles btnFiltro.Click

    End Sub

    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBusca.TextChanged
        carregaDgv()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmFornecedores.ShowDialog()
        carregaCbo2()
    End Sub

    'Private Sub frmCadastroItens_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    '    dgvItens.Invoke(Sub()
    '                        dgvItens.Columns.Clear()
    '                        dgvItens.ClearSelection()
    '                        dgvItens.DataSource = Nothing
    '                        dgvItens.Refresh()
    '                        dgvItens.AllowDrop = False
    '                        dgvItens.AllowUserToAddRows = False
    '                        dgvItens.AllowUserToDeleteRows = False
    '                        dgvItens.AllowUserToResizeRows = False
    '                        dgvItens.AllowUserToResizeColumns = False

    '                        dgvItens.MultiSelect = False
    '                    End Sub)
    'End Sub
End Class