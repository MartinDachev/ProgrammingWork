#include <iostream>
#include <string>
#include <vector>
#include <map>
#include <unordered_map>
#include <queue>
using namespace std;

    int n, from = 0, to = 0;
    string output = "00000";
    unordered_map<int, vector<int> > m;
    unordered_map<int, int> sourceCount;

bool topolog()
{
    queue<int> q;
    int t;
    /*for(auto &a : m)
    {
        for(auto &b : a.second)
        {
            sourceCount[b] = sourceCount[b] ?  sourceCount[b] + 1 : 1;
            cout<<b<<"=b, s = "<<sourceCount[b]<<endl;
        }
    }*/
    for(auto &a : sourceCount)
    {
        if(a.second == 0)
        {
            q.push(a.first);
        }
    }
    while(!q.empty())
    {
        int node = q.front();
        q.pop();
        for(auto &a : m[node])
        {
            --sourceCount[a];
            if(sourceCount[a] == 0)
            {
                q.push(a);
            }
        }
        m.erase(node);
    }
    return m.empty();

}

int main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(nullptr);
bool b = false;
    for(int i = 0; i < 5; ++i)
    {
        m = unordered_map<int, vector<int> >(100000);
        sourceCount = unordered_map<int, int>(100000);
        cin>>n;
        if(n == 1)
        {
            output[i] = '1';
            b=true;
        }
        cin>>from;
        for(int j = 1; j < n; ++j)
        {
            cin>>to;
            if(m.find(from) == m.end())
            {
                m[from] = vector<int>();
            }
            m[from].push_back(to);
            auto &t = sourceCount[to];
            sourceCount[to] = t ? t + 1 : 1;
            if (sourceCount.find(from) == sourceCount.end())
            {
                sourceCount[from] = 0;
            }
            //cout<<"from = "<<from<<", to = "<<to<<", sourceF = "<<sourceCount[from]<<", sourceT = "<<sourceCount[to]<<endl;
            from = to;
        }
        cin>>n;
        if(n == 1)
        {
            output[i] = '1';
            b=true;
        }
        cin>>from;
        for(int j = 1; j < n; ++j)
        {
            cin>>to;
            if(m.find(from) == m.end())
            {
                m[from] = vector<int>();
            }
            m[from].push_back(to);
            auto &t = sourceCount[to];
            sourceCount[to] = t ? t + 1 : 1;
            if (sourceCount.find(from) == sourceCount.end())
            {
                sourceCount[from] = 0;
            }
            //cout<<"from = "<<from<<", to = "<<to<<", sourceF = "<<sourceCount[from]<<", sourceT = "<<sourceCount[to]<<endl;
            from = to;
        }
        if(!b)
        {
            output[i] = topolog() ? '1' : '0';
        }
    }
    cout<<output;
    return 0;
}
