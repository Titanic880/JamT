using UI_Mimic;
using WinApi.User32;

namespace jamT {
    internal class MacroFire {

        private bool Running = false;
        private readonly bool RecordState = false;
        private Macro m_Macro;
        private DateTime start;
        private TimeSpan RunTime { get => DateTime.Now - start; }
        private readonly List<MacroInput> HeldInputs = [];
        private InputReader reader;

        public MacroFire(Macro ToFire) {
            this.m_Macro = ToFire;
        }
        public MacroFire() {
            RecordState = true;
        }

        public bool StartMacro() {
            if (RecordState) {
                return false;
            }
            //Setup
            Running = true;
            start = DateTime.Now;
            Task.Run(KeyCheckTicker);
            //Run the Macro
            foreach (Input m_Event in m_Macro.MacroSet) {
                if (m_Event is MacroInput Event) {

                    if (Event.KeyHeld) {
                        Event.TimeHeld += RunTime;
                        HeldInputs.Add(Event);
                        UI_Mimic.Windows.UIControl.KeyStrokeDown(Event.KeyDown);
                    } else {
                        UI_Mimic.Windows.UIControl.KeyStrokeSim(Event.KeyDown);
                    }
                } else if (m_Event is MouseInput MouseInput) {
                    if (MouseInput.Click && MouseInput.Move) {
                        UI_Mimic.Windows.UIControl.Mouse_Move_Click(MouseInput.LocationData, MouseInput.LeftClick);
                    } else if (MouseInput.Click) {
                        UI_Mimic.Windows.UIControl.Mouse_Click(MouseInput.LeftClick);
                    } else if (MouseInput.Move) {
                        UI_Mimic.Windows.UIControl.Mouse_Move(MouseInput.LocationData);
                    } else {
                        throw new NotSupportedException("Empty Mouse Input");
                    }
                }
            }

            Running = false;
            return true;
        }
        /// <summary>
        /// KeyHeld Update
        /// </summary>
        private void KeyCheckTicker() {
            //this is not technically thread safe (I do not care;
            //as the design is for this to be the only remove function (outside of a complete shutdown))
            while (Running) {
                foreach (MacroInput held in HeldInputs) {
                    if ((held.TimeHeld - RunTime).TotalSeconds < 0) { //Check for release
                        UI_Mimic.Windows.UIControl.KeyStrokeUp(held.KeyDown);
                        HeldInputs.Remove(held);
                    }
                }
            }
        }

        
        public bool RecordMacro(UI_Mimic.InputReader Reader) {
            byte res = Reader.GetHookState();
            if (res >= 1) {
                Reader.OnError += ErrorHandle;
                Reader.KeyDown += Reader_KeyDown;
                Reader.KeyUp += Reader_KeyUp;
            }
            if (res >= 16) {
                //Get Keyboard working then figure out mouse
                //Reader.OnMouseMove += MouseMove;
                //Reader.OnMouseClick += mouseRes;
            }
            
            
            m_Macro = new();
            start = DateTime.Now;
            Running = true;

            return true;
        }
        public void KillMacro() {
            Running = false;
        }
        private TimeSpan m_KeyHeld_Start;
        private MacroInput m_CurrentInput;
        private MouseInput m_CurrentMouseInput;

        private void Reader_KeyUp(Keys key, bool Shift, bool Ctrl, bool Alt, bool Home) {
            if (Running == false)
                return;
            //Constant in function value (easier debugging)
            TimeSpan snapshot = RunTime;
            //Held Input
            if(snapshot.Subtract(new(TimeSpan.TicksPerMillisecond*10)) >= m_CurrentInput.TimeHeld) {
                m_CurrentInput = new(m_CurrentInput.KeyDown,true, snapshot.Subtract(m_CurrentInput.TimeHeld));
                m_Macro.AddMacroInput(m_CurrentInput);
            }
            
        }
        private void Reader_KeyDown(Keys key, bool Shift, bool Ctrl, bool Alt, bool Home) {
            if (Running == false)
                return;
            List<MacroInput> Modifiers = [];
            //Test Using a new Macro per Modifier (with a preset hold time)
            if (Shift) {
                Modifiers.Add(new(VirtualKey.SHIFT,true,new TimeSpan(2*TimeSpan.TicksPerMillisecond)));
            }
            if (Ctrl) {
                Modifiers.Add(new(VirtualKey.CONTROL, true, new TimeSpan(2 * TimeSpan.TicksPerMillisecond)));
            }
            if (Alt) {
                Modifiers.Add(new(VirtualKey.MENU, true, new TimeSpan(2 * TimeSpan.TicksPerMillisecond)));
            }
            if (Home) {
                Modifiers.Add(new(VirtualKey.HOME, true, new TimeSpan(2 * TimeSpan.TicksPerMillisecond)));
            }
            m_Macro.AddMacroInput(Modifiers.ToArray());
            m_CurrentInput = new((VirtualKey)key);
        }
                
        private void mouseRes(MouseButtons Action) {
            if (Running == false)
                return;
        }
        private void MouseMove(int x, int y) {
            if (Running == false)
                return;
        }
        private void ErrorHandle(Exception ex) {
            //TODO: Error log handler
        }
    }

    internal class Macro {
        public Input[] MacroSet { get => [.. m_MacroSet]; }
        private readonly List<Input> m_MacroSet = [];
        public void AddMacroInput(Input input) {
            m_MacroSet.Add(input);
        }
        public void AddMacroInput(Input[] input) {
            m_MacroSet.AddRange(input);
        }
        public void RemoveMacroInput(Input input) {
            m_MacroSet.Remove(input);
        }
        public void RemoveMacroInput(Input[] input) {
            foreach(Input a in m_MacroSet) {
                if (input.Contains(a)) {
                    m_MacroSet.Remove(a);
                }
            }
        }
    }
    
    /// <summary>
    /// Rebuild input if you want to adjust it.
    /// </summary>
    internal class MacroInput : Input {
        public VirtualKey KeyDown { get; private set; }
        public bool KeyHeld { get; private set; }
        public TimeSpan TimeHeld { get; set; }

        public MacroInput(VirtualKey KeyDown, bool KeyHeld = false, TimeSpan TimeHeld = new()) {
            this.KeyDown = KeyDown;
            this.KeyHeld = KeyHeld;
            this.TimeHeld = TimeHeld;
        }
    }
    internal class MouseInput : Input {
        public bool Click { get; private set; } = false;
        public bool Move { get; private set; } = false;
        
        public Point LocationData { get; private set; }

        public bool LeftClick { get; private set; } = true;
        
        public MouseInput(bool Click, bool Move, bool LeftClick, int New_X,int New_Y) {
            this.Click = Click;
            this.Move = Move;
            this .LeftClick = LeftClick;
            
            LocationData = new(New_X, New_Y);
        }
        public MouseInput(bool Click, bool Move, bool LeftClick, Point NewLocation) {
            this.Click = Click;
            this.Move = Move;
            this.LeftClick = LeftClick;

            LocationData = NewLocation;
        }
    }
    internal class Input {
        
    }
}
