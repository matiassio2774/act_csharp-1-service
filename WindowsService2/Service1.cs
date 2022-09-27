using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic; // Install-Package Microsoft.VisualBasic
using System.IO;

namespace WindowsService2
{
    public partial class Service1 : ServiceBase
    {
        public System.Timers.Timer TimerServicio = new System.Timers.Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Agregue el código aquí para iniciar el servicio. Este método debería poner
            // en movimiento los elementos para que el servicio pueda funcionar.
            TimerServicio = new System.Timers.Timer();
            TimerServicio.Elapsed += (_, __) => EjecutaUnaAccion();
            TimerServicio.Interval = 6000;
            TimerServicio.Start();
        }

        public void EjecutaUnaAccion()
        {
            int i;
            for (i = 1; i <= 1000; i++)
            {
                File.AppendAllText(@"A:\INFORME.TXT","LINEA: " + i + System.Environment.NewLine);
            }
                
        }
        protected override void OnStop()
        {
            TimerServicio.Close();
        }
        protected override void OnPause()
        {
            TimerServicio.Stop();
        }

        protected override void OnContinue()
        {
            TimerServicio.Start();
        }
    }
}
