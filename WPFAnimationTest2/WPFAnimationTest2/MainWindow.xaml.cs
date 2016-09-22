using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFAnimationTest2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private DoubleAnimation animInit;
        private DoubleAnimation animMouseEnter;
        private DoubleAnimation animMouseLeave;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
 

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create a DoubleAnimation to animate the width of the button.
            animInit = new DoubleAnimation();
            animInit.From = 0;
            animInit.To = 100;

            QuarticEase easingFunction = new QuarticEase();
            easingFunction.EasingMode = EasingMode.EaseInOut;
            animInit.EasingFunction = easingFunction;
            animInit.Duration = new Duration(TimeSpan.FromMilliseconds(500));


            animMouseEnter= new DoubleAnimation();
            animMouseEnter.From = 100;
            animMouseEnter.To = 150;
            animMouseEnter.EasingFunction = easingFunction;
            animMouseEnter.Duration = new Duration(TimeSpan.FromMilliseconds(400));

            animMouseLeave = new DoubleAnimation();
            //animMouseLeave.From = 100;
            animMouseLeave.To = 100;
            animMouseLeave.EasingFunction = easingFunction;
            animMouseLeave.Duration = new Duration(TimeSpan.FromMilliseconds(400));


            AddButton("L1");
            AddButton("L2");
            AddButton("L3");

            
        }


        private void AddButton(string strContent)
        {
            var btn = new Button();
            btn.Background = new SolidColorBrush(Colors.Gray);
            btn.Content = strContent;
            btn.Name = "UniqueName" + System.Guid.NewGuid().ToString("N");
            btn.MouseEnter += OnEnter;
            btn.MouseLeave += OnLeave;
            
            RegisterName(btn.Name, btn);

            StackPanel1.Children.Add(btn);

            // Configure the animation to target the button's Width property.
            Storyboard.SetTargetName(animInit, btn.Name);
            Storyboard.SetTargetProperty(animInit, new PropertyPath(Button.HeightProperty));
            
            // Create a storyboard to contain the animation.
            Storyboard myWidthAnimatedButtonStoryboard = new Storyboard();
            myWidthAnimatedButtonStoryboard.Children.Add(animInit);
            myWidthAnimatedButtonStoryboard.Begin(btn);
        }

        private void OnEnter(object sender, RoutedEventArgs e)
        {
            // Configure the animation to target the button's Width property.
            Button btn = sender as Button;
            Storyboard.SetTargetName(animMouseEnter, btn.Name);
            Storyboard.SetTargetProperty(animMouseEnter, new PropertyPath(Button.HeightProperty));

            // Create a storyboard to contain the animation.
            Storyboard myWidthAnimatedButtonStoryboard = new Storyboard();
            myWidthAnimatedButtonStoryboard.Children.Add(animMouseEnter);
            myWidthAnimatedButtonStoryboard.Begin(btn);
        }

        private void OnLeave(object sender, RoutedEventArgs e)
        {
            // Configure the animation to target the button's Width property.
            Button btn = sender as Button;
            Storyboard.SetTargetName(animMouseLeave, btn.Name);
            Storyboard.SetTargetProperty(animMouseLeave, new PropertyPath(Button.HeightProperty));

            // Create a storyboard to contain the animation.
            Storyboard myWidthAnimatedButtonStoryboard = new Storyboard();
            myWidthAnimatedButtonStoryboard.Children.Add(animMouseLeave);
            myWidthAnimatedButtonStoryboard.Begin(btn);
        }

    }
}
