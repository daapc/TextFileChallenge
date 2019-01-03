using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextFileChallenge
{
    public partial class ChallengeForm : Form
    {
        BindingList<UserModel> users = new BindingList<UserModel>();

        public ChallengeForm()
        {
            InitializeComponent();

            users = UserModel.GetUserModelsFromText("StandardDataSet.csv");

            WireUpDropDown();
        }

        private void WireUpDropDown()
        {
            usersListBox.DataSource = users;
            usersListBox.DisplayMember = nameof(UserModel.DisplayText);
        }

        //private void ClearUsersListBox()
        //{
        //    usersListBox.DataSource = "";
        //    usersListBox.DisplayMember = "";
        //}

        private void addUserButton_Click(object sender, EventArgs e)
        {
            users.Add(new UserModel { FirstName = firstNameText.Text, LastName = lastNameText.Text, Age = (int)agePicker.Value, IsAlive = isAliveCheckbox.Checked });

            WireUpDropDown();
        }

        private void saveListButton_Click(object sender, EventArgs e)
        {
            // need a list of strings in the format of the .csv
            // need a UserModel list that we can foreach through
            // take each property from user and create a string in the format of .csv
            //ClearUsersListBox();

            List<string> output = new List<string>();
            foreach(UserModel user in users)
            {
                output.Add($"{user.FirstName},{user.LastName},{user.Age},{(user.IsAlive == true ? 1 : 0)}");
            }

            File.WriteAllLines("StandardDataSet.csv", output);

            users = UserModel.GetUserModelsFromText("StandardDataSet.csv");

            WireUpDropDown();

            Console.ReadLine();
        }
    }
}
