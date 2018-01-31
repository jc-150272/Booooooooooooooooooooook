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
        int read;
        int redstar;
        int bluebook;


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
                read = book.Read;
                }
            }else{
                DisplayAlert("表なし","表なし","OK");
            }
            titledayo.Text = title;
            
            if (bluebook == 1)
            {
                this.image1.Image = "blue_book_72.png";
            }

            else
            {
                this.image1.Image = "gray_book_72.png";
            }

            if (redstar == 1)
            {
                this.image2.Image = "red_star_72.png";
            }
          
            else
            {
                this.image2.Image = "gray_star_72.png";
            }

            if (read == 0)
            {
                this.unread2.Text = "未読";
                unread1.IsToggled = false;
            }

            if (read == 1)
            {
                this.unread2.Text = "既読";
                unread1.IsToggled= true;
            }
        }


        // 読みたいボタンを点滅させる
        private void OnImageClicked1(object sender, EventArgs e)
        {
            if (bluebook == 1)
            {
                UserModel.Gray_Book(Isbn);
                this.image1.Image = "gray_book_72.png";
                bluebook = 0;
            }

            else
            {
                UserModel.Blue_Book(Isbn);
                this.image1.Image = "blue_book_72.png";
                bluebook = 1;
            }
        }

        // お気にいりボタンを点滅させる
        private void OnImageClicked2(object sender, EventArgs e)
        {
            if (redstar == 1)
            {
                UserModel.Gray_Star(Isbn);
                this.image2.Image = "red_star_72.png";
                redstar = 0;
            }

            else
            {
                UserModel.Red_Star(Isbn);
                this.image2.Image = "gray_star_72.png";
                redstar = 1;
            }
        }

        // ラベルを未読⇔既読にする
        private void OnToggled(object sender, ToggledEventArgs e)
        {
            if (unread1.IsToggled == true)
            {
                UserModel.ReadBook(Isbn);
                this.unread2.Text = "既読";
            }
            if (unread1.IsToggled == false)
            {
                UserModel.UnreadBook(Isbn);
                this.unread2.Text = "未読";
            }
        }
    }
}