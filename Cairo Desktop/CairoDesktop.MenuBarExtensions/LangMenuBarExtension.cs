using CairoDesktop.Application.Interfaces;
using CairoDesktop.Infrastructure.ObjectModel;
using UserControl = System.Windows.Controls.UserControl;

namespace CairoDesktop.MenuBarExtensions
{
    internal sealed class LangMenuBarExtension : UserControlMenuBarExtension
    {
        private LanguagePane _lang;

        public override UserControl StartControl(IMenuBar host)
        {
            _lang = new LanguagePane();
            return _lang;
        }
    }
}