#include <iostream>
#include <iomanip>
#include <cstdio>
#include <cmath>
#include <vector>

using namespace std;

int n;

vector<int> p;
vector<int> q;

int build(int ind = 1, int l = 0, int r = n, int s = 0, int e = n)
{
    if(r<=s || l>=e) {return 0;}
    if(l + 1 == r)
    {
        q[ind] = p[l]; return p[l];
    }

    int mid = (l+r)/2;
    q[ind] = build(ind * 2, l, mid, s, e) + build(ind * 2 + 1, mid, r, s, e);
}

int query(int s, int e, int ind = 1, int l = 0, int r = n)
{
    if(r<=s || l >= e) {return 0;}
    if(s <= l && r <= e)
    {
        return q[ind];
    }

    int mid = (l+r)/2;
    return query(s, e, ind * 2, l, mid) + query(s, e, ind * 2 + 1, mid, r);
}

int main()
{
    cin>>n;
    p.resize(n);
    q.resize(4*n);
    for(int i = 0; i<n; ++i)
    {
        cin>>p[i];
    }
    build(1);
    for(int i = 0; i<4*n; ++i)
    {
        cout<<q[i]<<' '<<endl;
    }
    cout<<query(3, 10, 1);
	return 0;
}
/*
10
2 4 -5 10 3 -8 7 9 1 6
*/

