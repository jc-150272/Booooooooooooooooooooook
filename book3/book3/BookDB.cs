﻿using System;
using System.Collections.Generic;
using SQLite;

namespace book3
{
    //テーブル名を指定
    [Table("BookDB")]
    public class BookDB
    {
        //プライマリキー
        [PrimaryKey]
        //ISBN列
        public string ISBN { get; set; }
        //Title列
        public string Title { get; set; }
        //TitleKana列
        public string TitleKana { get; set; }
        //ItemCaption列
        public string ItemCaption { get; set; }
        //author列
        public string Author { get; set; }


        //--------------------------insert文的なの--------------------------
        public static void InsertBook(string isbn, string title, string titleKana, string itemCaption, string author)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにBookテーブルを作成する
                    db.CreateTable<BookDB>();

                    db.Insert(new BookDB() { ISBN = isbn, Title = title, TitleKana = titleKana, ItemCaption = itemCaption, Author = author });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        //BookテーブルのBookを削除するメソッド
        //--------------------------delete文的なの--------------------------
        public static void DeleteBook(string isbn)
        {

            //データベースに接続
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                //db.BeginTransaction();  //このサイト https://qiita.com/alzybaad/items/9356b5a651603a548278
                try
                {
                    db.CreateTable<BookDB>();
                    db.DropTable<BookDB>(); //dropテーブル

                    //db.Delete(isbn);
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }

        }

        //-----------------------以下selectメソッド--------------------------
        //全部表示
        public static List<BookDB> Select_all()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<BookDB>("SELECT * FROM [BookDB] order by [Title] desc limit 30");

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        //titleのみ表示
        public static List<BookDB> Select_title()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<BookDB>("SELECT [Title] FROM [BookDB] order by [Title] desc limit 30");

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        //titleをcountする
        public static List<BookDB> Select_title_count()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<BookDB>("SELECT count([Title]) FROM [BookDB] desc limit 30");

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }
    }
}
