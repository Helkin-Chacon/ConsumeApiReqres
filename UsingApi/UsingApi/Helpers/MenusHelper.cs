using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace UsingApi.Helpers
{
    public class MenusHelper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int id { get; set; }
        public string tittle { get; set; }

     

        private bool isSaved;

        public bool isselected
        {
            get
            {
                return isSaved;
            }
            set
            {
                if (value != isSaved)
                {
                    isSaved = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool istittle { get; set; }
        private Color color;

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                if (value != color)
                {
                    color = value;
                    OnPropertyChanged();
                }
            }
        }

        private int size;

        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                if (value != size)
                {
                    size = value;
                    OnPropertyChanged();
                }
            }
        }

        public int query { get; set; }
        public bool isaction { get; set; }
        public bool isindicative { get; set; }
        public List<MenusHelper> creation()
        {
            MenusHelper menus0 = new MenusHelper();
            MenusHelper menus1 = new MenusHelper();
            MenusHelper menus2 = new MenusHelper();
            MenusHelper menus3 = new MenusHelper();
            List<MenusHelper> ret = new List<MenusHelper>();

            menus0.id = 0;
            menus0.isselected = false;
            menus0.tittle = "PREV";
            menus0.isaction = true;
            menus0.isindicative = false;
            menus0.query = 1;

            menus0.Color = Color.FromHex("#80d7f9");
          
           
            ret.Add(menus0);

            menus1.id = 1;
            menus1.isselected = true;
            menus1.tittle = "1";
            menus1.Color = Color.White;
            menus1.isaction = false;
            menus1.isindicative = true;
            menus1.size = 10;
            ret.Add(menus1);

            menus2.id = 2;
            menus2.isselected = false;
            menus2.tittle = "2";
            menus2.Color = Color.LightGray;
            menus2.isaction = false;
            menus2.isindicative = true;
            menus2.size = 7;

            ret.Add(menus2);

            menus3.id = 3;
            menus3.isselected = false;
            menus3.tittle = "NEXT";
            menus3.Color = Color.FromHex("#80d7f9");
            menus3.query = 2;
            menus3.isindicative = false;
            menus3.isaction = true;


            ret.Add(menus3);


            return ret;
        }
    }
}
