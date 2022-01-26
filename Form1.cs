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
using System.Drawing;

namespace esthar_practice
{
    public partial class Form1 : Form
    {
        // GLOBAL HOTKEY STUFF
        [DllImport("user32.dll")]
        public static extern
        bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, int vk);

        // UPDATE STUFF
        bool appUpdateAvailable = false;

        // GAME STUFF
        Process ff8Game;
        IntPtr gameBaseAddress;
        string gameVersion;
        ProcessMemoryReader reader;
        List<SavedValue> savedConfigs;
        public Form1()
        {
            InitializeComponent();

            // Check for updates.
            CheckForUpdates();

            // Load saved config
            ConfigHandler config = new ConfigHandler();
            savedConfigs = config.LoadJson();
            SetDropDown(savedConfigs);
            drop_saved.SelectedIndex = 0;

            // Register Hotkey
            // https://ourcodeworld.com/articles/read/573/how-to-register-a-single-or-multiple-global-hotkeys-for-a-single-key-in-winforms
            // Set an unique id to your Hotkey, it will be used to
            // identify which hotkey was pressed in your code to execute something
            int UniqueHotkeyId = 1;
            int HotKeyCode = (int)Keys.F6;

            // Register the hotkey
            Boolean F9Registered = RegisterHotKey(this.Handle, UniqueHotkeyId, 0x0000, HotKeyCode);

            // 4. Verify if the hotkey was succesfully registered, if not, show message in the console
            if (!F9Registered)
                SetStatusText("Hotkey F6 couldn't be registered!");
        }

