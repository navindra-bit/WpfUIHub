using System.IO;
using System.Windows;
using LoginAndRegisterPage.ClassFile;
using Newtonsoft.Json;
namespace LoginAndRegisterPage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string rootpath = "";
       public string Folderpath = "";
      public  string filepath = "";
        public MainWindow()
        {
            InitializeComponent();
            rootpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Folderpath = Path.Combine(rootpath, "DotNetUserLog");
            if (!Directory.Exists(Folderpath))
            {
                Directory.CreateDirectory(Folderpath);
            }
        }

        private void chgSignupbutton_Click(object sender, RoutedEventArgs e)
        {
            alllogin.Visibility = Visibility.Collapsed;
            allregiter.Visibility = Visibility.Visible;
            Chgsingup.Visibility = Visibility.Collapsed;
            chgsingin.Visibility = Visibility.Visible;
        }

        private void chgSigninbutton_Click(object sender, RoutedEventArgs e)
        {
            alllogin.Visibility = Visibility.Visible;
            allregiter.Visibility = Visibility.Collapsed;
            Chgsingup.Visibility = Visibility.Visible;
            chgsingin.Visibility = Visibility.Collapsed;
        }

        private void TermAndCon_Click(object sender, RoutedEventArgs e)
        {
            Term_ConditionsPage term_ConditionsPage = new Term_ConditionsPage();
            term_ConditionsPage.Show();
        }

        private void loginbutton_Click(object sender, RoutedEventArgs e)
        {
            string username = logusername.Text.Trim();
            filepath = Path.Combine(Folderpath, "UserDetails.json");
            List<UserReg> userRegs = new List<UserReg>();
            if (File.Exists(filepath) )
            {
                
                string filedata = File.ReadAllText(filepath);
                userRegs = JsonConvert.DeserializeObject<List<UserReg>>(filedata);
                //string[] data = filedata.Split("|");

                //string passwordlog = logpassword.Password;
                //string usernamedata = data[0];
                //string passworddata = data[1].Trim();
                // if (usernamedata.ToLower() == username.ToLower() && passworddata == passwordlog)
                bool isvaild = false;

                var ul = from item in userRegs
                         where item.UserNameReg.ToLower().Equals(username.ToLower()) && item.PasswordReg == logpassword.Password.ToString()
                         select item;
                if (ul.Count() > 0)
                {
                    Usernamealr.Visibility = Visibility.Collapsed;
                    Passwordalr.Visibility = Visibility.Collapsed;
                    HomePage homePage = new HomePage();
                    homePage.Show();
                    isvaild = true;
                }
                    //foreach (var item in userRegs)
                    //{
                    //    if (item.UserNameReg.ToLower().Equals(username.ToLower()) && item.PasswordReg == logpassword.Password.ToString())
                    //    {
                    //        Usernamealr.Visibility = Visibility.Collapsed;
                    //        Passwordalr.Visibility = Visibility.Collapsed;
                    //        HomePage homePage = new HomePage();
                    //        homePage.Show();
                    //        isvaild = true;
                    //    }
                    //}


                    if (isvaild == false)
                {

                    Usernamealr.Visibility = Visibility.Visible;
                    Usernamealr.Content = "Enter a Vaild UserName";
                    Passwordalr.Visibility = Visibility.Visible;
                    Passwordalr.Content = "Enter a Vaild Password";
                }
                
            }
            else
            {

            
            if (string.IsNullOrWhiteSpace(logusername.Text)  || !File.Exists(filepath))
            {
                Usernamealr.Visibility = Visibility.Visible;
                Usernamealr.Content = "Enter a Vaild UserName";
            }
            else
            {
                Usernamealr.Visibility = Visibility.Collapsed;

            }
            if (string.IsNullOrWhiteSpace(logpassword.Password) || !File.Exists(filepath))
            {
                Passwordalr.Visibility = Visibility.Visible;
                Passwordalr.Content = "Enter a Vaild Password";
               
            }
            else
            {
                Passwordalr.Visibility = Visibility.Collapsed;
            }
            }


        }

        private void registerbutton_Click(object sender, RoutedEventArgs e)
        {
            bool boolusername = false;
            bool boolpassword = false;
            bool boolemail = false;
            bool boolphone = false;
            bool boolterm = false;
            if (string.IsNullOrWhiteSpace(regusername.Text) || regusername.Text.Contains('/'))
            {
                regUsernamealr.Visibility = Visibility.Visible;
                regUsernamealr.Content = "Enter a Vaild UserName";
            }
            else
            {
                regUsernamealr.Visibility = Visibility.Collapsed;
               
                boolusername = true;
            }
            if (string.IsNullOrWhiteSpace(regpassword.Text) || regusername.Text.Contains('/') || regpassword.Text != regconformpassword.Text )
            {
                regpasswordalr.Visibility = Visibility.Visible;
                regpasswordalr.Content = "Enter a Vaild & Matching Password";
                regconpasswordalr.Visibility = Visibility.Visible;
                regconpasswordalr.Content = "Enter a Vaild  & Matching  Password";

            }
            else
            {
                regpasswordalr.Visibility = Visibility.Collapsed;
                regconpasswordalr.Visibility = Visibility.Collapsed;
                boolpassword = true;

            }
            if (string.IsNullOrWhiteSpace(emailbox.Text) || regusername.Text.Contains('/') || !emailbox.Text.Contains(".com") || !emailbox.Text.Contains('@'))
            {
                regemailalr.Visibility = Visibility.Visible;
                regemailalr.Content = "Enter a Vaild Email Address";
            }
            else
            {
                regemailalr.Visibility = Visibility.Collapsed;
                boolemail = true;
            }
            if (string.IsNullOrWhiteSpace(phonebox.Text) || regusername.Text.Contains('/') || !int.TryParse(phonebox.Text, out int phone))
            {
               
             
                regphonenumalr.Visibility = Visibility.Visible;
                regphonenumalr.Content = "Enter a Vaild PhoneNumber";
            }
            else
            {
                regphonenumalr.Visibility = Visibility.Collapsed;
                boolphone = true;
            }
            if (regtermcheckbox.IsChecked == false)
            {
                regtemalr.Visibility = Visibility.Visible;
                regtemalr.Content = "Please , Accept the Terms & Conditions";
            }
            else
            {
                regtemalr.Visibility = Visibility.Collapsed;
                boolterm = true;
            }
            if(boolusername == true && boolpassword == true && boolemail== true && boolemail==true && boolphone==true && boolterm==true)
            {

                
                // filepath = Path.Combine(Folderpath, regusername.Text + ".json");
                filepath = Path.Combine(Folderpath, "UserDetails.json");
                List<UserReg> userRegs = new List<UserReg>();
                if (File.Exists(filepath))
                {
                    
                    string filedata = File.ReadAllText(filepath);
                    userRegs = JsonConvert.DeserializeObject<List<UserReg>>(filedata);
                    
                }

                UserReg reg = new UserReg();
                reg.UserNameReg = regusername.Text;
                reg.PasswordReg = regpassword.Text;
                reg.EmailReg = emailbox.Text;
                reg.PhoneNumberReg = Convert.ToInt32(phonebox.Text);
                userRegs.Add(reg);
                string json = JsonConvert.SerializeObject(userRegs);
                File.WriteAllText(filepath, json);
                MessageBox.Show("Done");

                //  string contentpass = $"{regusername.Text}|{regconformpassword.Text} | {emailbox.Text} | {phonebox.Text} ";
                // File.WriteAllText(filepath,contentpass);





            }
        }
    }
}