
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
            this.txt_stepId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_stepFraction = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_totalEncounters = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_dangerValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_offset = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_prevEncId = new System.Windows.Forms.TextBox();
            this.btn_go = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_stepId
            // 
            this.txt_stepId.Location = new System.Drawing.Point(106, 6);
            this.txt_stepId.Name = "txt_stepId";
            this.txt_stepId.Size = new System.Drawing.Size(49, 20);
            this.txt_stepId.TabIndex = 3;
            this.txt_stepId.Text = "29";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Step ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Step Fraction";
            // 
            // txt_stepFraction
            // 
            this.txt_stepFraction.Location = new System.Drawing.Point(106, 32);
            this.txt_stepFraction.Name = "txt_stepFraction";
            this.txt_stepFraction.Size = new System.Drawing.Size(49, 20);
            this.txt_stepFraction.TabIndex = 5;
            this.txt_stepFraction.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Total Encounters";
            // 
            // txt_totalEncounters
            // 
            this.txt_totalEncounters.Location = new System.Drawing.Point(106, 58);
            this.txt_totalEncounters.Name = "txt_totalEncounters";
            this.txt_totalEncounters.Size = new System.Drawing.Size(49, 20);
            this.txt_totalEncounters.TabIndex = 7;
            this.txt_totalEncounters.Text = "22";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Danger Value";
            // 
            // txt_dangerValue
            // 
            this.txt_dangerValue.Location = new System.Drawing.Point(239, 6);
            this.txt_dangerValue.Name = "txt_dangerValue";
            this.txt_dangerValue.Size = new System.Drawing.Size(49, 20);
            this.txt_dangerValue.TabIndex = 9;
            this.txt_dangerValue.Text = "80";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(161, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Offset";
            // 
            // txt_offset
            // 
            this.txt_offset.Location = new System.Drawing.Point(239, 32);
            this.txt_offset.Name = "txt_offset";
            this.txt_offset.Size = new System.Drawing.Size(49, 20);
            this.txt_offset.TabIndex = 11;
            this.txt_offset.Text = "13";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(161, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Prev Enc ID";
            // 
            // txt_prevEncId
            // 
            this.txt_prevEncId.Location = new System.Drawing.Point(239, 58);
            this.txt_prevEncId.Name = "txt_prevEncId";
            this.txt_prevEncId.Size = new System.Drawing.Size(49, 20);
            this.txt_prevEncId.TabIndex = 13;
            this.txt_prevEncId.Text = "0";
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(15, 84);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(273, 23);
            this.btn_go.TabIndex = 15;
            this.btn_go.Text = "Go";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.Btn_Go_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.Location = new System.Drawing.Point(15, 110);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(273, 17);
            this.lbl_status.TabIndex = 16;
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 136);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.btn_go);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_prevEncId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_offset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_dangerValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_totalEncounters);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_stepFraction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_stepId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 175);
            this.MinimumSize = new System.Drawing.Size(320, 175);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FF8 Esthar Practice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_stepId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_stepFraction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_totalEncounters;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_dangerValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_offset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_prevEncId;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.Label lbl_status;
    }
}

