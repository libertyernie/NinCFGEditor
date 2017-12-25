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
        private NIN_CFG _data;

        public Form1() {
            InitializeComponent();

            _data = NIN_CFG.Read(File.ReadAllBytes(@"C:\Users\admin\Desktop\nincfg.bin"));
                
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
                flowLayoutPanel1.Controls.Add(new CheckBox {
                    Text = sb.ToString(),
                    AutoSize = true,
                    Checked = _data.Flags.HasFlag(v)
                });
            }

            foreach (object o in Enum.GetValues(typeof(NinCFGVideoMode))) {
                ddlVideoMode.Items.Add(o);
                if ((NinCFGVideoMode)o == _data.VideoMode) {
                    ddlVideoMode.SelectedIndex = ddlVideoMode.Items.Count - 1;
                }
            }
            if (ddlVideoMode.SelectedIndex == -1) {
                ddlVideoMode.Items.Add(_data.VideoMode);
                ddlVideoMode.SelectedIndex = ddlVideoMode.Items.Count - 1;
            }

            foreach (object o in Enum.GetValues(typeof(NinCFGForceVideoMode))) {
                ddlForceVideoMode.Items.Add(o);
                if ((NinCFGForceVideoMode)o == _data.ForceVideoMode) {
                    ddlForceVideoMode.SelectedIndex = ddlForceVideoMode.Items.Count - 1;
                }
            }

            chkPatchPAL50.Checked = _data.PatchPAL50;

            foreach (object o in Enum.GetValues(typeof(NinCFGLanguage))) {
                ddlLanguage.Items.Add(o);
                if ((NinCFGLanguage)o == _data.Language) {
                    ddlLanguage.SelectedIndex = ddlLanguage.Items.Count - 1;
                }
            }
        }
    }
}
