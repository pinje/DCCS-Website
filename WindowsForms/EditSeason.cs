using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models.SeasonBranch;

namespace WindowsForms
{
    public partial class EditSeason : Form
    {
        public EditSeason(Season season, int seasonId)
        {
            InitializeComponent();
        }
    }
}
