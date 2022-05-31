namespace EierfarmWinFormsUi
{
    partial class frmEierfarm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNeuesHuhn = new System.Windows.Forms.Button();
            this.btnNeueGans = new System.Windows.Forms.Button();
            this.btnFuettern = new System.Windows.Forms.Button();
            this.btnEiLegen = new System.Windows.Forms.Button();
            this.cbxTiere = new System.Windows.Forms.ComboBox();
            this.pgdTier = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // btnNeuesHuhn
            // 
            this.btnNeuesHuhn.Location = new System.Drawing.Point(503, 35);
            this.btnNeuesHuhn.Name = "btnNeuesHuhn";
            this.btnNeuesHuhn.Size = new System.Drawing.Size(188, 58);
            this.btnNeuesHuhn.TabIndex = 0;
            this.btnNeuesHuhn.Text = "Huhn";
            this.btnNeuesHuhn.UseVisualStyleBackColor = true;
            this.btnNeuesHuhn.Click += new System.EventHandler(this.btnNeuesHuhn_Click);
            // 
            // btnNeueGans
            // 
            this.btnNeueGans.Location = new System.Drawing.Point(503, 99);
            this.btnNeueGans.Name = "btnNeueGans";
            this.btnNeueGans.Size = new System.Drawing.Size(188, 58);
            this.btnNeueGans.TabIndex = 1;
            this.btnNeueGans.Text = "Gans";
            this.btnNeueGans.UseVisualStyleBackColor = true;
            this.btnNeueGans.Click += new System.EventHandler(this.btnNeueGans_Click);
            // 
            // btnFuettern
            // 
            this.btnFuettern.Location = new System.Drawing.Point(503, 451);
            this.btnFuettern.Name = "btnFuettern";
            this.btnFuettern.Size = new System.Drawing.Size(188, 58);
            this.btnFuettern.TabIndex = 2;
            this.btnFuettern.Text = "Füttern";
            this.btnFuettern.UseVisualStyleBackColor = true;
            this.btnFuettern.Click += new System.EventHandler(this.btnFuettern_Click);
            // 
            // btnEiLegen
            // 
            this.btnEiLegen.Location = new System.Drawing.Point(503, 515);
            this.btnEiLegen.Name = "btnEiLegen";
            this.btnEiLegen.Size = new System.Drawing.Size(188, 58);
            this.btnEiLegen.TabIndex = 3;
            this.btnEiLegen.Text = "Ei legen";
            this.btnEiLegen.UseVisualStyleBackColor = true;
            this.btnEiLegen.Click += new System.EventHandler(this.btnEiLegen_Click);
            // 
            // cbxTiere
            // 
            this.cbxTiere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTiere.FormattingEnabled = true;
            this.cbxTiere.Location = new System.Drawing.Point(106, 41);
            this.cbxTiere.Name = "cbxTiere";
            this.cbxTiere.Size = new System.Drawing.Size(374, 49);
            this.cbxTiere.TabIndex = 4;
            this.cbxTiere.SelectedIndexChanged += new System.EventHandler(this.cbxTiere_SelectedIndexChanged);
            // 
            // pgdTier
            // 
            this.pgdTier.HelpVisible = false;
            this.pgdTier.Location = new System.Drawing.Point(106, 99);
            this.pgdTier.Name = "pgdTier";
            this.pgdTier.Size = new System.Drawing.Size(374, 473);
            this.pgdTier.TabIndex = 5;
            // 
            // frmEierfarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 636);
            this.Controls.Add(this.pgdTier);
            this.Controls.Add(this.cbxTiere);
            this.Controls.Add(this.btnEiLegen);
            this.Controls.Add(this.btnFuettern);
            this.Controls.Add(this.btnNeueGans);
            this.Controls.Add(this.btnNeuesHuhn);
            this.Name = "frmEierfarm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnNeuesHuhn;
        private Button btnNeueGans;
        private Button btnFuettern;
        private Button btnEiLegen;
        private ComboBox cbxTiere;
        private PropertyGrid pgdTier;
    }
}