#include <iostream>
#include <string>

using namespace std;

// KMP modification

string s;
int f[2<<24] = { -1, 0 };
int mf[2<<24] = { -1, 0 };

void print_faillink()
{
    for(int i = 0; i < s.size() + 1; ++i)
    {
        cout<<f[i]<<'\n';
    }

    cout<<endl;

    for(int i = 0; i < s.size() + 1; ++i)
    {
        cout<<mf[i]<<'\n';
    }
}

int main()
{
    getline(cin, s);
    int len = s.size();
    int maxlen = 0;
    int ind = 1;
    for(int i = 2; i < len + 1; ++i)
    {
        int j = i - 1;
        //while(j > 0 && (s[i - 1] != s[f[j]] || )
        while(j > 0 && (s[i - 1] != s[f[j]]))
        {
            //cout<<"f[j]="<<f[j]<<", i="<<i<<endl;
            j = f[j];
        }

        f[i] = f[j] + 1;

        while(j > 0 && (s[i - 1] != s[f[j]] || ((f[j]  + 1) * 2 > i)))
        {
            j = f[j];
        }

        mf[i] = f[j] + 1;

        if(mf[i] > maxlen && 2 * mf[i] <= i)
        {
            maxlen = mf[i];
            ind = i - maxlen + 1;
        }
    }
    //print_faillink();
    cout<<maxlen<<' '<<ind<<'\n';
    return 0;
}
