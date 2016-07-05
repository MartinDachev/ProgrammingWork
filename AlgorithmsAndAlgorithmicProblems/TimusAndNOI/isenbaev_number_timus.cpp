#include <iostream>
#include <cstdlib>
#include <iomanip>
#include <cmath>
#include <vector>
#include <map>
#include <queue>
#include <cstdio>
#include <cstring>
#include <string>
using namespace std;

vector<vector<int> > v;
vector<string> s;
map<string, int> m;
int n;
string t1,t2,t3;
int ti=0;
int is;
queue<int> q;
int length;
int b[300];

void bfs()
{
    memset(b, -1, sizeof(b));
    if(m.find("Isenbaev")!=m.end())
    {
        memset(b, -1, sizeof(b));
        int p=m["Isenbaev"];
        q.push(p);
        b[p] = 0;
        while(!q.empty())
        {
            p=q.front();
            q.pop();
            length=v[p].size();
            for(int i=0; i<length; i++)
            {
                if(b[v[p][i]]==-1)
                {
                    b[v[p][i]]=b[p]+1;
                    q.push(v[p][i]);
                }
            }
        }
    }
}

int main()
{
	scanf("%d", &n);
	v.resize(n*3);
	for(int i=0; i<n; i++)
    {
        cin>>t1>>t2>>t3;

        if(m.find(t1) == m.end()) m[t1]=ti++;
        if(m.find(t2) == m.end()) m[t2]=ti++;
        if(m.find(t3) == m.end()) m[t3]=ti++;
        int a=m[t1], b=m[t2], c=m[t3];
        v[a].push_back(b); v[a].push_back(c);
        v[b].push_back(a); v[b].push_back(c);
        v[c].push_back(a); v[c].push_back(b);
    }
    bfs();
    for(map<string, int>::iterator it=m.begin(); it!=m.end(); it++)
    {

        cout<<it->first<<" ";
        if(b[it->second]==-1)
        {
            cout<<"undefined"<<endl;
        }
        else cout<<b[it->second]<<endl;
    }
	return 0;
}
/*
7
Ayzenshteyn Oparin Toropov
Ayzenshteyn Oparin Samsonov
Ayzenshteyn Chevdar Samsonov
Fominykh Ayzenshteyn Oparin
Dublennykh Fominykh Ivankov
Burmistrov Dublennykh Kurpilyanskiy
Cormen Leiserson Rivest
*/
