Module variaveis
    Public id_usuario As Integer
    Public nm_usuario As String
    Public Sub Permitir_numeros(sender As Object, e As KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled = True
        End If
    End Sub
    Public Sub Permitir_dinheiro(sender As Object, e As KeyPressEventArgs)

        If Not IsNumeric(e.KeyChar) And Asc(e.KeyChar) <> Keys.Back And Asc(e.KeyChar) <> Asc(",") Then
            e.Handled = True
        End If
    End Sub
End Module
