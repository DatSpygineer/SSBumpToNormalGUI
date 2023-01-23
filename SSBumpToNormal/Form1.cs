using Microsoft.WindowsAPICodePack.Dialogs;

namespace SSBumpToNormal {
	public partial class Form1 : Form {
		public static string[] SupportedFormats = new[] {
			".bmp", ".png", ".jpg", ".jpeg", ".gif", ".tif", ".tiff", ".vtf"
		};

		public Form1() {
			InitializeComponent();
			var items = Enum.GetValues(typeof(TextureFormat));
			foreach (var item in items) {
				CbFormats.Items.Add(item);
			}
		}

		private void FormLoad(object sender, EventArgs e) {
			CbFormats.SelectedIndex = 0;
		}

		private void ListDragEnter(object sender, DragEventArgs e) {
			if (e.Data!.GetDataPresent(DataFormats.FileDrop)) {
				e.Effect = DragDropEffects.All;
			} else {
				e.Effect = DragDropEffects.None;
			}
		}
		private void ListDragDrop(object sender, DragEventArgs e) {
			if (e.Data!.GetData(DataFormats.FileDrop, false) is string[] files) {
				foreach (var file in files) {
					// Validate extension
					if (SupportedFormats.Contains(Path.GetExtension(file).ToLower())) {
						LstInputPaths.Items.Add(file);
					} else {
						MessageBox.Show($"Failed to load file {file}: Unsupported format!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}
		}

		private void OnAddClicked(object sender, EventArgs e) {
			var ofd = new OpenFileDialog {
				Filter = "Supported formats (*.png,*.bmp,*.gif,*.jpg,*.tiff,*.tif)|*.png;*.bmp;*.gif;*.jpg;*.tiff;*.tif;*.vtf" +
				"|PNG image (*.png)|*.png" +
				"|Bitmap (*.bmp)|*.bmp" +
				"|Gif (*.gif)|*.gif" +
				"|Tiff (*.tiff, *.tif)|*.tiff;*.tif" +
				"|Value texture (*.vtf)|*.vtf" +
				"|All files (*.*)|*.*",
				Multiselect= true
			};

			if (ofd.ShowDialog() == DialogResult.OK) {
				LstInputPaths.Items.AddRange(ofd.FileNames);
			}
		}
		private void OnRemoveClicked(object sender, EventArgs e) {
			if (LstInputPaths.SelectedItems.Count > 0) {
				if (MessageBox.Show(
						"Would you like to remove selected item(s)?", 
						"Confirm removal", 
						MessageBoxButtons.YesNo, 
						MessageBoxIcon.Question
					) == DialogResult.Yes) {
					foreach (var item in LstInputPaths.SelectedItems) {
						LstInputPaths.Items.Remove(item);
					}
				}
			}
		}

		private void OnConvertClicked(object sender, EventArgs e) {
			// I'm lazy...
			try {
				if (LstInputPaths.Items.Count > 0) {
					var ofd = new CommonOpenFileDialog {
						IsFolderPicker = true
					};
					if (ofd.ShowDialog() == CommonFileDialogResult.Ok) {
						var basePath = ofd.FileName;
						var format = Enum.Parse<TextureFormat>(CbFormats.SelectedItem.ToString()!);
						VTFInfo? vtfInfo = null;

						if (format == TextureFormat.VTF) {
							var vtfInfoDiag = new VTFInfoDialogue();
							if (vtfInfoDiag.ShowDialog() == DialogResult.Cancel) {
								return;
							}
							vtfInfo = vtfInfoDiag.VTFInfo;
						}

						foreach (var item in LstInputPaths.Items) {
							var path = Path.Combine(basePath, Path.GetFileNameWithoutExtension(item.ToString()!));
							SSBumpConverter.ConvertToNormal(
								item.ToString()!,
								path,
								format,
								vtfInfo
							);
						}
					}
				} else {
					MessageBox.Show("No input image specified!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} catch (Exception ex) {
				MessageBox.Show($"Failure: {ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			} finally {
				try {
					if (Directory.Exists(Path.Combine(AppContext.BaseDirectory, "temp"))) {
						Directory.Delete(Path.Combine(AppContext.BaseDirectory, "temp"), true);
					}
					if (Directory.Exists(Path.Combine(AppContext.BaseDirectory, "temp_in"))) {
						Directory.Delete(Path.Combine(AppContext.BaseDirectory, "temp_in"), true);
					}
				} catch (Exception ex) {
					MessageBox.Show($"Failed to clean up tempolary files!\n\n{ex}", "Failure", 0, MessageBoxIcon.Warning);
				}
			}
		}
	}
}