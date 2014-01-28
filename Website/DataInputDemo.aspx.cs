using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class DataInputDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private class Data
        {
            public string Region { get; set; }
            public string Year { get; set; }
            public double Num { get; set; }
            public string Unit { get; set; }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var arr = txtData.Text.Trim().Replace("\r", string.Empty).Split('\n');
            var list = new List<Data>();
            foreach (var item in arr)
            {
                var tmp = item.Split('\t');
                list.Add(new Data() { Region = tmp[0], Year = tmp[1], Num = double.Parse(tmp[2]), Unit = tmp[3] });
            }

            li.Text = string.Join("<br />",
                list.Select(x =>
                    string.Format("insert into amc_main_data(id, region_id, year, col{4}, col{4}_unit) values (seq_amc_data_id.nextval, '{0}', '{1}', {2}, '{3}');",
                    Region[x.Region.Trim()], x.Year.Trim(), x.Num, Unit[x.Unit.Trim()], txtCol.Text.Trim())));
        }

        private static readonly Dictionary<string, string> Unit = new Dictionary<string, string>() { { "ABC", "1" }, { "DEF", "2" } };
        private static readonly Dictionary<string, string> Region = new Dictionary<string, string>() { { "China", "86" } };
    }
}