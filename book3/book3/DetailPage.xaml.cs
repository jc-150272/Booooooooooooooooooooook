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


            //var query = UserModel.selectUserISBN(this.Isbn);
            if(UserModel.selectUserISBN(Isbn) != null){
                var query = UserModel.selectUserISBN(Isbn);

                foreach(var book in query){
                title = book.Title;
                }
            }else{
                DisplayAlert("表なし","表なし","OK");
            }
            
            /*
            foreach(var book in query){
                title = book.Title;
            }*/
          
        }

        var stackLayout = new StackLayout
{
    WidthRequest = 400,
    VerticalOptions = LayoutOptions.Center,
    HorizontalOptions = LayoutOptions.Center,
    Children =
    {
        //ラベルクラスのみのインスタンス生成
        new Label(),
 
        //ラベルのテキストに文字を設定
        new Label
        {
            Text = "あいうえおAIUEOaiueo曖昧模糊",
        },
 
        //ラベルにフォントを設定
        new Label
        {
            Text = "あいうえおAIUEOaiueo曖昧模糊",
            Font = Font.Default
        },
 
        //テキストを太字に設定
        new Label
        {
            Text = "あいうえおAIUEOaiueo曖昧模糊",
            FontAttributes = FontAttributes.Bold,
        },
 
        //フォントファミリを「Gulim」に設定
        new Label
        {
            Text = "あいうえおAIUEOaiueo曖昧模糊",
            FontFamily = "Gulim",
        },
 
        //フォントサイズを「20」に設定
        new Label
        {
            Text = "あいうえおAIUEOaiueo曖昧模糊",
            FontSize = 20,
        },
 
        //FormattedStringプロパティの設定
        new Label
        {
            FormattedText = new FormattedString
            {
                Spans =
                {
                    new Span
                    {
                        Text = "あいうえお",
                    },
                    new Span
                    {
                        Text = "AIUEO",
                        FontAttributes = FontAttributes.Bold,
                    },
                    new Span
                    {
                        Text = "aiueo",
                        ForegroundColor = Color.Yellow,
                    },
                    new Span
                    {
                        Text = "曖昧模糊",
                        FontSize = 30,
                    },
                },
            },
        },
 
        //テキストを中央寄せに設定
        new Label
        {
            Text = "あいうえおAIUEOaiueo曖昧模糊",
            HorizontalTextAlignment = TextAlignment.Center,
        },
 
        //折り返し方法を「CharacterWrap」に設定
        new Label
        {
            Text = "あいうえおAIUEOaiueo曖昧模糊",
            LineBreakMode = LineBreakMode.CharacterWrap,
        },
        
        //テキストの色を赤色に設定
        new Label
        {
            Text = "あいうえおAIUEOaiueo曖昧模糊",
            TextColor = Color.Red,
        },
 
        
        //テキストの高さを中央寄せに設定
        new Label
        {
            Text = "あいうえおAIUEOaiueo曖昧模糊",
            VerticalTextAlignment = TextAlignment.Center,
        },
    },
};
 
this.Content = stackLayout;

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