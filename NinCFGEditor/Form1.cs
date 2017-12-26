using Be.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NinCFGEditor {
    public partial class Form1 : Form {
        private Dictionary<NinCFGFlags, CheckBox> _checkboxes;

        private NIN_CFG _originalData;
        private NIN_CFG _workingData;

        public Form1() {
            InitializeComponent();
            
            _checkboxes = new Dictionary<NinCFGFlags, CheckBox>();
                
            foreach (object o in Enum.GetValues(typeof(NinCFGFlags))) {
                NinCFGFlags v = (NinCFGFlags)o;

                StringBuilder sb = new StringBuilder();
                bool lastLower = false;
                foreach (char c in v.ToString()) {
                    if (char.IsUpper(c) && lastLower) {
                        sb.Append(' ');
                    }
                    sb.Append(c);
                    lastLower = char.IsLower(c);
                }
                CheckBox box = new CheckBox {
                    Text = sb.ToString(),
                    AutoSize = true
                };
                box.CheckedChanged += (sender, e) => {
                    _workingData.Flags &= ~v;
                    if (box.Checked) _workingData.Flags |= v;
                    UpdateHexBox();
                };
                flowLayoutPanel1.Controls.Add(box);
                _checkboxes.Add(v, box);
            }
            
            _originalData = NIN_CFG.Default;
            Populate();
        }

        public void Populate() {
            _workingData = _originalData;
            UpdateHexBox();

            foreach (var pair in _checkboxes) {
                pair.Value.Checked = _workingData.Flags.HasFlag(pair.Key);
            }

            ddlVideoMode.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(NinCFGVideoModeHigh))) {
                ddlVideoMode.Items.Add(o);
                if ((NinCFGVideoModeHigh)o == _workingData.VideoModeHigh) {
                    ddlVideoMode.SelectedIndex = ddlVideoMode.Items.Count - 1;
                }
            }
            if (ddlVideoMode.SelectedIndex == -1) {
                ddlVideoMode.Items.Add(_workingData.VideoModeHigh);
                ddlVideoMode.SelectedIndex = ddlVideoMode.Items.Count - 1;
            }

            ddlForceVideoMode.Items.Clear();
            foreach (NinCFGVideoModeLow o in new[] {
                NinCFGVideoModeLow.PAL50,
                NinCFGVideoModeLow.PAL60,
                NinCFGVideoModeLow.NTSC,
                NinCFGVideoModeLow.MPAL
            }) {
                ddlForceVideoMode.Items.Add(o);
                if (o == _workingData.ForcedVideoMode) {
                    ddlForceVideoMode.SelectedIndex = ddlForceVideoMode.Items.Count - 1;
                }
            }
            if (ddlForceVideoMode.SelectedIndex == -1) {
                ddlForceVideoMode.Items.Add(_workingData.ForcedVideoMode);
                ddlForceVideoMode.SelectedIndex = ddlForceVideoMode.Items.Count - 1;
            }

            chkPatchPAL50.Checked = _workingData.PatchPAL50;

            ddlLanguage.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(NinCFGLanguage))) {
                ddlLanguage.Items.Add(o);
                if ((NinCFGLanguage)o == _workingData.Language) {
                    ddlLanguage.SelectedIndex = ddlLanguage.Items.Count - 1;
                }
            }

            txtGamePath.Text = _workingData.GamePath;
            txtCheatPath.Text = _workingData.CheatPath;
            numMaxPads.Value = _workingData.MaxPads;
            textBox1.Text = _workingData.GameID;

            ddlMemCardBlocks.Items.Clear();
            foreach (int size in NIN_CFG.SupportedMemoryCardBlockSizes) {
                ddlMemCardBlocks.Items.Add(size);
                if (size == _workingData.MemoryCardBlocks) {
                    ddlMemCardBlocks.SelectedIndex = ddlMemCardBlocks.Items.Count - 1;
                }
            }
            if (ddlMemCardBlocks.SelectedIndex == -1) {
                ddlMemCardBlocks.Items.Add(_workingData.MemoryCardBlocks);
                ddlMemCardBlocks.SelectedIndex = ddlMemCardBlocks.Items.Count - 1;
            }
        }

        private void UpdateHexBox() {
            hexBox1.ByteProvider = new ReadOnlyByteProvider(_workingData.GetBytes());
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            _originalData = NIN_CFG.Default;
            Populate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var dialog = new OpenFileDialog()) {
                dialog.DefaultExt = "bin";
                if (dialog.ShowDialog(this) == DialogResult.OK) {
                    _originalData = NIN_CFG.Read(File.ReadAllBytes(dialog.FileName));
                    Populate();
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var dialog = new SaveFileDialog()) {
                dialog.DefaultExt = "bin";
                if (dialog.ShowDialog(this) == DialogResult.OK) {
                    File.WriteAllBytes(dialog.FileName, _workingData.GetBytes());
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void ddlVideoMode_SelectedIndexChanged(object sender, EventArgs e) {
            _workingData.VideoModeHigh = (NinCFGVideoModeHigh)ddlVideoMode.SelectedItem;
            UpdateHexBox();
        }

        private void ddlForceVideoMode_SelectedIndexChanged(object sender, EventArgs e) {
            _workingData.ForcedVideoMode = (NinCFGVideoModeLow)ddlForceVideoMode.SelectedItem;
            UpdateHexBox();
        }

        private void chkPatchPAL50_CheckedChanged(object sender, EventArgs e) {
            _workingData.PatchPAL50 = chkPatchPAL50.Checked;
            UpdateHexBox();
        }

        private void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e) {
            _workingData.Language = (NinCFGLanguage)ddlLanguage.SelectedItem;
            UpdateHexBox();
        }

        private void txtGamePath_TextChanged(object sender, EventArgs e) {
            _workingData.GamePath = txtGamePath.Text;
            UpdateHexBox();
        }

        private void txtCheatPath_TextChanged(object sender, EventArgs e) {
            _workingData.CheatPath = txtCheatPath.Text;
            UpdateHexBox();
        }

        private void numMaxPads_ValueChanged(object sender, EventArgs e) {
            _workingData.MaxPads = (uint)numMaxPads.Value;
            UpdateHexBox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            _workingData.GameID = textBox1.Text;
            UpdateHexBox();
        }

        private void ddlMemCardBlocks_SelectedIndexChanged(object sender, EventArgs e) {
            _workingData.MemoryCardBlocks = (int)ddlMemCardBlocks.SelectedItem;
            UpdateHexBox();
        }
    }
}
