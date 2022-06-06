
namespace OFDF3TailControlGUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbReadOFD = new System.Windows.Forms.CheckBox();
            this.cbReadF3tail = new System.Windows.Forms.CheckBox();
            this.cbAnalize = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbReadOFD
            // 
            this.cbReadOFD.AutoSize = true;
            this.cbReadOFD.Enabled = false;
            this.cbReadOFD.Location = new System.Drawing.Point(14, 21);
            this.cbReadOFD.Name = "cbReadOFD";
            this.cbReadOFD.Size = new System.Drawing.Size(134, 17);
            this.cbReadOFD.TabIndex = 1;
            this.cbReadOFD.Text = "Прочитан файл ОФД";
            this.cbReadOFD.UseVisualStyleBackColor = true;
            // 
            // cbReadF3tail
            // 
            this.cbReadF3tail.AutoSize = true;
            this.cbReadF3tail.Enabled = false;
            this.cbReadF3tail.Location = new System.Drawing.Point(14, 45);
            this.cbReadF3tail.Name = "cbReadF3tail";
            this.cbReadF3tail.Size = new System.Drawing.Size(155, 17);
            this.cbReadF3tail.TabIndex = 2;
            this.cbReadF3tail.Text = "Прочитаны данные F3Tail";
            this.cbReadF3tail.UseVisualStyleBackColor = true;
            // 
            // cbAnalize
            // 
            this.cbAnalize.AutoSize = true;
            this.cbAnalize.Enabled = false;
            this.cbAnalize.Location = new System.Drawing.Point(14, 69);
            this.cbAnalize.Name = "cbAnalize";
            this.cbAnalize.Size = new System.Drawing.Size(95, 17);
            this.cbAnalize.TabIndex = 3;
            this.cbAnalize.Text = "Анализ чеков";
            this.cbAnalize.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(14, 220);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(461, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(461, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Обработать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Статус обработки";
            // 
            // tbFile
            // 
            this.tbFile.Location = new System.Drawing.Point(14, 143);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(461, 20);
            this.tbFile.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Файлы Excel|*.xlsx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Имя файла с выгрузкой";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(506, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cbAnalize);
            this.Controls.Add(this.cbReadF3tail);
            this.Controls.Add(this.cbReadOFD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Проверка чеков PLATFORMAOFD и F3Tail";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupBox1_DragDrop);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cbReadOFD;
        private System.Windows.Forms.CheckBox cbReadF3tail;
        private System.Windows.Forms.CheckBox cbAnalize;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
    }
}

