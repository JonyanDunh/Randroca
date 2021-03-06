﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        About About = new About();//关于的窗口
        ManualResetEvent Thread_blocking = new ManualResetEvent(false);//线程阻塞

        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;//显示位置屏幕居中
            InitializeComponent();
            this.ShowInTaskbar = false;//在任务栏上隐藏
            this.Topmost = true;//窗口置顶
            Thread thread = new Thread(Roll_call);//把点名的函数加入一个新的子线程
            thread.Start();//线程开始


        }

        private void Roll_call()//点名的函数
        {
            string[] name = { "蔡徐坤", "肖战", "乔碧萝", "罗志祥", "特朗普", "香蕉君", "比利王", "VAN" };//姓名列表

            while (true)//死循环
            {
                Thread_blocking.WaitOne();//设置线程阻塞
                Random ran = new Random(GetRandomSeed());//设置随机数种子
                int RandKey = ran.Next(0, name.Length - 1);//生成随机数

                Action action1 = () =>//创建委托,委托主线程更新UI
                {

                    label.Content = name[RandKey];//显示当前选中名字
                    imgs.Source = new BitmapImage(new Uri("pack://application:,,,/resource/face/" + name[RandKey] + ".png"));//显示与名字相对应的图片

                };
                label.Dispatcher.BeginInvoke(action1);
                Thread.Sleep(10);
            }
        }

        private void click(object sender, RoutedEventArgs e)//开始点名
        {
            //判断是否已经开始点名

            if (string.Equals(buttons.Content, "选老婆"))//没有开始点名时
            {

                Thread_blocking.Set();//允许阻塞的线程继续执行
                buttons.Content = "就这?";
            }
            else if (string.Equals(buttons.Content, "就这?"))//已经开始点名时
            {

                Thread_blocking.Reset();//阻塞线程
                buttons.Content = "选老婆";
            }

        }



        private void close(object sender, MouseButtonEventArgs e)//关闭程序
        {
            Process.GetCurrentProcess().Kill();//结束所有线程
            Application.Current.Shutdown();//关闭窗口
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)//移动窗口
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void bilibili(object sender, MouseButtonEventArgs e)//跳转到作者的BILIBILI主页
        {
            System.Diagnostics.Process.Start("https://space.bilibili.com/96876893");
        }

        static int GetRandomSeed()//随机数种子
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        private void about(object sender, MouseButtonEventArgs e)//点击关于按钮
        {
            About.ShowDialog();//显示关于的窗口
        }
    }
    }

