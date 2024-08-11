using jamT;
using WinApi.User32;

namespace MacroUtil {
    public partial class Form1 : Form {
        //private bool Capture = false;
        private Macro CurrentMacro;
        private MacroInput CurrentInput;


        public Form1() {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(VirtualKey));
            comboBox1.SelectedIndex = 0;
        }




        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (Capture is false) {
                return;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) {
            if (Capture is false) {
                return;
            }
        }

        private bool SafetyState = true;
        private void BtnSafetyToggle_Click(object sender, EventArgs e) {
            MessageBox.Show(
            UI_Mimic.Windows.UIControl.ToggleKeyInputSafety(3040312, !SafetyState)
            );
            SafetyState = !SafetyState;
        }

        private void BtnTBSend_Click(object sender, EventArgs e) {
            Thread.Sleep(3000);
            UI_Mimic.Windows.UIControl.KeyStrokesFromString(textBox1.Text);
        }

        private void BtnMouseSend_Click(object sender, EventArgs e) {
            Thread.Sleep(2000);
            if (ChBClick.Checked) {
                UI_Mimic.Windows.UIControl.Mouse_Move_Click(new Point((int)numericUpDown1.Value, (int)numericUpDown2.Value),!ChBRClick.Checked);
            }
            else {
                UI_Mimic.Windows.UIControl.Mouse_Move(new Point((int)numericUpDown1.Value, (int)numericUpDown2.Value));
            }
        }
        private void BtnComboSend_Click(object sender, EventArgs e) {
            Thread.Sleep(2000);
            UI_Mimic.Windows.UIControl.KeyStrokeSim(vk: (VirtualKey)comboBox1.SelectedItem!);
        }
    }
}
