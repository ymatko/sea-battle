namespace SeaBattle.View
{
    partial class StartForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TbLogin = new System.Windows.Forms.TextBox();
            this.BtnCont = new System.Windows.Forms.Button();
            this.BtnHG = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnCont);
            this.groupBox1.Controls.Add(this.TbLogin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect To game";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // TbLogin
            // 
            this.TbLogin.Location = new System.Drawing.Point(43, 34);
            this.TbLogin.Name = "TbLogin";
            this.TbLogin.Size = new System.Drawing.Size(184, 20);
            this.TbLogin.TabIndex = 1;
            // 
            // BtnCont
            // 
            this.BtnCont.Location = new System.Drawing.Point(233, 34);
            this.BtnCont.Name = "BtnCont";
            this.BtnCont.Size = new System.Drawing.Size(75, 20);
            this.BtnCont.TabIndex = 2;
            this.BtnCont.Text = "Connect";
            this.BtnCont.UseVisualStyleBackColor = true;
            this.BtnCont.Click += new System.EventHandler(this.BtnCont_Click);
            // 
            // BtnHG
            // 
            this.BtnHG.Location = new System.Drawing.Point(10, 107);
            this.BtnHG.Name = "BtnHG";
            this.BtnHG.Size = new System.Drawing.Size(316, 28);
            this.BtnHG.TabIndex = 1;
            this.BtnHG.Text = "Host Game";
            this.BtnHG.UseVisualStyleBackColor = true;
            this.BtnHG.Click += new System.EventHandler(this.BtnHG_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 143);
            this.Controls.Add(this.BtnHG);
            this.Controls.Add(this.groupBox1);
            this.Name = "StartForm";
            this.Text = "Login";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnCont;
        private System.Windows.Forms.TextBox TbLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnHG;
    }
}

