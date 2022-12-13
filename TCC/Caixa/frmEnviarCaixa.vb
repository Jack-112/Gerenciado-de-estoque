Imports MySql.Data.MySqlClient
Public Class frmEnviarCaixa
    Private Sub frmEnviarCaixa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregaDgv()
    End Sub
    Private Sub carregaDgv()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            dgvCaixas.Invoke(Sub()
                                 dgvCaixas.Columns.Clear()
                                 dgvCaixas.ClearSelection()
                                 dgvCaixas.DataSource = Nothing
                                 dgvCaixas.Refresh()
                                 dgvCaixas.AllowDrop = False
                                 dgvCaixas.AllowUserToAddRows = False
                                 dgvCaixas.AllowUserToDeleteRows = False
                                 dgvCaixas.AllowUserToResizeRows = False
                                 dgvCaixas.AllowUserToResizeColumns = False
                                 dgvCaixas.AllowUserToOrderColumns = False
                                 dgvCaixas.MultiSelect = False
                                 dgvCaixas.AllowUserToOrderColumns = False

                             End Sub)
            sql = ""
            sql += "SELECT DISTINCT c.id_caixa,c.nm_caixa, ci.valor_total "
            sql += "FROM caixas c "
            sql += "INNER JOIN caixa_itens ci ON (c.id_caixa=ci.id_caixa) "
            sql += "WHERE c.id_caixa IN ( "
            sql += "SELECT id_caixa FROM caixas_fechadas "
            sql += ") "
            sql += "  AND c.id_caixa NOT IN ( "
            sql += "SELECT id_caixa FROM enviar_caixas "
            sql += ") "
            conn.Close()
            conn.Open()


            Dim CheckBox As New DataGridViewCheckBoxColumn()
            With CheckBox
                .CellTemplate = New DataGridViewCheckBoxCell()
                .HeaderText = ""
                .Name = "cbkCaixa"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .FlatStyle = FlatStyle.Standard
            End With

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)

            dgvCaixas.Invoke(Sub()
                                 dgvCaixas.DataSource = ds.Tables(0)
                                 dgvCaixas.Columns.Insert(0, CheckBox)
                                 dgvCaixas.Columns(0).Width = 10

                                 dgvCaixas.Columns(1).Visible = False

                                 dgvCaixas.Columns(2).HeaderText = "Embalagem"
                                 dgvCaixas.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                 dgvCaixas.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                                 dgvCaixas.Columns(2).ReadOnly = True

                                 dgvCaixas.Columns(3).HeaderText = "Valor da embalagem"
                                 dgvCaixas.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                 dgvCaixas.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                                 dgvCaixas.Columns(3).ReadOnly = True

                             End Sub)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()

        End Try
    End Sub

    Private Sub MaskedTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefone.KeyPress
        ' Permitir_numeros(sender, e)
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String
        Dim contador = 0
        For i As Integer = 0 To dgvCaixas.Rows.Count - 1
            If dgvCaixas.Rows(i).Cells(0).Value = True Then

                If txtNome.Text = "" Then
                    MsgBox("Preencha o campo Nome", vbExclamation, "atenção!")
                    Exit Sub
                ElseIf txtEstado.Text = "" Then
                    MsgBox("Preencha o campo Estado", vbExclamation, "atenção!")
                    Exit Sub
                ElseIf txtCidade.Text = "" Then
                    MsgBox("Preencha o campo Cidade", vbExclamation, "atenção!")
                    Exit Sub
                ElseIf txtRua.Text = "" Then
                    MsgBox("Preencha o campo Rua", vbExclamation, "atenção!")
                    Exit Sub
                ElseIf txtNumero.Text = "" Then
                    MsgBox("Preencha o campo Número", vbExclamation, "atenção!")
                    Exit Sub
                ElseIf txtTelefone.Text = "" Then
                    MsgBox("Preencha o campo Telefone", vbExclamation, "atenção!")
                    Exit Sub
                End If
                sql = ""
                sql += "INSERT INTO enviar_caixas(nome_cliente,estado,cidade,rua,numero,telefone,id_caixa,id_enviado_por,data_envio)"
                sql += "VALUES('" & txtNome.Text & "','" & txtEstado.Text & "','" & txtCidade.Text & "','" & txtRua.Text & "'," & txtNumero.Text & ",'" & txtTelefone.Text & "'," & dgvCaixas.Rows(i).Cells(1).Value & ", " & id_usuario & ", NOW())"
                conn.Close()
                conn.Open()
                Dim comando As New MySqlCommand(sql, conn)
                comando.ExecuteReader()
                contador += 1
            End If

        Next i
        If contador = 0 Then
            MsgBox("Selecione uma embalagem", vbExclamation, "atenção!")
            Exit Sub
        End If
        carregaDgv()
        MsgBox("embalagens enviadas com suscesso", vbInformation, "atenção !")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class