using Newtonsoft.Json;
using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace book3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage
    {        
        public ObservableCollection<Book> items = new ObservableCollection<Book>();
        public BookPage()
        {
            InitializeComponent();

            UserModel.insertUser("111111111111", "美味しんぼaaaaaaaaaaaaaaaaaaaaaaaa", "おいしんぼ","a");
            UserModel.insertUser("222222222222","クッキングパパ","くっきんぐぱぱ","b");

             if (UserModel.selectUser() != null)
            {
                var query = UserModel.selectUser();
                var titleList = new List<String>();
                var isbnList = new List<String>();
                var RedList = new List<int>();
                var BlueList = new List<int>();
                //*をリストにぶち込んで個数分addするのでもいいのでは
                foreach (var user in query)
                {
                    titleList.Add(user.Title);
                    isbnList.Add(user.ISBN);
                    RedList.Add(user.RedStar);
                    BlueList.Add(user.BlueBook);
                }
                for (var j = 0; j < query.Count; j++)
                {
                    items.Add(new Book { 
                        Name = titleList[j],ISBN = isbnList[j], RedStar = RedList[j], BlueBook = BlueList[j],});

                }
            }
            else
            {
                items.Add(new Book { Name = "空やで" });
            }


            for (var i = 0; i < items.Count; i++)
            {

                if (items[i].RedStar == 1)
                {
                    items[i].RedStar2 = "red_star_72.png";
                }

                if (items[i].BlueBook == 1)
                {
                    items[i].BlueBook2 = "blue_book_72.png";
                }

            }

            BookListView.ItemsSource = items;
        }

        public class Book
        {
        public string ISBN { get; set; }

        public string Name { get; set; }

        public int RedStar { get; set; }

        public string RedStar2 { get; set; }

        public int BlueBook { get; set; }

        public string BlueBook2 { get; set; }

        }

        private void BookDetail(object sender, ItemTappedEventArgs e)
        {

        Book book = (Book)BookListView.SelectedItem;
        string isbn = book.ISBN;

        Navigation.PushAsync(new DetailPage(isbn));
        }


    
        /// <summary>
        /// リフレッシュ時に呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnRefreshing(object sender, EventArgs e)
        {
            //2秒処理を待つ
            await Task.Delay(2000);
            items.Clear();

            if (UserModel.selectUser() != null)
            {
                var query = UserModel.selectUser();
                var titleList = new List<String>();
                var isbnList = new List<String>();
                var RedList = new List<int>();
                var BlueList = new List<int>();
                //*をリストにぶち込んで個数分addするのでもいいのでは
                foreach (var user in query)
                {
                    titleList.Add(user.Title);
                    isbnList.Add(user.ISBN);
                    RedList.Add(user.RedStar);
                    BlueList.Add(user.BlueBook);
                }
                for (var j = 0; j < query.Count; j++)
                {
                    items.Add(new Book { 
                        Name = titleList[j],ISBN = isbnList[j], RedStar = RedList[j], BlueBook = BlueList[j],});

                }
            }
            else
            {
                items.Add(new Book { Name = "空やで" });
            }


            for (var i = 0; i < items.Count; i++)
            {

                if (items[i].RedStar == 1)
                {
                    items[i].RedStar2 = "red_star_72.png";
                }

                if (items[i].BlueBook == 1)
                {
                    items[i].BlueBook2 = "blue_book_72.png";
                }

            }

            BookListView.ItemsSource = items;

            //リフレッシュを止める
            this.BookListView.IsRefreshing = false;
        }

        private async void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Task.Delay(2000);
            items.Clear();
            
            string terms;

            if (picker.SelectedIndex == 0)
            {
                terms = "TitleKana";
                var query = UserModel.sortAsc(terms);
            }
            else if (picker.SelectedIndex == 1)
            {
                terms = "TitleKana";
                var query = UserModel.sortDesc(terms);
            }
            else if (picker.SelectedIndex == 2)
            {
                terms = "AuthorKana";
                var query = UserModel.sortAsc(terms);
            }
            else if (picker.SelectedIndex == 3)
            {
                terms = "AuthorKana";
                var query = UserModel.sortDesc(terms);
            }
            else if (picker.SelectedIndex == 4)
            {
                terms = "SalesDate";
                var query = UserModel.sortAsc(terms);
            }
            else if (picker.SelectedIndex == 5)
            {
                terms = "SalesDate";
                var query = UserModel.sortDesc(terms);
            }
            else if (picker.SelectedIndex == 6)
            {
                terms = "Date";
                var query = UserModel.sortAsc(terms);
            }
            else if (picker.SelectedIndex == 7)
            {
                terms = "Date";
                var query = UserModel.sortDesc(terms);
            }


                var titleList = new List<String>();
                var isbnList = new List<String>();
                var RedList = new List<int>();
                var BlueList = new List<int>();
                //*をリストにぶち込んで個数分addするのでもいいのでは
                foreach (var user in query)
                {
                    titleList.Add(user.Title);
                    isbnList.Add(user.ISBN);
                    RedList.Add(user.RedStar);
                    BlueList.Add(user.BlueBook);
                }
                for (var j = 0; j < query.Count; j++)
                {
                    items.Add(new Book { 
                        Name = titleList[j],ISBN = isbnList[j], RedStar = RedList[j], BlueBook = BlueList[j],});

                }


            for (var i = 0; i < items.Count; i++)
            {

                if (items[i].RedStar == 1)
                {
                    items[i].RedStar2 = "red_star_72.png";
                }

                if (items[i].BlueBook == 1)
                {
                    items[i].BlueBook2 = "blue_book_72.png";
                }

            }

            BookListView.ItemsSource = items;

            //リフレッシュを止める
            this.BookListView.IsRefreshing = false;
        
        }
    }

}
    
