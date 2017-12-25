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
                    _originalData.Flags &= ~v;
                    if (box.Checked) _originalData.Flags |= v;
                };
                flowLayoutPanel1.Controls.Add(box);
                _checkboxes.Add(v, box);
            }
            
            _originalData = NIN_CFG.Default;
            Populate();
        }

        public void Populate() {
            _workingData = _originalData;

            foreach (var pair in _checkboxes) {
                pair.Value.Checked = _workingData.Flags.HasFlag(pair.Key);
            }

            foreach (object o in Enum.GetValues(typeof(NinCFGVideoMode))) {
                ddlVideoMode.Items.Add(o);
                if ((NinCFGVideoMode)o == _workingData.VideoMode) {
                    ddlVideoMode.SelectedIndex = ddlVideoMode.Items.Count - 1;
                }
            }
            if (ddlVideoMode.SelectedIndex == -1) {
                ddlVideoMode.Items.Add(_workingData.VideoMode);
                ddlVideoMode.SelectedIndex = ddlVideoMode.Items.Count - 1;
            }

            foreach (object o in Enum.GetValues(typeof(NinCFGForceVideoMode))) {
                ddlForceVideoMode.Items.Add(o);
                if ((NinCFGForceVideoMode)o == _workingData.ForceVideoMode) {
                    ddlForceVideoMode.SelectedIndex = ddlForceVideoMode.Items.Count - 1;
                }
            }

            chkPatchPAL50.Checked = _workingData.PatchPAL50;

            foreach (object o in Enum.GetValues(typeof(NinCFGLanguage))) {
                ddlLanguage.Items.Add(o);
                if ((NinCFGLanguage)o == _workingData.Language) {
                    ddlLanguage.SelectedIndex = ddlLanguage.Items.Count - 1;
                }
            }

            txtGamePath.Text = _workingData.GamePath;
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
    }
}
