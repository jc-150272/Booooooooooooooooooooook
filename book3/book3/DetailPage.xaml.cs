using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace book3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{

        // ボタンとスイッチの判定
        string Isbn;
        string title;
        string titlekana;
        string itemcaption;
        string author;
        string publishername;
        string genre;
        int value;
        bool read;
        bool redstar;
        bool bluebook;
        bool bluebook2;

        public DetailPage(string isbn)
        {
            InitializeComponent();
            //var query = UserModel.selectUserISBN(this.Isbn);
            
            Isbn = isbn;
            if(UserModel.selectUserISBN(isbn) != null){
                var query = UserModel.selectUserISBN(isbn);

                foreach(var book in query){
                title = book.Title;
                bluebook = book.BlueBook;
                redstar = book.RedStar;
                }
            }else{
                DisplayAlert("表なし","表なし","OK");
            }
            titledayo.Text = title;
            
            if (bluebook == true)
            {
                this.image1.Image = "blue_book_72.png";
            }

            else
            {
                this.image1.Image = "gray_book_72.png";
            }

            if (redstar == true)
            {
                this.image2.Image = "red_star_72.png";
            }
          
            else
            {
                this.image2.Image = "gray_star_72.png";
            }

        }

        private void Buttondayo(object sender, EventArgs e)
        {
            DisplayAlert("isbn",Isbn,"ok");
        }

        // 読みたいボタンを点滅させる
        private void OnImageClicked1(object sender, EventArgs e)
        {
            if (bluebook == true)
            {
                UserModel.Gray_Book(Isbn);
                this.image1.Image = "gray_book_72.png";
                bluebook = false;
                var query = UserModel.selectUserISBN(Isbn);
                foreach(var book in query){
                bluebook2 = book.BlueBook;
                }
                if(bluebook2 == false){
                    DisplayAlert("falseが格納されてるよ","BB","CC");
                }
            }

            else
            {
                UserModel.Blue_Book(Isbn);
                this.image1.Image = "blue_book_72.png";
                bluebook = true;
                var query = UserModel.selectUserISBN(Isbn);
                foreach(var book in query){
                bluebook2 = book.BlueBook;
                }
                if(bluebook2 == true){
                    DisplayAlert("trueが格納されてるよ","BB","CC");
                }
            }
        }

        // お気にいりボタンを点滅させる
        private void OnImageClicked2(object sender, EventArgs e)
        {
            if (redstar == true)
            {
                this.image2.Image = "red_star_72.png";
                redstar = false;
            }

            else
            {
                this.image2.Image = "gray_star_72.png";
                redstar = true;
            }
        }

        // ラベルを未読⇔既読にする
        private void OnToggled(object sender, ToggledEventArgs e)
        {
            if (unread1.IsToggled == true)
            {
                this.unread2.Text = "既読";
            }
            if (unread1.IsToggled == false)
            {
                this.unread2.Text = "未読";
            }
        }
    }
}