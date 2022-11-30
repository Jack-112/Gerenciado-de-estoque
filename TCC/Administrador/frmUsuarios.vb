Imports MySql.Data.MySqlClient
Public Class frmUsuarios
    Dim id As Integer = 0
    Private Sub frmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregaDgv()
        carregaCBO()
        cboNivel.SelectedIndex = 0
    End Sub

    Private Sub carregaCBO()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = ""
            sql += "SELECT 0 'id_setor','Selecione um setor' nm_setor FROM DUAL UNION ALL SELECT id_setor,nm_setor FROM setores"

            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)
            Dim filtro As DataView = ds.Tables(0).DefaultView
            filtro.RowFilter = ""
            cboSetor.DataSource = filtro.ToTable(True, "id_setor", "nm_setor")
            cboSetor.Invoke(Sub()
                                With cboSetor
                                    .ValueMember = "id_setor"
                                    .DisplayMember = "nm_setor"
                                    .SelectedIndex = -1
                                    .Text = ""
                                End With

                            End Sub)

            cboSetor.SelectedIndex = 0

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
        txtNome.Enabled = False
        txtUsuario.Enabled = False
        txtSenha.Enabled = False
        txtDataNas.Enabled = False
        cboNivel.Enabled = False
        btnSalvar.Enabled = False
        txtNome.Text = ""
        txtUsuario.Text = ""
        txtSenha.Text = ""
        cboNivel.SelectedItem = ""
        txtDataNas.Text = ""
        id = 0
        btnSalvar.Text = "Salvar"
        Try
            usuariosDgv.Invoke(Sub()
                                   usuariosDgv.Columns.Clear()
                                   usuariosDgv.ClearSelection()
                                   usuariosDgv.DataSource = Nothing
                                   usuariosDgv.Refresh()
                                   usuariosDgv.AllowDrop = False
                                   usuariosDgv.AllowUserToAddRows = False
                                   usuariosDgv.AllowUserToDeleteRows = False
                                   usuariosDgv.AllowUserToResizeRows = False
                                   usuariosDgv.AllowUserToResizeColumns = False
                                   usuariosDgv.AllowUserToOrderColumns = False
                                   usuariosDgv.MultiSelect = False
                                   usuariosDgv.AllowUserToOrderColumns = False

                               End Sub)
            sql = ""
            sql += "SELECT id_usuario,login,nm_usuario,DATE_FORMAT(dt_nascimento,'%d/%m/%Y')data_nas,nm_setor,tp_usuario,senha FROM usuarios u"
            sql += " left join setores s on(u.id_setor=s.id_setor)"

            conn.Close()
            conn.Open()
            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)

            usuariosDgv.Invoke(Sub()
                                   usuariosDgv.DataSource = ds.Tables(0)

                                   usuariosDgv.Columns(0).Visible = False

                                   usuariosDgv.Columns(1).HeaderText = "Login"
                                   usuariosDgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                   usuariosDgv.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                                   usuariosDgv.Columns(1).ReadOnly = True

                                   usuariosDgv.Columns(2).HeaderText = "Nome"
                                   usuariosDgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                   usuariosDgv.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                                   usuariosDgv.Columns(2).ReadOnly = True

                                   usuariosDgv.Columns(3).HeaderText = "Data de nascimento"
                                   usuariosDgv.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                   usuariosDgv.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                                   usuariosDgv.Columns(3).ReadOnly = True

                                   usuariosDgv.Columns(4).HeaderText = "Setor"
                                   usuariosDgv.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                   usuariosDgv.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
                                   usuariosDgv.Columns(4).ReadOnly = True

                                   usuariosDgv.Columns(5).HeaderText = "Nivel de usuario"
                                   usuariosDgv.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                   usuariosDgv.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
                                   usuariosDgv.Columns(5).ReadOnly = True

                                   usuariosDgv.Columns(6).Visible = False
                               End Sub)


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()

        End Try
    End Sub

    Private Sub usuariosDgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles usuariosDgv.CellClick
        If e.RowIndex >= 0 Then

            txtUsuario.Text = usuariosDgv.Rows(e.RowIndex).Cells(1).Value.ToString
            txtNome.Text = usuariosDgv.Rows(e.RowIndex).Cells(2).Value.ToString
            txtDataNas.Text = usuariosDgv.Rows(e.RowIndex).Cells(3).Value.ToString
            cboSetor.Text = usuariosDgv.Rows(e.RowIndex).Cells(4).Value
            cboNivel.SelectedItem = usuariosDgv.Rows(e.RowIndex).Cells(5).Value.ToString
            txtSenha.Text = usuariosDgv.Rows(e.RowIndex).Cells(6).Value.ToString

            id = usuariosDgv.Rows(e.RowIndex).Cells(0).Value.ToString

            btnEditar.Enabled = True
            btnSalvar.Text = "Alterar"
        End If
    End Sub

    Private Sub btnCalcelar_Click(sender As Object, e As EventArgs) Handles btnCalcelar.Click
        Me.Close()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        txtNome.Enabled = True
        txtUsuario.Enabled = True
        txtSenha.Enabled = True
        txtDataNas.Enabled = True
        cboNivel.Enabled = True
        btnSalvar.Enabled = True
        cboSetor.Enabled = True
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String
        If cboNivel.SelectedIndex = 0 Then
            MsgBox("Por favor, selecione um nível para o usuario", vbExclamation, "Atenção")
            Exit Sub
        End If
        If btnSalvar.Text = "Alterar" Then
            Try
                sql = ""
                sql += "UPDATE usuarios SET login ='" & txtUsuario.Text & "',"
                sql += "nm_usuario='" & txtNome.Text & "',"
                sql += "dt_nascimento=DATE(STR_TO_DATE('" & txtDataNas.Text & "','%d/%m/%Y')), "
                sql += "tp_usuario='" & cboNivel.Text & "',senha='" & txtSenha.Text & "', "
                sql += "id_setor= " & cboSetor.SelectedValue
                sql += " WHERE id_usuario=" & id

                conn.Close()
                conn.Open()

                Dim comando As New MySqlCommand(sql, conn)
                comando.ExecuteReader()

                MsgBox("Usuário alterado com sucesu", vbInformation, "Informação")
                carregaDgv()

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
                conn.Dispose()
            End Try
        Else
            Try
                sql = ""
                sql += "INSERT INTO usuarios (login,nm_usuario,dt_nascimento,tp_usuario,senha,id_setor)"
                sql += "VALUES ('" & txtUsuario.Text & "','" & txtNome.Text & "',DATE(STR_TO_DATE('" & txtDataNas.Text & "','%d/%m/%Y')),'" & cboNivel.Text & "','1234'," & cboSetor.SelectedValue & ")"
                conn.Close()
                conn.Open()

                Dim comando As New MySqlCommand(sql, conn)
                comando.ExecuteReader()

                MsgBox("Usuário cadastrado com sucesu", vbInformation, "Informação")
                carregaDgv()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
                conn.Dispose()
            End Try
        End If

    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        txtNome.Enabled = True
        txtUsuario.Enabled = True
        txtSenha.Enabled = True
        txtDataNas.Enabled = True
        cboNivel.Enabled = True
        btnSalvar.Enabled = True
        cboSetor.Enabled = True
        txtNome.Text = ""
        txtUsuario.Text = ""
        txtSenha.Text = ""
        cboNivel.SelectedItem = ""
        txtDataNas.Text = ""
        id = 0
        btnSalvar.Text = "Salvar"
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String
        If id = 0 Then
            MsgBox("Selecione um usuário para deletar", vbExclamation, "Atenção")
            Exit Sub
        End If
        If MsgBox("Deseja realmente excluir o usuário " & txtNome.Text & " ?", vbQuestion + vbYesNo + vbDefaultButton2, "Message Box Title") = vbNo Then
            Exit Sub
        Else
            Try
                Sql = ""
                sql += "DELETE FROM usuarios WHERE id_usuario=" & id
                conn.Close()
                conn.Open()

                Dim comando As New MySqlCommand(sql, conn)
                comando.ExecuteReader()
                MsgBox("Usuário deletado com sucesu", vbInformation, "Informação")
                carregaDgv()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
                conn.Dispose()
            End Try
        End If
    End Sub
End Class