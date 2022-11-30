Imports MySql.Data.MySqlClient

Public Class frmAddItens
    Dim msgErro As Boolean = False
    Private Sub addItens_Load(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Activated
        If msgErro = False Then
            carregaDgv()
        End If
    End Sub

    Public Sub carregaDgv()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        dgvAddItens.Invoke(Sub()
                               dgvAddItens.Columns.Clear()
                               dgvAddItens.ClearSelection()
                               dgvAddItens.DataSource = Nothing
                               dgvAddItens.Refresh()
                               dgvAddItens.AllowDrop = False
                               dgvAddItens.AllowUserToAddRows = False
                               dgvAddItens.AllowUserToResizeRows = False
                               dgvAddItens.AllowUserToOrderColumns = False
                               dgvAddItens.AllowUserToResizeColumns = False
                               dgvAddItens.MultiSelect = False
                               dgvAddItens.RowHeadersVisible = False
                           End Sub)

        Try
            sql = ""
            sql += "SELECT i.id_item,nm_item,nm_classe,i.valor_venda,"
            sql += "DATE_FORMAT(i.data_validade,'%d/%m/%Y')dt_validade,codigo_barras,quantidade "
            sql += " FROM itens i "
            sql += " INNER JOIN  (SELECT CASE WHEN (MONTH(data_validade) < MONTH(NOW()) AND YEAR(data_validade) <= YEAR(NOW())) "
            sql += " OR(MONTH(data_validade) <= MONTH(NOW()) AND YEAR(data_validade) <= YEAR(NOW()) "
            sql += " AND DAY(data_validade)< DAY(NOW()))THEN 1 ELSE 0 END Vencido, a.id_item "
            sql += " FROM itens a) a ON(i.id_item=a.id_item) "
            sql += " INNER JOIN classe_item ci ON(i.classe_item=ci.id_classe_item) "
            sql += " WHERE Vencido != 1"

            conn.Close()
            conn.Open()

            Dim CheckBox As New DataGridViewCheckBoxColumn()
            With CheckBox
                .CellTemplate = New DataGridViewCheckBoxCell()
                .HeaderText = ""
                .Name = "cbkMenu"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .FlatStyle = FlatStyle.Standard
            End With

            Dim numeric As New NumericUpDownColumn
            With numeric
                .HeaderText = "Quantidade"
                .Name = "qtd"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            End With
            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)

            dgvAddItens.Invoke(Sub()
                                   dgvAddItens.DataSource = ds.Tables(0)

                                   dgvAddItens.Columns.Insert(0, CheckBox)
                                   dgvAddItens.Columns(0).Width = 10

                                   dgvAddItens.Columns.Insert(8, numeric)
                                   dgvAddItens.Columns(8).Width = 84

                                   dgvAddItens.Columns(1).Visible = False

                                   dgvAddItens.Columns(2).HeaderText = "Item"
                                   dgvAddItens.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                   dgvAddItens.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                                   dgvAddItens.Columns(2).ReadOnly = True

                                   dgvAddItens.Columns(3).HeaderText = "Classe"
                                   dgvAddItens.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                                   dgvAddItens.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                                   dgvAddItens.Columns(3).ReadOnly = True

                                   dgvAddItens.Columns(4).HeaderText = "Vl Venda"
                                   dgvAddItens.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                   dgvAddItens.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
                                   dgvAddItens.Columns(4).ReadOnly = True

                                   dgvAddItens.Columns(5).HeaderText = "Dt Validade"
                                   dgvAddItens.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                   dgvAddItens.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
                                   dgvAddItens.Columns(5).ReadOnly = True

                                   dgvAddItens.Columns(6).HeaderText = "Código de barras"
                                   dgvAddItens.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                   dgvAddItens.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
                                   dgvAddItens.Columns(6).ReadOnly = True

                                   dgvAddItens.Columns(7).HeaderText = "Qtd no Estoque"
                                   dgvAddItens.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                   dgvAddItens.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
                                   dgvAddItens.Columns(7).ReadOnly = True


                               End Sub)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String
        Dim conta As Boolean = False
        Dim ntem As Integer = 0
        msgErro = True

        For i As Integer = 0 To dgvAddItens.Rows.Count - 1

            If dgvAddItens.Rows(i).Cells(0).Value = True Then
                conta = True

                If dgvAddItens.Rows(i).Cells(8).Value <> IsDBNull(dgvAddItens.Rows(i).Cells(8).Value) Then
                    If dgvAddItens.Rows(i).Cells(7).Value > dgvAddItens.Rows(i).Cells(8).Value Then

                        If frmItensCaixa.dgvItens.Rows.Count = 0 Then

                            frmItensCaixa.dgvItens.Columns.Add(columnName:="IdItem", headerText:="IdItem")
                            frmItensCaixa.dgvItens.Columns.Add(columnName:="nm_item", headerText:="Item")
                            frmItensCaixa.dgvItens.Columns.Add(columnName:="classe", headerText:="Classe")
                            frmItensCaixa.dgvItens.Columns.Add(columnName:="valor_venda", headerText:="Vl venda")
                            frmItensCaixa.dgvItens.Columns.Add(columnName:="dt_validade", headerText:="Dt Validade")
                            frmItensCaixa.dgvItens.Columns.Add(columnName:="codigo_barras", headerText:="Código de barras")
                            frmItensCaixa.dgvItens.Columns.Add(columnName:="quantidade", headerText:="Quantidade")

                            frmItensCaixa.dgvItens.Columns(0).Visible = False

                            frmItensCaixa.dgvItens.Columns(0).ReadOnly = True
                            frmItensCaixa.dgvItens.Columns(1).ReadOnly = True
                            frmItensCaixa.dgvItens.Columns(2).ReadOnly = True
                            frmItensCaixa.dgvItens.Columns(3).ReadOnly = True
                            frmItensCaixa.dgvItens.Columns(4).ReadOnly = True
                            frmItensCaixa.dgvItens.Columns(5).ReadOnly = True
                            frmItensCaixa.dgvItens.Columns(6).ReadOnly = True
                            frmItensCaixa.dgvItens.Rows.Add(dgvAddItens.Rows(i).Cells(1).Value,
                                                                    dgvAddItens.Rows(i).Cells(2).Value,
                                                                    dgvAddItens.Rows(i).Cells(3).Value,
                                                                    dgvAddItens.Rows(i).Cells(4).Value,
                                                                    dgvAddItens.Rows(i).Cells(5).Value,
                                                                    dgvAddItens.Rows(i).Cells(6).Value,
                                                                    dgvAddItens.Rows(i).Cells(8).Value)
                        Else

                            For j As Integer = 0 To frmItensCaixa.dgvItens.Rows.Count - 1
                                If frmItensCaixa.dgvItens.Rows(j).Cells(0).Value = dgvAddItens.Rows(i).Cells(1).Value Then
                                    frmItensCaixa.dgvItens.Rows(j).Cells(6).Value += dgvAddItens.Rows(i).Cells(8).Value
                                    ntem = 1
                                    Exit For
                                End If
                                ntem = 0
                            Next j
                            If ntem = 0 Then
                                frmItensCaixa.dgvItens.Rows.Add(dgvAddItens.Rows(i).Cells(1).Value,
                                                                        dgvAddItens.Rows(i).Cells(2).Value,
                                                                        dgvAddItens.Rows(i).Cells(3).Value,
                                                                        dgvAddItens.Rows(i).Cells(4).Value,
                                                                        dgvAddItens.Rows(i).Cells(5).Value,
                                                                        dgvAddItens.Rows(i).Cells(6).Value,
                                                                        dgvAddItens.Rows(i).Cells(8).Value)
                            End If
                        End If
                        sql = ""
                        sql += "update itens set quantidade=quantidade-" & dgvAddItens.Rows(i).Cells(8).Value & " where id_item = " & dgvAddItens.Rows(i).Cells(1).Value
                        conn.Close()
                        conn.Open()
                        Dim comando As New MySqlCommand(sql, conn)
                        comando.ExecuteReader()
                        If dgvAddItens.Rows(i).Cells(8).Value = 1 Then
                            frmItensCaixa.valor_final += CDbl(dgvAddItens.Rows(i).Cells(4).Value)
                        Else
                            frmItensCaixa.valor_final += CDbl(dgvAddItens.Rows(i).Cells(8).Value) * CDbl(dgvAddItens.Rows(i).Cells(4).Value)
                        End If
                    Else
                        MsgBox("O item " & dgvAddItens.Rows(i).Cells(2).Value & " não foi adicionado !" & Chr(13) & " Quantidade desejada é maior que a do estoque !", vbExclamation, "Atenção")
                    End If
                Else
                    MsgBox("O item " & dgvAddItens.Rows(i).Cells(2).Value & "não foi adicionado pois não possui quantidade !", vbExclamation, "Atenção")
                End If

            End If


        Next i
        If conta = False Then
            MsgBox("Nenhum item foi selecionado !", vbExclamation, "Atenção")
            Exit Sub
        End If
        Me.Close()
        msgErro = False
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub dgvItens_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAddItens.CellClick
        dgvAddItens.BeginEdit(True)
    End Sub

    Private Sub addItens_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        For i As Integer = 0 To dgvAddItens.Rows.Count - 1
            dgvAddItens.Rows(i).Cells(8).Value = 0
        Next i

    End Sub
End Class