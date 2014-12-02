using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Emgu.CV;
using Emgu.CV.Structure;

using MongoDB.Driver;
using MongoDB.Bson;

namespace ECE4180FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private static Capture camCapture;
        private Mutex mutex;
        private bool isProcessing = false;
        
        public MainWindow()
        {
            InitializeComponent();
            mutex = new Mutex();
            try
            {
                camCapture = new Capture();
                camCapture.Start();
            }
            catch (Exception ex)
            {

            }
        }

        private void tabStartup_MouseMove(object sender, MouseEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void ProcessFrame(bool addingNewUser)
        {
            camCapture.Start();
            while (true)
            {
                mutex.WaitOne();
                if (!isProcessing) break;
                mutex.ReleaseMutex();
                Mat frame = camCapture.QueryFrame();
                Image<Bgr, Byte> smoothedFrame = new Image<Bgr, byte>(frame.Size);
                CvInvoke.GaussianBlur(frame, smoothedFrame, new System.Drawing.Size(3, 3), 1); //filter out noises
                if (!addingNewUser)
                {
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                        cameraDisplay.Source = BitmapSourceConvert.ToBitmapSource(smoothedFrame)
                        ));
                }
                else
                {
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                      intakePic.Source = BitmapSourceConvert.ToBitmapSource(smoothedFrame)
                       ));
                }
            }
            mutex.ReleaseMutex();
            camCapture.Pause();
           
        }

        private void tabMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mutex.WaitOne();
            isProcessing = tabControl.SelectedIndex == 1 ? true : false;
            mutex.ReleaseMutex();

            if (tabControl.SelectedIndex == 1)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(
                    (obj) =>
                    {
                        ProcessFrame(false);
                    }));
            }
        }

        private void dbm_Click(object sender, RoutedEventArgs e)
        {
            if(tabControl.SelectedIndex==1)
            {
                tabControl.SelectedIndex = 2;
                btnSwitch.Content = "Security View";
            }
            else if(tabControl.SelectedIndex==2)
            {
                tabControl.SelectedIndex = 1;
                btnSwitch.Content = "DB Management";
            }
        }

        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            if(!flyoutAddPerson.IsOpen)
            {
                mutex.WaitOne();
                isProcessing = true;
                mutex.ReleaseMutex();
                flyoutAddPerson.IsOpen = true;
                ThreadPool.QueueUserWorkItem(new WaitCallback(
                    (obj) =>
                    {
                        ProcessFrame(true);
                    }));
            }
        }

        private void flyoutAddPerson_ClosingFinished(object sender, RoutedEventArgs e)
        {
            mutex.WaitOne();
            isProcessing = false;
            mutex.ReleaseMutex();
        }



    }

}
