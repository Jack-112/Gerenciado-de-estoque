Imports MySql.Data.MySqlClient
Public Class frmAddClasse
    Dim id As Integer
    Private Sub frmAddClasse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregaDgv()
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
                                dgvItens.AllowUserToDeleteRows = False
                                dgvItens.AllowUserToResizeRows = False
                                dgvItens.AllowUserToResizeColumns = False
                                dgvItens.AllowUserToOrderColumns = False
                                dgvItens.MultiSelect = False
                                dgvItens.AllowUserToOrderColumns = False

                            End Sub)

            sql = ""
            sql += "SELECT * FROM classe_item "

            conn.Close()
            conn.Open()
            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)

            dgvItens.Invoke(Sub()
                                dgvItens.DataSource = ds.Tables(0)

                                dgvItens.Columns(0).Visible = False

                                dgvItens.Columns(1).HeaderText = "Classe"
                                dgvItens.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(1).ReadOnly = True

                                dgvItens.Columns(2).HeaderText = "Descrição"
                                dgvItens.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(2).ReadOnly = True
                            End Sub)


            btnSalvar.Text = "Salvar"
            dgvItens.Enabled = True
            txtNome.Text = ""
            txtDescricao.Text = ""
            txtNome.Enabled = False
            txtDescricao.Enabled = False
            btnSalvar.Enabled = False
            id = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub



    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBusca.TextChanged
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
                                dgvItens.AllowUserToDeleteRows = False
                                dgvItens.AllowUserToResizeRows = False
                                dgvItens.AllowUserToResizeColumns = False
                                dgvItens.AllowUserToOrderColumns = False
                                dgvItens.MultiSelect = False
                                dgvItens.AllowUserToOrderColumns = False

                            End Sub)

            sql = ""
            sql += "SELECT * FROM classe_item WHERE nm_classe LIKE '%" & txtBusca.Text.ToString & "%' OR ds_classe LIKE '%" & txtBusca.Text.ToString & "%' "

            conn.Close()
            conn.Open()
            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)

            dgvItens.Invoke(Sub()
                                dgvItens.DataSource = ds.Tables(0)

                                dgvItens.Columns(0).Visible = False

                                dgvItens.Columns(1).HeaderText = "Classe"
                                dgvItens.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(1).ReadOnly = True

                                dgvItens.Columns(2).HeaderText = "Descrição"
                                dgvItens.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                                dgvItens.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvItens.Columns(2).ReadOnly = True
                            End Sub)



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    Private Sub dgvItens_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellClick
        If e.RowIndex >= 0 Then
            txtNome.Text = dgvItens.Rows(e.RowIndex).Cells(1).Value.ToString
            txtDescricao.Text = dgvItens.Rows(e.RowIndex).Cells(2).Value.ToString
            id = dgvItens.Rows(e.RowIndex).Cells(0).Value.ToString
            btnEditar.Enabled = True
            btnExcluir.Enabled = True
        End If
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If id <> 0 Then
            Dim conn As New MySqlConnection(My.Settings.conexao)
            Dim sql As String
            If MsgBox("Deseja realmente excluir a classe" & txtNome.Text & " ?", vbQuestion + vbYesNo + vbDefaultButton2, "Atenção") = vbNo Then
                Exit Sub
            End If
            Try
                    sql = ""
                    sql += "DELETE FROM classe_item WHERE id_classe_item = " & id
                    conn.Close()
                    conn.Open()
                    Dim comando As New MySqlCommand(sql, conn)
                    comando.ExecuteReader()

                    MsgBox("Classe de item deletada com sucesso !!!", vbInformation, "Atenção")

                    carregaDgv()
                    frmCadastroItens.carregaCbo()

                    dgvItens.Enabled = True
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Close()
                    conn.Dispose()
                End Try

            End If
    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        btnSalvar.Text = "Salvar"
        dgvItens.Enabled = False
        btnSalvar.Enabled = True
        txtNome.Enabled = True
        txtDescricao.Enabled = True
        txtNome.Text = ""
        txtDescricao.Text = ""
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If txtNome.Text <> "" And txtDescricao.Text <> "" And btnSalvar.Text = "Salvar" Then
            Dim conn As New MySqlConnection(My.Settings.conexao)
            Dim sql As String

            Try
                sql = ""
                sql += "INSERT INTO classe_item (nm_classe,ds_classe) VALUES('" & txtNome.Text & "','" & txtDescricao.Text & "')"
                conn.Close()
                conn.Open()
                Dim comando As New MySqlCommand(sql, conn)
                comando.ExecuteReader()

                MsgBox("Classe de item inserida com sucesso !!!", vbInformation, "Atenção")
                frmCadastroItens.carregaCbo()
                carregaDgv()
                dgvItens.Enabled = True
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
                conn.Dispose()
            End Try
        ElseIf txtNome.Text = "" Or txtDescricao.Text = "" Then
            MsgBox("Preencha todos os campos", vbExclamation, "Atenção")
            Exit Sub
        Else
            Dim conn As New MySqlConnection(My.Settings.conexao)
            Dim sql As String
            Try
                sql = ""
                sql += "update classe_item set nm_classe='" & txtNome.Text & "',ds_classe='" & txtDescricao.Text & "' where id_classe_item =" & id
                conn.Close()
                conn.Open()
                Dim comando As New MySqlCommand(sql, conn)
                comando.ExecuteReader()

                MsgBox("Alteração feita com sucesso !!!", vbInformation, "Atenção")
                frmCadastroItens.carregaCbo()
                carregaDgv()
                dgvItens.Enabled = True
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
                conn.Dispose()
            End Try

        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        btnSalvar.Text = "Alterar"
        dgvItens.Enabled = False

        txtNome.Enabled = True
        txtDescricao.Enabled = True
        btnSalvar.Enabled = True

    End Sub

    Private Sub btnCancelar_Click() Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmAddClasse_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        btnSalvar.Text = "Salvar"
        dgvItens.Enabled = True
        txtNome.Text = ""
        txtDescricao.Text = Nothing
        txtNome.Enabled = False
        txtDescricao.Enabled = False
        btnSalvar.Enabled = False
        id = 0
        dgvItens.Invoke(Sub()
                            dgvItens.Columns.Clear()
                            dgvItens.ClearSelection()
                            dgvItens.DataSource = Nothing
                        End Sub)
    End Sub
End Class