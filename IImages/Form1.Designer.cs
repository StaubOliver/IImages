namespace IImages
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAdd = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.searchParcourir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAjoutNom = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonAjoutSelectAll = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.labelAjoutDate = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonAjoutSuppr = new System.Windows.Forms.Button();
            this.add_Submit = new System.Windows.Forms.Button();
            this.richTextBoxAjoutTags = new System.Windows.Forms.RichTextBox();
            this.richTextBoxAjoutPersonnes = new System.Windows.Forms.RichTextBox();
            this.listViewAjout = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListajout = new System.Windows.Forms.ImageList(this.components);
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownSearch = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewSearch = new System.Windows.Forms.ListView();
            this.imageListSearch = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAdd.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabSearch.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearch)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabEdit.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(944, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(118, 17);
            this.status.Text = "toolStripStatusLabel1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAdd);
            this.tabControl1.Controls.Add(this.tabSearch);
            this.tabControl1.Controls.Add(this.tabEdit);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(45, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(944, 539);
            this.tabControl1.TabIndex = 1;
            // 
            // tabAdd
            // 
            this.tabAdd.Controls.Add(this.tableLayoutPanel3);
            this.tabAdd.Location = new System.Drawing.Point(4, 22);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdd.Size = new System.Drawing.Size(936, 513);
            this.tabAdd.TabIndex = 1;
            this.tabAdd.Text = "Ajouter";
            this.tabAdd.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.listViewAjout, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(930, 507);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel4.Controls.Add(this.pictureBox1, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.searchParcourir, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(922, 44);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(553, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // searchParcourir
            // 
            this.searchParcourir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchParcourir.Location = new System.Drawing.Point(375, 7);
            this.searchParcourir.Name = "searchParcourir";
            this.searchParcourir.Size = new System.Drawing.Size(169, 30);
            this.searchParcourir.TabIndex = 0;
            this.searchParcourir.Text = "Parcourir";
            this.searchParcourir.UseVisualStyleBackColor = true;
            this.searchParcourir.Click += new System.EventHandler(this.searchParcourir_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 44);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ajouter des photos au catalogue :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.labelAjoutNom, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.label7, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.numericUpDown1, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.button3, 5, 2);
            this.tableLayoutPanel5.Controls.Add(this.buttonAjoutSelectAll, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.labelAjoutDate, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.button2, 4, 1);
            this.tableLayoutPanel5.Controls.Add(this.buttonAjoutSuppr, 4, 2);
            this.tableLayoutPanel5.Controls.Add(this.add_Submit, 5, 1);
            this.tableLayoutPanel5.Controls.Add(this.richTextBoxAjoutTags, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.richTextBoxAjoutPersonnes, 3, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 409);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(922, 94);
            this.tableLayoutPanel5.TabIndex = 2;
            this.tableLayoutPanel5.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel5_Paint);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nom du fichier";
            // 
            // labelAjoutNom
            // 
            this.labelAjoutNom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelAjoutNom.AutoSize = true;
            this.labelAjoutNom.Location = new System.Drawing.Point(3, 40);
            this.labelAjoutNom.Name = "labelAjoutNom";
            this.labelAjoutNom.Size = new System.Drawing.Size(35, 13);
            this.labelAjoutNom.TabIndex = 1;
            this.labelAjoutNom.Text = "label3";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Date de prise de vue";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tags";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(463, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Personnes";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(118, 65);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(109, 20);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button3.Location = new System.Drawing.Point(819, 66);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Annuler";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // buttonAjoutSelectAll
            // 
            this.buttonAjoutSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonAjoutSelectAll.Location = new System.Drawing.Point(693, 4);
            this.buttonAjoutSelectAll.Name = "buttonAjoutSelectAll";
            this.buttonAjoutSelectAll.Size = new System.Drawing.Size(100, 23);
            this.buttonAjoutSelectAll.TabIndex = 12;
            this.buttonAjoutSelectAll.Text = "Select All";
            this.buttonAjoutSelectAll.UseVisualStyleBackColor = true;
            this.buttonAjoutSelectAll.Click += new System.EventHandler(this.buttonAjoutSelectAll_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Note";
            // 
            // labelAjoutDate
            // 
            this.labelAjoutDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelAjoutDate.AutoSize = true;
            this.labelAjoutDate.Location = new System.Drawing.Point(118, 40);
            this.labelAjoutDate.Name = "labelAjoutDate";
            this.labelAjoutDate.Size = new System.Drawing.Size(35, 13);
            this.labelAjoutDate.TabIndex = 3;
            this.labelAjoutDate.Text = "label5";
            this.labelAjoutDate.Click += new System.EventHandler(this.labelAjoutDate_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.Location = new System.Drawing.Point(693, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Inverser";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button2_MouseClick);
            // 
            // buttonAjoutSuppr
            // 
            this.buttonAjoutSuppr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonAjoutSuppr.Location = new System.Drawing.Point(693, 66);
            this.buttonAjoutSuppr.Name = "buttonAjoutSuppr";
            this.buttonAjoutSuppr.Size = new System.Drawing.Size(100, 23);
            this.buttonAjoutSuppr.TabIndex = 14;
            this.buttonAjoutSuppr.Text = "Supprimer";
            this.buttonAjoutSuppr.UseVisualStyleBackColor = true;
            this.buttonAjoutSuppr.Click += new System.EventHandler(this.buttonAjoutSuppr_Click);
            // 
            // add_Submit
            // 
            this.add_Submit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.add_Submit.Location = new System.Drawing.Point(819, 35);
            this.add_Submit.Name = "add_Submit";
            this.add_Submit.Size = new System.Drawing.Size(100, 23);
            this.add_Submit.TabIndex = 8;
            this.add_Submit.Text = "Ajouter";
            this.add_Submit.UseVisualStyleBackColor = true;
            this.add_Submit.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBoxAjoutTags
            // 
            this.richTextBoxAjoutTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxAjoutTags.Location = new System.Drawing.Point(233, 34);
            this.richTextBoxAjoutTags.Name = "richTextBoxAjoutTags";
            this.tableLayoutPanel5.SetRowSpan(this.richTextBoxAjoutTags, 2);
            this.richTextBoxAjoutTags.Size = new System.Drawing.Size(224, 57);
            this.richTextBoxAjoutTags.TabIndex = 15;
            this.richTextBoxAjoutTags.Text = "";
            this.richTextBoxAjoutTags.TextChanged += new System.EventHandler(this.richTextBoxAjoutTags_TextChanged);
            this.richTextBoxAjoutTags.Validating += new System.ComponentModel.CancelEventHandler(this.richTextBoxAjoutTags_Validating);
            // 
            // richTextBoxAjoutPersonnes
            // 
            this.richTextBoxAjoutPersonnes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxAjoutPersonnes.Location = new System.Drawing.Point(463, 34);
            this.richTextBoxAjoutPersonnes.Name = "richTextBoxAjoutPersonnes";
            this.tableLayoutPanel5.SetRowSpan(this.richTextBoxAjoutPersonnes, 2);
            this.richTextBoxAjoutPersonnes.Size = new System.Drawing.Size(224, 57);
            this.richTextBoxAjoutPersonnes.TabIndex = 16;
            this.richTextBoxAjoutPersonnes.Text = "";
            // 
            // listViewAjout
            // 
            this.listViewAjout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewAjout.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewAjout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAjout.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewAjout.LargeImageList = this.imageListajout;
            this.listViewAjout.Location = new System.Drawing.Point(4, 55);
            this.listViewAjout.Name = "listViewAjout";
            this.listViewAjout.ShowGroups = false;
            this.listViewAjout.Size = new System.Drawing.Size(922, 347);
            this.listViewAjout.TabIndex = 3;
            this.listViewAjout.UseCompatibleStateImageBehavior = false;
            this.listViewAjout.View = System.Windows.Forms.View.Tile;
            this.listViewAjout.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewAjout_ItemSelectionChanged);
            this.listViewAjout.SelectedIndexChanged += new System.EventHandler(this.listViewAjout_SelectedIndexChanged);
            // 
            // imageListajout
            // 
            this.imageListajout.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageListajout.ImageSize = new System.Drawing.Size(100, 100);
            this.imageListajout.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.tableLayoutPanel1);
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(936, 513);
            this.tabSearch.TabIndex = 0;
            this.tabSearch.Text = "Rechercher";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel10, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(930, 507);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(346, 26);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 94);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rechercher :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.Location = new System.Drawing.Point(463, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 5;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.88889F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel8.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 3, 0);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel7, 4, 0);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(922, 94);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.numericUpDownSearch, 0, 1);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(514, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(178, 88);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Note";
            // 
            // numericUpDownSearch
            // 
            this.numericUpDownSearch.Location = new System.Drawing.Point(3, 32);
            this.numericUpDownSearch.Name = "numericUpDownSearch";
            this.numericUpDownSearch.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSearch.TabIndex = 1;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.button4, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.button5, 0, 1);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(718, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(180, 88);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button4.Location = new System.Drawing.Point(15, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Copier vers le presse papier";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button5.Location = new System.Drawing.Point(15, 32);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "Editer";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Controls.Add(this.listViewSearch, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(4, 105);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(922, 398);
            this.tableLayoutPanel10.TabIndex = 2;
            // 
            // listViewSearch
            // 
            this.listViewSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSearch.LargeImageList = this.imageListSearch;
            this.listViewSearch.Location = new System.Drawing.Point(3, 3);
            this.listViewSearch.Name = "listViewSearch";
            this.listViewSearch.Size = new System.Drawing.Size(455, 392);
            this.listViewSearch.TabIndex = 0;
            this.listViewSearch.UseCompatibleStateImageBehavior = false;
            this.listViewSearch.View = System.Windows.Forms.View.Tile;
            this.listViewSearch.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewSearch_ItemSelectionChanged);
            this.listViewSearch.SelectedIndexChanged += new System.EventHandler(this.listViewSearch_SelectedIndexChanged);
            // 
            // imageListSearch
            // 
            this.imageListSearch.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageListSearch.ImageSize = new System.Drawing.Size(100, 100);
            this.imageListSearch.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(464, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(455, 392);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // tabEdit
            // 
            this.tabEdit.Controls.Add(this.tableLayoutPanel6);
            this.tabEdit.Location = new System.Drawing.Point(4, 22);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabEdit.Size = new System.Drawing.Size(936, 513);
            this.tabEdit.TabIndex = 2;
            this.tabEdit.Text = "Editer";
            this.tabEdit.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(930, 507);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(105, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(352, 88);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(346, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "label5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IImages";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabAdd.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabSearch.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearch)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabEdit.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button searchParcourir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelAjoutNom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAjoutDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button add_Submit;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.ListView listViewAjout;
        private System.Windows.Forms.ImageList imageListajout;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonAjoutSelectAll;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonAjoutSuppr;
        private System.Windows.Forms.RichTextBox richTextBoxAjoutTags;
        private System.Windows.Forms.RichTextBox richTextBoxAjoutPersonnes;
        private System.Windows.Forms.NumericUpDown numericUpDownSearch;
        private System.Windows.Forms.ImageList imageListSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewSearch;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label5;



    }
}

