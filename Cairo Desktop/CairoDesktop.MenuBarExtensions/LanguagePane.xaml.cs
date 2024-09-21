using System;
using System.Windows.Controls;
using System.Windows.Threading;
using ManagedShell.Common.Helpers;

namespace CairoDesktop.MenuBarExtensions
{
    internal sealed partial class LanguagePane : UserControl
    {
        public LanguagePane()
        {
            InitializeComponent();

            InitializeLang();
        }

        private void InitializeLang()
        {
            UpdateText();

            // Create our timer for lang
            _ = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Background, Lang_Tick, Dispatcher);

            // register time changed handler to receive time zone updates for the lang to update correctly
            Microsoft.Win32.SystemEvents.TimeChanged += UpdateText;
            Dispatcher.ShutdownStarted += Dispatcher_ShutdownStarted;
        }

        private void Dispatcher_ShutdownStarted(object sender, EventArgs e)
        {
            Microsoft.Win32.SystemEvents.TimeChanged -= UpdateText;
        }

        private void Lang_Tick(object sender, EventArgs args)
        {
            UpdateText();
        }

        private void UpdateText(object sender = null, EventArgs eventArgs = null)
        {
            LangText.Text = KeyboardLayoutHelper.GetKeyboardLayout().ThreeLetterName;
        }
    }
}