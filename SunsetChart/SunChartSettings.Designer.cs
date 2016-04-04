namespace SunsetChart
{
    partial class SunChartSettings
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.currentDayColorButton = new System.Windows.Forms.Button();
            this.currentHourColorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(197, 226);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Speichern";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            // 
            // currentDayColorButton
            // 
            this.currentDayColorButton.Location = new System.Drawing.Point(36, 49);
            this.currentDayColorButton.Name = "currentDayColorButton";
            this.currentDayColorButton.Size = new System.Drawing.Size(107, 23);
            this.currentDayColorButton.TabIndex = 1;
            this.currentDayColorButton.Text = "Aktueller Tag";
            this.currentDayColorButton.UseVisualStyleBackColor = true;
            this.currentDayColorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // currentHourColorButton
            // 
            this.currentHourColorButton.Location = new System.Drawing.Point(36, 89);
            this.currentHourColorButton.Name = "currentHourColorButton";
            this.currentHourColorButton.Size = new System.Drawing.Size(107, 23);
            this.currentHourColorButton.TabIndex = 2;
            this.currentHourColorButton.Text = "Aktuelle Stunde";
            this.currentHourColorButton.UseVisualStyleBackColor = true;
            this.currentHourColorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // SunChartSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.currentHourColorButton);
            this.Controls.Add(this.currentDayColorButton);
            this.Controls.Add(this.buttonSave);
            this.Name = "SunChartSettings";
            this.Text = "SunChartSettings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button currentDayColorButton;
        private System.Windows.Forms.Button currentHourColorButton;
    }
}