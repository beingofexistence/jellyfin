﻿using MediaBrowser.Common.Kernel;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.Plugins;
using System.Linq;

namespace MediaBrowser.ServerApplication
{
    /// <summary>
    /// Class StartupWizard
    /// </summary>
    public class StartupWizard : IServerEntryPoint
    {
        /// <summary>
        /// The _app host
        /// </summary>
        private readonly IApplicationHost _appHost;
        /// <summary>
        /// The _user manager
        /// </summary>
        private readonly IUserManager _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="StartupWizard" /> class.
        /// </summary>
        /// <param name="appHost">The app host.</param>
        /// <param name="userManager">The user manager.</param>
        public StartupWizard(IApplicationHost appHost, IUserManager userManager)
        {
            _appHost = appHost;
            _userManager = userManager;
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public void Run()
        {
            if (_appHost.IsFirstRun)
            {
                LaunchStartupWizard();
            }
        }

        /// <summary>
        /// Launches the startup wizard.
        /// </summary>
        private void LaunchStartupWizard()
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Configuration.IsAdministrator);

            App.OpenDashboardPage("wizardStart.html", user);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
