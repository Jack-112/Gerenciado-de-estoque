<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.Menu1 = New System.Windows.Forms.MenuStrip()
        Me.mnAdmin = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SetoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnItens = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastroDeItensToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MovimentarItensToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FornecedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnCaixa = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CriarCaixaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ColocarItensNaCaixaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.FecharCaixaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReabrirCaixaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.EnviarCaixaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnCaixaRegistradora = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvEmbaEnviadas = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cboEnviado = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtFim3 = New System.Windows.Forms.DateTimePicker()
        Me.dtInicio3 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dtFim2 = New System.Windows.Forms.DateTimePicker()
        Me.dtInicio2 = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboItem = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboReceptor = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboResponsavel = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvMovimenta = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lbTotal = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.dtFim = New System.Windows.Forms.DateTimePicker()
        Me.dtInicio = New System.Windows.Forms.DateTimePicker()
        Me.cboClasse = New System.Windows.Forms.ComboBox()
        Me.cboFornecedor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvFornecedor = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Menu1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvEmbaEnviadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvMovimenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvFornecedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Menu1
        '
        Me.Menu1.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Menu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnAdmin, Me.mnItens, Me.mnCaixa, Me.mnCaixaRegistradora})
        Me.Menu1.Location = New System.Drawing.Point(0, 0)
        Me.Menu1.Name = "Menu1"
        Me.Menu1.Size = New System.Drawing.Size(713, 29)
        Me.Menu1.TabIndex = 0
        Me.Menu1.Text = "MenuStrip1"
        '
        'mnAdmin
        '
        Me.mnAdmin.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsuariosToolStripMenuItem, Me.ToolStripMenuItem1, Me.SetoresToolStripMenuItem, Me.ToolStripMenuItem2, Me.MenusToolStripMenuItem})
        Me.mnAdmin.Image = CType(resources.GetObject("mnAdmin.Image"), System.Drawing.Image)
        Me.mnAdmin.Name = "mnAdmin"
        Me.mnAdmin.Size = New System.Drawing.Size(162, 25)
        Me.mnAdmin.Text = "Administrador"
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.Image = CType(resources.GetObject("UsuariosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(277, 26)
        Me.UsuariosToolStripMenuItem.Text = "Gerenciar usuários"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(274, 6)
        '
        'SetoresToolStripMenuItem
        '
        Me.SetoresToolStripMenuItem.Image = CType(resources.GetObject("SetoresToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SetoresToolStripMenuItem.Name = "SetoresToolStripMenuItem"
        Me.SetoresToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.SetoresToolStripMenuItem.Size = New System.Drawing.Size(277, 26)
        Me.SetoresToolStripMenuItem.Text = "Setores"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(274, 6)
        '
        'MenusToolStripMenuItem
        '
        Me.MenusToolStripMenuItem.Image = CType(resources.GetObject("MenusToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MenusToolStripMenuItem.Name = "MenusToolStripMenuItem"
        Me.MenusToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.MenusToolStripMenuItem.Size = New System.Drawing.Size(277, 26)
        Me.MenusToolStripMenuItem.Text = "Liberar acesso"
        '
        'mnItens
        '
        Me.mnItens.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastroDeItensToolStripMenuItem, Me.ToolStripMenuItem3, Me.MovimentarItensToolStripMenuItem, Me.FornecedoresToolStripMenuItem})
        Me.mnItens.Image = CType(resources.GetObject("mnItens.Image"), System.Drawing.Image)
        Me.mnItens.Name = "mnItens"
        Me.mnItens.Size = New System.Drawing.Size(81, 25)
        Me.mnItens.Text = "Itens"
        '
        'CadastroDeItensToolStripMenuItem
        '
        Me.CadastroDeItensToolStripMenuItem.Image = CType(resources.GetObject("CadastroDeItensToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CadastroDeItensToolStripMenuItem.Name = "CadastroDeItensToolStripMenuItem"
        Me.CadastroDeItensToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.CadastroDeItensToolStripMenuItem.Size = New System.Drawing.Size(263, 26)
        Me.CadastroDeItensToolStripMenuItem.Text = "Gerenciar itens"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(260, 6)
        '
        'MovimentarItensToolStripMenuItem
        '
        Me.MovimentarItensToolStripMenuItem.Image = CType(resources.GetObject("MovimentarItensToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MovimentarItensToolStripMenuItem.Name = "MovimentarItensToolStripMenuItem"
        Me.MovimentarItensToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.MovimentarItensToolStripMenuItem.Size = New System.Drawing.Size(263, 26)
        Me.MovimentarItensToolStripMenuItem.Text = "Movimentar itens"
        '
        'FornecedoresToolStripMenuItem
        '
        Me.FornecedoresToolStripMenuItem.Name = "FornecedoresToolStripMenuItem"
        Me.FornecedoresToolStripMenuItem.Size = New System.Drawing.Size(263, 26)
        Me.FornecedoresToolStripMenuItem.Text = "Fornecedores"
        '
        'mnCaixa
        '
        Me.mnCaixa.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem4, Me.CriarCaixaToolStripMenuItem, Me.ToolStripMenuItem5, Me.ColocarItensNaCaixaToolStripMenuItem, Me.ToolStripMenuItem6, Me.FecharCaixaToolStripMenuItem, Me.ToolStripMenuItem7, Me.ReabrirCaixaToolStripMenuItem, Me.ToolStripMenuItem8, Me.EnviarCaixaToolStripMenuItem})
        Me.mnCaixa.Image = CType(resources.GetObject("mnCaixa.Image"), System.Drawing.Image)
        Me.mnCaixa.Name = "mnCaixa"
        Me.mnCaixa.Size = New System.Drawing.Size(146, 25)
        Me.mnCaixa.Text = "Embalagens"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(357, 6)
        '
        'CriarCaixaToolStripMenuItem
        '
        Me.CriarCaixaToolStripMenuItem.Name = "CriarCaixaToolStripMenuItem"
        Me.CriarCaixaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.CriarCaixaToolStripMenuItem.Size = New System.Drawing.Size(360, 26)
        Me.CriarCaixaToolStripMenuItem.Text = "Criar embalagem"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(357, 6)
        '
        'ColocarItensNaCaixaToolStripMenuItem
        '
        Me.ColocarItensNaCaixaToolStripMenuItem.Name = "ColocarItensNaCaixaToolStripMenuItem"
        Me.ColocarItensNaCaixaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.ColocarItensNaCaixaToolStripMenuItem.Size = New System.Drawing.Size(360, 26)
        Me.ColocarItensNaCaixaToolStripMenuItem.Text = "Colocar itens na embalagem"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(357, 6)
        '
        'FecharCaixaToolStripMenuItem
        '
        Me.FecharCaixaToolStripMenuItem.Name = "FecharCaixaToolStripMenuItem"
        Me.FecharCaixaToolStripMenuItem.Size = New System.Drawing.Size(360, 26)
        Me.FecharCaixaToolStripMenuItem.Text = "Fechar embalagem"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(357, 6)
        '
        'ReabrirCaixaToolStripMenuItem
        '
        Me.ReabrirCaixaToolStripMenuItem.Name = "ReabrirCaixaToolStripMenuItem"
        Me.ReabrirCaixaToolStripMenuItem.Size = New System.Drawing.Size(360, 26)
        Me.ReabrirCaixaToolStripMenuItem.Text = "Reabrir embalagem"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(357, 6)
        '
        'EnviarCaixaToolStripMenuItem
        '
        Me.EnviarCaixaToolStripMenuItem.Name = "EnviarCaixaToolStripMenuItem"
        Me.EnviarCaixaToolStripMenuItem.Size = New System.Drawing.Size(360, 26)
        Me.EnviarCaixaToolStripMenuItem.Text = "Enviar embalagem"
        '
        'mnCaixaRegistradora
        '
        Me.mnCaixaRegistradora.Image = CType(resources.GetObject("mnCaixaRegistradora.Image"), System.Drawing.Image)
        Me.mnCaixaRegistradora.Name = "mnCaixaRegistradora"
        Me.mnCaixaRegistradora.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.mnCaixaRegistradora.Size = New System.Drawing.Size(204, 25)
        Me.mnCaixaRegistradora.Text = "Caixa Registradora"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "excel.png")
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "lupa.png")
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvEmbaEnviadas)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Controls.Add(Me.cboEnviado)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.dtFim3)
        Me.TabPage3.Controls.Add(Me.dtInicio3)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Location = New System.Drawing.Point(4, 27)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(705, 361)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Emba. enviadas no mês"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvEmbaEnviadas
        '
        Me.dgvEmbaEnviadas.BackgroundColor = System.Drawing.Color.White
        Me.dgvEmbaEnviadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmbaEnviadas.Location = New System.Drawing.Point(6, 37)
        Me.dgvEmbaEnviadas.Name = "dgvEmbaEnviadas"
        Me.dgvEmbaEnviadas.Size = New System.Drawing.Size(693, 273)
        Me.dgvEmbaEnviadas.TabIndex = 41
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.ImageKey = "excel.png"
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(583, 316)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(116, 37)
        Me.Button1.TabIndex = 40
        Me.Button1.Text = "Exportar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cboEnviado
        '
        Me.cboEnviado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboEnviado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEnviado.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cboEnviado.FormattingEnabled = True
        Me.cboEnviado.Location = New System.Drawing.Point(271, 8)
        Me.cboEnviado.Name = "cboEnviado"
        Me.cboEnviado.Size = New System.Drawing.Size(303, 23)
        Me.cboEnviado.TabIndex = 28
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(196, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 15)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Enviado por:"
        '
        'dtFim3
        '
        Me.dtFim3.CustomFormat = "MM/yyyy"
        Me.dtFim3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dtFim3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFim3.Location = New System.Drawing.Point(124, 9)
        Me.dtFim3.Name = "dtFim3"
        Me.dtFim3.Size = New System.Drawing.Size(66, 21)
        Me.dtFim3.TabIndex = 26
        Me.dtFim3.Value = New Date(2022, 9, 29, 12, 54, 31, 0)
        '
        'dtInicio3
        '
        Me.dtInicio3.CustomFormat = "MM/yyyy"
        Me.dtInicio3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dtInicio3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtInicio3.Location = New System.Drawing.Point(29, 9)
        Me.dtInicio3.MaxDate = New Date(9998, 12, 1, 0, 0, 0, 0)
        Me.dtInicio3.Name = "dtInicio3"
        Me.dtInicio3.Size = New System.Drawing.Size(66, 21)
        Me.dtInicio3.TabIndex = 25
        Me.dtInicio3.Value = New Date(2022, 9, 29, 12, 54, 31, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(96, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 15)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Até:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 15)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "De:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.dtFim2)
        Me.TabPage2.Controls.Add(Me.dtInicio2)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.cboItem)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.cboReceptor)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.cboResponsavel)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.dgvMovimenta)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(705, 361)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Movimentados no mês"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.ImageKey = "excel.png"
        Me.Button2.ImageList = Me.ImageList1
        Me.Button2.Location = New System.Drawing.Point(583, 311)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 37)
        Me.Button2.TabIndex = 41
        Me.Button2.Text = "Exportar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dtFim2
        '
        Me.dtFim2.CustomFormat = "MM/yyyy"
        Me.dtFim2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dtFim2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFim2.Location = New System.Drawing.Point(133, 9)
        Me.dtFim2.Name = "dtFim2"
        Me.dtFim2.Size = New System.Drawing.Size(66, 21)
        Me.dtFim2.TabIndex = 21
        Me.dtFim2.Value = New Date(2022, 9, 29, 12, 54, 31, 0)
        '
        'dtInicio2
        '
        Me.dtInicio2.CustomFormat = "MM/yyyy"
        Me.dtInicio2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dtInicio2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtInicio2.Location = New System.Drawing.Point(38, 9)
        Me.dtInicio2.MaxDate = New Date(9998, 12, 1, 0, 0, 0, 0)
        Me.dtInicio2.Name = "dtInicio2"
        Me.dtInicio2.Size = New System.Drawing.Size(66, 21)
        Me.dtInicio2.TabIndex = 20
        Me.dtInicio2.Value = New Date(2022, 9, 29, 12, 54, 31, 0)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(105, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 15)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Até:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 15)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "De:"
        '
        'cboItem
        '
        Me.cboItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItem.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cboItem.FormattingEnabled = True
        Me.cboItem.Location = New System.Drawing.Point(38, 36)
        Me.cboItem.Name = "cboItem"
        Me.cboItem.Size = New System.Drawing.Size(161, 23)
        Me.cboItem.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(2, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 15)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Item:"
        '
        'cboReceptor
        '
        Me.cboReceptor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboReceptor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReceptor.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cboReceptor.FormattingEnabled = True
        Me.cboReceptor.Location = New System.Drawing.Point(517, 7)
        Me.cboReceptor.Name = "cboReceptor"
        Me.cboReceptor.Size = New System.Drawing.Size(182, 23)
        Me.cboReceptor.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(455, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Receptor:"
        '
        'cboResponsavel
        '
        Me.cboResponsavel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboResponsavel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboResponsavel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cboResponsavel.FormattingEnabled = True
        Me.cboResponsavel.Location = New System.Drawing.Point(284, 8)
        Me.cboResponsavel.Name = "cboResponsavel"
        Me.cboResponsavel.Size = New System.Drawing.Size(169, 23)
        Me.cboResponsavel.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(201, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Responsavel:"
        '
        'dgvMovimenta
        '
        Me.dgvMovimenta.BackgroundColor = System.Drawing.Color.White
        Me.dgvMovimenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovimenta.Location = New System.Drawing.Point(6, 65)
        Me.dgvMovimenta.Name = "dgvMovimenta"
        Me.dgvMovimenta.Size = New System.Drawing.Size(693, 242)
        Me.dgvMovimenta.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.lbTotal)
        Me.TabPage1.Controls.Add(Me.btnExportar)
        Me.TabPage1.Controls.Add(Me.dtFim)
        Me.TabPage1.Controls.Add(Me.dtInicio)
        Me.TabPage1.Controls.Add(Me.cboClasse)
        Me.TabPage1.Controls.Add(Me.cboFornecedor)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.dgvFornecedor)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(705, 361)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Vendidos no mês"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lbTotal
        '
        Me.lbTotal.AutoSize = True
        Me.lbTotal.BackColor = System.Drawing.Color.Transparent
        Me.lbTotal.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lbTotal.Location = New System.Drawing.Point(2, 319)
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(59, 21)
        Me.lbTotal.TabIndex = 40
        Me.lbTotal.Text = "Total:"
        '
        'btnExportar
        '
        Me.btnExportar.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportar.ImageKey = "excel.png"
        Me.btnExportar.ImageList = Me.ImageList1
        Me.btnExportar.Location = New System.Drawing.Point(583, 311)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(116, 37)
        Me.btnExportar.TabIndex = 39
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'dtFim
        '
        Me.dtFim.CustomFormat = "MM/yyyy"
        Me.dtFim.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFim.Location = New System.Drawing.Point(141, 9)
        Me.dtFim.Name = "dtFim"
        Me.dtFim.Size = New System.Drawing.Size(66, 21)
        Me.dtFim.TabIndex = 10
        Me.dtFim.Value = New Date(2022, 9, 29, 12, 54, 31, 0)
        '
        'dtInicio
        '
        Me.dtInicio.CustomFormat = "MM/yyyy"
        Me.dtInicio.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtInicio.Location = New System.Drawing.Point(34, 9)
        Me.dtInicio.MaxDate = New Date(9998, 12, 1, 0, 0, 0, 0)
        Me.dtInicio.Name = "dtInicio"
        Me.dtInicio.Size = New System.Drawing.Size(66, 21)
        Me.dtInicio.TabIndex = 9
        Me.dtInicio.Value = New Date(2022, 9, 29, 12, 54, 31, 0)
        '
        'cboClasse
        '
        Me.cboClasse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboClasse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboClasse.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cboClasse.FormattingEnabled = True
        Me.cboClasse.Location = New System.Drawing.Point(524, 8)
        Me.cboClasse.Name = "cboClasse"
        Me.cboClasse.Size = New System.Drawing.Size(175, 23)
        Me.cboClasse.TabIndex = 8
        '
        'cboFornecedor
        '
        Me.cboFornecedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboFornecedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFornecedor.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cboFornecedor.FormattingEnabled = True
        Me.cboFornecedor.Location = New System.Drawing.Point(295, 9)
        Me.cboFornecedor.Name = "cboFornecedor"
        Me.cboFornecedor.Size = New System.Drawing.Size(169, 23)
        Me.cboFornecedor.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(469, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Classe:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(213, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Fornecedor:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(106, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Até:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "De:"
        '
        'dgvFornecedor
        '
        Me.dgvFornecedor.BackgroundColor = System.Drawing.Color.White
        Me.dgvFornecedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFornecedor.Location = New System.Drawing.Point(6, 38)
        Me.dgvFornecedor.Name = "dgvFornecedor"
        Me.dgvFornecedor.Size = New System.Drawing.Size(693, 258)
        Me.dgvFornecedor.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 29)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(713, 392)
        Me.TabControl1.TabIndex = 5
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(713, 421)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Menu1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.Menu1
        Me.MaximizeBox = False
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Menu1.ResumeLayout(False)
        Me.Menu1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgvEmbaEnviadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvMovimenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvFornecedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Menu1 As MenuStrip
    Friend WithEvents mnAdmin As ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnItens As ToolStripMenuItem
    Friend WithEvents CadastroDeItensToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnCaixaRegistradora As ToolStripMenuItem
    Friend WithEvents MovimentarItensToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents mnCaixa As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents CriarCaixaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripSeparator
    Friend WithEvents ColocarItensNaCaixaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As ToolStripSeparator
    Friend WithEvents FecharCaixaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As ToolStripSeparator
    Friend WithEvents ReabrirCaixaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As ToolStripSeparator
    Friend WithEvents EnviarCaixaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FornecedoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Button2 As Button
    Friend WithEvents dtFim2 As DateTimePicker
    Friend WithEvents dtInicio2 As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cboItem As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cboReceptor As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cboResponsavel As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dgvMovimenta As DataGridView
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents lbTotal As Label
    Friend WithEvents btnExportar As Button
    Friend WithEvents dtFim As DateTimePicker
    Friend WithEvents dtInicio As DateTimePicker
    Friend WithEvents cboClasse As ComboBox
    Friend WithEvents cboFornecedor As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvFornecedor As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents dtFim3 As DateTimePicker
    Friend WithEvents dtInicio3 As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cboEnviado As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents dgvEmbaEnviadas As DataGridView
End Class
