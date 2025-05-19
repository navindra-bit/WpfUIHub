using System.Windows;
using System.Windows.Controls;

namespace Astrology
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int brith = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AgeBox_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1950; i <= 2100; i++) 
            {
                AgeBox.Items.Add(i.ToString());
            }
            AgeBox.SelectedItem = DateTime.Now.Year;
        }

        private void AgeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(AgeBox.SelectedItem != null)
            {
                string brithyear = (string)AgeBox.SelectedItem;
                 brith = Convert.ToInt32(brithyear);
            }
        }

        private void submitButtom_Click(object sender, RoutedEventArgs e)
        {
           
    string name = NameBox.Text;
    if (string.IsNullOrWhiteSpace(name))
    {
        MessageBox.Show("Please enter your name!", "Missing Info", MessageBoxButton.OK, MessageBoxImage.Warning);
        return;
    }

    if (AgeBox.SelectedItem == null)
    {
        MessageBox.Show("Please select your year of birth!", "Missing Info", MessageBoxButton.OK, MessageBoxImage.Warning);
        return;
    }

    int birthYear = brith;
    int currentYear = DateTime.Now.Year;
    int age = currentYear - birthYear; 


    int predictedLifespan = 80;  

   
    string advice = "\n\n🔹 Recommendations to live longer:\n";
    
    if (YesButton.IsChecked == true) 
    {
        predictedLifespan -= 8;
        advice += "❌ Smoking reduces your lifespan significantly. Consider quitting! 🚭\n";
    }
    
    if (YesalcoholButton.IsChecked == true) 
    {
        predictedLifespan -= 5;
        advice += "❌ Excessive alcohol consumption harms your health. Reduce intake! 🍷🚫\n";
    }

    if (NeverButton.IsChecked == true) 
    {
        predictedLifespan -= 5;
        advice += "❌ No exercise? Try to be active! Exercise keeps you young! 🏋️‍♂️\n";
    }

    if (NotHealthyDiet.IsChecked == true) 
    {
        predictedLifespan -= 6;
        advice += "❌ Unhealthy diet detected! Eat more fruits & veggies! 🥗\n";
    }

    if (sleep2.IsChecked == true) 
    {
        predictedLifespan -= 4;
        advice += "❌ Poor sleep affects your health! Try getting 7-9 hours per night. 😴\n";
    }

    if (PoorWorkLifeBalance.IsChecked == true)
    {
        predictedLifespan -= 5;
        advice += "❌ High work stress? Take breaks & relax! Life is short, enjoy it! 🌴\n";
    }

    if (PoorMentalHealth.IsChecked == true) 
    {
        predictedLifespan -= 5;
        advice += "❌ Frequent stress? Try meditation or talking to someone. Mental health matters! 💙\n";
    }

 
    if (predictedLifespan < 50)
    {
        predictedLifespan = 50;
    }

   
    int yearsLeft = predictedLifespan - age;


            string adviceMessage;

            if (yearsLeft <= 10)
            {
                adviceMessage = "⚠️ Time is precious! Make the most of it! ⏳";
            }
            else
            {
                adviceMessage = "🌟 Keep making good choices for a longer, healthier life!";
            }

            string message = string.Format("🔮 Hello {0}!\n\n" + "🗓️ Year of Birth: {1}\n" + "📅 Current Age: {2}\n\n" +  "⏳ Predicted Lifespan: {3} years\n" +
                "💖 Estimated Years Left: {4} years\n" + "{5}\n" + "{6}", name, birthYear, age, predictedLifespan, yearsLeft, adviceMessage, advice);

            MessageBox.Show(message, "Your Life Expectancy Prediction", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void ClearButtom_Click(object sender, RoutedEventArgs e)
        {
            NameBox.Text = "";
            AgeBox.SelectedItem = DateTime.Now.Year;

            YesButton.IsChecked = false;
            NoButton.IsChecked = false;

            YesalcoholButton.IsChecked = false;
            NalcoholButton.IsChecked = false;

            SometimeButton.IsChecked = false;
            NeverButton.IsChecked = false;
            Dailybutton.IsChecked = false;

            HealthyDiet.IsChecked = false;
            NotHealthyDiet.IsChecked = false;
            bothHealthyDiet.IsChecked = false;

            Sleep1.IsChecked = false;
            sleep2.IsChecked = false;
            Sleep3.IsChecked = false;

            GoodWorkLifeBalance.IsChecked = false;
            ModerateWorkLifeBalance.IsChecked = false;
            PoorWorkLifeBalance.IsChecked = false;

            GoodMentalHealth.IsChecked = false;
            ModerateMentalHealth.IsChecked = false;
            PoorMentalHealth.IsChecked = false;
        }
    }
}