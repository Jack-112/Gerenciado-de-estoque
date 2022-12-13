<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCadastroItens
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroItens))
        Me.txtQuantidade = New System.Windows.Forms.NumericUpDown()
        Me.cboClasse = New System.Windows.Forms.ComboBox()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.txtCodigoBarras = New System.Windows.Forms.TextBox()
        Me.txtDataValidade = New System.Windows.Forms.MaskedTextBox()
        Me.txtValorCusto = New System.Windows.Forms.TextBox()
        Me.txtValorVenda = New System.Windows.Forms.TextBox()
        Me.dgvItens = New System.Windows.Forms.DataGridView()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPrateleira = New System.Windows.Forms.TextBox()
        Me.txtAndar = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtQuantidadeMini = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtBusca = New System.Windows.Forms.TextBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnLimpa = New System.Windows.Forms.Button()
        Me.btnOkFiltro = New System.Windows.Forms.Button()
        Me.ckFiltro = New System.Windows.Forms.CheckedListBox()
        Me.ckOcultar = New System.Windows.Forms.CheckedListBox()
        Me.btnLimpa2 = New System.Windows.Forms.Button()
        Me.btnOkFiltro2 = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboFornecedor = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnOcultar = New System.Windows.Forms.Button()
        Me.btnFiltro = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Enabled = False
        Me.txtQuantidade.Location = New System.Drawing.Point(372, 29)
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.Size = New System.Drawing.Size(50, 21)
        Me.txtQuantidade.TabIndex = 3
        '
        'cboClasse
        '
        Me.cboClasse.Enabled = False
        Me.cboClasse.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.cboClasse.FormattingEnabled = True
        Me.cboClasse.Location = New System.Drawing.Point(433, 27)
        Me.cboClasse.Name = "cboClasse"
        Me.cboClasse.Size = New System.Drawing.Size(127, 24)
        Me.cboClasse.TabIndex = 4
        '
        'txtNome
        '
        Me.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNome.Enabled = False
        Me.txtNome.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtNome.Location = New System.Drawing.Point(12, 27)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(243, 23)
        Me.txtNome.TabIndex = 1
        '
        'txtDescricao
        '
        Me.txtDescricao.Enabled = False
        Me.txtDescricao.Location = New System.Drawing.Point(12, 115)
        Me.txtDescricao.Multiline = True
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(312, 183)
        Me.txtDescricao.TabIndex = 6
        '
        'txtCodigoBarras
        '
        Me.txtCodigoBarras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoBarras.Enabled = False
        Me.txtCodigoBarras.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtCodigoBarras.Location = New System.Drawing.Point(138, 70)
        Me.txtCodigoBarras.Name = "txtCodigoBarras"
        Me.txtCodigoBarras.Size = New System.Drawing.Size(230, 23)
        Me.txtCodigoBarras.TabIndex = 7
        '
        'txtDataValidade
        '
        Me.txtDataValidade.Enabled = False
        Me.txtDataValidade.Location = New System.Drawing.Point(261, 29)
        Me.txtDataValidade.Mask = "00/00/0000"
        Me.txtDataValidade.Name = "txtDataValidade"
        Me.txtDataValidade.Size = New System.Drawing.Size(100, 21)
        Me.txtDataValidade.TabIndex = 2
        Me.txtDataValidade.ValidatingType = GetType(Date)
        '
        'txtValorCusto
        '
        Me.txtValorCusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValorCusto.Enabled = False
        Me.txtValorCusto.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtValorCusto.Location = New System.Drawing.Point(328, 159)
        Me.txtValorCusto.Name = "txtValorCusto"
        Me.txtValorCusto.Size = New System.Drawing.Size(114, 23)
        Me.txtValorCusto.TabIndex = 10
        '
        'txtValorVenda
        '
        Me.txtValorVenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValorVenda.Enabled = False
        Me.txtValorVenda.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtValorVenda.Location = New System.Drawing.Point(455, 159)
        Me.txtValorVenda.Name = "txtValorVenda"
        Me.txtValorVenda.Size = New System.Drawing.Size(102, 23)
        Me.txtValorVenda.TabIndex = 11
        '
        'dgvItens
        '
        Me.dgvItens.BackgroundColor = System.Drawing.Color.White
        Me.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItens.Location = New System.Drawing.Point(12, 335)
        Me.dgvItens.Name = "dgvItens"
        Me.dgvItens.Size = New System.Drawing.Size(579, 289)
        Me.dgvItens.TabIndex = 15
        '
        'btnEditar
        '
        Me.btnEditar.Enabled = False
        Me.btnEditar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEditar.Location = New System.Drawing.Point(344, 225)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(83, 31)
        Me.btnEditar.TabIndex = 14
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancelar.Location = New System.Drawing.Point(465, 262)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(83, 31)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnSalvar
        '
        Me.btnSalvar.Enabled = False
        Me.btnSalvar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSalvar.Location = New System.Drawing.Point(344, 188)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(83, 31)
        Me.btnSalvar.TabIndex = 13
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 15)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Nome do Produto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(258, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Data de validade"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(362, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Quantidade"
        '
        'btnNovo
        '
        Me.btnNovo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnNovo.Location = New System.Drawing.Point(465, 188)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(83, 31)
        Me.btnNovo.TabIndex = 16
        Me.btnNovo.Text = "Novo"
        Me.btnNovo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(12, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 15)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Descrição"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(135, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 15)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Código de barras"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(326, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 15)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Valor de custo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(452, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 15)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Valor de venda"
        '
        'btnExcluir
        '
        Me.btnExcluir.Enabled = False
        Me.btnExcluir.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnExcluir.Location = New System.Drawing.Point(344, 262)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(83, 31)
        Me.btnExcluir.TabIndex = 17
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(460, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 15)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Classe"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Pink
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(103, 631)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(25, 25)
        Me.Panel1.TabIndex = 23
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Yellow
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Location = New System.Drawing.Point(203, 631)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(25, 25)
        Me.Panel2.TabIndex = 24
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(129, 635)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 16)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Vencidos"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(229, 635)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(154, 16)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Perto do vencimento"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.YellowGreen
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(384, 631)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(25, 25)
        Me.Panel3.TabIndex = 25
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(410, 635)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 16)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Baixo estoque"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(326, 97)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 15)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Prateleira"
        '
        'txtPrateleira
        '
        Me.txtPrateleira.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrateleira.Enabled = False
        Me.txtPrateleira.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtPrateleira.Location = New System.Drawing.Point(329, 115)
        Me.txtPrateleira.Name = "txtPrateleira"
        Me.txtPrateleira.Size = New System.Drawing.Size(113, 23)
        Me.txtPrateleira.TabIndex = 8
        '
        'txtAndar
        '
        Me.txtAndar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAndar.Enabled = False
        Me.txtAndar.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtAndar.Location = New System.Drawing.Point(456, 115)
        Me.txtAndar.Name = "txtAndar"
        Me.txtAndar.Size = New System.Drawing.Size(102, 23)
        Me.txtAndar.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(452, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 15)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Andar"
        '
        'txtQuantidadeMini
        '
        Me.txtQuantidadeMini.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantidadeMini.Enabled = False
        Me.txtQuantidadeMini.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtQuantidadeMini.Location = New System.Drawing.Point(14, 70)
        Me.txtQuantidadeMini.Name = "txtQuantidadeMini"
        Me.txtQuantidadeMini.Size = New System.Drawing.Size(115, 23)
        Me.txtQuantidadeMini.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(12, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 15)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Quantidade minima"
        '
        'txtBusca
        '
        Me.txtBusca.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtBusca.Location = New System.Drawing.Point(12, 305)
        Me.txtBusca.Name = "txtBusca"
        Me.txtBusca.Size = New System.Drawing.Size(282, 23)
        Me.txtBusca.TabIndex = 19
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "seta-para-baixo (1).png")
        Me.ImageList1.Images.SetKeyName(1, "lupa.png")
        Me.ImageList1.Images.SetKeyName(2, "excel.png")
        '
        'btnLimpa
        '
        Me.btnLimpa.Location = New System.Drawing.Point(535, 402)
        Me.btnLimpa.Name = "btnLimpa"
        Me.btnLimpa.Size = New System.Drawing.Size(54, 23)
        Me.btnLimpa.TabIndex = 15
        Me.btnLimpa.Text = "Limpar"
        Me.btnLimpa.UseVisualStyleBackColor = True
        Me.btnLimpa.Visible = False
        '
        'btnOkFiltro
        '
        Me.btnOkFiltro.Location = New System.Drawing.Point(493, 402)
        Me.btnOkFiltro.Name = "btnOkFiltro"
        Me.btnOkFiltro.Size = New System.Drawing.Size(43, 23)
        Me.btnOkFiltro.TabIndex = 14
        Me.btnOkFiltro.Text = "OK"
        Me.btnOkFiltro.UseVisualStyleBackColor = True
        Me.btnOkFiltro.Visible = False
        '
        'ckFiltro
        '
        Me.ckFiltro.BackColor = System.Drawing.SystemColors.Control
        Me.ckFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ckFiltro.CheckOnClick = True
        Me.ckFiltro.ColumnWidth = 85
        Me.ckFiltro.FormattingEnabled = True
        Me.ckFiltro.Items.AddRange(New Object() {"Andar", "Bx estoque", "Cd barras", "Classe", "Dt validade", "Item", "Prateleira", "Pt vencer ", "Qt minima", "Quantidade", "Vencidos ", "Vl custo", "Vl Venda", "Fornecedor"})
        Me.ckFiltro.Location = New System.Drawing.Point(334, 329)
        Me.ckFiltro.Name = "ckFiltro"
        Me.ckFiltro.Size = New System.Drawing.Size(257, 114)
        Me.ckFiltro.TabIndex = 40
        Me.ckFiltro.Visible = False
        '
        'ckOcultar
        '
        Me.ckOcultar.BackColor = System.Drawing.SystemColors.Control
        Me.ckOcultar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ckOcultar.CheckOnClick = True
        Me.ckOcultar.ColumnWidth = 100
        Me.ckOcultar.FormattingEnabled = True
        Me.ckOcultar.Items.AddRange(New Object() {"Item", "Descrição", "Classe", "Cd de barras", "Dt de validade", "Quantidade", "Qtd minima", "Vl de custo", "Vl de venda", "Prateleira", "Andar", "Fornecedor"})
        Me.ckOcultar.Location = New System.Drawing.Point(334, 329)
        Me.ckOcultar.Name = "ckOcultar"
        Me.ckOcultar.Size = New System.Drawing.Size(257, 114)
        Me.ckOcultar.TabIndex = 41
        Me.ckOcultar.Visible = False
        '
        'btnLimpa2
        '
        Me.btnLimpa2.Location = New System.Drawing.Point(535, 413)
        Me.btnLimpa2.Name = "btnLimpa2"
        Me.btnLimpa2.Size = New System.Drawing.Size(54, 23)
        Me.btnLimpa2.TabIndex = 45
        Me.btnLimpa2.Text = "Limpar"
        Me.btnLimpa2.UseVisualStyleBackColor = True
        Me.btnLimpa2.Visible = False
        '
        'btnOkFiltro2
        '
        Me.btnOkFiltro2.Location = New System.Drawing.Point(493, 413)
        Me.btnOkFiltro2.Name = "btnOkFiltro2"
        Me.btnOkFiltro2.Size = New System.Drawing.Size(43, 23)
        Me.btnOkFiltro2.TabIndex = 44
        Me.btnOkFiltro2.Text = "OK"
        Me.btnOkFiltro2.UseVisualStyleBackColor = True
        Me.btnOkFiltro2.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(374, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 15)
        Me.Label15.TabIndex = 354
        Me.Label15.Text = "Fornecedor"
        '
        'cboFornecedor
        '
        Me.cboFornecedor.Enabled = False
        Me.cboFornecedor.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.cboFornecedor.FormattingEnabled = True
        Me.cboFornecedor.Location = New System.Drawing.Point(374, 69)
        Me.cboFornecedor.Name = "cboFornecedor"
        Me.cboFornecedor.Size = New System.Drawing.Size(186, 24)
        Me.cboFornecedor.TabIndex = 355
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.TCC.My.Resources.Resources.botao_de_simbolo_de_mais
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.Location = New System.Drawing.Point(561, 69)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 24)
        Me.Button2.TabIndex = 356
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnOcultar
        '
        Me.btnOcultar.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnOcultar.ImageIndex = 0
        Me.btnOcultar.ImageList = Me.ImageList1
        Me.btnOcultar.Location = New System.Drawing.Point(392, 304)
        Me.btnOcultar.Name = "btnOcultar"
        Me.btnOcultar.Size = New System.Drawing.Size(65, 25)
        Me.btnOcultar.TabIndex = 39
        Me.btnOcultar.Text = "Ocultar"
        Me.btnOcultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOcultar.UseVisualStyleBackColor = True
        '
        'btnFiltro
        '
        Me.btnFiltro.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnFiltro.ImageIndex = 0
        Me.btnFiltro.ImageList = Me.ImageList1
        Me.btnFiltro.Location = New System.Drawing.Point(332, 304)
        Me.btnFiltro.Name = "btnFiltro"
        Me.btnFiltro.Size = New System.Drawing.Size(59, 25)
        Me.btnFiltro.TabIndex = 352
        Me.btnFiltro.Text = "Filtros"
        Me.btnFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFiltro.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.ImageIndex = 2
        Me.Button5.ImageList = Me.ImageList1
        Me.Button5.Location = New System.Drawing.Point(465, 225)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(83, 31)
        Me.Button5.TabIndex = 38
        Me.Button5.Text = "    Exportar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.ImageIndex = 1
        Me.Button4.ImageList = Me.ImageList1
        Me.Button4.Location = New System.Drawing.Point(294, 304)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(38, 25)
        Me.Button4.TabIndex = 20
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.TCC.My.Resources.Resources.botao_de_simbolo_de_mais
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(561, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 24)
        Me.Button1.TabIndex = 5
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmCadastroItens
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 660)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cboFornecedor)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btnLimpa2)
        Me.Controls.Add(Me.btnOkFiltro2)
        Me.Controls.Add(Me.btnLimpa)
        Me.Controls.Add(Me.btnOkFiltro)
        Me.Controls.Add(Me.btnOcultar)
        Me.Controls.Add(Me.btnFiltro)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txtBusca)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtQuantidadeMini)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtAndar)
        Me.Controls.Add(Me.txtPrateleira)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnNovo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.txtValorVenda)
        Me.Controls.Add(Me.txtValorCusto)
        Me.Controls.Add(Me.txtDataValidade)
        Me.Controls.Add(Me.txtCodigoBarras)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.cboClasse)
        Me.Controls.Add(Me.txtQuantidade)
        Me.Controls.Add(Me.ckOcultar)
        Me.Controls.Add(Me.ckFiltro)
        Me.Controls.Add(Me.dgvItens)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCadastroItens"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gerenciar itens"
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtQuantidade As NumericUpDown
    Friend WithEvents cboClasse As ComboBox
    Friend WithEvents txtNome As TextBox
    Friend WithEvents txtDescricao As TextBox
    Friend WithEvents txtCodigoBarras As TextBox
    Friend WithEvents txtDataValidade As MaskedTextBox
    Friend WithEvents txtValorCusto As TextBox
    Friend WithEvents txtValorVenda As TextBox
    Friend WithEvents dgvItens As DataGridView
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnSalvar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents btnNovo As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnExcluir As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtPrateleira As TextBox
    Friend WithEvents txtAndar As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtQuantidadeMini As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtBusca As TextBox
    Friend WithEvents btnFiltro As Button
    Private WithEvents ImageList1 As ImageList
    Friend WithEvents btnOkFiltro As Button
    Friend WithEvents btnLimpa As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents btnOcultar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ckFiltro As CheckedListBox
    Friend WithEvents ckOcultar As CheckedListBox
    Friend WithEvents btnLimpa2 As Button
    Friend WithEvents btnOkFiltro2 As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents cboFornecedor As ComboBox
    Friend WithEvents Button2 As Button
End Class
