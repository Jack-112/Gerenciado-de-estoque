Imports MySql.Data.MySqlClient
Public Class frmFornecedores
    Dim cancela As Integer = 0
    Dim editar As Boolean = False
    Dim id As Integer = 0
    Private Sub frmFornecedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregaDGV()
    End Sub

    Private Sub carregaDGV()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

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
            sql = ""
            sql += "SELECT * FROM fornecedores"
            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)

            dgvFornecedor.Invoke(Sub()
                                     dgvFornecedor.DataSource = ds.Tables(0)
                                     dgvFornecedor.Columns(0).Visible = False

                                     dgvFornecedor.Columns(1).HeaderText = "Nome"
                                     dgvFornecedor.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                     dgvFornecedor.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                                     dgvFornecedor.Columns(1).ReadOnly = True

                                     dgvFornecedor.Columns(2).HeaderText = "Logradouro"
                                     dgvFornecedor.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                     dgvFornecedor.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                                     dgvFornecedor.Columns(2).ReadOnly = True

                                     dgvFornecedor.Columns(3).HeaderText = "Bairro"
                                     dgvFornecedor.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                     dgvFornecedor.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                                     dgvFornecedor.Columns(3).ReadOnly = True

                                     dgvFornecedor.Columns(4).HeaderText = "Número"
                                     dgvFornecedor.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                     dgvFornecedor.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
                                     dgvFornecedor.Columns(4).ReadOnly = True

                                     dgvFornecedor.Columns(5).HeaderText = "Estado"
                                     dgvFornecedor.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                     dgvFornecedor.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
                                     dgvFornecedor.Columns(5).ReadOnly = True

                                     dgvFornecedor.Columns(6).HeaderText = "Cidade"
                                     dgvFornecedor.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                     dgvFornecedor.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
                                     dgvFornecedor.Columns(6).ReadOnly = True

                                     dgvFornecedor.Columns(7).HeaderText = "Cep"
                                     dgvFornecedor.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                     dgvFornecedor.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
                                     dgvFornecedor.Columns(7).ReadOnly = True

                                     dgvFornecedor.Columns(8).HeaderText = "Telefone"
                                     dgvFornecedor.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                     dgvFornecedor.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
                                     dgvFornecedor.Columns(8).ReadOnly = True

                                     dgvFornecedor.Columns(9).HeaderText = "Email"
                                     dgvFornecedor.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                     dgvFornecedor.Columns(9).SortMode = DataGridViewColumnSortMode.NotSortable
                                     dgvFornecedor.Columns(9).ReadOnly = True

                                     dgvFornecedor.Columns(10).HeaderText = "Cnpj"
                                     dgvFornecedor.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                     dgvFornecedor.Columns(10).SortMode = DataGridViewColumnSortMode.NotSortable
                                     dgvFornecedor.Columns(10).ReadOnly = True

                                 End Sub)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    Private Sub dgvFornecedor_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFornecedor.CellClick
        If e.RowIndex >= 0 And editar = False Then
            id = dgvFornecedor.Rows(e.RowIndex).Cells(0).Value
            txtNome.Text = dgvFornecedor.Rows(e.RowIndex).Cells(1).Value
            txtLogradouro.Text = dgvFornecedor.Rows(e.RowIndex).Cells(2).Value
            txtBairro.Text = dgvFornecedor.Rows(e.RowIndex).Cells(3).Value
            txtNumero.Text = dgvFornecedor.Rows(e.RowIndex).Cells(4).Value
            txtEstado.Text = dgvFornecedor.Rows(e.RowIndex).Cells(5).Value
            txtCidade.Text = dgvFornecedor.Rows(e.RowIndex).Cells(6).Value
            txtCep.Text = dgvFornecedor.Rows(e.RowIndex).Cells(7).Value
            txtTelefone.Text = dgvFornecedor.Rows(e.RowIndex).Cells(8).Value
            txtEmail.Text = dgvFornecedor.Rows(e.RowIndex).Cells(9).Value
            txtCnpj.Text = dgvFornecedor.Rows(e.RowIndex).Cells(10).Value
            btnEditar.Enabled = True
            btnExcluir.Enabled = True
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        cancela = 0
        txtNome.Enabled = True
        txtLogradouro.Enabled = True
        txtBairro.Enabled = True
        txtNumero.Enabled = True
        txtEstado.Enabled = True
        txtCidade.Enabled = True
        txtCep.Enabled = True
        txtTelefone.Enabled = True
        txtEmail.Enabled = True
        txtCnpj.Enabled = True
        btnSalvar.Enabled = True
        btnSalvar.Text = "Alterar"
        editar = True
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        btnSalvar.Text = "Salvar"
        btnSalvar.Enabled = False
        txtNome.Text = ""
        txtLogradouro.Text = ""
        txtBairro.Text = ""
        txtNumero.Text = ""
        txtEstado.Text = ""
        txtCidade.Text = ""
        txtCep.Text = ""
        txtTelefone.Text = ""
        txtEmail.Text = ""
        txtCnpj.Text = ""

        txtNome.Enabled = False
        txtLogradouro.Enabled = False
        txtBairro.Enabled = False
        txtNumero.Enabled = False
        txtEstado.Enabled = False
        txtCidade.Enabled = False
        txtCep.Enabled = False
        txtTelefone.Enabled = False
        txtEmail.Enabled = False
        txtCnpj.Enabled = False
        btnEditar.Enabled = False
        btnExcluir.Enabled = False
        cancela += 1
        id = 0
        If cancela > 1 Then
            cancela = 0
            Me.Close()
        End If
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String
        cancela = 0
        If MsgBox("Deseja realmente excluir o Fornecedor " & txtNome.Text & " ?", vbQuestion + vbYesNo + vbDefaultButton2, "Atenção") = vbNo Then
            Exit Sub
        End If

        cancela = 0
        Try
            sql = ""
            sql += "delete from fornecedores where id_fornecedor = " & id
            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            comando.ExecuteReader()

            MsgBox("Fornecedor deletado com sucessu", vbInformation, "Informação")
            carregaDGV()
            id = 0

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        btnSalvar.Text = "Salvar"
        cancela = 0
        txtNome.Text = ""
        txtLogradouro.Text = ""
        txtBairro.Text = ""
        txtNumero.Text = ""
        txtEstado.Text = ""
        txtCidade.Text = ""
        txtCep.Text = ""
        txtTelefone.Text = ""
        txtEmail.Text = ""
        txtCnpj.Text = ""

        txtNome.Enabled = True
        txtLogradouro.Enabled = True
        txtBairro.Enabled = True
        txtNumero.Enabled = True
        txtEstado.Enabled = True
        txtCidade.Enabled = True
        txtCep.Enabled = True
        txtTelefone.Enabled = True
        txtEmail.Enabled = True
        txtCnpj.Enabled = True
        btnSalvar.Enabled = True

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If txtNome.Text = "" Then
            MsgBox("Preencha o campo 'Nome'", vbExclamation, "Atenção")
            txtNome.Focus()
            Exit Sub
        ElseIf txtLogradouro.Text = "" Then
            MsgBox("Preencha o campo 'Logradouro'", vbExclamation, "Atenção")
            txtLogradouro.Focus()
            Exit Sub
        ElseIf txtBairro.Text = "" Then
            MsgBox("Preencha o campo 'Bairro'", vbExclamation, "Atenção")
            txtBairro.Focus()
            Exit Sub
        ElseIf txtNumero.Text = "" Then
            MsgBox("Preencha o campo 'Número'", vbExclamation, "Atenção")
            txtNumero.Focus()
            Exit Sub
        ElseIf txtEstado.Text = "" Then
            MsgBox("Preencha o campo 'Estado'", vbExclamation, "Atenção")
            txtEstado.Focus()
            Exit Sub
        ElseIf txtCidade.Text = "" Then
            MsgBox("Preencha o campo 'Cidade'", vbExclamation, "Atenção")
            txtCidade.Focus()
            Exit Sub
        ElseIf txtCep.Text = "" Then
            MsgBox("Preencha o campo 'Cep'", vbExclamation, "Atenção")
            txtCep.Focus()
            Exit Sub
        ElseIf txtTelefone.Text = "" Then
            MsgBox("Preencha o campo 'Telefone'", vbExclamation, "Atenção")
            txtTelefone.Focus()
            Exit Sub
        ElseIf txtEmail.Text = "" Then
            MsgBox("Preencha o campo 'Email'", vbExclamation, "Atenção")
            txtEmail.Focus()
            Exit Sub
        ElseIf txtCnpj.Text = "" Then
            MsgBox("Preencha o campo 'Cnpj'", vbExclamation, "Atenção")
            txtCnpj.Focus()
            Exit Sub
        ElseIf btnSalvar.Text = "Alterar" Then
            cancela = 0
            Dim conn As New MySqlConnection(My.Settings.conexao)
            Dim sql As String

            Try
                sql = ""
                sql += "UPDATE fornecedores SET  nome='" & txtNome.Text & "',"
                sql += "logradouro='" & txtLogradouro.Text & "',"
                sql += "bairro='" & txtBairro.Text & "',"
                sql += "numero='" & txtNumero.Text & "',"
                sql += "estado='" & txtEstado.Text & "',"
                sql += "cidade='" & txtCidade.Text & "',"
                sql += "cep='" & txtCep.Text & "',"
                sql += "telefone='" & txtTelefone.Text & "',"
                sql += "email='" & txtEmail.Text & "',"
                sql += "cnpj='" & txtCnpj.Text & "' "
                sql += "where id_fornecedor = " & id

                conn.Close()
                conn.Open()

                Dim comando As New MySqlCommand(sql, conn)
                comando.ExecuteReader()

                MsgBox("Fornecedor alterado com sucesu", vbInformation, "Informação")
                carregaDGV()

                txtNome.Text = ""
                txtLogradouro.Text = ""
                txtBairro.Text = ""
                txtNumero.Text = ""
                txtEstado.Text = ""
                txtCidade.Text = ""
                txtCep.Text = ""
                txtTelefone.Text = ""
                txtEmail.Text = ""
                txtCnpj.Text = ""
                id = 0
                txtNome.Enabled = False
                txtLogradouro.Enabled = False
                txtBairro.Enabled = False
                txtNumero.Enabled = False
                txtEstado.Enabled = False
                txtCidade.Enabled = False
                txtCep.Enabled = False
                txtTelefone.Enabled = False
                txtEmail.Enabled = False
                txtCnpj.Enabled = False
                btnEditar.Enabled = False
                btnExcluir.Enabled = False
                editar = False
                btnSalvar.Text = "Salvar"
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
                sql += "insert into fornecedores (nome, logradouro , bairro , numero , estado , cidade , cep , telefone , email , cnpj ) "
                sql += " values ('" & txtNome.Text & "','" & txtLogradouro.Text & "','" & txtBairro.Text & "','"
                sql += txtNumero.Text & "','" & txtEstado.Text & "','" & txtCidade.Text & "','" & txtCep.Text & "','"
                sql += txtTelefone.Text & "','" & txtEmail.Text & "','" & txtCnpj.Text & "')"
                conn.Close()
                conn.Open()

                Dim comando As New MySqlCommand(sql, conn)
                comando.ExecuteReader()

                MsgBox("Fornecedor salvo com sucesu", vbInformation, "Informação")
                carregaDGV()

                txtNome.Text = ""
                txtLogradouro.Text = ""
                txtBairro.Text = ""
                txtNumero.Text = ""
                txtEstado.Text = ""
                txtCidade.Text = ""
                txtCep.Text = ""
                txtTelefone.Text = ""
                txtEmail.Text = ""
                txtCnpj.Text = ""
                id = 0
                txtNome.Enabled = False
                txtLogradouro.Enabled = False
                txtBairro.Enabled = False
                txtNumero.Enabled = False
                txtEstado.Enabled = False
                txtCidade.Enabled = False
                txtCep.Enabled = False
                txtTelefone.Enabled = False
                txtEmail.Enabled = False
                txtCnpj.Enabled = False
                btnEditar.Enabled = False
                btnExcluir.Enabled = False
                editar = False
                btnSalvar.Text = "Salvar"
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
                conn.Dispose()
            End Try
        End If
    End Sub
End Class