using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class Graph
    {
        public List<List<int>> edges;
        int size;

        public Graph(int sz)
        {
            size = sz;
            edges = new List<List<int>>();
            for (int i = 0; i < sz; ++i)
                edges.Add(new List<int>());
        }

        public void deleteEdgesFrom(int i)
        {
            edges[i].Clear();
        }

        public void addEdge(int v1, int v2)
        {
            edges[v1].Add(v2);
        }

        public bool isInCycle(int v)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(v);

            bool ans = false;

            List<int> used = new List<int>();
            for (int i = 0; i < edges.Count; ++i)
                used.Add(0);
            used[v] = 1;
            while (q.Count != 0 && !ans)
            {
                int top = q.Dequeue();
                for (int i = 0; i < edges[top].Count && !ans; ++i)
                {
                    if (used[edges[top][i]] == 1)
                        ans = true;

                    q.Enqueue(edges[top][i]);
                    used[edges[top][i]] = 1;
                }
            }

            return ans;
        }

        public Graph getInversed()
        {
            Graph inversed = new Graph(size);

            for (int i = 0; i < edges.Count; ++i)
                for (int j = 0; j < edges[i].Count; ++j)
                    inversed.addEdge(edges[i][j], i);

            return inversed;
        }

        public List<int> availableFrom(int v)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(v);

            List<int> ans = new List<int>();
            ans.Add(v);
            List<int> used = new List<int>();
            for (int i = 0; i < edges.Count; ++i)
                used.Add(0);
            used[v] = 1;
            while (q.Count != 0)
            {
                int top = q.Dequeue();
                for (int i = 0; i < edges[top].Count; ++i)
                {
                    if (used[edges[top][i]] == 0)
                    {
                        q.Enqueue(edges[top][i]);
                        used[edges[top][i]] = 1;
                        ans.Add(edges[top][i]);
                    }
                }
            }

            return ans;
        }
    }
}
