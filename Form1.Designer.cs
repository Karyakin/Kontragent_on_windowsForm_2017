namespace WindowsFormsApp3
{
    partial class Autorization
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Autorization));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Lable_Login = new System.Windows.Forms.Label();
            this.Lable_Passward = new System.Windows.Forms.Label();
            this.button1_Регистрация = new System.Windows.Forms.Button();
            this.button2_Выход = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Login = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3_Вход = new System.Windows.Forms.Button();
            this.Kontragent_Lable = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Lable_Login
            // 
            this.Lable_Login.AutoSize = true;
            this.Lable_Login.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lable_Login.Location = new System.Drawing.Point(18, 158);
            this.Lable_Login.Name = "Lable_Login";
            this.Lable_Login.Size = new System.Drawing.Size(52, 19);
            this.Lable_Login.TabIndex = 1;
            this.Lable_Login.Text = "Логин";
            // 
            // Lable_Passward
            // 
            this.Lable_Passward.AutoSize = true;
            this.Lable_Passward.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lable_Passward.Location = new System.Drawing.Point(10, 195);
            this.Lable_Passward.Name = "Lable_Passward";
            this.Lable_Passward.Size = new System.Drawing.Size(60, 19);
            this.Lable_Passward.TabIndex = 2;
            this.Lable_Passward.Text = "Пароль";
            // 
            // button1_Регистрация
            // 
            this.button1_Регистрация.BackColor = System.Drawing.Color.White;
            this.button1_Регистрация.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1_Регистрация.ForeColor = System.Drawing.Color.Green;
            this.button1_Регистрация.Location = new System.Drawing.Point(10, 232);
            this.button1_Регистрация.Name = "button1_Регистрация";
            this.button1_Регистрация.Size = new System.Drawing.Size(115, 23);
            this.button1_Регистрация.TabIndex = 3;
            this.button1_Регистрация.Text = "Регистрация";
            this.button1_Регистрация.UseVisualStyleBackColor = false;
            this.button1_Регистрация.Click += new System.EventHandler(this.Button1_Регистрация_Click);
            // 
            // button2_Выход
            // 
            this.button2_Выход.BackColor = System.Drawing.Color.White;
            this.button2_Выход.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2_Выход.Location = new System.Drawing.Point(210, 232);
            this.button2_Выход.Name = "button2_Выход";
            this.button2_Выход.Size = new System.Drawing.Size(115, 23);
            this.button2_Выход.TabIndex = 4;
            this.button2_Выход.Text = "ВЫХОД";
            this.button2_Выход.UseVisualStyleBackColor = false;
            this.button2_Выход.Click += new System.EventHandler(this.Button2_Выход_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(93, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Введите данные для входа в личный кабинет.";
            // 
            // textBox_Login
            // 
            this.textBox_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Login.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBox_Login.Location = new System.Drawing.Point(96, 159);
            this.textBox_Login.Name = "textBox_Login";
            this.textBox_Login.Size = new System.Drawing.Size(229, 20);
            this.textBox_Login.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBox2.Location = new System.Drawing.Point(96, 196);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(229, 22);
            this.textBox2.TabIndex = 7;
            this.textBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // button3_Вход
            // 
            this.button3_Вход.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button3_Вход.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3_Вход.ForeColor = System.Drawing.Color.White;
            this.button3_Вход.Location = new System.Drawing.Point(90, 264);
            this.button3_Вход.Name = "button3_Вход";
            this.button3_Вход.Size = new System.Drawing.Size(186, 23);
            this.button3_Вход.TabIndex = 8;
            this.button3_Вход.Text = "Вход";
            this.button3_Вход.UseVisualStyleBackColor = false;
            this.button3_Вход.Click += new System.EventHandler(this.Button3_Вход_Click);
            // 
            // Kontragent_Lable
            // 
            this.Kontragent_Lable.AutoSize = true;
            this.Kontragent_Lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Kontragent_Lable.ForeColor = System.Drawing.Color.Green;
            this.Kontragent_Lable.Location = new System.Drawing.Point(85, 80);
            this.Kontragent_Lable.Name = "Kontragent_Lable";
            this.Kontragent_Lable.Size = new System.Drawing.Size(191, 25);
            this.Kontragent_Lable.TabIndex = 9;
            this.Kontragent_Lable.Text = "ИС \"Контрагент\"";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(93, 142);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(91, 13);
            this.label28.TabIndex = 95;
            this.label28.Text = "Заполните поле!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(93, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "Заполните поле!";
            // 
            // Autorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(348, 299);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.Kontragent_Lable);
            this.Controls.Add(this.button3_Вход);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox_Login);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2_Выход);
            this.Controls.Add(this.button1_Регистрация);
            this.Controls.Add(this.Lable_Passward);
            this.Controls.Add(this.Lable_Login);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Autorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Lable_Login;
        private System.Windows.Forms.Label Lable_Passward;
        private System.Windows.Forms.Button button1_Регистрация;
        private System.Windows.Forms.Button button2_Выход;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Login;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3_Вход;
        private System.Windows.Forms.Label Kontragent_Lable;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label1;
    }
}

