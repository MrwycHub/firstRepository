/*using System;

namespace _1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Person p = new Person("zhangsan", 20);
			p.print();
		}
	}

	//在不改动Person类的情况下，给Person类添加一个print方法
	public class Person
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public Person(string _name, int _age)
		{
			this.Name = _name;
			this.Age = _age;
		}
	}

	//在静态类中扩展方法
	public static class PersonExtern
	{
		//扩展方法中至少有一个参数，这个参数前要加this，this后边是要扩展的类对象
		public static void print(this Person p)
		{
			Console.WriteLine("name:{0},age:{1}", p.Name, p.Age);
		}
	}
}
*/
/*using System;
using System.Collections.Generic;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			List<int> l = new List<int>();
			for (int i = 1; i <= 100; i++)
			{
				l.Add(i);
			}

			int a = l.sum();
			Console.WriteLine(a);

			//List<double> l2 = new List<double>();
			//不同的封闭泛型，扩展的方法不一样

			int b = l.sum(50);
			Console.WriteLine(b);
		}
	}

	public static class ListExten
	{
		public static int sum(this List<int> l)
		{
			int s = 0;
			foreach (int t in l)
			{
				if(t%2 == 0)
					s += t;
			}
			return s;
		}
		//第一个参数是扩展的类的对象，从第二个参数开始就是该扩展方法的参数
		public static int sum(this List<int> l, int n)
		{
			int s = 0;
			for (int i = 0; i < n; i++)
			{
				s += l[i];
			}
			return s;
		}
	}


	public class Abc
	{
		public class Bcd
		{

		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//Abc a = new Abc();
			//1.静态类不可以创建对象，类似抽象类(abstract)
			//2.静态类不可以被继承，类似密封类(sealed)
			//3.静态类中不可以声明非静态成员(实例成员)，只能声明静态成员

		}
	}

	public static class Abc
	{
		//private int a;
		static Abc()
		{

		}
	}
	//public class Bcd : Abc
	//{

	//}
}*/
/*using System;
using bb;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			Person p = new Person();
			p.print();//对象在调用某方法时，首先在该类中查找有没有该方法，
					  //如果没有找到该方法，在去查找扩展方法
					  //在查找扩展方法时：首先在当前命名空间查找，
					  //当前命名空间没有再去引入的其他命名空间去查找
			p.print2();
		}
	}
	public class Person
	{

	}

	//扩展方法可以重载，在调用时根据参数选择调用哪个扩展方法
	//如果参数也一样，不同的命名空间可以一样，同一个命名空间下不可以
	public static class PersonExten
	{
		public static void print(this Person p)
		{
			Console.WriteLine("print for Person");
		}
	}
	public static class PersonExten2
	{
		public static void print(this Person p,string s)
		{
			Console.WriteLine("print for Person in PersonExten2 {0}",s);
		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//Person p = null;
			//p.print1();//p是空引用，调用实例方法会抛出异常
			//p.print2();//空引用可以调用扩展方法

			Student s = new Student();
			s.print2();//子类可以调用父类的扩展方法，扩展方法可以继承到子类
		}
	}

	public class Person
	{
		public void print1()
		{
			Console.WriteLine("print1 in Person");
		}
	}
	public static class PersonExten
	{
		public static void print2(this Person p)
		{
			Console.WriteLine("print2 in PersonExten");
		}
	}

	public class Student : Person
	{

	}
}*/
/*using System;
using System.Collections.Generic;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			string s = "hello";
			s.fun();

			List<int> l = new List<int>();
			l.fun();

			Person p = new Person();
			p.fun();

			Dictionary<int, int> d = new Dictionary<int, int>();
			d.fun();
		}
	}

	public static class ObjExten
	{
		public static void fun(this object o)
		{
			Console.WriteLine("fun for object");
		}
	}

	public class Person
	{

	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{

		}
	}

	public class Person
	{
		private string name;
		public Person(string _name)
		{
			name = _name;
		}
	}

	public class Student : Person
	{
		public Student(string _name) : base(_name)
		{

		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			int a = add(1, 2);
			int b = add(2, 3);
			int c = add(3, 4);

			Console.WriteLine(a);
			Console.WriteLine(b);
			Console.WriteLine(c);

			Console.WriteLine("-----------");

			int d = add();//不给add传参数，然后让add函数计算两个默认值的和 (可选实参)
			Console.WriteLine(d);
			int e = add(100);
			Console.WriteLine(e);

			int f = add2(100);
		}
		//声明形参时，给形参添加默认值，调用函数时，就可以不传参，直接使用默认值进行计算
		//不传参使用默认值计算，传参就使用实参计算
		public static int add(int a = 50, int b = 20)
		{
			return a + b;
		}
		//可选实参必须放在必选实参后边
		public static int add2(int b, int a = 50)
		{
			return a + b;
		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			int a = add(1);
			Console.WriteLine(a);

			int b = add(b: 1);
			Console.WriteLine(b);

			fun();
			fun(s: "hello", b: 100.001);
			//命名实参：指定实参给哪个可选形参赋值
		}
		public static int add(int a = 10, int b = 20)
		{
			return a + b;
		}

		public static void fun(int a = 10, double b = 5.5, string s = "sss")
		{
			Console.WriteLine("{0},{1},{2}", a, b, s);
		}
		//数组不能有可选实参
		//public static void fun2(int[] a = { 1,2,3})
		//{

		//}
		//ref 或 out的参数不能是可选实参
		//public static void fun3(ref int a = 1)
		//{

		//}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{

		}
	}

	public class Person
	{
		private string name;
		public Person(string _name = "noname")
		{
			name = _name;
		}

		//public Person()
		//{

		//}
	}
	public class Student : Person
	{
		//子类中不显示调用父类构造函数时，会自动调用父类无参构造函数(或构造函数的参数带默认参数)
	}
}
*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//Student s = new Student();
			//Person p = s;

			//object o = s;
			//object o2 = p;

			//string str = "hello";
			//object o3 = str;

			//泛型参数的变化(协变和逆变)
			MyInterface<Student> s = null;
			MyInterface<Person> p = null;

			p = s;
			//s赋值给p的过程中，泛型参数从子类转换成父类，需要给泛型参数加out
			//关键字，让该泛型参数支持协变(泛型参数从子类转换成父类)

			//Person p2 = null;
			//Student s2 = null;
			//s2 = p2;

			MyInterface2<Person> p2 = null;
			MyInterface2<Student> s2 = null;
			s2 = p2;//赋值过程中，泛型参数从父类转换成子类，该过程叫做逆变，需要给
			//泛型参数加in关键字
		}
	}

	public class Person
	{

	}
	public class Student : Person
	{

	}

	public interface MyInterface<out T>
	{

	}
	public interface MyInterface2<in T>
	{

	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			Create<Animal> aInterface = new AnimalFactory();
			Animal a = aInterface.create();

			Create<Dog> dInterface = new DogFactory();
			Dog d = dInterface.create();

			aInterface = dInterface;//协变 泛型参数从子类到父类
			Animal a2 = aInterface.create();//create返回值从子类到父类
			a2.print();
			//Dog对象可以直接赋值给Animal使用，同样，泛型参数是Dog的接口也可以
			//赋值给泛型参数是Animal的接口(泛型接口的类型转换)

			//dInterface = aInterface;//逆变，泛型参数从父类到子类
			//Dog d2 = dInterface.create();//create返回值是Animal对象，不能赋值给Dog引用
			//泛型参数作为返回值时，只能发生协变
		}
	}
	public class Animal
	{
		public virtual void print()
		{
			Console.WriteLine("animal");
		}
	}
	public class Dog : Animal
	{
		public override void print()
		{
			Console.WriteLine("Dog");
		}
	}

	public interface Create<out T>
	{
		T create();
	}

	public class AnimalFactory : Create<Animal>
	{
		public Animal create()
		{
			return new Animal();
		}
	}
	public class DogFactory : Create<Dog>
	{
		public Dog create()
		{
			return new Dog();
		}
	}
}
*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			Animal a = new Animal();
			Dog d = new Dog();
			
			Show<Animal> aInterface = new ShowAniaml();
			Show<Dog> dInterface = new ShowDog();

			aInterface.show(a);
			dInterface.show(d);

			dInterface = aInterface;//逆变，泛型参数从父类到子类
			dInterface.show(d);//参数d从子类到父类: show方法的参数是Animal类型，Animal x = d;

			//aInterface = dInterface;//协变，泛型参数从子类到父类
			//aInterface.show(a);//参数a从父类到子类:show方法的参数是Dog类型，Dog x = a;
			//泛型参数做参数时，不能协变

			//泛型的协变逆变，指泛型参数(泛型接口或泛型委托中的泛型参数)的协变逆变
		}
	}

	public class Animal
	{
		public virtual void print()
		{
			Console.WriteLine("Animal");
		}
	}
	public class Dog : Animal
	{
		public override void print()
		{
			Console.WriteLine("Dog");
		}
	}

	public interface Show<in T>
	{
		void show(T x);
	}

	public class ShowAniaml : Show<Animal>
	{
		public void show(Animal x)
		{
			x.print();
		}
	}
	public class ShowDog : Show<Dog>
	{
		public void show(Dog x)
		{
			x.print();
		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public delegate T MyDelegate1<out T>();
		public delegate void MyDelegate2<out T>(T x);
		public static void Main()
		{
			MyDelegate1<Animal> aDelegate = createAnimal;
			MyDelegate1<Dog> dDelegate = createDog;

			Animal a = aDelegate();
			Dog d = dDelegate();

			//aDelegate = dDelegate;//协变，泛型参数从子类到父类
			//Animal a2 = aDelegate();
			//dDelegate = aDelegate;
			//Dog d2 = dDelegate();
			//泛型参数做返回值时只能协变不能逆变

			MyDelegate2<Animal> aDelegate2 = showAnimal;
			MyDelegate2<Dog> dDelegate2 = showDog;

			aDelegate2(a);
			dDelegate2(d);

			//dDelegate2 = aDelegate2;
			//dDelegate2(d);//dDelegate2实际指向showAnimal方法，参数是Animal类型

			//aDelegate2 = dDelegate2;//协变
			//aDelegate2(a);//aDelegate2实际指向showDog方法，参数类型是Dog类型
			//泛型参数做参数时只能逆变不能协变
		}
		public static Animal createAnimal()
		{
			return new Animal();
		}
		public static Dog createDog()
		{
			return new Dog();
		}
		public static void showAnimal(Animal x)
		{
			Console.WriteLine("animal");
		}
		public static void showDog(Dog x)
		{
			Console.WriteLine("Dog");
		}
	}

	public class Animal { }
	public class Dog : Animal { }
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			Vector<string> v = new Vector<string>();
			Vector<object> o = v;

		}
	}

	public class Vector<out T>
	{
		private T[] array;
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			MyInterface<int> interface1 = null;
			MyInterface<double> interface2 = interface1;
		}
	}

	public interface MyInterface<out T>
	{

	}
}*/
using System;
using System.Dynamic;
namespace aa
{
	class MainClass
	{
		public delegate void MyDelegate();
		public static void Main()
		{
			//dynamic a = 100;//动态类型，只有在程序执行过程中才能确定类型
			var b = 100;//在编译时，就可以根据值来推断类型 
			int c = b + 10;
			Console.WriteLine(c);
			//Console.WriteLine(a);
			dynamic o = new ExpandoObject();
			o.Name = "zhangsan";
			o.Age = 20;
			o.Print = (MyDelegate)(() =>
			{
				Console.WriteLine("name:{0},age:{1}", o.Name, o.Age);
			});
			Console.WriteLine("name:{0},age:{1}", o.Name, o.Age);
			o.Print();
		}
	}
}