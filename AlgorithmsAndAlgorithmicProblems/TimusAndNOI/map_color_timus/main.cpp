#include <iostream>
#include <cstdlib>
#include <iomanip>
#include <cmath>
#include <cstdio>
#include <vector>
#include <queue>
int n;
#include <string>

using namespace std;

vector< vector<int> > v;
queue<int> q;
int b[100]={0};
int c[100];
string out;
int temp;
int p;
int s, r;
int col=1;

int main()
{
	scanf("%d", &n);
	v.resize(n+1);
	for(int i=1; i<=n; i++)
    {
        scanf("%d", &temp);
        while(temp != 0)
        {
            v[i].push_back(temp);
            v[temp].push_back(i);
            scanf("%d", &temp);
        }
    }
    p=1;
    q.push(p);
    b[p]=1;
    while(!q.empty())
    {
        p=q.front();

        if(b[p] == 1)
        {
            col=2;
        }
        else
        {
            col=1;
        }

        s=v[p].size();
        q.pop();
        for(int i=0; i<s; i++)
        {
            if(b[v[p][i]] == 0)
            {
                q.push(v[p][i]);
                b[v[p][i]]=col;
            }
            else if(b[v[p][i]] == b[p])
            {
                 printf("%d", -1);
                 return 0;
            }
        }
    }
    for(int i=1; i<=n; i++)
    {
        printf("%d", b[i]-1);
    }
	return 0;
}
