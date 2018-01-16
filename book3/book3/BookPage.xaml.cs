using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace book3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage
    {
        public BookPage()
        {
            InitializeComponent();

            ObservableCollection<Book> items = new ObservableCollection<Book>();
            items.Add(new Book { Name = "John Doe", Value = 4.0, BlueBook = true, RedStar = true });
            items.Add(new Book { Name = "Jane Doe", Value = 3.5, BlueBook = true, RedStar = false });
            items.Add(new Book { Name = "Sammy Doe", Value = 2.5, BlueBook = false, RedStar = false });

            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Value <= 0.25)
                {
                    items[i].ValueImage = "value_0.png";
                }

                else if (items[i].Value <= 0.75)
                {
                    items[i].ValueImage = "value_0.5.png";
                }

                else if (items[i].Value <= 1.25)
                {
                    items[i].ValueImage = "value_1.png";
                }

                else if (items[i].Value <= 1.75)
                {
                    items[i].ValueImage = "value_1.5.png";
                }

                else if (items[i].Value <= 2.25)
                {
                    items[i].ValueImage = "value_2.png";
                }

                else if (items[i].Value <= 2.75)
                {
                    items[i].ValueImage = "value_2.5.png";
                }

                else if (items[i].Value <= 3.25)
                {
                    items[i].ValueImage = "value_3.png";
                }

                else if (items[i].Value <= 3.75)
                {
                    items[i].ValueImage = "value_3.5.png";
                }

                else if (items[i].Value <= 4.25)
                {
                    items[i].ValueImage = "value_4.png";
                }

                else if (items[i].Value <= 4.75)
                {
                    items[i].ValueImage = "value_4.5.png";
                }

                else
                {
                    items[i].ValueImage = "value_5.png";
                }


                if (items[i].RedStar == true)
                {
                    items[i].RedStar2 = "red_star_72.png";
                }

                if (items[i].BlueBook == true)
                {
                    items[i].BlueBook2 = "blue_book_72.png";
                }

            }

            BookListView.ItemsSource = items;
            BookListView.HasUnevenRows = true;

            BookListView.ItemSelected += (s, e) => {
                Book tmp;
                if (_index != -1) {
                    tmp = data.ar[_index];
                    tmp.Expand = false;
                    data.ar[_index] = tmp;
                }

                _index = data.ar.IndexOf(e.SelectedItem as OneData);
                if (_index != -1) {
                    tmp = data.ar[_index];
                    tmp.Expand = true;
                    data.ar[_index] = tmp;
                }

            };

        }

        class PreserveAttribute : System.Attribute{
            public bool Conditional { get; set; }
}
        class MyCell : ViewCell {
            }

            View CreateExpandView() {

            var name = new Label { FontSize = 12 };
            name.SetBinding(Label.TextProperty, "Name");

            var value = new Label { FontSize = 12 };
            value.SetBinding(Label.TextProperty, "Value");

            var layout = new StackLayout {
                Children = { name,value }
            };
            return new StackLayout() {
                Padding = new Thickness(5),
                Orientation = StackOrientation.Horizontal //横に並べる
            };
        }

        protected override void OnBindingContextChanged() {
            base.OnBindingContextChanged();
            if (BindingContext == null) {
                return;
            }
            var data = (Book)BindingContext;

            var expand = data.Expand;

            if (expand) {
                Height = 150;
                View = CreateExpandView();

            }


        }

    }

        public class Book
    {
        public int ISBN { get; set; }

        public string Name { get; set; }

        public double Value { get; set; }

        public string ValueImage { get; set; }

        public bool RedStar { get; set; }

        public string RedStar2 { get; set; }

        public bool BlueBook { get; set; }

        public string BlueBook2 { get; set; }

    }

    public Book()
    {
        Expand = false; // <=詳細表示中かどうかのフラグ
    }
}
