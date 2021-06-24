
namespace Inertia__new_
{
    partial class Menu
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
            this.information = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.headline = new System.Windows.Forms.Label();
            this.rules = new System.Windows.Forms.Button();
            this.fon = new System.Windows.Forms.PictureBox();
            this.level1 = new System.Windows.Forms.Button();
            this.level2 = new System.Windows.Forms.Button();
            this.level3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fon)).BeginInit();
            this.SuspendLayout();
            // 
            // information
            // 
            this.information.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.information.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.information.Location = new System.Drawing.Point(1014, 621);
            this.information.Name = "information";
            this.information.Size = new System.Drawing.Size(176, 60);
            this.information.TabIndex = 0;
            this.information.Text = "Сведения";
            this.information.UseVisualStyleBackColor = false;
            this.information.MouseLeave += new System.EventHandler(this.Information_MouseLeave);
            this.information.MouseHover += new System.EventHandler(this.Information_Hover);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.SystemColors.GrayText;
            this.start.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.start.Location = new System.Drawing.Point(1014, 230);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(176, 60);
            this.start.TabIndex = 1;
            this.start.Text = "Начать";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // headline
            // 
            this.headline.BackColor = System.Drawing.SystemColors.Menu;
            this.headline.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headline.Location = new System.Drawing.Point(438, 19);
            this.headline.Name = "headline";
            this.headline.Size = new System.Drawing.Size(526, 41);
            this.headline.TabIndex = 2;
            this.headline.Text = "Добро пожаловать в игру \"Инерция!\"";
            this.headline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rules
            // 
            this.rules.BackColor = System.Drawing.SystemColors.Info;
            this.rules.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rules.Location = new System.Drawing.Point(1014, 391);
            this.rules.Name = "rules";
            this.rules.Size = new System.Drawing.Size(176, 60);
            this.rules.TabIndex = 3;
            this.rules.Text = "Правила игры";
            this.rules.UseVisualStyleBackColor = false;
            this.rules.MouseLeave += new System.EventHandler(this.Rules_MouseLeave);
            this.rules.MouseHover += new System.EventHandler(this.Rules_Hover);
            // 
            // fon
            // 
            this.fon.Image = global::Inertia__new_.Properties.Resources.minion;
            this.fon.Location = new System.Drawing.Point(40, 77);
            this.fon.Name = "fon";
            this.fon.Size = new System.Drawing.Size(855, 839);
            this.fon.TabIndex = 4;
            this.fon.TabStop = false;
            // 
            // level1
            // 
            this.level1.AutoSize = true;
            this.level1.BackColor = System.Drawing.SystemColors.Highlight;
            this.level1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.level1.Location = new System.Drawing.Point(1235, 122);
            this.level1.Name = "level1";
            this.level1.Size = new System.Drawing.Size(178, 58);
            this.level1.TabIndex = 5;
            this.level1.Text = "Уровень 1";
            this.level1.UseVisualStyleBackColor = false;
            this.level1.Visible = false;
            this.level1.Click += new System.EventHandler(this.level1_Click);
            // 
            // level2
            // 
            this.level2.AutoSize = true;
            this.level2.BackColor = System.Drawing.SystemColors.Highlight;
            this.level2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.level2.Location = new System.Drawing.Point(1235, 232);
            this.level2.Name = "level2";
            this.level2.Size = new System.Drawing.Size(178, 58);
            this.level2.TabIndex = 6;
            this.level2.Text = "Уровень 2";
            this.level2.UseVisualStyleBackColor = false;
            this.level2.Visible = false;
            this.level2.Click += new System.EventHandler(this.level2_Click);
            // 
            // level3
            // 
            this.level3.AutoSize = true;
            this.level3.BackColor = System.Drawing.SystemColors.Highlight;
            this.level3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.level3.Location = new System.Drawing.Point(1235, 339);
            this.level3.Name = "level3";
            this.level3.Size = new System.Drawing.Size(178, 58);
            this.level3.TabIndex = 7;
            this.level3.Text = "Уровень 3";
            this.level3.UseVisualStyleBackColor = false;
            this.level3.Visible = false;
            this.level3.Click += new System.EventHandler(this.level3_Click);
            // 
            // Menu
            // 
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1447, 866);
            this.Controls.Add(this.level3);
            this.Controls.Add(this.level2);
            this.Controls.Add(this.level1);
            this.Controls.Add(this.fon);
            this.Controls.Add(this.rules);
            this.Controls.Add(this.headline);
            this.Controls.Add(this.start);
            this.Controls.Add(this.information);
            this.Name = "Menu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.fon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button information;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label headline;
        private System.Windows.Forms.Button rules;
        private System.Windows.Forms.PictureBox fon;
        private System.Windows.Forms.Button level1;
        private System.Windows.Forms.Button level2;
        private System.Windows.Forms.Button level3;
    }
}

