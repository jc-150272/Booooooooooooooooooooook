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

        public DetailPage(string isbn)
        {
            InitializeComponent();
            this.Isbn = isbn;
            var query = UserModel.selectUserISBN(this.Isbn);

            foreach(var book in query){
                title = book.Title;
            }
            /*ここからわかんね上の変数に全部データを格納したい*/
        }

        // 読みたいボタンを点滅させる
        private void OnImageClicked1(object sender, EventArgs e)
        {
            if (bluebook == true)
            {
                UserModel.Blue_Book(this.Isbn);
                this.image1.Image = "blue_book_72.png";
                bluebook = false;
            }

            else
            {
                UserModel.Gray_Book(this.Isbn);
                this.image1.Image = "gray_book_72.png";
                bluebook = true;
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