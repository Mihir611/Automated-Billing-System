namespace Hi_Tech
{
    partial class supoutlistalllitem
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.salesTestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._HI_TECHDataSet4 = new Hi_Tech._HI_TECHDataSet4();
            this.salesTestTableAdapter = new Hi_Tech._HI_TECHDataSet4TableAdapters.SalesTestTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesTestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._HI_TECHDataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(12, 93);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(1119, 425);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.Visible = false;
            // 
            // salesTestBindingSource
            // 
            this.salesTestBindingSource.DataMember = "SalesTest";
            this.salesTestBindingSource.DataSource = this._HI_TECHDataSet4;
            // 
            // _HI_TECHDataSet4
            // 
            this._HI_TECHDataSet4.DataSetName = "_HI_TECHDataSet4";
            this._HI_TECHDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // salesTestTableAdapter
            // 
            this.salesTestTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(82, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // supoutlistalllitem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Name = "supoutlistalllitem";
            this.Size = new System.Drawing.Size(1166, 671);
            this.Load += new System.EventHandler(this.supoutlistalllitem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesTestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._HI_TECHDataSet4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource salesTestBindingSource;
        private _HI_TECHDataSet4 _HI_TECHDataSet4;
        private _HI_TECHDataSet4TableAdapters.SalesTestTableAdapter salesTestTableAdapter;
        private System.Windows.Forms.Label label1;
    }
}
