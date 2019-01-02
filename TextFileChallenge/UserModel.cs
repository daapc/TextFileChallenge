using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileChallenge
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsAlive { get; set; }

        public string DisplayText
        {
            get
            {
                string aliveStatus = "is dead";

                if (IsAlive == true)
                {
                    aliveStatus = "is alive";
                }

                return $"{ FirstName} { LastName } is { Age } and { aliveStatus }";
            }
        }

        public static BindingList<UserModel> GetUserModelsFromText(string fileName)
        {
            BindingList<UserModel> output = new BindingList<UserModel>();

            StreamReader fileReader = new StreamReader(fileName);
            string line = fileReader.ReadLine();
            line = fileReader.ReadLine();

            while (line != null)
            {
                string[] cols = line.Split(',');
                output.Add(new UserModel { FirstName = cols[0], LastName = cols[1], Age = int.Parse(cols[2]), IsAlive = int.Parse(cols[3]) == 1 ? true : false });

                line = fileReader.ReadLine();
            }
            return output;
        }
    }
}
