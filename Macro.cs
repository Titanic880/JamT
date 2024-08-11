using UI_Mimic.Windows;

namespace jamT {

    internal class MacroFire {
        private Macro m_Macro;
        private DateTime start;


        public MacroFire(Macro ToFire) { 
            this.m_Macro = ToFire;
        }
        public void StartMacro() {
            foreach(MacroInput m_Event in m_Macro.MacroSet) {
                if (m_Event.KeyHeld) {
                    //UI_Mimic.Windows.UserControl.HoldInput();
                }
                //UI_Mimic.Windows.UserControl.key();
            }
        }
    }

    internal class Macro {
        public MacroInput[] MacroSet { get => [.. m_MacroSet]; }
        private List<MacroInput> m_MacroSet = [];
        public void AddMacroInput(MacroInput input) {
            m_MacroSet.Add(input);
        }
        public void RemoveMacroInput(MacroInput input) {
            m_MacroSet.Remove(input);
        }
    }
    internal class MacroInput {
        public Keys KeyDown { get; set; }
        public bool KeyHeld { get; set; }
        public TimeSpan TimeHeld { get; set; }

        public MacroInput(Keys KeyDown, bool KeyHeld = false, TimeSpan TimeHeld = new()) {
            this.KeyDown = KeyDown;
            this.KeyHeld = KeyHeld;
            this.TimeHeld = TimeHeld;
        }
    }
}
