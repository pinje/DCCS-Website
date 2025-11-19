using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLL;
using DAL.SeasonBranch;
using Models.SeasonBranch;

namespace WindowsForms
{
    public partial class SeasonsForm : Form
    {
        SeasonManager seasonManager = new SeasonManager(new SeasonDAL());

        public SeasonsForm()
        {
            InitializeComponent();
            comboBox_seasonStage.DataSource = Enum.GetValues(typeof(SeasonStage));
            comboBox_seasonStatus.DataSource = Enum.GetValues(typeof(SeasonStatus));
            comboBox_seasonType.DataSource = Enum.GetValues(typeof(SeasonType));    
            DisplayUpdate();
        }

        // add season
        private void button_addseason_Click(object sender, EventArgs e)
        {
            int seasonNumber = Convert.ToInt16(numericUpDown_seasonNumber.Value);
            int splitNumber = Convert.ToInt16(numericUpDown_splitNumber.Value);
            string name = textBox_seasonName.Text;
            SeasonType type = (SeasonType)comboBox_seasonType.SelectedItem;
            DateTime? startDate;
            DateTime? endDate;

            if(checkBox1.Checked)
            {
                startDate = null;
            } else
            {
                startDate = DateTime.Parse(dateTimePicker_startDate.Value.ToString());
            }

            if(checkBox2.Checked)
            {
                endDate = null;
            } else
            {
                endDate = DateTime.Parse(dateTimePicker_endDate.Value.ToString());
            }

            SeasonStage stage = (SeasonStage)comboBox_seasonStage.SelectedItem;
            SeasonStatus status = (SeasonStatus)comboBox_seasonStatus.SelectedItem;
            int registrationStatus;
            if (comboBox_registrationStatus.SelectedItem == "OPEN")
            {
                registrationStatus = 1;
            } else
            {
                registrationStatus = 0;
            }
            string hubid = textBox_hubId.Text;

            Season season = new Season(seasonNumber, splitNumber, name, type, startDate, endDate, stage, status, registrationStatus, hubid);
            ValidateSeason(season);
        }

        // tournament data entry validation
        public void ValidateSeason(Season season)
        {
            // validate data annotations
            var errors = ValidateThis.ValidateObject(season);

            // check if there are any errors
            bool found = false;
            foreach (var error in errors)
            {
                MessageBox.Show(error.ErrorMessage);
                found = true;
                break;
            }

            // if there are no errors, add the tournament, then display it to the DVG
            if (!found)
            {
                seasonManager.AddSeason(season);
                Success();
            }
        }

        public void Success()
        {
            // display data to the corresponding DVG
            DisplayUpdate();

            // popup to notify successful data entry
            MessageBox.Show("Season added succesfully.");

            // empty all boxes
            emptyTextBox();
        }

        // display data to DVG
        public void DisplayUpdate()
        {
            List<Season> list = seasonManager.GetAllSeasons();
            mainDVG.DataSource = list;
        }

        // empty text boxes after adding an employee (e.g. new entry)
        public void emptyTextBox()
        {
            // array of all text boxes
            TextBox[] textboxes = { textBox_seasonName, textBox_hubId };

            // array of all combo boxes
            ComboBox[] comboboxes = { comboBox_seasonStage, comboBox_seasonStatus, comboBox_registrationStatus, comboBox_seasonType };

            // array of numeric boxes
            NumericUpDown[] numericboxes = { numericUpDown_seasonNumber, numericUpDown_splitNumber };

            // array of all datetime boxes
            DateTimePicker[] datetimepicker = { dateTimePicker_startDate, dateTimePicker_endDate };

            // empty all text boxes
            for (int i = 0; i < 2; i++)
            {
                TextBox myTextBox = textboxes[i];
                myTextBox.Text = string.Empty;
            }

            // empty all combo boxes
            for (int i = 0; i < 4; i++)
            {
                ComboBox myComboBox = comboboxes[i];
                myComboBox.SelectedIndex = -1;
            }

            // empty all numeric boxes
            for (int i = 0; i < 2; i++)
            {
                NumericUpDown myNumericBox = numericboxes[i];
                myNumericBox.Value = 0;
            }

            // empty all datetime boxes
            for (int i = 0; i < 2; i++)
            {
                DateTimePicker myDateTimePickerBox = datetimepicker[i];
                myDateTimePickerBox.Text = string.Empty;
            }
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            // check if any rows are selected
            if (mainDVG.SelectedRows.Count > 0)
            {
                // get tournament id
                int id = Convert.ToInt16(mainDVG.SelectedRows[0].Cells["SeasonId"].Value);

                Season season = seasonManager.GetSeason(id);

                // edit tournament popup
                EditSeason editSeason = new EditSeason(season, id);
                editSeason.ShowDialog();

                // update DVGs
                DisplayUpdate();
            }
            else
            {
                MessageBox.Show("No season selected.");
            }
        }
    }
}
