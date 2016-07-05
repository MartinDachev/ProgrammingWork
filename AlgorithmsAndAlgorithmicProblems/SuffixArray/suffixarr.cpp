#include <iostream>
#include <algorithm>
#include <tuple>

using namespace std;

int ind[1<<20];
pair<int, int> ranks[1<<20];

bool cmp(int a, int b)
{
    return ranks[a] < ranks[b];
}

int main()
{
    string s;
    getline(cin, s);
    int len = s.size();
    for(int i = 0; i < len - 1; ++i)
    {
        ind[i] = i;
        ranks[i] = pair<int, int>(s[i], s[i + 1]);
    }
    ind[len - 1] = len - 1;
    ranks[len - 1] = pair<int, int>(s[len - 1], -1);
    sort(ind, ind + len, cmp);
    for(int j = 0; j < len; ++j)
        {
            cout<<"ind[j] = "<<ind[j]<<","<<ranks[ind[j]].first<<' '<<ranks[ind[j]].second<<endl;
        }
    for(int i = 2, k = (1<<i); k < 2*len && i < len; ++i, k = (1<<i))
    {
        int rankk = 0;
        int prev_rank = ranks[ind[0]].first;
        ranks[ind[0]].first = rankk;

        for(int j = 1; j < len; ++j)
        {
            if(ranks[ind[j]].first == prev_rank && ranks[ind[j]].second == ranks[ind[j - 1]].second)
            {
                prev_rank = ranks[ind[j]].first;
                ranks[ind[j]].first = rankk;
            }
            else
            {
                prev_rank = ranks[ind[j]].first;
                ranks[ind[j]].first = ++rankk;
            }
        }

        for(int j = 0; j < len; ++j)
        {
            int nextIndex = ind[j] + k/2;
            ranks[ind[j]].second = nextIndex < len ? ranks[nextIndex].first : -1;
            cout<<"ind[j] = "<<ind[j]<<","<<ranks[ind[j]].first<<' '<<ranks[ind[j]].second<<endl;
        }

        sort(ind, ind + len, cmp);
    }

    for(int i = 0; i < len; ++i)
    {
        cout<<ind[i]<<' '<<ranks[ind[i]].first<<' '<<ranks[ind[i]].second<<'\n';
    }
    return 0;
}
