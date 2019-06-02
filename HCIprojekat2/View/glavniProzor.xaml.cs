﻿using System;
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
using System.Windows.Shapes;
using System.ComponentModel;
using Microsoft.Win32;

namespace HCIprojekat2.View
{
    /// <summary>
    /// Interaction logic for glavniProzor.xaml
    /// </summary>
    public partial class GlavniProzor : Window, INotifyPropertyChanged
    {

        #region PropertyChangedNotifier
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private ImageSource _image;

        public ImageSource Image
        {
            get
            {
                return _image;
            }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged("Image");
                }
            }
        }

        private static RoutedCommand loadImage = new RoutedCommand();
        public GlavniProzor()
        {
            InitializeComponent();

            loadImage.InputGestures.Add(new KeyGesture(Key.F2));

            CommandBinding cb = new CommandBinding(loadImage);
            cb.Executed += new ExecutedRoutedEventHandler(LoadHandler);
            this.CommandBindings.Add(cb);
            //CommandBinding nam omogućava da ako se neka komanda izvrši
            //da prikačimo događaje za razne momente u izvršavanju komande
            Image = new BitmapImage(new Uri("../../mapasveta.jpg", UriKind.Relative));
            this.DataContext = this;
        }

        private void LoadHandler(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images|*.jpg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string url = openFileDialog.FileName;
                Image = new BitmapImage(new Uri(url, UriKind.Absolute));
            }
        }

    }
}
