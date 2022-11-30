Imports MySql.Data.MySqlClient
Public Class frmCriaCaixa
    Dim id As Integer = 0
    Private Sub frmCriaCaixa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregaDgv()
    End Sub

    Private Sub carregaDgv()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try

            dgvCaixa.Invoke(Sub()
                                dgvCaixa.Columns.Clear()
                                dgvCaixa.ClearSelection()
                                dgvCaixa.DataSource = Nothing
                                dgvCaixa.Refresh()
                                dgvCaixa.AllowDrop = False
                                dgvCaixa.AllowUserToAddRows = False
                                dgvCaixa.AllowUserToDeleteRows = False
                                dgvCaixa.AllowUserToResizeRows = False
                                dgvCaixa.AllowUserToResizeColumns = False
                                dgvCaixa.AllowUserToOrderColumns = False
                                dgvCaixa.MultiSelect = False
                                dgvCaixa.AllowUserToOrderColumns = False

                            End Sub)

            sql = ""
            sql += "SELECT"
            sql += " id_caixa,"
            sql += " nm_caixa,"
            sql += " descricao,"
            sql += " DATE_FORMAT(data_criacao,'%d/%m/%Y %H:%i')data_criacao,"
            sql += " u.login "
            sql += "FROM caixas c"
            sql += " INNER JOIN usuarios u ON(c.criado_por=u.id_usuario)"
            sql += " WHERE id_caixa NOT IN (SELECT id_caixa FROM caixas_fechadas) "
            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)

            dgvCaixa.Invoke(Sub()
                                dgvCaixa.DataSource = ds.Tables(0)
                                dgvCaixa.Columns(0).Visible = False

                                dgvCaixa.Columns(1).HeaderText = "Nm embalagem"
                                dgvCaixa.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                '  dgvCaixa.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvCaixa.Columns(1).ReadOnly = True

                                dgvCaixa.Columns(2).HeaderText = "Descrição"
                                'dgvCaixa.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvCaixa.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvCaixa.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                                dgvCaixa.Columns(2).ReadOnly = True

                                dgvCaixa.Columns(3).HeaderText = "Data de criação"
                                dgvCaixa.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                'dgvCaixa.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvCaixa.Columns(3).ReadOnly = True

                                dgvCaixa.Columns(4).HeaderText = "Criado por"
                                dgvCaixa.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                ' dgvCaixa.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvCaixa.Columns(4).ReadOnly = True

                                dgvCaixa.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                            End Sub)


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    Private Sub dgvCaixa_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCaixa.CellClick
        If e.RowIndex >= 0 Then
            txtNomeCaixa.Text = dgvCaixa.Rows(e.RowIndex).Cells(1).Value.ToString
            txtDescricao.Text = dgvCaixa.Rows(e.RowIndex).Cells(2).Value.ToString
            id = dgvCaixa.Rows(e.RowIndex).Cells(0).Value.ToString
            btnAlterar.Enabled = True
            btnExcluir.Enabled = True
            txtDescricao.Enabled = False
            txtNomeCaixa.Enabled = False
        End If
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        If id = 0 Then
            MsgBox("Selecione uma caixa", vbExclamation, "Atenção")
            Exit Sub
        End If

        txtDescricao.Enabled = True
        txtNomeCaixa.Enabled = True
        btnSalvar.Enabled = True
        btnSalvar.Text = "Alterar"
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If txtNomeCaixa.Text = "" Then
            MsgBox("Preencha o campo ""Nome da embalagem""", vbExclamation, "Atenção")
            txtNomeCaixa.Focus()
            Exit Sub
        ElseIf txtDescricao.text = "" Then
            MsgBox("Preencha o campo ""Descrição""", vbExclamation, "Atenção")
            txtDescricao.Focus()
            Exit Sub
        ElseIf btnSalvar.Text = "Alterar" Then
            Dim conn As New MySqlConnection(My.Settings.conexao)
            Dim sql As String

            Try
                sql = ""
                sql += "UPDATE caixas SET nm_caixa = '" & txtNomeCaixa.Text & "', descricao='" & txtDescricao.Text & "' WHERE id_caixa=" & id
                conn.Close()
                conn.Open()

                Dim comando As New MySqlCommand(sql, conn)
                comando.ExecuteReader()
                carregaDgv()
                txtNomeCaixa.Text = ""
                txtDescricao.Text = ""
                txtNomeCaixa.Enabled = False
                txtDescricao.Enabled = False
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
                conn.Dispose()
            End Try
        ElseIf btnSalvar.Text = "Salvar" Then
            Dim conn As New MySqlConnection(My.Settings.conexao)
            Dim sql As String

            Try
                sql = ""
                sql += "INSERT INTO caixas (nm_caixa,descricao,data_criacao,criado_por) VALUES('" & txtNomeCaixa.Text & "','" & txtDescricao.Text & "',"
                sql += "NOW()," & id_usuario & ")"
                conn.Close()
                conn.Open()
                Dim comando As New MySqlCommand(sql, conn)
                comando.ExecuteReader()
                carregaDgv()
                txtNomeCaixa.Text = ""
                txtDescricao.Text = ""
                txtNomeCaixa.Enabled = False
                txtDescricao.Enabled = False
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
                conn.Dispose()
            End Try
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmCriaCaixa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtDescricao.Enabled = False
        txtNomeCaixa.Enabled = False
        btnSalvar.Enabled = False
        txtNomeCaixa.Text = ""
        txtDescricao.Text = ""
        id = 0
        btnAlterar.Enabled = False
        btnExcluir.Enabled = False
        dgvCaixa.Invoke(Sub()
                            dgvCaixa.Columns.Clear()
                            dgvCaixa.ClearSelection()
                            dgvCaixa.DataSource = Nothing
                            dgvCaixa.Refresh()
                            dgvCaixa.AllowDrop = False
                            dgvCaixa.AllowUserToAddRows = False
                            dgvCaixa.AllowUserToDeleteRows = False
                            dgvCaixa.AllowUserToResizeRows = False
                            dgvCaixa.AllowUserToResizeColumns = False
                            dgvCaixa.AllowUserToOrderColumns = False
                            dgvCaixa.MultiSelect = False
                            dgvCaixa.AllowUserToOrderColumns = False

                        End Sub)
    End Sub

    Private Sub btnCriar_Click(sender As Object, e As EventArgs) Handles btnCriar.Click
        txtNomeCaixa.Text = ""
        txtDescricao.Text = ""
        txtDescricao.Enabled = True
        txtNomeCaixa.Enabled = True
        btnSalvar.Enabled = True
        btnSalvar.Text = "Salvar"
        dgvCaixa.ClearSelection()
        id = 0
        btnExcluir.Enabled = False
        btnAlterar.Enabled = False
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If id = 0 Then
            MsgBox("Selecione uma caixa", vbExclamation, "Atenção")
            Exit Sub
        End If
        If MsgBox("Deseja realmente excluir a Caixa " & Chr(34) & txtNomeCaixa.Text & Chr(34) & " ? " & Chr(13) & "todos os itens que estão nessa caixa serão retirados", vbQuestion + vbYesNo + vbDefaultButton2, "Message Box Title") = vbNo Then
            Exit Sub
        End If
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = ""
            sql += "DELETE FROM caixas WHERE id_caixa =" & id
            conn.Close()
            conn.Open()
            Dim comando As New MySqlCommand(sql, conn)
            comando.ExecuteReader()
            carregaDgv()
            txtNomeCaixa.Text=""
            txtDescricao.Text = ""
            txtNomeCaixa.Enabled = False
            txtDescricao.Enabled = False
            btnAlterar.Enabled = False
            btnExcluir.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
End Class