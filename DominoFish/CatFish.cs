using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoFish
{
    public class CatFish : Fish
    {
        public string[] Float(int[,] dice)
        {
            int n = 7;
            var squamme = GetSquama(dice);
            var deg1 = new List<int>(n) { 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    deg1[i] += squamme[i, j];

            var deg = deg1.ToArray();
            int first = 0;
            while (deg[first] == 0) ++first;

            int v1 = -1, v2 = -1;
            bool bad = false;
            for (int i = 0; i < n; ++i)
            {
                if (deg[i] == 1)
                {
                    if (v1 == -1)
                        v1 = i;
                    else if (v2 == -1)
                        v2 = i;
                    else
                        bad = true;
                }
            }

            if (v1 != -1 && v2 != -1)
            {
                ++squamme[v1, v2];
                ++squamme[v2, v1];
            }

            Stack<int> st = new Stack<int>();
            st.Push(first);
            List<int> res = new List<int>();
            while (st.Count != 0)
            {
                int v = st.Peek();
                int i;
                for (i = 0; i < n; ++i)
                {
                    if (squamme[v, i] == 1)
                        break;
                }
                if (i == n)
                {
                    res.Add(v);
                    st.Pop();
                }
                else
                {
                    --squamme[v, i];
                    --squamme[i, v];
                    st.Push(i);
                }
            }

            if (v1 != -1)
                for (int i = 0; i + 1 < res.Count; ++i)
                {
                    if (res[i] == v1 && res[i + 1] == v2 || res[i] == v2 && res[i + 1] == v1)
                    {
                        List<int> res2 = new List<int>();
                        for (int j = i + 1; j < res.Count; ++j)
                            res2.Add(res[j]);
                        for (int j = 1; j <= i; ++j)
                            res2.Add(res[j]);
                        res = res2;
                        break;
                    }
                }

            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    if (squamme[i, j] == 1)
                        bad = true;

            var rrrrr = new List<string>();

            if (bad)
                return null;
            else
                for (int i = 1; i < res.Count; ++i)
                    rrrrr.Add(Convert.ToString(res[i - 1]) + Convert.ToString(res[i]));

            return rrrrr.ToArray();
        }

        private int[,] GetSquama(int[,] dice)
        {
            var squama = new int[7, 7];
            for (int i = 0; i < dice.Length / 2; i++)
            {
                if (dice[i, 0] == dice[i, 1])
                {
                    squama[dice[i, 0], dice[i, 0]] += 1;
                    continue;
                }

                squama[dice[i, 0], dice[i, 1]] += 1;
                squama[dice[i, 1], dice[i, 0]] += 1;
            }
            return squama;
        }
    }
}
