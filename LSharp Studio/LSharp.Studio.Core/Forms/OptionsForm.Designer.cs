namespace LSharp.Studio.Core.Forms
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.DefaultSaveLocationTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dllRadioButton = new System.Windows.Forms.RadioButton();
            this.winFormsExeRadioButton = new System.Windows.Forms.RadioButton();
            this.exeRadioButton = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DefaultSaveLocationTextBox
            // 
            this.DefaultSaveLocationTextBox.Location = new System.Drawing.Point(135, 6);
            this.DefaultSaveLocationTextBox.Name = "DefaultSaveLocationTextBox";
            this.DefaultSaveLocationTextBox.Size = new System.Drawing.Size(447, 20);
            this.DefaultSaveLocationTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Default Save Location:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(437, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(507, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dllRadioButton);
            this.panel1.Controls.Add(this.winFormsExeRadioButton);
            this.panel1.Controls.Add(this.exeRadioButton);
            this.panel1.Location = new System.Drawing.Point(13, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Default Compile Type:";
            // 
            // dllRadioButton
            // 
            this.dllRadioButton.AutoSize = true;
            this.dllRadioButton.Location = new System.Drawing.Point(12, 68);
            this.dllRadioButton.Name = "dllRadioButton";
            this.dllRadioButton.Size = new System.Drawing.Size(37, 17);
            this.dllRadioButton.TabIndex = 2;
            this.dllRadioButton.TabStop = true;
            this.dllRadioButton.Text = "Dll";
            this.dllRadioButton.UseVisualStyleBackColor = true;
            // 
            // winFormsExeRadioButton
            // 
            this.winFormsExeRadioButton.AutoSize = true;
            this.winFormsExeRadioButton.Location = new System.Drawing.Point(12, 46);
            this.winFormsExeRadioButton.Name = "winFormsExeRadioButton";
            this.winFormsExeRadioButton.Size = new System.Drawing.Size(93, 17);
            this.winFormsExeRadioButton.TabIndex = 1;
            this.winFormsExeRadioButton.TabStop = true;
            this.winFormsExeRadioButton.Text = "WinForms Exe";
            this.winFormsExeRadioButton.UseVisualStyleBackColor = true;
            // 
            // exeRadioButton
            // 
            this.exeRadioButton.AutoSize = true;
            this.exeRadioButton.Location = new System.Drawing.Point(12, 23);
            this.exeRadioButton.Name = "exeRadioButton";
            this.exeRadioButton.Size = new System.Drawing.Size(43, 17);
            this.exeRadioButton.TabIndex = 0;
            this.exeRadioButton.TabStop = true;
            this.exeRadioButton.Text = "Exe";
            this.exeRadioButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(467, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Set Default Programs";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(594, 170);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DefaultSaveLocationTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.Text = "L# Studio - Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton dllRadioButton;
        private System.Windows.Forms.RadioButton winFormsExeRadioButton;
        private System.Windows.Forms.RadioButton exeRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;

        #endregion

        private System.Windows.Forms.TextBox DefaultSaveLocationTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;





    }
}