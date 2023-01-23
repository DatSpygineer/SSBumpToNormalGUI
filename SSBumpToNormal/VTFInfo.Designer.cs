namespace SSBumpToNormal {
	partial class VTFInfoDialogue {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.BtnOk = new System.Windows.Forms.Button();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.CbCompression = new System.Windows.Forms.CheckBox();
			this.CbAlpha = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.CbVersion = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// BtnOk
			// 
			this.BtnOk.Location = new System.Drawing.Point(12, 129);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.Size = new System.Drawing.Size(75, 23);
			this.BtnOk.TabIndex = 0;
			this.BtnOk.Text = "Ok";
			this.BtnOk.UseVisualStyleBackColor = true;
			this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// BtnCancel
			// 
			this.BtnCancel.Location = new System.Drawing.Point(93, 129);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(75, 23);
			this.BtnCancel.TabIndex = 1;
			this.BtnCancel.Text = "Cancel";
			this.BtnCancel.UseVisualStyleBackColor = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// CbCompression
			// 
			this.CbCompression.AutoSize = true;
			this.CbCompression.Location = new System.Drawing.Point(12, 56);
			this.CbCompression.Name = "CbCompression";
			this.CbCompression.Size = new System.Drawing.Size(119, 19);
			this.CbCompression.TabIndex = 2;
			this.CbCompression.Text = "Compress texture";
			this.CbCompression.UseVisualStyleBackColor = true;
			// 
			// CbAlpha
			// 
			this.CbAlpha.AutoSize = true;
			this.CbAlpha.Location = new System.Drawing.Point(12, 81);
			this.CbAlpha.Name = "CbAlpha";
			this.CbAlpha.Size = new System.Drawing.Size(78, 19);
			this.CbAlpha.TabIndex = 3;
			this.CbAlpha.Text = "Has alpha";
			this.CbAlpha.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Version:";
			// 
			// CbVersion
			// 
			this.CbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CbVersion.FormattingEnabled = true;
			this.CbVersion.Items.AddRange(new object[] {
            "7.2",
            "7.3",
            "7.4",
            "7.5"});
			this.CbVersion.Location = new System.Drawing.Point(12, 27);
			this.CbVersion.Name = "CbVersion";
			this.CbVersion.Size = new System.Drawing.Size(119, 23);
			this.CbVersion.TabIndex = 5;
			// 
			// VTFInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(301, 161);
			this.Controls.Add(this.CbVersion);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.CbAlpha);
			this.Controls.Add(this.CbCompression);
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.BtnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "VTFInfo";
			this.Text = "VTF Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button BtnOk;
		private Button BtnCancel;
		private CheckBox CbCompression;
		private CheckBox CbAlpha;
		private Label label1;
		private ComboBox CbVersion;
	}
}