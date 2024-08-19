using jamT;

namespace MacroUtil {
    public partial class Form1 : Form {
        private bool m_capture = false;
        private List<Macro> m_MacroList = [];
        private UI_Mimic.InputReader InputReader;

        public Form1() {
            InitializeComponent();
            InputReader = UI_Mimic.InputReader.ReaderFactory(true, [ this.Text ] );
            InputReader.GenerateHook(UI_Mimic.HookTypePub.Keyboard);
            InputReader.GenerateHook(UI_Mimic.HookTypePub.Mouse);
            
        }
        ~Form1() {
            if (this.IsDisposed) {
                return;
            }
            InputReader.DisconnectHook(UI_Mimic.HookTypePub.Keyboard);
            InputReader.DisconnectHook(UI_Mimic.HookTypePub.Mouse);
            InputReader.Dispose();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (m_capture is false) {
                return;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) {
            if (m_capture is false) {
                return;
            }
        }

        private void BtnAddtoList_Click(object sender, EventArgs e) {
            if(textBox1.Text == "") {
                return;
            }
            listBox1.Items.Add(textBox1.Text);
        }

        private void BtnAutoGrab_Click(object sender, EventArgs e) {
            System.Windows.Forms.Timer tim = new();
            tim.Interval = 2500;
            tim.Tick += Tick;
            tim.Start();

            void Tick(object? sender, EventArgs e) {
                ((System.Windows.Forms.Timer)sender!).Stop();
                //Action
                textBox1.Text = UI_Mimic.Windows.W_WindowInfo.GetActiveWindowTitle();
                ((System.Windows.Forms.Timer)sender!).Dispose();
            }
        }


        private void BtnStart_Click(object sender, EventArgs e) {
            //Initilize hooks and Start timer
        }

        private void BtnRemove_Click(object sender, EventArgs e) {
            if (listBox1.SelectedIndex < 0 || listBox1.SelectedIndex > listBox1.Items.Count - 1) {
                return;
            }
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
