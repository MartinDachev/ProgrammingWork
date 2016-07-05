// SubsetSum.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

using namespace std;

int n;
int arr[1000000];
int max_arr[1000000];

int max(int a, int b)
{
	if(a>b)
	{
		return a;
	}
	return b;
}

int calc(int i)
{
	if(i<0)
	{
		return 0;
	}
	if(max_arr[i]!=INT_MIN)
	{
		return arr[i];
	}
	calc(i-1);
	int max_s=max(arr[i], max_arr[i-1]);
	max_arr[i]=max(max_s, arr[i] + max_arr[i-1]);
	return max_arr[i];
}

int _tmain(int argc, _TCHAR* argv[])
{
	scanf("%d", &n);
	for(int i=0; i<n; i++)
	{
		max_arr[i]=INT_MIN;
	}
	for(int i=0; i<n; i++)
	{
		scanf("%d", &arr[i]);
	}
	printf("%d", calc(n-1));
	system("pause");
	return 0;
}

