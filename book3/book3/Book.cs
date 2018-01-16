using System;

public class Book
{

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
