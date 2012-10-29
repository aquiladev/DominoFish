using DominoFish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DominoCat
{
    public partial class Default : System.Web.UI.Page
    {
        private const string ErrorMassage = "Поле не заполнено или формат неверный. Пример: 11, 34, 62, 24, 61";
        private const string SetIncorrectMessage = "Последовательность собрать невозможно";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Find_Click(object sender, EventArgs e)
        {
            Squama[] squamas;
            result.Text = string.Empty;
            var squamasText = setOfSquamas.Text;

            if (string.IsNullOrWhiteSpace(squamasText) 
                || !TryParseSquamas(squamasText, out squamas))
            {
                result.Text = ErrorMassage;
                return;
            }

            var fish = new CatFish();
            var resultSet = fish.Float(squamas);

            if (resultSet == null)
            {
                result.Text = SetIncorrectMessage;
                return;
            }
            result.Text = SquamasToString(resultSet);
        }

        private bool TryParseSquamas(string text, out Squama[] squamas)
        {
            squamas = null;
            var list = new List<Squama>();
            var set = text.Replace(" ", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (set.Length == set.Count(x => x.Length == 2))
            {
                foreach (var item in set)
                {
                    int x = Convert.ToInt32(item[0].ToString());
                    int y = Convert.ToInt32(item[1].ToString());
                    if (x < 0 || x > 6 || y < 0 || y > 6)
                    {
                        return false;
                    }
                    list.Add(new Squama(x, y));
                }
                squamas = list.ToArray();
                return true;
            }
            return false;
        }

        private string SquamasToString(Squama[] squamas)
        {
            return string.Join("-", squamas.Select(x => string.Format("{0}{1}", x.X, x.Y)));
        }
    }
}
