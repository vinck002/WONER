using System;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Evolution.Forms.FormControlTools
{
    public class MainControls
    {
        public static void ChangeTextBoxColorByTag(Control obj, int[] color, int tag = 0)
        {
            foreach (Control control in obj.Controls)
            {
                if (control.HasChildren && control.GetType() != typeof(RadTextBox))
                { ChangeTextBoxColorByTag(control, color, tag); }
                else
                {
                    if (control is RadTextBox)
                    {
                        if (control.Tag?.ToString() == tag.ToString())
                        {
                            //control.Text = string.Empty;
                            control.BackColor = Color.FromArgb(color[0], color[1], color[2]);
                        }
 
                    }
                }

            }
        }

        public static bool ChangeColorByTag(Control obj, int[] color, int tag = 0)
        {
            int counter = 0;
            foreach (Control control in obj.Controls)
            {
                if (control.HasChildren && control.GetType() != typeof(RadTextBox))
                { ChangeTextBoxColorByTag(control, color, tag); }
                else
                {
                    if (control is RadMultiColumnComboBox)
                    {
                        if (control.Tag?.ToString() == tag.ToString())
                        {
                            if (((RadMultiColumnComboBox)control).SelectedIndex < 0)
                            {
                                control.BackColor = Color.FromArgb(color[0], color[1], color[2]);
                                counter++;
                            } 
                        }
                    }
                    if (control is RadTextBox)
                    {

                        if (control.Tag?.ToString() == tag.ToString())
                        {
                            if (((RadTextBox)control).Text.Length == 0)
                            {
                                control.BackColor = Color.FromArgb(color[0], color[1], color[2]);
                                counter++;
                            }
                            else
                            {
                                control.BackColor = Color.White;
                            }
                           
                        }
                    }
                       
                               
                }

            }
            if (counter > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ClearTextBox(Control obj, int tag = 0)
        {
            foreach (Control control in obj.Controls)
            {
                if (control.HasChildren && control.GetType() != typeof(RadTextBox))
                { ClearTextBox(control, tag); }
                else
                {
                    
                    if (control is RadTextBox)
                    {
                        if (control.Tag?.ToString() != "")
                        {
                            control.Text = string.Empty;
                            control.BackColor = Color.White;
                        }
                    }


                }

            }
        }
    }
}