        public void SetDropDown(List<SavedValue> values)
        {
            drop_saved.Items.Clear();
            foreach (SavedValue value in values)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = value.name;
                item.Value = value;

                drop_saved.Items.Add(item);
            }
        }

        protected override void WndProc(ref Message m)
        {
            // 5. Catch when a HotKey is pressed !
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();

                // Do something based on which hotkey was pressed
                switch(id)
                {
                    case 1:
                        SetMemoryValues();
                        break;
                }
            }

            base.WndProc(ref m);
        }

        private void Btn_Go_Click(object sender, EventArgs e)
        {
            SetMemoryValues();
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
        public async void SetMemoryValues()
        {
            ff8Game = new Process();
            gameBaseAddress = new IntPtr();
            gameVersion = "";

            try {
                // Find the FF8 process.
                ff8Game = await Task.Run(FF8Game.FindGame);
                gameBaseAddress = ff8Game.MainModule.BaseAddress;
                gameVersion = FF8Game.GetVersion(ff8Game).ToUpper();

                // Update text fields
                SetFormText("FF8 Esthar Practice - " + gameVersion);
                SetStatusText("Game found: " + gameVersion);
            }
            catch (NullReferenceException e)
            {
                SetStatusText(e.Message);
                return;
            }

            reader = new ProcessMemoryReader
            {
                ReadProcess = ff8Game
            };
            reader.OpenProcess();

            // FR address = EN address - hex(328)
            int hexOffset = (gameVersion == "EN") ? 0x0 : 0x328;

            // Addresses (manipulate to correct address if FR)
            int addressStepId = 0x18D2FB8 - hexOffset;
            int addressStepFrac = 0x18DC740 - hexOffset;
            int addressTotalEncs = 0x18DBFEC - hexOffset;
            int addressDangerValue = 0x18DC74A - hexOffset;
            int addressOffset = 0x18DC748 - hexOffset;
            int addressLastEncId = 0x1996DA8 - hexOffset;

            // Anti Speedrun Cheating - Add Doomtrain when program is used.
            int addressDoomId = 0x18FDFA5 - hexOffset;

            try
            {
                WriteMemoryAddress(addressStepId, Convert.ToInt32(num_stepId.Value));
                WriteMemoryAddress(addressStepFrac, Convert.ToInt32(num_fraction.Value));
                WriteMemoryAddress(addressTotalEncs, Convert.ToInt32(num_totalEnc.Value));
                WriteMemoryAddress(addressDangerValue, Convert.ToInt32(num_danger.Value));
                WriteMemoryAddress(addressOffset, Convert.ToInt32(num_offset.Value));
                WriteMemoryAddress(addressLastEncId, Convert.ToInt32(num_lastEnc.Value));
                WriteMemoryAddress(addressDoomId, 1);

                // Danger value won't update if you assign it simultaenously.
                // So we sleep for 100ms. Idk why.
                Thread.Sleep(100);
                WriteMemoryAddress(addressDangerValue, Convert.ToInt32(num_danger.Value));

                SystemSounds.Exclamation.Play();
            }
            catch (Exception)
            {
                SetStatusText("Error parsing values.");
                return;
            }
        }
        private void WriteMemoryAddress(int offset, int val)
        {
            IntPtr address = IntPtr.Add(gameBaseAddress, offset);

            byte[] value = BitConverter.GetBytes(val);

            reader.WriteProcessMemory(address, value, out int _);
        }
        private async void CheckForUpdates()
        {
            SetStatusText("Checking for updates...");

            bool updateRequired = await Task.Run(Updater.IsUpdateRequired);
            appUpdateAvailable = updateRequired;

            if (updateRequired)
            {
                SetStatusText("New version available. Click here to download.");
            }
            else
            {
                SetStatusText("Running latest version.");
            }
        }
        private void Lbl_Status_Click(object sender, EventArgs e)
        {
            if(appUpdateAvailable)
                Process.Start("https://github.com/brofar/esthar-practice/releases/latest");
        }

        private void drop_saved_SelectedIndexChanged(object sender, EventArgs e)
        {
            SavedValue config = (drop_saved.SelectedItem as ComboboxItem).Value;
            if(config.valid)
            {
                num_stepId.Value = config.StepId;
                num_fraction.Value = config.StepFrac;
                num_totalEnc.Value = config.TotalEncs;
                num_danger.Value = config.DangerValue;
                num_offset.Value = config.Offset;
                num_lastEnc.Value = config.LastEncId;
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            SavedValue newValue = new SavedValue
            {
                StepId = Convert.ToInt32(num_stepId.Value),
                StepFrac = Convert.ToInt32(num_fraction.Value),
                TotalEncs = Convert.ToInt32(num_totalEnc.Value),
                DangerValue = Convert.ToInt32(num_danger.Value),
                Offset = Convert.ToInt32(num_offset.Value),
                LastEncId = Convert.ToInt32(num_lastEnc.Value)
            };
            string input = "";
            DialogResult result = ShowInputDialog(ref input);

            while ((savedConfigs.Where(i => i.name == input).FirstOrDefault() != null || input == "") && result == DialogResult.OK )
            {
                result = ShowInputDialog(ref input, true);
            }

            if (result == DialogResult.OK)
            {
                newValue.name = input;
                savedConfigs.Add(newValue);

                // Update the dropdown
                SetDropDown(savedConfigs);

                // Set the dropdown to our latest added entry.
                drop_saved.SelectedIndex = drop_saved.Items.Count - 1;

                ConfigHandler config = new ConfigHandler();
                config.SaveJson(savedConfigs);
            }
        }
        private static DialogResult ShowInputDialog(ref string input, bool err = false)
        {
            // https://stackoverflow.com/questions/97097/what-is-the-c-sharp-version-of-vb-nets-inputdialog
            System.Drawing.Size size = new System.Drawing.Size(200, 90);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.StartPosition = FormStartPosition.CenterParent;
            inputBox.MinimizeBox = false;
            inputBox.MaximizeBox = false;
            inputBox.ShowInTaskbar = false;
            inputBox.Text = "Name";

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 25);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Label message = new Label();
            message.Name = "lbl_message";
            message.ForeColor = DefaultForeColor;
            message.Text = "Enter a name for this set.";
            message.Size = new System.Drawing.Size(size.Width - 10, 23);
            message.Location = new System.Drawing.Point(3, 5);
            if(err)
            {
                message.Text = "That name already exists.";
                message.ForeColor = Color.Red;
            }
            inputBox.Controls.Add(message);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 59);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 59);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }

        private void btn_del_config_Click(object sender, EventArgs e)
        {
            SavedValue targetSavedValue = (drop_saved.SelectedItem as ComboboxItem).Value;

            DialogResult dialogResult = MessageBox.Show(string.Format("Delete {0} from configs?", targetSavedValue.name), "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                savedConfigs.Remove(savedConfigs.Where(i => i.name == targetSavedValue.name).FirstOrDefault());

                // Update the dropdown
                SetDropDown(savedConfigs);

                // Set the dropdown to our latest added entry.
                drop_saved.SelectedIndex = 0;

                ConfigHandler config = new ConfigHandler();
                config.SaveJson(savedConfigs);
            }
        }
    }
    public class ComboboxItem
    {
        public string Text { get; set; }
        public SavedValue Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}