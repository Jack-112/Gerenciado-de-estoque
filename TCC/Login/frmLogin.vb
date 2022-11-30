Imports MySql.Data.MySqlClient
Public Class frmLogin
    Private Sub btnEntrar_Click() Handles btnEntrar.Click
        'Dim conn As New MySqlConnection(My.Settings.dgvUsuarios)
        'Dim comando As MySqlCommand
        'Dim a As String
        'Dim da As MySqlDataAdapter
        'Dim dr As MySqlDataReader

        'Try
        '    a = "Select nome from dgvUsuarios WHERE iddgvUsuarios=2"
        '    conn.Close()
        '    conn.Open()
        '    comando = New MySqlCommand(a, conn)
        '    dr = comando.ExecuteReader()
        '    If dr.Read Then
        '        Label1.Text = dr("nome")
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = "select * from usuarios where login='" & txtUsuario.Text.ToString & "' "
            conn.Close()
            conn.Open()
            Dim comando As New MySqlCommand(sql, conn)
            Dim dr As MySqlDataReader = comando.ExecuteReader()

            If dr.Read Then
                If txtSenha.Text <> dr("senha").ToString Then
                    MsgBox("Senha invalida", vbCritical, "Erro")
                    txtSenha.Text = ""
                    conn.Close()
                    conn.Dispose()
                    Exit Sub
                ElseIf dr("senha").ToString = "1234" Then
                    id_usuario = dr("id_usuario").ToString
                    MsgBox("Senha padrão detectada, redefina na próxima tela !!!", vbExclamation, "Alerta")
                    frmSenha.Show()
                    Me.Close()
                    Exit Sub
                End If
                id_usuario = dr("id_usuario").ToString
                nm_usuario = dr("nm_usuario").ToString
                Menus()

                Me.Close()
            Else
                MsgBox("usuario não encontrado", vbCritical, "Erro")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub Menus()
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim Sql As String

        Try
            Sql = "SELECT nm_menu FROM usuarios_menus im INNER JOIN menus m ON(im.id_menu=m.id_menu) WHERE im.id_usuario= " & id_usuario
            conn.Close()
            conn.Open()

            Dim comando As New MySqlCommand(Sql, conn)
            Dim dr As New MySqlDataAdapter(comando)
            Dim ds As New DataSet
            dr.Fill(ds)
            Dim menus(ds.Tables(0).Rows.Count)
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                If ds.Tables(0).Rows(i).Item("nm_menu").ToString = "mnAdmim" Then
                    frmPrincipal.mnAdmin.Visible = True
                ElseIf ds.Tables(0).Rows(i).Item("nm_menu").ToString = "mnItens" Then
                    frmPrincipal.mnItens.Visible = True
                ElseIf ds.Tables(0).Rows(i).Item("nm_menu").ToString = "mnCaixaRegistradora" And ds.Tables(0).Rows.Count = 1 Then
                    frmCaixaResgistradora.Show()
                    frmCaixaResgistradora.MenuStrip1.Visible = True
                    Me.Close()
                    Exit Sub
                ElseIf ds.Tables(0).Rows(i).Item("nm_menu").ToString = "mnCaixaRegistradora" Then
                    frmPrincipal.mnCaixaRegistradora.Visible = True
                ElseIf ds.Tables(0).Rows(i).Item("nm_menu").ToString = "mnCaixa" Then
                    frmPrincipal.mnCaixa.Visible = True
                ElseIf ds.Tables(0).Rows(i).Item("nm_menu").ToString = "mnRelatorios" Then
                    'frmPrincipal.mnRelatorios.Visible = True
                End If


            Next i

            frmPrincipal.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub frmLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnEntrar_Click()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Dim verSenha As Boolean = False
    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click

        If verSenha = False Then
            txtSenha.UseSystemPasswordChar = False
            btnVer.Image = My.Resources.olho_fechado
            verSenha = True
        ElseIf verSenha = True Then
            txtSenha.UseSystemPasswordChar = True
            btnVer.Image = My.Resources.olho_aberto
            verSenha = False
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnVer.Image = My.Resources.olho_aberto
    End Sub
End Class