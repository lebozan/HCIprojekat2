using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

using ResourcesApplication.Beans;
using ResourcesApplication.Html;

namespace ResourcesApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TempWindow : Window
    {
        private string CURRENT_MAP;
        private Double zoomMax = 5;
        private Double zoomMin = 0.5;
        private Double zoomSpeed = 0.001;
        private Double zoom = 1;

        public Database database { get; set; }
        private ObservableCollection<Resource> resources;
        public ObservableCollection<Resource> Resources
        {
            get { return resources; }
            set
            {
                if (value != resources)
                {
                    resources = value;
                    OnPropertyChanged("Resources");
                }
            }
        }

        public static ObservableCollection<Resource> resourcesToShow;
        public ObservableCollection<Resource> ResourcesToShow
        {
            get { return resourcesToShow; }
            set
            {
                if (value != resourcesToShow)
                {
                    resourcesToShow = value;
                    OnPropertyChanged("ResourcesToShow");
                }
            }
        }

        private ObservableCollection<ResourceType> resourcesType;
        public ObservableCollection<ResourceType> ResourcesType
        {
            get { return resourcesType; }
            set
            {
                if (value != resourcesType)
                {
                    resourcesType = value;
                    OnPropertyChanged("ResourcesType");
                }
            }
        }

        private Resource selectedResource;
        public Resource SelectedResource
        {
            get { return selectedResource; }
            set
            {
                if (value != selectedResource)
                {
                    selectedResource = value;
                    OnPropertyChanged("SelectedResource");
                }
            }
        }

        private Resource ClickedResource;
        public TempWindow(string map)
        {
            InitializeComponent();
            database = new Database();
            database.serijalizacija.RESOURCES_DATA = map + ".bin";
            database.deserijalizacija.RESOURCES_DATA = map + ".bin";
            database.loadData();
            CURRENT_MAP = map;

            DataContext = this;
            Resources = database.Resources;
            ResourcesType = database.Types;
            addToResourcesToShow();
            ResourcePins_Draw();
        }
        private void PrikaziDokumentaciju_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void AddResource_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddResource addResource = new AddResource(this);
            addResource.Show();
            addToResourcesToShow();
        }

        public void addToResourcesToShow()
        {
            ResourcesToShow = new ObservableCollection<Resource>();
            foreach (Resource r in Resources)
            {

                if (r.X == -1 && r.Y == -1)
                {
                    ResourcesToShow.Add(r);
                }


            }

            listView.ItemsSource = null;
            listView.ItemsSource = ResourcesToShow;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddTag addTag = new AddTag(this);
            addTag.Show();
            addToResourcesToShow();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //AddResourceType type = new AddResourceType();
            //type.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddResource type = new AddResource(this);
            type.Show();
            addToResourcesToShow();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }
        private void ShowTypes_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ShowTypes showTypes = new ShowTypes(this);
            showTypes.Show();
        }

        private void AddTag_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddTag addTag = new AddTag(this);
            addTag.Show();
        }
        private void ShowTags_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ShowTags showTags = new ShowTags(this);
            showTags.Show();
        }

        private void DeleteResources_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DeleteResources del = new DeleteResources(this);
            del.Show();
            addToResourcesToShow();
        }

        private void EditTypes_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            EditTypes edit = new EditTypes(this);
            edit.Show();
            addToResourcesToShow();
        }

        private void EditResources_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            EditResources edit = new EditResources(this);
            edit.Show();
            addToResourcesToShow();
        }

        private void EditTags_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            EditTags edit = new EditTags(this);
            edit.Show();
            addToResourcesToShow();
        }

        private void DeleteTypes_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DeleteTypes edit = new DeleteTypes(this);
            edit.Show();
            addToResourcesToShow();
        }

        private void DeleteTags_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DeleteTags addType = new DeleteTags(this);
            addType.Show();
            addToResourcesToShow();
        }

        private void AddType_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddType addType = new AddType(this);
            addType.Show();
            addToResourcesToShow();
        }



        private void ShowResources_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ShowResources showResources = new ShowResources(this);
            showResources.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private Point startPoint = new Point();

        private void Map_MouseMove(object sender, MouseEventArgs e)

        {
            Point mousePosition = e.GetPosition(Map);
            Vector diff = startPoint - mousePosition;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Resource resource = Resource_Click((int)mousePosition.X, (int)mousePosition.Y);

                if (resource != null)
                {
                    resourcesToShow.Remove(resource);
                    Console.WriteLine("Resource id: ", resource.Id);
                    DataObject dragData = new DataObject("resource", resource);
                    DragDrop.DoDragDrop(Map, dragData, DragDropEffects.Move);
                }
            }
        }

        private void Map_DragEnter(object sender, DragEventArgs e)
        {

            if (!e.Data.GetDataPresent("resource") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Map_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("resource"))
            {
                Point dropPosition = e.GetPosition(Map);
                Resource resourcePin = e.Data.GetData("resource") as Resource;
                Console.WriteLine("U petom id resursa je " + resourcePin.Id);
                Resource resourceOnThatPosition = Resource_Click((int)dropPosition.X, (int)dropPosition.Y);
                resourcesToShow.Remove(resourcePin);
                if (resourceOnThatPosition != null && !resourcePin.Id.Equals(resourceOnThatPosition.Id))
                {
                    resourcePin.X = (int)dropPosition.X + 30;
                    resourcePin.Y = (int)dropPosition.Y + 30;
                }
                // if it is close to the edge, move it a little bit
                else if ((int)dropPosition.Y > -30 && (int)dropPosition.Y < 10)
                {
                    resourcePin.X = (int)dropPosition.X - 30;
                    resourcePin.Y = (int)dropPosition.Y + 15;
                }
                else if ((int)dropPosition.X > -30 && (int)dropPosition.X < 10)
                {
                    resourcePin.X = (int)dropPosition.X + 15;
                    resourcePin.Y = (int)dropPosition.Y - 30;
                }
                else
                {
                    resourcePin.X = (int)dropPosition.X - 30;
                    resourcePin.Y = (int)dropPosition.Y - 30;
                }

                Console.WriteLine("Na kraju petog resourcePinX" + resourcePin.X + " resourcePin.Y " + resourcePin.Y);
                database.UpdateResource(resourcePin.Id, resourcePin);
                ResourcePins_Draw();
            }
        }

        private void MapZoom_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            zoom += zoomSpeed * e.Delta; // Ajust zooming speed (e.Delta = Mouse spin value )
            if (zoom < zoomMin) { zoom = zoomMin; } // Limit Min Scale
            if (zoom > zoomMax) { zoom = zoomMax; } // Limit Max Scale

            Point mousePos = e.GetPosition(Map);

            if (zoom > 1)
            {
                Map.RenderTransform = new ScaleTransform(zoom, zoom, mousePos.X, mousePos.Y); // transform Canvas size from mouse position
            }
            else
            {
                Map.RenderTransform = new ScaleTransform(zoom, zoom); // transform Canvas size
            }

        }
        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("SESTO");
            startPoint = e.GetPosition(null);
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.GetPosition(null);
            Vector diff = startPoint - mousePosition;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                if (SelectedResource != null)
                {
                    ListView listView = sender as ListView;
                    Resource resource = SelectedResource;
                    DataObject dragData = new DataObject("resource", resource);
                    DragDrop.DoDragDrop(listView, dragData, DragDropEffects.Move);
                    if (ResourcesToShow != null)
                    {
                        foreach (Resource r in ResourcesToShow)
                        {
                            if (r.Id == resource.Id)
                            {
                                ResourcesToShow.Remove(r);
                                break;
                            }

                        }
                    }
                }

            }
        }

        private Resource Resource_Click(int x, int y)
        {
            foreach (Resource resource in Resources)
            {
                if (resource.X != -1 && resource.Y != -1)
                {
                    if (Math.Sqrt(Math.Pow((x - resource.X - 15), 2) + Math.Pow((y - resource.Y - 15), 2)) < 20)
                    {
                        return resource;
                    }
                }
            }
            return null;

        }

        public void ResourcePins_Draw()
        {
            Map.Children.Clear();
            foreach (Resource resource in Resources)
            {
                if (resource.X != -1 && resource.Y != -1)
                {
                    Console.WriteLine("OD PRONADJENOG X i Y su " + resource.X + " " + resource.Y);
                    Console.WriteLine("OD PRONADJ " + resource.Id);
                    Image ResourceIcon = new Image();
                    ResourceIcon.Width = 30;
                    ResourceIcon.Height = 30;
                    ResourceIcon.ToolTip = "Id resursa: " + resource.Id + "\nZa vise informacija pritisnite desni klik misa ";

                    if (File.Exists(resource.IconPath))
                    {
                        ResourceIcon.Source = new BitmapImage(new Uri(resource.IconPath, UriKind.Absolute));
                    }
                    else
                    {
                        MessageBox.Show("Došlo je do greške pri učitavanju ikonice resursa, molimo dodajte novu ikonicu!", "Došlo je do greške!");
                        //EditManifestation edit = new EditManifestation(resource.Id);
                        //edit.ShowDialog();
                        break;
                    }

                    Map.Children.Add(ResourceIcon);
                    ContextMenu cm = new ContextMenu();
                    MenuItem m1 = new MenuItem();
                    MenuItem m3 = new MenuItem();
                    m3.Header = "Vrati resurs u listu (resurs nece biti prikazan na mapi)";
                    m3.Click += new RoutedEventHandler(return_to_list);
                    MenuItem m4 = new MenuItem();
                    m4.Header = "Kopiraj resurs na drugu mapu";
                    m4.Click += new RoutedEventHandler(copy_Click);
                    cm.Items.Add(m3);
                    cm.Items.Add(m4);
                    ResourceIcon.ContextMenu = cm;

                    Canvas.SetLeft(ResourceIcon, resource.X);
                    Canvas.SetTop(ResourceIcon, resource.Y);

                }
            }

            // To scroll down in list, for easier drag and dropping recent item
            if (listView != null && listView.Items.Count != 0)
            {
                listView.ScrollIntoView(listView.Items.GetItemAt(listView.Items.Count - 1));
            }
        }

        public void ResourcePins_Draw2(List<Resource> res)
        {
            Map.Children.Clear();
            foreach (Resource resource in res)
            {
                if (resource.X != -1 && resource.Y != -1)
                {
                    //Console.WriteLine("OD PRONADJENOG X i Y su " + resource.X + " " + resource.Y);
                    //Console.WriteLine("OD PRONADJ " + resource.Id);
                    Image ResourceIcon = new Image();
                    ResourceIcon.Width = 30;
                    ResourceIcon.Height = 30;
                    ResourceIcon.ToolTip = "Id resursa: " + resource.Id + "\nZa vise informacija pritisnite desni klik misa ";

                    if (File.Exists(resource.IconPath))
                    {
                        ResourceIcon.Source = new BitmapImage(new Uri(resource.IconPath, UriKind.Absolute));
                    }
                    else
                    {
                        MessageBox.Show("Došlo je do greške pri učitavanju ikonice manifestacije, molimo dodajte novu ikonicu!", "Došlo je do greške!");
                        //EditManifestation edit = new EditManifestation(resource.Id);
                        //edit.ShowDialog();
                        break;
                    }

                    Map.Children.Add(ResourceIcon);
                    ContextMenu cm = new ContextMenu();
                    MenuItem m1 = new MenuItem();
                    m1.Header = "Obrisi resurs";
                    m1.Click += new RoutedEventHandler(delete_Click);
                    MenuItem m2 = new MenuItem();
                    m2.Header = "Izmeni resurs";
                    m2.Click += new RoutedEventHandler(edit_Click);
                    MenuItem m3 = new MenuItem();
                    m3.Header = "Vrati resurs u listu (resurs nece biti prikazan na mapi)";
                    m3.Click += new RoutedEventHandler(return_to_list);
                    MenuItem m4 = new MenuItem();
                    m4.Header = "Kopiraj resurs na drugu mapu";
                    m4.Click += new RoutedEventHandler(copy_Click);
                    cm.Items.Add(m1);
                    cm.Items.Add(m2);
                    cm.Items.Add(m3);
                    cm.Items.Add(m4);
                    ResourceIcon.ContextMenu = cm;

                    Canvas.SetLeft(ResourceIcon, resource.X);
                    Canvas.SetTop(ResourceIcon, resource.Y);

                }
            }

            // To scroll down in list, for easier drag and dropping recent item
            if (listView != null && listView.Items.Count != 0)
            {
                listView.ScrollIntoView(listView.Items.GetItemAt(listView.Items.Count - 1));
            }
        }

        public void delete_Click(Object sender, RoutedEventArgs e)
        {
            MenuItem mnu = sender as MenuItem;
            Image img = null;
            if (mnu != null)
            {
                img = ((ContextMenu)mnu.Parent).PlacementTarget as Image;
            }
            String tip = (String)img.ToolTip;
            string[] elems = tip.Split(null);
            Resource r = null;
            foreach (Resource res in Resources)
            {
                if (String.Equals(res.Id, elems[2]))
                {
                    res.X = -1;
                    res.Y = -1;
                    r = res;
                    break;

                }

            }

        }

        public void edit_Click(Object sender, RoutedEventArgs e)
        {
            MenuItem mnu = sender as MenuItem;
            Image img = null;
            if (mnu != null)
            {
                img = ((ContextMenu)mnu.Parent).PlacementTarget as Image;
            }
            String tip = (String)img.ToolTip;
            string[] elems = tip.Split(null);
            Resource r = null;
            foreach (Resource res in Resources)
            {
                if (String.Equals(res.Id, elems[2]))
                {
                    res.X = -1;
                    res.Y = -1;
                    r = res;
                    break;

                }

            }
        }

        public void copy_Click(Object sender, RoutedEventArgs e)
        {
            MenuItem mnu = sender as MenuItem;
            Image img = null;
            if (mnu != null)
            {
                img = ((ContextMenu)mnu.Parent).PlacementTarget as Image;
            }
            String tip = (String)img.ToolTip;
            string[] elems = tip.Split(null);
            Resource r = null;
            foreach (Resource res in Resources)
            {
                if (String.Equals(res.Id, elems[2]))
                {
                    res.X = -1;
                    res.Y = -1;
                    r = res;
                    break;

                }

            }

            if (r != null)
            {
                MainWindow.resourceForCopy = r;
            }

        }

        public void paste_Click(Object sender, RoutedEventArgs e)
        {
            if (MainWindow.resourceForCopy != null)
            {
                Point pointToWindow = Mouse.GetPosition(this);
                pointToWindow.X -= 250;
                Resource resourcePin = MainWindow.resourceForCopy;
                Resource resourceOnThatPosition = Resource_Click((int)pointToWindow.X, (int)pointToWindow.Y);

                if (resourceOnThatPosition != null && !resourcePin.Id.Equals(resourceOnThatPosition.Id))
                {
                    resourcePin.X = (int)pointToWindow.X + 30;
                    resourcePin.Y = (int)pointToWindow.Y + 30;
                }
                // if it is close to the edge, move it a little bit
                else if ((int)pointToWindow.Y > -30 && (int)pointToWindow.Y < 10)
                {
                    resourcePin.X = (int)pointToWindow.X - 30;
                    resourcePin.Y = (int)pointToWindow.Y + 15;
                }
                else if ((int)pointToWindow.X > -30 && (int)pointToWindow.X < 10)
                {
                    resourcePin.X = (int)pointToWindow.X + 15;
                    resourcePin.Y = (int)pointToWindow.Y - 30;
                }
                else
                {
                    resourcePin.X = (int)pointToWindow.X;
                    resourcePin.Y = (int)pointToWindow.Y;
                }

                Console.WriteLine("Na kraju petog resourcePinX" + resourcePin.X + " resourcePin.Y " + resourcePin.Y);
                bool postoji = false;
                foreach (Resource r in Resources)
                {
                    if (String.Equals(r.Id, resourcePin.Id))
                    {
                        postoji = true;
                        break;
                    }

                }
                if (postoji == false)
                {
                    database.AddResource(resourcePin);
                }

                else
                {

                    database.UpdateResource(resourcePin.Id, resourcePin);
                }

                addToResourcesToShow();

                ResourcePins_Draw();

            }
            else
            {
                MessageBox.Show("Da biste nalepili resurs ovde prvo trebate da ga kopirate.");
            }

        }

        public void return_to_list(Object sender, RoutedEventArgs e)
        {
            MenuItem mnu = sender as MenuItem;
            Image img = null;
            if (mnu != null)
            {
                img = ((ContextMenu)mnu.Parent).PlacementTarget as Image;
            }
            String tip = (String)img.ToolTip;
            string[] elems = tip.Split(null);
            Resource r = null;
            foreach (Resource res in Resources)
            {
                if (String.Equals(res.Id, elems[2]))
                {
                    res.X = -1;
                    res.Y = -1;
                    r = res;
                    break;

                }

            }


            if (r != null)
            {
                database.UpdateResource(r.Id, r);
                ResourcesToShow.Add(r);
            }

            ResourcePins_Draw();
        }

        private void SearchID_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IdSearch searh = new IdSearch(this);
            searh.Show();
        }

        private void SearchName_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            NameSearch searh = new NameSearch(this);
            searh.Show();
        }

        private void SearchTag_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TagSearch searh = new TagSearch(this);
            searh.Show();
        }

        private void SearchType_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TypeSearch searh = new TypeSearch(this);
            searh.Show();
        }

        private void Filter_Executed(object sender, ExecutedRoutedEventArgs e)
        {
           // Filter searh = new Filter(this);
           // searh.Show();
        }

        private void ShowAll_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ResourcePins_Draw();
        }


        private void Help_Click(object sender, RoutedEventArgs e)
        {
            HtmlHelp help = new HtmlHelp("MainWindow", this);
            help.Show();
        }

        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(this);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
            else
            {
                HelpProvider.ShowHelp(GetType().Name, this);
            }
        }
    }
}