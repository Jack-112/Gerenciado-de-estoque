Imports MySql.Data.MySqlClient
Public Class frmMenus
    Dim id_usuario_selecionado As Integer = 0
    Private Sub frmMenus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregaDgv()
        'carregaCbo()
        carregaDgv2()
    End Sub
    'Private Sub carregaCbo()
    '    Dim conn As New MySqlConnection(My.Settings.conexao)
    '    Dim sql As String

    '    Try
    '        sql = ""
    '        sql += "SELECT 0 'id_usuario','Selecione um Usuário' nome FROM DUAL UNION ALL SELECT id_usuario,CONCAT(nm_usuario,' (',login,')')nome FROM tcc.usuarios"

    '        conn.Close()
    '        conn.Open()

    '        Dim comando As New MySqlCommand(sql, conn)
    '        Dim dr As New MySqlDataAdapter(comando)
    '        Dim ds As New DataSet
    '        dr.Fill(ds)
    '        Dim filtro As DataView = ds.Tables(0).DefaultView
    '        filtro.RowFilter = ""
    '        cboUsuarios.DataSource = filtro.ToTable(True, "id_usuario", "nome")
    '        cboUsuarios.Invoke(Sub()
    '                               With cboUsuarios
    '                                   .ValueMember = "id_usuario"
    '                                   .DisplayMember = "nome"
    '                                   .SelectedIndex = -1
    '                                   .Text = ""
    '                               End With
    '                           End Sub)
    '        cboUsuarios.SelectedIndex = 0
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        conn.Close()
    '        conn.Dispose()
    '    End Try
    'End Sub
    Private Sub carregaDgv()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try



            dgvMenu.Invoke(Sub()
                               dgvMenu.Columns.Clear()
                               dgvMenu.ClearSelection()
                               dgvMenu.DataSource = Nothing
                               dgvMenu.Refresh()
                               dgvMenu.AllowDrop = False
                               dgvMenu.AllowUserToAddRows = False
                               dgvMenu.AllowUserToDeleteRows = False
                               dgvMenu.AllowUserToResizeRows = False
                               dgvMenu.AllowUserToResizeColumns = False
                               dgvMenu.AllowUserToOrderColumns = False
                               dgvMenu.MultiSelect = False
                               dgvMenu.AllowUserToOrderColumns = False

                           End Sub)
            sql = ""
            sql += "SELECT id_menu,"
            sql += "CASE WHEN nm_menu = 'mnAdmim' THEN 'Adiministrador' ELSE"
            sql += " CASE WHEN nm_menu='mnItens' THEN 'Itens' ELSE "
            sql += "  CASE WHEN nm_menu='mnCaixaRegistradora' THEN 'Caixa Registradora' ELSE "
            sql += "   CASE WHEN nm_menu='mnCaixa' THEN 'Caixa' ELSE "
            sql += "    CASE WHEN nm_menu='mnRelatorios' THEN 'Relatórios' "
            sql += " end end end end end menus "
            sql += " FROM menus "

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

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)

            dgvMenu.Invoke(Sub()
                               dgvMenu.DataSource = ds.Tables(0)
                               dgvMenu.Columns.Insert(0, CheckBox)
                               dgvMenu.Columns(0).Width = 10

                               dgvMenu.Columns(1).Visible = False

                               dgvMenu.Columns(2).HeaderText = "Menu"
                               dgvMenu.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                               dgvMenu.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                               dgvMenu.Columns(2).ReadOnly = True

                           End Sub)


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()

        End Try
    End Sub

    Private Sub carregaDgv2()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try



            dgvUsuarios.Invoke(Sub()
                                   dgvUsuarios.Columns.Clear()
                                   dgvUsuarios.ClearSelection()
                                   dgvUsuarios.DataSource = Nothing
                                   dgvUsuarios.Refresh()
                                   dgvUsuarios.AllowDrop = False
                                   dgvUsuarios.AllowUserToAddRows = False
                                   dgvUsuarios.AllowUserToDeleteRows = False
                                   dgvUsuarios.AllowUserToResizeRows = False
                                   dgvUsuarios.AllowUserToResizeColumns = False
                                   dgvUsuarios.AllowUserToOrderColumns = False
                                   dgvUsuarios.MultiSelect = False
                                   dgvUsuarios.AllowUserToOrderColumns = False

                               End Sub)
            sql = ""
            sql += "SELECT id_usuario,login FROM usuarios"

            conn.Close()
            conn.Open()



            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)

            dgvUsuarios.Invoke(Sub()
                                   dgvUsuarios.DataSource = ds.Tables(0)
                                   dgvUsuarios.Columns(0).Visible = False

                                   dgvUsuarios.Columns(1).HeaderText = "Usuarios"
                                   dgvUsuarios.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                   dgvUsuarios.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                                   dgvUsuarios.Columns(1).ReadOnly = True

                               End Sub)


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()

        End Try
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = ""
            sql += "delete from usuarios_menus where id_usuario = " & id_usuario_selecionado
            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            comando.ExecuteReader()
            For i As Integer = 0 To dgvMenu.Rows.Count - 1

                If dgvMenu.Rows(i).Cells(0).Value = True Then

                    sql = ""
                    sql += "insert into usuarios_menus (id_usuario,id_menu) values(" & id_usuario_selecionado & "," & dgvMenu.Rows(i).Cells(1).Value & ")"
                    conn.Close()
                    conn.Open()

                    Dim comando2 As New MySqlCommand(sql, conn)
                    comando2.ExecuteReader()
                End If

            Next i
            MsgBox("Menus salvos")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub



    Private Sub cboUsuarios_TextChanged(sender As Object, e As EventArgs)
        ' cboUsuarios.Text = UCase(cboUsuarios.Text)
    End Sub

    Private Sub dgvUsuarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        id_usuario_selecionado = dgvUsuarios.Rows(e.RowIndex).Cells(0).Value
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String
        Try
            sql = ""
            sql += "select * from usuarios_menus where id_usuario = " & id_usuario_selecionado
            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As MySqlDataReader = comando.ExecuteReader()
            carregaDgv()

            For i As Integer = 0 To dgvMenu.Rows.Count - 1

                If dr.Read Then

                    Dim num1 As String = dr("id_menu").ToString

                    If num1 <> Nothing Then

                        For j As Integer = 0 To dgvMenu.Rows.Count - 1

                            If CStr(dgvMenu.Rows(j).Cells(1).Value) = num1 Then
                                dgvMenu.Rows(j).Cells(0).Value = True

                            End If
                        Next j



                    End If

                End If

            Next i
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
            dgvUsuarios.Invoke(Sub()
                                   dgvUsuarios.Columns.Clear()
                                   dgvUsuarios.ClearSelection()
                                   dgvUsuarios.DataSource = Nothing
                                   dgvUsuarios.Refresh()
                                   dgvUsuarios.AllowDrop = False
                                   dgvUsuarios.AllowUserToAddRows = False
                                   dgvUsuarios.AllowUserToDeleteRows = False
                                   dgvUsuarios.AllowUserToResizeRows = False
                                   dgvUsuarios.AllowUserToResizeColumns = False
                                   dgvUsuarios.AllowUserToOrderColumns = False
                                   dgvUsuarios.MultiSelect = False
                                   dgvUsuarios.AllowUserToOrderColumns = False

                               End Sub)

            sql = ""
            sql += "SELECT id_usuario,login FROM usuarios WHERE login LIKE '%" & txtBusca.Text.ToString & "%'"

            conn.Close()
            conn.Open()
            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)

            dgvUsuarios.Invoke(Sub()
                                   dgvUsuarios.DataSource = ds.Tables(0)
                                   dgvUsuarios.Columns(0).Visible = False

                                   dgvUsuarios.Columns(1).HeaderText = "Usuarios"
                                   dgvUsuarios.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                   dgvUsuarios.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                                   dgvUsuarios.Columns(1).ReadOnly = True

                               End Sub)



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
End Class