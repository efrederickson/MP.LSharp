using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LSharp.Studio
{
    public partial class SplashScreen : Form
    {
        #region Constructors

        public SplashScreen()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public string LoadingMsg
        {
            get { return lblLoadingMessage.Text; }
            set
            {
                lblLoadingMessage.Text = value;
                lblLoadingMessage.Left = this.Width - lblLoadingMessage.Width - 10;
                Application.DoEvents();
            }
        }

        #endregion
    }
}