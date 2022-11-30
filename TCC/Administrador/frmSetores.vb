Imports MySql.Data.MySqlClient

Public Class frmSetores
    Dim id_setor As Integer = 0
    Private Sub frmSetores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregaDgv()
        carregaCbo()
    End Sub
    Private Sub carregaCbo()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String
        Try

            sql = ""
            sql += "SELECT 0 'id_usuario','Selecione um usuário' nm_usuario FROM DUAL UNION ALL SELECT nm_usuario,nm_usuario FROM usuarios"

            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)
            Dim filtro As DataView = ds.Tables(0).DefaultView
            filtro.RowFilter = ""
            cboEncarregado.DataSource = filtro.ToTable(True, "id_usuario", "nm_usuario")
            cboEncarregado.Invoke(Sub()
                                      With cboEncarregado
                                          .ValueMember = "id_usuario"
                                          .DisplayMember = "nm_usuario"
                                          .SelectedIndex = -1
                                          .Text = ""
                                      End With
                                  End Sub)
            cboEncarregado.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub carregaDgv()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try

            dgvSetores.Invoke(Sub()
                                  dgvSetores.Columns.Clear()
                                  dgvSetores.ClearSelection()
                                  dgvSetores.DataSource = Nothing
                                  dgvSetores.Refresh()
                                  dgvSetores.AllowDrop = False
                                  dgvSetores.AllowUserToAddRows = False
                                  dgvSetores.AllowUserToResizeRows = False
                                  dgvSetores.AllowUserToOrderColumns = False
                                  dgvSetores.AllowUserToResizeColumns = False
                                  dgvSetores.MultiSelect = False
                              End Sub)

            sql = ""
            sql += "SELECT "
            sql += " id_setor,"
            sql += " nm_setor,"
            sql += " nm_encarregado,"
            sql += " contato_encarregado"
            sql += " FROM setores "

            conn.Close()
            conn.Open()
            Dim comando As New MySqlCommand(sql, conn)
            Dim da As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            da.Fill(ds)


            dgvSetores.Invoke(Sub()
                                  dgvSetores.DataSource = ds.Tables(0)
                                  dgvSetores.Columns(0).Visible = False

                                  dgvSetores.Columns(1).HeaderText = "Setor"
                                  dgvSetores.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                  dgvSetores.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                                  dgvSetores.Columns(1).ReadOnly = True

                                  dgvSetores.Columns(2).HeaderText = "Encarregado"
                                  dgvSetores.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                                  dgvSetores.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                                  dgvSetores.Columns(2).ReadOnly = True

                                  dgvSetores.Columns(3).HeaderText = "Ramal"
                                  dgvSetores.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                  dgvSetores.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                                  dgvSetores.Columns(3).ReadOnly = True


                              End Sub)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    Private Sub dgvSetores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSetores.CellClick
        txtNome.Text = dgvSetores.Rows(e.RowIndex).Cells(1).Value.ToString
        txtRamal.Mask = "(99)00000-0000"
        txtRamal.Text = dgvSetores.Rows(e.RowIndex).Cells(3).Value.ToString
        cboEncarregado.Text = dgvSetores.Rows(e.RowIndex).Cells(2).Value.ToString
        id_setor = dgvSetores.Rows(e.RowIndex).Cells(0).Value
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If id_setor = 0 Then
            MsgBox("Escolha um setor", vbExclamation, "Atenção")
            Exit Sub
        End If
        btnSalvar.Text = "Alterar"
        cboEncarregado.Enabled = True
        txtNome.Enabled = True
        txtRamal.Enabled = True
        dgvSetores.Enabled = False
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If btnSalvar.Text = "Alterar" And cboEncarregado.SelectedIndex <> 0 Then
            Dim conn As New MySqlConnection(My.Settings.conexao)
            Dim sql As String

            Try
                sql = "UPDATE setores SET nm_setor='" & txtNome.Text & "', nm_encarregado='" & cboEncarregado.SelectedValue.ToString & "' ,contato_encarregado='" & txtRamal.Text & "' WHERE id_setor=" & id_setor
                conn.Close()
                conn.Open()
                Dim comando As New MySqlCommand(sql, conn)
                comando.ExecuteReader()

                MsgBox("Setor alterado com sucesso")

                carregaDgv()
                dgvSetores.Enabled = True
                btnSalvar.Text = "Salvar"
                cboEncarregado.Enabled = False
                txtNome.Enabled = False
                txtRamal.Enabled = False
                txtNome.Text = ""
                txtRamal.Text = ""
                cboEncarregado.SelectedIndex = 0
                id_setor = 0
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
                conn.Dispose()
            End Try
        ElseIf btnSalvar.Text = "Salvar" And cboEncarregado.SelectedIndex <> 0 Then
            Dim conn As New MySqlConnection(My.Settings.conexao)
            Dim sql As String

            Try
                sql = "INSERT INTO setores (nm_setor,contato_encarregado,nm_encarregado) VALUES ('" & txtNome.Text & "','" & txtRamal.Text & "','" & cboEncarregado.SelectedValue.ToString & "')"
                conn.Close()
                conn.Open()
                Dim comando As New MySqlCommand(sql, conn)
                comando.ExecuteReader()

                MsgBox("Setor alterado com sucesso")

                carregaDgv()
                dgvSetores.Enabled = True
                btnSalvar.Text = "Salvar"
                cboEncarregado.Enabled = False
                txtNome.Enabled = False
                txtRamal.Enabled = False
                txtNome.Text = ""
                txtRamal.Text = ""
                cboEncarregado.SelectedIndex = 0
                id_setor = 0
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
                conn.Dispose()
            End Try
        End If
    End Sub

    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        btnSalvar.Text = "Salvar"
        cboEncarregado.Enabled = True
        txtNome.Enabled = True
        txtRamal.Enabled = True
        dgvSetores.Enabled = False
        txtNome.Text = ""
        txtRamal.Mask = "(99)00000-0000"
        txtRamal.Text = ""
        cboEncarregado.SelectedIndex = 0
        id_setor = 0
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If id_setor = 0 Then
            MsgBox("Escolha um setor", vbExclamation, "Atenção")
            Exit Sub
        End If
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = "DELETE FROM setores WHERE id_setor=" & id_setor
            conn.Close()
            conn.Open()
            Dim comando As New MySqlCommand(sql, conn)
            comando.ExecuteReader()

            MsgBox("Setor deletado com sucesso")

            carregaDgv()
            dgvSetores.Enabled = True
            btnSalvar.Text = "Salvar"
            cboEncarregado.Enabled = False
            txtNome.Enabled = False
            txtRamal.Enabled = False
            txtNome.Text = ""
            txtRamal.Text = ""
            cboEncarregado.SelectedIndex = 0
            id_setor = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        dgvSetores.Enabled = True
        btnSalvar.Text = "Salvar"
        cboEncarregado.Enabled = False
        txtNome.Enabled = False
        txtRamal.Enabled = False
        txtNome.Text = ""
        txtRamal.Text = ""
        cboEncarregado.SelectedIndex = 0
        id_setor = 0
        dgvSetores.Invoke(Sub()
                              dgvSetores.Columns.Clear()
                              dgvSetores.ClearSelection()
                              dgvSetores.DataSource = Nothing
                              dgvSetores.Refresh()
                              dgvSetores.AllowDrop = False
                              dgvSetores.AllowUserToAddRows = False
                              dgvSetores.AllowUserToResizeRows = False
                              dgvSetores.AllowUserToOrderColumns = False
                              dgvSetores.AllowUserToResizeColumns = False
                              dgvSetores.MultiSelect = False
                          End Sub)
    End Sub
End Class