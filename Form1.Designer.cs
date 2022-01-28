
namespace esthar_practice
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_go = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.num_stepId = new System.Windows.Forms.NumericUpDown();
            this.num_fraction = new System.Windows.Forms.NumericUpDown();
            this.num_totalEnc = new System.Windows.Forms.NumericUpDown();
            this.num_danger = new System.Windows.Forms.NumericUpDown();
            this.num_offset = new System.Windows.Forms.NumericUpDown();
            this.num_lastEnc = new System.Windows.Forms.NumericUpDown();
            this.drop_saved = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_del_config = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_stepId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fraction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_totalEnc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_danger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_offset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_lastEnc)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Step ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Step Fraction";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Total Encounters";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Danger Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Offset";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Prev Enc ID";
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(9, 116);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(273, 23);
            this.btn_go.TabIndex = 7;
            this.btn_go.Text = "Go (F6)";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.Btn_Go_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.Location = new System.Drawing.Point(12, 142);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(273, 17);
            this.lbl_status.TabIndex = 8;
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_status.Click += new System.EventHandler(this.Lbl_Status_Click);
            // 
            // num_stepId
            // 
            this.num_stepId.Location = new System.Drawing.Point(100, 39);
            this.num_stepId.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_stepId.Name = "num_stepId";
            this.num_stepId.Size = new System.Drawing.Size(49, 20);
            this.num_stepId.TabIndex = 1;
            this.num_stepId.Value = new decimal(new int[] {
            29,
            0,
            0,
            0});
            // 
            // num_fraction
            // 
            this.num_fraction.Location = new System.Drawing.Point(100, 65);
            this.num_fraction.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_fraction.Name = "num_fraction";
            this.num_fraction.Size = new System.Drawing.Size(49, 20);
            this.num_fraction.TabIndex = 3;
            // 
            // num_totalEnc
            // 
            this.num_totalEnc.Location = new System.Drawing.Point(100, 90);
            this.num_totalEnc.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_totalEnc.Name = "num_totalEnc";
            this.num_totalEnc.Size = new System.Drawing.Size(49, 20);
            this.num_totalEnc.TabIndex = 5;
            this.num_totalEnc.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // num_danger
            // 
            this.num_danger.Location = new System.Drawing.Point(233, 39);
            this.num_danger.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_danger.Name = "num_danger";
            this.num_danger.Size = new System.Drawing.Size(49, 20);
            this.num_danger.TabIndex = 2;
            this.num_danger.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // num_offset
            // 
            this.num_offset.Location = new System.Drawing.Point(233, 65);
            this.num_offset.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_offset.Name = "num_offset";
            this.num_offset.Size = new System.Drawing.Size(49, 20);
            this.num_offset.TabIndex = 4;
            this.num_offset.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // num_lastEnc
            // 
            this.num_lastEnc.Location = new System.Drawing.Point(233, 90);
            this.num_lastEnc.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_lastEnc.Name = "num_lastEnc";
            this.num_lastEnc.Size = new System.Drawing.Size(49, 20);
            this.num_lastEnc.TabIndex = 6;
            // 
            // drop_saved
            // 
            this.drop_saved.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drop_saved.FormattingEnabled = true;
            this.drop_saved.Location = new System.Drawing.Point(12, 12);
            this.drop_saved.Name = "drop_saved";
            this.drop_saved.Size = new System.Drawing.Size(146, 21);
            this.drop_saved.TabIndex = 15;
            this.drop_saved.SelectedIndexChanged += new System.EventHandler(this.drop_saved_SelectedIndexChanged);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(164, 10);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(56, 23);
            this.btn_save.TabIndex = 16;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_del_config
            // 
            this.btn_del_config.Location = new System.Drawing.Point(226, 10);
            this.btn_del_config.Name = "btn_del_config";
            this.btn_del_config.Size = new System.Drawing.Size(56, 23);
            this.btn_del_config.TabIndex = 17;
            this.btn_del_config.Text = "Delete";
            this.btn_del_config.UseVisualStyleBackColor = true;
            this.btn_del_config.Click += new System.EventHandler(this.btn_del_config_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 161);
            this.Controls.Add(this.btn_del_config);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.drop_saved);
            this.Controls.Add(this.num_lastEnc);
            this.Controls.Add(this.num_offset);
            this.Controls.Add(this.num_danger);
            this.Controls.Add(this.num_totalEnc);
            this.Controls.Add(this.num_fraction);
            this.Controls.Add(this.num_stepId);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.btn_go);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(310, 200);
            this.MinimumSize = new System.Drawing.Size(310, 200);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FF8 Esthar Practice";
            ((System.ComponentModel.ISupportInitialize)(this.num_stepId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fraction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_totalEnc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_danger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_offset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_lastEnc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.NumericUpDown num_stepId;
        private System.Windows.Forms.NumericUpDown num_fraction;
        private System.Windows.Forms.NumericUpDown num_totalEnc;
        private System.Windows.Forms.NumericUpDown num_danger;
        private System.Windows.Forms.NumericUpDown num_offset;
        private System.Windows.Forms.NumericUpDown num_lastEnc;
        private System.Windows.Forms.ComboBox drop_saved;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_del_config;
    }
}

