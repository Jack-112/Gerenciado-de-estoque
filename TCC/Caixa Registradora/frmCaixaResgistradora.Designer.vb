<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCaixaResgistradora
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCaixaResgistradora))
        Me.txtCodigoDeBarras = New System.Windows.Forms.TextBox()
        Me.txtTotalPagar = New System.Windows.Forms.TextBox()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.txtClasse = New System.Windows.Forms.TextBox()
        Me.txtDataValidade = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvItens = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQuantidade = New System.Windows.Forms.NumericUpDown()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.LogoffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCodigoDeBarras
        '
        Me.txtCodigoDeBarras.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodigoDeBarras.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.txtCodigoDeBarras.Location = New System.Drawing.Point(12, 124)
        Me.txtCodigoDeBarras.Name = "txtCodigoDeBarras"
        Me.txtCodigoDeBarras.Size = New System.Drawing.Size(428, 29)
        Me.txtCodigoDeBarras.TabIndex = 0
        '
        'txtTotalPagar
        '
        Me.txtTotalPagar.BackColor = System.Drawing.SystemColors.Window
        Me.txtTotalPagar.Font = New System.Drawing.Font("Arial", 55.0!)
        Me.txtTotalPagar.Location = New System.Drawing.Point(12, 22)
        Me.txtTotalPagar.Name = "txtTotalPagar"
        Me.txtTotalPagar.ReadOnly = True
        Me.txtTotalPagar.Size = New System.Drawing.Size(516, 92)
        Me.txtTotalPagar.TabIndex = 1
        Me.txtTotalPagar.Text = "R$ 0"
        Me.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNome
        '
        Me.txtNome.BackColor = System.Drawing.SystemColors.Window
        Me.txtNome.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.txtNome.Location = New System.Drawing.Point(12, 184)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.ReadOnly = True
        Me.txtNome.Size = New System.Drawing.Size(229, 29)
        Me.txtNome.TabIndex = 2
        '
        'txtValor
        '
        Me.txtValor.BackColor = System.Drawing.SystemColors.Window
        Me.txtValor.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.txtValor.Location = New System.Drawing.Point(247, 184)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.ReadOnly = True
        Me.txtValor.Size = New System.Drawing.Size(229, 29)
        Me.txtValor.TabIndex = 3
        '
        'txtClasse
        '
        Me.txtClasse.BackColor = System.Drawing.SystemColors.Window
        Me.txtClasse.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.txtClasse.Location = New System.Drawing.Point(12, 243)
        Me.txtClasse.Name = "txtClasse"
        Me.txtClasse.ReadOnly = True
        Me.txtClasse.Size = New System.Drawing.Size(229, 29)
        Me.txtClasse.TabIndex = 4
        '
        'txtDataValidade
        '
        Me.txtDataValidade.BackColor = System.Drawing.SystemColors.Window
        Me.txtDataValidade.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.txtDataValidade.Location = New System.Drawing.Point(247, 243)
        Me.txtDataValidade.Name = "txtDataValidade"
        Me.txtDataValidade.ReadOnly = True
        Me.txtDataValidade.Size = New System.Drawing.Size(229, 29)
        Me.txtDataValidade.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(446, 124)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 29)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Adicionar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvItens
        '
        Me.dgvItens.AllowUserToAddRows = False
        Me.dgvItens.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItens.Location = New System.Drawing.Point(12, 361)
        Me.dgvItens.Name = "dgvItens"
        Me.dgvItens.ReadOnly = True
        Me.dgvItens.Size = New System.Drawing.Size(516, 243)
        Me.dgvItens.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(150, 332)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(239, 32)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Itens no carrinho"
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.txtQuantidade.Location = New System.Drawing.Point(13, 302)
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.Size = New System.Drawing.Size(120, 29)
        Me.txtQuantidade.TabIndex = 6
        Me.txtQuantidade.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogoffToolStripMenuItem, Me.SairToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(538, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'LogoffToolStripMenuItem
        '
        Me.LogoffToolStripMenuItem.Name = "LogoffToolStripMenuItem"
        Me.LogoffToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.LogoffToolStripMenuItem.Text = "Logoff"
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(38, 20)
        Me.SairToolStripMenuItem.Text = "Sair"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.Location = New System.Drawing.Point(382, 610)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(146, 29)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Confirmar compra"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(12, 275)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 24)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Quantidade"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(8, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(184, 24)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Classe do produto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(243, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 24)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Data de validade"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(8, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(175, 24)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Nome do produto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(243, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 24)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Valor"
        '
        'frmCaixaResgistradora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(538, 645)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtQuantidade)
        Me.Controls.Add(Me.dgvItens)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtDataValidade)
        Me.Controls.Add(Me.txtClasse)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.txtTotalPagar)
        Me.Controls.Add(Me.txtCodigoDeBarras)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmCaixaResgistradora"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Caixa Registradora"
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCodigoDeBarras As TextBox
    Friend WithEvents txtTotalPagar As TextBox
    Friend WithEvents txtNome As TextBox
    Friend WithEvents txtValor As TextBox
    Friend WithEvents txtClasse As TextBox
    Friend WithEvents txtDataValidade As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents dgvItens As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtQuantidade As NumericUpDown
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents LogoffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SairToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
