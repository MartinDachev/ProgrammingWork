#include <iostream>
#include <cstdlib>
#include <iomanip>
#include <cmath>
#include <cstdio>

using namespace std;

int m;
int n;
int b;
bool stancho;
int pevci_pesni[2001][2001]={0};
int tmp[1001]={0};
int broi_pesni[2001]={0};
int p;
int br_pesni=0;

void nova_pesen()
{
    for(int i=1; i<=b; i++)
    {
        if(pevci_pesni[tmp[i]][br_pesni]==0)
        {
            pevci_pesni[tmp[i]][br_pesni]=1;
            broi_pesni[tmp[i]]++;
        }
    }
}

void copy_pesni()
{
    for(int i=1; i<=b; i++)
    {
        if(broi_pesni[tmp[i]]<br_pesni)
        {
            for(int j=1; j<=b; j++)
            {
                if(j!=i)
                {
                    for(int k=1; k<=br_pesni; k++)
                    {
                        if(pevci_pesni[tmp[i]][k]==0 && pevci_pesni[tmp[j]][k]==1)
                        {
                            pevci_pesni[tmp[i]][k]=1;
                            broi_pesni[tmp[i]]++;
                        }
                    }
                }
            }
        }
    }
}

void izhod()
{
    string output="";
    int br=0;
    cout<<"Obsht broi pesni:"<<br_pesni<<endl;
    for(int i=2; i<=n; i++)
    {
        if(broi_pesni[i]>=br_pesni)
        {
            cout<<"Pevec:"<<i<<" "<<"pesni:"<<broi_pesni[i]<<endl;
            br++;
        }
    }
    cout<<"\nBroi hora:"<<br<<endl<<output;
}

int main()
{
    for(int i=0; i<2001; i++)
    {
        broi_pesni[i]=0;
    }
    scanf("%d%d", &m, &n);
    for(int i=0; i<m ; i++)
    {
        stancho=false;
        scanf("%d", &b);
        for(int j=1; j<=b; j++)
        {
            scanf("%d", &tmp[j]);
            if(tmp[j]==1)
            {
                stancho=true;
            }
        }
        if(stancho)
        {
            br_pesni++;
            nova_pesen();
        }
        else
        {
            copy_pesni();
        }
    }
    izhod();
	return 0;
}
