/*In Class Assignment2 AzzaElgendy
 * 
 * String Validations 
 * 
 * Revision History 2/12/2018
 * revision history 16/2/2018
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace inClassAssignment2AzzaElgendy
{
    public partial class AEMember : Form
    {
        public AEMember()
        {
            InitializeComponent();
        }
       
        
        //change color
        private void AEChangeColorTextBox(Control.ControlCollection cc)
        {
            foreach (Control ctrl in cc)
            {
                TextBox tb = ctrl as TextBox;
                if (tb != null)
                    tb.BackColor = Color.Beige;
                AEChangeColorTextBox(ctrl.Controls);
            }
        }

        //first letter to Upper not working
        private void AECapitalize( string text)
        {

            if (text != "")

            {
                text = text.Trim();
                text = text.ToLower();
                string output = text.First().ToString().ToUpper() 
                    + text.Substring(1); 
            }

        }
        //to lower Case not working
        public static string AELowerCase(string text)
        {

            if (String.IsNullOrEmpty(text))
                throw new ArgumentException("This Shoudnt be empty");
            return text.ToString().ToLower();
        }
        //check is numeric
        public bool AEIsNumeric(string text)
        {
            int number;
            return int.TryParse(text, out number);
        }
        public bool AEEmailValidation(string text)
        {
            if (textBoxEmail.Text != "")
            {
                if (textBoxEmail.Text.Contains("@") 
                    && textBoxEmail.Text.Contains("."))
                {
                    text = textBoxEmail.Text.ToLower();
                    textBoxEmail.Text = text;

                }
                else
                {
                    richTextBoxError.Text 
                        += ("This is not avalid Email") + "\n";
                    textBoxPostalCode.Focus();
                }
            }
            return true;
        }

        public bool AEPostalCodeValidate(string text)
        {
            //postal code
            char[] postalCode = new char[6];

            bool go = true;
            bool go2 = true;
            //validate postal code
            if (textBoxPostalCode.Text != "" 
                && textBoxPostalCode.Text.Length == 6)
            {


                text = textBoxPostalCode.Text;
                postalCode = text.ToCharArray();
                if (postalCode.Length != 6)
                {
                    richTextBoxError.Text 
                        += ("Postal Code Must Be 6 Digits    "
                        + "ex  : 1A1 A1A") + "\n";
                    richTextBoxError.Focus();
                }
                else
                {

                    for (int i = 0; i < postalCode.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            postalCode = text.ToCharArray();
                            if (char.IsLetter(text, 0))
                            {


                                go = true;
                            }
                            else
                            {
                                go = false;
                            }

                        }
                    }
                    for (int i = 0; i < postalCode.Length; i++)
                    {
                        if (i % 2 == 1)
                        {
                            postalCode = text.ToCharArray();
                            if (char.IsDigit(text, 1))
                            {

                                go2 = true;
                            }
                            else
                            {

                                go2 = false;
                            }
                        }
                    }
                    if (go == true && go2 == true)
                    {
                        text = text.Insert(3, " ");
                        textBoxPostalCode.Text = text.ToUpper();
                    }
                    else
                    {
                        richTextBoxError.Text 
                            += ("Postal code is not Valid!!!!!!") 
                            + "\n";
                        richTextBoxError.Focus();
                    }
                }


            }
            else if (textBoxPostalCode.Text != "" 
                && textBoxPostalCode.Text.Length == 7)
            {

                int index = textBoxPostalCode.Text.IndexOf(" ");
                textBoxPostalCode.Text = textBoxPostalCode.Text.Remove(index, 1);
                text = textBoxPostalCode.Text;
                postalCode = text.ToCharArray();
          
                if (postalCode.Length != 6)
                {
                    richTextBoxError.Text += ("Postal Code Must Be 6 Digits  "
                        + "ex  : 1A1 A1A") + "\n";
                    richTextBoxError.Focus();
                }
                else
                {
                    for (int i = 0; i < postalCode.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            postalCode = text.ToCharArray();
                            if (char.IsLetter(text, 0))
                            {
                                go = true;
                            }
                            else
                            {
                                go = false;
                            }

                        }
                    }
                    for (int i = 0; i < postalCode.Length; i++)
                    {
                        if (i % 2 == 1)
                        {
                            postalCode = text.ToCharArray();
                            if (char.IsDigit(text, 1))
                            {

                                go2 = true;
                            }
                            else
                            {

                                go2 = false;
                            }
                        }
                    }
                    if (go == true && go2 == true)
                    {
                        textBoxPostalCode.Text = text.ToUpper();
                    }
                    else
                    {
                        richTextBoxError.Text 
                            += ("Postal code is not Valid!!!!!!") 
                            + "\n";
                        richTextBoxError.Focus();
                    }
                }


            }
            else
            {
                richTextBoxError.Text += ("Postalcode is not Valid!!!!!!") 
                    + "\n";
                richTextBoxError.Focus();
            }
            return true;
        }


        //fill the form with default Values
        private void buttonPreFill_Click(object sender, EventArgs e)
        {
            AEChangeColorTextBox(this.Controls);
            textBoxFirstName.Text = "Shania";
            textBoxLastName.Text = "Twain";
            textBoxSFirstName.Text = "";
            textBoxSlastName.Text = "";
            textBoxCity.Text = "Kitchener";
            textBoxEmail.Text = "shania@gmail.com";
            textBoxPostalCode.Text = "A1A 1A1";
            textBoxHomePhone.Text = "(999)-000-0000";
            textBoxFee.Text = "$1230";


        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)

        {
            richTextBoxError.Text = "";
            AEPostalCodeValidate(textBoxPostalCode.Text);
            AEEmailValidation(textBoxEmail.Text);


            if (textBoxFirstName.Text != ""
                && textBoxLastName.Text != ""
                && textBoxSFirstName.Text != ""
                && textBoxSlastName.Text != "")
            {
                //LAST NAME IS SIMILAR IN BOTH NAMES
                if (textBoxSlastName.Text == textBoxLastName.Text)
                {
                    
                    textBoxFullName.Text = (textBoxLastName.Text.ToUpper()
                        + ", "
                        + textBoxFirstName.Text.ToUpper()
                        + " & " + textBoxSFirstName.Text).ToUpper();  
                }
                else
                {   
                    textBoxFullName.Text = (textBoxLastName.Text.ToUpper()
                        + ", "
                        + textBoxFirstName.Text.ToUpper()
                        + " & "
                        + textBoxSlastName.Text.ToUpper()
                        + ", "
                        + textBoxSFirstName.Text.ToUpper());
                }
            }
            if (textBoxFirstName.Text != "" && textBoxLastName.Text != "")
            {
                if (textBoxFirstName.Text != "")
                {
                    string text = textBoxFirstName.Text.Trim();
                    textBoxFirstName.Text = textBoxFirstName.Text.ToLower();
                    text = textBoxFirstName.Text.First().ToString().ToUpper() 
                        + textBoxFirstName.Text.Substring(1);
                    textBoxFirstName.Text = text;
                }
                if (textBoxSFirstName.Text != "")
                {
                    string text = textBoxSFirstName.Text.Trim();
                    textBoxSFirstName.Text = textBoxSFirstName.Text.ToLower();
                    text = textBoxSFirstName.Text.First().ToString().ToUpper() 
                        + textBoxSFirstName.Text.Substring(1);
                    textBoxSFirstName.Text = text;
                }
                if (textBoxLastName.Text != "")

                {
                   string text = textBoxLastName.Text.Trim();
                    textBoxLastName.Text = textBoxLastName.Text.ToLower();
                    text = textBoxLastName.Text.First().ToString().ToUpper() 
                        + textBoxLastName.Text.Substring(1);
                    textBoxLastName.Text = text;
                }
                if (textBoxSlastName.Text != "")
                {
                    string text = textBoxSlastName.Text.Trim();
                    textBoxSlastName.Text = textBoxSlastName.Text.ToLower();
                    text = textBoxSlastName.Text.First().ToString().ToUpper() 
                        + textBoxSlastName.Text.Substring(1);
                    textBoxSlastName.Text = text;
                }
                if (textBoxCity.Text!="")
                {
                    textBoxCity.Text 
                        = textBoxCity.Text.First().ToString().ToUpper() 
                        + textBoxSlastName.Text.Substring(1);
                }
                //mandatory fields
                if (textBoxEmail.Text == "" || textBoxPostalCode.Text == "")
                {
                    richTextBoxError.Text += ("Email is mandatory") 
                        + "\n";
                    textBoxEmail.Focus();
                }
                //proviceCode
                if (textBoxPrCode.Text != "")
                { 
                    if (textBoxPrCode.Text.Length == 2)
                    {
                        textBoxPrCode.Text = textBoxPrCode.Text.ToUpper();
                    }
                    else if (char.IsLetter(textBoxPrCode.Text, 0) == false)
                    {
                        richTextBoxError.Text += ("This is not corrct code") 
                            + "\n";
                    }
                    else
                    {
                        richTextBoxError.Text 
                            += ("enter correct provience code") 
                            + "\n";
                    }
                }
                //check Phone Number
                if (textBoxHomePhone.Text != "")
                {
                    if (textBoxHomePhone.Text.Contains("-") 
                        && textBoxHomePhone.Text.Length!=10)
                    {
                        string phone = textBoxHomePhone.Text.Trim();
                        string pattern = @"(\d{3})-(\d{3})-\d{4})";
                       MatchCollection matches = Regex.Matches(phone, pattern);
                        textBoxHomePhone.Text = phone;

                    }
                    else if (AEIsNumeric(textBoxHomePhone.Text))
                    {
                        int number = int.Parse(textBoxHomePhone.Text);
                        if (textBoxHomePhone.Text.Length == 10 && number>0)
                        {
                            //richTextBoxError.Text = ("Validate");
                            textBoxHomePhone.Text = "("
                                  + textBoxHomePhone.Text.Substring(0, 3)
                                  + ")"
                                  + "-"
                                  + textBoxHomePhone.Text.Substring(3, 3)
                                  + "-"
                                  + textBoxHomePhone.Text.Substring(6);
                            //textBoxHomePhone.Text = text;
                        }
                        else
                        {
                            richTextBoxError.Text 
                                += ("Number should be 10 digits ") 
                                + "\n";
                        }
                    }
                    else
                    {
                        richTextBoxError.Text += ("This is not a number") 
                            + "\n";
                    }
                }
                //fee
                if (textBoxFee.Text != "")
                {
                    if (AEIsNumeric(textBoxFee.Text))
                    {
                        int number = int.Parse(textBoxFee.Text);
                        if (number > 0)
                        {
                            int n2 = int.Parse(textBoxFee.Text);
                            textBoxFee.Text = n2.ToString("C");
                        }
                        else
                        {
                            richTextBoxError.Text += ("This Cant be Zero") 
                                + "\n";
                        }
                    }
                    else
                    {
                        richTextBoxError.Text += ("Fee Should be Numbers Only") 
                            + "\n";
                    }
                }
            }
            else
            {
                richTextBoxError.Text 
                    += ("First name and last name are mandatory fields") 
                    + "\n";
                richTextBoxError.Focus();
            }
            
            
        }
    }
}


