﻿using System;
using System.Collections.Generic;
using SQLite;

//参考url http://dev-suesan.hatenablog.com/entry/2017/03/06/005206
//SQLメソッドの参考url https://www.tmp1024.com/programming/use-sqlite

namespace book3
{
    /*
    //テーブル名を指定
    [Table("User")]
    public class UserModel
    {
        //プライマリキー　自動採番されます
        [PrimaryKey, AutoIncrement, Column("_id")]
        //idカラム
        public int Id { get; set; }
        //名前カラム
        public string Name { get; set; }
        public int id;
        //Userテーブルに行追加するメソッドです
            //------------------------Insert文的なの--------------------------
        public static void insertUser(string name)
        {
            //データベースに接続
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    
                    //データベースにUserテーブルを作成します
                    db.CreateTable<UserModel>();
                    
                    //Userテーブルに行追加します
                    db.Insert(new UserModel() { Name = name });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }
        
        //id name オーバーロード
        public static void insertUser(int id, string name)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにUserテーブルを作成する
                    db.CreateTable<UserModel>();
                    db.Insert(new UserModel() { Id = id , Name = name  });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }
        
        //Userテーブルのuserを削除するメソッド
        //--------------------------delete文的なの--------------------------
        public static void deleteUser(int id)
        {
            //データベースに接続
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                //db.BeginTransaction();  //このサイト https://qiita.com/alzybaad/items/9356b5a651603a548278
                try
                {
                    db.CreateTable<UserModel>();
                    db.DropTable<UserModel>();
                    db.Delete(id);
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }
        //Userテーブルの行データを取得します
        //--------------------------select文的なの--------------------------
        public static List<UserModel> selectUser()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<UserModel>("SELECT * FROM [User] desc limit 15");
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }
    }
    */

    //テーブル名を指定
    [Table("Book")]
    public class UserModel
    {
        //プライマリキー　自動採番されます
        [PrimaryKey]
        //カラムっていうのは列と同じ
        //idカラム
        public string ISBN { get; set; }
        //名前カラム
        public string Title { get; set; }

        public string TitleKana { get; set; }

        public string ItemCaption { get; set; }

        public string Author { get; set; }

        public string publisherName { get; set; }

        public string Genre { get; set; }

        public int Value { get; set; }

        public bool Read { get; set; }

        public bool RedStar { get; set; }

        public bool BlueBook { get; set; }
        //Userテーブルに行追加するメソッドです
        //------------------------Insert文的なの--------------------------

        //id name オーバーロード
        public static void insertUser(string isbn, string title, string titlekana, string itemcaption)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにUserテーブルを作成する
                    db.CreateTable<UserModel>();

                    db.Insert(new UserModel() { ISBN = isbn, Title = title, TitleKana = titlekana, ItemCaption = itemcaption });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        //Userテーブルのuserを削除するメソッド
        //--------------------------delete文的なの--------------------------
        public static void deleteUser()
        {

            //データベースに接続
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                //db.BeginTransaction();  //このサイト https://qiita.com/alzybaad/items/9356b5a651603a548278
                try
                {
                    db.CreateTable<UserModel>();
                    db.DropTable<UserModel>();

                    // db.Delete(id);
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }

        }


        //Userテーブルの行データを取得します
        //--------------------------select文的なの--------------------------
        public static List<UserModel> selectUser()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    //return db.Query<UserModel>("SELECT * FROM [Book] order by [_id] desc limit 15");
                    return db.Query<UserModel>("SELECT * FROM [Book]");

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        public static List<UserModel> countUser(int id)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    return db.Query<UserModel>("SELECT Name FROM[Book] where [_id] =" + id + " limit 15");
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        public static List<UserModel> Blue_Book(string isbn)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try{

                    
                   return db.Execute<UserModel>("update [Book] set BlueBook = true where ISBN =?",isbn);
                   
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        public static List<UserModel> Gray_Book(string isbn)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try{
                    return db.Execute<UserModel>("update [Book] set BlueBook = true where ISBN =?",isbn);
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }
/*
        public static void Gray_Book(string isbn)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    db.Execute("UPDATE [Book] SET BlueBook = false WHERE ISBN =" + isbn,2);
                    //db.Query<UserModel>("UPDATE [Book] SET BlueBook = false WHERE ISBN =" + isbn );
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }
*/

                //Userテーブルの行データを取得します
        //--------------------------select文的なの--------------------------
        public static List<UserModel> selectUserISBN(string isbn)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    //return db.Query<UserModel>("SELECT * FROM [Book] order by [_id] desc limit 15");
                    return db.Query<UserModel>("SELECT * FROM [Book] WHERE ISBN =" + isbn );

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