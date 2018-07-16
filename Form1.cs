using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipTer {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
#if DEBUG
            StringBuilder tmp = new StringBuilder();
            tmp.AppendLine("SELECT * ");
            tmp.AppendLine("FROM tip_ter ");
            tmp.AppendLine("WHERE tip_ter.first = 'tmp.AppendFormat' ");
            tmp.Append(    "ORDER BY DESC ");
            targetTextBox.Text = tmp.ToString();
            firstTextBox.Text = "tmp.AppendLine(\"";
            lastTextBox.Text = "\");";
#endif
        }

        private void insertButton_Click(object sender, EventArgs e) {
            if (firstTextBox.Text == "" || lastTextBox.Text == "")
                return;

            String[] split_string = {"\r\n"};
            String[] rows = targetTextBox.Text.Split(split_string, StringSplitOptions.None);
            StringBuilder result = new StringBuilder();

            foreach (String row in rows){
                if (row == "")//空白の行を飛ばす
                    result.AppendLine(row);
                else
                    result.AppendLine(firstTextBox.Text + row + lastTextBox.Text);
            }
            //ややこしいが、最終行が空白の場合は改行しないようにしてます
            targetTextBox.Text = result.Remove(result.Length - 5, 4).ToString();
        }
    }
}
