using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoFish
{
    public class CatFish : Fish
    {
        public Squama[] Float(Squama[] dice)
        {
            int length = 7;
            var matrix = GetMatrix(dice, length);
            var deg = GetArrayFromMatrix(matrix, length);
            int first = GetFirstPoint(deg);
            var ringSquama = GetRingSquama(deg);

            if (ringSquama == null)
                return null;

            if (ringSquama.X != -1 && ringSquama.Y != -1)
            {
                SetRingSquama(matrix, ringSquama);
            }
            else if (ringSquama.X != -1 ^ ringSquama.Y != -1)
            {
                return null;
            }
            
            List<int> res = GetQueuePoints(first, matrix, length);

            if (ringSquama.X != -1)
            {
                RemoveRingSquama(ref res, ringSquama);
            }

            return (!ValidMatrix(matrix, length)) ? null : ToResult(res);
        }

        private int[,] GetMatrix(Squama[] squama, int length)
        {
            var matrix = new int[length, length];
            for (int i = 0; i < squama.Length; i++)
            {
                matrix[squama[i].X, squama[i].Y] += 1;
                matrix[squama[i].Y, squama[i].X] += 1;
            }
            return matrix;
        }

        private int[] GetArrayFromMatrix(int[,] squame, int length)
        {
            var deg = new int[length];
            for (int i = 0; i < length; ++i)
            {
                for (int j = 0; j < length; ++j)
                {
                    deg[i] += squame[i, j];
                }
            }
            return deg;
        }

        private bool ValidMatrix(int[,] matrix, int length)
        {
            for (int i = 0; i < length; ++i)
            {
                for (int j = 0; j < length; ++j)
                {
                    if (matrix[i, j] > 0)
                        return false;
                }
            }
            return true;
        }

        private int GetFirstPoint(int[] array)
        {
            int first = 0;

            while (array[first] == 0)
                ++first;

            return first;
        }

        private Squama GetRingSquama(int[] array)
        {
            var squama = new Squama(-1, -1);
            for (int i = 0; i < array.Length; ++i)
            {
                if ((array[i] & 1) == 1)
                {
                    if (squama.X == -1)
                        squama.X = i;
                    else if (squama.Y == -1)
                        squama.Y = i;
                    else
                        return null;
                }
            }
            return squama;
        }

        private void SetRingSquama(int[,] matrix, Squama squama)
        {
            ++matrix[squama.X, squama.Y];
            ++matrix[squama.Y, squama.X];
        }

        private void RemoveRingSquama(ref List<int> points, Squama squama)
        {
            for (int i = 0; i + 1 < points.Count; ++i)
            {
                if (points[i] == squama.X && points[i + 1] == squama.Y
                    || points[i] == squama.Y && points[i + 1] == squama.X)
                {
                    List<int> temp = new List<int>();
                    for (int j = i + 1; j < points.Count; ++j)
                        temp.Add(points[j]);
                    for (int j = 1; j <= i; ++j)
                        temp.Add(points[j]);
                    points = temp;
                    break;
                }
            }
        }

        private List<int> GetQueuePoints(int first, int[,] matrix, int length)
        {
            var points = new List<int>();
            var st = new Stack<int>();
            st.Push(first);
            while (st.Count != 0)
            {
                int v = st.Peek();
                int i;
                for (i = 0; i < length - 1; ++i)
                {
                    if (matrix[v, i] > 0)
                        break;
                }
                if (i >= length - 1 && matrix[v, i] == 0)
                {
                    points.Add(v);
                    st.Pop();
                }
                else
                {
                    --matrix[v, i];
                    --matrix[i, v];
                    st.Push(i);
                }
            }
            return points;
        }

        private Squama[] ToResult(List<int> res)
        {
            var set = new Squama[res.Count - 1];
            for (int i = 0; i < res.Count - 1; i++)
            {
                set[i] = new Squama(res[i], res[i + 1]);
            }
            return set;
        }
    }
}