/*
 * @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@/....................................................................................................................................\@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@^......................................................................................................................................=
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@........................................................................................................................................
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@........................................................................................................................................
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@........................................................................................................................................
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@........................................................................................................................................
@@@@@@@@@@@@@@@@@/[[[[[[[O@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@........]]]]]]]]]]]]]]]]]................................................................................]]]]]]`........................
@@@@@@@@@@@@@@@@@^       O@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@........@@@@@@@@@@@@@@@@@@@@@O]..........................................................................O@@@@@^........................
@@@@@@@@@@@@@@@@@^       O@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@........@@@@@@@@@@@@@@@@@@@@@@@@O`.......................................................................O@@@@@^........................
@@@@@@@@@@@@@@@@@^       O@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@........@@@@@@O[[[[[[[[[O@@@@@@@@@\......................................................................O@@@@@^........................
@@@@@@@@@@@@@@@@@^       O@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@........@@@@@@O............,O@@@@@@\.....................................................................O@@@@@^........................
@@@@@@@@@@@@@@@@@^       O@@@@@@@@@@@@O[`       [\@@@@@@@@@@@@/[[[[[[\@@@/[      [\@@@@@@@[[[[[[[[@@@@@@@@@@@/[[[[[[[O@@@@@@@O[`        ,[O@@@@@@@@@@[[[[[[[@@@/[      [\@@@@@@@@@........@@@@@@O..............O@@@@@@^.......]]]]]]`.........,]]]]]].......,]]]]]`....,]OO@O]]............O@@@@@^....,]O@OO]`............
@@@@@@@@@@@@@@@@@^       O@@@@@@@@@/                ,O@@@@@@@@^      =/             ,O@@@@\       =@@@@@@@@@O       =@@@@@O`                ,O@@@@@@@       /              \@@@@@@........@@@@@@O..............,@@@@@@O.......@@@@@@^.........=@@@@@@.......=@@@@@^.]O@@@@@@@@@@@\.........O@@@@@^.]O@@@@@@@@@@O`.........
@@@@@@@@@@@@@@@@@^       O@@@@@@@/                    ,O@@@@@@^                       \@@@@^       \@@@@@@@@`      ,@@@@@^                    \@@@@@@                       \@@@@@........@@@@@@O...............O@@@@@@^......@@@@@@^.........=@@@@@@.......=@@@@@O@@@@@@@@@@@@@@@O........O@@@@@@@@@@@@@@@@@@@@@^........
@@@@@@@@@@@@@@@@@^       O@@@@@@^        ]@@@@O`        \@@@@@^         ,O@@@\        =@@@@@`       @@@@@@@^       O@@@@^       /@@@@@\       =@@@@@@         ,/@@@O`        @@@@@........@@@@@@O...............=@@@@@@^......@@@@@@^.........=@@@@@@.......=@@@@@@@O[.....,O@@@@@@^.......O@@@@@@@/`.....\@@@@@@@........
@@@@@@@@@@@@@@@@@^       O@@@@@^       =@@@@@@@@@`       \@@@@^        O@@@@@@@        @@@@@@       =@@@@@@       =@@@@@O]]]   O@@@@@@@^       @@@@@@        /@@@@@@@`       @@@@@........@@@@@@O...............=@@@@@@^......@@@@@@^.........=@@@@@@.......=@@@@@@/........,@@@@@@\.......O@@@@@@^........=@@@@@@^.......
@@@@@@@@@@@@@@@@@^       O@@@@@       =@@@@@@@@@@@       ,@@@@^       =@@@@@@@@^       @@@@@@O       \@@@@`      =@@@@@@@@@@@@@@@@@@/[`        @@@@@@       =@@@@@@@@^       @@@@@........@@@@@@O...............=@@@@@@^......@@@@@@^.........=@@@@@@.......=@@@@@@^.........O@@@@@O.......O@@@@@O.........=@@@@@@^.......
@@@@@@@@@@@@@@@@@^       O@@@@^       =@@@@@@@@@@@^       @@@@^       =@@@@@@@@^       @@@@@@@^       @@@/       @@@@@@@@@@@[`                 @@@@@@       =@@@@@@@@^       @@@@@........@@@@@@O.............../@@@@@@^......@@@@@@^.........=@@@@@@.......=@@@@@@..........O@@@@@O.......O@@@@@/..........@@@@@@^.......
@@O[[[[[[@@@@@@@@^       O@@@@\       =@@@@@@@@@@@^       @@@@^       O@@@@@@@@^       @@@@@@@@^      ,@@       /@@@@@@@@`                    .@@@@@@       =@@@@@@@@^       @@@@@........@@@@@@O...............@@@@@@@.......@@@@@@^.........=@@@@@@.......=@@@@@@..........O@@@@@O.......O@@@@@^..........@@@@@@^.......
@O       \@@@@@@@^       @@@@@@       =@@@@@@@@@@@       ,@@@@^       O@@@@@@@@^       @@@@@@@@@       =^      =@@@@@@@@          ]]]O@^      .@@@@@@       =@@@@@@@@^       @@@@@........@@@@@@O............../@@@@@@^.......@@@@@@^........./@@@@@@.......=@@@@@@..........O@@@@@O.......O@@@@@^..........@@@@@@^.......
@@       ,@@@@@@O       .@@@@@@^       =@@@@@@@@@`       /@@@@^       O@@@@@@@@^       @@@@@@@@@O             ,@@@@@@@@^       O@@@@@@@^      .@@@@@@       =@@@@@@@@^       @@@@@........@@@@@@O............,O@@@@@@/........@@@@@@O........,O@@@@@@.......=@@@@@@..........O@@@@@O.......O@@@@@^..........@@@@@@^.......
@@^        [\@/`        /@@@@@@@`        [@@@@O`        /@@@@@^       O@@@@@@@@^       @@@@@@@@@@^            @@@@@@@@@^       ,O@@@@[         @@@@@@       =@@@@@@@@^       @@@@@........@@@@@@O]]]]]]]]]/O@@@@@@@@/.........O@@@@@@\....../@@@@@@@@.......=@@@@@@..........O@@@@@O.......O@@@@@^..........@@@@@@^.......
@@@^                   /@@@@@@@@@\                    ,O@@@@@@^       O@@@@@@@@^       @@@@@@@@@@@^          /@@@@@@@@@O                       @@@@@@       =@@@@@@@@^       @@@@@........@@@@@@@@@@@@@@@@@@@@@@@@O`..........,@@@@@@@@@@@@@@@OO@@@@@.......=@@@@@@..........O@@@@@O.......O@@@@@^..........@@@@@@^.......
@@@@O`               /@@@@@@@@@@@@@\                ,O@@@@@@@@^       O@@@@@@@@^       @@@@@@@@@@@@`        =@@@@@@@@@@@@`             /^      =@@@@@       =@@@@@@@@^       @@@@@........@@@@@@@@@@@@@@@@@@@@@O[...............\@@@@@@@@@@@O`.O@@@@@.......=@@@@@@..........O@@@@@O.......O@@@@@^..........@@@@@@^.......
@@@@@@@O]`       ]/@@@@@@@@@@@@@@@@@@@O]]       ]/@@@@@@@@@@@@\]]]]]]]O@@@@@@@@\]]]]]]]@@@@@@@@@@@@O       ,@@@@@@@@@@@@@@@\]      ,/@@@O]]]]]]]O@@@@]]]]]]]/@@@@@@@@\]]]]]]]@@@@@........[[[[[[[[[[[[[[[[[.......................,[\O@O/[.....[[[[[[.......,[[[[[[..........[[[[[[[.......[[[[[[`..........[[[[[[`.......
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@`       O@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@........................................................................................................................................
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@/        /@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@........................................................................................................................................
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@O             =@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@........................................................................................................................................
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@           ,O@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@........................................................................................................................................
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@^       ]/@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@........................................................................................................................................
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@^......................................................................................................................................=
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\..................................................................................................................................../@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
*/