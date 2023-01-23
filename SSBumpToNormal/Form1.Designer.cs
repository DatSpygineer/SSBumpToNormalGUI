namespace SSBumpToNormal {
	partial class Form1 {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.label1 = new System.Windows.Forms.Label();
			this.BtnAdd = new System.Windows.Forms.Button();
			this.LstInputPaths = new System.Windows.Forms.ListBox();
			this.BtnRemove = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.CbFormats = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Input textures:";
			// 
			// BtnAdd
			// 
			this.BtnAdd.Location = new System.Drawing.Point(347, 234);
			this.BtnAdd.Name = "BtnAdd";
			this.BtnAdd.Size = new System.Drawing.Size(75, 23);
			this.BtnAdd.TabIndex = 2;
			this.BtnAdd.Text = "Add file";
			this.BtnAdd.UseVisualStyleBackColor = true;
			this.BtnAdd.Click += new System.EventHandler(this.OnAddClicked);
			// 
			// LstInputPaths
			// 
			this.LstInputPaths.AllowDrop = true;
			this.LstInputPaths.FormattingEnabled = true;
			this.LstInputPaths.ItemHeight = 15;
			this.LstInputPaths.Location = new System.Drawing.Point(12, 27);
			this.LstInputPaths.Name = "LstInputPaths";
			this.LstInputPaths.Size = new System.Drawing.Size(329, 259);
			this.LstInputPaths.TabIndex = 3;
			this.LstInputPaths.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListDragDrop);
			this.LstInputPaths.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListDragEnter);
			// 
			// BtnRemove
			// 
			this.BtnRemove.Location = new System.Drawing.Point(347, 263);
			this.BtnRemove.Name = "BtnRemove";
			this.BtnRemove.Size = new System.Drawing.Size(75, 23);
			this.BtnRemove.TabIndex = 4;
			this.BtnRemove.Text = "Remove";
			this.BtnRemove.UseVisualStyleBackColor = true;
			this.BtnRemove.Click += new System.EventHandler(this.OnRemoveClicked);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 292);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(121, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Convert textures!";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnConvertClicked);
			// 
			// CbFormats
			// 
			this.CbFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CbFormats.FormattingEnabled = true;
			this.CbFormats.Items.AddRange(new object[] {
            "PNG",
            "BMP",
            "TGA",
            "VTF"});
			this.CbFormats.Location = new System.Drawing.Point(347, 293);
			this.CbFormats.Name = "CbFormats";
			this.CbFormats.Size = new System.Drawing.Size(75, 23);
			this.CbFormats.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(254, 296);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 15);
			this.label2.TabIndex = 7;
			this.label2.Text = "Output format:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 326);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.CbFormats);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.BtnRemove);
			this.Controls.Add(this.LstInputPaths);
			this.Controls.Add(this.BtnAdd);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "SSBump to Normal map";
			this.Load += new System.EventHandler(this.FormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label label1;
		private Button BtnAdd;
		private ListBox LstInputPaths;
		private Button BtnRemove;
		private Button button1;
		private ComboBox CbFormats;
		private Label label2;
	}
}