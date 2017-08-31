using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
namespace fileProgram
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ToDo t1=new ToDo ("aa",1,"this is aa","2017-7-12");
            ToDo t2=new ToDo ("bb",1,"this is bb","2017-6-12");
            ToDo t3=new ToDo ("cc",2,"this is cc","2017-5-12");
            ToDo t4=new ToDo ("dd",3,"this is dd","2017-7-15");
            ToDo t5=new ToDo ("ee",1,"this is ee","2017-8-12");
            TodoList tdList = new TodoList();
            tdList.add(t1);
            tdList.add(t2);
            tdList.add(t3);
            tdList.add(t4);
            tdList.add(t5);

        }
    }
    //待办事项
    public class ToDo
    {
        private string subject;
        private int priority;
        private string description;
        private string time;
        //属性
        public string Subject
        {
            get{return subject;}
            set{subject = value;}
        }
        public int Priority
        {
            get{return priority;}
            set{priority = value;}
        }
        public string Description
        {
            get{return description;}
            set{description = value;}
        }
        public string Time
        {
            get{return time;}
            set{time = value;}
        }
        //构造函数
        public ToDo()
        {

        }
        public ToDo(string _subject,int _priority,string _description,string _time)
        {
            subject = _subject;
            priority = _priority;//权重
            description = _description;
            time = _time;
        }
        //比较标题大小
        public int subCompare(ToDo x,ToDo y)
        {
           return  string.CompareOrdinal(x.subject, y.subject);

        }
        //比较优先级大小
        public int priCompare(ToDo x,ToDo y)
        {
            return x.priority - y.priority;
        }
        //比较时间先后

        //ToString()
        public override string ToString()
        {
            return string.Format("[TodoList:sub:{0} priority:{1} description:{2} tiem:{3}]",subject,priority ,description,time);

        }
        //按标题进行排序
        public int sortBySub(ToDo t)
        {
            int m=string.CompareOrdinal(this.Subject, t.Subject);
            if (m>0)
            {
                return 1;
            }else if(m<0)
            {
                return -1;
            }else
            {
                return 0;
            }

        }
        //按优先级进行排序
        public int sortByPri(ToDo t)
        {
            int m = this.priority - t.priority;
            if (m>0)
            {
                return 1;
            }
            else if(m<0)
            {
                return -1;
            }
            else{
                return 0;
            }
        }
        //按时间进行排序 
        public int sortBytime(ToDo t)
        {
            DateTime t1 = Convert.ToDateTime(this.time);
            DateTime t2 = Convert.ToDateTime(t.time);
            int m = DateTime.Compare(t1, t2);
            if (m>0)
            {
                return 1;
            }else if(m<0)
            {
                return -1;
            }
            else{
                return 0;
            }
        }
    }
    public class TodoList
    {
        private List<ToDo> todoListArray;
        //构造函数
        public TodoList()
        {
            todoListArray = new List<ToDo>();
        }
        public ToDo this[int index]
        {
            get{return todoListArray[index];}
            set{todoListArray[index] = value;}
        }
        //返回容器中Todo对象的个数
        public int getNum()
        {
            return todoListArray.Count;
        }
        //添加Todo对象
        public void add(ToDo t)
        {
            todoListArray.Add(t);
        }
        //删除Todo对象，参数是Todo对象
        public void deleteByInstance(ToDo t)
        {
            todoListArray.Remove(t);
        }

        //按下标删除Todo对象，参数是下标
        public void deleteByIndex(int n)
        {
            todoListArray.RemoveAt(n);
        }
        //返回某下标的Todo对象
        public ToDo getInstance(int n)
        {
            return todoListArray[n];
        }
        //返回某Todo对象的下标
        public int getIndex(ToDo t)
        {
            if (todoListArray.Contains(t))
            {
                for (int i = 0; i < todoListArray.Count; i++)
                {
                    if (todoListArray[i]==t)
                    {
                        return i;
                    }
                }
            }
        }

//        //按标题进行排序
//        public void sortBySub(ToDo t)
//        {
//            return string.CompareOrdinal()
//        }
//        //按优先级进行排序
//        public void sortByPri()
//        {
//
//        }
//        //按时间进行排序 
//        public void sortBytime()
//        {
//
//        }
        //打印所有的Todo对象信息
        public void printAll()
        {
            foreach (var item in todoListArray)
            {
                Console.WriteLine(item);
            }
        }


    }
    public class TodoDB
    {
        private string filePath;
        private TodoList todoList;
        //构造函数
        public TodoDB(string _filePath)
        {
            todoList = new TodoList();
            filePath =_filePath;
        }

        //返回容器中Todo对象的个数
        public int getListCount()
        {
            return todoList.getNum();
        }

        //添加Todo对象
        public void addInstance()
        {
            todoList.add();
        }
        //删除Todo对象，参数是Todo对象
        public void deleteByInstance(ToDo t)
        {
            todoList.deleteByInstance(t);
        }
        //按下标删除Todo对象，参数是下标
        public void deleteByIndex(int n)
        {
            todoList.deleteByIndex(n);
        }

        //返回某下标的Todo对象
        public ToDo getInstance(int n)
        {
            todoList.getInstance(n);
        }
        //返回某Todo对象的下标
        public int getIndex(ToDo t)
        {
            todoList.getIndex(t);
        }
        //按标题进行排序

        //按优先级进行排序

        //按时间进行排序 

        //打印所有的Todo对象信息
        public void printAll()
        {
            todoList.printAll();
        }

        // ////////////////////////

        //将todoList中的Todo对象保存到文件
        public void arrayToXml()
        {
            string str="<? xml version=\"1.0\" encoding=\"UTF-8\" ?>";
            str += "<root>";

            for (int i = 0; i < this.getListCount(); i++)
            {
                str+="<thing>";
                str+="<subject>";
                str += this.getInstance(i).Subject;
                str+="</subject>";
                str+="<priority>";
                str += this.getInstance(i).Priority;
                str+="</priority>";
                str += "<description>";
                str += this.getInstance(i).Description;
                str += "</description>";
                str+="<time>";
                str += this.getInstance(i).Time;
                str +="</time>";
                str += "</thing>";
            }
            str +="</root>";
            FileStream fs = null;
            if (File.Exists(filePath))
            {
                Console.WriteLine("file exists");
                fs = File.Open(filePath, FileMode.Open);
            }
            else
            {
                fs = File.Create(filePath);
            }
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(str);
            sw.Flush();
            fs.Close();
        }
        //在文件中读取Todo对象保存到todoList中
        public void xmlTOList()
        {

            FileStream fs = null;
            if (File.Exists(filePath))
            {
                fs = File.Open(filePath, FileMode.Open);
            }
            else
            {
                Console.WriteLine("file is not exist");
            }
            StreamReader sr = new StreamReader(fs);
            string strList=sr.ReadToEnd();
            XElement root = XElement.Parse(strList);
            var things = root.Elements("thing");
            foreach (var item in things)
            {
                var subEl= item.Element("subject");
                XElement priorityEl = item.Element("priority");
                XElement descEl = item.Element("description");
                XElement timeEl = item.Element("time");
                ToDo td = new ToDo(subEl.Value, priorityEl.Value, descEl.Value, timeEl.Value);
                todoList.add();
            }
        }
    }
}
