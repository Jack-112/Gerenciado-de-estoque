Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmPrincipal
    Dim valida As Integer = 0
    Dim lvTotal As Decimal = 0
    Dim tabPage As Integer = 0

    Private Sub UsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem.Click
        frmUsuarios.ShowDialog()
    End Sub

    Private Sub CadastroDeItensToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CadastroDeItensToolStripMenuItem.Click
        frmCadastroItens.ShowDialog()
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregaCboTab1()
        carregaCboTab2()
        carregaCboTab3()
        carregaDGV()

        dtInicio.Value = Now
        dtFim.Value = Now
        dtInicio2.Value = Now
        dtFim2.Value = Now
        dtInicio3.Value = Now
        dtFim3.Value = Now

        valida = 1
    End Sub

    Private Sub carregaCboTab1()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = ""
            sql += "select 0 'id_classe_item','Todas as classes' nm_classe from dual union all SELECT id_classe_item,nm_classe FROM classe_item"

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

            sql = ""
            sql += "select 0 'id_fornecedor','Todos os fornecedores' nome from dual union all SELECT id_fornecedor,nome FROM fornecedores"

            conn.Close()
            conn.Open()

            Dim comando2 As New MySqlCommand(sql, conn)
            Dim dr2 As New MySqlDataAdapter(comando2)
            Dim ds2 As New DataSet
            dr2.Fill(ds2)
            Dim filtro2 As DataView = ds2.Tables(0).DefaultView
            filtro2.RowFilter = ""
            cboFornecedor.DataSource = filtro2.ToTable(True, "id_fornecedor", "nome")
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
    Private Sub carregaCboTab2()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = ""
            sql += "SELECT 0 'id_responsavel','Todos os responsaveis' nm_responsavel FROM DUAL UNION ALL SELECT id_responsavel,nm_usuario 'nm_responsavel' FROM movimenta_itens mi "
            sql += " INNER JOIN usuarios u ON(mi.id_responsavel=u.id_usuario) "
            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)
            Dim filtro As DataView = ds.Tables(0).DefaultView
            filtro.RowFilter = ""
            cboResponsavel.DataSource = filtro.ToTable(True, "id_responsavel", "nm_responsavel")
            cboResponsavel.Invoke(Sub()
                                      With cboResponsavel
                                          .ValueMember = "id_responsavel"
                                          .DisplayMember = "nm_responsavel"
                                          .SelectedIndex = -1
                                          .Text = ""
                                      End With
                                  End Sub)
            cboResponsavel.SelectedIndex = 0

            sql = ""
            sql += "SELECT 0 'id_item','Todos os itens' nm_item FROM DUAL UNION ALL SELECT i.id_item,nm_item FROM itens i INNER JOIN movimenta_itens mi ON(i.id_item=mi.id_item)"
            conn.Close()
            conn.Open()

            Dim comando2 As New MySqlCommand(sql, conn)
            Dim dr2 As New MySqlDataAdapter(comando2)
            Dim ds2 As New DataSet
            dr2.Fill(ds2)
            Dim filtro2 As DataView = ds2.Tables(0).DefaultView
            filtro2.RowFilter = ""
            cboItem.DataSource = filtro2.ToTable(True, "id_item", "nm_item")
            cboItem.Invoke(Sub()
                               With cboItem
                                   .ValueMember = "id_item"
                                   .DisplayMember = "nm_item"
                                   .SelectedIndex = -1
                                   .Text = ""
                               End With
                           End Sub)
            cboItem.SelectedIndex = 0

            sql = ""
            sql += "select 0 'id_receptor','Todos os receptores' nm_receptor from dual union all SELECT id_receptor,nm_usuario FROM movimenta_itens mi "
            sql += " INNER JOIN usuarios u ON(mi.id_responsavel=u.id_usuario) "

            conn.Close()
            conn.Open()

            Dim comando3 As New MySqlCommand(sql, conn)
            Dim dr3 As New MySqlDataAdapter(comando3)
            Dim ds3 As New DataSet
            dr3.Fill(ds3)
            Dim filtro3 As DataView = ds3.Tables(0).DefaultView
            filtro3.RowFilter = ""
            cboReceptor.DataSource = filtro3.ToTable(True, "id_receptor", "nm_receptor")
            cboReceptor.Invoke(Sub()
                                   With cboReceptor
                                       .ValueMember = "id_receptor"
                                       .DisplayMember = "nm_receptor"
                                       .SelectedIndex = -1
                                       .Text = ""
                                   End With

                               End Sub)

            cboReceptor.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub carregaCboTab3()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = ""
            sql += "SELECT 0 'id_usuario','Todos os usuarios' nm_usuario FROM DUAL UNION ALL SELECT id_enviado_por,nm_usuario FROM enviar_caixas ec INNER JOIN usuarios u ON(ec.id_enviado_por=u.id_usuario)"

            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)
            Dim filtro As DataView = ds.Tables(0).DefaultView
            filtro.RowFilter = ""
            cboEnviado.DataSource = filtro.ToTable(True, "id_usuario", "nm_usuario")
            cboEnviado.Invoke(Sub()
                                  With cboEnviado
                                      .ValueMember = "id_usuario"
                                      .DisplayMember = "nm_usuario"
                                      .SelectedIndex = -1
                                      .Text = ""
                                  End With

                              End Sub)

            cboEnviado.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub carregaDGV()

        ' Dim conn As New MySqlConnection(My.Settings.)
        Dim sql As String
        If tabPage = 0 Then
            sql = ""
            sql += "SELECT i.id_item, "
            sql += "i.nm_item, "
            sql += "descritivo, "
            sql += "sum(iv.quantidade)quantidade, "
            sql += "i.valor_venda vl_unitário, "
            sql += "sum(iv.valor_venda)vl_total, "
            sql += "c.nm_classe, "
            sql += "codigo_barras, "
            sql += "f.nome fornecedor, "
            sql += "date_format(iv.dt_venda,'%d/%m/%Y')dt_venda "
            sql += "FROM  itens i "
            sql += "INNER JOIN itens_vendidos iv ON(i.id_item=iv.id_item) "
            sql += "inner join classe_item     c on(i.classe_item=c.id_classe_item) "
            sql += "INNER JOIN fornecedores    f ON(i.id_fornecedor=f.id_fornecedor) "
            sql += "WHERE date_format(iv.dt_venda,'%Y-%m') BETWEEN DATE_FORMAT(STR_TO_DATE('01/" & Format(dtInicio.Value, "MM'/'yyyy") & "','%d/%m/%Y'),'%Y-%m') "
            sql += "And DATE_FORMAT(STR_TO_DATE('01/" & Format(dtFim.Value, "MM'/'yyyy") & "','%d/%m/%Y'),'%Y-%m') "
            If cboFornecedor.SelectedIndex <> 0 Then
                sql += "AND i.id_fornecedor = '" & cboFornecedor.SelectedValue & "' "
            End If
            If cboClasse.SelectedIndex <> 0 Then
                sql += "AND i.classe_item = '" & cboClasse.SelectedValue & "' "
            End If
            sql += " group by i.id_item,date_format(iv.dt_venda,'%d/%m/%Y') "

            montaVendidosMes(sql)

        ElseIf tabPage = 1 Then
            sql = ""
            sql += "select id_mov_it,"
            sql += "rp.nm_usuario 'nm_responsavel',"
            sql += "rc.nm_usuario 'nm_receptor',"
            sql += "nm_item,"
            sql += "quantidade_movida,"
            sql += "date_format(data_mov_it,'%d/%m/%Y %H:%i')data_mov_it "
            sql += "from itens i "
            sql += "inner join movimenta_itens mi on(i.id_item=mi.id_item) "
            sql += " INNER JOIN usuarios rc ON(mi.id_receptor=rc.id_usuario) "
            sql += " INNER JOIN usuarios rp ON(mi.id_responsavel=rp.id_usuario)"
            sql += "WHERE date_format(data_mov_it,'%Y-%m') BETWEEN DATE_FORMAT(STR_TO_DATE('01/" & Format(dtInicio2.Value, "MM'/'yyyy") & "','%d/%m/%Y'),'%Y-%m') "
            sql += "And DATE_FORMAT(STR_TO_DATE('01/" & Format(dtFim2.Value, "MM'/'yyyy") & "','%d/%m/%Y'),'%Y-%m') "
            If cboResponsavel.SelectedIndex <> 0 Then
                sql += "AND  id_responsavel= '" & cboResponsavel.SelectedValue & "' "
            End If
            If cboReceptor.SelectedIndex <> 0 Then
                sql += "AND id_receptor = '" & cboReceptor.SelectedValue & "' "
            End If
            If cboItem.SelectedIndex <> 0 Then
                sql += "AND i.id_item = '" & cboItem.SelectedValue & "' "
            End If
            montaMovimentaMes(sql)
        ElseIf tabPage = 2 Then
            sql = ""
            sql += "SELECT DISTINCT id_enviar_caixa,c.id_caixa,nm_caixa,nm_usuario, ec.nome_cliente, valor_total,DATE_FORMAT(ec.data_envio,'%d/%m/%Y')data_envio "
            sql += " FROM enviar_caixas ec "
            sql += "	INNER JOIN usuarios     u ON(ec.id_enviado_por=u.id_usuario)"
            sql += "	INNER JOIN caixas       c ON(ec.id_caixa=c.id_caixa)"
            sql += "	INNER JOIN caixa_itens ci ON(c.id_caixa=ci.id_caixa)"
            sql += "	INNER JOIN itens 	i ON(ci.id_item=i.id_item)"
            sql += "WHERE date_format(ec.data_envio,'%Y-%m') BETWEEN DATE_FORMAT(STR_TO_DATE('01/" & Format(dtInicio3.Value, "MM'/'yyyy") & "','%d/%m/%Y'),'%Y-%m') "
            sql += "And DATE_FORMAT(STR_TO_DATE('01/" & Format(dtFim3.Value, "MM'/'yyyy") & "','%d/%m/%Y'),'%Y-%m') "
            If cboEnviado.SelectedIndex <> 0 Then
                sql += "AND  id_usuario= '" & cboEnviado.SelectedValue & "' "
            End If
            montaCaixasEnviadas(sql)

        End If
    End Sub

    Private Sub montaCaixasEnviadas(sql As String)
        Dim conn As New MySqlConnection(My.Settings.conexao)

        Try
            dgvEmbaEnviadas.Invoke(Sub()
                                       dgvEmbaEnviadas.Columns.Clear()
                                       dgvEmbaEnviadas.ClearSelection()
                                       dgvEmbaEnviadas.DataSource = Nothing
                                       dgvEmbaEnviadas.Refresh()
                                       dgvEmbaEnviadas.AllowDrop = False
                                       dgvEmbaEnviadas.AllowUserToAddRows = False
                                       dgvEmbaEnviadas.AllowUserToResizeRows = False
                                       dgvEmbaEnviadas.AllowUserToDeleteRows = False
                                       dgvEmbaEnviadas.AllowUserToOrderColumns = False
                                       dgvEmbaEnviadas.AllowUserToResizeColumns = False
                                       dgvEmbaEnviadas.MultiSelect = False
                                   End Sub)

            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)

            dgvEmbaEnviadas.Invoke(Sub()
                                       If ds.Tables(0).Rows.Count > 0 Then

                                           dgvEmbaEnviadas.DataSource = ds.Tables(0)


                                           dgvEmbaEnviadas.Columns(0).Visible = False
                                           dgvEmbaEnviadas.Columns(1).Visible = False

                                           dgvEmbaEnviadas.Columns(2).HeaderText = "Nm embalagem"
                                           dgvEmbaEnviadas.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                           dgvEmbaEnviadas.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                                           dgvEmbaEnviadas.Columns(2).ReadOnly = True

                                           dgvEmbaEnviadas.Columns(3).HeaderText = "Enviado por"
                                           dgvEmbaEnviadas.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                           dgvEmbaEnviadas.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                                           dgvEmbaEnviadas.Columns(3).ReadOnly = True

                                           dgvEmbaEnviadas.Columns(4).HeaderText = "Cliente"
                                           dgvEmbaEnviadas.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                           dgvEmbaEnviadas.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
                                           dgvEmbaEnviadas.Columns(4).ReadOnly = True

                                           dgvEmbaEnviadas.Columns(5).HeaderText = "Vl embalagem"
                                           dgvEmbaEnviadas.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                           dgvEmbaEnviadas.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
                                           dgvEmbaEnviadas.Columns(5).ReadOnly = True

                                           dgvEmbaEnviadas.Columns(6).HeaderText = "Dt Envio"
                                           dgvEmbaEnviadas.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                           dgvEmbaEnviadas.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
                                           dgvEmbaEnviadas.Columns(6).ReadOnly = True
                                       End If
                                   End Sub)
            For i As Integer = 0 To dgvEmbaEnviadas.Rows.Count - 1
                dgvEmbaEnviadas.AutoResizeRow(i, DataGridViewAutoSizeRowMode.AllCells)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub montaMovimentaMes(sql As String)
        Dim conn As New MySqlConnection(My.Settings.conexao)

        Try
            dgvMovimenta.Invoke(Sub()
                                    dgvMovimenta.Columns.Clear()
                                    dgvMovimenta.ClearSelection()
                                    dgvMovimenta.DataSource = Nothing
                                    dgvMovimenta.Refresh()
                                    dgvMovimenta.AllowDrop = False
                                    dgvMovimenta.AllowUserToAddRows = False
                                    dgvMovimenta.AllowUserToResizeRows = False
                                    dgvMovimenta.AllowUserToDeleteRows = False
                                    dgvMovimenta.AllowUserToOrderColumns = False
                                    dgvMovimenta.AllowUserToResizeColumns = False
                                    dgvMovimenta.MultiSelect = False
                                End Sub)

            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)

            dgvMovimenta.Invoke(Sub()
                                    If ds.Tables(0).Rows.Count > 0 Then

                                        dgvMovimenta.DataSource = ds.Tables(0)


                                        dgvMovimenta.Columns(0).Visible = False

                                        dgvMovimenta.Columns(1).HeaderText = "Nm Responsavel"
                                        dgvMovimenta.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        dgvMovimenta.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvMovimenta.Columns(1).ReadOnly = True

                                        dgvMovimenta.Columns(2).HeaderText = "Nm Receptor"
                                        dgvMovimenta.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        dgvMovimenta.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvMovimenta.Columns(2).ReadOnly = True

                                        dgvMovimenta.Columns(3).HeaderText = "Item"
                                        dgvMovimenta.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        dgvMovimenta.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvMovimenta.Columns(3).ReadOnly = True

                                        dgvMovimenta.Columns(4).HeaderText = "Qtd. movida"
                                        dgvMovimenta.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        dgvMovimenta.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvMovimenta.Columns(4).ReadOnly = True

                                        dgvMovimenta.Columns(5).HeaderText = "Dt Movimentação"
                                        dgvMovimenta.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        dgvMovimenta.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
                                        dgvMovimenta.Columns(5).ReadOnly = True
                                    End If
                                End Sub)
            For i As Integer = 0 To dgvMovimenta.Rows.Count - 1
                dgvMovimenta.AutoResizeRow(i, DataGridViewAutoSizeRowMode.AllCells)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub
    Private Sub montaVendidosMes(sql As String)

        Dim conn As New MySqlConnection(My.Settings.conexao)

        Try
            dgvFornecedor.Invoke(Sub()
                                     dgvFornecedor.Columns.Clear()
                                     dgvFornecedor.ClearSelection()
                                     dgvFornecedor.DataSource = Nothing
                                     dgvFornecedor.Refresh()
                                     dgvFornecedor.AllowDrop = False
                                     dgvFornecedor.AllowUserToAddRows = False
                                     dgvFornecedor.AllowUserToResizeRows = False
                                     dgvFornecedor.AllowUserToDeleteRows = False
                                     dgvFornecedor.AllowUserToOrderColumns = False
                                     dgvFornecedor.AllowUserToResizeColumns = False
                                     dgvFornecedor.MultiSelect = False
                                 End Sub)

            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)

            dgvFornecedor.Invoke(Sub()
                                     If ds.Tables(0).Rows.Count > 0 Then

                                         dgvFornecedor.DataSource = ds.Tables(0)


                                         dgvFornecedor.Columns(0).Visible = False

                                         dgvFornecedor.Columns(1).HeaderText = "Item"
                                         dgvFornecedor.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                         dgvFornecedor.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                                         dgvFornecedor.Columns(1).ReadOnly = True

                                         dgvFornecedor.Columns(2).HeaderText = "Descritivo"
                                         dgvFornecedor.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                                         dgvFornecedor.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                                         dgvFornecedor.Columns(2).ReadOnly = True

                                         dgvFornecedor.Columns(3).HeaderText = "Qtd vendida"
                                         dgvFornecedor.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                         dgvFornecedor.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                                         dgvFornecedor.Columns(3).ReadOnly = True

                                         dgvFornecedor.Columns(4).HeaderText = "Vl unitário"
                                         dgvFornecedor.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                         dgvFornecedor.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
                                         dgvFornecedor.Columns(4).ReadOnly = True

                                         dgvFornecedor.Columns(5).HeaderText = "Vl total"
                                         dgvFornecedor.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                         dgvFornecedor.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
                                         dgvFornecedor.Columns(5).ReadOnly = True

                                         dgvFornecedor.Columns(6).HeaderText = "Classe"
                                         dgvFornecedor.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                         dgvFornecedor.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
                                         dgvFornecedor.Columns(6).ReadOnly = True

                                         dgvFornecedor.Columns(7).HeaderText = "Cd barras"
                                         dgvFornecedor.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                         dgvFornecedor.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
                                         dgvFornecedor.Columns(7).ReadOnly = True

                                         dgvFornecedor.Columns(8).HeaderText = "Fornecedor"
                                         dgvFornecedor.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                         dgvFornecedor.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
                                         dgvFornecedor.Columns(8).ReadOnly = True

                                         dgvFornecedor.Columns(9).HeaderText = "Dt venda"
                                         dgvFornecedor.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                         dgvFornecedor.Columns(9).SortMode = DataGridViewColumnSortMode.NotSortable
                                         dgvFornecedor.Columns(9).ReadOnly = True
                                     End If
                                 End Sub)
            For i As Integer = 0 To dgvFornecedor.Rows.Count - 1
                dgvFornecedor.AutoResizeRow(i, DataGridViewAutoSizeRowMode.AllCells)
            Next
            If dgvFornecedor.Rows.Count > 0 Then
                lvTotal = 0
                If dtInicio.Value.ToString("MMMM/yyyy") = dtFim.Value.ToString("MMMM/yyyy") Then
                    For i As Integer = 0 To dgvFornecedor.Rows.Count - 1
                        lvTotal += dgvFornecedor.Rows(i).Cells(5).Value
                    Next
                    lbTotal.Text = "Total do mês de " & dtInicio.Value.ToString("MMMM/yyyy") & ": " & lvTotal
                ElseIf dtInicio.Value.ToString("yyyy") = dtFim.Value.ToString("yyyy") Then

                    For i As Integer = 0 To dgvFornecedor.Rows.Count - 1
                        lvTotal += dgvFornecedor.Rows(i).Cells(5).Value
                    Next
                    lbTotal.Text = "Total dos meses entre " & dtInicio.Value.ToString("MMMM") & " a " & dtFim.Value.ToString("MMMM") & " de " & dtFim.Value.ToString("yyyy") & ": " & lvTotal
                Else
                    For i As Integer = 0 To dgvFornecedor.Rows.Count - 1
                        lvTotal += dgvFornecedor.Rows(i).Cells(5).Value
                    Next
                    lbTotal.Text = "Total entre o mês de " & dtInicio.Value.ToString("MMMM/yyyy") & " a " & dtFim.Value.ToString("MMMM/yyyy") & ": " & lvTotal
                End If
            Else
                lbTotal.Text = "Nenhum produto vendido nesse periodo"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub


    Private Sub MenusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenusToolStripMenuItem.Click
        frmMenus.ShowDialog()
    End Sub

    Private Sub CaixaRegistradoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnCaixaRegistradora.Click
        frmCaixaResgistradora.ShowDialog()
    End Sub

    Private Sub CriarCaixaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CriarCaixaToolStripMenuItem.Click
        frmCriaCaixa.ShowDialog()
    End Sub

    Private Sub MovimentarItensToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimentarItensToolStripMenuItem.Click
        frmMovimentaItens.ShowDialog()
    End Sub

    Private Sub SetoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetoresToolStripMenuItem.Click
        frmSetores.ShowDialog()
    End Sub

    Private Sub ColocarItensNaCaixaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColocarItensNaCaixaToolStripMenuItem.Click
        frmItensCaixa.ShowDialog()
    End Sub

    Private Sub FecharCaixaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FecharCaixaToolStripMenuItem.Click
        frmFecharCaixa.ShowDialog()
    End Sub

    Private Sub ReabrirCaixaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReabrirCaixaToolStripMenuItem.Click
        frmReabrirCaixa.ShowDialog()
    End Sub



    Private Sub EnviarCaixaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnviarCaixaToolStripMenuItem.Click
        frmEnviarCaixa.ShowDialog()
    End Sub



    Private Sub FornecedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FornecedoresToolStripMenuItem.Click
        frmFornecedores.ShowDialog()
    End Sub

    Private Sub dtInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtInicio.ValueChanged
        If valida = 0 Then
            Exit Sub
        End If
        carregaDGV()
    End Sub
    Private Sub dtFim_ValueChanged(sender As Object, e As EventArgs) Handles dtFim.ValueChanged
        If valida = 0 Then
            Exit Sub
        End If
        carregaDGV()
    End Sub

    Private Sub cboFornecedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFornecedor.SelectedIndexChanged
        carregaDGV()
    End Sub

    Private Sub cboClasse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClasse.SelectedIndexChanged
        carregaDGV()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If dgvFornecedor.Rows.Count = 0 Then
            MsgBox("Nenhum dado para ser exportado!!", vbExclamation, "Atenção")
            Exit Sub
        End If

        ExportToExcelWithFormat(dgvFornecedor)
    End Sub

    Public Sub ExportToExcelWithFormat(ByVal dataGridView1 As Windows.Forms.DataGridView)
        Dim contador = 0
        Dim rownum = 2
        If tabPage = 0 Then

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
            For colCount As Integer = 1 To dataGridView1.Columns.Count - 1

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
                    For colCount As Integer = 1 To dataGridView1.Columns.Count - 1
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
                        '   xlRange.Interior.Color = Drawing.ColorTranslator.ToOle(dataGridView1.Rows(rowCount).DefaultCellStyle.BackColor)

                        'defina a cor da fonte do xlrange para o styletyle.ForeColor da linha 
                        xlRange.Font.Color = dataGridView1.Rows(rowCount).Cells(colCount).Style.ForeColor.ToArgb()
                    Next
                    contador += 1
                End If

            Next
            Dim legenda1 As Excel.Range = CType(xlWorkSheet1.Cells(1, 1), Excel.Range)

            legenda1.Font.Size = 15
            legenda1.HorizontalAlignment = Excel.Constants.xlCenter
            legenda1.Font.Bold = 5
            If dtInicio.Value.ToString("MMMM/yyyy") = dtFim.Value.ToString("MMMM/yyyy") Then
                legenda1.Value = "Produtos vendidos no mês de " & dtInicio.Value.ToString("MMMM/yyyy")
            ElseIf dtInicio.Value.ToString("yyyy") = dtFim.Value.ToString("yyyy") Then
                legenda1.Value = "Produtos vendidos entre " & dtInicio.Value.ToString("MMMM") & " a " & dtFim.Value.ToString("MMMM") & " de " & dtFim.Value.ToString("yyyy")
            Else
                legenda1.Value = "Produtos vendidos entre " & dtInicio.Value.ToString("MMMM/yyyy") & " a " & dtFim.Value.ToString("MMMM/yyyy")
            End If

            Dim legenda2 As Excel.Range = CType(xlWorkSheet1.Cells(dataGridView1.Rows.Count + 3, 1), Excel.Range)

            legenda2.Font.Size = 15
            '  legenda2.HorizontalAlignment = Excel.Constants.xlCenter
            legenda2.Font.Bold = 5
            legenda2.Value = "Total: " & lvTotal

            Dim mergeRange As Excel.Range
            mergeRange = xlWorkSheet1.Range("a1", "i1")
            mergeRange.Borders.LineStyle = 7
            mergeRange.Merge()

            Dim mergeRange2 As Excel.Range
            mergeRange2 = xlWorkSheet1.Range("a" & dataGridView1.Rows.Count + 3, "i" & dataGridView1.Rows.Count + 3)
            mergeRange2.Borders.LineStyle = 7
            mergeRange2.Merge()

        ElseIf tabPage = 1 Then

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

            Dim mescla As Excel.Range
            mescla = xlWorkSheet1.Range("a2", "b2")
            mescla.Merge()
            Dim mescla2 As Excel.Range
            mescla2 = xlWorkSheet1.Range("c2", "d2")
            mescla2.Merge()
            Dim mescla3 As Excel.Range
            mescla3 = xlWorkSheet1.Range("e2", "f2")
            mescla3.Merge()
            Dim mescla4 As Excel.Range
            mescla4 = xlWorkSheet1.Range("h2", "i2")
            mescla4.Merge()

            Dim pulaColuna As Integer = 0
            Dim contaColuna As Integer = 0
            For colCount As Integer = 1 To dataGridView1.Columns.Count - 1

                If pulaColuna = 4 And contaColuna = 0 Then
                    pulaColuna -= 1
                    contaColuna += 1
                End If

                Dim xlRange As Excel.Range = CType(xlWorkSheet1.Cells(rownum, colCount + pulaColuna), Excel.Range)
                xlRange.VerticalAlignment = Excel.Constants.xlCenter
                xlRange.HorizontalAlignment = Excel.Constants.xlCenter
                xlRange.WrapText = True
                xlRange.Font.Bold = 5
                xlRange.ColumnWidth = 12
                xlRange.Columns(colCount).AutoFit
                Dim borda As Excel.Range = CType(xlWorkSheet1.Cells(rownum, colCount), Excel.Range)
                borda.Borders.LineStyle = 7
                If colCount = 5 Then
                    For i As Integer = 1 To 4
                        Dim borda2 As Excel.Range = CType(xlWorkSheet1.Cells(rownum, colCount + i), Excel.Range)
                        borda2.Borders.LineStyle = 7
                    Next
                End If

                xlRange.Value2 = dataGridView1.Columns(colCount).HeaderCell.Value.ToString

                pulaColuna += 1
            Next


            ' for each para cada linha no datagridview
            For rowCount As Integer = 0 To dataGridView1.Rows.Count - 1
                'se a linha estiver visível
                If dataGridView1.Rows(rowCount).Visible = True Then
                    'incrementar o número da linha para excel
                    rownum = rownum + 1
                    Dim Vetor() As String = {"a", "c", "e", "h"}
                    Dim Vetor2() As String = {"b", "d", "f", "i"}
                    Dim Nvetor As Integer = 0

                    'mergeRange2.Borders.LineStyle = 7

                    pulaColuna = 0
                    contaColuna = 0
                    For colCount As Integer = 1 To dataGridView1.Columns.Count - 1
                        If pulaColuna = 4 And contaColuna = 0 Then
                            pulaColuna -= 1
                            contaColuna += 1
                        End If
                        'crie um intervalo do Excel para o rownum e o columncount
                        Dim xlRange As Excel.Range = CType(xlWorkSheet1.Cells(rownum, colCount + pulaColuna), Excel.Range)
                        Try

                            Dim mergeRange2 As Excel.Range
                            mergeRange2 = xlWorkSheet1.Range(Vetor(Nvetor) & rownum, Vetor2(Nvetor) & rownum)
                            mergeRange2.Merge()
                            'adicione o valor da célula gridview ao intervalo de células e defina o tamano delas
                            xlRange.VerticalAlignment = Excel.Constants.xlCenter
                            xlRange.HorizontalAlignment = Excel.Constants.xlCenter

                            xlRange.WrapText = True
                            xlRange.ColumnWidth = 12
                            xlRange.Value2 = dataGridView1.Rows(rowCount).Cells(colCount).Value
                            Dim borda As Excel.Range = CType(xlWorkSheet1.Cells(rownum, colCount), Excel.Range)
                            borda.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                            If colCount = 5 Then
                                For i As Integer = 1 To 4
                                    Dim borda2 As Excel.Range = CType(xlWorkSheet1.Cells(rownum, colCount + i), Excel.Range)
                                    borda2.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                                Next
                            End If

                            pulaColuna += 1
                        Catch __unusedException1__ As Exception

                            MsgBox(__unusedException1__.Message)
                            Try
                                xlRange.Value2 = __unusedException1__.Message
                            Catch __unusedException11__ As Exception

                            End Try
                        End Try
                        'defina o intervalo interior do xlrange para o estilo de linha padrão da célula
                        '   xlRange.Interior.Color = Drawing.ColorTranslator.ToOle(dataGridView1.Rows(rowCount).DefaultCellStyle.BackColor)

                        'defina a cor da fonte do xlrange para o styletyle.ForeColor da linha 
                        xlRange.Font.Color = dataGridView1.Rows(rowCount).Cells(colCount).Style.ForeColor.ToArgb()

                        If Nvetor < 3 Then
                            Nvetor += 1
                        End If
                    Next
                    contador += 1
                End If

            Next
            Dim legenda1 As Excel.Range = CType(xlWorkSheet1.Cells(1, 1), Excel.Range)

            legenda1.Font.Size = 15
            legenda1.HorizontalAlignment = Excel.Constants.xlCenter
            legenda1.Font.Bold = 5
            If dtInicio2.Value.ToString("MMMM/yyyy") = dtFim2.Value.ToString("MMMM/yyyy") Then
                legenda1.Value = "Produtos movimentados no mês de " & dtInicio2.Value.ToString("MMMM/yyyy")
            ElseIf dtInicio2.Value.ToString("yyyy") = dtFim2.Value.ToString("yyyy") Then
                legenda1.Value = "Produtos movimentados entre " & dtInicio2.Value.ToString("MMMM") & " a " & dtFim2.Value.ToString("MMMM") & " de " & dtFim2.Value.ToString("yyyy")
            Else
                legenda1.Value = "Produtos movimentados entre " & dtInicio2.Value.ToString("MMMM/yyyy") & " a " & dtFim2.Value.ToString("MMMM/yyyy")
            End If

            Dim mergeRange As Excel.Range
            mergeRange = xlWorkSheet1.Range("a1", "i1")
            mergeRange.Borders.LineStyle = 7
            mergeRange.Merge()

        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        'MsgBox(TabControl1.SelectedIndex.ToString)
        tabPage = TabControl1.SelectedIndex
        carregaDGV()
    End Sub

    Private Sub dtInicio2_ValueChanged(sender As Object, e As EventArgs) Handles dtInicio2.ValueChanged
        If valida = 0 Then
            Exit Sub
        End If
        carregaDGV()
    End Sub

    Private Sub dtFim2_ValueChanged(sender As Object, e As EventArgs) Handles dtFim2.ValueChanged
        If valida = 0 Then
            Exit Sub
        End If
        carregaDGV()
    End Sub

    Private Sub cboReceptor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboResponsavel.SelectedIndexChanged, cboReceptor.SelectedIndexChanged, cboItem.SelectedIndexChanged
        carregaDGV()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ExportToExcelWithFormat(dgvMovimenta)
    End Sub

    Private Sub cboEnviado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEnviado.SelectedIndexChanged
        carregaDGV()
    End Sub

    Private Sub dtInicio3_ValueChanged(sender As Object, e As EventArgs) Handles dtInicio3.ValueChanged
        If valida = 0 Then
            Exit Sub
        End If
        carregaDGV()
    End Sub

    Private Sub dtFim3_ValueChanged(sender As Object, e As EventArgs) Handles dtFim3.ValueChanged
        If valida = 0 Then
            Exit Sub
        End If
        carregaDGV()
    End Sub
End Class
