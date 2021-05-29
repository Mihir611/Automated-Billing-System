namespace Hi_Tech
{
    partial class itemmasterlist
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(itemmasterlist));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendornameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemgroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxcatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsncodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salepriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasepriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mrpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesdiscountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasediscountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salPricIncTaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._HI_TECHDataSet = new Hi_Tech._HI_TECHDataSet();
            this.itemTableAdapter = new Hi_Tech._HI_TECHDataSetTableAdapters.ItemTableAdapter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._HI_TECHDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 59);
            this.panel1.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(338, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(222, 30);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the name of item to search";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(579, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 50);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemnameDataGridViewTextBoxColumn,
            this.vendornameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.modelnoDataGridViewTextBoxColumn,
            this.itemgroupDataGridViewTextBoxColumn,
            this.taxcatDataGridViewTextBoxColumn,
            this.hsncodeDataGridViewTextBoxColumn,
            this.salepriceDataGridViewTextBoxColumn,
            this.purchasepriceDataGridViewTextBoxColumn,
            this.mrpDataGridViewTextBoxColumn,
            this.salesdiscountDataGridViewTextBoxColumn,
            this.purchasediscountDataGridViewTextBoxColumn,
            this.itemIdDataGridViewTextBoxColumn,
            this.unitDataGridViewTextBoxColumn,
            this.stockDataGridViewTextBoxColumn,
            this.salPricIncTaxDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.itemBindingSource;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridView1.Location = new System.Drawing.Point(17, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1130, 362);
            this.dataGridView1.TabIndex = 8;
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.DataPropertyName = "Item_name";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.itemnameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.itemnameDataGridViewTextBoxColumn.HeaderText = "Item_name";
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            // 
            // vendornameDataGridViewTextBoxColumn
            // 
            this.vendornameDataGridViewTextBoxColumn.DataPropertyName = "Vendor_name";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.vendornameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.vendornameDataGridViewTextBoxColumn.HeaderText = "Vendor_name";
            this.vendornameDataGridViewTextBoxColumn.Name = "vendornameDataGridViewTextBoxColumn";
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.manufacturerDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            // 
            // modelnoDataGridViewTextBoxColumn
            // 
            this.modelnoDataGridViewTextBoxColumn.DataPropertyName = "Model_no";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.modelnoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.modelnoDataGridViewTextBoxColumn.HeaderText = "Model_no";
            this.modelnoDataGridViewTextBoxColumn.Name = "modelnoDataGridViewTextBoxColumn";
            // 
            // itemgroupDataGridViewTextBoxColumn
            // 
            this.itemgroupDataGridViewTextBoxColumn.DataPropertyName = "Item_group";
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.itemgroupDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.itemgroupDataGridViewTextBoxColumn.HeaderText = "Item_group";
            this.itemgroupDataGridViewTextBoxColumn.Name = "itemgroupDataGridViewTextBoxColumn";
            // 
            // taxcatDataGridViewTextBoxColumn
            // 
            this.taxcatDataGridViewTextBoxColumn.DataPropertyName = "Tax_cat";
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.taxcatDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.taxcatDataGridViewTextBoxColumn.HeaderText = "Tax_cat";
            this.taxcatDataGridViewTextBoxColumn.Name = "taxcatDataGridViewTextBoxColumn";
            // 
            // hsncodeDataGridViewTextBoxColumn
            // 
            this.hsncodeDataGridViewTextBoxColumn.DataPropertyName = "Hsn_code";
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.hsncodeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.hsncodeDataGridViewTextBoxColumn.HeaderText = "Hsn_code";
            this.hsncodeDataGridViewTextBoxColumn.Name = "hsncodeDataGridViewTextBoxColumn";
            // 
            // salepriceDataGridViewTextBoxColumn
            // 
            this.salepriceDataGridViewTextBoxColumn.DataPropertyName = "Sale_price";
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.salepriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.salepriceDataGridViewTextBoxColumn.HeaderText = "Sale_price";
            this.salepriceDataGridViewTextBoxColumn.Name = "salepriceDataGridViewTextBoxColumn";
            // 
            // purchasepriceDataGridViewTextBoxColumn
            // 
            this.purchasepriceDataGridViewTextBoxColumn.DataPropertyName = "Purchase_price";
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.purchasepriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.purchasepriceDataGridViewTextBoxColumn.HeaderText = "Purchase_price";
            this.purchasepriceDataGridViewTextBoxColumn.Name = "purchasepriceDataGridViewTextBoxColumn";
            // 
            // mrpDataGridViewTextBoxColumn
            // 
            this.mrpDataGridViewTextBoxColumn.DataPropertyName = "Mrp";
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.mrpDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.mrpDataGridViewTextBoxColumn.HeaderText = "Mrp";
            this.mrpDataGridViewTextBoxColumn.Name = "mrpDataGridViewTextBoxColumn";
            // 
            // salesdiscountDataGridViewTextBoxColumn
            // 
            this.salesdiscountDataGridViewTextBoxColumn.DataPropertyName = "Sales_discount";
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            this.salesdiscountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.salesdiscountDataGridViewTextBoxColumn.HeaderText = "Sales_discount";
            this.salesdiscountDataGridViewTextBoxColumn.Name = "salesdiscountDataGridViewTextBoxColumn";
            // 
            // purchasediscountDataGridViewTextBoxColumn
            // 
            this.purchasediscountDataGridViewTextBoxColumn.DataPropertyName = "Purchase_discount";
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            this.purchasediscountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.purchasediscountDataGridViewTextBoxColumn.HeaderText = "Purchase_discount";
            this.purchasediscountDataGridViewTextBoxColumn.Name = "purchasediscountDataGridViewTextBoxColumn";
            // 
            // itemIdDataGridViewTextBoxColumn
            // 
            this.itemIdDataGridViewTextBoxColumn.DataPropertyName = "Item_Id";
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.itemIdDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.itemIdDataGridViewTextBoxColumn.HeaderText = "Item_Id";
            this.itemIdDataGridViewTextBoxColumn.Name = "itemIdDataGridViewTextBoxColumn";
            this.itemIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitDataGridViewTextBoxColumn
            // 
            this.unitDataGridViewTextBoxColumn.DataPropertyName = "Unit";
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            this.unitDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.unitDataGridViewTextBoxColumn.HeaderText = "Unit";
            this.unitDataGridViewTextBoxColumn.Name = "unitDataGridViewTextBoxColumn";
            // 
            // stockDataGridViewTextBoxColumn
            // 
            this.stockDataGridViewTextBoxColumn.DataPropertyName = "Stock";
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            this.stockDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.stockDataGridViewTextBoxColumn.HeaderText = "Stock";
            this.stockDataGridViewTextBoxColumn.Name = "stockDataGridViewTextBoxColumn";
            // 
            // salPricIncTaxDataGridViewTextBoxColumn
            // 
            this.salPricIncTaxDataGridViewTextBoxColumn.DataPropertyName = "SalPricInc_Tax";
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            this.salPricIncTaxDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.salPricIncTaxDataGridViewTextBoxColumn.HeaderText = "SalPricInc_Tax";
            this.salPricIncTaxDataGridViewTextBoxColumn.Name = "salPricIncTaxDataGridViewTextBoxColumn";
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataMember = "Item";
            this.itemBindingSource.DataSource = this._HI_TECHDataSet;
            // 
            // _HI_TECHDataSet
            // 
            this._HI_TECHDataSet.DataSetName = "_HI_TECHDataSet";
            this._HI_TECHDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemTableAdapter
            // 
            this.itemTableAdapter.ClearBeforeFill = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1169, 5);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1169, 5);
            this.panel3.TabIndex = 11;
            // 
            // itemmasterlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "itemmasterlist";
            this.Size = new System.Drawing.Size(1166, 671);
            this.Load += new System.EventHandler(this.itemmasterlist_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._HI_TECHDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private _HI_TECHDataSet _HI_TECHDataSet;
        private _HI_TECHDataSetTableAdapters.ItemTableAdapter itemTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendornameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemgroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxcatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsncodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salepriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasepriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mrpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesdiscountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasediscountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salPricIncTaxDataGridViewTextBoxColumn;
    }
}
