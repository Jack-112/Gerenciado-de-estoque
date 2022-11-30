Imports MySql.Data.MySqlClient
Public Class frmCaixaResgistradora
    Dim valor_final As Decimal = 0
    Dim codigo As Integer = 0
    Dim id_item As Integer = 0

    Private Sub txtCodigoDeBarras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoDeBarras.KeyPress
        Permitir_numeros(sender, e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtCodigoDeBarras.Text = "" Or txtQuantidade.Value = 0 Then
            Exit Sub
        End If

        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = ""
            sql += "SELECT i.id_item,i.nm_item,REPLACE(i.valor_venda,'.',',')valor_venda,c.nm_classe classe,DATE_FORMAT(i.data_validade,'%d/%m/%Y')data_validade "
            sql += "FROM itens i "
            sql += "INNER JOIN classe_item c ON(i.classe_item=c.id_classe_item) "
            sql += "WHERE codigo_barras =" & txtCodigoDeBarras.Text

            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As MySqlDataReader = comando.ExecuteReader()

            If dr.Read Then
                txtClasse.Text = dr("classe").ToString
                txtDataValidade.Text = dr("data_validade").ToString
                txtValor.Text = dr("valor_venda").ToString
                txtNome.Text = dr("nm_item").ToString
                id_item = dr("id_item")
                ValorFinal()
                carregaDgv()
            End If
            txtQuantidade.Value = 1
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub
    Private Sub ValorFinal()
        If txtQuantidade.Value = 1 Then
            valor_final += CDbl(txtValor.Text)
        Else
            valor_final += CDbl(txtQuantidade.Value) * CDbl(txtValor.Text)
        End If

        txtTotalPagar.Text = "R$ " & valor_final
    End Sub
    Private Sub carregaDgv()




        If dgvItens.Rows.Count = 0 Then
            dgvItens.Columns.Add(columnName:="IdItem", headerText:="IdItem")
            dgvItens.Columns.Add(columnName:="nomeItem", headerText:="Item")
            dgvItens.Columns.Add(columnName:="classe", headerText:="Classe")
            dgvItens.Columns.Add(columnName:="valorVenda", headerText:="Valor")
            dgvItens.Columns.Add(columnName:="dataValidade", headerText:="Data de validade")
            dgvItens.Columns.Add(columnName:="Quantidade", headerText:="Quantidade")
            dgvItens.Rows.Add(id_item, txtNome.Text, txtClasse.Text, txtValor.Text, txtDataValidade.Text, txtQuantidade.Value)
        Else
            For i As Integer = 0 To dgvItens.Rows.Count - 1
                If txtNome.Text = dgvItens.Rows(i).Cells(1).Value.ToString And txtClasse.Text = dgvItens.Rows(i).Cells(2).Value.ToString And txtValor.Text = dgvItens.Rows(i).Cells(3).Value.ToString And txtDataValidade.Text = dgvItens.Rows(i).Cells(4).Value.ToString Then
                    dgvItens.Rows(i).Cells(5).Value = CDbl(dgvItens.Rows(i).Cells(5).Value) + txtQuantidade.Value
                    Exit Sub
                End If
            Next i

            dgvItens.Rows.Add(id_item, txtNome.Text, txtClasse.Text, txtValor.Text, txtDataValidade.Text, txtQuantidade.Value)
        End If
        dgvItens.Columns(0).Visible = False
    End Sub

    Private Sub txtQuantidade_KeyPress(sender As Object, e As KeyPressEventArgs)
        Permitir_numeros(sender, e)
    End Sub

    Private Sub dgvItens_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvItens.KeyDown
        If e.KeyCode = Keys.Delete And dgvItens.Rows.Count <> 0 Then


            If dgvItens.Rows(dgvItens.CurrentRow.Index).Cells(5).Value <> 1 Then
                dgvItens.Rows(dgvItens.CurrentRow.Index).Cells(5).Value = CDbl(dgvItens.Rows(dgvItens.CurrentRow.Index).Cells(5).Value) - 1
                valor_final -= CDbl(dgvItens.Rows(dgvItens.CurrentRow.Index).Cells(3).Value)
                txtTotalPagar.Text = "R$ " & valor_final
            Else
                dgvItens.Rows(dgvItens.CurrentRow.Index).Cells(5).Value = CDbl(dgvItens.Rows(dgvItens.CurrentRow.Index).Cells(5).Value) - 1
                valor_final -= CDbl(dgvItens.Rows(dgvItens.CurrentRow.Index).Cells(3).Value)
                If valor_final < 0 Then
                    valor_final = 0
                End If
                txtTotalPagar.Text = "R$ " & valor_final
                dgvItens.Rows.Remove(dgvItens.Rows(dgvItens.CurrentRow.Index))
            End If

        End If
    End Sub

    Private Sub txtCodigoDeBarras_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoDeBarras.TextChanged
        If txtCodigoDeBarras.Text = "" Then Exit Sub
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = ""
            sql += "SELECT i.id_item,i.nm_item,REPLACE(i.valor_venda,'.',',')valor_venda,c.nm_classe classe,DATE_FORMAT(i.data_validade,'%d/%m/%Y')data_validade "
            sql += "FROM itens i "
            sql += "INNER JOIN classe_item c ON(i.classe_item=c.id_classe_item) "
            sql += "WHERE codigo_barras =" & txtCodigoDeBarras.Text

            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As MySqlDataReader = comando.ExecuteReader()

            If dr.Read Then
                txtClasse.Text = dr("classe").ToString
                txtDataValidade.Text = dr("data_validade").ToString
                txtValor.Text = dr("valor_venda").ToString
                txtNome.Text = dr("nm_item").ToString
                id_item = dr("id_item")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try


    End Sub


    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub LogoffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoffToolStripMenuItem.Click
        frmLogin.Show()
        Me.Close()
    End Sub

    Private Sub frmCaixaResgistradora_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtClasse.Text = ""
        txtDataValidade.Text = ""
        txtValor.Text = ""
        txtNome.Text = ""
        txtQuantidade.Value = 1
        valor_final = 0
        txtTotalPagar.Text = "R$ 0"
        txtCodigoDeBarras.Text = ""
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
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("Confimar compra ?", vbQuestion + vbYesNo + vbDefaultButton2, "Atenção") = vbNo Then
            Exit Sub
        End If
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            For i As Integer = 0 To dgvItens.Rows.Count - 1
                sql = ""
                sql += "UPDATE itens SET quantidade = quantidade - " & dgvItens.Rows(i).Cells(5).Value & " WHERE id_item = " & dgvItens.Rows(i).Cells(0).Value
                conn.Close()
                conn.Open()
                Dim comando As New MySqlCommand(sql, conn)
                comando.ExecuteReader()
                sql = ""
                sql += "INSERT INTO itens_vendidos(id_item,quantidade,valor_venda,dt_venda) "
                sql += "VALUES(" & dgvItens.Rows(i).Cells(0).Value & "," & dgvItens.Rows(i).Cells(5).Value
                sql += ",REPLACE('" & dgvItens.Rows(i).Cells(3).Value * dgvItens.Rows(i).Cells(5).Value & "',',','.'), now())"
                conn.Close()
                conn.Open()
                Dim comando2 As New MySqlCommand(sql, conn)
                comando2.ExecuteReader()
            Next i

            txtClasse.Text = ""
            txtDataValidade.Text = ""
            txtValor.Text = ""
            txtNome.Text = ""
            txtQuantidade.Value = 1
            txtTotalPagar.Text = "R$ 0"
            txtCodigoDeBarras.Text = ""
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
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    Private Sub frmCaixaResgistradora_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class