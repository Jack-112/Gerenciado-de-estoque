<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmItensCaixa
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItensCaixa))
        Me.dgvItens = New System.Windows.Forms.DataGridView()
        Me.cboCaixa = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.txtTotal = New System.Windows.Forms.Label()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvItens
        '
        Me.dgvItens.BackgroundColor = System.Drawing.Color.White
        Me.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItens.Location = New System.Drawing.Point(12, 82)
        Me.dgvItens.Name = "dgvItens"
        Me.dgvItens.Size = New System.Drawing.Size(484, 276)
        Me.dgvItens.TabIndex = 0
        '
        'cboCaixa
        '
        Me.cboCaixa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCaixa.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.cboCaixa.FormattingEnabled = True
        Me.cboCaixa.Location = New System.Drawing.Point(12, 29)
        Me.cboCaixa.Name = "cboCaixa"
        Me.cboCaixa.Size = New System.Drawing.Size(338, 25)
        Me.cboCaixa.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Selecionar a embalagem"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.Location = New System.Drawing.Point(502, 116)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 28)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Adicionar"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnExcluir
        '
        Me.btnExcluir.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnExcluir.Location = New System.Drawing.Point(502, 150)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(84, 28)
        Me.btnExcluir.TabIndex = 8
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.UseVisualStyleBackColor = True
        '
        'txtTotal
        '
        Me.txtTotal.AutoSize = True
        Me.txtTotal.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotal.Location = New System.Drawing.Point(6, 361)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(360, 32)
        Me.txtTotal.TabIndex = 9
        Me.txtTotal.Text = "Valor da embalagem: R$ 0"
        '
        'btnSalvar
        '
        Me.btnSalvar.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSalvar.Location = New System.Drawing.Point(502, 82)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(84, 28)
        Me.btnSalvar.TabIndex = 10
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(502, 184)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 28)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.ImageIndex = 0
        Me.Button2.ImageList = Me.ImageList1
        Me.Button2.Location = New System.Drawing.Point(356, 27)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(140, 28)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Adicionar Itens"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "mais.png")
        '
        'frmItensCaixa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 402)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboCaixa)
        Me.Controls.Add(Me.dgvItens)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItensCaixa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Colocar itens na caixa"
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvItens As DataGridView
    Friend WithEvents cboCaixa As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnExcluir As Button
    Friend WithEvents txtTotal As Label
    Friend WithEvents btnSalvar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ImageList1 As ImageList
End Class
