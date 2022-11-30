<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuarios))
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.txtSenha = New System.Windows.Forms.MaskedTextBox()
        Me.usuariosDgv = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnCalcelar = New System.Windows.Forms.Button()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.cboNivel = New System.Windows.Forms.ComboBox()
        Me.txtDataNas = New System.Windows.Forms.MaskedTextBox()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboSetor = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.usuariosDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Enabled = False
        Me.txtUsuario.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtUsuario.Location = New System.Drawing.Point(12, 38)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(154, 21)
        Me.txtUsuario.TabIndex = 0
        '
        'txtNome
        '
        Me.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNome.Enabled = False
        Me.txtNome.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtNome.Location = New System.Drawing.Point(172, 38)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(441, 21)
        Me.txtNome.TabIndex = 1
        '
        'txtSenha
        '
        Me.txtSenha.Enabled = False
        Me.txtSenha.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtSenha.Location = New System.Drawing.Point(13, 84)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.Size = New System.Drawing.Size(164, 21)
        Me.txtSenha.TabIndex = 2
        Me.txtSenha.UseSystemPasswordChar = True
        '
        'usuariosDgv
        '
        Me.usuariosDgv.BackgroundColor = System.Drawing.Color.White
        Me.usuariosDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.usuariosDgv.Location = New System.Drawing.Point(13, 112)
        Me.usuariosDgv.Name = "usuariosDgv"
        Me.usuariosDgv.Size = New System.Drawing.Size(600, 308)
        Me.usuariosDgv.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 19)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Usuário"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(168, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 19)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Nome"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(9, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 19)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Senha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(179, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 19)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Data de nascimento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(341, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(133, 19)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Nível do usuário"
        '
        'btnEditar
        '
        Me.btnEditar.Enabled = False
        Me.btnEditar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnEditar.Location = New System.Drawing.Point(444, 426)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(82, 28)
        Me.btnEditar.TabIndex = 11
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnSalvar
        '
        Me.btnSalvar.Enabled = False
        Me.btnSalvar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSalvar.Location = New System.Drawing.Point(13, 426)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(82, 28)
        Me.btnSalvar.TabIndex = 12
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnCalcelar
        '
        Me.btnCalcelar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCalcelar.Location = New System.Drawing.Point(532, 426)
        Me.btnCalcelar.Name = "btnCalcelar"
        Me.btnCalcelar.Size = New System.Drawing.Size(82, 28)
        Me.btnCalcelar.TabIndex = 13
        Me.btnCalcelar.Text = "Cancelar"
        Me.btnCalcelar.UseVisualStyleBackColor = True
        '
        'btnNovo
        '
        Me.btnNovo.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnNovo.Location = New System.Drawing.Point(101, 426)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(82, 28)
        Me.btnNovo.TabIndex = 14
        Me.btnNovo.Text = "Novo"
        Me.btnNovo.UseVisualStyleBackColor = True
        '
        'cboNivel
        '
        Me.cboNivel.Enabled = False
        Me.cboNivel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cboNivel.FormattingEnabled = True
        Me.cboNivel.Items.AddRange(New Object() {"Selecione", "ADMIN", "USUÁRIO"})
        Me.cboNivel.Location = New System.Drawing.Point(345, 83)
        Me.cboNivel.Name = "cboNivel"
        Me.cboNivel.Size = New System.Drawing.Size(129, 23)
        Me.cboNivel.TabIndex = 15
        '
        'txtDataNas
        '
        Me.txtDataNas.Enabled = False
        Me.txtDataNas.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtDataNas.Location = New System.Drawing.Point(183, 84)
        Me.txtDataNas.Mask = "00/00/0000"
        Me.txtDataNas.Name = "txtDataNas"
        Me.txtDataNas.Size = New System.Drawing.Size(156, 21)
        Me.txtDataNas.TabIndex = 16
        Me.txtDataNas.ValidatingType = GetType(Date)
        '
        'btnExcluir
        '
        Me.btnExcluir.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnExcluir.Location = New System.Drawing.Point(189, 426)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(82, 28)
        Me.btnExcluir.TabIndex = 17
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(480, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 19)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Setor"
        '
        'cboSetor
        '
        Me.cboSetor.Enabled = False
        Me.cboSetor.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cboSetor.FormattingEnabled = True
        Me.cboSetor.Items.AddRange(New Object() {"Selecione", "Admin", "Usuário"})
        Me.cboSetor.Location = New System.Drawing.Point(480, 83)
        Me.cboSetor.Name = "cboSetor"
        Me.cboSetor.Size = New System.Drawing.Size(133, 23)
        Me.cboSetor.TabIndex = 19
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.TCC.My.Resources.Resources.botao_de_simbolo_de_mais
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.Location = New System.Drawing.Point(616, 83)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 23)
        Me.Button2.TabIndex = 357
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Button2.UseVisualStyleBackColor = False
        '
        'frmUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 460)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cboSetor)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.txtDataNas)
        Me.Controls.Add(Me.cboNivel)
        Me.Controls.Add(Me.btnNovo)
        Me.Controls.Add(Me.btnCalcelar)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.usuariosDgv)
        Me.Controls.Add(Me.txtSenha)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.txtUsuario)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuários"
        CType(Me.usuariosDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtNome As TextBox
    Friend WithEvents txtSenha As MaskedTextBox
    Friend WithEvents usuariosDgv As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnCalcelar As Button
    Friend WithEvents btnNovo As Button
    Friend WithEvents cboNivel As ComboBox
    Friend WithEvents txtDataNas As MaskedTextBox
    Friend WithEvents btnExcluir As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents cboSetor As ComboBox
    Friend WithEvents Button2 As Button
End Class
