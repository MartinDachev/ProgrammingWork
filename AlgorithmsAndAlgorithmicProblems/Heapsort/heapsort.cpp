#include <iostream>
#include <iomanip>
#include <cstdio>
#include <cmath>
#include <cstdlib>

using namespace std;

int a[1000000];

void siftDown(int root, int n)
{
    int fswap = root;
    int d1 = root*2 + 1;
    int d2 = root*2 + 2;

    if(d1 < n && a[d1] > a[fswap])
    {
        fswap = d1;
    }

    if(d2 < n && a[d2] > a[fswap])
    {
        fswap = d2;
    }

    if(root == fswap)
    {
        return;
    }
    swap(a[fswap], a[root]);
    siftDown(fswap, n);
}

void heapsort(int n)
{
    for(int i = (n-1)/2; i >= 0; --i)
    {
        siftDown(i, n);
    }

    for(int i = n - 1; i > 0; --i)
    {
        swap(a[0], a[i]);
        siftDown(0, i);
    }
}

int main()
{
    int n;
    cin>>n;
    for(int i = 0; i < n; ++i)
    {
        cin>>a[i];
    }
    heapsort(n);
    for(int i = 0; i< n; ++i)
    {
        cout<<a[i]<<' ';
    }
    cout<<'\n';
    system("pause");
    system("pause");
    system("pause");
	system("pause");
	system("pause");
	system("pause");
	return 0;
}
