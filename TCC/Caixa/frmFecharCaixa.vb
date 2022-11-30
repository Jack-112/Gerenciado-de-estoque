Imports MySql.Data.MySqlClient
Public Class frmFecharCaixa
    Private Sub frmFecharCaixa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregaCbo()
    End Sub

    Private Sub carregaCbo()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = ""
            sql += "SELECT 0'id_caixa','Selecione uma caixa'nm_caixa FROM DUAL UNION SELECT id_caixa,nm_caixa FROM caixas "
            sql += "WHERE id_caixa NOT IN (SELECT id_caixa FROM  caixas_fechadas)"
            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataTable
            dr.Fill(ds)
            Dim filtro As DataView = ds.DefaultView
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

    Private Sub cboCaixa_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCaixa.SelectionChangeCommitted
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
                            dgvItens.RowHeadersVisible = False
                        End Sub)
        If cboCaixa.SelectedIndex = 0 Then
            valor_final.Text = "Valor da embalagem: R$ 0"
            Exit Sub
        End If

        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = ""
            sql += "SELECT ci.id_caixa,ci.id_item,i.nm_item,cl.nm_classe,i.valor_venda,DATE_FORMAT(i.data_validade,'%d/%m/%Y')dt_validade,ci.quantidade,ci.valor_total "
            sql += " FROM caixa_itens ci INNER JOIN caixas c ON(ci.id_caixa = c.id_caixa) INNER JOIN itens  i ON(ci.id_item=i.id_item) "
            sql += " INNER JOIN classe_item cl ON(i.classe_item=cl.id_classe_item) "
            sql += " WHERE ci.id_caixa = " & cboCaixa.SelectedValue

            conn.Close()
            conn.Open()
            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)

            dgvItens.Invoke(Sub()
                                dgvItens.DataSource = ds.Tables(0)

                                dgvItens.Columns(0).Visible = False
                                dgvItens.Columns(1).Visible = False

                                dgvItens.Columns(2).HeaderText = "Item"
                                dgvItens.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(2).ReadOnly = True

                                dgvItens.Columns(3).HeaderText = "Classe"
                                dgvItens.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(3).ReadOnly = True

                                dgvItens.Columns(4).HeaderText = "Valor de Venda"
                                dgvItens.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(4).ReadOnly = True

                                dgvItens.Columns(5).HeaderText = "Data de Validade"
                                dgvItens.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(5).ReadOnly = True

                                dgvItens.Columns(6).HeaderText = "Quantidade"
                                dgvItens.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(6).ReadOnly = True

                                dgvItens.Columns(7).Visible = False
                            End Sub)
            Dim var As Decimal = 0
            If ds.Tables(0).Rows.Count > 0 Then
                var = ds.Tables(0).Rows(0).Item("valor_total")
            End If

            valor_final.Text = "Valor da embalagem: R$ " & var
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Deseja realmente Fechar a embalagem selecionada ?", vbQuestion + vbYesNo + vbDefaultButton2, "Atenção") = vbNo Then
            Exit Sub
        End If
        If dgvItens.Rows.Count = 0 Then
            MsgBox("A embalagem não possui itens", MessageBoxIcon.Error, "Atenção")
            Exit Sub
        End If
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = ""
            sql += "INSERT INTO caixas_fechadas (id_caixa,usuario,dt_fechamento) VALUES(" & cboCaixa.SelectedValue & ",'" & nm_usuario & "',NOW())"
            conn.Close()
            conn.Open()
            Dim comando2 As New MySqlCommand(sql, conn)
            comando2.ExecuteReader()
            carregaCbo()
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
                                dgvItens.RowHeadersVisible = False
                            End Sub)
            valor_final.Text = "Valor da embalagem: R$ 0"
            MsgBox("embalagem fechada com sucesso", vbInformation, "Atenção")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    Private Sub frmFecharCaixa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
                            dgvItens.RowHeadersVisible = False
                        End Sub)
        valor_final.Text = "Valor da embalagem: R$ 0"
    End Sub
End Class