namespace Emlak
{
    partial class Kayit
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
            this.textBox_sifre = new System.Windows.Forms.TextBox();
            this.textBox_kullanici_adi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_kayit = new System.Windows.Forms.Button();
            this.checkBox_yetkilendirme = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox_sifre
            // 
            this.textBox_sifre.Location = new System.Drawing.Point(188, 69);
            this.textBox_sifre.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_sifre.Name = "textBox_sifre";
            this.textBox_sifre.PasswordChar = '*';
            this.textBox_sifre.Size = new System.Drawing.Size(276, 22);
            this.textBox_sifre.TabIndex = 2;
            this.textBox_sifre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_kullanici_adi
            // 
            this.textBox_kullanici_adi.Location = new System.Drawing.Point(188, 30);
            this.textBox_kullanici_adi.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_kullanici_adi.Name = "textBox_kullanici_adi";
            this.textBox_kullanici_adi.Size = new System.Drawing.Size(276, 22);
            this.textBox_kullanici_adi.TabIndex = 1;
            this.textBox_kullanici_adi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(116, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Şifre :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(55, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kullanıcı Adı :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_kayit
            // 
            this.button_kayit.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_kayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_kayit.ForeColor = System.Drawing.Color.GhostWhite;
            this.button_kayit.Location = new System.Drawing.Point(16, 164);
            this.button_kayit.Margin = new System.Windows.Forms.Padding(4);
            this.button_kayit.Name = "button_kayit";
            this.button_kayit.Size = new System.Drawing.Size(500, 82);
            this.button_kayit.TabIndex = 4;
            this.button_kayit.Text = "Kayıt";
            this.button_kayit.UseVisualStyleBackColor = false;
            this.button_kayit.Click += new System.EventHandler(this.button_kayit_Click);
            // 
            // checkBox_yetkilendirme
            // 
            this.checkBox_yetkilendirme.AutoSize = true;
            this.checkBox_yetkilendirme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox_yetkilendirme.ForeColor = System.Drawing.Color.Teal;
            this.checkBox_yetkilendirme.Location = new System.Drawing.Point(345, 121);
            this.checkBox_yetkilendirme.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_yetkilendirme.Name = "checkBox_yetkilendirme";
            this.checkBox_yetkilendirme.Size = new System.Drawing.Size(119, 24);
            this.checkBox_yetkilendirme.TabIndex = 3;
            this.checkBox_yetkilendirme.Text = "Yetkilendir";
            this.checkBox_yetkilendirme.UseVisualStyleBackColor = true;
            // 
            // Kayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(532, 262);
            this.Controls.Add(this.checkBox_yetkilendirme);
            this.Controls.Add(this.button_kayit);
            this.Controls.Add(this.textBox_sifre);
            this.Controls.Add(this.textBox_kullanici_adi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Kayit";
            this.Text = "Kayit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Kayit_FormClosing);
            this.Load += new System.EventHandler(this.Kayit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_sifre;
        private System.Windows.Forms.TextBox textBox_kullanici_adi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_kayit;
        private System.Windows.Forms.CheckBox checkBox_yetkilendirme;
    }
}