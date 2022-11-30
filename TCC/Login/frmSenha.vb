Imports MySql.Data.MySqlClient

Public Class frmSenha
    Dim verSenha As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        If verSenha = False Then
            txtSenha1.UseSystemPasswordChar = False
            txtSenha2.UseSystemPasswordChar = False
            btnVer.Image = My.Resources.olho_fechado
            verSenha = True
        ElseIf verSenha = True Then
            txtSenha1.UseSystemPasswordChar = True
            txtSenha2.UseSystemPasswordChar = True
            btnVer.Image = My.Resources.olho_aberto
            verSenha = False
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        If txtSenha1.Text <> txtSenha2.Text Then
            MsgBox("As senhas não conferem", vbCritical, "Erro")
            Exit Sub
        End If
        Dim conn As New MySqlConnection(My.Settings.conexao)
        Dim sql As String

        Try
            sql = ""
            sql += " update usuarios "
            sql += " set senha= '" & txtSenha1.Text.ToString & "'"
            sql += " where id_usuario = " & id_usuario.ToString
            conn.Close()
            conn.Open()
            Dim comando = New MySqlCommand(sql, conn)
            comando.ExecuteReader()
            frmLogin.Show()
            MsgBox("Senha alterada com sucesso", vbInformation, "Atenção")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    Private Sub frmSenha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnVer.Image = My.Resources.olho_aberto
    End Sub
End Class