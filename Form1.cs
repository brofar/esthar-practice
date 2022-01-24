using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Media;
using ProcessMemoryReaderLib;
using System.Runtime.InteropServices;

namespace esthar_practice
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern
       bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, int vk);
        [DllImport("user32")]
        public static extern
        bool GetMessage(ref Message lpMsg, IntPtr handle, uint mMsgFilterInMain, uint mMsgFilterMax);

        public const int MOD_ALT = 0x0001;
        public const int MOD_CONTROL = 0x0002;
        public const int MOD_SHIFT = 0x004;
        public const int MOD_NOREPEAT = 0x400;
        public const int WM_HOTKEY = 0x312;
        public const int DSIX = 0x36;

        public Form1()
        {
            InitializeComponent();
            // Set an unique id to your Hotkey, it will be used to
            // identify which hotkey was pressed in your code to execute something
            int UniqueHotkeyId = 1;
            // Set the Hotkey triggerer the F9 key 
            // Expected an integer value for F9: 0x78, but you can convert the Keys.KEY to its int value
            // See: https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx
            int HotKeyCode = (int)Keys.F6;
            // Register the "F9" hotkey
            Boolean F9Registered = RegisterHotKey(
                this.Handle, UniqueHotkeyId, 0x0000, HotKeyCode
            );

            // 4. Verify if the hotkey was succesfully registered, if not, show message in the console
            if (F9Registered)
            {
                Console.WriteLine("Global Hotkey F9 was succesfully registered");
            }
            else
            {
                Console.WriteLine("Global Hotkey F9 couldn't be registered !");
            }
        }

        protected override void WndProc(ref Message m)
        {
            // 5. Catch when a HotKey is pressed !
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();
                // MessageBox.Show(string.Format("Hotkey #{0} pressed", id));

                if (id == 1)
                {
                    Begin();
                }
            }

            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Btn_Go_Click(object sender, EventArgs e)
        {
            Begin();
        }

        private string GetVersion(Process ff8Game)
        {
            // Get the language from the process name (i.e. remove "FF8_" from the name)
            string GameVersion = ff8Game.ProcessName.Substring(4);

            // Update Form Title
            SetFormText("FF8 Esthar Practice - " + GameVersion);

            // DO STUFF
            return GameVersion;
        }
        private Process FindGame()
        {
            List<Process> processes = new List<Process>();
                processes = Process.GetProcesses()
                .Where(x => (x.ProcessName.StartsWith("FF8_", StringComparison.OrdinalIgnoreCase))
                            && !(x.ProcessName.Equals("FF8_Launcher", StringComparison.OrdinalIgnoreCase)))
                .ToList();

            if (processes.Count == 0)
                throw new NullReferenceException("Game not found.");

            return processes[0];
        }


        // Thread-Safe Call to Windows Forms Control
        delegate void SetFormTextCallback(string text);
        public void SetFormText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InvokeRequired)
            {
                SetFormTextCallback d = new SetFormTextCallback(SetFormText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.Text = text;
            }
        }
        // Thread-Safe Call to Windows Forms Control
        delegate void SetStatusTextCallback(string text);
        public void SetStatusText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lbl_status.InvokeRequired)
            {
                SetStatusTextCallback d = new SetStatusTextCallback(SetStatusText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lbl_status.Text = text;
            }
        }
        public async void Begin()
        {
            Process ff8Game = new Process();
            IntPtr GameBaseAddress = new IntPtr();
            string version = "";

            try {
                // Find the FF8 process.
                ff8Game = await Task.Run(FindGame);
                GameBaseAddress = ff8Game.MainModule.BaseAddress;
                version = GetVersion(ff8Game).ToUpper();

                SetStatusText("Game found: " + version);
            }
            catch (NullReferenceException e)
            {
                SetStatusText(e.Message);
                return;
            }

            // FR address = EN address - hex(328)
            int hexOffset = (version == "EN") ? 0x0 : 0x328;

            // Addresses (manipulate to correct address if FR)
            IntPtr addressStepId = IntPtr.Add(GameBaseAddress, 0x18D2FB8 - hexOffset);
            IntPtr addressStepFrac = IntPtr.Add(GameBaseAddress, 0x18DC740 - hexOffset);
            IntPtr addressTotalEncs = IntPtr.Add(GameBaseAddress, 0x18DBFEC - hexOffset);
            IntPtr addressDangerValue = IntPtr.Add(GameBaseAddress, 0x18DC74A - hexOffset);
            IntPtr addressOffset = IntPtr.Add(GameBaseAddress, 0x18DC748 - hexOffset);
            IntPtr addressLastEncId = IntPtr.Add(GameBaseAddress, 0x1996DA8 - hexOffset);

            ProcessMemoryReader reader = new ProcessMemoryReader
            {
                ReadProcess = ff8Game
            };
            reader.OpenProcess();

            byte[] stepId, StepFrac, TotalEncs, DangerValue, Offset, LastEncId;
            try
            {
                stepId = BitConverter.GetBytes(Convert.ToInt32(txt_stepId.Text));
                StepFrac = BitConverter.GetBytes(Convert.ToInt32(txt_stepFraction.Text));
                TotalEncs = BitConverter.GetBytes(Convert.ToInt32(txt_totalEncounters.Text));
                DangerValue = BitConverter.GetBytes(Convert.ToInt32(txt_dangerValue.Text));
                Offset = BitConverter.GetBytes(Convert.ToInt32(txt_offset.Text));
                LastEncId = BitConverter.GetBytes(Convert.ToInt32(txt_prevEncId.Text));

                // Write to game memory.
                reader.WriteProcessMemory(addressStepId, stepId, out int _);                
                reader.WriteProcessMemory(addressStepFrac, StepFrac, out int _);
                reader.WriteProcessMemory(addressTotalEncs, TotalEncs, out int _);
                reader.WriteProcessMemory(addressOffset, Offset, out int _);
                reader.WriteProcessMemory(addressLastEncId, LastEncId, out int _);

                // Danger value won't update if you assign it simultaenously.
                Thread.Sleep(100);
                reader.WriteProcessMemory(addressDangerValue, DangerValue, out int _);

                SystemSounds.Exclamation.Play();
            }
            catch (Exception e)
            {
                SetStatusText("Error parsing values.");
                return;
            }
        }
    }

}
