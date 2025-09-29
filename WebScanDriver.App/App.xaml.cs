using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace WebScanDriver.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private NotifyIcon trayIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            trayIcon = new NotifyIcon
            {
                Icon = new Icon("Assets\\Icons\\Logo.ico"), // Or load your .ico file
                Visible = true,
                Text = "WPF Tray App"
            };

            var menu = new ContextMenuStrip();
            menu.Items.Add("Say Hello", null);
            menu.Items.Add("Exit", null, (s, ev) =>
            {
                trayIcon.Visible = false;
                Shutdown();
            });

            trayIcon.ContextMenuStrip = menu;
        }
    }
}
