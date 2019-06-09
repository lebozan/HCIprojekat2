using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ResourcesApplication.Commands
{
    class RoutedCommands
    {

        public static readonly RoutedUICommand AddTag = new RoutedUICommand(
            "Add Tag",
            "AddTag",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
            new KeyGesture(Key.D, ModifierKeys.Control | ModifierKeys.Alt)
            }
            );
        public static readonly RoutedUICommand ShowTags = new RoutedUICommand(
           "Show Tags",
           "ShowTags",
           typeof(RoutedCommand),
           new InputGestureCollection()
           {
            new KeyGesture(Key.P, ModifierKeys.Control | ModifierKeys.Alt)
           }
           );

        public static readonly RoutedUICommand AddType = new RoutedUICommand(
           "Add Type",
           "AddType",
           typeof(RoutedCommand),
           new InputGestureCollection()
           {
            new KeyGesture(Key.D, ModifierKeys.Alt)
           }
           );
        public static readonly RoutedUICommand ShowTypes = new RoutedUICommand(
                   "Show Types",
                   "ShowTypes",
                   typeof(RoutedCommand),
                   new InputGestureCollection()
                   {
                new KeyGesture(Key.P, ModifierKeys.Alt)
                   }
                   );

        public static readonly RoutedUICommand AddResource = new RoutedUICommand(
                  "Add Resource",
                  "AddResource",
                  typeof(RoutedCommand),
                  new InputGestureCollection()
                  {
                new KeyGesture(Key.D, ModifierKeys.Control)
                  }
                  );

        public static readonly RoutedUICommand ShowResources = new RoutedUICommand(
                  "Show Resources",
                  "ShowResources",
                  typeof(RoutedCommand),
                  new InputGestureCollection()
                  {
                new KeyGesture(Key.P, ModifierKeys.Control)
                  }
                  );
        public static readonly RoutedUICommand EditResources = new RoutedUICommand(
              "Edit Resources",
              "EditResources",
              typeof(RoutedCommand),
              new InputGestureCollection()
              {
                new KeyGesture(Key.I, ModifierKeys.Control)
              }
              );

        public static readonly RoutedUICommand DeleteResources = new RoutedUICommand(
                 "Delete Resources",
                 "DeleteResources",
                 typeof(RoutedCommand),
                 new InputGestureCollection()
                 {
                new KeyGesture(Key.O, ModifierKeys.Control)
                 }
                 );

        public static readonly RoutedUICommand EditTypes = new RoutedUICommand(
               "Edit Types",
               "EditTypes",
               typeof(RoutedCommand),
               new InputGestureCollection()
               {
                new KeyGesture(Key.I, ModifierKeys.Alt)
               }
               );

        public static readonly RoutedUICommand DeleteTypes = new RoutedUICommand(
               "Delete Types",
               "DeleteTypes",
               typeof(RoutedCommand),
               new InputGestureCollection()
               {
                new KeyGesture(Key.O, ModifierKeys.Alt)
               }
               );

        public static readonly RoutedUICommand EditTags = new RoutedUICommand(
              "Edit Tags",
              "EditTags",
              typeof(RoutedCommand),
              new InputGestureCollection()
              {
                new KeyGesture(Key.I, ModifierKeys.Control | ModifierKeys.Alt)
              }
              );
        public static readonly RoutedUICommand DeleteTags = new RoutedUICommand(
              "Delete Tags",
              "DeleteTags",
              typeof(RoutedCommand),
              new InputGestureCollection()
              {
                new KeyGesture(Key.O, ModifierKeys.Control | ModifierKeys.Alt)
              }
              );

        public static readonly RoutedUICommand SearchID = new RoutedUICommand(
                  "Search Resources by ID on Map",
                  "SearchID",
                  typeof(RoutedCommand),
                  new InputGestureCollection()
                  {
                new KeyGesture(Key.X, ModifierKeys.Alt)
                  }
                  );

        public static readonly RoutedUICommand SearchName = new RoutedUICommand(
                 "Search Resources by Name on Map",
                 "SearchName",
                 typeof(RoutedCommand),
                 new InputGestureCollection()
                 {
                new KeyGesture(Key.C, ModifierKeys.Alt)
                 }
                 );
        public static readonly RoutedUICommand SearchTag = new RoutedUICommand(
                 "Search Resources by Tag on Map",
                 "SearchTag",
                 typeof(RoutedCommand),
                 new InputGestureCollection()
                 {
                new KeyGesture(Key.B, ModifierKeys.Alt)
                 }
                 );
        public static readonly RoutedUICommand SearchType = new RoutedUICommand(
                 "Search Resources by Type on Map",
                 "SearchType",
                 typeof(RoutedCommand),
                 new InputGestureCollection()
                 {
                new KeyGesture(Key.V, ModifierKeys.Alt)
                 }
                 );
        public static readonly RoutedUICommand Filter = new RoutedUICommand(
                 "Filter Resources by on Map",
                 "Filter",
                 typeof(RoutedCommand),
                 new InputGestureCollection()
                 {
                new KeyGesture(Key.F, ModifierKeys.Alt)
                 }
                 );
        public static readonly RoutedUICommand ShowAll = new RoutedUICommand(
                "Show All resources on map",
                "ShowAll",
                typeof(RoutedCommand),
                new InputGestureCollection()
                {
                new KeyGesture(Key.S, ModifierKeys.Alt)
                }
                );

    }





}
