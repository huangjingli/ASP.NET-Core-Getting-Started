using System;

namespace CoreDemo.Model
{
    //电影院
    public class Cinema
    {
        public int  Id { get; set; }
        public string Name { get; set; } //电影名
        public string Location { get; set; }//地址
        public int Capacity { get; set; }//人数
    }
}
