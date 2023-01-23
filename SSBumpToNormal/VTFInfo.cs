using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSBumpToNormal {
	public partial class VTFInfoDialogue : Form {
		public VTFInfo VTFInfo { get; private set; }

		public VTFInfoDialogue() {
			InitializeComponent();
			CbVersion.SelectedIndex = 0;
			DialogResult = DialogResult.Cancel;
		}

		private void BtnOk_Click(object sender, EventArgs e) {
			VTFInfo = new VTFInfo {
				Version = CbVersion.SelectedIndex switch {
					1 => new Version(7, 3),
					2 => new Version(7, 4),
					3 => new Version(7, 5),
					_ => new Version(7, 2),
				},
				Compressed = CbCompression.Checked,
				HasAlpha = CbAlpha.Checked,
			};

			DialogResult = DialogResult.OK;
			Close();
		}
		private void BtnCancel_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
