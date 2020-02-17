using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;

namespace GlobalStore.UpdateService
{
    public class Updater
    {
        private BackgroundWorker bgWorker;
        //private AcceptUpdateForm form;
      
        private IUpdatable programInfo;

        public Updater(IUpdatable updatable)
        {
            this.programInfo = updatable;
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(bg_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
        }
        public void DoUpdate()
        {if(this.bgWorker.IsBusy)
            bgWorker.RunWorkerAsync(this.programInfo);
        }
        public void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            IUpdatable application = (IUpdatable)e.Argument;
            if (!UpdateXml.ExistsOnServer(application.UpdateXmlLocation))
            {
                e.Cancel = true;
            }
            else
            { e.Result = UpdateXml.Parse(application.UpdateXmlLocation,application.ApplicationID); 
            }
        }
        public void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                UpdateXml update = (UpdateXml)e.Result;
                if (update != null && update.IsNewerThan(this.programInfo.ApplicationAssembly.GetName().Version))
                {
                    DownloadUpdate(update);
                }
            }
        }
        private void DownloadUpdate(UpdateXml updateXml)
        {

            string currentPath = this.programInfo.ApplicationAssembly.Location;
            string newPath = Path.GetDirectoryName(currentPath)+ "\\" + updateXml.FileName;

            UpdateApplication(currentPath, newPath, updateXml.LaunchArgs);
            
        }
        private void UpdateApplication(string currPath,string newPath, string launchArgs)
        {
            string argument = "/C Choise /C Y /N /D Y /T 4 & Del /F /Q \"{0}\" & Choice /C Y /N  /D Y  /T 2 & Move /Y \"{1}\" \"{2}\"  & Start \"\" /D \"{3}\" \"{4}\" {5}";
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.Arguments = string.Format(argument, currPath, newPath, Path.GetDirectoryName(newPath), Path.GetFileName(newPath), launchArgs);
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.FileName = "cmd.exe";
            Process.Start(processStartInfo);
        }



    }
}
