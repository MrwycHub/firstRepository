
/*using System;
namespace fanxingMethod
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Vector<int> vs = new Vector<int>();
            Person p = new Person();
            var s=vs.print(p);
            Console.WriteLine(s);
        }
      
    }
    public interface Text<T>
    {
         T print<T>(T x);
    }
    public class Vector<T>:Text<T>
    {
        public T print<T>(T x)
        {
            return x;
        }
    }
    public class Person
    {
        
    }
}*/
using System;
namespace aa
{
    class Program
    {
        public static void Main()
        {
            Hero h1 = new Hero() { Name = "Monkey", Hp = 12000, Skill = "金箍棒", Lv = 18 };
            Hero h2 = new Hero() { Name = "lefulan", Hp = 1800, Skill = "fenshen", Lv = 17 };
            h1.showInfo();
            Console.WriteLine("----------");
            h1.addHp();
            h1.showInfo();
            Console.WriteLine("----------");
            h1.updateLv();
            h1.showInfo();
            Console.WriteLine("----------");
            Hero.modifyCareer("Magic");
            h1.showInfo();
            h2.showInfo();
            Console.WriteLine("----------");
        }
    }
    public class Hero
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public string Skill { get; set; }
        public int Lv { get; set; }
        private static string career { get; set; }

        public Hero()
        {
            career = "fighter";
        }
        public void addHp()
        {
            this.Hp += 100;
        }
        public void updateLv()
        {
            this.Lv++;
        }
        public static void modifyCareer(string newCareer)
        {
            career = newCareer;

        }
        public void showInfo()
        {
            Console.WriteLine("name:{0} Hp:{1} skill:{2} Lv:{3} carrer:{4}",Name,Hp,Skill,Lv,career);
        }
    }
}