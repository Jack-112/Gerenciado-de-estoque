<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSenha
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtSenha1 = New System.Windows.Forms.MaskedTextBox()
        Me.txtSenha2 = New System.Windows.Forms.MaskedTextBox()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtSenha1
        '
        Me.txtSenha1.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.txtSenha1.Location = New System.Drawing.Point(12, 45)
        Me.txtSenha1.Name = "txtSenha1"
        Me.txtSenha1.Size = New System.Drawing.Size(264, 30)
        Me.txtSenha1.TabIndex = 0
        Me.txtSenha1.UseSystemPasswordChar = True
        '
        'txtSenha2
        '
        Me.txtSenha2.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.txtSenha2.Location = New System.Drawing.Point(12, 91)
        Me.txtSenha2.Name = "txtSenha2"
        Me.txtSenha2.Size = New System.Drawing.Size(264, 30)
        Me.txtSenha2.TabIndex = 1
        Me.txtSenha2.UseSystemPasswordChar = True
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnConfirmar.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold)
        Me.btnConfirmar.Location = New System.Drawing.Point(12, 136)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(92, 30)
        Me.btnConfirmar.TabIndex = 4
        Me.btnConfirmar.Text = "Confimar"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancelar.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancelar.Location = New System.Drawing.Point(178, 136)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(98, 30)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(225, 24)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "REDEFINA SUA SENHA"
        '
        'btnVer
        '
        Me.btnVer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVer.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnVer.Location = New System.Drawing.Point(279, 91)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(42, 32)
        Me.btnVer.TabIndex = 2
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'frmSenha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 196)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.btnVer)
        Me.Controls.Add(Me.txtSenha2)
        Me.Controls.Add(Me.txtSenha1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSenha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSenha1 As MaskedTextBox
    Friend WithEvents txtSenha2 As MaskedTextBox
    Friend WithEvents btnVer As Button
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label1 As Label
End Class
