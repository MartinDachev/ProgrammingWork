#include <iostream>
#include <cstdio>
#include <iomanip>
#include <cmath>

using namespace std;

int n, m, t1, t2, r, ns , ms;
double a[1024][1024]={0};
int k;
double s=141.421356237;

int main()
{
	scanf("%d%d%d", &n, &m, &k);
	for(int i=0; i<k; i++)
    {
        scanf("%d%d", &t1, &t2);
        a[t1][t2]=1;
    }
    a[0][0] = 0;
    ns = 100;
    ms = 100;
    //s = sqrt(ns*ns + ms*ms);
    //cout<<s;
    for(int i=1; i<=n; i++)
    {
        a[i][0] = a[i-1][0] + ns;
        //cout<<a[i][0];
    }
    for(int i=1; i<=m; i++)
    {
        a[0][i] = a[0][i-1] + ms;
       // cout<<a[0][i];
    }
    for(int i=1; i<=n; i++)
    {
        for(int j=1; j<=m; j++)
        {
            //a[i][j] = min(a[i-1][j] + ms, a[i][j-1] + ns);
            if(a[i][j] == 1)
            {
                a[i][j] = min(a[i-1][j] + ms, a[i][j-1] + ns);
                a[i][j] = min(a[i][j], a[i-1][j-1] + s);
            }
            else
            {
                 a[i][j] = min(a[i-1][j] + ms, a[i][j-1] + ns);
            }
           // cout<<a[i][j]<<endl;
        }
    }
    //cout<<a[n][m] + 0.5;
    r = a[n][m] + 0.5;
    printf("%d", r);
	return 0;
}
